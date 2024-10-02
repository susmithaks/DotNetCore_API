using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetCore_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("4f0ef889-2941-493d-8fe7-0a9db0a56ed2"), "Hard" },
                    { new Guid("ee6159ac-8734-473c-a145-16c2e9f89960"), "Medium" },
                    { new Guid("ff373f74-3563-4ce0-82c0-99f0c065f738"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("40070409-302c-4a4a-a43a-45a600381531"), "TN", "Tuticorin", null },
                    { new Guid("6637ea22-e7a9-465d-9a98-f5226b0bc3bd"), "TJ", "Thanjavur", "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528" },
                    { new Guid("6b3066bb-856d-429c-b759-f11e7b1fe14f"), "GI", "Guduvancheri", null },
                    { new Guid("9e4a3927-533c-48e2-8866-2f8f150df78e"), "MDU", "Madurai", "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528" },
                    { new Guid("a6c98bc3-381f-4826-86c6-e4b7f0877876"), "CHN", "Chennai", "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528" },
                    { new Guid("c0ef2d24-a848-41c6-8e87-4066faed8bbf"), "TLR", "Tiruvallur", "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528" },
                    { new Guid("c3b44ff9-3a3a-45e5-90cd-6345dfcc2d6c"), "DG", "Dindigul", "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528" },
                    { new Guid("dedf0bf4-074e-48ea-a46e-a7ad48ee67cb"), "TPJ", "Tiruchirappalli", "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528" },
                    { new Guid("e293c64f-bb48-4165-8f51-51d974e774d2"), "RMM", "Rameswaram", "https://stock.adobe.com/in/images/sri-meenakshi-temple/47862528" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4f0ef889-2941-493d-8fe7-0a9db0a56ed2"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ee6159ac-8734-473c-a145-16c2e9f89960"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ff373f74-3563-4ce0-82c0-99f0c065f738"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("40070409-302c-4a4a-a43a-45a600381531"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6637ea22-e7a9-465d-9a98-f5226b0bc3bd"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6b3066bb-856d-429c-b759-f11e7b1fe14f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9e4a3927-533c-48e2-8866-2f8f150df78e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a6c98bc3-381f-4826-86c6-e4b7f0877876"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c0ef2d24-a848-41c6-8e87-4066faed8bbf"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c3b44ff9-3a3a-45e5-90cd-6345dfcc2d6c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("dedf0bf4-074e-48ea-a46e-a7ad48ee67cb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e293c64f-bb48-4165-8f51-51d974e774d2"));
        }
    }
}
