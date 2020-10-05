using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlissRecruitment.Infra.Data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionDescription = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ThumbUrl = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PublishedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionChoices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<long>(nullable: false),
                    Choice = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Votes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionChoices_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "ImageUrl", "PublishedAt", "QuestionDescription", "ThumbUrl" },
                values: new object[,]
                {
                    { 1L, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2020, 10, 5, 0, 38, 57, 782, DateTimeKind.Local).AddTicks(6698), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 2L, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2020, 10, 5, 0, 38, 57, 785, DateTimeKind.Local).AddTicks(2630), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 3L, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2020, 10, 5, 0, 38, 57, 785, DateTimeKind.Local).AddTicks(3067), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 4L, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2020, 10, 5, 0, 38, 57, 785, DateTimeKind.Local).AddTicks(3162), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 5L, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2020, 10, 5, 0, 38, 57, 785, DateTimeKind.Local).AddTicks(3246), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 6L, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2020, 10, 5, 0, 38, 57, 785, DateTimeKind.Local).AddTicks(3515), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 7L, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2020, 10, 5, 0, 38, 57, 785, DateTimeKind.Local).AddTicks(3573), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 8L, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2020, 10, 5, 0, 38, 57, 785, DateTimeKind.Local).AddTicks(3618), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 9L, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2020, 10, 5, 0, 38, 57, 785, DateTimeKind.Local).AddTicks(3661), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" },
                    { 10L, "https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)", new DateTime(2020, 10, 5, 0, 38, 57, 785, DateTimeKind.Local).AddTicks(3709), "Favourite programming language?", "https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)" }
                });

            migrationBuilder.InsertData(
                table: "QuestionChoices",
                columns: new[] { "Id", "Choice", "QuestionId", "Votes" },
                values: new object[,]
                {
                    { 1L, "Swift", 1L, 0 },
                    { 23L, "Objective-C", 6L, 0 },
                    { 24L, "Ruby", 6L, 0 },
                    { 25L, "Swift", 7L, 0 },
                    { 26L, "Python", 7L, 0 },
                    { 27L, "Objective-C", 7L, 0 },
                    { 28L, "Ruby", 7L, 0 },
                    { 29L, "Swift", 8L, 0 },
                    { 22L, "Python", 6L, 0 },
                    { 30L, "Python", 8L, 0 },
                    { 32L, "Ruby", 8L, 0 },
                    { 33L, "Swift", 9L, 0 },
                    { 34L, "Python", 9L, 0 },
                    { 35L, "Objective-C", 9L, 0 },
                    { 36L, "Ruby", 9L, 0 },
                    { 37L, "Swift", 10L, 0 },
                    { 38L, "Python", 10L, 0 },
                    { 31L, "Objective-C", 8L, 0 },
                    { 21L, "Swift", 6L, 0 },
                    { 20L, "Ruby", 5L, 0 },
                    { 19L, "Objective-C", 5L, 0 },
                    { 2L, "Python", 1L, 0 },
                    { 3L, "Objective-C", 1L, 0 },
                    { 4L, "Ruby", 1L, 0 },
                    { 5L, "Swift", 2L, 0 },
                    { 6L, "Python", 2L, 0 },
                    { 7L, "Objective-C", 2L, 0 },
                    { 8L, "Ruby", 2L, 0 },
                    { 9L, "Swift", 3L, 0 },
                    { 10L, "Python", 3L, 0 },
                    { 11L, "Objective-C", 3L, 0 },
                    { 12L, "Ruby", 3L, 0 },
                    { 13L, "Swift", 4L, 0 },
                    { 14L, "Python", 4L, 0 },
                    { 15L, "Objective-C", 4L, 0 },
                    { 16L, "Ruby", 4L, 0 },
                    { 17L, "Swift", 5L, 0 },
                    { 18L, "Python", 5L, 0 },
                    { 39L, "Objective-C", 10L, 0 },
                    { 40L, "Ruby", 10L, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionChoices_QuestionId",
                table: "QuestionChoices",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionChoices");

            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
