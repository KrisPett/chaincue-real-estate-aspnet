using chaincue_real_estate_aspnet.Models;

namespace chaincue_real_estate_aspnet.Services
{
    public interface CountryServiceI
    {
        Country Save(Country.CountryNames countryNames);
        List<Country> FindAll();
    }
}
