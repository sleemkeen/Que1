namespace Que1;
using System.Text.Json;

public static class ContactStorage
{
    public static List<ContactModel> Load(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                if (!string.IsNullOrWhiteSpace(json))
                {
                    return JsonSerializer.Deserialize<List<ContactModel>>(json)
                           ?? new List<ContactModel>();
                }
            }
        }
        catch
        {
            Console.WriteLine("Error loading contacts file. Starting fresh.");
        }

        return new List<ContactModel>();
    }

    public static void Save(string filePath, List<ContactModel> contacts)
    {
        string json = JsonSerializer.Serialize(contacts,
            new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(filePath, json);
    }
}