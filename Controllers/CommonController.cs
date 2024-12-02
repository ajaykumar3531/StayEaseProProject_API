using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StayEasePro_Application.CommonRepos.Contracts;
using StayEasePro_Application.Repos.Contracts;
using StayEasePro_Application.Repos.Services;

namespace StayEasePro_API.Controllers
{
    [Route("api/common")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly ICommonService _commonService;

        public CommonController(ILoggerService loggerService, ICommonService commonService)
        {
            _loggerService = loggerService;
            _commonService = commonService;
        }

        [HttpPost("GetAllStates")]
        public async Task<IActionResult> GetAllStates(string CountryID)
        {
            try
            {
                
                CountryID = "88B05421-0929-49A6-BD54-01CF157540E2";
                var response = await _commonService.GetAllStates(CountryID);
                if (response.StatusCode == StatusCodes.Status200OK && !string.IsNullOrEmpty(response.StatusMessage))
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                await _loggerService.LocalLogs(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        [HttpPost("GetAllCities")]
        public async Task<IActionResult> GetAllCities(string StateID)
        {
            try
            {
                
                StateID = "C5003C83-9095-4179-ABF3-CC389B9648E9";
                var response = await _commonService.GetAllCities(StateID);
                if (response.StatusCode == StatusCodes.Status200OK && !string.IsNullOrEmpty(response.StatusMessage))
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                await _loggerService.LocalLogs(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
