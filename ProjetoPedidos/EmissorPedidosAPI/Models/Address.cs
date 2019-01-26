namespace EmissorPedidosAPI.Models
{
    /// <summary>
    /// 26/01/2019
    /// Following the Canada Post Pattern at https://www.canadapost.ca/tools/pg/manual/PGaddress-e.asp
    /// </summary>
    public class Address : BaseModel
    {
        public string StreetType { get; set; }
        public string StreetName { get; set; }
        public int CivicNumber { get; set; }
        public string CivicNumberSuffix { get; set; }
        public string MunicipalityName { get; set; }
        public string Province { get; set; }
        public string PostalBox { get; set; }
        public Company Company { get; set; }
    }
}