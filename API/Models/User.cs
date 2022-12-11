using System;
using System.Collections.Generic;

namespace API.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string UserMiddleName { get; set; } = null!;

    public string UserFirstName { get; set; } = null!;

    public string UserLastName { get; set; } = null!;

    public int UserPostId { get; set; }

    public string UserLogin { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();

    public virtual Post UserPost { get; set; } = null!;
}
