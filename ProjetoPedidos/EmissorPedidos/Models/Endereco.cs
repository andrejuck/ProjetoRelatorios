namespace EmissorPedidos.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public Empresa Empresa { get; set; }
        public Municipio Municipio { get; set; }
        public Estado Estado { get; set; }
        public Pais Pais { get; set; }
    }
}