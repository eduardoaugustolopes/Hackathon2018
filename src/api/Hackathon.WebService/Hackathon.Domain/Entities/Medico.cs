namespace Hackathon.Domain.Entities
{
    public class Medico
    {
        public int Id { get; set; }

        private string _crm = string.Empty;
        public string Crm
        {
            get { return _crm ?? string.Empty; }
            set { _crm = value; }
        }

        private string _nome = string.Empty;
        public string Nome
        {
            get { return _nome ?? string.Empty; }
            set { _nome = value; }
        }

        private string _telefone = string.Empty;
        public string Telefone
        {
            get { return _telefone ?? string.Empty; }
            set { _telefone = value; }
        }
    }
}
