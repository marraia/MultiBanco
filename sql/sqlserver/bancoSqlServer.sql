CREATE DATABASE testeDB;

CREATE TABLE [dbo].[Station] (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Endereco] [varchar](50) NOT NULL,
	[Telefone] [varchar](50) NOT NULL
)