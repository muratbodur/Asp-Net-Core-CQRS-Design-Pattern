using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.CQRSPattern.Handlers;
using DesignPattern.CQRS.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.CQRS.Controllers
{
	public class DefaultController : Controller
	{
		private readonly GetProductQueryHandler _getProductQueryHandler;
		private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
		private readonly RemoveProductCommandHandler _removeProductCommandHandler;
		private readonly GetProductUpdateHandler _getProductUpdateHandler;
		private readonly UpdateProductCommandHandler _updateProductCommandHandler;

		public DefaultController(CreateProductCommandHandler createProductCommandHandler, GetProductQueryHandler getProductQueryHandler, GetProductByIdQueryHandler getProductByIdQueryHandler, RemoveProductCommandHandler removeProductCommand, GetProductUpdateHandler getProductUpdateHandler, UpdateProductCommandHandler updateProductCommandHandler)
		{
			_createProductCommandHandler = createProductCommandHandler;
			_getProductQueryHandler = getProductQueryHandler;
			_getProductByIdQueryHandler = getProductByIdQueryHandler;
			_removeProductCommandHandler = removeProductCommand;
			_getProductUpdateHandler = getProductUpdateHandler;
			_updateProductCommandHandler = updateProductCommandHandler;
		}



		public IActionResult Index()
		{
			var values = _getProductQueryHandler.Handle();
			return View(values);
		}

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]
		public IActionResult AddProduct(CreateProductCommand command)
		{ 
			_createProductCommandHandler.Handle(command);	
			return RedirectToAction("Index");
		}

		public IActionResult GetProduct(int id) 
		{
			var values = _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
			return View(values);

		}


		public IActionResult DeleteProduct(int id)
		
		{
			_removeProductCommandHandler.Handle(new RemoveProductCommand(id));
			return RedirectToAction("Index");

		}


		[HttpGet]
		public IActionResult UpdateProduct(int id)
		{
			var values = _getProductUpdateHandler.Handle(new GetProductUpdateQuery(id));
			return View(values);	
		}



		[HttpPost]
		public IActionResult UpdateProduct(UpdateProductCommand command)
		{
			_updateProductCommandHandler.Handle(command);
			return RedirectToAction("Index");

		}


	}
}
