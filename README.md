# ClimaTempoSimples
Tecnologias utilizadas: .NET 4.6.1, .NET MVC 5.2.7. 
Para utilizar o projeto basta Fazer o dowload, abrir a sln no Visual Studio, adicionar sua string de conexao(ConnectionString) ao arquivo WebConfig em SUACONEXAO. 
Para criação e preenchimento da base de testes utilizar os scripts SQL disponibilizados na pasta SQL na ordem abaixo:

1 - Create Database.sql

2 - Create Table.Sql

3 - DadosClimaTempoSimples.SQL

Obs:. O Script facilitador.Sql serve para inserir e consultar dados na tabela Cidade

Obs:. Para inserir mais cidades no Dropdown basta alterar o campo @CID_IDS INT na linha 46 do script DadosClimaTempo