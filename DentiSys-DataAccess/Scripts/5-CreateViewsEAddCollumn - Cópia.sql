--Primeiramente Adicionando a coluna Cidade, não sei como esqueci rss

ALTER TABLE Endereco
ADD Cidade NVARCHAR(50) NULL;

--CREATE OR ALTER VIEW vwTodosOsPacientes AS
--SELECT 
--    * 
--FROM 
--    Paciente

--CREATE OR ALTER VIEW vwPacientesEEndereco AS
--SELECT 
--    Paciente.Id AS PacienteId,
--    Paciente.Nome AS NomePaciente,
--    Paciente.Idade,
--    Endereco.Id AS EnderecoId,
--    Endereco.Rua,
--	Endereco.Cidade,
--    Endereco.Estado
--FROM 
--    Paciente
--INNER JOIN 
--    Endereco ON Paciente.IdEndereco = Endereco.Id
--WHERE 
--    Paciente.CPF IS NOT NULL;
