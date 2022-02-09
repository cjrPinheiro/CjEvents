using CJE.Aplication.Dtos;
using CJE.Aplication.Interfaces;
using CJE.Common.Extensions;
using CJE.Common.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CJE.API.Business.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        // GET: api/<AccountsController>

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                string userName = User.GetUserName();

                var user = await _accountService.GetUserByUserNameAsync(userName);

                return Ok(user);
            }
            catch (Exception e)
            {
                var error = CommonFunctions.GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }

        // POST api/<AccountsController>
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
        {
            try
            {
                if (!await _accountService.UserExists(userDto.Username))
                {
                    var newUser = await _accountService.CreateAccountAsync(userDto);
                    if (newUser != null)
                        return Created("Succesfully registered", newUser);
                    return BadRequest("The User couldn't be created at this time. Please try again soon.");
                }
                else
                    return BadRequest("UserName already exists");
            }
            catch (Exception e)
            {
                var error = CommonFunctions.GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            try
            {
                var user = await _accountService.GetUserByUserNameAsync(userDto.Username);
                if (user != null)
                {
                    var loginResult = await _accountService.CheckUserPasswordAsync(userDto);

                    if (loginResult.Succeeded)
                    {
                        var token = await _tokenService.CreateTokenAsync(user);
                        return Ok(new
                        {
                            userName = user.Username,
                            firstName = user.FirstName,
                            token = token
                        });
                    }
                }
                return Unauthorized("Invalid Username or Password.");
            }
            catch (Exception e)
            {
                var error = CommonFunctions.GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }

        // PUT api/<AccountsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserExistingDto userExistingDto)
        {
            try
            {
                var user = await _accountService.GetUserByUserNameAsync(User.GetUserName());

                if (user != null)
                {
                    var updatedUser = await _accountService.UpdateAccount(User.GetUserId(), userExistingDto);
                    if (updatedUser != null)
                        return Ok(updatedUser);
                    return BadRequest("The User couldn't be updated at this time. Please try again soon.");
                }
                else
                    return Unauthorized("Invalid user.");
            }
            catch (Exception e)
            {
                var error = CommonFunctions.GenerateError("Ocorreu um erro interno na aplicação.", e);
                //implementar log
                return this.StatusCode(StatusCodes.Status500InternalServerError, error);
            }
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
