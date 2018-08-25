namespace Hackathon.Domain.Entities
{
    public class Clinica
    {
        public int Id { get; set; }

        private string _nome = string.Empty;
        public string Nome
        {
            get { return _nome ?? string.Empty; }
            set { _nome = value; }
        }

        private string _logradouro = string.Empty;
        public string Logradouro
        {
            get { return _logradouro ?? string.Empty; }
            set { _logradouro = value; }
        }

        private string _numero = string.Empty;
        public string Numero
        {
            get { return _numero ?? string.Empty; }
            set { _numero = value; }
        }

        private string _bairro = string.Empty;
        public string Bairro
        {
            get { return _bairro ?? string.Empty; }
            set { _bairro = value; }
        }

        private string _complemento = string.Empty;
        public string Complemento
        {
            get { return _complemento ?? string.Empty; }
            set { _complemento = value; }
        }

        private string _cep = string.Empty;
        public string Cep
        {
            get { return _cep ?? string.Empty; }
            set { _cep = value; }
        }

        private string _cidade = string.Empty;
        public string Cidade
        {
            get { return _cidade ?? string.Empty; }
            set { _cidade = value; }
        }

        private string _uf = string.Empty;
        public string Uf
        {
            get { return _uf ?? string.Empty; }
            set { _uf = value; }
        }

        private string _localizacao = string.Empty;
        public string Localizacao
        {
            get { return _localizacao ?? string.Empty; }
            set { _localizacao = value; }
        }

        private string _telefone = string.Empty;
        public string Telefone
        {
            get { return _telefone ?? string.Empty; }
            set { _telefone = value; }
        }

        private string _email = string.Empty;
        public string Email
        {
            get { return _email ?? string.Empty; }
            set { _email = value; }
        }

        private string _senha = string.Empty;
        public string Senha
        {
            get { return _senha ?? string.Empty; }
            set { _senha = value; }
        }
    }
}
