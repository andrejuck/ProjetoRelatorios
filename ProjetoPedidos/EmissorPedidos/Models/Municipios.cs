namespace EmissorPedidos.Models
{
    public class Municipios
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public Estados Estado { get; set; }
    }
}