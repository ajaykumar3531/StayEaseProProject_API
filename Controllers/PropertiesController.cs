using Microsoft.AspNetCore.Mvc;
using StayEasePro_Application.CommonRepos.Contracts;
using StayEasePro_Application.Repos.Contracts;
using StayEasePro_Domain.DTO_s.Requests;
using StayEasePro_Domain.DTO_s.Responses;

namespace StayEasePro.Controllers
{
    //[Authorize]
    [Route("api/Properties")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ILoggerService _loggerService;
        private readonly IPropertyService _propertyService;

        public PropertiesController(ILoggerService loggerService, IPropertyService ownerService)
        {
            _loggerService = loggerService;
            _propertyService = ownerService;
        }

        #region PropertyRegion
        [HttpPost("CreateProperty")]
        public async Task<IActionResult> CreateProperty(CreatePropertyRequest request)
        {
            try
            {
                // string UserID = GlobalUserContext.UserID.ToUpper();
                string UserID = "2FFD76E6-4638-4214-8963-5DC5B6006C6A";
                var response = await _propertyService.CreateProperty(request, UserID);
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

        [HttpPost("UpdateProperty")]
        public async Task<IActionResult> UpdateProperty(UpdatePropertyRequest request)
        {
            try
            {
                // string UserID = GlobalUserContext.UserID.ToUpper();
                string UserID = "2FFD76E6-4638-4214-8963-5DC5B6006C6A";
                var response = await _propertyService.UpdateProperty(request, UserID);
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

        [HttpPost("GetAllProperties")]
        public async Task<IActionResult> GetAllProperties()
        {
            try
            {
                // string UserID = GlobalUserContext.UserID.ToUpper();
                string UserID = "2FFD76E6-4638-4214-8963-5DC5B6006C6A";
                var response = await _propertyService.GetAllProperties(UserID);
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


        [HttpPost("DeleteProperty")]
        public async Task<IActionResult> DeleteProperty(DeletePropertyRequest request)
        {
            try
            {
                // string UserID = GlobalUserContext.UserID.ToUpper();
                string UserID = "2FFD76E6-4638-4214-8963-5DC5B6006C6A";
                var response = await _propertyService.DeleteProperties(request, UserID);
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


        #endregion


        #region RoomsRegion

        [HttpPost("CreateRooms")]
        public async Task<IActionResult> CreateRooms(CreateRoomsRequest request)
        {
            try
            {
                // string UserID = GlobalUserContext.UserID.ToUpper();
                string UserID = "2FFD76E6-4638-4214-8963-5DC5B6006C6A";
                var response = await _propertyService.CreateRooms(request, UserID);
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

        [HttpPost("UpdateRooms")]
        public async Task<IActionResult> UpdateRooms(UpdateRoomsRequest request)
        {
            try
            {
                // string UserID = GlobalUserContext.UserID.ToUpper();
                string UserID = "2FFD76E6-4638-4214-8963-5DC5B6006C6A";
                var response = await _propertyService.UpdateRooms(request, UserID);
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

        [HttpPost("GetAllRoomsByPropertyId")]
        public async Task<IActionResult> GetAllRoomsByPropertyId(string propertyID)
        {
            try
            {
                // string UserID = GlobalUserContext.UserID.ToUpper();
                string UserID = "2FFD76E6-4638-4214-8963-5DC5B6006C6A";
                var response = await _propertyService.GetAllRoomsByPropertyId(propertyID, UserID);
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



        [HttpPost("DeleteRooms")]
        public async Task<IActionResult> DeleteRooms(DeleteRoomsRequest request)
        {
            try
            {
                // string UserID = GlobalUserContext.UserID.ToUpper();
                string UserID = "2FFD76E6-4638-4214-8963-5DC5B6006C6A";
                var response = await _propertyService.DeleteRooms(request, UserID);
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


        #endregion
    }
}
