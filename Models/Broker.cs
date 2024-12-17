namespace chaincue_real_estate_aspnet.Models
{
    public class Broker
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }

        public static Broker Create(string email)
        {
            return new Broker
            {
                Name = string.Empty,
                PhoneNumber = string.Empty,
                Email = email 
            };
        }
    }
}
