namespace Que1;

public class Validation
{
    public static Boolean IsValidPhoneNumber(string phoneNumber)
    {
        if (phoneNumber.Length != 9) return false;
        if (!long.TryParse(phoneNumber, out long num)) return false;
        if (num <= 0) return false;
        return true;
    }
}