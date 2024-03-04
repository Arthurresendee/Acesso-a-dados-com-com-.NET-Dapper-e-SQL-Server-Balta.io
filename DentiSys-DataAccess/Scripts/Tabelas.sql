create Database DentiSys

use Dentisys

Create Table Dentista
(
    id UNIQUEIDENTIFIER,
    Especializacao NVARCHAR (200) null,
    NumeroDeRegistro NVARCHAR(50) null,
    Constraint pk_Dentista primary key (Id)
)

CREATE TABLE [Endereco]
(
    Id UNIQUEIDENTIFIER,
    CEP NVARCHAR(50) NULL,
    Pais NVARCHAR(50) null,
    Estado NVARCHAR(50),
    Rua NVARCHAR(100) NULL,
    Numero NVARCHAR(50) NULL,
    CONSTRAINT pk_Endereco PRIMARY KEY (Id)
)

Create Table Paciente
(
	Id uniqueIdentifier,
	Constraint pk_Paciente primary key (Id)
)

create table [PacientePlano]
(
	Id UniqueIdentifier,
	IdPlano uniqueidentifier null,
	IdPaciente uniqueidentifier null,
	PlanoAtivo bit null,
	constraint pk_PacientePlano primary key (Id)
)

Create Table PacienteProcedimento
(
	Id uniqueidentifier,
	IdPaciente uniqueidentifier null,
	IdProcedimento uniqueidentifier null,
	DataProcedimento DateTime null,
	ProcedimentoRealizado bit not null
	constraint pk_PacienteProcedimento primary key (Id)
)

Create table [Pessoa]
(
    Id uniqueIdentifier,
	Nome nvarchar(100) null,
	Sobrenome nvarchar(100) null,
	Idade int null,
	CPF nvarchar(11) null,
	DataDeAniversario Datetime null,
	Email nvarchar(50) null,
	NumeroDeTelefone nvarchar(20) null,
	constraint pk_Pessoa primary key (Id)
)

Create Table Plano
(
	Id uniqueIdentifier,
	Titulo nvarchar(50) null,
	TipoDePlano int null,
	Descricao nvarchar(200) null,
	Coberturas nvarchar(200) null,
	DataInicial Datetime null,
	DataFinal DateTime null
	constraint pk_Plano primary key (Id)
)

create Table Procedimento
(
	Id uniqueidentifier,
	Titulo nvarchar(100) null,
	TipoDeProcedimento int null,
	Descricao nvarchar(200) null,
	constraint pk_Procedimento primary key (Id)
)

