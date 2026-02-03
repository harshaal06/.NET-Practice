namespace ContactsApp.Infrastructure.Query;

public static class QueryGenerator
{
    public static string GenerateInsertContactQuery()
    {
        return "INSERT INTO Contacts (Name, PhoneNumber) VALUES (@Name, @PhoneNumber)";
    }

    public static string GenerateSelectAllContactsQuery()
    {
        return "SELECT Id, Name, PhoneNumber FROM Contacts ORDER BY Id";
    }
}
