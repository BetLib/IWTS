using Domain.Entities;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Xml.Linq;

#nullable disable

namespace Domain.Migrations
{
    public partial class AddDefaultSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
                INSERT INTO public.""Subjects""
                (""Id"", ""Name"")
                VALUES
                ({(int)Constants.SubjectId.Math}, 'Математика'),
                ({(int)Constants.SubjectId.Russian}, 'Русский'),
                ({(int)Constants.SubjectId.Informatics}, 'Информатика'),
                ({(int)Constants.SubjectId.Biology}, 'Биология'),
                ({(int)Constants.SubjectId.SocialScience}, 'Обществознание'),
                ({(int)Constants.SubjectId.English}, 'Английский')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
