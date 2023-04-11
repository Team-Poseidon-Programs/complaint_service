using System;
using System.Collections.Generic;

namespace customer_complaint_service.Entities;

public partial class CustomerComplaint
{
    public int Id { get; set; }

    public string? PatientEmail { get; set; }

    public string? Complaint { get; set; }

    public string? Date { get; set; }
}
