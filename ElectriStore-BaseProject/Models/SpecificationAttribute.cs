using System;
using System.Collections.Generic;

namespace ElectriStore_BaseProject.Models;

public partial class SpecificationAttribute
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string? Name { get; set; }
}
