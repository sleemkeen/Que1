using System;
using Que1;

public class Program
{
    public static void Main(string[] args)
    {
        ContactBook book = new ContactBook();
        int choice;

        do
        {
            Console.WriteLine("----------- Contact Book -----------");
            Console.WriteLine("1: Add Contact");
            Console.WriteLine("2: Show All Contacts");
            Console.WriteLine("3: Show Contact Details");
            Console.WriteLine("4: Update Contact");
            Console.WriteLine("5: Delete Contact");
            Console.WriteLine("0: Exit");
            Console.WriteLine("------------------------------------");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice! Try again.\n");
                continue;
            }

            switch (choice)
            {
                case 1: book.AddContact(); break;
                case 2: book.ShowAllContacts(); break;
                case 3: book.ShowContactDetails(); break;
                case 4: book.UpdateContact(); break;
                case 5: book.DeleteContact(); break;
                case 0: Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("Invalid option! Try again.\n"); break;
            }

        } while (choice != 0);
    }
}