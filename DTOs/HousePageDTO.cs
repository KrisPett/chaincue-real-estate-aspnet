namespace chaincue_real_estate_aspnet.DTOs
{
    public class HousePageDTO
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Type { get; set; }
        public  required string Location { get; set; }
        public required int NumberOfRooms { get; set; }
        public required int Beds { get; set; }
        public required string DollarPrice { get; set; }
        public required string CryptoPrice { get; set; }
        public required string Description { get; set; }
        public required HouseImageDTO[] Images { get; set; }
        public required BrokerDTO? Broker { get; set; }

        public class HouseImageDTO
        {
            public required string Id { get; set; }
            public required string Url { get; set; }
        }

        public class BrokerDTO
        {
            public required string Id { get; set; }
            public required string Name { get; set; }
            public required string PhoneNumber { get; set; }
            public required string Email { get; set; }
        }
    }
}
