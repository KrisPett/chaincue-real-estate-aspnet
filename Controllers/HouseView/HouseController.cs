using chaincue_real_estate_aspnet.Controllers.HomeView;
using chaincue_real_estate_aspnet.DTOs;
using chaincue_real_estate_aspnet.Models;
using chaincue_real_estate_aspnet.Services.DTOBuilderHelpers;
using chaincue_real_estate_aspnet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static chaincue_real_estate_aspnet.DTOs.HousePageDTO;

namespace chaincue_real_estate_aspnet.Controllers.HouseView
{
    [Route("house")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly ILogger<HouseController> _logger;
        private readonly HouseHelper _houseHelper;

        public HouseController(
            ILogger<HouseController> logger,
            HouseHelper houseHelper)
        {
            _logger = logger;
            _houseHelper = houseHelper;
        }

        [HttpGet("{houseId}")]
        public IActionResult GetHousePage(String houseId)
        {
            _logger.LogInformation("GetHousePage");
            var dto = ToHousePageDTO(houseId);
            return Ok(dto);
        }

        private HousePageDTO ToHousePageDTO(string id, Func<DTOBuilder, DTOBuilder>? additionalProcessing = null)
        {
            var dtoBuilder = new DTOBuilder();
            additionalProcessing?.Invoke(dtoBuilder);

            _houseHelper.UpdateDTOBuilderWithHouseByHouseId<DTOBuilder>(id, (builder, house) => { builder.House = house; }).Invoke(dtoBuilder);

            return ToDTO(dtoBuilder);
        }

        private static HousePageDTO ToDTO(DTOBuilder dtoBuilder)
        {
            return new HousePageDTO
            {
                Id = dtoBuilder.House?.Id.ToString() ?? string.Empty,
                Title = dtoBuilder.House?.Title ?? string.Empty,
                Type = dtoBuilder.House?.HouseTypes ?? string.Empty, 
                Location = dtoBuilder.House?.Location ?? string.Empty,
                NumberOfRooms = dtoBuilder.House?.NumberRooms ?? 0,
                Beds = dtoBuilder.House?.Beds ?? 0,
                DollarPrice = dtoBuilder.House?.Price ?? string.Empty,
                CryptoPrice = dtoBuilder.House?.Price ?? string.Empty, 
                Description = dtoBuilder.House?.Description ?? string.Empty,
                Images = dtoBuilder.House?.Images?.Select(ToDTO).ToArray() ?? Array.Empty<HousePageDTO.HouseImageDTO>(),
                Broker = dtoBuilder.House?.Broker != null ? HouseController.ToDTO(dtoBuilder.House.Broker) : null,
            };
        }

        private static HousePageDTO.HouseImageDTO ToDTO(HouseImage houseImage)
        {
            return new HousePageDTO.HouseImageDTO
            {
                Id = houseImage.Id.ToString(),
                Url = houseImage.Url,
            };
        }

        private static HousePageDTO.BrokerDTO ToDTO(Broker? broker)
        {
            return new HousePageDTO.BrokerDTO
            {
                Id = broker?.Id.ToString() ?? string.Empty,
                Email = broker?.Email ?? string.Empty,
                Name = broker?.Name ?? string.Empty,
                PhoneNumber = broker?.PhoneNumber ?? string.Empty
            };
        }

        private class DTOBuilder
        {
            public House? House { get; set; }
        }
    }
}
