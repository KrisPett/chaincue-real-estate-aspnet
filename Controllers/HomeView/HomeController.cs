using chaincue_real_estate_aspnet.DTOs;
using chaincue_real_estate_aspnet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chaincue_real_estate_aspnet.Controllers.HomeView
{
    [ApiController]
    [Route("home")]
    public class HomePageController : ControllerBase
    {
        //private readonly HouseHelper _houseHelper;
        //private readonly CountryHelper _countryHelper;
        private readonly ILogger<HomePageController> _logger;

        public HomePageController(ILogger<HomePageController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetHomePage()
        {
            _logger.LogInformation("HomePage");
            var dto = await ToHomePageDTOAsync();
            return Ok(dto);
        }

        private async Task<HomePageDTO> ToHomePageDTOAsync(Func<DTOBuilder, DTOBuilder>? additionalProcessing = null)
        {
            var dtoBuilder = new DTOBuilder();
            additionalProcessing?.Invoke(dtoBuilder);

            //_countryHelper.UpdateDTOBuilderWithCountries(dtoBuilder);
            //_houseHelper.UpdateDTOBuilderWithHouses(dtoBuilder);

            return await Task.FromResult(ToDTO(dtoBuilder));
        }

        private static HomePageDTO ToDTO(DTOBuilder dtoBuilder)
        {
            return new HomePageDTO
            {
                Countries = dtoBuilder.Countries.Select(ToDTO).ToArray(),
                RecentlyAddedHouses = dtoBuilder.Houses.Select(ToDTO).ToArray()
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
