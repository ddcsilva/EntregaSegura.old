using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntregaSegura.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CONDOMINIOS",
                columns: table => new
                {
                    CND_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave primária do condomínio"),
                    CND_NOME = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Nome do condomínio"),
                    CND_CNPJ = table.Column<string>(type: "varchar(14)", nullable: false, comment: "CNPJ do condomínio"),
                    CND_TELEFONE = table.Column<string>(type: "varchar(11)", nullable: false, comment: "Telefone do condomínio"),
                    CND_EMAIL = table.Column<string>(type: "varchar(100)", nullable: false, comment: "E-mail do condomínio"),
                    CND_DATA_CRIACAO = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()", comment: "Data de criação do condomínio"),
                    CND_DATA_ATUALIZACAO = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()", comment: "Data da última atualização do condomínio"),
                    CND_DATA_EXCLUSAO = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Data da exclusão do condomínio")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONDOMINIOS", x => x.CND_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_TRANSPORTADORAS",
                columns: table => new
                {
                    TRA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave primária da transportadora"),
                    TRA_NOME = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Nome da transportadora"),
                    TRA_CNPJ = table.Column<string>(type: "varchar(14)", nullable: false, comment: "CNPJ da transportadora"),
                    TRA_TELEFONE = table.Column<string>(type: "varchar(11)", nullable: false, comment: "Telefone da transportadora"),
                    TRA_EMAIL = table.Column<string>(type: "varchar(100)", nullable: false, comment: "E-mail da transportadora"),
                    TRA_DATA_CRIACAO = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()", comment: "Data de criação da transportadora"),
                    TRA_DATA_ATUALIZACAO = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()", comment: "Data da última atualização da transportadora"),
                    TRA_DATA_EXCLUSAO = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Data da exclusão da transportadora")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSPORTADORAS", x => x.TRA_ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENDERECOS",
                columns: table => new
                {
                    END_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave primária do endereço"),
                    CON_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave estrangeira do condomínio"),
                    END_LOGRADOURO = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Logradouro do endereço"),
                    END_NUMERO = table.Column<string>(type: "varchar(10)", nullable: false, comment: "Número do endereço"),
                    END_COMPLEMENTO = table.Column<string>(type: "varchar(100)", nullable: true, comment: "Complemento do endereço"),
                    END_CEP = table.Column<string>(type: "varchar(8)", nullable: false, comment: "CEP do endereço"),
                    END_BAIRRO = table.Column<string>(type: "varchar(50)", nullable: false, comment: "Bairro do endereço"),
                    END_CIDADE = table.Column<string>(type: "varchar(50)", nullable: false, comment: "Cidade do endereço"),
                    END_ESTADO = table.Column<string>(type: "varchar(2)", nullable: false, comment: "Estado do endereço"),
                    END_DATA_CRIACAO = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()", comment: "Data de criação do endereço"),
                    END_DATA_ATUALIZACAO = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()", comment: "Data da última atualização do endereço"),
                    END_DATA_EXCLUSAO = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Data da exclusão do endereço")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECOS", x => x.END_ID);
                    table.ForeignKey(
                        name: "FK_ENDERECO_CONDOMINIO",
                        column: x => x.CON_ID,
                        principalTable: "TB_CONDOMINIOS",
                        principalColumn: "CND_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_FUNCIONARIOS",
                columns: table => new
                {
                    FUN_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave primária do funcionário"),
                    FUN_NOME = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Nome do funcionário"),
                    FUN_CPF = table.Column<string>(type: "varchar(11)", nullable: false, comment: "CPF do funcionário"),
                    FUN_EMAIL = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Email do funcionário"),
                    FUN_TELEFONE = table.Column<string>(type: "varchar(11)", nullable: false, comment: "Telefone do funcionário"),
                    FUN_STATUS = table.Column<int>(type: "int", nullable: false, comment: "Status do funcionário"),
                    FUN_CARGO = table.Column<int>(type: "int", nullable: false, comment: "Cargo do funcionário"),
                    FUN_DATA_ADMISSAO = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Data de admissão do funcionário"),
                    FUN_DATA_DEMISSAO = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Data de demissão do funcionário"),
                    FUN_DATA_CRIACAO = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()", comment: "Data de criação do funcionário"),
                    FUN_DATA_ATUALIZACAO = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()", comment: "Data da última atualização do funcionário"),
                    FUN_DATA_EXCLUSAO = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Data da exclusão do funcionário"),
                    FUN_CONDOMINIO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave estrangeira do condomínio")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FUNCIONARIOS", x => x.FUN_ID);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_CONDOMINIO",
                        column: x => x.FUN_CONDOMINIO_ID,
                        principalTable: "TB_CONDOMINIOS",
                        principalColumn: "CND_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_UNIDADES",
                columns: table => new
                {
                    UND_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave primária da unidade"),
                    CON_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave estrangeira do condomínio"),
                    UND_NUMERO = table.Column<string>(type: "varchar(10)", nullable: false, comment: "Número da unidade"),
                    UND_BLOCO = table.Column<string>(type: "varchar(10)", nullable: true, comment: "Bloco da unidade"),
                    UND_DATA_CRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Data de criação da unidade"),
                    UND_DATA_ATUALIZACAO = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()", comment: "Data da última atualização da unidade"),
                    UND_DATA_EXCLUSAO = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Data da exclusão da unidade")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNIDADES", x => x.UND_ID);
                    table.ForeignKey(
                        name: "FK_UNIDADES_CONDOMINIOS",
                        column: x => x.CON_ID,
                        principalTable: "TB_CONDOMINIOS",
                        principalColumn: "CND_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_MORADORES",
                columns: table => new
                {
                    MOR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave primária do morador"),
                    MOR_NOME = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Nome do morador"),
                    MOR_CPF = table.Column<string>(type: "varchar(11)", nullable: false, comment: "CPF do morador"),
                    MOR_EMAIL = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Email do morador"),
                    MOR_TELEFONE = table.Column<string>(type: "varchar(11)", nullable: false, comment: "Telefone do morador"),
                    MOR_STATUS = table.Column<int>(type: "int", nullable: false, comment: "Status do morador"),
                    MOR_UNIDADE_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave estrangeira da unidade do morador"),
                    MOR_DATA_CRIACAO = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Data de criação do morador"),
                    MOR_DATA_ATUALIZACAO = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Data da última atualização do morador"),
                    MOR_DATA_EXCLUSAO = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Data da exclusão do morador")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MORADORES", x => x.MOR_ID);
                    table.ForeignKey(
                        name: "FK_MORADORES_UNIDADES",
                        column: x => x.MOR_UNIDADE_ID,
                        principalTable: "TB_UNIDADES",
                        principalColumn: "UND_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_ENTREGAS",
                columns: table => new
                {
                    ETG_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave primária da entrega"),
                    TRP_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave estrangeira da transportadora"),
                    FUN_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave estrangeira do funcionário"),
                    MOR_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Chave estrangeira do morador"),
                    ETG_REMETENTE = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Nome do remetente da entrega"),
                    ETG_DESTINATARIO = table.Column<string>(type: "varchar(100)", nullable: false, comment: "Nome do destinatário da entrega"),
                    ETG_DATA_RECEBIMENTO = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Data de recebimento da entrega"),
                    ETG_DATA_RETIRADA = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Data de retirada da entrega"),
                    ETG_DESCRICAO = table.Column<string>(type: "varchar(200)", nullable: true, comment: "Descrição da entrega"),
                    ETG_OBSERVACAO = table.Column<string>(type: "varchar(200)", nullable: true, comment: "Observação da entrega"),
                    ETG_STATUS = table.Column<int>(type: "int", nullable: false, comment: "Status da entrega"),
                    ETG_DATA_CRIACAO = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()", comment: "Data de criação da entrega"),
                    ETG_DATA_ATUALIZACAO = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()", comment: "Data da última atualização da entrega"),
                    ETG_DATA_EXCLUSAO = table.Column<DateTime>(type: "datetime", nullable: true, comment: "Data da exclusão da entrega")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTREGAS", x => x.ETG_ID);
                    table.ForeignKey(
                        name: "FK_ENTREGA_TRANSPORTADORA",
                        column: x => x.TRP_ID,
                        principalTable: "TB_TRANSPORTADORAS",
                        principalColumn: "TRA_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FUNCIONARIO_ENTREGA",
                        column: x => x.FUN_ID,
                        principalTable: "TB_FUNCIONARIOS",
                        principalColumn: "FUN_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MORADORES_ENTREGAS",
                        column: x => x.MOR_ID,
                        principalTable: "TB_MORADORES",
                        principalColumn: "MOR_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TB_CONDOMINIOS",
                columns: new[] { "CND_ID", "CND_CNPJ", "CND_DATA_ATUALIZACAO", "CND_DATA_CRIACAO", "CND_DATA_EXCLUSAO", "CND_EMAIL", "CND_NOME", "CND_TELEFONE" },
                values: new object[] { new Guid("502baf2c-f36a-4e7d-a535-da632f982172"), "11111111111111", new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3107), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3097), null, "contato@condominioexemplo.com.br", "Condomínio Exemplo", "11999999999" });

            migrationBuilder.InsertData(
                table: "TB_TRANSPORTADORAS",
                columns: new[] { "TRA_ID", "TRA_CNPJ", "TRA_DATA_ATUALIZACAO", "TRA_DATA_CRIACAO", "TRA_DATA_EXCLUSAO", "TRA_EMAIL", "TRA_NOME", "TRA_TELEFONE" },
                values: new object[] { new Guid("2ede059b-6321-4ead-aef3-01040f1c36b5"), "22222222222222", new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3343), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3343), null, "contato@transportadoraexemplo.com.br", "Transportadora Exemplo", "11988888888" });

            migrationBuilder.InsertData(
                table: "TB_ENDERECOS",
                columns: new[] { "END_ID", "END_BAIRRO", "END_CEP", "END_CIDADE", "END_COMPLEMENTO", "CON_ID", "END_DATA_ATUALIZACAO", "END_DATA_CRIACAO", "END_DATA_EXCLUSAO", "END_ESTADO", "END_LOGRADOURO", "END_NUMERO" },
                values: new object[] { new Guid("87e884bf-2426-414c-8679-3d0632dc10d6"), "Bairro Exemplo", "11111111", "Cidade Exemplo", "Bloco A", new Guid("502baf2c-f36a-4e7d-a535-da632f982172"), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3214), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3214), null, "SP", "Rua Exemplo", "100" });

            migrationBuilder.InsertData(
                table: "TB_FUNCIONARIOS",
                columns: new[] { "FUN_ID", "FUN_CPF", "FUN_CARGO", "FUN_CONDOMINIO_ID", "FUN_DATA_ADMISSAO", "FUN_DATA_ATUALIZACAO", "FUN_DATA_CRIACAO", "FUN_DATA_DEMISSAO", "FUN_DATA_EXCLUSAO", "FUN_EMAIL", "FUN_NOME", "FUN_STATUS", "FUN_TELEFONE" },
                values: new object[] { new Guid("e0024df7-457a-44b7-bf34-929d65e1981e"), "98765432109", 2, new Guid("502baf2c-f36a-4e7d-a535-da632f982172"), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3329), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3329), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3328), null, null, "funcionario@email.com", "Funcionario Exemplo", 2, "11999999999" });

            migrationBuilder.InsertData(
                table: "TB_UNIDADES",
                columns: new[] { "UND_ID", "UND_BLOCO", "CON_ID", "UND_DATA_ATUALIZACAO", "UND_DATA_CRIACAO", "UND_DATA_EXCLUSAO", "UND_NUMERO" },
                values: new object[] { new Guid("085671e6-cea0-4cbb-a2f2-5ac83b7cc4e3"), "A", new Guid("502baf2c-f36a-4e7d-a535-da632f982172"), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3293), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3293), null, "101" });

            migrationBuilder.InsertData(
                table: "TB_MORADORES",
                columns: new[] { "MOR_ID", "MOR_CPF", "MOR_DATA_ATUALIZACAO", "MOR_DATA_CRIACAO", "MOR_DATA_EXCLUSAO", "MOR_EMAIL", "MOR_NOME", "MOR_STATUS", "MOR_TELEFONE", "MOR_UNIDADE_ID" },
                values: new object[] { new Guid("5e71fa02-7271-49be-8c41-9cf04a8eb471"), "12345678901", new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3312), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3311), null, "morador@email.com", "Morador Exemplo", 2, "11999999999", new Guid("085671e6-cea0-4cbb-a2f2-5ac83b7cc4e3") });

            migrationBuilder.InsertData(
                table: "TB_ENTREGAS",
                columns: new[] { "ETG_ID", "ETG_DATA_ATUALIZACAO", "ETG_DATA_CRIACAO", "ETG_DATA_EXCLUSAO", "ETG_DATA_RECEBIMENTO", "ETG_DATA_RETIRADA", "ETG_DESCRICAO", "ETG_DESTINATARIO", "FUN_ID", "MOR_ID", "ETG_OBSERVACAO", "ETG_REMETENTE", "ETG_STATUS", "TRP_ID" },
                values: new object[] { new Guid("cbd10c3c-b8ac-4dbe-ab91-c0277716bc49"), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3364), new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3364), null, new DateTime(2023, 5, 6, 19, 25, 47, 112, DateTimeKind.Local).AddTicks(3366), null, "Descrição da entrega", "Destinatario Exemplo", new Guid("e0024df7-457a-44b7-bf34-929d65e1981e"), new Guid("5e71fa02-7271-49be-8c41-9cf04a8eb471"), "Observação da entrega", "Remetente Exemplo", 1, new Guid("2ede059b-6321-4ead-aef3-01040f1c36b5") });

            migrationBuilder.CreateIndex(
                name: "IX_CONDOMINIOS_CNPJ",
                table: "TB_CONDOMINIOS",
                column: "CND_CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONDOMINIOS_EMAIL",
                table: "TB_CONDOMINIOS",
                column: "CND_EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONDOMINIOS_NOME",
                table: "TB_CONDOMINIOS",
                column: "CND_NOME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_CEP",
                table: "TB_ENDERECOS",
                column: "END_CEP");

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_CONDOMINIO",
                table: "TB_ENDERECOS",
                column: "CON_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENTREGAS_FUN_ID",
                table: "TB_ENTREGAS",
                column: "FUN_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENTREGAS_MOR_ID",
                table: "TB_ENTREGAS",
                column: "MOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ENTREGAS_TRP_ID",
                table: "TB_ENTREGAS",
                column: "TRP_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_CPF",
                table: "TB_FUNCIONARIOS",
                column: "FUN_CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FUNCIONARIO_EMAIL",
                table: "TB_FUNCIONARIOS",
                column: "FUN_EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_FUNCIONARIOS_FUN_CONDOMINIO_ID",
                table: "TB_FUNCIONARIOS",
                column: "FUN_CONDOMINIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MORADORES_CPF",
                table: "TB_MORADORES",
                column: "MOR_CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MORADORES_EMAIL",
                table: "TB_MORADORES",
                column: "MOR_EMAIL",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MORADORES_UNIDADE_ID",
                table: "TB_MORADORES",
                column: "MOR_UNIDADE_ID");

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
                name: "IX_TRANSPORTADORAS_NOME",
                table: "TB_TRANSPORTADORAS",
                column: "TRA_NOME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TRANSPORTADORAS_TELEFONE",
                table: "TB_TRANSPORTADORAS",
                column: "TRA_TELEFONE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UNIDADES_CONDOMINIO_NUMERO_BLOCO",
                table: "TB_UNIDADES",
                columns: new[] { "CON_ID", "UND_NUMERO", "UND_BLOCO" },
                unique: true,
                filter: "[UND_BLOCO] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ENDERECOS");

            migrationBuilder.DropTable(
                name: "TB_ENTREGAS");

            migrationBuilder.DropTable(
                name: "TB_TRANSPORTADORAS");

            migrationBuilder.DropTable(
                name: "TB_FUNCIONARIOS");

            migrationBuilder.DropTable(
                name: "TB_MORADORES");

            migrationBuilder.DropTable(
                name: "TB_UNIDADES");

            migrationBuilder.DropTable(
                name: "TB_CONDOMINIOS");
        }
    }
}
