 create Table Procedimento
(
	Id uniqueidentifier,
	Titulo nvarchar(100) null,
	TipoDeProcedimento int null, -- de 0 a 9
	Descricao nvarchar(200) null,
	constraint pk_Procedimento primary key (Id)
)

Create Table Plano
(
	Id uniqueIdentifier,
	Titulo nvarchar(50) null,
	TipoDePlano int null, --De 0 a 5
	Descricao nvarchar(200) null,
	Coberturas nvarchar(200) null,
	DataInicial Datetime null,
	DataFinal DateTime null
	constraint pk_Plano primary key (Id)
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

Create Table Dentista
(
    Id UNIQUEIDENTIFIER,
	Nome nvarchar(100) null,
	Sobrenome nvarchar(100) null,
	Idade int null,
	CPF nvarchar(11) null,
	DataDeAniversario Datetime null,
	Email nvarchar(50) null,
	NumeroDeTelefone nvarchar(20) null,
    Especializacao NVARCHAR (200) null,
    NumeroDeRegistro NVARCHAR(50) null,
	IdEndereco uniqueidentifier not null,
    Constraint pk_Dentista primary key (Id),
	constraint fk_Dentista_Endereco foreign key (IdEndereco) references Endereco (Id)
)

Create Table Paciente
(
	Id uniqueIdentifier,
	Nome nvarchar(100) null,
	Sobrenome nvarchar(100) null,
	Idade int null,
	CPF nvarchar(11) null,
	DataDeAniversario Datetime null,
	Email nvarchar(50) null,
	NumeroDeTelefone nvarchar(20) null,
	IdEndereco uniqueidentifier not null,
	Constraint pk_Paciente primary key (Id),
	constraint fk_Paciente_Endereco foreign key (IdEndereco) references Endereco (Id)
)

create table [PacientePlano]
(
	Id UniqueIdentifier,
	IdPlano uniqueidentifier not null,
	IdPaciente uniqueidentifier not null,
	PlanoAtivo bit null,
	constraint pk_PacientePlano primary key (Id),
	constraint fk_PacientePlano_Plano foreign key (IdPlano) references Plano(id),
	constraint fk_PacientePlano_Paciente foreign key (IdPaciente) references Paciente (id)
)

Create Table PacienteProcedimento
(
	Id uniqueidentifier,
	IdPaciente uniqueidentifier not null,
	IdProcedimento uniqueidentifier not null,
	DataProcedimento DateTime null,
	ProcedimentoRealizado bit null,
	constraint pk_PacienteProcedimento primary key (Id),
	constraint fk_PacienteProcedimento_Paciente foreign key (IdPaciente) references Paciente (Id),
	constraint fk_PacienteProcedimento_Procedimento foreign key (IdProcedimento) references Procedimento (Id)
)

--EXEC sp_MSforeachtable 'DROP TABLE ?'

