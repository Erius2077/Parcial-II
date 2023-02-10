using System;
using System.Collections.Generic;

namespace PasteleriaDBFirst.Models;

public partial class Reservacion
{
    public int Idreservation { get; set; }

    public string Cake { get; set; } = null!;

    public int Total { get; set; }

    public string? Client { get; set; }

    public DateTime Date { get; set; }

    public string Status { get; set; } = null!;

    public int? Idclient { get; set; }

    public int? Idcake { get; set; }

    public virtual Cake? IdcakeNavigation { get; set; }

    public virtual Client? IclientNavigation { get; set; }
}
