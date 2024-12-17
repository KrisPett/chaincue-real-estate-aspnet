using chaincue_real_estate_aspnet.Data;
using chaincue_real_estate_aspnet.DTOs;
using chaincue_real_estate_aspnet.Models;
using chaincue_real_estate_aspnet.Services;
using chaincue_real_estate_aspnet.Services.DTOBuilderHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chaincue_real_estate_aspnet.Controllers.HomeView
{
    [ApiController]
    [Route("home")]
    public class HomePageController : ControllerBase
    {
        private readonly ILogger<HomePageController> _logger;
        private readonly CountryHelper _countryHelper;
        private readonly HouseHelper _houseHelper;

        public HomePageController(
            ILogger<HomePageController> logger,
            CountryHelper countryHelper,
            HouseHelper houseHelper)
        {
            _logger = logger;
            _countryHelper = countryHelper;
            _houseHelper = houseHelper;
        }

        [HttpGet]
        public IActionResult GetHomePage()
        {
            _logger.LogInformation("HomePage");
            var dto = ToHomePageDTO();
            return Ok(dto);
        }

        private HomePageDTO ToHomePageDTO(Func<DTOBuilder, DTOBuilder>? additionalProcessing = null)
        {
            var dtoBuilder = new DTOBuilder();
            additionalProcessing?.Invoke(dtoBuilder);

            _countryHelper.UpdateDTOBuilderWithCountries<DTOBuilder>((builder, countries) => { builder.Countries = countries; }).Invoke(dtoBuilder);
            _houseHelper.UpdateDTOBuilderWithHouses<DTOBuilder>((builder, houses) => { builder.Houses = houses; }).Invoke(dtoBuilder);

            return ToDTO(dtoBuilder);
        }

        private static HomePageDTO ToDTO(DTOBuilder dtoBuilder)
        {
            return new HomePageDTO
            {
                Countries = dtoBuilder.Countries.Select(ToDTO).ToArray(),
                RecentlyAddedHouses = dtoBuilder.GetHouses().Select(ToDTO).ToArray()
            };
        }

        private static HomePageDTO.CountryDTO ToDTO(Country country)
        {
            return new HomePageDTO.CountryDTO
            {
                Name = country.Name
            };
        }

        private static HomePageDTO.HouseDTO ToDTO(House house)
        {
            return new HomePageDTO.HouseDTO
            {
                Id = house.Id.ToString(),
                Title = house.Title,
                Location = house.Location,
                NumberRooms = house.NumberRooms,
                Beds = house.Beds,
                DollarPrice = house.Price.ToString(),
                CryptoPrice = "₿32.346",
                Src = house.Src
            };
        }
        private class DTOBuilder
        {
            public List<Country> Countries { get; set; } = new List<Country>();
            public List<House> Houses { get; set; } = new List<House>();

            public List<House> GetHouses()
            {
                return Houses
                    .OrderByDescending(h => h.Timestamp)
                    .Take(6)
                    .ToList();
            }
        }
    }
}
