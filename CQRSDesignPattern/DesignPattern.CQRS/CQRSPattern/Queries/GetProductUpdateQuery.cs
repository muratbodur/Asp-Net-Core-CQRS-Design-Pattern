namespace DesignPattern.CQRS.CQRSPattern.Queries
{
	public class GetProductUpdateQuery
	{
		public GetProductUpdateQuery(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
