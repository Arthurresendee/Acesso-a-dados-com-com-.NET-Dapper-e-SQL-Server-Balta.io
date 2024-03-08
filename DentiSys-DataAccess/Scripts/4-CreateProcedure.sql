create or alter Procedure [dbo].[spGetPacientes]
as
	begin
		select * from Paciente
		end
GO

create or alter Procedure [dbo].[spGetPacienteById]
(
	@id uniqueidentifier
)
as
	begin
		select * from Paciente where Id = @id
		end
GO