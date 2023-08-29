using System.Security.Claims;
using Artemis.Contracts.DTOs;
using Artemis.Contracts.Entities;
using Artemis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Artemis.API.Controllers
{
    [ApiController, Route("artemis/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserService _userService;

        [HttpPost, Route("login"),
        ProducesResponseType(StatusCodes.Status404NotFound),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status200OK),
        ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
        {
            ModelState.ClearValidationState(nameof(loginRequest));

            if (TryValidateModel(loginRequest, nameof(loginRequest)))
            {
                User? user = await _userService.GetByEmailAsync(loginRequest.Email);

                if (user is null)
                    return NotFound(loginRequest.Email);

                if (!user.PasswordHash.Equals(loginRequest.PasswordHash))
                    return Unauthorized();

                return Ok(await _userService.Login(user));
            }

            return ValidationProblem(ModelState);
        }

        [HttpPost, Route("register"),
        ProducesResponseType(StatusCodes.Status409Conflict),
        ProducesResponseType(StatusCodes.Status201Created),
        ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequest)
        {
            ModelState.ClearValidationState(nameof(registrationRequest));

            if (TryValidateModel(registrationRequest, nameof(registrationRequest)))
            {
                if (await _userService.GetByEmailAsync(registrationRequest.Email) is not null)
                    return Conflict(registrationRequest.Email);

                User user = new(registrationRequest);

                await _userService.CreateUserAsync(user);

                return CreatedAtAction(
                    nameof(GetById),
                    new {id = user.Id},
                    user.CreateDto());
            }

            return ValidationProblem(ModelState);
        }

        [Authorize, HttpPost, Route("update"),
        ProducesResponseType(StatusCodes.Status404NotFound),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status409Conflict),
        ProducesResponseType(StatusCodes.Status200OK),
        ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequestDto updateRequest)
        {
            ModelState.ClearValidationState(nameof(updateRequest));

            if (TryValidateModel(updateRequest, nameof(updateRequest)))
            {
                User? user = await _userService.GetByIdAsync(updateRequest.Id);

                if (user is null)
                    return NotFound(updateRequest.Id);

                if (!user.Id.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                    return Unauthorized();

                if (!user.Email.Equals(updateRequest.Email)
                    && await _userService.GetByEmailAsync(updateRequest.Email) is not null)
                    return Conflict(updateRequest.Email);

                user.UpdateValues(updateRequest);

                await _userService.UpdateUserAsync(user);

                return Ok(user.CreateDto());
            }

            return ValidationProblem(ModelState);
        }

        [Authorize, HttpDelete, Route("delete"),
        ProducesResponseType(StatusCodes.Status404NotFound),
        ProducesResponseType(StatusCodes.Status409Conflict),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status200OK),
        ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromBody] UserDeleteRequestDto deleteRequest)
        {
            ModelState.ClearValidationState(nameof(deleteRequest));

            if (TryValidateModel(deleteRequest, nameof(deleteRequest)))
            {
                User? user = await _userService.GetByIdAsync(deleteRequest.Id);

                if (user is null) return NotFound(deleteRequest.Id);

                if (!user.Email.Equals(deleteRequest.Email))
                    return Conflict(deleteRequest.Email);

                if (!user.PasswordHash.Equals(deleteRequest.PasswordHash)
                    || !user.Id.Equals(User.FindFirstValue(ClaimTypes.NameIdentifier)))
                    return Unauthorized();

                await _userService.DeleteUserAsync(user);

                return Ok();
            }

            return ValidationProblem(ModelState);
        }

        [Authorize, HttpGet, Route("get-user/by-id"),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status404NotFound),
        ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById()
        {
            string? id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id is null)
                return Unauthorized();

            User? user = await _userService.GetByIdAsync(id);

            return user is null ? NotFound(id) : Ok(user.CreateDto());
        }

        [Authorize, HttpGet, Route("get-user/by-email"),
        ProducesResponseType(StatusCodes.Status401Unauthorized),
        ProducesResponseType(StatusCodes.Status404NotFound),
        ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByEmail()
        {
            string? email = User.FindFirstValue(ClaimTypes.Email);

            if (email is null)
                return Unauthorized();

            User? user = await _userService.GetByEmailAsync(email);

            return user is null ? NotFound(email) : Ok(user.CreateDto());
        }

        public AuthenticationController(UserService userService)
        {
            this._userService = userService;
        }
    }
}
