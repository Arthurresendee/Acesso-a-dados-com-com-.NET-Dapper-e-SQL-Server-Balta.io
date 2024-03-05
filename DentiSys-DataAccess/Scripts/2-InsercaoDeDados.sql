--------------------------------
-- -Endereco
INSERT INTO [Endereco] ([Id], [CEP], [Pais], [Estado], [Rua], [Numero])
VALUES
    ('1F25D9D7-C9DE-4F9A-8D59-5416D8DAAE13', '12345-678', 'Brazil', 'São Paulo', 'Rua A', '123'),
    ('326A2806-0F5F-4E05-9A1A-34C06C282F08', '23456-789', 'Brazil', 'Rio de Janeiro', 'Rua B', '456'),
    ('76848E37-5BB0-44DE-B8FD-82A80E3A2B0B', '34567-890', 'Brazil', 'Minas Gerais', 'Rua C', '789'),
    ('9ED37E44-24D2-4F2D-A21B-7D3A2D08FAC4', '45678-901', 'Brazil', 'Bahia', 'Rua D', '1011'),
    ('5C28E04B-9F6E-4B75-883F-47937E93D118', '56789-012', 'Brazil', 'Paraná', 'Rua E', '1213'),
    ('FE4037FC-692B-4A90-BB13-49B2B17F9E42', '67890-123', 'Brazil', 'Santa Catarina', 'Rua F', '1415'),
    ('7B5A3D89-625E-439F-AF3E-F29E0FF2C4CB', '78901-234', 'Brazil', 'Rio Grande do Sul', 'Rua G', '1617'),
    ('E296EF2B-7E7E-4E1B-B0DE-C84D0327C8AF', '89012-345', 'Brazil', 'Ceará', 'Rua H', '1819'),
    ('F8AF6B45-9B58-464A-B285-D11C60B0F39F', '90123-456', 'Brazil', 'Pernambuco', 'Rua I', '2021'),
    ('68A167BC-918A-48DC-8570-97FA7AAE49AC', '01234-567', 'Brazil', 'Amazonas', 'Rua J', '2223'),
    ('9AC71239-9E16-4655-AEF6-D4B41C46D6A8', '12345-678', 'Brazil', 'São Paulo', 'Rua K', '2425'),
    ('0E1E27C0-3F58-4DAB-A0F4-951E31857149', '23456-789', 'Brazil', 'Rio de Janeiro', 'Rua L', '2627'),
    ('D7484AB8-B62C-4F4F-BC57-F1CFEA3E5607', '34567-890', 'Brazil', 'Minas Gerais', 'Rua M', '2829'),
    ('8AF4D42C-4F81-4B88-B39F-32077D87BC5F', '45678-901', 'Brazil', 'Bahia', 'Rua N', '3031'),
    ('FAC28F10-7B38-4B80-810E-91C0A978AD81', '56789-012', 'Brazil', 'Paraná', 'Rua O', '3233');
----------------------------------
--Dentista

