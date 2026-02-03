# Contacts Application

A simple full-stack Contacts application built with React frontend and .NET Core Web API backend using MySQL database.

## Architecture

The application follows Clean Architecture principles with three main layers:

- **Domain**: Entities and interfaces
- **Infrastructure**: Services, data access, and utilities
- **API**: Controllers and API configuration

## Prerequisites

- .NET 8.0 SDK
- Node.js (v14 or higher)
- MySQL Server
- npm or yarn

## Database Setup

1. Start MySQL server
2. Run the database script:

```sql
CREATE DATABASE IF NOT EXISTS ContactsDB;
USE ContactsDB;

CREATE TABLE IF NOT EXISTS Contacts (
  Id INT AUTO_INCREMENT PRIMARY KEY,
  Name VARCHAR(100) NOT NULL,
  PhoneNumber VARCHAR(15) NOT NULL
);
```

Or execute the provided `database.sql` file:

```bash
mysql -u root -p < database.sql
```

## Backend Setup

1. Navigate to the project root directory
2. Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ContactsDB;User=root;Password=yourpassword;"
  }
}
```

3. Restore dependencies and run:

```bash
dotnet restore
dotnet run
```

The API will run on `http://localhost:5000` (check the console output for the exact URL).

## Frontend Setup

1. Navigate to the frontend directory:

```bash
cd frontend
```

2. Install dependencies:

```bash
npm install
```

3. Start the development server:

```bash
npm start
```

The React app will run on `http://localhost:3000`

## API Endpoints

### POST /api/contacts
Add a new contact.

**Request Body:**
```json
{
  "name": "John Doe",
  "phoneNumber": "9876543210"
}
```

### GET /api/contacts
Get all contacts.

**Response:**
```json
[
  {
    "id": 1,
    "name": "John Doe",
    "phoneNumber": "9876543210"
  }
]
```

## Project Structure

```
ContactsApp/
├── Domain/
│   ├── Entities/
│   │   └── Contact.cs
│   └── Interfaces/
│       └── IContactService.cs
├── Infrastructure/
│   ├── Services/
│   │   └── ContactService.cs
│   ├── Query/
│   │   └── QueryGenerator.cs
│   └── Utils/
│       └── SqlHelper.cs
├── API/
│   └── Controllers/
│       └── ContactController.cs
├── Program.cs
├── appsettings.json
├── frontend/
│   ├── src/
│   │   ├── components/
│   │   │   ├── ContactForm.js
│   │   │   ├── ContactForm.css
│   │   │   ├── ContactList.js
│   │   │   └── ContactList.css
│   │   ├── services/
│   │   │   └── api.js
│   │   ├── App.js
│   │   ├── App.css
│   │   ├── index.js
│   │   └── index.css
│   ├── public/
│   │   └── index.html
│   └── package.json
├── database.sql
└── ContactsApp.csproj
```

## Features

- Add new contacts with name and phone number
- View all contacts in a table
- Clean Architecture separation of concerns
- Parameterized SQL queries for security
- CORS enabled for React frontend
- Error handling and validation

## Notes

- Make sure MySQL server is running before starting the backend
- Update the connection string in `appsettings.json` with your MySQL credentials
- The frontend expects the API to run on `http://localhost:5000` (update `frontend/src/services/api.js` if using a different port)
