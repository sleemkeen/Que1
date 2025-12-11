# Contact Book (C# Console Application)

A simple, user-friendly console-based **Contact Management System** built in C# for Que 1 CA1. This application allows you to store, view, search, update, and delete contacts, with automatic data persistence using a JSON file.

---

## **Features**

### ✔️ Add Contact

* Captures user details such as name, company, phone, email, and date of birth.
* Validates 9-digit phone numbers.
* Automatically saves to `contacts.json`.

### ✔️ Show All Contacts

* Displays all contacts in a clear, formatted list.

### ✔️ Show Contact Details

* Search for a contact using their mobile number.
* Displays full details if found.

### ✔️ Update Contact

* Update any field of an existing contact.
* Press Enter to keep the current value.
* Saves updates to `contacts.json`.

### ✔️ Delete Contact

* Remove a contact using their mobile number.
* Saves changes instantly.

### ✔️ Persistent Storage

* Contacts are stored in **JSON format**.
* Data is automatically loaded when the app starts.

---

## **Project Structure**

```
/Que1
 ├── ContactModel.cs
 ├── ContactBook.cs
 ├── ContactStorage.cs
 ├── Inputs.cs
 ├── Validation.cs
 ├── Program.cs
 └── contacts.json (generated at runtime)
```

---

## **How It Works**

### **ContactModel**

Represents an individual contact with fields for:

* First Name
* Last Name
* Company
* Phone Number
* Email Address
* Birthdate

### **ContactBook**

Contains all the core operations:

* Add
* Display all
* Search
* Update
* Delete
* Manage JSON saving/loading

### **ContactStorage**

Handles file read/write operations using `System.Text.Json`.

### **Program.cs**

Runs the main menu loop and handles user interaction.

---

## **How to Run**

### From an IDE (Visual Studio / VS Code)

1. Open the project folder.
2. Build the solution.
3. Run the program.

### From Terminal

```
dotnet build
dotnet run
```

---

## **Menu Preview**

```
----------- Contact Book -----------
1: Add Contact
2: Show All Contacts
3: Show Contact Details
4: Update Contact
5: Delete Contact
0: Exit
------------------------------------
Enter your choice:
```

---

## **Sample contacts.json**

```json
[
  {
    "FirstName": "John",
    "LastName": "Doe",
    "Company": "ABC Corp",
    "PhoneNumber": "123456789",
    "Email": "john.doe@example.com",
    "Dob": "1990-05-20T00:00:00"
  }
]
```

