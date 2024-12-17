namespace chaincue_real_estate_aspnet.Models
{
    public class HouseImage
    {
        public Guid Id { get; set; }
        public required string Url { get; set; }

        public static HouseImage Create(string url)
        {
            return new HouseImage
            {
                Url = url
            };
        }
    }
}
