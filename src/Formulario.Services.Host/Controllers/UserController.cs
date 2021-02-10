using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Formulario.Domain.ViewModels.User;
using Formulario.Domain.Interfaces.Identities;

namespace Formulario.Services.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly ILogger<UserController> _logger;

        public UserController(IUser user, ILogger<UserController> logger)
        {
            _user = user;
            _logger = logger;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthViewModel auth)
        {
            try
            {
                return _user.Auth(auth);
            }
            catch (Exception e)
            {
                
                throw;
            }
        }

        [HttpPost()]
        public IActionResult Create(CreateViewModel user)
        {
            try
            {
                return Ok(_user.Create(user));
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
    }
}
