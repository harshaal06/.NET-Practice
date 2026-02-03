using ContactsApp.Domain.Entities;
using ContactsApp.Domain.Interfaces;
using ContactsApp.Infrastructure.Query;
using ContactsApp.Infrastructure.Utils;
using MySql.Data.MySqlClient;

namespace ContactsApp.Infrastructure.Services;

public class ContactService : IContactService
{
    private readonly SqlHelper _sqlHelper;

    public ContactService(SqlHelper sqlHelper)
    {
        _sqlHelper = sqlHelper;
    }

    public async Task AddContactAsync(Contact contact)
    {
        var query = QueryGenerator.GenerateInsertContactQuery();
        var parameters = new Dictionary<string, object>
        {
            { "@Name", contact.Name },
            { "@PhoneNumber", contact.PhoneNumber }
        };

        await _sqlHelper.ExecuteNonQueryAsync(query, parameters);
    }

    public async Task<List<Contact>> GetAllContactsAsync()
    {
        var query = QueryGenerator.GenerateSelectAllContactsQuery();
        
        return await _sqlHelper.ExecuteReaderAsync(query, reader => new Contact
        {
            Id = reader.GetInt32("Id"),
            Name = reader.GetString("Name"),
            PhoneNumber = reader.GetString("PhoneNumber")
        });
    }
}
