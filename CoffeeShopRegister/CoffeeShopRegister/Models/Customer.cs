using System;
using System.Collections.Generic;

namespace CoffeeShopRegister.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string OrderName { get; set; } = null!;
}
