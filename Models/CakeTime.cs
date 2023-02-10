using System;
using System.Collections.Generic;

namespace PasteleriaDBFirst.Models;

public partial class CakeTime
{
    public int Id { get; set; }

    public string Calendary { get; set; } = null!;

    public virtual ICollection<Calendary> Calendary { get; } = new List<Calendary>();
}
