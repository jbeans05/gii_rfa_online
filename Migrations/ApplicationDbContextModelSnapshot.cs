﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Paperless_rfa.DataAccess;

#nullable disable

namespace Paperless_rfa.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Paperless_rfa.Models.Departement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeptCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeptCode")
                        .IsUnique();

                    b.ToTable("Departement");
                });

            modelBuilder.Entity("Paperless_rfa.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DepartementId")
                        .HasColumnType("integer");

                    b.Property<string>("EmployeeId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DepartementId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Paperless_rfa.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("SuppliersId")
                        .HasColumnType("integer");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("SuppliersId");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Paperless_rfa.Models.RFA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Currency")
                        .HasColumnType("text");

                    b.Property<int?>("DepartementId")
                        .HasColumnType("integer");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RFANumber")
                        .HasColumnType("text");

                    b.Property<string>("StrWhere")
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.Property<bool>("isAcctApprove")
                        .HasColumnType("boolean");

                    b.Property<bool>("isAgreementAttachment")
                        .HasColumnType("boolean");

                    b.Property<bool>("isCEOApprove")
                        .HasColumnType("boolean");

                    b.Property<bool>("isCFOApprove")
                        .HasColumnType("boolean");

                    b.Property<bool>("isDeliveryNoteAttachent")
                        .HasColumnType("boolean");

                    b.Property<bool>("isHODApprove")
                        .HasColumnType("boolean");

                    b.Property<bool>("isInvoiceAttachment")
                        .HasColumnType("boolean");

                    b.Property<bool>("isManagerApprove")
                        .HasColumnType("boolean");

                    b.Property<bool>("isNoaLisAttachmentt")
                        .HasColumnType("boolean");

                    b.Property<bool>("isPOAttachment")
                        .HasColumnType("boolean");

                    b.Property<bool>("isQuotationAttachment")
                        .HasColumnType("boolean");

                    b.Property<bool>("isROAttachment")
                        .HasColumnType("boolean");

                    b.Property<bool>("isTaxApprove")
                        .HasColumnType("boolean");

                    b.Property<bool>("isTaxAttachment")
                        .HasColumnType("boolean");

                    b.Property<string>("strHow")
                        .HasColumnType("text");

                    b.Property<string>("strHowMuch")
                        .HasColumnType("text");

                    b.Property<string>("strWhat")
                        .HasColumnType("text");

                    b.Property<string>("strWhen")
                        .HasColumnType("text");

                    b.Property<string>("strWho")
                        .HasColumnType("text");

                    b.Property<string>("strWhy")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartementId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RFANumber")
                        .IsUnique();

                    b.ToTable("RFA");
                });

            modelBuilder.Entity("Paperless_rfa.Models.RFADetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<decimal>("ActualPrice")
                        .HasColumnType("numeric");

                    b.Property<string>("CostAllocation")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Remark")
                        .HasColumnType("text");

                    b.Property<int?>("RequestOrderDetailId")
                        .HasColumnType("integer");

                    b.Property<int?>("RfaId")
                        .HasColumnType("integer");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("RequestOrderDetailId");

                    b.HasIndex("RfaId");

                    b.HasIndex("SupplierId");

                    b.ToTable("RFADetail");
                });

            modelBuilder.Entity("Paperless_rfa.Models.RequestOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("integer");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<string>("RequestOrderNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RequestOrderNumber")
                        .IsUnique();

                    b.ToTable("RequestOrder");
                });

            modelBuilder.Entity("Paperless_rfa.Models.RequestOrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Currentcy")
                        .HasColumnType("text");

                    b.Property<int?>("ItemId")
                        .HasColumnType("integer");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int?>("RequestOrderId")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<string>("Unit")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("RequestOrderId");

                    b.ToTable("RequestOrderDetail");
                });

            modelBuilder.Entity("Paperless_rfa.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("RoleCode")
                        .HasColumnType("text");

                    b.Property<string>("RoleDescription")
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Paperless_rfa.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("Paperless_rfa.Models.UserApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("WrongPasswordCount")
                        .HasColumnType("integer");

                    b.Property<int?>("employeeId")
                        .HasColumnType("integer");

                    b.Property<bool>("isLock")
                        .HasColumnType("boolean");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("userName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("employeeId");

                    b.HasIndex("userName")
                        .IsUnique();

                    b.ToTable("UserApp");
                });

            modelBuilder.Entity("Paperless_rfa.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserAppId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserAppId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Paperless_rfa.Models.Employee", b =>
                {
                    b.HasOne("Paperless_rfa.Models.Departement", "Departement")
                        .WithMany("Employees")
                        .HasForeignKey("DepartementId");

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("Paperless_rfa.Models.Item", b =>
                {
                    b.HasOne("Paperless_rfa.Models.Supplier", "Suppliers")
                        .WithMany("Items")
                        .HasForeignKey("SuppliersId");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("Paperless_rfa.Models.RFA", b =>
                {
                    b.HasOne("Paperless_rfa.Models.Departement", "Departement")
                        .WithMany()
                        .HasForeignKey("DepartementId");

                    b.HasOne("Paperless_rfa.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Departement");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Paperless_rfa.Models.RFADetail", b =>
                {
                    b.HasOne("Paperless_rfa.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("Paperless_rfa.Models.RequestOrderDetail", "RequestOrderDetail")
                        .WithMany()
                        .HasForeignKey("RequestOrderDetailId");

                    b.HasOne("Paperless_rfa.Models.RFA", "Rfa")
                        .WithMany("RFADetails")
                        .HasForeignKey("RfaId");

                    b.HasOne("Paperless_rfa.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.Navigation("Item");

                    b.Navigation("RequestOrderDetail");

                    b.Navigation("Rfa");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("Paperless_rfa.Models.RequestOrder", b =>
                {
                    b.HasOne("Paperless_rfa.Models.Departement", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Paperless_rfa.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Department");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Paperless_rfa.Models.RequestOrderDetail", b =>
                {
                    b.HasOne("Paperless_rfa.Models.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");

                    b.HasOne("Paperless_rfa.Models.RequestOrder", "RequestOrder")
                        .WithMany("RequestOrderDetails")
                        .HasForeignKey("RequestOrderId");

                    b.Navigation("Item");

                    b.Navigation("RequestOrder");
                });

            modelBuilder.Entity("Paperless_rfa.Models.UserApp", b =>
                {
                    b.HasOne("Paperless_rfa.Models.Employee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeId");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("Paperless_rfa.Models.UserRole", b =>
                {
                    b.HasOne("Paperless_rfa.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId");

                    b.HasOne("Paperless_rfa.Models.UserApp", "UserApp")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserAppId");

                    b.Navigation("Role");

                    b.Navigation("UserApp");
                });

            modelBuilder.Entity("Paperless_rfa.Models.Departement", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Paperless_rfa.Models.RFA", b =>
                {
                    b.Navigation("RFADetails");
                });

            modelBuilder.Entity("Paperless_rfa.Models.RequestOrder", b =>
                {
                    b.Navigation("RequestOrderDetails");
                });

            modelBuilder.Entity("Paperless_rfa.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Paperless_rfa.Models.Supplier", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("Paperless_rfa.Models.UserApp", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
