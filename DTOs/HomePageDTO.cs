namespace chaincue_real_estate_aspnet.DTOs
{
    public class HomePageDTO
    {
        public required CountryDTO[] Countries { get; set; }
        public required HouseDTO[] RecentlyAddedHouses { get; set; }

        public class CountryDTO
        {
            public required string Name { get; set; }
        }

        public class HouseDTO
        {
            public required string Id { get; set; }
            public required string Title { get; set; }
            public required string Location { get; set; }
            public int NumberRooms { get; set; }
            public int Beds { get; set; }
            public required string DollarPrice { get; set; }
            public required string CryptoPrice { get; set; }
            public required string Src { get; set; }
        }
    }
}
