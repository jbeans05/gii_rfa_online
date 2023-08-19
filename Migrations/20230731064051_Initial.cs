using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Paperless_rfa.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    DeptCode = table.Column<string>(type: "text", nullable: false),
                    DeptName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleCode = table.Column<string>(type: "text", nullable: true),
                    RoleName = table.Column<string>(type: "text", nullable: true),
                    RoleDescription = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    EmployeeId = table.Column<string>(type: "text", nullable: false),
                    EmployeeName = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartementId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Departement_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    SuppliersId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Supplier_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequestOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    RequestOrderNumber = table.Column<string>(type: "text", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: true),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true),
                    DepartmentId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOrder_Departement_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestOrder_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RFA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    RFANumber = table.Column<string>(type: "text", nullable: true),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    strWhy = table.Column<string>(type: "text", nullable: true),
                    strWho = table.Column<string>(type: "text", nullable: true),
                    strWhat = table.Column<string>(type: "text", nullable: true),
                    strWhen = table.Column<string>(type: "text", nullable: true),
                    StrWhere = table.Column<string>(type: "text", nullable: true),
                    strHow = table.Column<string>(type: "text", nullable: true),
                    strHowMuch = table.Column<string>(type: "text", nullable: true),
                    isManagerApprove = table.Column<bool>(type: "boolean", nullable: false),
                    isHODApprove = table.Column<bool>(type: "boolean", nullable: false),
                    isCEOApprove = table.Column<bool>(type: "boolean", nullable: false),
                    isCFOApprove = table.Column<bool>(type: "boolean", nullable: false),
                    isAcctApprove = table.Column<bool>(type: "boolean", nullable: false),
                    isTaxApprove = table.Column<bool>(type: "boolean", nullable: false),
                    isInvoiceAttachment = table.Column<bool>(type: "boolean", nullable: false),
                    isTaxAttachment = table.Column<bool>(type: "boolean", nullable: false),
                    isDeliveryNoteAttachent = table.Column<bool>(type: "boolean", nullable: false),
                    isROAttachment = table.Column<bool>(type: "boolean", nullable: false),
                    isPOAttachment = table.Column<bool>(type: "boolean", nullable: false),
                    isQuotationAttachment = table.Column<bool>(type: "boolean", nullable: false),
                    isNoaLisAttachmentt = table.Column<bool>(type: "boolean", nullable: false),
                    isAgreementAttachment = table.Column<bool>(type: "boolean", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true),
                    DepartementId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RFA_Departement_DepartementId",
                        column: x => x.DepartementId,
                        principalTable: "Departement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RFA_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserApp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    employeeId = table.Column<int>(type: "integer", nullable: true),
                    userName = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: true),
                    isLock = table.Column<bool>(type: "boolean", nullable: false),
                    WrongPasswordCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserApp_Employee_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequestOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currentcy = table.Column<string>(type: "text", nullable: true),
                    ItemId = table.Column<int>(type: "integer", nullable: true),
                    RequestOrderId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOrderDetail_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestOrderDetail_RequestOrder_RequestOrderId",
                        column: x => x.RequestOrderId,
                        principalTable: "RequestOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    UserAppId = table.Column<int>(type: "integer", nullable: true),
                    RoleId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRole_UserApp_UserAppId",
                        column: x => x.UserAppId,
                        principalTable: "UserApp",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RFADetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ActualPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    CostAllocation = table.Column<string>(type: "text", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    ItemId = table.Column<int>(type: "integer", nullable: true),
                    SupplierId = table.Column<int>(type: "integer", nullable: true),
                    RequestOrderDetailId = table.Column<int>(type: "integer", nullable: true),
                    RfaId = table.Column<int>(type: "integer", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RFADetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RFADetail_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RFADetail_RFA_RfaId",
                        column: x => x.RfaId,
                        principalTable: "RFA",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RFADetail_RequestOrderDetail_RequestOrderDetailId",
                        column: x => x.RequestOrderDetailId,
                        principalTable: "RequestOrderDetail",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RFADetail_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departement_DeptCode",
                table: "Departement",
                column: "DeptCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartementId",
                table: "Employee",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeId",
                table: "Employee",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_Code",
                table: "Item",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_SuppliersId",
                table: "Item",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrder_DepartmentId",
                table: "RequestOrder",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrder_EmployeeId",
                table: "RequestOrder",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrder_RequestOrderNumber",
                table: "RequestOrder",
                column: "RequestOrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrderDetail_ItemId",
                table: "RequestOrderDetail",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrderDetail_RequestOrderId",
                table: "RequestOrderDetail",
                column: "RequestOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_RFA_DepartementId",
                table: "RFA",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_RFA_EmployeeId",
                table: "RFA",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RFA_RFANumber",
                table: "RFA",
                column: "RFANumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RFADetail_ItemId",
                table: "RFADetail",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RFADetail_RequestOrderDetailId",
                table: "RFADetail",
                column: "RequestOrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_RFADetail_RfaId",
                table: "RFADetail",
                column: "RfaId");

            migrationBuilder.CreateIndex(
                name: "IX_RFADetail_SupplierId",
                table: "RFADetail",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Name",
                table: "Supplier",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserApp_employeeId",
                table: "UserApp",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserApp_userName",
                table: "UserApp",
                column: "userName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserAppId",
                table: "UserRole",
                column: "UserAppId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RFADetail");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "RFA");

            migrationBuilder.DropTable(
                name: "RequestOrderDetail");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "UserApp");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "RequestOrder");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Departement");
        }
    }
}
