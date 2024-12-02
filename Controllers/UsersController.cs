using AuthGuardPro_Application.DTO_s.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayEasePro_Application.CommonRepos.Contracts;
using StayEasePro_Application.Repos.Contracts;
using StayEasePro_Domain.DTO_s.DTO;
using StayEasePro_Domain.DTO_s.Requests;

[Route("api/User")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILoggerService _loggerService;

    public UsersController(IUserService userService,ILoggerService loggerService)
    {
        _userService = userService;
        _loggerService = loggerService;
    }

    /// <summary>
    /// Creates a new user. Requires authorization.
    /// </summary>
    /// <param name="request">The user creation request containing username, email, and password.</param>
    /// <returns>A response containing the created user's details.</returns>
    [AllowAnonymous]
    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        try
        {
            var response = await _userService.CreateUser(request);
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



    /// <summary>
    /// Logs in a user. No authorization required.
    /// </summary>
    /// <param name="request">The login request containing username and password.</param>
    /// <returns>A response containing the user's login status.</returns>
    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> LoginUser(LoginUserRequest request)
    {
        try
        {
           
            var response = await _userService.LoginUser(request);
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

    [Authorize]
    [HttpPost("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
    {
        try
        {
            string userID = GlobalUserContext.UserID.ToUpper();
            var response = await _userService.ForgotPassword(request);
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


    [Authorize]
    [HttpPost("DeleteAccount")]
    public async Task<IActionResult> DeleteAccount(DeleteRequest request)
    {
        try
        {
            var response = await _userService.DeleteUser(request);
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


   // [Authorize]
    [HttpPost("JoinUser")]
    public async Task<IActionResult> JoinUser(JoinDetailsRequest request)
    {
        try
        {
            // string UserID = GlobalUserContext.UserID.ToUpper();
            string UserID = "2FFD76E6-4638-4214-8963-5DC5B6006C6A";
            request.UserId = UserID.ToUpper();
            var response = await _userService.JoinUser(request);
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
