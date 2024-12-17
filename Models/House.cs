namespace chaincue_real_estate_aspnet.Models
{
    public class House
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int NumberRooms { get; set; }
        public int Beds { get; set; }
        public string Price { get; set; } = string.Empty;
        public required string Src { get; set; }
        public bool Sold { get; set; }
        public required string HouseTypes { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public List<HouseImage> Images { get; set; } = new List<HouseImage>();
        public Broker? Broker { get; set; }

        public enum HouseTypesEnum
        {
            CONDOMINIUM,
            VILLA,
            TOWNHOUSE,
            VACATION_HOME,
            ESTATES_AND_FARMS,
            LAND,
            OTHER_HOUSES
        }

        public static House Create(HouseTypesEnum houseTypes, string src)
        {
            return new House
            {
                Id = Guid.NewGuid(),
                Src = src,
                Sold = false,
                HouseTypes = houseTypes.ToString()
            };
        }
    }
}
