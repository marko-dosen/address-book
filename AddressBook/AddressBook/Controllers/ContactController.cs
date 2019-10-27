using System;
using System.Threading.Tasks;
using AddressBook.App.Exceptions;
using AddressBook.App.Factories;
using AddressBook.App.Models;
using AddressBook.Contracts.Models;
using AddressBook.Hubs;
using AddressBook.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ContactHub = AddressBook.Hubs.ContactHub;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IUseCaseFactory _useCaseFactory;
        private readonly IHub<ContactHub> _hub;

        public ContactController(IUseCaseFactory useCaseFactory, IHub<ContactHub> hub)
        {
            _useCaseFactory = useCaseFactory;
            _hub = hub;
        }

        [HttpGet]
        public IActionResult Get(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                var pagination = new PagingParameter { PageSize = pageSize, PageNumber = pageNumber };
                var result = _useCaseFactory.GetContactsUseCase().Execute(pagination);
                Response.Headers.Add("Pagination", JsonConvert.SerializeObject(result.Pagination));
                return Ok(result.Contacts);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_useCaseFactory.GetContactUseCase().Execute(id));
            }
            catch (ContactNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Contact contact)
        {
            try
            {
                ContactWithId result = _useCaseFactory.CreateContactUseCase().Execute(contact);
                var resourcePath = new Uri($"{Request.GetDisplayUrl()}/{result.Id}");
                await _hub.SendUpdateAsync(MessageType.ContactCreate, result);
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

        [HttpPut]
        public IActionResult Put(ContactWithId contact)
        {
            try
            {
                return Ok(_useCaseFactory.UpdateContactUseCase().Execute(contact));
            }
            catch (ContactAlreadyExistsException e)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, e);
            }
            catch (ContactNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _useCaseFactory.DeleteContactUseCase().Execute(id);
                return Ok();
            }
            catch (ContactNotFoundException)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }
    }
}