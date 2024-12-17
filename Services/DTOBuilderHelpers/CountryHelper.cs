using chaincue_real_estate_aspnet.Models;

namespace chaincue_real_estate_aspnet.Services.DTOBuilderHelpers
{
    public class CountryHelper
    {
        private readonly CountryService _countryService;

        public CountryHelper(CountryService countryService)
        {
            _countryService = countryService;
        }

        public Func<B, B> UpdateDTOBuilderWithCountries<B>(Action<B, List<Country>> setCountries)
        {
            return dtoBuilder =>
            {
                var countries = _countryService.FindAll();
                setCountries(dtoBuilder, countries);
                return dtoBuilder;
            };
        }
    }
}
