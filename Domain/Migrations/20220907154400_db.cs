using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MD_Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TaxCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MD_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "SAM_Module",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModuleDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAM_Module", x => x.ModuleID);
                });

            migrationBuilder.CreateTable(
                name: "SAM_Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RoleNotes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    RoleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAM_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "SAM_UserAccount",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccPwd = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: true),
                    AccountEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RecoveryEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: true),
                    CreatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAM_UserAccount", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_SAM_UserAccount_MD_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "MD_Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SAM_Function",
                columns: table => new
                {
                    FuncID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FuncDesc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    URL = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    CreatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAM_Function", x => x.FuncID);
                    table.ForeignKey(
                        name: "FK_SAM_Function_SAM_Module_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "SAM_Module",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SAM_UserInRole",
                columns: table => new
                {
                    UID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidDateFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    ValidDateTo = table.Column<DateTime>(type: "datetime", nullable: true),
                    AccountID = table.Column<int>(type: "int", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    CreatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAM_UserInRole", x => x.UID);
                    table.ForeignKey(
                        name: "FK_SAM_UserInRole_SAM_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "SAM_Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SAM_UserInRole_SAM_UserAccount_AccountID",
                        column: x => x.AccountID,
                        principalTable: "SAM_UserAccount",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SAM_FuncInRole",
                columns: table => new
                {
                    FID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    FuncID = table.Column<int>(type: "int", nullable: true),
                    CreatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedUser = table.Column<string>(type: "varchar(125)", unicode: false, maxLength: 125, nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAM_FuncInRole", x => x.FID);
                    table.ForeignKey(
                        name: "FK_SAM_FuncInRole_SAM_Function_FuncID",
                        column: x => x.FuncID,
                        principalTable: "SAM_Function",
                        principalColumn: "FuncID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SAM_FuncInRole_SAM_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "SAM_Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SAM_FuncInRole_FuncID",
                table: "SAM_FuncInRole",
                column: "FuncID");

            migrationBuilder.CreateIndex(
                name: "IX_SAM_FuncInRole_RoleID",
                table: "SAM_FuncInRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_SAM_Function_ModuleID",
                table: "SAM_Function",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_SAM_UserAccount_CustomerID",
                table: "SAM_UserAccount",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_SAM_UserInRole_AccountID",
                table: "SAM_UserInRole",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_SAM_UserInRole_RoleID",
                table: "SAM_UserInRole",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SAM_FuncInRole");

            migrationBuilder.DropTable(
                name: "SAM_UserInRole");

            migrationBuilder.DropTable(
                name: "SAM_Function");

            migrationBuilder.DropTable(
                name: "SAM_Role");

            migrationBuilder.DropTable(
                name: "SAM_UserAccount");

            migrationBuilder.DropTable(
                name: "SAM_Module");

            migrationBuilder.DropTable(
                name: "MD_Customer");
        }
    }
}
