Create database Blog
go

use Blog
go

															--user - role 
															-- Um usu�rio pode ter muitos perfis e um perfil pode estar em muitos usu�rios
															-- O usuario pode ser administrador, autor, um estudando, um aluno ou at� os 3 ao mesmo tempo... 
															-- O autor de um post vai ser sempre um usu�rio

															--category e tags
															--uma postagem no blog pode ter uma categoria e muitas tags
															--uma Tag pode estar em muitas postagens

Create table [User](
	Id int not null identity(1,1),
	[Name] nvarchar(80) not null,
	Email nvarchar(200) not null,
	PasswordHash varchar(255) not null,
	Bio Text not null,
	[Image] varchar(2000) not null,
	Slug varchar(80) not null								-- Arthur-Emanuel

	constraint PK_User primary Key (Id),
	constraint UQ_User_Email Unique (Email),				--Definindo que o Email e o Slug s�o unicos na tabela
	constraint UQ_User_Slug Unique (Slug)
)															-- indices clusterizados significa que s�o criados em ordem. geralmentes as chaves prim�rias s�o criadas com clustered. Como s�o criado em ordem, fica mais f�cil, simples e r�pida para achar esses registros... Id 1, 2, 3, 4														
Create nonclustered index IX_User_Email on [User] (Email)	--Criando �ndice para o campo Email. Por padr�o os �ndices s�o criados por n�o clusterizados
Create nonclustered index IX_User_Slug on [User] (Slug)		-- �ndices n�o clusterizados, apontam diretamente para o Id, ficando assim muito mais r�pida a pesquisa do objeto pelo campo, que tem como Id um campo clusterizado que facilita achar esse registro no meio dos outros milh�es de arquivos na tabela.



Create table [Role](
	Id int not null identity(1,1),
	[Name] varchar(80) not null,
	Slug varchar(80) not null,

	constraint PK_Role primary key (Id),
	constraint UQ_Role_Slug UNIQUE (slug)					-- campo �nico
)

create nonclustered index IX_Role_Slug On [Role] (Slug)

															-- Como um User pode ter muitos perfis, e at� vparios ao mesmo tempo, e um perfil pode estar em muitos users, teremos ent�o que criar um relacionamento N para N
create table UserRole (
	UserId int not null,
	RoleId int not null

	constraint PK_UserRole primary key (UserId, RoleId)		-- Chave prim�ria composta.
)


create Table Category(
	Id int not null identity(1,1),
	[Name] varchar(80) not null,
	Slug varchar(80) not null,

	constraint PK_Category primary key (Id),
	constraint UQ_Category_Slug UNIQUE (slug)
)
create nonclustered index IX_Category_Slug On Category (Slug)


CREATE TABLE [Post] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [CategoryId] INT NOT NULL,								-- Um post s� tem uma categoria
    [AuthorId] INT NOT NULL,								-- Um post s� tem um author, um usu�rio
    [Title] VARCHAR(160) NOT NULL,
    [Summary] VARCHAR(255) NOT NULL,
    [Body] TEXT NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    [LastUpdateDate] DATETIME NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_Post] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Post_Category] FOREIGN KEY([CategoryId]) REFERENCES [Category]([Id]),
    CONSTRAINT [FK_Post_Author] FOREIGN KEY([AuthorId]) REFERENCES [User]([Id]),
    CONSTRAINT [UQ_Post_Slug] UNIQUE([Slug])				--S� pode haver um Post com mesmo Slug
)
CREATE NONCLUSTERED INDEX [IX_Post_Slug] ON [Post]([Slug])

CREATE TABLE [Tag] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] VARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Tag] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Tag_Slug] UNIQUE([Slug])					-- S� pode haver um post com a mesma Tag
)
CREATE NONCLUSTERED INDEX [IX_Tag_Slug] ON [Tag]([Slug])

CREATE TABLE [PostTag] (									--Rela��o de um Post com uma Tag. Relacionamento de N p N
    [PostId] INT NOT NULL,
    [TagId] INT NOT NULL,

    CONSTRAINT PK_PostTag PRIMARY KEY([PostId], [TagId])
)

INSERT INTO [User] ([Name], Email, PasswordHash, Bio, [Image], Slug)
VALUES 
    ('Usu�rio 1', 'usuario1@example.com', 'hash1', 'Biografia do Usu�rio 1', 'image1.jpg', 'usuario-1'),
    ('Usu�rio 2', 'usuario2@example.com', 'hash2', 'Biografia do Usu�rio 2', 'image2.jpg', 'usuario-2'),
    ('Usu�rio 3', 'usuario3@example.com', 'hash3', 'Biografia do Usu�rio 3', 'image3.jpg', 'usuario-3'),
    ('Usu�rio 4', 'usuario4@example.com', 'hash4', 'Biografia do Usu�rio 4', 'image4.jpg', 'usuario-4'),
    ('Usu�rio 5', 'usuario5@example.com', 'hash5', 'Biografia do Usu�rio 5', 'image5.jpg', 'usuario-5');

INSERT INTO [Role] ([Name], Slug)
VALUES
    ('Administrador', 'administrador'),
    ('Usu�rio', 'usuario'),
    ('Moderador', 'moderador'),
    ('Convidado', 'convidado'),
    ('Editor', 'editor');

INSERT INTO [Tag] ([Name], [Slug])
VALUES
    ('Tecnologia', 'tecnologia'),
    ('Esportes', 'esportes'),
    ('Entretenimento', 'entretenimento'),
    ('Moda', 'moda'),
    ('Viagens', 'viagens');

insert into UserRole
values	(1,1),
		(1,2),
		(1,3),
		(1,4),
		(1,5)