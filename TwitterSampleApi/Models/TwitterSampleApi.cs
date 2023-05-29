namespace TwitterSampleApi.Models;

public class TwitterSampleApi
{
    public int Id { get; set; }
    public string metin { get; set; }
    public string sender { get; set; }
    public string sender_username { get; set; }
}

public class User
{
    public string username { get; set; }
    public string name { get; set; }
    public decimal follower_count { get; set; }
    public int follow_count { get; set; }
}