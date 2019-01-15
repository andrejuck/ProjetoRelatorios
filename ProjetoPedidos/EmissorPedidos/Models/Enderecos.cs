namespace EmissorPedidos.Models
{
    public class Enderecos
    {
        public int Id { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public Empresas Empresa { get; set; }
        public Municipios Municipio { get; set; }
        public Estados Estado { get; set; }
        public Paises Pais { get; set; }
    }
}