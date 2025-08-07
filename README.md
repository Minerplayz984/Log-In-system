# Login System in C#

A beginner-friendly, console-based login system developed in C#. This project demonstrates foundational **OOP concepts**, **exception handling**, **input validation**, and **basic file-free user data management** using a `List<User>`.

## Features

-  Create new accounts
-  Login with credentials
-  Modify account details (Name, DOB, Hobbies)
-  Logout
-  Delete account
-  View all usernames (Admin only, secured with an access ID)
-  Robust error handling for all input and logic errors

---

## Technical Overview

- **Language:** C#
- **IDE:** Visual Studio / .NET CLI
- **Data Storage:** In-memory (no database or file storage used)
- **Admin Access:** Auto-generated ID shown at runtime
- **Exception Handling:** Custom messages for common mistakes like empty input, wrong format, etc.
- **Input Validation:** Fully handled using `try-catch`, `ArgumentException`, and conditional checks.

---

## User Class Structure

```csharp
public class User 
{
    public string username;
    public string password;
    public string name;
    public DateTime DateofBirth;
    public string Hobbies;
}