INSERT INTO [Dentista] ([Id], [Nome], [Sobrenome], [Idade], [CPF], [DataDeAniversario], [Email], [NumeroDeTelefone], [Especializacao], [NumeroDeRegistro], [IdEndereco])
VALUES
	('AE2F95A7-7A8C-4894-A41F-5FA5A684B1F5', 'João', 'Silva', 35, '12345678901', '15-05-1987', 'joao.silva@example.com', '(11) 98765-4321', 'Clínico Geral', 'CRM12345', '8AF4D42C-4F81-4B88-B39F-32077D87BC5F'),
    ('CB6A132B-65F3-4425-BC5A-B9E6EF5E33FD', 'Maria', 'Santos', 40, '98765432109', '20-10-1982', 'maria.santos@example.com', '(21) 12345-6789', 'Ortodontista', 'CRM54321', '326A2806-0F5F-4E05-9A1A-34C06C282F08'),
    ('ED22FA3C-2273-4742-8E18-5FF0841A5081', 'Pedro', 'Oliveira', 38, '45678901234', '12-08-1984', 'pedro.oliveira@example.com', '(31) 87654-3210', 'Periodontista', 'CRM67890', '5C28E04B-9F6E-4B75-883F-47937E93D118'),
    ('6B956C9A-9D12-446A-AAB0-4C7EDB628E37', 'Ana', 'Ferreira', 45, '23456789012', '25-03-1977', 'ana.ferreira@example.com', '(41) 54321-0987', 'Endodontista', 'CRM09876', 'FE4037FC-692B-4A90-BB13-49B2B17F9E42'),
    ('F97FAC98-63B3-4773-8D4C-106B318CA781', 'Carlos', 'Rodrigues', 42, '89012345678', '08-12-1980', 'carlos.rodrigues@example.com', '(51) 67890-1234', 'Cirurgião Bucomaxilofacial', 'CRM23456', '1F25D9D7-C9DE-4F9A-8D59-5416D8DAAE13'),
    ('A3E0CB6F-E965-4922-A50C-ABF44DA64E69', 'Fernanda', 'Lima', 33, '34567890123', '18-09-1989', 'fernanda.lima@example.com', '(61) 98765-4321', 'Odontopediatra', 'CRM34567', '9ED37E44-24D2-4F2D-A21B-7D3A2D08FAC4'),
    ('23FB0150-1B74-4A8F-8B2B-D3A20C4F31CB', 'Rafael', 'Martins', 36, '67890123456', '22-07-1986', 'rafael.martins@example.com', '(71) 12345-6789', 'Implantodontista', 'CRM45678', '76848E37-5BB0-44DE-B8FD-82A80E3A2B0B'),
    ('54EFABD2-5B2F-4B52-964B-B1941A3CF1A8', 'Juliana', 'Almeida', 39, '90123456789', '05-11-1983', 'juliana.almeida@example.com', '(81) 87654-3210', 'Ortopedista Funcional dos Maxilares', 'CRM56789', 'FAC28F10-7B38-4B80-810E-91C0A978AD81'),
    ('5E1A0D79-1EE3-4A9B-A870-C6BEB800791F', 'Bruno', 'Souza', 41, '12345678901', '14-02-1981', 'bruno.souza@example.com', '(91) 54321-0987', 'Dentística', 'CRM67890', '0E1E27C0-3F58-4DAB-A0F4-951E31857149'),
    ('0F8E6B45-5A9B-46AA-B285-D11C60B0F39F', 'Luana', 'Cavalcante', 36, '23456789012', '18-11-1986', 'luana.cavalcante@example.com', '(99) 87654-3210', 'Odontologia Estética', 'CRM78901', '68A167BC-918A-48DC-8570-97FA7AAE49AC'),
    ('F3F9EF2B-7F7E-4F1B-B0EE-C8CD0D27C8AF', 'Gustavo', 'Pereira', 38, '34567890123', '27-03-1984', 'gustavo.pereira@example.com', '(92) 76543-2109', 'Ortodontia', 'CRM89012', 'E296EF2B-7E7E-4E1B-B0DE-C84D0327C8AF'),
    ('C4D8AF6B-4B5E-464A-B285-D8CD0D27C8AF', 'Luciana', 'Rocha', 41, '45678901234', '09-07-1981', 'luciana.rocha@example.com', '(93) 65432-1098', 'Implantodontia', 'CRM90123', 'F8AF6B45-9B58-464A-B285-D11C60B0F39F');

