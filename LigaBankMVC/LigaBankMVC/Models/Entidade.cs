namespace LigaBankMVC.Models
{
    public class Entidade
    {
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}