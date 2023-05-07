using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntregaSegura.API.Migrations
{
    public partial class AlteracaoEstrutura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TRANSPORTADORAS_CNPJ",
                table: "TB_TRANSPORTADORAS");

            migrationBuilder.DropIndex(
                name: "IX_TRANSPORTADORAS_EMAIL",
                table: "TB_TRANSPORTADORAS");

            migrationBuilder.DropIndex(
                name: "IX_TRANSPORTADORAS_TELEFONE",
                table: "TB_TRANSPORTADORAS");

            migrationBuilder.DeleteData(
                table: "TB_ENTREGAS",
                keyColumn: "ETG_ID",
                keyValue: new Guid("8339a211-dd63-43d0-bc26-193bb90f99f1"));

            migrationBuilder.DeleteData(
                table: "TB_FUNCIONARIOS",
                keyColumn: "FUN_ID",
                keyValue: new Guid("c2fc8a76-2989-4b7d-8099-b3ab3f4a7188"));

            migrationBuilder.DeleteData(
                table: "TB_MORADORES",
                keyColumn: "MOR_ID",
                keyValue: new Guid("0f2dcb61-c456-403a-918c-abd85214bdc1"));

            migrationBuilder.DeleteData(
                table: "TB_TRANSPORTADORAS",
                keyColumn: "TRA_ID",
                keyValue: new Guid("1bc38b42-5ec3-4165-8f1f-2cebfc8b7d2e"));

            migrationBuilder.DeleteData(
                table: "TB_UNIDADES",
                keyColumn: "UND_ID",
                keyValue: new Guid("1f0c68f4-4357-4a80-a39c-920cd40e0a88"));

            migrationBuilder.DeleteData(
                table: "TB_CONDOMINIOS",
                keyColumn: "CND_ID",
                keyValue: new Guid("17f36e9f-8cbe-4dcd-b312-70e2ec47058f"));

            migrationBuilder.AlterColumn<string>(
                name: "TRA_TELEFONE",
                table: "TB_TRANSPORTADORAS",
                type: "varchar(11)",
                nullable: true,
                comment: "Telefone da transportadora",
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldComment: "Telefone da transportadora");

            migrationBuilder.AlterColumn<string>(
                name: "TRA_EMAIL",
                table: "TB_TRANSPORTADORAS",
                type: "varchar(100)",
                nullable: true,
                comment: "E-mail da transportadora",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldComment: "E-mail da transportadora");

            migrationBuilder.AlterColumn<string>(
                name: "TRA_CNPJ",
                table: "TB_TRANSPORTADORAS",
                type: "varchar(14)",
                nullable: true,
                comment: "CNPJ da transportadora",
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldComment: "CNPJ da transportadora");

            migrationBuilder.InsertData(
                table: "TB_CONDOMINIOS",
                columns: new[] { "CND_ID", "CND_BAIRRO", "CND_CEP", "CND_CNPJ", "CND_CIDADE", "CND_COMPLEMENTO", "CND_DATA_ATUALIZACAO", "CND_DATA_CRIACAO", "CND_DATA_EXCLUSAO", "CND_EMAIL", "CND_ESTADO", "CND_LOGRADOURO", "CND_NOME", "CND_NUMERO", "CND_TELEFONE" },
                values: new object[] { new Guid("a0875673-1846-41b7-a175-0da3d7ecd460"), "Bairro Exemplo", "11111111", "11111111111111", "Cidade Exemplo", "Bloco A", new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6110), new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6102), null, "contato@condominioexemplo.com.br", "SP", "Rua Exemplo", "Condomínio Exemplo", "100", "11999999999" });

            migrationBuilder.InsertData(
                table: "TB_TRANSPORTADORAS",
                columns: new[] { "TRA_ID", "TRA_CNPJ", "TRA_DATA_ATUALIZACAO", "TRA_DATA_CRIACAO", "TRA_DATA_EXCLUSAO", "TRA_EMAIL", "TRA_NOME", "TRA_TELEFONE" },
                values: new object[] { new Guid("ec08a5fc-8353-41d4-829c-fc1e0c8a037d"), "22222222222222", new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6246), new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6246), null, "contato@transportadoraexemplo.com.br", "Transportadora Exemplo", "11988888888" });

            migrationBuilder.InsertData(
                table: "TB_FUNCIONARIOS",
                columns: new[] { "FUN_ID", "FUN_CPF", "FUN_CARGO", "FUN_CONDOMINIO_ID", "FUN_DATA_ADMISSAO", "FUN_DATA_ATUALIZACAO", "FUN_DATA_CRIACAO", "FUN_DATA_DEMISSAO", "FUN_DATA_EXCLUSAO", "FUN_EMAIL", "FUN_NOME", "FUN_STATUS", "FUN_TELEFONE" },
                values: new object[] { new Guid("c5c9430c-3d61-462b-a9a9-85f3a4e0676e"), "98765432109", 2, new Guid("a0875673-1846-41b7-a175-0da3d7ecd460"), new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6234), new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6233), new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6233), null, null, "funcionario@email.com", "Funcionario Exemplo", 2, "11999999999" });

            migrationBuilder.InsertData(
                table: "TB_UNIDADES",
                columns: new[] { "UND_ID", "UND_BLOCO", "CON_ID", "UND_DATA_ATUALIZACAO", "UND_DATA_CRIACAO", "UND_DATA_EXCLUSAO", "UND_NUMERO" },
                values: new object[] { new Guid("fffc9618-f8f0-4137-bedc-7bcb43e52b0d"), "A", new Guid("a0875673-1846-41b7-a175-0da3d7ecd460"), new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6204), new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6204), null, "101" });

            migrationBuilder.InsertData(
                table: "TB_MORADORES",
                columns: new[] { "MOR_ID", "MOR_CPF", "MOR_DATA_ATUALIZACAO", "MOR_DATA_CRIACAO", "MOR_DATA_EXCLUSAO", "MOR_EMAIL", "MOR_NOME", "MOR_STATUS", "MOR_TELEFONE", "MOR_UNIDADE_ID" },
                values: new object[] { new Guid("c076638d-7dfc-44dc-9701-f65c42e111f3"), "12345678901", new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6218), new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6218), null, "morador@email.com", "Morador Exemplo", 2, "11999999999", new Guid("fffc9618-f8f0-4137-bedc-7bcb43e52b0d") });

            migrationBuilder.InsertData(
                table: "TB_ENTREGAS",
                columns: new[] { "ETG_ID", "ETG_DATA_ATUALIZACAO", "ETG_DATA_CRIACAO", "ETG_DATA_EXCLUSAO", "ETG_DATA_RECEBIMENTO", "ETG_DATA_RETIRADA", "ETG_DESCRICAO", "ETG_DESTINATARIO", "FUN_ID", "MOR_ID", "ETG_OBSERVACAO", "ETG_REMETENTE", "ETG_STATUS", "TRP_ID" },
                values: new object[] { new Guid("826c10c7-0a9d-4676-8fdc-1c8ed5869cd4"), new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6304), new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6304), null, new DateTime(2023, 5, 7, 14, 27, 52, 37, DateTimeKind.Local).AddTicks(6306), null, "Descrição da entrega", "Destinatario Exemplo", new Guid("c5c9430c-3d61-462b-a9a9-85f3a4e0676e"), new Guid("c076638d-7dfc-44dc-9701-f65c42e111f3"), "Observação da entrega", "Remetente Exemplo", 1, new Guid("ec08a5fc-8353-41d4-829c-fc1e0c8a037d") });

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTADORAS_CNPJ",
                table: "TB_TRANSPORTADORAS",
                column: "TRA_CNPJ",
                unique: true,
                filter: "[TRA_CNPJ] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTADORAS_EMAIL",
                table: "TB_TRANSPORTADORAS",
                column: "TRA_EMAIL",
                unique: true,
                filter: "[TRA_EMAIL] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTADORAS_TELEFONE",
                table: "TB_TRANSPORTADORAS",
                column: "TRA_TELEFONE",
                unique: true,
                filter: "[TRA_TELEFONE] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TRANSPORTADORAS_CNPJ",
                table: "TB_TRANSPORTADORAS");

            migrationBuilder.DropIndex(
                name: "IX_TRANSPORTADORAS_EMAIL",
                table: "TB_TRANSPORTADORAS");

            migrationBuilder.DropIndex(
                name: "IX_TRANSPORTADORAS_TELEFONE",
                table: "TB_TRANSPORTADORAS");

            migrationBuilder.DeleteData(
                table: "TB_ENTREGAS",
                keyColumn: "ETG_ID",
                keyValue: new Guid("826c10c7-0a9d-4676-8fdc-1c8ed5869cd4"));

            migrationBuilder.DeleteData(
                table: "TB_FUNCIONARIOS",
                keyColumn: "FUN_ID",
                keyValue: new Guid("c5c9430c-3d61-462b-a9a9-85f3a4e0676e"));

            migrationBuilder.DeleteData(
                table: "TB_MORADORES",
                keyColumn: "MOR_ID",
                keyValue: new Guid("c076638d-7dfc-44dc-9701-f65c42e111f3"));

            migrationBuilder.DeleteData(
                table: "TB_TRANSPORTADORAS",
                keyColumn: "TRA_ID",
                keyValue: new Guid("ec08a5fc-8353-41d4-829c-fc1e0c8a037d"));

            migrationBuilder.DeleteData(
                table: "TB_UNIDADES",
                keyColumn: "UND_ID",
                keyValue: new Guid("fffc9618-f8f0-4137-bedc-7bcb43e52b0d"));

            migrationBuilder.DeleteData(
                table: "TB_CONDOMINIOS",
                keyColumn: "CND_ID",
                keyValue: new Guid("a0875673-1846-41b7-a175-0da3d7ecd460"));

            migrationBuilder.AlterColumn<string>(
                name: "TRA_TELEFONE",
                table: "TB_TRANSPORTADORAS",
                type: "varchar(11)",
                nullable: false,
                defaultValue: "",
                comment: "Telefone da transportadora",
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldNullable: true,
                oldComment: "Telefone da transportadora");

            migrationBuilder.AlterColumn<string>(
                name: "TRA_EMAIL",
                table: "TB_TRANSPORTADORAS",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "",
                comment: "E-mail da transportadora",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true,
                oldComment: "E-mail da transportadora");

            migrationBuilder.AlterColumn<string>(
                name: "TRA_CNPJ",
                table: "TB_TRANSPORTADORAS",
                type: "varchar(14)",
                nullable: false,
                defaultValue: "",
                comment: "CNPJ da transportadora",
                oldClrType: typeof(string),
                oldType: "varchar(14)",
                oldNullable: true,
                oldComment: "CNPJ da transportadora");

            migrationBuilder.InsertData(
                table: "TB_CONDOMINIOS",
                columns: new[] { "CND_ID", "CND_BAIRRO", "CND_CEP", "CND_CNPJ", "CND_CIDADE", "CND_COMPLEMENTO", "CND_DATA_ATUALIZACAO", "CND_DATA_CRIACAO", "CND_DATA_EXCLUSAO", "CND_EMAIL", "CND_ESTADO", "CND_LOGRADOURO", "CND_NOME", "CND_NUMERO", "CND_TELEFONE" },
                values: new object[] { new Guid("17f36e9f-8cbe-4dcd-b312-70e2ec47058f"), "Bairro Exemplo", "11111111", "11111111111111", "Cidade Exemplo", "Bloco A", new DateTime(2023, 5, 7, 0, 18, 7, 502, DateTimeKind.Local).AddTicks(9949), new DateTime(2023, 5, 7, 0, 18, 7, 502, DateTimeKind.Local).AddTicks(9941), null, "contato@condominioexemplo.com.br", "SP", "Rua Exemplo", "Condomínio Exemplo", "100", "11999999999" });

            migrationBuilder.InsertData(
                table: "TB_TRANSPORTADORAS",
                columns: new[] { "TRA_ID", "TRA_CNPJ", "TRA_DATA_ATUALIZACAO", "TRA_DATA_CRIACAO", "TRA_DATA_EXCLUSAO", "TRA_EMAIL", "TRA_NOME", "TRA_TELEFONE" },
                values: new object[] { new Guid("1bc38b42-5ec3-4165-8f1f-2cebfc8b7d2e"), "22222222222222", new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(933), new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(932), null, "contato@transportadoraexemplo.com.br", "Transportadora Exemplo", "11988888888" });

            migrationBuilder.InsertData(
                table: "TB_FUNCIONARIOS",
                columns: new[] { "FUN_ID", "FUN_CPF", "FUN_CARGO", "FUN_CONDOMINIO_ID", "FUN_DATA_ADMISSAO", "FUN_DATA_ATUALIZACAO", "FUN_DATA_CRIACAO", "FUN_DATA_DEMISSAO", "FUN_DATA_EXCLUSAO", "FUN_EMAIL", "FUN_NOME", "FUN_STATUS", "FUN_TELEFONE" },
                values: new object[] { new Guid("c2fc8a76-2989-4b7d-8099-b3ab3f4a7188"), "98765432109", 2, new Guid("17f36e9f-8cbe-4dcd-b312-70e2ec47058f"), new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(62), new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(61), new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(61), null, null, "funcionario@email.com", "Funcionario Exemplo", 2, "11999999999" });

            migrationBuilder.InsertData(
                table: "TB_UNIDADES",
                columns: new[] { "UND_ID", "UND_BLOCO", "CON_ID", "UND_DATA_ATUALIZACAO", "UND_DATA_CRIACAO", "UND_DATA_EXCLUSAO", "UND_NUMERO" },
                values: new object[] { new Guid("1f0c68f4-4357-4a80-a39c-920cd40e0a88"), "A", new Guid("17f36e9f-8cbe-4dcd-b312-70e2ec47058f"), new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(33), new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(32), null, "101" });

            migrationBuilder.InsertData(
                table: "TB_MORADORES",
                columns: new[] { "MOR_ID", "MOR_CPF", "MOR_DATA_ATUALIZACAO", "MOR_DATA_CRIACAO", "MOR_DATA_EXCLUSAO", "MOR_EMAIL", "MOR_NOME", "MOR_STATUS", "MOR_TELEFONE", "MOR_UNIDADE_ID" },
                values: new object[] { new Guid("0f2dcb61-c456-403a-918c-abd85214bdc1"), "12345678901", new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(47), new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(47), null, "morador@email.com", "Morador Exemplo", 2, "11999999999", new Guid("1f0c68f4-4357-4a80-a39c-920cd40e0a88") });

            migrationBuilder.InsertData(
                table: "TB_ENTREGAS",
                columns: new[] { "ETG_ID", "ETG_DATA_ATUALIZACAO", "ETG_DATA_CRIACAO", "ETG_DATA_EXCLUSAO", "ETG_DATA_RECEBIMENTO", "ETG_DATA_RETIRADA", "ETG_DESCRICAO", "ETG_DESTINATARIO", "FUN_ID", "MOR_ID", "ETG_OBSERVACAO", "ETG_REMETENTE", "ETG_STATUS", "TRP_ID" },
                values: new object[] { new Guid("8339a211-dd63-43d0-bc26-193bb90f99f1"), new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(953), new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(953), null, new DateTime(2023, 5, 7, 0, 18, 7, 503, DateTimeKind.Local).AddTicks(955), null, "Descrição da entrega", "Destinatario Exemplo", new Guid("c2fc8a76-2989-4b7d-8099-b3ab3f4a7188"), new Guid("0f2dcb61-c456-403a-918c-abd85214bdc1"), "Observação da entrega", "Remetente Exemplo", 1, new Guid("1bc38b42-5ec3-4165-8f1f-2cebfc8b7d2e") });

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTADORAS_CNPJ",
                table: "TB_TRANSPORTADORAS",
                column: "TRA_CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTADORAS_EMAIL",
                table: "TB_TRANSPORTADORAS",
                column: "TRA_EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTADORAS_TELEFONE",
                table: "TB_TRANSPORTADORAS",
                column: "TRA_TELEFONE",
                unique: true);
        }
    }
}
