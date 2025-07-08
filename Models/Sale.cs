public class Sale
{
    public int ID { get; set; }
    public int ProductItemID { get; set; }
    public int UserDataID { get; set; }
    public DateTime BuyDate { get; set; }
    public UserData UserData { get; set; }
    public ProductItem ProductItem { get; set; }
}