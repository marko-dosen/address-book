using System;
using System.Threading.Tasks;
using AddressBook.App.Services;
using AddressBook.App.UseCases;
using AddressBook.Contracts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repository;

        public ContactController(IContactRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            try
            {
                CreateContactUseCase useCase = new CreateContactUseCase(_repository);
                return Ok(useCase.Execute(contact));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}