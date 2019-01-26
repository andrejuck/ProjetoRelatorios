namespace EmissorPedidos.Models
{
    public class Municipio
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public Estado Estado { get; set; }
    }
}