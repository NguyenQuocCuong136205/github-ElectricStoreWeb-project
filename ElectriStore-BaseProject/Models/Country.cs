using System;
using System.Collections.Generic;

namespace ElectriStore_BaseProject.Models;

public partial class Country
{
    public int Id { get; set; }

    public string? Country1 { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
