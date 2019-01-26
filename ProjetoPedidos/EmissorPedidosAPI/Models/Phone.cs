namespace EmissorPedidosAPI.Models
{
    public class Phone : BaseModel
    {
        public string PhoneNumber { get; set; }
        public User User { get; set; }
        public Company Company { get; set; }
    }
}