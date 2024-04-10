Create database Blog
go

use Blog
go

															--user - role 
															-- Um usuário pode ter muitos perfis e um perfil pode estar em muitos usuários
															-- O usuario pode ser administrador, autor, um estudando, um aluno ou até os 3 ao mesmo tempo... 
															-- O autor de um post vai ser sempre um usuário

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
	constraint UQ_User_Email Unique (Email),				--Definindo que o Email e o Slug são unicos na tabela
	constraint UQ_User_Slug Unique (Slug)
)															-- indices clusterizados significa que são criados em ordem. geralmentes as chaves primárias são criadas com clustered. Como são criado em ordem, fica mais fácil, simples e rápida para achar esses registros... Id 1, 2, 3, 4														
Create nonclustered index IX_User_Email on [User] (Email)	--Criando índice para o campo Email. Por padrão os índices são criados por não clusterizados
Create nonclustered index IX_User_Slug on [User] (Slug)		-- índices não clusterizados, apontam diretamente para o Id, ficando assim muito mais rápida a pesquisa do objeto pelo campo, que tem como Id um campo clusterizado que facilita achar esse registro no meio dos outros milhões de arquivos na tabela.



Create table [Role](
	Id int not null identity(1,1),
	[Name] varchar(80) not null,
	Slug varchar(80) not null,

	constraint PK_Role primary key (Id),
	constraint UQ_Role_Slug UNIQUE (slug)					-- campo único
)

create nonclustered index IX_Role_Slug On [Role] (Slug)

															-- Como um User pode ter muitos perfis, e até vparios ao mesmo tempo, e um perfil pode estar em muitos users, teremos então que criar um relacionamento N para N
create table UserRole (
	UserId int not null,
	RoleId int not null

	constraint PK_UserRole primary key (UserId, RoleId)		-- Chave primária composta.
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
    [CategoryId] INT NOT NULL,								-- Um post só tem uma categoria
    [AuthorId] INT NOT NULL,								-- Um post só tem um author, um usuário
    [Title] VARCHAR(160) NOT NULL,
    [Summary] VARCHAR(255) NOT NULL,
    [Body] TEXT NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    [LastUpdateDate] DATETIME NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_Post] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Post_Category] FOREIGN KEY([CategoryId]) REFERENCES [Category]([Id]),
    CONSTRAINT [FK_Post_Author] FOREIGN KEY([AuthorId]) REFERENCES [User]([Id]),
    CONSTRAINT [UQ_Post_Slug] UNIQUE([Slug])				--Só pode haver um Post com mesmo Slug
)
CREATE NONCLUSTERED INDEX [IX_Post_Slug] ON [Post]([Slug])

CREATE TABLE [Tag] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] VARCHAR(80) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Tag] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_Tag_Slug] UNIQUE([Slug])					-- Só pode haver um post com a mesma Tag
)
CREATE NONCLUSTERED INDEX [IX_Tag_Slug] ON [Tag]([Slug])

CREATE TABLE [PostTag] (									--Relação de um Post com uma Tag. Relacionamento de N p N
    [PostId] INT NOT NULL,
    [TagId] INT NOT NULL,

    CONSTRAINT PK_PostTag PRIMARY KEY([PostId], [TagId])
)

INSERT INTO [User] ([Name], Email, PasswordHash, Bio, [Image], Slug)
VALUES 
    ('Usuário 1', 'usuario1@example.com', 'hash1', 'Biografia do Usuário 1', 'image1.jpg', 'usuario-1'),
    ('Usuário 2', 'usuario2@example.com', 'hash2', 'Biografia do Usuário 2', 'image2.jpg', 'usuario-2'),
    ('Usuário 3', 'usuario3@example.com', 'hash3', 'Biografia do Usuário 3', 'image3.jpg', 'usuario-3'),
    ('Usuário 4', 'usuario4@example.com', 'hash4', 'Biografia do Usuário 4', 'image4.jpg', 'usuario-4'),
    ('Usuário 5', 'usuario5@example.com', 'hash5', 'Biografia do Usuário 5', 'image5.jpg', 'usuario-5');

INSERT INTO [Role] ([Name], Slug)
VALUES
    ('Administrador', 'administrador'),
    ('Usuário', 'usuario'),
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