using System;
using System.Collections.Generic;

namespace MedicalStoreManagement.Models;

public partial class MedcinineStock
{
    public int MedId { get; set; }

    public string MedName { get; set; } = null!;

    public string MedCategory { get; set; } = null!;

    public string CompanyName { get; set; } = null!;

    public double Amount { get; set; }

    public string Description { get; set; } = null!;

    public DateOnly MafDate { get; set; }

    public DateOnly ExpData { get; set; }

    public virtual ICollection<Purchasing> Purchasings { get; set; } = new List<Purchasing>();
}
