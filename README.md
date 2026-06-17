# BookVerse — Library Management System

A desktop Library Management System built with **C# and .NET 10 (Windows Forms)**. It lets a librarian manage books, members, book issue/return, and reservations from a single dashboard ("BookVerse"), with all data persisted in **SQL Server**.

The solution is organised into two projects following an MVC-like separation: a reusable core library for the domain and data access, and a Windows Forms front end for the UI.

---

## Project Information

| | |
|---|---|
| **Project Title** | BookVerse — Library Management System |
| **Platform** | C# / .NET 10 — Windows Forms Desktop Application |
| **Database** | SQL Server (ADO.NET via `Microsoft.Data.SqlClient`) |

### Group Members

| Name | Roll No | Role |
|------|---------|------|
| **Haroon Khan** | F23BDOCS1M01172 | Group Leader |
| Bilawal Imran | F23BDOCS1M01065 | Member |
| Bisma Sharif | F23BDOCS1M01054 | Member |

---

## Features

- **Dashboard** – At-a-glance summary counts (total books, members, active issues, returned, reservations) shown in a status strip, with a refresh action.
- **Books** – Full CRUD and search by field (title, author, category) using SQL `LIKE` queries.
- **Members** – Add, edit, delete, and list library members.
- **Issue / Return** – Issue a book to a member, mark it as returned (with an optional return date), and track each record's status (`Issued` / `Returned`).
- **Reservations** – Create, edit, delete, and list reservations with a lifecycle status (`Pending`, `Approved`, `Cancelled`, `Completed`, `Expired`).
- **Auto-generated IDs** – Every record gets a short prefixed identifier (`B-`, `M-`, `I-`, `R-`) derived from a GUID.

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Language / Runtime | C#, .NET 10 |
| UI | Windows Forms (`net10.0-windows`) |
| Data access | ADO.NET via `Microsoft.Data.SqlClient` 7.0.1 (parameterized SQL) |
| Database | SQL Server |
| Configuration | `System.Configuration.ConfigurationManager` (`App.config`) |

---

## Project Structure

```
LibraryManagementSystem/
├── App.Core/                     # Class library: domain + data access
│   ├── Enums/                    # BookCategory, IssueStatus, ReservationStatus
│   ├── Models/                   # Book, Member, IssueRecord, Reservation
│   ├── Interfaces/               # IBookService, IMemberService, IIssueService, IReservationService
│   └── Services/                 # SQL-backed service implementations
│
└── App.WindowsApp/               # WinForms application (entry point)
    ├── Forms/                    # DashboardForm + edit dialogs (BookForm, MemberForm, …)
    ├── Views/                    # UserControl views hosted in the dashboard panel
    ├── Resources/                # Icons and images
    └── App.config                # Connection string lives here
```

**How it fits together:** `App.WindowsApp` references `App.Core`. The entry point (`Program.cs`) launches `DashboardForm`, which acts as a shell that swaps `UserControl` views (Books, Members, Issue/Return, Reservations) into a content panel. Each view talks to an `App.Core` service, and each service opens its own `SqlConnection` and runs parameterized SQL against SQL Server.

---

## Domain Model

| Entity | Key fields |
|--------|-----------|
| **Book** | Id, Title, Author, Quantity, Category, PublishedDate |
| **Member** | Id, Name, Email, Phone, Address |
| **IssueRecord** | Id, BookId, MemberId, BookName, MemberName, IssueDate, ReturnDate?, Status |
| **Reservation** | Id, BookId, MemberId, BookName, MemberName, ReservationDate, ExpiryDate?, Status |

Enums:
- `BookCategory` — Science, Programming, History, Fiction, Biography, Novel, Poetry, Technology
- `IssueStatus` — Issued, Returned
- `ReservationStatus` — Pending, Approved, Cancelled, Completed, Expired

Enum values are stored as strings and parsed back with `Enum.TryParse`.

---

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) (with the Windows desktop workload)
- **Windows** – Windows Forms targets `net10.0-windows`, so the app builds and runs on Windows only.
- **SQL Server** (Express, Developer, or LocalDB) reachable at the configured server.
- Visual Studio 2022+ is recommended, though the .NET CLI works too.

### 1. Set up the database

Create a database named `LibraryDB` and the four tables the services expect. The schema below is derived from the data-access layer — adjust column sizes to taste:

```sql
CREATE DATABASE LibraryDB;
GO
USE LibraryDB;
GO

CREATE TABLE Books (
    Id            NVARCHAR(20)  PRIMARY KEY,
    Title         NVARCHAR(200) NOT NULL,
    Author        NVARCHAR(200) NOT NULL,
    Category      NVARCHAR(50),
    PublishedDate DATE,
    Quantity      INT
);

CREATE TABLE Members (
    Id      NVARCHAR(20)  PRIMARY KEY,
    Name    NVARCHAR(200) NOT NULL,
    Email   NVARCHAR(200),
    Phone   NVARCHAR(50),
    Address NVARCHAR(300)
);

CREATE TABLE Issues (
    Id         NVARCHAR(20) PRIMARY KEY,
    BookId     NVARCHAR(20),
    MemberId   NVARCHAR(20),
    IssueDate  DATE,
    ReturnDate DATE NULL,
    Status     NVARCHAR(20),
    CONSTRAINT FK_Issues_Books   FOREIGN KEY (BookId)   REFERENCES Books(Id),
    CONSTRAINT FK_Issues_Members FOREIGN KEY (MemberId) REFERENCES Members(Id)
);

CREATE TABLE Reservations (
    Id              NVARCHAR(20) PRIMARY KEY,
    BookId          NVARCHAR(20),
    MemberId        NVARCHAR(20),
    ReservationDate DATE,
    ExpiryDate      DATE NULL,
    Status          NVARCHAR(20),
    CONSTRAINT FK_Reservations_Books   FOREIGN KEY (BookId)   REFERENCES Books(Id),
    CONSTRAINT FK_Reservations_Members FOREIGN KEY (MemberId) REFERENCES Members(Id)
);
```

> `Issues` and `Reservations` reference `Books(Id)` and `Members(Id)` via foreign keys, so the parent `Books` and `Members` tables must be created first (as ordered above), and a book or member can't be deleted while it's still referenced by an issue or reservation. The Issue/Return and Reservation views `LEFT JOIN` to `Books` and `Members` to display book and member names.

### 2. Configure the connection string

The connection string is read from `App.WindowsApp/App.config` under the name `LibraryDB`:

```xml
<connectionStrings>
  <add name="LibraryDB"
       connectionString="Server=localhost;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;"
       providerName="Microsoft.Data.SqlClient" />
</connectionStrings>
```

Update `Server=` to match your SQL Server instance (e.g. `localhost\SQLEXPRESS` or `(localdb)\MSSQLLocalDB`). The default uses Windows authentication (`Trusted_Connection=True`); switch to `User Id=...;Password=...;` if you use SQL authentication.

### 3. Build and run

**Visual Studio:** open `LibraryManagementSystem.slnx`, set `App.WindowsApp` as the startup project, and press F5.

**.NET CLI (on Windows):**

```bash
dotnet build
dotnet run --project App.WindowsApp
```

---

## Usage

1. Launch the app to land on the **Dashboard** with live summary counts.
2. Use the side navigation to switch between **Books**, **Members**, **Issue/Return**, and **Reservations**.
3. In each section, use the toolbar to add, edit, view, or delete records; Books also supports search.
4. To lend a book, issue it to a member from **Issue/Return**; later mark it returned to update its status and the dashboard totals.