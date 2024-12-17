namespace chaincue_real_estate_aspnet.Exceptions
{
    public class HouseNotFoundException : Exception
    {
        public HouseNotFoundException(string id) : base($"House not found. Id: {id}")
        {
        }
    }
}
