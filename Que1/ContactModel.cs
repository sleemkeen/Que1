namespace Que1
{
    public class ContactModel
    {
        private string _firstName;
        private string _lastName;
        private string _company;
        private string _phoneNumber;
        private string _email;
        private DateTime _dob;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Company
        {
            get { return _company; }
            set { _company = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime Dob
        {
            get { return _dob; }
            set { _dob = value; }
        }

        public ContactModel() { }

        public ContactModel(string firstName, string lastName, string company, string phoneNumber, string email, DateTime dob)
        {
            _firstName = firstName;
            _lastName = lastName;
            _company = company;
            _phoneNumber = phoneNumber;
            _email = email;
            _dob = dob;
        }

        public override string ToString()
        {
            return "\n" +
                   "Name: " + _firstName + " " + _lastName + "\n" +
                   "Company: " + _company + "\n" +
                   "Phone: " + _phoneNumber + "\n" +
                   "Email: " + _email + "\n" +
                   "Birthdate: " + _dob.ToString("dd MMM yyyy");
        }
    }
}