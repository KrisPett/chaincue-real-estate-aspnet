using chaincue_real_estate_aspnet.Data;
using chaincue_real_estate_aspnet.Models;
using Microsoft.EntityFrameworkCore;

namespace chaincue_real_estate_aspnet.Services
{
    public class CountryService: CountryServiceI
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<Country> FindAll()
        {
            return _dbContext.Countries.ToList();
        }

        public Country Save(Country.CountryNames countryNames)
        {
            var country = Country.Create(countryNames);
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return country;
        }
    }
}
