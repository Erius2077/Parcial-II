using System;
using System.Collections.Generic;

namespace PasteleriaDBFirst.Models;

public partial class Calendary
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public int Idhorario { get; set; }

    public virtual CakeTime IdcalendaryNavigation { get; set; } = null!;

}
