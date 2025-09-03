using System;
using System.Collections.Generic;

namespace MedicalStoreManagement.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phoneno { get; set; } = null!;

    public string Address { get; set; } = null!;
}
