using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Runtime.ConstrainedExecution;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Versao02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "REGIAO",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    {11 ,"São Paulo"},
                    {12 ,"São Paulo"},
                    {13 ,"São Paulo"},
                    {14 ,"São Paulo"},
                    {15 ,"São Paulo"},
                    {16 ,"São Paulo"},
                    {17 ,"São Paulo"},
                    {18 ,"São Paulo"},
                    {19 ,"São Paulo"},
                    {21 ,"Rio de Janeiro"},
                    {22 ,"Rio de Janeiro"},
                    {24 ,"Rio de Janeiro"},
                    {27 ,"Espírito Santo"},
                    {28 ,"Espírito Santo"},
                    {31 ,"Minas Gerais"},
                    {32 ,"Minas Gerais"},
                    {33 ,"Minas Gerais"},
                    {34 ,"Minas Gerais"},
                    {35 ,"Minas Gerais"},
                    {37 ,"Minas Gerais"},
                    {38 ,"Minas Gerais"},
                    {41 ,"Paraná"},
                    {42 ,"Paraná"},
                    {43 ,"Paraná"},
                    {44 ,"Paraná"},
                    {45 ,"Paraná"},
                    {46 ,"Paraná"},
                    {47 ,"Santa Catarina"},
                    {48 ,"Santa Catarina"},
                    {49 ,"Santa Catarina"},
                    {51 ,"Rio Grande do Sul"},
                    {53 ,"Rio Grande do Sul"},
                    {54 ,"Rio Grande do Sul"},
                    {55 ,"Rio Grande do Sul"},
                    {61 ,"Distrito Federal/ Goiá"},
                    {62 ,"Goiás"},
                    {63 ,"Tocantins"},
                    {64 ,"Goiás"},
                    {65 ,"Mato Grosso"},
                    {66 ,"Mato Grosso"},
                    {67 ,"Mato Grosso do Sul"},
                    {68 ,"Acre"},
                    {69 ,"Rondônia"},
                    {71 ,"Bahia"},
                    {73 ,"Bahia"},
                    {74 ,"Bahia"},
                    {75 ,"Bahia"},
                    {77 ,"Bahia"},
                    {79 ,"Sergipe"},
                    {81 ,"Pernambuco"},
                    {82 ,"Alagoas"},
                    {83 ,"Paraíba"},
                    {84 ,"Rio Grande do Norte"},
                    {85 ,"Ceará"},
                    {86 ,"Piauí"},
                    {87 ,"Pernambuco"},
                    {88 ,"Ceará"},
                    {89 ,"Piauí"},
                    {91 ,"Pará"},
                    {92 ,"Amazonas"},
                    {93 ,"Pará"},
                    {94 ,"Pará"},
                    {95 ,"Roraima"},
                    {96 ,"Amapá"},
                    {97 ,"Amazonas"},
                    {98 ,"Maranhão"},
                    {99 ,"Maranhão"}
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                          table: "REGIAO",
                          keyColumn: "Id",
                          keyValues: new object[]
                 {11,12,13,14,15,16,17,18,19,21,22,24,27,28,31,32,
                  33,34,35,37,38,41,42,43,44,45,46,47,48,49,51,53,
                  54,55,61,62,63,64,65,66,67,68,69,71,73,74,75,77,
                  79,81,82,83,84,85,86,87,88,89,91,92,93,94,95,96,
                  97,98,99});
        }
    }
}
