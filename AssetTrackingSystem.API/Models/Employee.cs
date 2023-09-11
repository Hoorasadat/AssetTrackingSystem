using System;
using System.Collections.Generic;

namespace AssetTrackingSystem.API.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string EmployeeNumber { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;
}
