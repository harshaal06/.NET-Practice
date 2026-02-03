using ContactsApp.Domain.Entities;
using ContactsApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactsApp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    //API to post the contact in db
    [HttpPost]
    public async Task<IActionResult> AddContact([FromBody] Contact contact)
    {
        if (string.IsNullOrWhiteSpace(contact.Name) || string.IsNullOrWhiteSpace(contact.PhoneNumber))
        {
            return BadRequest("Name and PhoneNumber are required.");
        }

        await _contactService.AddContactAsync(contact);
        return Ok(new { message = "Contact added successfully" });
    }

    // API to get the all contacts from db
    [HttpGet]
    public async Task<IActionResult> GetAllContacts()
    {
        var contacts = await _contactService.GetAllContactsAsync();
        return Ok(contacts);
    }
}
