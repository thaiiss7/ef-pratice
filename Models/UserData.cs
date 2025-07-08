public class UserData
{
    public int ID { get; set; }
    public string UserName { get; set; }
    public string Pass { get; set; }
    public bool IsAdm { get; set; }
    public ICollection<Sale> Sales { get; set; }
}