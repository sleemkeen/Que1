namespace Que1;

public class ContactBook
{
    private List<ContactModel> contacts = new List<ContactModel>();
    private readonly string _filePath = "contacts.json";

    public ContactBook()
    {
        string folderPath = AppContext.BaseDirectory;
        
        string filePath = Path.Combine(folderPath, _filePath);
        contacts = ContactStorage.Load(filePath); // Load saved contacts on startup
    }

    public void AddContact()
    {
        try
        {
            ContactModel contactModel = new ContactModel();

            contactModel.FirstName = Inputs.ReadString("First Name");
            contactModel.LastName = Inputs.ReadString("Last Name");
            contactModel.Company = Inputs.ReadString("Company");

            // Validate phone number
            string phoneNumber;
            while (true)
            {
                phoneNumber = Inputs.ReadString("Mobile Number (9-digit): ");
                if (Validation.IsValidPhoneNumber(phoneNumber)) break;

                Console.WriteLine("Invalid phone number! Must be a 9-digit positive number.");
            }

            contactModel.PhoneNumber = phoneNumber;
            contactModel.Email = Inputs.ReadString("Enter your email address: ");
            contactModel.Dob = Inputs.ReadDate("Enter your date of birth");

            contacts.Add(contactModel);
            ContactStorage.Save(_filePath, contacts);

            Console.WriteLine("Contact added successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while adding contact: {ex.Message}\n");
        }
    }


    public void ShowAllContacts()
    {
        try
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts to display.\n");
                return;
            }

            Console.WriteLine("\nAll Contacts:");
            foreach (var c in contacts)
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error displaying contacts: {ex.Message}\n");
        }
    }

    
    public void ShowContactDetails()
    {
        try
        {
            string phoneNo = Inputs.ReadString("Enter Mobile Number to search: ");

            ContactModel contactModel = contacts.Find(c => c.PhoneNumber == phoneNo);

            if (contactModel == null)
            {
                Console.WriteLine("Contact not found.\n");
                return;
            }

            Console.WriteLine("\n--- Contact Details ---");
            Console.WriteLine($"First Name: {contactModel.FirstName}");
            Console.WriteLine($"Last Name: {contactModel.LastName}");
            Console.WriteLine($"Company: {contactModel.Company}");
            Console.WriteLine($"Mobile: {contactModel.PhoneNumber}");
            Console.WriteLine($"Email: {contactModel.Email}");
            Console.WriteLine($"Birthdate: {contactModel.Dob}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving contact: {ex.Message}\n");
        }
    }

    
    public void UpdateContact()
    {
        try
        {
            Console.Write("Enter Mobile Number of contact to update: ");
            string phoneNumber = Console.ReadLine() ?? string.Empty;

            ContactModel contactModel = contacts.Find(c => c.PhoneNumber == phoneNumber);

            if (contactModel == null)
            {
                Console.WriteLine("Contact not found.\n");
                return;
            }

            Console.WriteLine("Leave blank to keep old value.");

            Console.Write($"First Name ({contactModel.FirstName}): ");
            string? fn = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(fn)) contactModel.FirstName = fn;

            Console.Write($"Last Name ({contactModel.LastName}): ");
            string? ln = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(ln)) contactModel.LastName = ln;

            Console.Write($"Company ({contactModel.Company}): ");
            string? comp = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(comp)) contactModel.Company = comp;

            while (true)
            {
                Console.Write($"Mobile ({contactModel.PhoneNumber}): ");
                string? newMobile = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newMobile)) break;

                if (Validation.IsValidPhoneNumber(newMobile))
                {
                    contactModel.PhoneNumber = newMobile;
                    break;
                }

                Console.WriteLine("Invalid mobile number!");
            }

            Console.Write($"Email ({contactModel.Email}): ");
            string? email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email)) contactModel.Email = email;

            try
            {
                DateTime bday = Inputs.ReadDate($"Birthdate ({contactModel.Dob}): ");
                contactModel.Dob = bday;
            }
            catch
            {
                Console.WriteLine("Invalid date entered. Keeping old birthdate.");
            }

            ContactStorage.Save(_filePath, contacts);

            Console.WriteLine("Contact updated successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while updating contact: {ex.Message}\n");
        }
    }

   
    public void DeleteContact()
    {
        try
        {
            Console.Write("Enter Mobile Number of contact to delete: ");
            string mobile = Console.ReadLine() ?? string.Empty;

            ContactModel contactModel = contacts.Find(c => c.PhoneNumber == mobile);

            if (contactModel == null)
            {
                Console.WriteLine("Contact not found.\n");
                return;
            }

            contacts.Remove(contactModel);
            ContactStorage.Save(_filePath, contacts);

            Console.WriteLine("Contact deleted successfully!\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while deleting contact: {ex.Message}\n");
        }
    }
}
