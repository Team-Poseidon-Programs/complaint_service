using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace customer_complaint_service.Entities;

public partial class AuditServiceContext : DbContext
{
    public AuditServiceContext()
    {
    }

    public AuditServiceContext(DbContextOptions<AuditServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustomerComplaint> CustomerComplaints { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=tcp:poseidonserver.database.windows.net,1433;initial catalog=Audit_Service;persist security info=false;user id=poseidon;password=Program@123;multipleactiveresultsets=false;encrypt=true;trustservercertificate=false;connection timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerComplaint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__customer__3213E83FAF6CD848");

            entity.ToTable("customer_complaint");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Complaint)
                .IsUnicode(false)
                .HasColumnName("complaint");
            entity.Property(e => e.Date)
                .IsUnicode(false)
                .HasColumnName("date");
            entity.Property(e => e.PatientEmail)
                .IsUnicode(false)
                .HasColumnName("patient_email");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
