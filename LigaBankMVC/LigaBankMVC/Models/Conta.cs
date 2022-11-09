using Microsoft.AspNetCore.Identity;

namespace LigaBankMVC.Models
{
    public class Conta : Entidade
    {
        public Guid UsuarioId { get; set; }

        public int NumeroDaAgencia { get; set; }

        public Decimal SaldoDaConta { get; set; }

        //public string NomeDoCliente { get; set; }

        //public string? FotoDoCliente { get; set; } 
    }
}