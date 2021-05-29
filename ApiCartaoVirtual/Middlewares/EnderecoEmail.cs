using System.Net.Mail;
namespace Email.Middlewares
{
    public class EnderecoEmail
    {
        public string email;

        public EnderecoEmail(string email)
        {
            this.email = email;
        }

        public bool valido()
        {
            try
            {
                var enderecoEmail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}