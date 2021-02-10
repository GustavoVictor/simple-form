using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Formulario.Domain.ViewModels.Form;
using Formulario.Domain.Interfaces.Identities;

namespace Formulario.Services.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController: ControllerBase
    {
        private readonly IForm _form;
        private readonly ILogger<UserController> _logger;

        public FormController(IForm form, ILogger<UserController> logger)
        {
            _form = form;
            _logger = logger;
        }

        [HttpPost()]
        public IActionResult Create(FormViewModel form)
        {
            try
            {
                return Ok(_form.Create(form));
            }
            catch (Exception e)
            {
                
                throw;
            }
        }
    }
}