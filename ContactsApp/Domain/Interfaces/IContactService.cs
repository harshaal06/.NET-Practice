using ContactsApp.Domain.Entities;

namespace ContactsApp.Domain.Interfaces;

public interface IContactService
{
    Task AddContactAsync(Contact contact);
    Task<List<Contact>> GetAllContactsAsync();
}
