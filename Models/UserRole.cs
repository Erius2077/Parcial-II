using System;
using System.Collections.Generic;

namespace PasteleriaDBFirst.Models;

public partial class UserRole
{
    public int IdUserRole { get; set; }

    public string UserRole1 { get; set; } = null!;

    public virtual ICollection<Client> Client { get; } = new List<Client>();
}