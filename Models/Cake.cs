using System;
using System.Collections.Generic;

namespace PasteleriaDBFirst.Models;

public partial class Cake
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Image { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}

