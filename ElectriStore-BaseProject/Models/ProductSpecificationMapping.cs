using System;
using System.Collections.Generic;

namespace ElectriStore_BaseProject.Models;

public partial class ProductSpecificationMapping
{
    public int ProductId { get; set; }

    public int AttributeId { get; set; }

    public string? Value { get; set; }
}
