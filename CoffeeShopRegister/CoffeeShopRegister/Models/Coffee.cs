﻿using System;
using System.Collections.Generic;

namespace CoffeeShopRegister.Models;

public partial class Coffee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;
}
