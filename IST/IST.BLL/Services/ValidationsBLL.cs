using System.Text.RegularExpressions;
using System.Net.Mail;

namespace IST.BLL.Services
{
    public class ValidationsBLL
    {
        public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
                return false;

            var addr = new MailAddress(email);
            if (addr.Address != trimmedEmail)
                return false;

            return true;
        }

        public bool IsValidName(string name)
        {
            Regex regex = new Regex(
              @"^[a-zA-Z]+$",
            RegexOptions.IgnoreCase
            | RegexOptions.CultureInvariant
            | RegexOptions.IgnorePatternWhitespace
            | RegexOptions.Compiled
            );

           if(regex.IsMatch(name))
                return true;
           else
                return false;
        }
        public bool IsAValidId(int id)
        {
            if(id <= 0)
                return false;

            return true;
        }
    }
}