----------------------------------
-- Paciente
INSERT INTO Paciente (Id, Nome, Sobrenome, Idade, CPF, DataDeAniversario, Email, NumeroDeTelefone, IdEndereco)
VALUES
    ('AE2F95A7-7A8C-4894-A41F-5FA5A684B1F5', 'João', 'Silva', 35, '12345678901', '15-05-1987', 'joao.silva@example.com', '(11) 98765-4321', '8AF4D42C-4F81-4B88-B39F-32077D87BC5F'),
    ('CB6A132B-65F3-4425-BC5A-B9E6EF5E33FD', 'Maria', 'Santos', 40, '98765432109', '20-10-1982', 'maria.santos@example.com', '(21) 12345-6789', '326A2806-0F5F-4E05-9A1A-34C06C282F08'),
    ('ED22FA3C-2273-4742-8E18-5FF0841A5081', 'Pedro', 'Oliveira', 38, '45678901234', '12-08-1984', 'pedro.oliveira@example.com', '(31) 87654-3210', '5C28E04B-9F6E-4B75-883F-47937E93D118'),
    ('6B956C9A-9D12-446A-AAB0-4C7EDB628E37', 'Ana', 'Ferreira', 45, '23456789012', '25-03-1977', 'ana.ferreira@example.com', '(41) 54321-0987', 'FE4037FC-692B-4A90-BB13-49B2B17F9E42'),
    ('F97FAC98-63B3-4773-8D4C-106B318CA781', 'Carlos', 'Rodrigues', 42, '89012345678', '08-12-1980', 'carlos.rodrigues@example.com', '(51) 67890-1234', '1F25D9D7-C9DE-4F9A-8D59-5416D8DAAE13'),
    ('A3E0CB6F-E965-4922-A50C-ABF44DA64E69', 'Fernanda', 'Lima', 33, '34567890123', '18-09-1989', 'fernanda.lima@example.com', '(61) 98765-4321', '9ED37E44-24D2-4F2D-A21B-7D3A2D08FAC4'),
    ('23FB0150-1B74-4A8F-8B2B-D3A20C4F31CB', 'Rafael', 'Martins', 36, '67890123456', '22-07-1986', 'rafael.martins@example.com', '(71) 12345-6789', '76848E37-5BB0-44DE-B8FD-82A80E3A2B0B'),
    ('54EFABD2-5B2F-4B52-964B-B1941A3CF1A8', 'Juliana', 'Almeida', 39, '90123456789', '05-11-1983', 'juliana.almeida@example.com', '(81) 87654-3210', 'FAC28F10-7B38-4B80-810E-91C0A978AD81'),
    ('5E1A0D79-1EE3-4A9B-A870-C6BEB800791F', 'Bruno', 'Souza', 41, '12345678901', '14-02-1981', 'bruno.souza@example.com', '(91) 54321-0987', '0E1E27C0-3F58-4DAB-A0F4-951E31857149'),
    ('0F8E6B45-5A9B-46AA-B285-D11C60B0F39F', 'Luana', 'Cavalcante', 36, '23456789012', '18-11-1986', 'luana.cavalcante@example.com', '(99) 87654-3210', '68A167BC-918A-48DC-8570-97FA7AAE49AC'),
    ('F3F9EF2B-7F7E-4F1B-B0EE-C8CD0D27C8AF', 'Gustavo', 'Pereira', 38, '34567890123', '27-03-1984', 'gustavo.pereira@example.com', '(92) 76543-2109', 'E296EF2B-7E7E-4E1B-B0DE-C84D0327C8AF'),
    ('C4D8AF6B-4B5E-464A-B285-D8CD0D27C8AF', 'Luciana', 'Rocha', 41, '45678901234', '09-07-1981', 'luciana.rocha@example.com', '(93) 65432-1098', 'F8AF6B45-9B58-464A-B285-D11C60B0F39F');


-----------------------------------
-- Procedimento
INSERT INTO [Procedimento] ([Id], [Titulo], [TipoDeProcedimento], [Descricao])
VALUES
    ('E1F2A3B4-C5D6-E7F8-A9B0-1C2D3E4F5A64', 'Clareamento dental', 5, 'Procedimento estético para clarear os dentes.'),
    ('5D6E7F8A-9B0C-1D2E-3F4A-5C6D7E8F9A05', 'Ortodontia', 6, 'Tratamento para correção de má oclusão e alinhamento dos dentes.'),
    ('1C2D3E4F-5A6B-7C8D-9E0F-1A2B3C4D5E66', 'Odontopediatria', 7, 'Atendimento odontológico especializado para crianças.'),
    ('8D9E0F1A-2B3C-4D5E-6F7A-8B9C0D1E2F37', 'Cirurgia de extração do siso', 8, 'Remoção dos dentes do siso impactados.'),
    ('6F7A8B9C-0D1E-2F3A-4B5C-6D7E8F9A0B18', 'Prótese dentária', 9, 'Reabilitação oral com próteses para substituir dentes ausentes.'),
    ('4B5C6D7E-8F9A-0B1C-2D3E-4F5A6B7C8D99', 'Periodontia', 0, 'Tratamento das estruturas de suporte dos dentes, como gengiva e osso alveolar.'),
    ('2D3E4F5A-6B7C-8D9E-0F1A-2B3C4D5E6F71', 'Endodontia', 1, 'Tratamento dos tecidos internos do dente, como a polpa.'),
    ('0F1A2B3C-4D5E-6F7A-8B9C-0D1E2F3A4B52', 'Odontologia estética', 2, 'Procedimentos para melhorar a estética do sorriso.'),
    ('8B9C0D1E-2F3A-4B5C-6D7E-8F9A0B1C2D33', 'Odontogeriatria', 3, 'Atendimento odontológico especializado para idosos.'),
    ('6D7E8F9A-0B1C-2D3E-4F5A-6B7C8D9E0F14', 'Odontologia preventiva', 4, 'Prevenção de doenças bucais e promoção da saúde oral.');


