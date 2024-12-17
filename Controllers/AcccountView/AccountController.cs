using chaincue_real_estate_aspnet.Controllers.HomeView;
using chaincue_real_estate_aspnet.DTOs;
using chaincue_real_estate_aspnet.Models;
using chaincue_real_estate_aspnet.Services.DTOBuilderHelpers;
using chaincue_real_estate_aspnet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chaincue_real_estate_aspnet.Controllers.AcccountView
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            ILogger<AccountController> logger,
            CountryHelper countryHelper,
            HouseHelper houseHelper)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAccountPage()
        {
            _logger.LogInformation("GetAccountPage");
            var dto = ToAccountPageDTO();
            return Ok(dto);
        }

        private AccountPageDTO ToAccountPageDTO(Func<DTOBuilder, DTOBuilder>? additionalProcessing = null)
        {
            var dtoBuilder = new DTOBuilder();
            additionalProcessing?.Invoke(dtoBuilder);

            return ToDTO(dtoBuilder);
        }

        private static AccountPageDTO ToDTO(DTOBuilder dtoBuilder)
        {
            return new AccountPageDTO
            {
                Id = "id"
            };
        }

        private class DTOBuilder
        {
        }
    }
}
