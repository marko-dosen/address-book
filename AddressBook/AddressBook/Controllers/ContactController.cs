using System;
using AddressBook.App.Exceptions;
using AddressBook.App.Factories;
using AddressBook.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IUseCaseFactory _useCaseFactory;

        public ContactController(IUseCaseFactory useCaseFactory)
        {
            _useCaseFactory = useCaseFactory;
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            try
            {
                Domain.Models.Contact result = _useCaseFactory.CreateContactUseCase().Execute(contact);
                var resourcePath = new Uri($"{Request.GetDisplayUrl()}/{result.Id}");
                return Created(resourcePath, result);
            }
            catch (ContactAlreadyExistsException e)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, e);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}