------------------------------------
-- Plano
INSERT INTO [Plano] ([Id], [Titulo], [TipoDePlano], [Descricao], [Coberturas], [DataInicial], [DataFinal])
VALUES
    ('5A4B3C2D-1E0F-9A8B-7C6D-5E4F3A2B1C0D', 'Plano Básico', 0, 'Plano básico de cobertura odontológica.', 'Consulta e limpeza', GETDATE(), DATEADD(YEAR, 1, GETDATE())),
    ('9B8C7D6E-5F4A-3B2C-1D0E-9F8A7B6C5D4E', 'Plano Intermediário', 1, 'Plano intermediário de cobertura odontológica.', 'Consulta, limpeza, restauração', GETDATE(), DATEADD(YEAR, 1, GETDATE())),
    ('3C2D1E0F-9A8B-7C6D-5E4F-3A2B1C0D9E8F', 'Plano Completo', 2, 'Plano completo de cobertura odontológica.', 'Consulta, limpeza, restauração, canal, prótese', GETDATE(), DATEADD(YEAR, 1, GETDATE())),
    ('7D6E5F4A-3B2C-1D0E-9F8A-7B6C5D4E3F2A', 'Plano Premium', 3, 'Plano premium de cobertura odontológica.', 'Consulta, limpeza, restauração, canal, implante, ortodontia', GETDATE(), DATEADD(YEAR, 1, GETDATE())),
    ('1E0F9A8B-7C6D-5E4F-3A2B-1C0D9E8F7A6B', 'Plano Familiar', 4, 'Plano de cobertura odontológica para toda a família.', 'Consulta, limpeza, restauração, canal, implante, ortodontia', GETDATE(), DATEADD(YEAR, 1, GETDATE()));

INSERT INTO PacientePlano (Id, IdPlano, IdPaciente, PlanoAtivo)
VALUES
    ('D3EFABDE-CA43-49D0-9824-EFC13504F18F', '1E0F9A8B-7C6D-5E4F-3A2B-1C0D9E8F7A6B', 'B2A83A96-4EDC-4E3B-BF1D-1C27CF90375F', 1),
    ('F1A0BC3D-4DE2-4A8C-9256-6FA1F7C28D79', '3C2D1E0F-9A8B-7C6D-5E4F-3A2B1C0D9E8F', '8F2E5FA9-981C-4AB8-A178-30CAB8C2B1D5', 1),
    ('9A8F6D2C-3E5B-47F1-8A64-FC9B13D0B5D2', '5A4B3C2D-1E0F-9A8B-7C6D-5E4F3A2B1C0D', '9F37E0B9-D1C3-4827-91A4-3EB1864C4C14', 1),
    ('B0E9C8D7-A1F6-4B3D-87E2-0CF9845B6A21', '7D6E5F4A-3B2C-1D0E-9F8A-7B6C5D4E3F2A', 'A6E6E14B-1E93-42E5-8645-49CDBAB08D17', 1),
    ('C5D4A3B2-7F69-4E81-BC20-9DECAF8D01E3', '9B8C7D6E-5F4A-3B2C-1D0E-9F8A7B6C5D4E', '90A46497-4E4F-44A3-8D2D-4C435711D125', 1);

INSERT INTO PacienteProcedimento (Id, IdPaciente, IdProcedimento, DataProcedimento, ProcedimentoRealizado)
VALUES
    ('8D3A7C2B-F1E6-4B9D-A0C5-EC3F6D5A821B', 'B2A83A96-4EDC-4E3B-BF1D-1C27CF90375F', '0F1A2B3C-4D5E-6F7A-8B9C-0D1E2F3A4B52', GETDATE(), 1),
    ('1F2E3D4C-5B6A-798C-D0E1-F2A3B4C5D6E7', '8F2E5FA9-981C-4AB8-A178-30CAB8C2B1D5', '1C2D3E4F-5A6B-7C8D-9E0F-1A2B3C4D5E66', GETDATE(), 1),
    ('9B8A7F6E-5D4C-3B2A-1F9E-8D7C6B5A4F34', '9F37E0B9-D1C3-4827-91A4-3EB1864C4C14', 'E1F2A3B4-C5D6-E7F8-A9B0-1C2D3E4F5A64', GETDATE(), 1),
    ('2E3D4C5B-A69B-8C7D-0E1F-2A3B4C5D6E7F', 'A6E6E14B-1E93-42E5-8645-49CDBAB08D17', '2D3E4F5A-6B7C-8D9E-0F1A-2B3C4D5E6F71', GETDATE(), 1),
    ('5A4B3C2D-7E8F-69A1-C5D0-E1F2A3B4C5D6', '90A46497-4E4F-44A3-8D2D-4C435711D125', '4B5C6D7E-8F9A-0B1C-2D3E-4F5A6B7C8D99', GETDATE(), 1);