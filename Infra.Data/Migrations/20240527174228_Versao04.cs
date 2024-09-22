using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Versao04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Down(migrationBuilder);

            migrationBuilder.InsertData(
                table: "REGIAO",
                columnTypes: new[] { "int", "string", "string" },
                columns: new[] { "Id", "Descricao", "Uf"},
                values: new object[,]
                {
                    {11 ,"São Paulo e Região Metropolitana", "SP"},
                    {12 ,"Vale do Paraíba Paulista e Sul de Minas Gerais", "SP"},
                    {13 ,"Santos e Região Metropolitana da Baixada Santista", "SP"},
                    {14 ,"Bauru e Centro-Oeste Paulista", "SP"},
                    {15 ,"Bauru e Centro-Oeste Paulista", "SP"},
                    {16 ,"Ribeirão Preto e Região", "SP"},
                    {17 ,"Região de São José do Rio Preto", "SP"},
                    {18 ,"Presidente Prudente e Oeste Paulista", "SP"},
                    {19 ,"Região de Campinas", "SP"},
                    {21 ,"Rio de Janeiro e Região Metropolitana", "RJ"},
                    {22 ,"Cabo Frio e Região", "RJ"},
                    {24 ,"Angra dos Reis e Região", "RJ"},
                    {27 ,"Vitória e Região Metropolitana", "ES"},
                    {28 ,"Cachoeiro de Itapemirim e Região", "ES"},
                    {31 ,"Belo Horizonte e Região Metropolitana", "MG"},
                    {32 ,"Barbacena e Reigão", "MG"},
                    {33 ,"Almenara e Região", "MG"},
                    {34 ,"Araguari e Região","MG"},
                    {35 ,"Alfenas e Região","MG"},
                    {37 ,"Bom Despacho e Região","MG"},
                    {38 ,"Curvelo e Região","MG"},
                    {41 ,"Curitiba e Região Metropolitana","PR"},
                    {42 ,"Ponta Grossa e Região","PR"},
                    {43 ,"Londrina e Região","PR"},
                    {44 ,"Maringá e Região","PR"},
                    {45 ,"Cascavel e Região","PR"},
                    {46 ,"Francisco Beltrão e Região","PR"},
                    {47 ,"Balneário Camboriú e Região", "SC"},
                    {48 ,"Florianópolis e Região Metropolitana", "SC"},
                    {49 ,"Caçador e Região", "SC"},
                    {51 ,"Porto Alegre e Região Metropolitana", "RS"},
                    {53 ,"Pelotas e Região", "RS"},
                    {54 ,"Caxias do Sul e Região", "RS"},
                    {55 ,"Santa Maria e Região", "RS"},
                    {61 ,"Distrito Federal e Região integrada de desenvolvimento e entorno", "DF"},
                    {62 ,"Goiânia e Região Metropolitana", "GO"},
                    {63 ,"Tocantins", "TO"},
                    {64 ,"Caldas Novas e Região", "GO"},
                    {65 ,"Cuiabá e Região Metropolitana", "MT"},
                    {66 ,"Rondonópolis e Região", "MT"},
                    {67 ,"Mato Grosso do Sul", "MS"},
                    {68 ,"Acre", "AC"},
                    {69 ,"Rondônia", "RO"},
                    {71 ,"Salvador e Região Metropolitana", "BA"},
                    {73 ,"Porto Seguro e Região", "BA"},
                    {74 ,"Juazeiro e Região", "BA"},
                    {75 ,"Feira de Santana e Região", "BA"},
                    {77 ,"Vitória da Conquista e Região", "BA"},
                    {79 ,"Sergipe", "SE"},
                    {81 ,"Recife e Região Metropolitana", "PE"},
                    {82 ,"Alagoas", "AL"},
                    {83 ,"Paraíba", "PB"},
                    {84 ,"Rio Grande do Norte", "RN"},
                    {85 ,"Fortaleza e Região Metropolitana", "CE"},
                    {86 ,"Teresina e Região", "PI"},
                    {87 ,"Petrolina e Região", "PE"},
                    {88 ,"Juazeiro do Norte e Região", "CE"},
                    {89 ,"Picos e Região", "PI"},
                    {91 ,"Belém e Região Metropolitana", "PA"},
                    {92 ,"Manaus e Região Metropolitana", "AM"},
                    {93 ,"Santarém e Região", "PA"},
                    {94 ,"Santarém e Região", "PA"},
                    {95 ,"Roraima", "RR"},
                    {96 ,"Amapá", "AP"},
                    {97 ,"Interior de Amazonas", "AM"},
                    {98 ,"São Luís e Região Metropolitana", "MA"},
                    {99 ,"Imperatriz e Região","MA" }
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
