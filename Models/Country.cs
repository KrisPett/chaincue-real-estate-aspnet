namespace chaincue_real_estate_aspnet.Models
{
    public class Country
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
  
        public static Country Create(CountryNames name)
        {
            return new Country
            {
                Name = name.ToString()
            };
        }

        public enum CountryNames
        {
            SWEDEN,
            SPAIN
        }
    }
}
