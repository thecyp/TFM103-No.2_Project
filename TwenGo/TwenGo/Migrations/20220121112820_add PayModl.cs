using Microsoft.EntityFrameworkCore.Migrations;

namespace TwenGo.Migrations
{
    public partial class addPayModl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpgatewayOutputDataModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amt = table.Column<int>(type: "int", nullable: false),
                    TradeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MerchantOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespondType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EscrowBank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespondCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card6No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Card4No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inst = table.Column<int>(type: "int", nullable: true),
                    InstFirst = table.Column<int>(type: "int", nullable: true),
                    InstEach = table.Column<int>(type: "int", nullable: true),
                    ECI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenUseStatus = table.Column<int>(type: "int", nullable: true),
                    RedAmt = table.Column<int>(type: "int", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DCC_Amt = table.Column<double>(type: "float", nullable: true),
                    DCC_Rate = table.Column<double>(type: "float", nullable: true),
                    DCC_Markup = table.Column<double>(type: "float", nullable: true),
                    DCC_Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DCC_Currency_Code = table.Column<int>(type: "int", nullable: true),
                    PayBankCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayerAccount5Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreType = table.Column<int>(type: "int", nullable: true),
                    StoreID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode_3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayStore = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpgatewayOutputDataModels", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpgatewayOutputDataModels");
        }
    }
}
