namespace chaincue_real_estate_aspnet.Exceptions
{
    public class BrokerNotFoundException : Exception
    {
        public BrokerNotFoundException(string id) : base($"Broker not found. Id: {id}")
        {
        }
    }
}
