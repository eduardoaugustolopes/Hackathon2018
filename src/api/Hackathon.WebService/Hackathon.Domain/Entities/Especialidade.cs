namespace Hackathon.Domain.Entities
{
    class Especialidade
    {
        public int Id { get; set; }

        private string _descricao = string.Empty;
        public string Descricao
        {
            get { return _descricao ?? string.Empty; }
            set { _descricao = value; }
        }

    }
}
