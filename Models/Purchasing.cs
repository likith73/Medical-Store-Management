using System;
using System.Collections.Generic;

namespace MedicalStoreManagement.Models;

public partial class Purchasing
{
    public int PurchasingId { get; set; }

    public int MedId { get; set; }

    public int Quantity { get; set; }

    public double Amount { get; set; }

    public DateOnly PurchasingDate { get; set; }

    public virtual MedcinineStock Med { get; set; } = null!;
}
