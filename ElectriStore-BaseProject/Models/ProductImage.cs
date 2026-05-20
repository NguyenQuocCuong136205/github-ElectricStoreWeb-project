using System;
using System.Collections.Generic;

namespace ElectriStore_BaseProject.Models;

public partial class ProductImage
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public string? Img { get; set; }

    public int? DisplayOrder { get; set; }

    public virtual Product? Product { get; set; }
}
