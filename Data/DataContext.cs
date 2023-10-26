using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SecurityPrincipleWebAPICodeFirst.Models;

namespace SecurityPrincipleWebAPICodeFirst.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }
    protected DataContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<GroupMember> GroupMembers { get; set; }

    public virtual DbSet<SecurityPrinciple> SecurityPrinciples { get; set; }

    public virtual DbSet<VGroupMember> VGroupMembers { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Data Source=MATTHEW;Initial Catalog=SecurityPrincipleWebAPIDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupMember>(entity =>
        {
            entity.HasKey(e => new { e.GroupId, e.SecurityPrincipleId });

            entity.ToTable("GroupMember");

            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.SecurityPrincipleId).HasColumnName("securityPrincipleId");
            entity.Property(e => e.UpdatedBy)
                .HasMaxLength(10)
                .HasColumnName("updatedBy");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupMemberGroups)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupMember_GroupPrinciple");

            entity.HasOne(d => d.SecurityPrinciple).WithMany(p => p.GroupMemberSecurityPrinciples)
                .HasForeignKey(d => d.SecurityPrincipleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupMember_MemberPrinciple");
        });

        modelBuilder.Entity<SecurityPrinciple>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Security__3214EC07C53E46C2"); 

            entity.ToTable("SecurityPrinciple");

            entity.Property(e => e.Id)/*.ValueGeneratedNever()*/;
            entity.Property(e => e.ApplicationId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("applicationId");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("displayName");
            entity.Property(e => e.PrincipleType)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("principleType");
        });

        modelBuilder.Entity<VGroupMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vGroupMembers");

            entity.Property(e => e.GroupDisplayName)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("groupDisplayName");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.MemberDisplayName)
                .HasMaxLength(32)
                .IsFixedLength()
                .HasColumnName("memberDisplayName");
            entity.Property(e => e.MemberId).HasColumnName("memberId");
            entity.Property(e => e.MemberPrincipleType)
                .HasMaxLength(17)
                .IsUnicode(false)
                .HasColumnName("memberPrincipleType");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    public class TDataContext : DataContext
    {
        public TDataContext(DbContextOptions<TDataContext> options) : base(options)
        {

        }
    }
}
