namespace chaincue_real_estate_aspnet.Exceptions
{
    public class HouseImageNotFoundException : Exception
    {
        public HouseImageNotFoundException(string id) : base($"House image not found. Id: {id}")
        {
        }
    }
}
