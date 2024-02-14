using DesignPattern.CQRS.CQRSPattern.Queries;
using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
	public class GetProductUpdateHandler
	{

		private readonly Context _context;

		public GetProductUpdateHandler(Context context)
		{
			_context = context;
		}



		public GetProductUpdateResult Handle(GetProductUpdateQuery query)
		{
			var values = _context.Set<Product>().Find(query.Id);
			return new GetProductUpdateResult
			{
				Description= values.Description,
				Name = values.Name,
				Price = values.Price,
				Stock = values.Stock
			};
			
		}
	}
}
