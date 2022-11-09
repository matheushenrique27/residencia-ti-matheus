namespace LigaBankMVC.Models
{
    public class Historico : Entidade
    {
        public List<Operacao>? Operacoes { get; set; }
        public Conta? Conta { get; set; }
    }
}