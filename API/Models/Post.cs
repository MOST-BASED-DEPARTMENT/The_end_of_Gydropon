namespace API.Models;

public partial class Post
{
    public int IdPost { get; set; }

    public string PostName { get; set; } = null!;

    public int SuperiorPostId { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
