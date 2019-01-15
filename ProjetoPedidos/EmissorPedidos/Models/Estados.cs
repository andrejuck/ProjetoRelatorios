using System.ComponentModel.DataAnnotations;

namespace EmissorPedidos.Models
{
    public class Estados
    {
        public int Id { get; set; }
        public int CodigoUf { get; set; }
        public string Nome { get; set; }
        [MaxLength(2)]
        public string Uf { get; set; }
        public Paises Pais { get; set; }
    }
}