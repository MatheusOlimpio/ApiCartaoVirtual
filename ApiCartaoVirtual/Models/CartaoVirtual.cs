namespace Api.Models
{
    public class CartaoVirtual
    {
        public System.Guid Id { get; set; }
        public string Email { get; set; }

        public string NumeroCartao { get; set; }

        public System.DateTime DataCriacao { get; set; }
    }
}
