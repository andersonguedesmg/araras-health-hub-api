USE [ararashealthhub]
GO

DECLARE @NOW DATETIME
SET @NOW = GETDATE()

INSERT INTO [dbo].[Employee]
            ([Name]
            ,[Cpf]
            ,[Function]
            ,[Phone]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
VALUES
            -- ('Name', 'Cpf', 'Function', 'Phone', 'CreatedOn', 'UpdatedOn', 'IsActive')
            ('Jed Bartlet', '292.593.758-60', 'Coordenador', '(19) 98564-1205', @NOW, NULL, 1),
            ('Matt Santos', '759.353.678-58', 'Coordenador', '(19) 98812-7589', @NOW, NULL, 1),
            ('Leo McGarry', '216.440.478-53', 'Auxiliar Administrativo', '(19) 97345-6402', @NOW, @NOW, 0),
            ('Donna Moss', '819.682.918-30', 'Farmacêutico', '(19) 99985-3021', @NOW, NULL, 1),
            ('Josh Lyman', '848.710.488-61', 'Enfermeiro', '(19) 99123-8527', @NOW, NULL, 1),
            ('C. J. Cregg', '975.614.608-72', 'Agente de Endemias', '(19) 98142-6349', @NOW, NULL, 1),
            ('Kate Harper', '942.440.518-99', 'Auxiliar Administrativo', '(19) 98257-8901', @NOW, NULL, 1),
            ('Toby Ziegler', '939.598.358-25','Auxiliar Administrativo', '(19) 99765-4203', @NOW, NULL, 1),
            ('Sam Seaborn', '497.785.508-67', 'Enfermeiro', '(19) 99123-5080', @NOW, NULL, 1),
            ('Charlie Young', '605.573.148-79', 'Agente de Endemias', '(19) 99475-5678', @NOW, NULL, 1),
            ('Will Bailey', '414.870.098-95', 'Auxiliar Administrativo', '(19) 98230-4462', @NOW, NULL, 1),
            ('Ainsley Hayes', '303.192.668-42', 'Enfermeiro', '(19) 98734-7605', @NOW, NULL, 1),
            ('Arnold Vinick', '301.777.668-91', 'Auxiliar Administrativo', '(19) 99658-3470', @NOW, NULL, 1),
            ('Chandler Bing', '753.951.258-96', 'Coordenador', '(19) 99564-7832', @NOW, @NOW, 0),
            ('Joey Tribbiani', '951.357.456-87', 'Auxiliar Administrativo', '(19) 99642-1198', @NOW, NULL, 1),
            ('Rachel Green', '321.654.987-00', 'Farmacêutico', '(19) 98451-2389', @NOW, NULL, 1),
            ('Monica Geller', '159.753.486-20', 'Enfermeiro', '(19) 98745-1023', @NOW, NULL, 1),
            ('Ross Geller', '987.654.321-00', 'Auxiliar Administrativo', '(19) 98123-7654', @NOW, NULL, 1),
            ('Phoebe Buffay', '852.741.963-11', 'Farmacêutico', '(19) 98325-4432', @NOW, NULL, 1),
            ('Gregory House', '741.852.963-32', 'Enfermeiro', '(19) 98976-2154', @NOW, NULL, 1),
            ('Lisa Cuddy', '963.258.741-66', 'Coordenador', '(19) 98712-6663', @NOW, NULL, 1),
            ('James Wilson', '321.987.654-99', 'Farmacêutico', '(19) 99112-9987', @NOW, NULL, 1),
            ('Eric Foreman', '654.123.987-22', 'Agente de Endemias', '(19) 98455-8790', @NOW, NULL, 1),
            ('Allison Cameron', '987.321.654-55', 'Enfermeiro', '(19) 98098-3212', @NOW, NULL, 1),
            ('Matt Albie', '951.159.357-00', 'Agente de Endemias', '(19) 98333-3030', @NOW, @NOW, 0),
            ('Danny Tripp', '753.456.159-11', 'Farmacêutico', '(19) 98484-8484', @NOW, NULL, 1),
            ('Jordan McDeere', '456.159.753-22', 'Coordenador', '(19) 98686-1212', @NOW, NULL, 1),
            ('Casey McCall', '123.456.789-00', 'Farmacêutico', '(19) 98181-8181', @NOW, NULL, 1),
            ('Dan Rydell', '321.123.456-11', 'Enfermeiro', '(19) 98282-8282', @NOW, NULL, 1),
            ('Dana Whitaker', '456.456.123-22', 'Auxiliar Administrativo', '(19) 98383-8383', @NOW, NULL, 1),
            ('Natalie Hurley', '789.789.123-33', 'Auxiliar Administrativo', '(19) 98484-8485', @NOW, NULL, 1),
            ('Jeremy Goodwin', '147.258.369-44', 'Enfermeiro', '(19) 98585-8586', @NOW, NULL, 1),
            ('Alan Shore', '249.732.810-00', 'Farmacêutico', '(19) 98401-1234', @NOW, NULL, 1),
            ('Denny Crane', '365.872.760-20', 'Coordenador', '(19) 98876-5543', @NOW, NULL, 1),
            ('Adrian Monk', '184.321.940-40', 'Agente de Endemias', '(19) 99811-2374', @NOW, NULL, 1),
            ('Michael Scofield', '182.295.910-90', 'Auxiliar Administrativo', '(19) 98560-4032', @NOW, NULL, 1),
            ('Tony Soprano', '103.640.250-60', 'Farmacêutico', '(19) 97987-1204', @NOW, @NOW, 0),
            ('Ally McBeal', '379.045.320-68', 'Auxiliar Administrativo', '(19) 98543-6578', @NOW, NULL, 1),
            ('Frank Underwood', '709.293.670-38', 'Auxiliar Administrativo', '(19) 98439-1052', @NOW, NULL, 1),
            ('Seth Cohen', '591.003.280-17', 'Enfermeiro', '(19) 99504-2371', @NOW, NULL, 1),
            ('Summer Roberts', '284.075.900-59', 'Enfermeiro', '(19) 99102-3470', @NOW, NULL, 1),
            ('Sandy Cohen', '673.102.550-06', 'Coordenador', '(19) 98332-7740', @NOW, NULL, 1),
            ('Will McAvoy', '654.729.330-62', 'Coordenador', '(19) 98323-4420', @NOW, NULL, 1),
            ('Sloan Sabbith', '310.768.200-61', 'Auxiliar Administrativo', '(19) 98244-3150', @NOW, NULL, 1),
            ('Don Keefer', '164.802.630-77', 'Enfermeiro', '(19) 98899-2340', @NOW, NULL, 1),
            ('Chuck Bartowski', '202.875.660-20', 'Enfermeiro', '(19) 99865-4477', @NOW, NULL, 1),
            ('Mark Greene', '712.987.100-01', 'Auxiliar Administrativo', '(19) 98123-4770', @NOW, NULL, 1),
            ('Doug Ross', '470.359.230-06', 'Enfermeiro', '(19) 98733-9087', @NOW, NULL, 1),
            ('John Carter', '116.842.600-20', 'Farmacêutico', '(19) 98123-4567', @NOW, NULL, 1),
            ('Abby Lockhart', '090.633.180-30', 'Agente de Endemias', '(19) 98045-6651', @NOW, NULL, 1),
            ('Peter Benton', '086.521.740-38', 'Enfermeiro', '(19) 98760-4392', @NOW, NULL, 1),
            ('Neela Rasgotra', '942.351.540-29', 'Coordenador', '(19) 98076-1194', @NOW, NULL, 1),
            ('Carol Hathaway', '253.170.670-43', 'Enfermeiro', '(19) 98895-2291', @NOW, NULL, 1),
            ('Luka Kovač', '059.143.700-98', 'Auxiliar Administrativo', '(19) 98328-1147', @NOW, NULL, 1),
            ('Dexter Morgan', '708.241.860-00', 'Enfermeiro', '(19) 99384-2911', @NOW, NULL, 1),
            ('Angel Batista', '541.709.740-90', 'Auxiliar Administrativo', '(19) 99527-1084', @NOW, NULL, 1),
            ('Jack Bauer', '068.295.370-60', 'Agente de Endemias', '(19) 99930-6871', @NOW, NULL, 1),
            ('David Palmer', '482.395.990-58', 'Coordenador', '(19) 98946-3045', @NOW, NULL, 1),
            ('Michelle Dessler', '786.193.860-77', 'Farmacêutico', '(19) 99653-2270', @NOW, NULL, 1),
            ('Chloe OBrian', '970.504.120-66', 'Auxiliar Administrativo', '(19) 99128-4009', @NOW, NULL, 1),
            ('Jake Peralta', '120.586.070-25', 'Auxiliar Administrativo', '(19) 99831-7192', @NOW, NULL, 1),
            ('Rosa Diaz', '627.813.340-04', 'Auxiliar Administrativo', '(19) 99475-3301', @NOW, NULL, 1),
            ('Terry Jeffords', '059.310.280-78', 'Auxiliar Administrativo', '(19) 98702-9186', @NOW, NULL, 1),
            ('Amy Santiago', '835.196.700-98', 'Enfermeiro', '(19) 99213-6644', @NOW, NULL, 1),
            ('Raymond Holt', '096.470.580-29', 'Coordenador', '(19) 99915-8720', @NOW, @NOW, 0),
            ('Richard Castle', '341.089.660-06', 'Farmacêutico', '(19) 99548-7299', @NOW, NULL, 1),
            ('Kate Beckett', '741.659.420-31', 'Auxiliar Administrativo', '(19) 98993-4108', @NOW, NULL, 1),
            ('Nick George', '246.800.730-08', 'Agente de Endemias', '(19) 99731-2665', @NOW, NULL, 1),
            ('Karen Darling', '194.730.550-74', 'Auxiliar Administrativo', '(19) 99297-1320', @NOW, NULL, 1),
            ('John Bates', '509.186.320-56', 'Farmacêutico', '(19) 99488-6057', @NOW, NULL, 1),
            ('Eric Taylor', '837.601.470-85', 'Coordenador', '(19) 98754-0032', @NOW, NULL, 1),
            ('Lorelai Gilmore', '398.207.610-44', 'Auxiliar Administrativo', '(19) 99076-3580', @NOW, NULL, 1),
            ('Rory Gilmore', '185.346.280-09', 'Agente de Endemias', '(19) 99805-7213', @NOW, NULL, 1),
            ('Luke Danes', '738.921.060-22', 'Coordenador', '(19) 99499-2841', @NOW, NULL, 1),
            ('Ted Mosby', '530.149.370-43', 'Enfermeiro', '(19) 99784-1155', @NOW, NULL, 1),
            ('Marshall Eriksen', '659.013.210-13', 'Auxiliar Administrativo', '(19) 99345-9687', @NOW, NULL, 1),
            ('Robin Scherbatsky', '874.126.490-65', 'Auxiliar Administrativo', '(19) 99166-2930', @NOW, NULL, 1),
            ('Barney Stinson', '702.435.830-00', 'Auxiliar Administrativo', '(19) 98743-7099', @NOW, NULL, 1),
            ('Lily Aldrin', '348.290.510-77', 'Farmacêutico', '(19) 99972-0844', @NOW, NULL, 1),
            ('Alexandra Eames', '692.184.200-30', 'Auxiliar Administrativo', '(19) 99618-0552', @NOW, NULL, 1),
            ('Robert Goren', '519.203.170-48', 'Coordenador', '(19) 99133-8476', @NOW, NULL, 1),
            ('Megan Wheeler', '246.850.940-93', 'Enfermeiro', '(19) 99023-6611', @NOW, NULL, 1),
            ('Harvey Specter', '439.165.980-03', 'Auxiliar Administrativo', '(19) 98712-4350', @NOW, NULL, 1),
            ('Donna Paulsen', '871.542.630-94', 'Farmacêutico', '(19) 98413-6572', @NOW, NULL, 1),
            ('Louis Litt', '036.285.810-87', 'Coordenador', '(19) 98642-3033', @NOW, NULL, 1),
            ('Jon Snow', '325.987.741-66', 'Enfermeiro', '(19) 98132-1100', @NOW, NULL, 1),
            ('Arya Stark', '741.852.963-88', 'Auxiliar Administrativo', '(19) 98101-2345', @NOW, NULL, 1),
            ('Daenerys Targaryen', '951.357.258-99', 'Coordenador', '(19) 98100-1234', @NOW, NULL, 1),
            ('Tyrion Lannister', '617.450.300-85', 'Agente de Endemias', '(19) 99601-8933', @NOW, NULL, 1),
            ('Lennie Briscoe', '607.219.860-49', 'Agente de Endemias', '(19) 99233-0090', @NOW, @NOW, 0),
            ('Ben Stone', '305.691.440-30', 'Enfermeiro', '(19) 99387-4456', @NOW, NULL, 1),
            ('Anita Van Buren', '220.374.830-58', 'Farmacêutico', '(19) 99012-6172', @NOW, NULL, 1),
            ('Jack McCoy', '188.967.230-36', 'Coordenador', '(19) 98490-7633', @NOW, NULL, 1);
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @NOW DATETIME
SET @NOW = GETDATE()

INSERT INTO [dbo].[Facility]
            ([Name]
            ,[Address]
            ,[Number]
            ,[Neighborhood]
            ,[City]
            ,[State]
            ,[Cep]
            ,[Email]
            ,[Phone]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
VALUES
            -- ('Name', 'Address', 'Number', 'Neighborhood', 'City', 'State', 'Cep', 'Email', 'Phone', 'CreatedOn', 'UpdatedOn', 'IsActive')
            ('Centro de Distribuição de Medicamentos Ricardo Francisco Vechin', 'Rua Brasília', '295', 'Centro', 'Araras', 'SP', '13600-710', 'sms@araras.sp.gov.br', '(19) 3544-4280', @NOW, NULL, 1),
            ('UBS Ênio Vitalli', 'Rua Franca', '99', 'Jd. Piratininga', 'Araras', 'SP', '13604-066', 'sms@araras.sp.gov.br', '(19) 3544-4280', @NOW, NULL, 1),
            ('UPA Elisa Sbrissa Franchozza', 'Av. Irineu Carrocci', '400', 'José Ometto II', 'Araras', 'SP', '13606-414', 'sms@araras.sp.gov.br', '(19) 3543-5100', @NOW, NULL, 1),
            ('Farmácia de Alto Custo', 'Rua Brasília', '295', 'Centro', 'Araras', 'SP', '13600-710', 'sms@araras.sp.gov.br', '(19) 3551-1096', @NOW, NULL, 1),
            ('SAMU Regional de Araras', 'Avenida Dona Renata', '4585', 'Centro', 'Araras', 'SP', '13600-001', 'samu@araras.sp.gov.br', '(19) 3541-6819', @NOW, NULL, 1),
            ('PSF Edmundo Ulson', 'Rua Ângelo Francato', '393', 'Parque Tiradentes', 'Araras', 'SP', '13606-652', 'sms@araras.sp.gov.br', '(19) 3544-5232', @NOW, NULL, 1),
            ('PSF Nilton De Lollo', 'Rua Catanduva', '253', 'Jd. São João', 'Araras', 'SP', '13604-044', 'sms@araras.sp.gov.br', '(19) 3544-7302', @NOW, NULL, 1),
            ('PSF Jair Mourão', 'Rua do Estudante', '110', 'Jardim José Ometto I', 'Araras', 'SP', '13606-314', 'sms@araras.sp.gov.br', '(19) 3544-7754', @NOW, NULL, 1),
            ('UBS José Fiori', 'Rua Ana da Silva', 's/nº', 'Jardim Nova Suissa', 'Araras', 'SP', '13607-088', 'sms@araras.sp.gov.br', '(19) 3542-9308', @NOW, NULL, 1),
            ('CAEM Dr. Nelson Salomé', 'Rua Nelson Ferreira', 's/nº', 'Jardim José Ometto II', 'Araras', 'SP', '13606-390', 'sms@araras.sp.gov.br', '(19) 3542-7602', @NOW, NULL, 1),
            ('Ambulatório de Saúde Mental Agnaldo Bianchini', 'Avenida Loreto', '1291', 'Jardim das Flores', 'Araras', 'SP', '13607-200', 'sms@araras.sp.gov.br', '(19) 3544-2674', @NOW, NULL, 1),
            ('CAPS-AD', 'Avenida Washington Luiz', '545', 'Centro', 'Araras', 'SP', '13600-720', 'sms@araras.sp.gov.br', '(19) 3542-4137', @NOW, NULL, 1),
            ('Centro de Controle de Zoonoses', 'Estrada Municipal Luiz Segundo DAlessandri', 's/nº', 'Conjunto Residencial Prefeito Professor Jair Della Colleta', 'Araras', 'SP', '13606-852', 'sms@araras.sp.gov.br', '(19) 3544-4413', @NOW, NULL, 1),
            ('UBS São João', 'Rua São João', 's/nº', 'Jardim São João', 'Araras', 'SP', '13606-300', 'sms@araras.sp.gov.br', '(19) 3544-7887', @NOW, NULL, 1),
            ('PSF José Ometto', 'Rua Irmã Ignácia', '200', 'Jardim José Ometto', 'Araras', 'SP', '13607-250', 'sms@araras.sp.gov.br', '(19) 3544-7845', @NOW, NULL, 1),
            ('UBS Vila Poloni', 'Rua Américo Vespe', '123', 'Vila Poloni', 'Araras', 'SP', '13605-520', 'sms@araras.sp.gov.br', '(19) 3544-7465', @NOW, NULL, 1),
            ('PSF Parque Tiradentes', 'Rua Antônio Freire', '400', 'Parque Tiradentes', 'Araras', 'SP', '13606-700', 'sms@araras.sp.gov.br', '(19) 3544-6224', @NOW, NULL, 1),
            ('UBS Vila Santana', 'Rua Santo Antônio', '110', 'Vila Santana', 'Araras', 'SP', '13606-800', 'sms@araras.sp.gov.br', '(19) 3544-5999', @NOW, NULL, 1),
            ('CAPS II', 'Rua Marinalva Mendes', '50', 'Jardim das Palmeiras', 'Araras', 'SP', '13607-400', 'sms@araras.sp.gov.br', '(19) 3544-5376', @NOW, NULL, 1),
            ('PSF Rural São Benedito', 'Estrada São Benedito', 's/nº', 'Zona Rural', 'Araras', 'SP', '13606-900', 'sms@araras.sp.gov.br', '(19) 3544-9080', @NOW, NULL, 1),
            ('PSF Rural Guaporé', 'Estrada Guaporé', 's/nº', 'Zona Rural', 'Araras', 'SP', '13607-450', 'sms@araras.sp.gov.br', '(19) 3544-9120', @NOW, NULL, 1),
            ('UBS Santa Rita', 'Rua Santa Rita', '100', 'Santa Rita', 'Araras', 'SP', '13607-500', 'sms@araras.sp.gov.br', '(19) 3544-9280', @NOW, NULL, 1),
            ('UBS Estância São João', 'Rua Estância São João', '250', 'Estância São João', 'Araras', 'SP', '13606-950', 'sms@araras.sp.gov.br', '(19) 3544-9500', @NOW, NULL, 1),
            ('PSF Rural São José', 'Estrada São José', 's/nº', 'Zona Rural', 'Araras', 'SP', '13607-550', 'sms@araras.sp.gov.br', '(19) 3544-9620', @NOW, NULL, 1),
            ('UBS Jardim Eldorado', 'Rua Eldorado', '350', 'Jardim Eldorado', 'Araras', 'SP', '13608-000', 'sms@araras.sp.gov.br', '(19) 3544-9730', @NOW, NULL, 1),
            ('Ambulatório de Pronto Atendimento Dr. Solon F. de Oliveira', 'Rua Dos Girassois', 's/nº', 'Jd Sobradinho', 'Araras', 'SP', '13602-006', 'sms@araras.sp.gov.br', '(19) 3544-5630', @NOW, @NOW, 0),
            ('Vigilância Sanitária de Araras', 'Rua Campos Sales', '33', 'Jardim Belvedere', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3543-1522', @NOW, NULL, 1),
            ('Unidade Movel Odontológica', 'Rua Campos Sales', '33', 'Jardim Belvedere', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3543-1522', @NOW, NULL, 1),
            ('Unidade de Vigilância Epidemiológica', 'Rua Campos Sales', '33', 'Jardim Belvedere', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3541-7037', @NOW, NULL, 1),
            ('UBS Osvaldo Salvador Devitte', 'Avenida Presidente Castelo Branco', '27', 'Conjunto Habitacional Narciso Gomes', 'Araras', 'SP', '13601-440', 'sms@araras.sp.gov.br', '(19) 3544-4974', @NOW, NULL, 1),
            ('UBS Dr. Humberto Rodrigues Junior', 'Avenida Melvin Jones', 's/nº', 'Jd Tangara', 'Araras', 'SP', '13607-005', 'sms@araras.sp.gov.br', '(19) 3544-6939', @NOW, NULL, 1),
            ('UBS Dr. Emerson Mercatelli', 'Rua Anibal Lopes Da Silva', '190', 'Residencial Bosque de Versalles', 'Araras', 'SP', '13609-384', 'sms@araras.sp.gov.br', '(19) 3547-9609', @NOW, NULL, 1),
            ('UBS Dr. Antônio Simoes Pontes', 'Avenida João Rossi', 's/nº', 'Jardim Aeroporto', 'Araras', 'SP', '13605-300', 'sms@araras.sp.gov.br', '(19) 3547-3195', @NOW, @NOW, 0),
            ('UBS Antônio Carlos Fabricio', 'Rua Do Carpinteiro', 's/nº', 'Jardim José Ometto I', 'Araras', 'SP', '13606-320', 'sms@araras.sp.gov.br', '(19) 3544-3569', @NOW, NULL, 1),
            ('UBS Alberto Franzini', 'Rua Cassio Gonzaga', 's/nº', 'Jd Morumbi', 'Araras', 'SP', '13606-508', 'sms@araras.sp.gov.br', '(19) 3541-8016', @NOW, NULL, 1),
            ('Pró Saúde Hospital Geral', 'Avenida Augusta Viola Da Costa', '805', 'Loreto', 'Araras', 'SP', '13606-020', 'sms@araras.sp.gov.br', '(19) 3321-1260', @NOW, NULL, 1),
            ('PS Dr. Alcides Franco de Oliveira', 'Rua Lourenco Batistela', '514', 'Jardim José Ometto I', 'Araras', 'SP', '13606-326', 'sms@araras.sp.gov.br', '(19) 3541-7211', @NOW, @NOW, 0),
            ('SAE/CTA Enfermeira Adalgisa dos Santos Gonçalves', 'Rua Francisco Paulo Russo', '119', 'Centro', 'Araras', 'SP', '13600-559', 'sms@araras.sp.gov.br', '(19) 3544-2064', @NOW, NULL, 1),
            ('Posto de Atendimento Médico Eva Almeida Costa Cruz', 'Avenida Presidente Cafe Filho', '209', 'Narciso Gomes', 'Araras', 'SP', '13601-430', 'sms@araras.sp.gov.br', '(19) 3541-7898', @NOW, @NOW, 0),
            ('Medicina Diagnóstica Castro Soares', 'Rua Brasilia', '123', 'Centro', 'Araras', 'SP', '13600-710', 'sms@araras.sp.gov.br', '(19) 3541-4211', @NOW, NULL, 1),
            ('LabVitta Laboratório de Análises Clínicas', 'Rua Coronel Andre Ulson Junior', '244', 'Centro', 'Araras', 'SP', '13600-690', 'sms@araras.sp.gov.br', '(19) 3543-5400', @NOW, NULL, 1),
            ('ESF Vital Pacífico Homem', 'Rua Irineu Carroci', '1469', 'Jardim José Ometto IV', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3544-5411', @NOW, NULL, 1),
            ('ESF Zona Rural', 'Sitio Morro Grande', 's/nº', 'Zona Rural', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3543-1522', @NOW, NULL, 1),
            ('Hospital de Campanha Covid 19', 'Rua Nelson Ferreira', 's/nº', 'Jardim José Ometto II', 'Araras', 'SP', '13606-414', 'sms@araras.sp.gov.br', '(19) 3543-1522', @NOW, @NOW, 0),
            ('Hospital São Leopoldo Mandic', 'Av Padre Alarico Zacharias', '1253', 'Belvedere', 'Araras', 'SP', '13601-200', 'sms@araras.sp.gov.br', '(19) 3543-3211', @NOW, NULL, 1),
            ('Hospital Irmandade da Santa Casa de Misericórdia de Araras', 'Praca Dr. Narcizo Gomes', '49', 'Centro', 'Araras', 'SP', '13600-695', 'sms@araras.sp.gov.br', '(19) 3543-5400', @NOW, NULL, 1),
            ('ESF Dr. Orlando Zaniboni', 'Rua Francisco Cressoni', '158', 'Parque Tiradentes', 'Araras', 'SP', '13606-643', 'sms@araras.sp.gov.br', '(19) 3541-7791', @NOW, NULL, 1),
            ('ESF Dr. Sebastião Jair Mourão', 'Rua Do Estudante', '110', 'Jardim José Ometto I', 'Araras', 'SP', '13606-314', 'sms@araras.sp.gov.br', '(19) 3544-7754', @NOW, @NOW, 0),
            ('ESF Francisco Nicola Cascelli', 'Rua Melania Baraldi Marostica', '550', 'Parque Das Arvores', 'Araras', 'SP', '13604-172', 'sms@araras.sp.gov.br', '(19) 3544-5424', @NOW, NULL, 1),
            ('ESF Jeronymo Ometto', 'Rua Ciro Lagazzi', '285', 'Jardim Candida', 'Araras', 'SP', '13603-027', 'sms@araras.sp.gov.br', '(19) 3541-9490', @NOW, NULL, 1),
            ('ESF Lucia Boquette Meneghetti', 'Rua Allan Kardec', 's/nº', 'Vila Dona Rosa Zurit', 'Araras', 'SP', '13601-361', 'sms@araras.sp.gov.br', '(19) 3544-7533', @NOW, NULL, 1),
            ('ESF Madre Carla Rabolin', 'Rua Carlindo Fernandes', 's/nº', 'Jardim Alvorada', 'Araras', 'SP', '13604-312', 'sms@araras.sp.gov.br', '(19) 3551-3563', @NOW, NULL, 1),
            ('ESF Narciso Gomes II', 'Avenida Presidente Cafe Filho', '209', 'Narciso Gomes', 'Araras', 'SP', '13601-430', 'sms@araras.sp.gov.br', '(19) 3541-7898', @NOW, NULL, 1),
            ('ESF Ophelia Geraci Pesse', 'Avenida Professor Dircon Kammer', '880', 'Jardim Alto Da Colin', 'Araras', 'SP', '13604-472', 'sms@araras.sp.gov.br', '(19) 3542-4137', @NOW, NULL, 1),
            ('ESF Otavio João Breda', 'Rua João Puppi', '15', 'Parque Dom Pedro', 'Araras', 'SP', '13606-839', 'sms@araras.sp.gov.br', '(19) 3541-7593', @NOW, NULL, 1),
            ('ESF Dr. Fermin Blanco Vianna', 'Rua Dalton Bird de Camargo Preto', '42', 'Jardim José Ometto II', 'Araras', 'SP', '13606-350', 'sms@araras.sp.gov.br', '(19) 3544-8559', @NOW, NULL, 1),
            ('ESF Dr. Bento Feres', 'Rua Julia Luiz Ruette', '245', 'Jardim Ouro Verde II', 'Araras', 'SP', '13607-507', 'sms@araras.sp.gov.br', '(19) 3542-5453', @NOW, NULL, 1),
            ('ESF Antônio Simoes Pontes', 'Avenida João Rossi', 's/nº', 'Jardim Aeroporto', 'Araras', 'SP', '13605-300', 'sms@araras.sp.gov.br', '(19) 3547-3195', @NOW, NULL, 1),
            ('Consultorio na Rua', 'Rua Campos Sales', '33', 'Jardim Belvedere', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3543-1522', @NOW, NULL, 1),
            ('Centro Odontologico Dr. Solon de Oliveira Fernandes', 'Avenida Lourenco Batistella', '514', 'Jardim José Ometto I', 'Araras', 'SP', '13606-326', 'sms@araras.sp.gov.br', '(19) 3541-7211', @NOW, @NOW, 0),
            ('Centro Médico Social Comunitário Irma Maria Diva Patarra', 'Avenida Padre Alarico Zacharias', '300', 'Jardim Belvedere', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3543-3088', @NOW, @NOW, 0),
            ('Centro Infantil Dr. Hercio Marcos Cintra Arantes', 'Avenida Washington Luiz', '545', 'Vila Michelin', 'Araras', 'SP', '13601-001', 'sms@araras.sp.gov.br', '(19) 3542-9909', @NOW, NULL, 1),
            ('Centro de Saúde Dra Rosa Chelminsk Teixeira', 'Avenida Governador Garcez', '137', 'Jardim Belvedere', 'Araras', 'SP', '13601-140', 'sms@araras.sp.gov.br', '(19) 3542-6164', @NOW, NULL, 1),
            ('Centro de Saúde Da Mulher Jandira A Leite Duarte', 'Rua Dos Anturios', '30', 'Jardim Sobradinho', 'Araras', 'SP', '13602-005', 'sms@araras.sp.gov.br', '(19) 3551-5440', @NOW, NULL, 1),
            ('Centro de Imagem Radiológica', 'Av Governador Garcez', 's/nº', 'Jardim Belvedere', 'Araras', 'SP', '13601-140', 'sms@araras.sp.gov.br', '(19) 3543-3055', @NOW, @NOW, 0),
            ('CDI Syrius', 'Praca Doutor Narciso Gomes', '49', 'Centro', 'Araras', 'SP', '13600-695', 'sms@araras.sp.gov.br', '(19) 3805-3737', @NOW, @NOW, 0),
            ('CAPS IJ Infanto Juvenil', 'Rua Carlindo Pereira Da Costa', 's/nº', 'Vila Michelin', 'Araras', 'SP', '13601-008', 'sms@araras.sp.gov.br', '(19) 3551-0277', @NOW, NULL, 1),
            ('CAPS II Idalina Corredor Victorello', 'Avenida Loreto', '1291', 'Jardim Das Flores', 'Araras', 'SP', '13607-200', 'sms@araras.sp.gov.br', '(19) 3544-5874', @NOW, NULL, 1),
            ('CAPS AD Arceu Scanavini', 'Doutor Fabio Fachini', '1011', 'Vila Candinha', 'Araras', 'SP', '13605-060', 'sms@araras.sp.gov.br', '(19) 3542-0905', @NOW, NULL, 1),
            ('APAE de Araras Sitio Arco Iris', 'Rodovia Wilson Finardi', 's/nº', 'Zona Rural', 'Araras', 'SP', '13609-300', 'sms@araras.sp.gov.br', '(19) 3541-3133', @NOW, NULL, 1),
            ('Centro de Distribuicao de Imunobiológicos de Araras', 'Rua Campos Sales', '33', 'Jardim Belvedere', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3543-1522', @NOW, NULL, 1),
            ('CDB Araras Centro de Diagnósticos Brasil', 'Rua Hercilia Dal Pietro', '555', 'Jardim Das Flores', 'Araras', 'SP', '13607-220', 'sms@araras.sp.gov.br', '(19) 3543-4600', @NOW, NULL, 1);
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @NOW DATETIME
SET @NOW = GETDATE()

INSERT INTO [dbo].[Supplier]
            ([Name]
            ,[Cnpj]
            ,[Address]
            ,[Number]
            ,[Neighborhood]
            ,[City]
            ,[State]
            ,[Cep]
            ,[Email]
            ,[Phone]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
VALUES
            -- ('Name', 'Cnpj', 'Address', 'Number', 'Neighborhood', 'City', 'State', 'Cep', 'Email', 'Phone', 'CreatedOn', 'UpdatedOn', 'IsActive')
            ('Grupo Martins', '01.407.377/0001-62', 'Avenida Pedro Álvarez Cabral', '3000', 'Vila Maria', 'São Paulo', 'SP', '02048-000', 'contato@martins.com.br', '(11) 2221-2222', @NOW, NULL, 1),
            ('Droga Raia', '44.177.977/0001-83', 'Avenida São João', '1500', 'Centro', 'São Paulo', 'SP', '01030-001', 'sac@droga-raia.com.br', '(11) 3333-7777', @NOW, NULL, 1),
            ('Farmais Distribuidora', '11.582.072/0001-12', 'Avenida Maria Conceição', '1050', 'Jardim da Saúde', 'São Paulo', 'SP', '04152-040', 'comercial@farmais.com.br', '(11) 5075-9911', @NOW, NULL, 1),
            ('Ultrafarma', '06.862.412/0001-23', 'Rua dos Três Irmãos', '122', 'Vila Progredior', 'São Paulo', 'SP', '02751-000', 'atendimento@ultrafarma.com.br', '(11) 4003-4116', @NOW, NULL, 1),
            ('AstraZeneca Brasil', '60.582.059/0001-70', 'Avenida Pasteur', '500', 'Jardim Botânico', 'São Paulo', 'SP', '01000-000', 'contato@astrazeneca.com', '(11) 3463-5000', @NOW, NULL, 1),
            ('Biolab Sanus', '59.471.376/0001-39', 'Avenida Francisco Matarazzo', '1510', 'Lapa', 'São Paulo', 'SP', '05001-200', 'atendimento@biolab.com.br', '(11) 3616-0800', @NOW, NULL, 1),
            ('Laboratório Aché', '60.115.279/0001-18', 'Avenida do Estado', '500', 'Belenzinho', 'São Paulo', 'SP', '03082-000', 'atendimento@ache.com.br', '(11) 3278-1000', @NOW, NULL, 1),
            ('Marjan Farma', '59.514.229/0001-50', 'Rua Morato Coelho', '1215', 'Vila Progredior', 'São Paulo', 'SP', '05422-100', 'marjan@marjan.com.br', '(11) 3078-3122', @NOW, @NOW, 0),
            ('Laboratório São Paulo', '60.159.618/0001-90', 'Avenida Celso Garcia', '2289', 'Belenzinho', 'São Paulo', 'SP', '03071-000', 'atendimento@labsp.com.br', '(11) 2295-7000', @NOW, NULL, 1),
            ('Medquímica', '60.259.512/0001-99', 'Rua Barão de Itapetininga', '102', 'Centro', 'São Paulo', 'SP', '01042-000', 'atendimento@medquimica.com.br', '(11) 3241-1234', @NOW, NULL, 1),
            ('Laboratório Valeant', '60.610.038/0001-88', 'Rua do Forte', '102', 'Centro', 'São Paulo', 'SP', '02058-000', 'atendimento@valeant.com.br', '(11) 3178-4000', @NOW, @NOW, 0),
            ('Laboratório Daudt', '60.215.498/0001-32', 'Rua dos Três Irmãos', '112', 'Vila Progredior', 'São Paulo', 'SP', '02751-000', 'sac@daudt.com.br', '(11) 3356-1234', @NOW, NULL, 1),
            ('Lavoisier', '60.689.447/0001-77', 'Rua Mário Lopes Leão', '400', 'Bela Vista', 'São Paulo', 'SP', '01050-000', 'atendimento@lavoisier.com.br', '(11) 3325-3345', @NOW, NULL, 1),
            ('Cia. Muller', '60.707.188/0001-19', 'Rua da Consolação', '1200', 'Bela Vista', 'São Paulo', 'SP', '01050-100', 'contato@ciamuller.com.br', '(11) 3256-9876', @NOW, NULL, 1),
            ('Fresenius Kabi', '60.826.588/0001-72', 'Rua dos Três Irmãos', '560', 'Vila Progredior', 'São Paulo', 'SP', '02751-000', 'sac@fresenius-kabi.com.br', '(11) 3341-4444', @NOW, NULL, 1),
            ('Med Farma', '60.285.337/0001-80', 'Rua Santa Cruz', '342', 'Vila Santa Clara', 'São Paulo', 'SP', '04112-210', 'contato@medfarma.com.br', '(11) 5512-7823', @NOW, NULL, 1),
            ('Laboratório Apsen', '60.535.417/0001-80', 'Rua do Ouvidor', '56', 'Centro', 'São Paulo', 'SP', '20010-000', 'apsen@apsen.com.br', '(11) 3103-9000', @NOW, NULL, 1),
            ('Eurofarma Laboratórios S.A.', '62.579.262/0001-70', 'Rua Conceição', '1372', 'Vila Olímpia', 'São Paulo', 'SP', '04503-000', 'contato@eurofarma.com.br', '(11) 3848-5000', @NOW, NULL, 1),
            ('EMS S.A.', '61.442.807/0001-09', 'Rua Silva Jardim', '240', 'Jardim São Francisco', 'Hortolândia', 'SP', '13186-070', 'sac@ems.com.br', '(19) 3866-2000', @NOW, NULL, 1),
            ('Blau Farmacêutica Ltda.', '02.438.344/0001-40', 'Av. Juscelino Kubitschek', '2041', 'Vila Olímpia', 'São Paulo', 'SP', '04543-011', 'contato@blaufarma.com.br', '(11) 3842-7800', @NOW, NULL, 1),
            ('Cristália Produtos Químicos Farmacêuticos Ltda.', '47.283.136/0001-20', 'Av. Eugênio de Medeiros', '1205', 'Pinheiros', 'São Paulo', 'SP', '05413-002', 'contato@cristalia.com.br', '(11) 3083-2000', @NOW, NULL, 1),
            ('Libbs Farmacêutica Ltda.', '61.582.226/0001-60', 'Av. das Nações Unidas', '14401', 'Vila Gertrudes', 'São Paulo', 'SP', '04794-000', 'sac@libbs.com.br', '(11) 3768-8000', @NOW, NULL, 1),
            ('União Química Farmacêutica Nacional S.A.', '61.104.342/0001-40', 'Rua do Rocio', '2400', 'Vila Olímpia', 'São Paulo', 'SP', '04552-000', 'contato@uniaofarmaceutica.com.br', '(11) 3046-3300', @NOW, NULL, 1),
            ('Hypera Pharma S.A.', '16.438.820/0001-97', 'Av. Dona Helena Pereira de Moraes', '251', 'São Cristóvão', 'Amparo', 'SP', '13903-080', 'sac@hypera.com.br', '(19) 3805-5000', @NOW, NULL, 1),
            ('Bayer S.A.', '57.418.315/0001-14', 'Rua Fidêncio Ramos', '302', 'Vila Olímpia', 'São Paulo', 'SP', '04551-010', 'contato@bayer.com.br', '(11) 3167-7000', @NOW, NULL, 1),
            ('Pfizer Brasil Ltda.', '33.202.663/0001-07', 'Av. Dr. Chucri Zaidan', '920', 'Vila Cordeiro', 'São Paulo', 'SP', '04583-905', 'sac.brasil@pfizer.com', '(11) 2127-7000', @NOW, NULL, 1),
            ('Novartis Biociências S.A.', '45.761.663/0001-60', 'Rua José Loureiro', '209', 'Vila Nova Conceição', 'São Paulo', 'SP', '04503-020', 'contato@novartis.com.br', '(11) 3046-5700', @NOW, NULL, 1),
            ('Sanofi-Aventis Farmacêutica Ltda.', '45.162.252/0001-87', 'Av. das Nações Unidas', '22711', 'Jurubatuba', 'São Paulo', 'SP', '04795-100', 'contato@sanofi.com.br', '(11) 3744-6100', @NOW, NULL, 1),
            ('GSK Brasil Ltda.', '33.061.579/0001-64', 'Rua Olimpíadas', '266', 'Vila Olímpia', 'São Paulo', 'SP', '04551-000', 'contato@gsk.com.br', '(11) 3094-3400', @NOW, NULL, 1),
            ('Medley Indústria Farmacêutica Ltda.', '33.557.704/0001-09', 'Rua Humberto de Campos', '400', 'Parque São Jorge', 'São Paulo', 'SP', '03071-000', 'sac@medley.com.br', '(11) 2659-4000', @NOW, NULL, 1),
            ('Multilab Indústria Farmacêutica Ltda.', '57.232.247/0001-83', 'Rua São Jorge', '125', 'Jardim São Jorge', 'São Paulo', 'SP', '03330-000', 'contato@multilab.com.br', '(11) 2688-3000', @NOW, @NOW, 0),
            ('Medquimheo Produtos Farmacêuticos Ltda.', '62.511.173/0001-04', 'Av. Rotary', '550', 'Parque Industrial', 'Sumaré', 'SP', '13174-000', 'sac@medquimheo.com.br', '(19) 3454-4600', @NOW, NULL, 1),
            ('Legrand Indústria Química e Farmacêutica Ltda.', '61.123.456/0001-99', 'Rua das Acácias', '500', 'Jardim América', 'São Paulo', 'SP', '01415-000', 'contato@legrand.com.br', '(11) 3815-6000', @NOW, NULL, 1),
            ('Anidra Indústria e Comércio de Produtos Farmacêuticos Ltda.', '02.987.654/0001-32', 'Rua dos Lírios', '234', 'Vila Formosa', 'São Paulo', 'SP', '03173-000', 'contato@anidra.com.br', '(11) 2099-7700', @NOW, NULL, 1),
            ('Fanpat Indústria Farmacêutica Ltda.', '57.345.678/0001-01', 'Av. Brasil', '1500', 'Centro', 'Bauru', 'SP', '17010-000', 'sac@fanpat.com.br', '(14) 3235-4700', @NOW, NULL, 1),
            ('Prati-Donaduzzi & Cia Ltda.', '81.893.391/0001-50', 'Rua Domingos Donaduzzi', '1720', 'Vila Industrial', 'Toledo', 'PR', '85903-030', 'contato@prati.com.br', '(45) 3279-7000', @NOW, NULL, 1),
            ('Neo Química Produtos Farmacêuticos Ltda.', '00.721.114/0001-60', 'Rua dos Trabalhadores', '500', 'Vila Mariana', 'São Paulo', 'SP', '04123-020', 'sac@neoquimica.com.br', '(11) 3134-7000', @NOW, NULL, 1),
            ('Sandoz Farmacêutica Ltda.', '33.222.111/0001-30', 'Av. Europa', '123', 'Jardim Europa', 'São Paulo', 'SP', '01449-000', 'contato@sandoz.com.br', '(11) 3897-9000', @NOW, NULL, 1),
            ('Drogaria Ultra Popular de Araras', '34.038.090/0001-21', 'Rua Julio Mesquita', '466', 'Centro', 'Araras', 'SP', '13600-060', 'info@ultrapopular.com.br', '(19) 3541-1234', @NOW, NULL, 1),
            ('Farmácia Avenida Araras Ltda', '44.214.385/0001-65', 'Avenida da Saudade', '174', 'Jardim Nossa Sra Fátima', 'Araras', 'SP', '13607-061', 'contato@avenida.com.br', '(19) 3541-2345', @NOW, NULL, 1),
            ('Morandini Ltda', '63.950.497/0001-29', 'Av. Selvílio Begnami', '38', 'Parque Santa Olívia', 'Araras', 'SP', '13607-567', 'sac@morandini.com.br', '(19) 3541-3456', @NOW, NULL, 1),
            ('Farmadescontao Araras', '55.247.852/0001-70', 'Av. Pres. Castello Branco', '190', 'Narciso Gomes', 'Araras', 'SP', '13601-400', 'contato@descontao.com.br', '(19) 3541-4567', @NOW, NULL, 1),
            ('Farmácia Ararense Ltda', '44.206.845/0001-03', 'Praça Martinico Prado', '38', 'Centro', 'Araras', 'SP', '13600-680', 'sac@ararenese.com.br', '(19) 3541-5678', @NOW, NULL, 1),
            ('Batistella Ferrendes e Cia Ltda', '07.102.724/0001-95', 'Rua Tiradentes', '243', 'Centro', 'Araras', 'SP', '13600-070', 'contato@batistella.com.br', '(19) 3541-1142', @NOW, NULL, 1),
            ('Drogaria Samval Ltda', '54.196.951/0001-07', 'Rua Ciro Lagazzi', '640', 'Jardim Cândida', 'Araras', 'SP', '13603-027', 'sac@samvaldrogaria.com.br', '(19) 3541-6789', @NOW, NULL, 1),
            ('Farmácia Cooper B Borelli Cia', '46.666.350/0001-92', 'Av. Zurita', '441', 'Jardim Belvedere', 'Araras', 'SP', '13601-020', 'cooper@farmacoop.com.br', '(19) 3541-7890', @NOW, NULL, 1),
            ('Drogaria Romana Ltda', '52.935.954/0001-90', 'Av. Romana Ometto', '231', 'Jardim Cândida', 'Araras', 'SP', '13603-004', 'romana@sac.com.br', '(19) 3541-8910', @NOW, NULL, 1),
            ('Farmácia Popular do Povo', '44.556.778/0001-99', 'Praça da Matriz', '50', 'Centro', 'Araras', 'SP', '13600-000', 'contato@populardopovo.com.br', '(19) 3541-0000', @NOW, @NOW, 0),
            ('Drogaria Araras Tiradentes Ltda', '74.248.725/0001-30', 'Av. Augusta Viola da Costa', '1712', 'Jardim Celina', 'Araras', 'SP', '13606-020', 'tiradentes@araras.com.br', '(19) 3541-9012', @NOW, NULL, 1),
            ('Distribuidora Simples Farma', '27.101.891/0001-59', 'Rua José Bonifácio', '1120', 'Centro', 'Araras', 'SP', '13600-110', 'contato@simplesfarma.com.br', '(19) 3543-1010', @NOW, NULL, 1),
            ('Farmácia São Lucas Araras', '04.503.891/0001-33', 'Rua 13 de Maio', '830', 'Centro', 'Araras', 'SP', '13600-300', 'sao.lucas@farmacia.com.br', '(19) 3542-9876', @NOW, NULL, 1),
            ('Farmácia Drogamais Araras', '10.234.891/0001-40', 'Rua Tiradentes', '450', 'Jardim São João', 'Araras', 'SP', '13601-050', 'atendimento@drogamais.com.br', '(19) 3542-1212', @NOW, NULL, 1),
            ('Distribuidora Biokosma', '03.912.600/0001-74', 'Rua do Café', '550', 'Distrito Industrial', 'Araras', 'SP', '13607-000', 'comercial@biokosma.com.br', '(19) 3543-3434', @NOW, NULL, 1),
            ('Farmácia Mais Barato', '09.334.790/0001-27', 'Av. Dona Renata', '1322', 'Centro', 'Araras', 'SP', '13600-012', 'contato@maisbarato.com.br', '(19) 3541-3131', @NOW, NULL, 1),
            ('Farmácia Big Farma', '62.493.837/0001-18', 'Rua Nunes Machado', '98', 'Vila Dona Rosa', 'Araras', 'SP', '13601-470', 'sac@bigfarma.com.br', '(19) 3542-8888', @NOW, NULL, 1),
            ('Farmácia Drogamed Araras', '01.838.443/0001-57', 'Rua Silvio Cezarini', '201', 'Jardim Belvedere', 'Araras', 'SP', '13601-120', 'contato@drogamed.com.br', '(19) 3543-7070', @NOW, NULL, 1),
            ('Drogaria Saúde Total', '35.944.556/0001-14', 'Rua Maranhão', '760', 'Jardim Cândida', 'Araras', 'SP', '13603-002', 'saudetotal@farmacia.com.br', '(19) 3541-8888', @NOW, NULL, 1),
            ('Laboratório Baldacci S.A.', '60.672.246/0001-00', 'Rua Pedro Antônio de Magalhães', '640', 'Vila Nova Conceição', 'São Paulo', 'SP', '04507-000', 'contato@baldacci.com.br', '(11) 5082-1100', @NOW, @NOW, 0),
            ('Distribuidora FarmaNorte', '02.872.781/0001-92', 'Rua Pedro Álvares Cabral', '199', 'Parque Industrial', 'Araras', 'SP', '13607-560', 'vendas@farmanorte.com.br', '(19) 3541-6666', @NOW, NULL, 1),
            ('Farmácia Brasil Araras', '53.290.998/0001-05', 'Rua Barão do Rio Branco', '123', 'Centro', 'Araras', 'SP', '13600-050', 'contato@farmaciabrasil.com.br', '(19) 3541-1414', @NOW, NULL, 1),
            ('Farmácia Farmavida', '13.231.211/0001-20', 'Rua São Paulo', '490', 'Jardim Belvedere', 'Araras', 'SP', '13601-000', 'farmavida@farmacia.com.br', '(19) 3541-1111', @NOW, NULL, 1),
            ('Farmácia Central Araras', '18.440.976/0001-33', 'Rua Tiradentes', '200', 'Centro', 'Araras', 'SP', '13600-070', 'central@farmacia.com.br', '(19) 3542-0000', @NOW, NULL, 1),
            ('Drogaria Coração de Jesus', '74.240.933/0001-00', 'Av. Augusta Viola da Costa', '1244', 'Jardim São João', 'Araras', 'SP', '13606-020', 'coracao@jesusfarma.com.br', '(19) 3542-8787', @NOW, NULL, 1),
            ('Distribuidora Farpel Farma', '05.444.334/0001-99', 'Rua José Bonifácio', '200', 'Centro', 'Araras', 'SP', '13600-000', 'vendas@farpel.com.br', '(19) 3542-6767', @NOW, NULL, 1),
            ('Drogaria Nossa Farma', '63.223.431/0001-45', 'Rua Prudente de Moraes', '875', 'Centro', 'Araras', 'SP', '13600-230', 'nossafarma@araras.com.br', '(19) 3542-4545', @NOW, NULL, 1),
            ('Distribuidora MaxiMed', '11.009.239/0001-61', 'Rua Almirante Barroso', '312', 'Centro', 'Araras', 'SP', '13600-310', 'sac@maximed.com.br', '(19) 3543-2323', @NOW, NULL, 1),
            ('Drogaria Bem-Estar', '67.881.333/0001-07', 'Rua São Bento', '220', 'Centro', 'Araras', 'SP', '13600-180', 'contato@bemestar.com.br', '(19) 3542-1111', @NOW, NULL, 1),
            ('Farmácia Vida Mais', '18.772.001/0001-88', 'Rua Benedito Correia', '95', 'Jardim Belvedere', 'Araras', 'SP', '13601-140', 'sac@vidamais.com.br', '(19) 3543-0909', @NOW, NULL, 1),
            ('Drogaria Fênix', '41.002.112/0001-76', 'Av. Dona Renata', '1550', 'Centro', 'Araras', 'SP', '13600-012', 'fenix@farmacia.com.br', '(19) 3542-9999', @NOW, NULL, 1),
            ('Farmácia Naturallis', '60.772.002/0001-11', 'Rua Amazonas', '430', 'Jardim Cândida', 'Araras', 'SP', '13603-003', 'naturallis@farmacia.com.br', '(19) 3542-1213', @NOW, NULL, 1),
            ('Sun Farmacêutica do Brasil', '—', 'Alameda Tocantins', '125', 'Alphaville Industrial', 'Barueri', 'SP', '06455-020', 'farmacovigilancia@sunpharma.com', '(11) 4766-8800', @NOW, NULL, 1),
            ('Farmácia BioSaúde', '29.334.112/0001-55', 'Rua 1º de Maio', '150', 'Centro', 'Araras', 'SP', '13600-090', 'biosaudeararas@farmacia.com.br', '(19) 3541-9999', @NOW, NULL, 1),
            ('Drogaria Popular', '07.999.123/0001-81', 'Av. Brasil', '980', 'Jardim São João', 'Araras', 'SP', '13601-070', 'popular@farmaciapopular.com.br', '(19) 3541-2020', @NOW, NULL, 1),
            ('Farmácia Saúde Ocupacional', '50.112.456/0001-33', 'Rua Presidente Vargas', '300', 'Centro', 'Araras', 'SP', '13600-040', 'saudeocup@farmacia.com.br', '(19) 3541-3030', @NOW, NULL, 1),
            ('Drogasil Araras', '01.234.567/0001-89', 'Av. Dona Renata', '2345', 'Centro', 'Araras', 'SP', '13600-011', 'araras@drogasil.com.br', '(19) 3541-4545', @NOW, NULL, 1),
            ('Farmácia Cidade Viva', '16.223.334/0001-22', 'Rua Xavier da Silva', '765', 'Vila Dona Rosa', 'Araras', 'SP', '13601-050', 'cidviva@farmacia.com.br', '(19) 3542-1313', @NOW, NULL, 1),
            ('Distribuidora FarmaPlus', '08.445.678/0001-10', 'Rua São Bento', '500', 'Centro', 'Araras', 'SP', '13600-200', 'contato@farmaplus.com.br', '(19) 3542-2121', @NOW, NULL, 1),
            ('Diffucap Chemobras', '45.161.472/0001-00', 'Rua São Paulo', '200', 'Centro', 'Guarulhos', 'SP', '07024-000', 'contato@diffucap.com.br', '(11) 2440-1000', @NOW, @NOW, 0),
            ('Farmácia Saúde Plus', '33.556.778/0001-09', 'Av. Major Antonio Pereira', '333', 'Jardim São João', 'Araras', 'SP', '13606-010', 'saudeplus@farmacia.com.br', '(19) 3541-3232', @NOW, NULL, 1),
            ('Farmácia Bem-Estar', '21.998.556/0001-70', 'Rua Campinas', '220', 'Vila Dona Rosa', 'Araras', 'SP', '13601-480', 'bemestar@farmacia.com.br', '(19) 3542-4141', @NOW, NULL, 1),
            ('Farmácia FarmaFácil', '28.772.112/0001-80', 'Av. Pres. Vargas', '155', 'Centro', 'Araras', 'SP', '13600-060', 'farmafacil@farmacia.com.br', '(19) 3541-5454', @NOW, NULL, 1),
            ('Drogaria Saúde & Vida', '77.665.443/0001-09', 'Rua Nogueira Padilha', '321', 'Centro', 'Araras', 'SP', '13600-230', 'saudevida@farmacia.com.br', '(19) 3541-6767', @NOW, NULL, 1),
            ('Farmácia Vitória Araras', '46.112.334/0001-34', 'Av. São Carlos', '410', 'Jardim Belvedere', 'Araras', 'SP', '13601-160', 'vitoria@farmacia.com.br', '(19) 3541-7878', @NOW, NULL, 1),
            ('Distribuidora Indústria Ararense', '70.334.225/0001-12', 'Rua do Progresso', '100', 'Distrito Industrial', 'Araras', 'SP', '13607-570', 'ind@ararasind.com.br', '(19) 3543-4545', @NOW, NULL, 1),
            ('Farmácia Araras Saúde', '11.223.334/0001-22', 'Rua 15 de Novembro', '890', 'Centro', 'Araras', 'SP', '13600-090', 'ararassaude@farmacia.com.br', '(19) 3541-2828', @NOW, NULL, 1),
            ('Farmácia Cidadão', '66.998.556/0001-11', 'Rua do Comércio', '555', 'Centro', 'Araras', 'SP', '13600-200', 'cidadao@farmacia.com.br', '(19) 3542-3434', @NOW, NULL, 1),
            ('Drogaria Vida Feliz', '98.112.334/0001-44', 'Av. Getúlio Vargas', '132', 'Jardim Cândida', 'Araras', 'SP', '13603-060', 'vidafeliz@farmacia.com.br', '(19) 3541-4545', @NOW, NULL, 1),
            ('Farmácia Nova Era', '27.334.225/0001-13', 'Rua do Sol', '321', 'Jardim São João', 'Araras', 'SP', '13606-050', 'novaera@farmacia.com.br', '(19) 3541-5656', @NOW, NULL, 1),
            ('Farmácia Bem Caring', '15.556.778/0001-20', 'Av. Amazonas', '410', 'Vila Dona Rosa', 'Araras', 'SP', '13601-470', 'bemcaring@farmacia.com.br', '(19) 3542-6767', @NOW, NULL, 1),
            ('Drogaria Pontual', '39.998.556/0001-09', 'Rua Santa Catarina', '220', 'Centro', 'Araras', 'SP', '13600-150', 'pontual@farmacia.com.br', '(19) 3541-7878', @NOW, NULL, 1),
            ('Farmácia Popular Araras', '58.112.334/0001-55', 'Av. São Bento', '78', 'Centro', 'Araras', 'SP', '13600-180', 'popularararas@farmacia.com.br', '(19) 3542-8989', @NOW, NULL, 1),
            ('Farmácia Essencial', '30.334.225/0001-32', 'Rua Júlio Mesquita', '310', 'Centro', 'Araras', 'SP', '13600-065', 'essencial@farmacia.com.br', '(19) 3541-9090', @NOW, NULL, 1),
            ('Drogaria Express', '42.223.334/0001-22', 'Av. Pres. Castelo Branco', '1900', 'Jardim Celina', 'Araras', 'SP', '13606-110', 'express@farmacia.com.br', '(19) 3543-1011', @NOW, NULL, 1),
            ('Kendrick Laboratórios', '61.777.888/0001-00', 'Rua dos Laboratórios', '456', 'Centro', 'Rio de Janeiro', 'RJ', '20000-000', 'sac@kendrick.com.br', '(21) 2222-3333', @NOW, @NOW, 0),
            ('Farmácia Estrela do Norte', '88.556.778/0001-11', 'Rua Nova Araras', '800', 'Jardim São João', 'Araras', 'SP', '13606-060', 'estrelanorte@farmacia.com.br', '(19) 3541-3233', @NOW, NULL, 1),
            ('Distribuidora MegaFarma', '51.112.334/0001-45', 'Rua São Paulo', '210', 'Centro', 'Araras', 'SP', '13600-020', 'megafarma@distribuidora.com.br', '(19) 3541-4546', @NOW, NULL, 1),
            ('Farmácia Bem Viver', '65.334.225/0001-26', 'Rua Presidente Kennedy', '112', 'Centro', 'Araras', 'SP', '13600-100', 'bemviver@farmacia.com.br', '(19) 3541-9797', @NOW, NULL, 1),
            ('Farmácia Vida Viva', '23.998.556/0001-40', 'Av. Dona Renata', '1999', 'Vila Dona Rosa', 'Araras', 'SP', '13601-331', 'vidaviva@farmacia.com.br', '(19) 3542-2122', @NOW, NULL, 1),
            ('Drogaria Multimed', '47.112.334/0001-78', 'Rua Rio Branco', '300', 'Centro', 'Araras', 'SP', '13600-030', 'multimed@farmacia.com.br', '(19) 3542-6768', @NOW, NULL, 1),
            ('Farmácia Extra Vida', '99.112.334/0001-10', 'Av. São Carlos', '780', 'Vila Dona Rosa', 'Araras', 'SP', '13601-470', 'extravida@farmacia.com.br', '(19) 3542-9090', @NOW, NULL, 1),
            ('Drogaria Nova Saúde', '12.223.334/0001-55', 'Rua do Comércio', '620', 'Centro', 'Araras', 'SP', '13600-220', 'novasaude@farmacia.com.br', '(19) 3543-1111', @NOW, NULL, 1),
            ('Distribuidora FarmaAraras', '17.112.334/0001-90', 'Rua 13 de Maio', '400', 'Centro', 'Araras', 'SP', '13600-300', 'contato@farmaararas.com.br', '(19) 3543-2222', @NOW, NULL, 1),
            ('Farmácia MedPlus', '24.112.334/0001-11', 'Av. Dona Renata', '2100', 'Jardim São João', 'Araras', 'SP', '13606-020', 'medplus@farmacia.com.br', '(19) 3542-1314', @NOW, NULL, 1),
            ('Farmácia Araraquarense', '30.334.225/0001-44', 'Rua São Bento', '145', 'Centro', 'Araras', 'SP', '13600-180', 'ararafarma@farmacia.com.br', '(19) 3542-4546', @NOW, NULL, 1),
            ('Cimed Indústria S.A.', '02.814.497/0001-07', 'Avenida Angélica', '2248', 'Consolação', 'São Paulo', 'SP', '01228-200', 'tributario@grupocimed.com.br', '(11) 3544-7200', @NOW, NULL, 1),
            ('Mantecorp Farmasa (Cosmed Ind. de Cosméticos e Medicamentos S.A.)', '61.082.426/0002-07', 'Rua Bonnard (Green Valley I)', '980', 'Alphaville Empresarial', 'Barueri', 'SP', '06465-134', 'daniel.almeida@hypera.com.br', '(62) 3878-8150', @NOW, @NOW, 0),
            ('Germed Farmacêutica Ltda.', '45.992.062/0001-65', 'Rodovia Jornalista Francisco Aguirre Proença', 'S/N KM 08', 'Chácara Assay', 'Hortolândia', 'SP', '13186-901', 'contabil.holding@ems.com.br', '(19) 3887-9800', @NOW, NULL, 1),
            ('Natulab Laboratório S/A', '02.456.955/0001-83', 'Rua José Rocha Galvão', '02', 'Salgadeira', 'Santo Antônio de Jesus', 'BA', '44444-312', 'contador@natulab.com.br', '(75) 3311-5555', @NOW, NULL, 1),
            ('Novo Nordisk Farmacêutica do Brasil Ltda', '82.277.955/0001-55', 'Avenida Francisco Matarazzo', '1350', 'Água Branca', 'São Paulo', 'SP', '05001-100', 'recebimento@novonordisk.com', '(11) 3868-9137', @NOW, NULL, 1),
            ('FQM Indústria Farmacêutica Ltda.', '12.345.678/0001-15', 'Av. Inventada', '500', 'Centro', 'São Paulo', 'SP', '01010-000', 'sac@fqm.com.br', '(11) 4000-0000', @NOW, NULL, 1),
            ('Teuto Brasileiro S.A.', '12.345.678/0001-90', 'Avenida Industrial', '1000', 'Distrito Industrial', 'Anápolis', 'GO', '75000-000', 'contato@teuto.com.br', '(62) 4000-0000', @NOW, NULL, 1),
            ('Geolab Indústria Farmacêutica', '98.765.432/0001-09', 'Rua dos Laboratórios', '200', 'Polo Industrial', 'Goiânia', 'GO', '74000-000', 'contato@geolab.com.br', '(62) 3900-0000', @NOW, NULL, 1),
            ('Dimebrás Distribuidora Farmacêutica Ltda', '42.545.039/0001-34', 'Rua Cecília do Rego Almeida', '300', 'Jardim Eldorado', 'Palhoça', 'SC', '88133-560', 'dimebras@dimebras.com.br', '(48) 3224-1834', @NOW, NULL, 1),
            ('ANB Farma Ltda', '73.773.129/0001-06', 'Rua Alcides Jazar', '520', 'Atuba', 'Pinhais', 'PR', '83326-070', 'contato@anbfarma.com.br', '(41) 3072-8120', @NOW, NULL, 1),
            ('Foco Distribuidora de Medicamentos Ltda', '08.809.411/0001-34', 'Avenida Central', '1200', 'Bairro Novo Mundo', 'Curitiba', 'PR', '81000-000', 'atendimento@focodistribuidora.com.br', '(41) 3266-2111', @NOW, NULL, 1),
            ('Medmais Comércio de Materiais Hospitalares E Medicamentos Ltda', '54.223.019/0001-26', 'Rua João Fernandes da Gama', '160', 'Centro', 'Ribeira do Pombal', 'BA', '48400-000', 'medmais@medmais.com.br', '(75) 9904-7884', @NOW, NULL, 1),
            ('Multmed Comercial Ltda', '57.929.071/0001-90', 'Avenida das Américas', '12900', 'Barra da Tijuca', 'Rio de Janeiro', 'RJ', '22790-702', 'multmed@multmed.com.br', '(21) 97101-7775', @NOW, NULL, 1),
            ('Torrent Pharma', '33.197.886/0001-00', 'Rua Doutor Alfredo de Castro', '200', 'Barra Funda', 'São Paulo', 'SP', '01155-060', 'contato@torrentpharma.com.br', '(11) 3874-9000', @NOW, NULL, 1),
            ('Tecnofarma', '00.111.222/0001-00', 'Avenida Marechal Deodoro', '789', 'Centro', 'Campinas', 'SP', '13000-000', 'contato@tecnofarma.com.br', '(19) 3232-4444', @NOW, @NOW, 0),
            ('Laboratórios Gautier', '99.888.777/0001-00', 'Rua Estrangeira', '100', 'Cidade Vizinha', 'Montevidéu', 'UY', '00000-000', 'info@gautier.com', '(598) 2901-1234', @NOW, @NOW, 0),
            ('Celltrion Healthcare', '36.879.445/0001-00', 'Avenida Queiroz Filho', '1700', 'Vila Leopoldina', 'São Paulo', 'SP', '05319-000', 'contato@celltrionhealthcare.com.br', '(11) 3717-0000', @NOW, NULL, 1),
            ('Moksha8', '07.388.941/0001-00', 'Rua Fidêncio Ramos', '302', 'Vila Olímpia', 'São Paulo', 'SP', '04551-010', 'sac@moksha8.com.br', '(11) 3043-9800', @NOW, NULL, 1),
            ('Viatris (Mylan/Upjohn)', '02.730.297/0001-27', 'Avenida Presidente Juscelino Kubitschek', '1909', 'Vila Nova Conceição', 'São Paulo', 'SP', '04543-907', 'contato@viatris.com.br', '(11) 3048-8000', @NOW, NULL, 1),
            ('Siegfried Rhein', '01.520.141/0001-90', 'Avenida Brigadeiro Faria Lima', '2010', 'Jardim Paulistano', 'São Paulo', 'SP', '01451-000', 'sac@siegfriedrhein.com.br', '(11) 3034-5400', @NOW, NULL, 1),
            ('Servier do Brasil', '42.946.071/0001-00', 'Estrada dos Bandeirantes', '4214', 'Jacarepaguá', 'Rio de Janeiro', 'RJ', '22775-114', 'contato@servier.com.br', '(21) 3232-0000', @NOW, NULL, 1),
            ('Dimed (Panvel Farmácias)', '92.665.611/0001-00', 'Avenida Assis Brasil', '3522', 'São Sebastião', 'Porto Alegre', 'RS', '91010-000', 'sac@dimed.com.br', '(51) 3218-9000', @NOW, NULL, 1),
            ('Boehringer Ingelheim', '60.846.120/0001-00', 'Avenida das Nações Unidas', '13797', 'Morumbi', 'São Paulo', 'SP', '04794-000', 'contato@boehringer-ingelheim.com.br', '(11) 4949-4000', @NOW, NULL, 1),
            ('Eli Lilly do Brasil', '43.940.618/0001-44', 'Avenida Morumbi', '8234', 'Santo Amaro', 'São Paulo', 'SP', '04703-002', 'sac@lilly.com', '(11) 5092-2000', @NOW, NULL, 1),
            ('Teva Farmacêutica Ltda.', '05.501.990/0001-00', 'Avenida Paulista', '1776', 'Bela Vista', 'São Paulo', 'SP', '01310-200', 'sac@tevabrasil.com.br', '(11) 3016-5600', @NOW, NULL, 1),
            ('Grunenthal do Brasil', '10.545.964/0001-54', 'Avenida das Nações Unidas', '12901', 'Brooklin Novo', 'São Paulo', 'SP', '04578-000', 'contato@grunenthal.com.br', '(11) 3815-4000', @NOW, NULL, 1),
            ('Zydus Nikkho', '05.254.218/0001-00', 'Rua Engenheiro Ladislau Kanzler', '255', 'Parque Industrial', 'Curitiba', 'PR', '81170-420', 'contato@zydusnikkho.com.br', '(41) 3340-0000', @NOW, NULL, 1),
            ('CM Hospitalar', '03.791.706/0001-00', 'Rua Luiz Gama', '300', 'Centro', 'Campinas', 'SP', '13015-120', 'comercial@cmhospitalar.com.br', '(19) 3737-1000', @NOW, NULL, 1),
            ('Farmalogist', '03.882.115/0001-00', 'Rodovia Anhanguera', 'Km 104', 'Distrito Industrial', 'Sumaré', 'SP', '13175-000', 'contato@farmalogist.com.br', '(19) 3873-5000', @NOW, NULL, 1),
            ('Biosintética Farmacêutica', '61.272.164/0001-32', 'Rua Doutor José Bernardo Pinto', '333', 'Vila Guilherme', 'São Paulo', 'SP', '02055-000', 'contato@biosintetica.com.br', '(11) 2171-8000', @NOW, @NOW, 0),
            ('Biobrás', '30.136.215/0001-00', 'Avenida Caxingui', '25', 'Jardim Everest', 'Montes Claros', 'MG', '39400-000', 'contato@biobras.com.br', '(38) 3218-1000', @NOW, @NOW, 0),
            ('Laboratórios Meizler (Adquirida por UCB Pharma)', '61.123.456/0001-00', 'Rua José Alves da Silva', '123', 'Vila Nova', 'São Paulo', 'SP', '05450-000', 'contato@meizler.com.br', '(11) 3048-1234', @NOW, @NOW, 0),
            ('UCB Biopharma S/A.', '64.711.500/0001-14', 'Alameda Araguaia', '3833', 'Centro Empresarial Alphaville', 'Barueri', 'SP', '06455-000', 'ucbcares.br@ucb.com', '(11) 4195-6613', @NOW, NULL, 1),
            ('Momenta Farmacêutica', '05.679.548/0001-90', 'Rua Enéas Luís Carlos Barbanti', '216', 'Freguesia do Ó', 'São Paulo', 'SP', '02911-000', 'sac@momentafarma.com.br', '(11) 3977-9000', @NOW, NULL, 1),
            ('UCI-Farma', '42.946.071/0001-00', 'Rua do Feijão', '155', 'Penha Circular', 'Rio de Janeiro', 'RJ', '21011-050', 'contato@ucifarma.com.br', '(21) 2598-1000', @NOW, NULL, 1),
            ('Herbarium', '78.950.069/0001-70', 'Rua Guairacá', '1000', 'Hauer', 'Curitiba', 'PR', '81610-060', 'sac@herbarium.com.br', '(41) 3291-5800', @NOW, NULL, 1),
            ('Myralis Pharma', '11.832.071/0001-52', 'Rua Pastor Djalma da Silva Coimbra', '346', 'Parque Cidade Nova', 'Valinhos', 'SP', '13271-460', 'contato@myralis.com.br', '(19) 3849-7400', @NOW, NULL, 1),
            ('SND Distribuição', '00.006.136/0001-00', 'Rodovia Anhanguera', 'Km 139', 'Jardim Guanabara', 'Campinas', 'SP', '13070-000', 'contato@snd.com.br', '(19) 3746-1000', @NOW, NULL, 1),
            ('Drogarias Rossy', '12.345.678/0001-99', 'Rua da Amizade', '500', 'Centro', 'Campinas', 'SP', '13010-000', 'contato@drogariarossy.com.br', '(19) 3232-1122', @NOW, @NOW, 0),
            ('Mafra Hospitalar', '80.006.136/0001-80', 'Rua Padre Anchieta', '2050', 'Bigorrilho', 'Curitiba', 'PR', '80730-000', 'contato@mafra.com.br', '(41) 3218-5000', @NOW, NULL, 1),
            ('Grupo DPSP (Pacheco e São Paulo)', '61.854.493/0001-80', 'Rua Alexandre Dumas', '1801', 'Chácara Santo Antônio', 'São Paulo', 'SP', '04717-004', 'contato@dpsp.com.br', '(11) 5188-7700', @NOW, NULL, 1),
            ('Farmácias Indiana', '20.720.898/0001-00', 'Rua Espírito Santo', '100', 'Centro', 'Teófilo Otoni', 'MG', '39800-000', 'sac@farmaciasindiana.com.br', '(33) 3529-1000', @NOW, NULL, 1),
            ('Zambon Laboratórios', '61.189.789/0001-00', 'Rua Álvaro Bandeira', '300', 'Vila Nova Conceição', 'São Paulo', 'SP', '04509-020', 'sac@zambon.com.br', '(11) 2110-4000', @NOW, NULL, 1),
            ('Laboratório Farmacêutico Arboris', '11.223.344/0001-55', 'Rua das Indústrias', '50', 'Distrito Industrial', 'Sorocaba', 'SP', '18087-000', 'contato@arboris.com.br', '(15) 3211-5000', @NOW, @NOW, 0),
            ('Cifarma Científica', '17.200.065/0001-00', 'Rua Carlos Gomes', '125', 'Jardim Ana Lucia', 'Goiânia', 'GO', '74000-000', 'contato@cifarma.com.br', '(62) 3230-1000', @NOW, NULL, 1),
            ('Coopmed Distribuidora', '08.765.432/0001-00', 'Avenida das Hortênsias', '1500', 'Jardim das Flores', 'Campinas', 'SP', '13088-000', 'vendas@coopmed.com.br', '(19) 3200-5000', @NOW, NULL, 1),
            ('Dimensa Distribuidora', '04.543.210/0001-00', 'Rua das Oliveiras', '880', 'Distrito Industrial', 'Uberlândia', 'MG', '38402-000', 'comercial@dimensa.com.br', '(34) 3210-9000', @NOW, NULL, 1),
            ('Alpha Distribuidora Farmacêutica', '09.876.543/0001-21', 'Rua do Comércio', '123', 'Centro', 'Limeira', 'SP', '13480-000', 'vendas@alphadist.com.br', '(19) 3441-5555', @NOW, NULL, 1),
            ('Beta Pharma Representações', '01.234.567/0001-00', 'Avenida Independência', '456', 'Jardim Amélia', 'Rio Claro', 'SP', '13500-000', 'contato@betapharma.com.br', '(19) 3522-6666', @NOW, NULL, 1),
            ('Laboratório Magistralis', '05.678.910/0001-12', 'Rua da Saúde', '789', 'Bela Vista', 'Piracicaba', 'SP', '13400-000', 'manipulacao@magistralis.com.br', '(19) 3401-7777', @NOW, NULL, 1),
            ('Laboratório Catarinense', '84.683.746/0001-00', 'Rua Doutor João Colin', '1000', 'América', 'Joinville', 'SC', '89204-000', 'contato@labcatarinense.com.br', '(47) 3451-2000', @NOW, @NOW, 0),
            ('Laboratório Climax', '22.334.556/0001-77', 'Avenida Paulista', '100', 'Jardim Paulista', 'São Paulo', 'SP', '01310-000', 'sac@climaxlab.com.br', '(11) 3333-1111', @NOW, @NOW, 0),
            ('Distribuidora Alfa Saúde', '33.445.667/0001-88', 'Rua das Mangueiras', '321', 'Bairro Novo', 'Jundiaí', 'SP', '13210-000', 'vendas@alfasaude.com.br', '(11) 4588-9900', @NOW, @NOW, 0);
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @NOW DATETIME
SET @NOW = GETDATE()

INSERT INTO [dbo].[Product]
            ([Name]
            ,[Description]
            ,[DosageForm]
            ,[Category]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
VALUES
            -- ('Name', 'Description', 'DosageForm', 'Category', 'CreatedOn', 'UpdatedOn', 'IsActive')
            ('Dipirona Sódica 500mg', 'Analgésico e antitérmico utilizado para dor e febre.', 'Comprimido', 'Analgésico/Antitérmico', @NOW, NULL, 1),
            ('Dipirona Sódica 1g', 'Analgésico e antitérmico utilizado para dor e febre.', 'Ampola', 'Analgésico/Antitérmico', @NOW, NULL, 1),
            ('Paracetamol 750mg', 'Analgésico utilizado para dor e febre.', 'Comprimido', 'Analgésico/Antitérmico', @NOW, NULL, 1),
            ('Ibuprofeno 400mg', 'Anti-inflamatório utilizado para dor e inflamação.', 'Comprimido', 'Anti-inflamatório', @NOW, NULL, 1),
            ('Paracetamol 1g', 'Analgésico e antitérmico para dor e febre.', 'Comprimido', 'Analgésico/Antitérmico', @NOW, NULL, 1),
            ('Ibuprofeno 600mg', 'Anti-inflamatório para dor e inflamação.', 'Comprimido', 'Anti-inflamatório', @NOW, NULL, 1),
            ('Soro Glicosado 5% 250ml', 'Solução para uso intravenoso.', 'Bolsa', 'Hidratante/Infusão', @NOW, NULL, 1),
            ('Metformina 500mg', 'Controle de glicemia em pacientes com diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, @NOW, 0),
            ('Amoxicilina 875mg', 'Antibiótico de largo espectro.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Dexametasona 0,5mg', 'Corticosteroide para inflamações leves.', 'Comprimido', 'Corticosteroide', @NOW, NULL, 1),
            ('Losartana 100mg', 'Anti-hipertensivo para controle da pressão arterial.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Metformina 1000mg', 'Controle da diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Amoxicilina + Clavulanato 875mg', 'Antibiótico de amplo espectro.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Cefalexina 500mg', 'Antibiótico para infecções respiratórias e urinárias.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Sais para Reidratação Oral', 'Suplemento eletrolítico para desidratação.', 'Sachê', 'Hidratante Oral', @NOW, NULL, 1),
            ('Insulina Glargina 100UI/ml', 'Insulina de ação prolongada para diabetes tipo 1 e 2.', 'Caneta', 'Hormônio/Insulina', @NOW, NULL, 1),
            ('Insulina Regular 100UI/ml', 'Insulina de ação rápida.', 'Caneta', 'Hormônio/Insulina', @NOW, NULL, 1),
            ('Sais para Reidratação com Zinco', 'Suplemento eletrolítico com zinco para desidratação.', 'Sachê', 'Hidratante Oral', @NOW, NULL, 1),
            ('Rehidratante Infantil', 'Repositor de eletrólitos para crianças.', 'Sachê', 'Hidratante Oral', @NOW, NULL, 1),
            ('Soro Fisiológico 100ml', 'Solução para uso intravenoso ou nasal.', 'Bolsa', 'Hidratante/Infusão', @NOW, NULL, 1),
            ('Soro Glicosado 10% 500ml', 'Solução glicosada para uso hospitalar.', 'Bolsa', 'Hidratante/Infusão', @NOW, NULL, 1),
            ('Insulina NPH 100UI/ml', 'Insulina de ação intermediária.', 'Caneta', 'Hormônio/Insulina', @NOW, NULL, 1),
            ('Insulina Detemir 100UI/ml', 'Insulina basal de longa duração.', 'Caneta', 'Hormônio/Insulina', @NOW, NULL, 1),
            ('Insulina Lispro 100UI/ml', 'Insulina de ação ultra-rápida.', 'Caneta', 'Hormônio/Insulina', @NOW, NULL, 1),
            ('Amoxicilina 250mg', 'Antibiótico para infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Omeprazol 10mg', 'Inibidor de bomba de prótons para refluxo.', 'Comprimido', 'Antiácido', @NOW, NULL, 1),
            ('Hidroclorotiazida 25mg', 'Diurético para controle da pressão arterial.', 'Comprimido', 'Diurético', @NOW, NULL, 1),
            ('Levodopa + Carbidopa', 'Tratamento da doença de Parkinson.', 'Comprimido', 'Neurológico', @NOW, NULL, 1),
            ('Risperidona 2mg', 'Antipsicótico utilizado em transtornos mentais.', 'Comprimido', 'Antipsicótico', @NOW, NULL, 1),
            ('Diazepam 10mg', 'Ansiolítico e relaxante muscular.', 'Comprimido', 'Ansiolítico', @NOW, NULL, 1),
            ('Sinvastatina 10mg', 'Redutor de colesterol.', 'Comprimido', 'Anticolesterol', @NOW, NULL, 1),
            ('Vitamina D3 1000UI', 'Suplemento vitamínico.', 'Comprimido', 'Suplemento/Vitamina', @NOW, @NOW, 0),
            ('Cloroquina 250mg', 'Medicamento utilizado em doenças autoimunes e malária.', 'Comprimido', 'Imunomodulador', @NOW, @NOW, 0),
            ('Hidroxicloroquina 400mg', 'Tratamento para lúpus e artrite reumatoide.', 'Comprimido', 'Imunomodulador', @NOW, NULL, 1),
            ('Ranitidina 150mg', 'Bloqueador H2 utilizado para tratar úlceras.', 'Comprimido', 'Antiácido', @NOW, NULL, 1),
            ('Isotretinoína 20mg', 'Tratamento para acne grave.', 'Cápsula', 'Dermatológico', @NOW, @NOW, 0),
            ('AAS 100mg', 'Antiagregante plaquetário para prevenção cardiovascular.', 'Comprimido', 'Antitrombótico', @NOW, NULL, 1),
            ('Sinvastatina 40mg', 'Redutor de colesterol.', 'Comprimido', 'Anticolesterol', @NOW, NULL, 1),
            ('Carvedilol 25mg', 'Tratamento para insuficiência cardíaca.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Soro Fisiológico 0,9% 500ml', 'Solução salina para hidratação ou limpeza.', 'Bolsa', 'Hidratante/Infusão', @NOW, NULL, 1),
            ('Espirolactona 100mg', 'Diurético poupador de potássio.', 'Comprimido', 'Diurético', @NOW, NULL, 1),
            ('Albendazol 400mg', 'Antiparasitário utilizado no tratamento de verminoses.', 'Comprimido', 'Antiparasitário', @NOW, NULL, 1),
            ('Lorazepam 1mg', 'Ansiolítico para tratamento de transtornos de ansiedade.', 'Comprimido', 'Ansiolítico', @NOW, NULL, 1),
            ('Buscopan 10mg', 'Antiespasmódico para cólicas intestinais.', 'Comprimido', 'Antiespasmódico', @NOW, NULL, 1),
            ('Bromoprida 10mg', 'Antiemético utilizado para enjoo e refluxo.', 'Comprimido', 'Antiemético', @NOW, NULL, 1),
            ('AAS 500mg', 'Analgésico e antipirético.', 'Comprimido', 'Analgésico/Antitérmico', @NOW, NULL, 1),
            ('Ondansetrona 4mg', 'Medicamento para náuseas e vômitos.', 'Comprimido', 'Antiemético', @NOW, NULL, 1),
            ('Doxiciclina 100mg', 'Antibiótico utilizado para tratar infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Lorazepam 2mg', 'Ansiolítico utilizado para tratar transtornos de ansiedade.', 'Comprimido', 'Ansiolítico', @NOW, NULL, 1),
            ('Prazosin 1mg', 'Medicamento utilizado para tratar hipertensão e sintomas de hipertrofia prostática.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Fluoxetina 20mg', 'Antidepressivo utilizado para tratar depressão e transtorno obsessivo-compulsivo.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Vitamina C 500mg', 'Suplemento antioxidante.', 'Comprimido', 'Suplemento/Vitamina', @NOW, @NOW, 0),
            ('Naproxeno 500mg', 'Anti-inflamatório utilizado para aliviar dor e inflamação.', 'Comprimido', 'Anti-inflamatório', @NOW, NULL, 1),
            ('Prednisona 20mg', 'Corticosteroide utilizado no tratamento de condições inflamatórias e autoimunes.', 'Comprimido', 'Corticosteroide', @NOW, @NOW, 0),
            ('Ciprofloxacino 500mg', 'Antibiótico utilizado no tratamento de infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Atorvastatina 20mg', 'Medicamento utilizado para reduzir o colesterol e prevenir doenças cardiovasculares.', 'Comprimido', 'Anticolesterol', @NOW, NULL, 1),
            ('Desloratadina 5mg', 'Antialérgico para rinite e urticária.', 'Comprimido', 'Antialérgico', @NOW, NULL, 1),
            ('Levotiroxina Sódica 50mcg', 'Reposição hormonal da tireoide.', 'Comprimido', 'Hormônio/Tireoide', @NOW, NULL, 1),
            ('Levotiroxina Sódica 100mcg', 'Tratamento de hipotireoidismo.', 'Comprimido', 'Hormônio/Tireoide', @NOW, NULL, 1),
            ('Ranitidina 75mg', 'Bloqueador de ácido estomacal.', 'Comprimido', 'Antiácido', @NOW, @NOW, 0),
            ('Claritromicina 500mg', 'Antibiótico para infecções respiratórias.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Azitromicina 500mg', 'Antibiótico macrolídeo para infecções respiratórias e ISTs.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Levofloxacino 500mg', 'Antibiótico para infecções graves.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Betametasona 0,5mg', 'Corticosteroide para alergias e inflamações.', 'Comprimido', 'Corticosteroide', @NOW, NULL, 1),
            ('Prednisona 5mg', 'Corticosteroide para doenças autoimunes.', 'Comprimido', 'Corticosteroide', @NOW, NULL, 1),
            ('Amoxicilina 500mg', 'Antibiótico de amplo espectro para infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Paracetamol 500mg', 'Analgésico e antitérmico utilizado para dor e febre.', 'Comprimido', 'Analgésico/Antitérmico', @NOW, NULL, 1),
            ('Metformina 850mg', 'Medicamento utilizado no controle de diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Loratadina 10mg', 'Antialérgico utilizado para tratar reações alérgicas.', 'Comprimido', 'Antialérgico', @NOW, NULL, 1),
            ('Losartana 50mg', 'Medicamento utilizado para hipertensão e insuficiência cardíaca.', 'Comprimido', 'Antihipertensivo', @NOW, @NOW, 0),
            ('Cloridrato de Sertralina 50mg', 'Medicamento utilizado no tratamento de depressão e ansiedade.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Omeprazol 20mg', 'Inibidor da bomba de prótons utilizado para tratar úlceras gástricas e refluxo ácido.', 'Comprimido', 'Antiácido', @NOW, NULL, 1),
            ('Cetoconazol 200mg', 'Antifúngico utilizado no tratamento de infecções fúngicas.', 'Comprimido', 'Antifúngico', @NOW, NULL, 1),
            ('Lisinopril 10mg', 'Medicamento utilizado para tratar hipertensão e insuficiência cardíaca.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Cloridrato de Clonazepam 2mg', 'Ansiolítico utilizado no tratamento de transtornos de ansiedade e convulsões.', 'Comprimido', 'Ansiolítico', @NOW, NULL, 1),
            ('Captopril 25mg', 'Medicamento utilizado no tratamento de hipertensão e insuficiência cardíaca.', 'Comprimido', 'Antihipertensivo', @NOW, @NOW, 0),
            ('Furosemida 40mg', 'Diurético utilizado no tratamento de hipertensão e insuficiência cardíaca.', 'Comprimido', 'Diurético', @NOW, @NOW, 0),
            ('Salbutamol 5ml', 'Broncodilatador utilizado para asma e doenças pulmonares.', 'Frasco', 'Broncodilatador', @NOW, NULL, 1),
            ('Zolpidem 10mg', 'Medicamento utilizado para o tratamento de insônia.', 'Comprimido', 'Hipnótico', @NOW, NULL, 1),
            ('Enoxaparina 40mg', 'Anticoagulante utilizado no tratamento e prevenção de trombose.', 'Tubo', 'Anticoagulante', @NOW, NULL, 1),
            ('Salbutamol 2,5mg', 'Broncodilatador utilizado para asma e doenças pulmonares.', 'Frasco', 'Broncodilatador', @NOW, NULL, 1),
            ('Prednisona 10mg', 'Anti-inflamatório e imunossupressor.', 'Comprimido', 'Corticosteroide', @NOW, NULL, 1),
            ('Ibuprofeno 200mg', 'Anti-inflamatório não esteroide (AINE) para dor e inflamação.', 'Comprimido', 'Anti-inflamatório', @NOW, NULL, 1),
            ('Ferro Sulfato 200mg', 'Suplemento de ferro utilizado para tratar e prevenir a anemia ferropriva.', 'Comprimido', 'Suplemento/Anemia', @NOW, NULL, 1),
            ('Enalapril 10mg', 'Medicamento utilizado para tratar hipertensão e insuficiência cardíaca.', 'Comprimido', 'Antihipertensivo', @NOW, @NOW, 0),
            ('Ácido Fólico 5mg', 'Vitamina utilizada na prevenção de defeitos do tubo neural e tratamento de anemias.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Fluimucil 600mg', 'Mucolítico utilizado no tratamento de doenças respiratórias.', 'Comprimido)', 'Mucolítico', @NOW, @NOW, 0),
            ('Gliclazida 80mg', 'Medicamento utilizado no controle de diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Carbamazepina 200mg', 'Antiepilético utilizado no tratamento de epilepsia e transtornos do humor.', 'Comprimido', 'Antiepilético', @NOW, NULL, 1),
            ('Cimetidina 200mg', 'Antagonista H2 utilizado no tratamento de úlceras gástricas e refluxo.', 'Comprimido', 'Antiácido', @NOW, NULL, 1),
            ('Dexametasona 4mg', 'Corticosteroide utilizado no tratamento de inflamações e reações alérgicas.', 'Comprimido', 'Corticosteroide', @NOW, NULL, 1),
            ('Alprazolam 1mg', 'Ansiolítico utilizado para transtornos de ansiedade.', 'Comprimido', 'Ansiolítico', @NOW, NULL, 1),
            ('Amitriptilina 25mg', 'Antidepressivo utilizado também para dor crônica.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Baclofeno 10mg', 'Relaxante muscular usado em espasticidade.', 'Comprimido', 'Musculoesquelético', @NOW, NULL, 1),
            ('Benzetacil 1.200.000UI', 'Antibiótico para infecções bacterianas.', 'Ampola', 'Antibiótico', @NOW, NULL, 1),
            ('Carbocisteína 250mg/5ml', 'Mucolítico utilizado em doenças respiratórias.', 'Xarope', 'Mucolítico', @NOW, NULL, 1),
            ('Cetirizina 10mg', 'Antialérgico para rinite e urticária.', 'Comprimido', 'Antialérgico', @NOW, NULL, 1),
            ('Clobutinol + Doxilamina', 'Antitussígeno e antialérgico para tosse.', 'Xarope', 'Respiratório', @NOW, NULL, 1),
            ('Clopidogrel 75mg', 'Antiplaquetário usado em prevenção de AVC e infarto.', 'Comprimido', 'Antitrombótico', @NOW, NULL, 1),
            ('Codeína 30mg', 'Analgésico opioide para dor moderada.', 'Comprimido', 'Analgésico/Opiáceo', @NOW, @NOW, 0),
            ('Diltiazem 60mg', 'Tratamento de angina e hipertensão.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Doxiciclina 50mg', 'Antibiótico usado para tratar infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Escitalopram 10mg', 'Antidepressivo para depressão e ansiedade.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Espinheira Santa 500mg', 'Fitoterápico para problemas digestivos.', 'Comprimido', 'Fitoterápico', @NOW, NULL, 1),
            ('Finasterida 1mg', 'Tratamento da alopecia androgenética.', 'Comprimido', 'Dermatológico', @NOW, NULL, 1),
            ('Furosemida 20mg', 'Diurético para tratar retenção de líquidos.', 'Comprimido', 'Diurético', @NOW, NULL, 1),
            ('Glicose 50%', 'Solução de glicose para hipoglicemia.', 'Ampola', 'Hidratante/Infusão', @NOW, NULL, 1),
            ('Hioscina 10mg', 'Antiespasmódico para dores abdominais.', 'Comprimido', 'Antiespasmódico', @NOW, NULL, 1),
            ('Isosorbida 20mg', 'Vasodilatador para angina.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Lactulose 667mg/ml', 'Laxante utilizado em constipação.', 'Xarope', 'Laxante', @NOW, NULL, 1),
            ('Lamotrigina 50mg', 'Antiepiléptico e estabilizador de humor.', 'Comprimido', 'Antiepilético', @NOW, NULL, 1),
            ('Lansoprazol 30mg', 'Tratamento de refluxo e úlcera gástrica.', 'Comprimido', 'Antiácido', @NOW, NULL, 1),
            ('Maleato de Enalapril 5mg', 'Tratamento de hipertensão e insuficiência cardíaca.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Meloxicam 15mg', 'Anti-inflamatório para dores articulares.', 'Comprimido', 'Anti-inflamatório', @NOW, NULL, 1),
            ('Montelucaste 10mg', 'Controle de asma e rinite alérgica.', 'Comprimido', 'Respiratório', @NOW, NULL, 1),
            ('Morfina 10mg', 'Analgésico opioide potente.', 'Ampola', 'Analgésico/Opiáceo', @NOW, NULL, 1),
            ('Nifedipino 20mg', 'Anti-hipertensivo e vasodilatador.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Nistatina 100.000UI', 'Antifúngico oral para candidíase.', 'Suspensão', 'Antifúngico', @NOW, NULL, 1),
            ('Nitrofurantoína 100mg', 'Antibiótico para infecção urinária.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Nortriptilina 25mg', 'Antidepressivo tricíclico.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Omeprazol 40mg', 'Tratamento de úlcera e refluxo ácido.', 'Comprimido', 'Antiácido', @NOW, NULL, 1),
            ('Pantoprazol 40mg', 'Inibidor de bomba de prótons para úlceras.', 'Comprimido', 'Antiácido', @NOW, NULL, 1),
            ('Penicilina G Benzatina', 'Antibiótico para sífilis e amigdalite.', 'Ampola', 'Antibiótico', @NOW, NULL, 1),
            ('Propranolol 40mg', 'Beta-bloqueador usado para ansiedade e hipertensão.', 'Comprimido', 'Antihipertensivo', @NOW, @NOW, 0),
            ('Quetiapina 25mg', 'Antipsicótico para esquizofrenia e bipolaridade.', 'Comprimido', 'Antipsicótico', @NOW, NULL, 1),
            ('Rivaroxabana 20mg', 'Anticoagulante oral para prevenção de AVC.', 'Comprimido', 'Anticoagulante', @NOW, NULL, 1),
            ('Sertralina 100mg', 'Antidepressivo para transtornos de humor.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Sulfametoxazol + Trimetoprima', 'Antibiótico para infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Tiamina 300mg', 'Vitamina B1 usada na deficiência e alcoolismo.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Tiamina 100mg', 'Vitamina B1 para suplementação.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Valproato de Sódio 500mg', 'Antiepilético e estabilizador de humor.', 'Comprimido', 'Antiepilético', @NOW, NULL, 1),
            ('Varfarina 5mg', 'Anticoagulante oral usado na prevenção de trombose.', 'Comprimido', 'Anticoagulante', @NOW, NULL, 1),
            ('Verapamil 80mg', 'Tratamento de arritmias e hipertensão.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Vitamina B12 1000mcg', 'Tratamento de deficiência de B12.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Zolmitriptana 2,5mg', 'Tratamento de crises de enxaqueca.', 'Comprimido', 'Neurológico', @NOW, NULL, 1),
            ('Mebendazol 100mg', 'Antiparasitário usado no tratamento de verminoses.', 'Comprimido', 'Antiparasitário', @NOW, NULL, 1),
            ('Bromazepam 3mg', 'Ansiolítico para transtornos de ansiedade.', 'Comprimido', 'Ansiolítico', @NOW, NULL, 1),
            ('Loratadina + Pseudoefedrina', 'Tratamento de rinite alérgica com congestão.', 'Comprimido', 'Antialérgico', @NOW, NULL, 1),
            ('Desloratadina + Betametasona', 'Anti-histamínico e anti-inflamatório.', 'Comprimido', 'Antialérgico', @NOW, NULL, 1),
            ('Ácido Acetilsalicílico 300mg', 'Antiagregante plaquetário.', 'Comprimido', 'Antitrombótico', @NOW, NULL, 1),
            ('Isossorbida Dinitrato 10mg', 'Vasodilatador utilizado em angina.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Perindopril 5mg', 'Anti-hipertensivo inibidor da ECA.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Rosuvastatina 10mg', 'Estatina usada para controlar colesterol.', 'Comprimido', 'Anticolesterol', @NOW, NULL, 1),
            ('Cetoprofeno 100mg', 'Anti-inflamatório para dor e inflamação.', 'Cápsula', 'Anti-inflamatório', @NOW, NULL, 1),
            ('Nimesulida 100mg', 'Analgésico e anti-inflamatório.', 'Comprimido', 'Anti-inflamatório', @NOW, NULL, 1),
            ('Glicose 25%', 'Solução de glicose usada em hipoglicemia.', 'Ampola', 'Hidratante/Infusão', @NOW, NULL, 1),
            ('Ácido Tranexâmico 250mg', 'Antifibrinolítico usado para controle de sangramentos.', 'Comprimido', 'Hemostático', @NOW, NULL, 1),
            ('Sinvastatina 20mg', 'Redutor de colesterol.', 'Comprimido', 'Anticolesterol', @NOW, NULL, 1),
            ('Captopril 12,5mg', 'Anti-hipertensivo para controle da pressão arterial.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Fentanil 100mcg/ml', 'Analgésico opioide potente para dor intensa.', 'Ampola injetável', 'Analgésico/Opiáceo', @NOW, @NOW, 0),
            ('Duloxetina 60mg', 'Antidepressivo para depressão e dor crônica.', 'Cápsula', 'Antidepressivo', @NOW, NULL, 1),
            ('Azitromicina 250mg', 'Antibiótico para infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Vitamina B12 Injetável 1000mcg/ml', 'Suplemento para deficiência de B12.', 'Ampola injetável', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Doxazosina 2mg', 'Alfa-bloqueador para hipertensão e hiperplasia prostática.', 'Comprimido', 'Antihipertensivo/Urológico', @NOW, NULL, 1),
            ('Glucosamina + Condroitina Sachê', 'Suplemento para saúde das articulações.', 'Sachê', 'Suplemento/Articular', @NOW, NULL, 1),
            ('Clonidina 0,100mg', 'Anti-hipertensivo e para crises hipertensivas.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Sulfato Ferroso Xarope', 'Suplemento de ferro líquido para anemia.', 'Xarope', 'Suplemento/Anemia', @NOW, NULL, 1),
            ('Ácido Valproico 500mg', 'Antiepilético e estabilizador de humor.', 'Comprimido', 'Antiepilético', @NOW, NULL, 1),
            ('Metoprolol 50mg', 'Beta-bloqueador para hipertensão e angina.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Fenobarbital 100mg', 'Anticonvulsivante e sedativo.', 'Comprimido', 'Antiepilético', @NOW, NULL, 1),
            ('Coenzima Q10 100mg', 'Suplemento para produção de energia celular e saúde cardíaca.', 'Cápsula', 'Suplemento', @NOW, NULL, 1),
            ('Budesonida 200mcg', 'Corticosteroide inalatório para asma.', 'Cápsula para inalação', 'Respiratório', @NOW, NULL, 1),
            ('Ciclopirox Olamina Esmalte 8%', 'Antifúngico para micose de unha.', 'Esmalte', 'Antifúngico/Dermatológico', @NOW, NULL, 1),
            ('Pazopanibe 200mg', 'Medicamento oncológico para câncer de rim e sarcoma.', 'Comprimido', 'Oncológico', @NOW, NULL, 1),
            ('Ambroxol 30mg', 'Mucolítico para problemas respiratórios.', 'Comprimido', 'Respiratório', @NOW, NULL, 1),
            ('Acarbose 50mg', 'Inibidor de alfa-glicosidase para diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Valsartana 80mg', 'Anti-hipertensivo para controle da pressão arterial.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Mupirocina Pomada 2%', 'Antibiótico tópico para infecções de pele.', 'Pomada', 'Antibiótico/Dermatológico', @NOW, NULL, 1),
            ('Piroxicam 20mg', 'Anti-inflamatório não esteroide para dores e inflamações.', 'Comprimido', 'Anti-inflamatório', @NOW, NULL, 1),
            ('Metotrexato 2,5mg', 'Imunossupressor e quimioterápico.', 'Comprimido', 'Reumatológico/Oncológico', @NOW, NULL, 1),
            ('Tacrolimus 1mg', 'Imunossupressor para transplantes.', 'Cápsula', 'Imunomodulador', @NOW, NULL, 1),
            ('Ambroxol 15mg/5ml', 'Mucolítico e expectorante para tosse com catarro.', 'Xarope', 'Respiratório', @NOW, NULL, 1),
            ('Liraglutida 6mg/ml', 'Agonista GLP-1 para diabetes tipo 2 e obesidade.', 'Caneta injetora', 'Antidiabético/Obesidade', @NOW, NULL, 1),
            ('Permetrina Loção 5%', 'Escabicida e pediculicida para sarna e piolho.', 'Loção', 'Dermatológico/Parasiticida', @NOW, NULL, 1),
            ('Acetilcisteína 200mg', 'Mucolítico para doenças respiratórias, facilitando a expectoração.', 'Granulado', 'Respiratório', @NOW, NULL, 1),
            ('Dutasterida 0,5mg', 'Tratamento de HPB e alopecia androgenética.', 'Cápsula', 'Urológico/Dermatológico', @NOW, NULL, 1),
            ('Ácido Fusídico Creme 2%', 'Antibiótico tópico para infecções de pele.', 'Creme', 'Antibiótico/Dermatológico', @NOW, NULL, 1),
            ('Trazodona 100mg', 'Antidepressivo para depressão com ansiedade e insônia.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Insulina Degludeca 100UI/ml', 'Insulina basal ultra-longa duração.', 'Caneta', 'Hormônio/Insulina', @NOW, NULL, 1),
            ('Hidroclorotiazida + Losartana 50/12.5mg', 'Combinação para controle de hipertensão.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Sulfato Ferroso Gotas', 'Suplemento de ferro para lactentes e crianças.', 'Solução oral (Gotas)', 'Suplemento/Anemia/Pediatria', @NOW, NULL, 1),
            ('Progesterona Cápsula 100mg', 'Hormônio para terapia de reposição hormonal e fertilidade.', 'Cápsula', 'Hormônio/Ginecológico', @NOW, NULL, 1),
            ('Nistatina Suspensão Oral 100.000UI/ml', 'Antifúngico oral para candidíase.', 'Suspensão oral', 'Antifúngico/Pediatria', @NOW, NULL, 1),
            ('Metoprolol 100mg', 'Controle da pressão arterial e ritmo cardíaco.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Tacrolimus Pomada 0,1%', 'Imunomodulador tópico para dermatite atópica.', 'Pomada', 'Dermatológico/Imunomodulador', @NOW, NULL, 1),
            ('Tadalafila 5mg (uso diário)', 'Tratamento de disfunção erétil e HPB (uso diário).', 'Comprimido', 'Urológico', @NOW, @NOW, 0),
            ('Gliclazida 30mg MR', 'Antidiabético oral de liberação modificada.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Olanzapina 5mg', 'Antipsicótico para esquizofrenia e transtorno bipolar.', 'Comprimido', 'Antipsicótico', @NOW, NULL, 1),
            ('Imipramina 25mg', 'Antidepressivo tricíclico.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Flúor Dental 0,05%', 'Para prevenção de cáries.', 'Gel dental', 'Odontológico', @NOW, NULL, 1),
            ('Óleo de Peixe (Ômega 3) 1000mg', 'Suplemento para saúde cardiovascular e cerebral.', 'Cápsula', 'Suplemento', @NOW, NULL, 1),
            ('Pimecrolimus Creme 1%', 'Imunomodulador tópico para dermatite atópica leve a moderada.', 'Creme', 'Dermatológico/Imunomodulador', @NOW, NULL, 1),
            ('Sulfadiazina de Prata Creme 1%', 'Antimicrobiano tópico para queimaduras.', 'Creme', 'Dermatológico', @NOW, NULL, 1),
            ('Peróxido de Benzoíla Gel 5%', 'Tratamento tópico para acne.', 'Gel', 'Dermatológico', @NOW, NULL, 1),
            ('Ramipril 10mg', 'Tratamento de hipertensão e redução de risco cardiovascular.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Gliclazida 60mg MR', 'Controle de diabetes tipo 2 com liberação prolongada.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Prednisolona 3mg/ml', 'Corticosteroide oral para crianças.', 'Xarope', 'Corticosteroide/Pediatria', @NOW, NULL, 1),
            ('Valaciclovir 500mg', 'Antiviral para herpes.', 'Comprimido', 'Antiviral', @NOW, NULL, 1),
            ('Fenobarbital Solução Oral 2mg/ml', 'Anticonvulsivante para uso pediátrico.', 'Solução oral', 'Antiepilético/Pediatria', @NOW, NULL, 1),
            ('Dapagliflozina 10mg', 'Inibidor SGLT2 para diabetes tipo 2 e insuficiência cardíaca.', 'Comprimido', 'Antidiabético/Cardiovascular', @NOW, @NOW, 0),
            ('Azatioprina 50mg', 'Imunossupressor para transplantes e doenças autoimunes.', 'Comprimido', 'Imunomodulador', @NOW, NULL, 1),
            ('Isosorbida Dinitrato 5mg Sublingual', 'Vasodilatador para alívio rápido de angina.', 'Comprimido sublingual', 'Cardiovascular', @NOW, NULL, 1),
            ('Esomeprazol 40mg', 'Tratamento de refluxo gastroesofágico severo.', 'Cápsula', 'Antiácido', @NOW, NULL, 1),
            ('Albendazol Suspensão 40mg/ml', 'Antiparasitário para verminoses.', 'Suspensão oral', 'Antiparasitário', @NOW, NULL, 1),
            ('Glipizida 5mg', 'Sulfonilureia para diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Minoxidil Solução Tópica 5%', 'Tratamento tópico para alopecia androgenética.', 'Solução tópica', 'Dermatológico', @NOW, NULL, 1),
            ('Adapaleno Gel 0,1%', 'Retinoide para acne.', 'Gel', 'Dermatológico', @NOW, NULL, 1),
            ('Loratadina Xarope 1mg/ml', 'Antialérgico para crianças.', 'Xarope', 'Antialérgico/Pediatria', @NOW, NULL, 1),
            ('Semaglutida 0,25mg', 'Agonista GLP-1 para diabetes tipo 2 e perda de peso.', 'Caneta injetora', 'Antidiabético/Obesidade', @NOW, NULL, 1),
            ('Morfina Solução Oral 10mg/ml', 'Analgésico opioide potente.', 'Solução oral', 'Analgésico/Opiáceo', @NOW, NULL, 1),
            ('Cloridrato de Bupropiona 150mg', 'Antidepressivo e auxiliar na cessação do tabagismo.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Carvedilol 6,25mg', 'Beta-bloqueador para hipertensão e insuficiência cardíaca.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Vitamina E 400UI', 'Antioxidante e para saúde da pele.', 'Cápsula', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Tretinoína Creme 0,025%', 'Retinoide para acne e rejuvenescimento.', 'Creme', 'Dermatológico', @NOW, NULL, 1),
            ('Chá Verde', 'Termogênico e antioxidante.', 'Sachê', 'Fitoterápico', @NOW, NULL, 1),
            ('Glatiramer Acetato 20mg', 'Tratamento da esclerose múltipla.', 'Seringa preenchida', 'Neurológico/Imunomodulador', @NOW, NULL, 1),
            ('Citrato de Sildenafila 50mg', 'Tratamento de disfunção erétil.', 'Comprimido', 'Urológico', @NOW, @NOW, 0),
            ('Hidralazina 25mg', 'Vasodilatador para hipertensão grave.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Biotina 5mg', 'Suplemento para cabelo, pele e unhas.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Metotrexato 25mg/ml Injetável', 'Quimioterápico para doenças autoimunes e câncer.', 'Solução injetável', 'Reumatológico/Oncológico', @NOW, NULL, 1),
            ('Nitrato de Miconazol Creme 2%', 'Antifúngico tópico para micoses de pele.', 'Creme', 'Antifúngico/Dermatológico', @NOW, NULL, 1),
            ('Ácido Zoledrônico 5mg/100ml', 'Bifosfonato para osteoporose e hipercalcemia da malignidade.', 'Solução para infusão', 'Saúde Óssea', @NOW, NULL, 1),
            ('Permetrina Xampu 1%', 'Pediculicida para tratamento de piolhos.', 'Xampu', 'Dermatológico/Pediatria', @NOW, NULL, 1),
            ('Pantoprazol Sódico 20mg', 'Inibidor de bomba de prótons para refluxo.', 'Comprimido revestido', 'Antiácido', @NOW, NULL, 1),
            ('Donepezila 5mg', 'Tratamento da doença de Alzheimer.', 'Comprimido', 'Neurológico', @NOW, NULL, 1),
            ('Carbamazepina 200mg Suspensão Oral', 'Antiepilético para epilepsia.', 'Suspensão oral', 'Antiepilético', @NOW, NULL, 1),
            ('Alprazolam 0,5mg', 'Ansiolítico para transtornos de ansiedade e pânico.', 'Comprimido', 'Ansiolítico', @NOW, NULL, 1),
            ('Tiamazol 10mg', 'Antitireoidiano para hipertireoidismo.', 'Comprimido', 'Hormônio/Tireoide', @NOW, NULL, 1),
            ('Cúrcuma (Curcumina) 500mg', 'Anti-inflamatório natural.', 'Cápsula', 'Fitoterápico/Suplemento', @NOW, NULL, 1),
            ('Tiamina 50mg', 'Suplemento de Vitamina B1.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Furosemida 10mg/ml', 'Diurético injetável para edemas e hipertensão.', 'Ampola injetável', 'Diurético', @NOW, NULL, 1),
            ('Ramipril 5mg', 'Inibidor da ECA para hipertensão e proteção cardiovascular.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Ginseng Siberiano', 'Adaptógeno para energia e estresse.', 'Cápsula', 'Fitoterápico', @NOW, NULL, 1),
            ('Nitrofural Pomada 0,2%', 'Antisséptico tópico para feridas e queimaduras.', 'Pomada', 'Antisséptico/Dermatológico', @NOW, NULL, 1),
            ('Sulfato de Glicosamina + Condroitina', 'Suplemento para saúde das articulações.', 'Comprimido', 'Suplemento/Articular', @NOW, NULL, 1),
            ('Dramin B6', 'Antiemético para náuseas e vômitos.', 'Comprimido', 'Antiemético', @NOW, NULL, 1),
            ('Glibenclamida 2.5mg', 'Antidiabético oral para diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Ureia Creme 20%', 'Hidratante para queratose pilar e pele áspera.', 'Creme', 'Dermatológico', @NOW, NULL, 1),
            ('Amiodarona 200mg', 'Antiarrítmico para tratamento de arritmias cardíacas.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Brometo de Piridostigmina 60mg', 'Tratamento da miastenia gravis.', 'Comprimido', 'Neurológico', @NOW, NULL, 1),
            ('Alendronato 70mg', 'Bifosfonato para osteoporose (uso semanal).', 'Comprimido', 'Saúde Óssea', @NOW, NULL, 1),
            ('Dramin B6 DM', 'Antiemético e antitussígeno.', 'Xarope', 'Antiemético/Respiratório', @NOW, NULL, 1),
            ('Metronidazol Gel 0,75%', 'Antibiótico e anti-inflamatório tópico para rosácea.', 'Gel', 'Dermatológico/Antibiótico', @NOW, NULL, 1),
            ('Rosiglitazona 4mg', 'Tiazolidinediona para diabetes tipo 2 (uso restrito).', 'Comprimido', 'Antidiabético', @NOW, @NOW, 0),
            ('Valsartana 160mg', 'Anti-hipertensivo para casos de hipertensão mais severa.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Digoxina Xarope 0,05mg/ml', 'Cardiotônico para crianças.', 'Xarope', 'Cardiovascular/Pediatria', @NOW, NULL, 1),
            ('Carvão Ativado 250mg', 'Adsorvente para intoxicações e gases.', 'Cápsula', 'Gastrointestinal', @NOW, NULL, 1),
            ('Quetiapina 100mg', 'Antipsicótico para esquizofrenia e transtorno bipolar.', 'Comprimido', 'Antipsicótico', @NOW, NULL, 1),
            ('Vitamina K1 10mg', 'Vitamina para coagulação sanguínea.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Anlodipino 10mg', 'Anti-hipertensivo para pressão arterial e angina.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Propranolol Retard 80mg', 'Beta-bloqueador de liberação prolongada.', 'Cápsula', 'Cardiovascular', @NOW, NULL, 1),
            ('Carvedilol 12,5mg', 'Beta-bloqueador para controle de doenças cardíacas.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Buspirona 10mg', 'Ansiolítico para tratamento de ansiedade.', 'Comprimido', 'Ansiolítico', @NOW, NULL, 1),
            ('Verapamil 40mg', 'Bloqueador de canal de cálcio para arritmias e hipertensão.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Anlodipino 5mg', 'Anti-hipertensivo e antianginoso.', 'Comprimido', 'Antihipertensivo', @NOW, @NOW, 0),
            ('Aceclofenaco 100mg', 'Anti-inflamatório não esteroide para dor e inflamação.', 'Comprimido', 'Anti-inflamatório', @NOW, NULL, 1),
            ('Bromazepam 6mg', 'Ansiolítico para transtornos de ansiedade e insônia.', 'Comprimido', 'Ansiolítico', @NOW, NULL, 1),
            ('Budesonida 400mcg', 'Corticosteroide inalatório para controle de asma severa.', 'Cápsula para inalação', 'Respiratório', @NOW, NULL, 1),
            ('Cefalexina 250mg/5ml', 'Antibiótico para infecções diversas.', 'Suspensão oral', 'Antibiótico', @NOW, NULL, 1),
            ('Cloridrato de Amoxapina 50mg', 'Antidepressivo tricíclico.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Dienogeste 2mg', 'Progestágeno para tratamento de endometriose.', 'Comprimido', 'Hormônio/Ginecológico', @NOW, NULL, 1),
            ('Duloxetina 30mg', 'Antidepressivo e analgésico para dor neuropática.', 'Cápsula', 'Antidepressivo', @NOW, NULL, 1),
            ('Empagliflozina 10mg', 'Inibidor SGLT2 para diabetes tipo 2 e insuficiência cardíaca.', 'Comprimido', 'Antidiabético/Cardiovascular', @NOW, NULL, 1),
            ('Esomeprazol 20mg', 'Inibidor de bomba de prótons para refluxo e úlceras.', 'Cápsula', 'Antiácido', @NOW, NULL, 1),
            ('Gabapentina 300mg', 'Anticonvulsivante e para dor neuropática.', 'Cápsula', 'Neurológico', @NOW, NULL, 1),
            ('Hidroclorotiazida 50mg', 'Diurético para hipertensão e edemas.', 'Comprimido', 'Diurético', @NOW, NULL, 1),
            ('Ibuprofeno Suspensão 100mg/ml', 'Analgésico e anti-inflamatório para crianças.', 'Suspensão oral', 'Anti-inflamatório/Pediatria', @NOW, NULL, 1),
            ('Irbesartana 150mg', 'Anti-hipertensivo para controle da pressão arterial.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Isossorbida Mononitrato 20mg', 'Vasodilatador para profilaxia de angina.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Cetoconazol Creme 2%', 'Antifúngico tópico para infecções de pele.', 'Creme', 'Antifúngico/Dermatológico', @NOW, NULL, 1),
            ('Lactobacillus reuteri', 'Probiótico para saúde gastrointestinal.', 'Sachê', 'Probiótico', @NOW, NULL, 1),
            ('Lamotrigina 25mg', 'Antiepiléptico e estabilizador de humor.', 'Comprimido', 'Antiepilético', @NOW, NULL, 1),
            ('Lansoprazol 15mg', 'Inibidor de bomba de prótons para úlceras e refluxo.', 'Cápsula', 'Antiácido', @NOW, NULL, 1),
            ('Levotiroxina Sódica 25mcg', 'Reposição hormonal para hipotireoidismo.', 'Comprimido', 'Hormônio/Tireoide', @NOW, NULL, 1),
            ('Lisinopril 20mg', 'Inibidor da ECA para hipertensão.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Maleato de Enalapril 20mg', 'Inibidor da ECA para hipertensão e insuficiência cardíaca.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Mesalazina 400mg', 'Anti-inflamatório intestinal para doença de Crohn e colite ulcerativa.', 'Comprimido', 'Gastrointestinal', @NOW, NULL, 1),
            ('Nimesulida Gel 2%', 'Anti-inflamatório tópico para dores musculares e traumáticas.', 'Gel', 'Anti-inflamatório/Tópico', @NOW, NULL, 1),
            ('Nistatina Creme Vaginal 250.000UI', 'Antifúngico para candidíase vaginal.', 'Creme vaginal', 'Antifúngico/Ginecológico', @NOW, NULL, 1),
            ('Norfloxacino 400mg', 'Antibiótico para infecções urinárias.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Olanzapina 10mg', 'Antipsicótico para transtornos psicóticos severos.', 'Comprimido', 'Antipsicótico', @NOW, NULL, 1),
            ('Omeprazol Cápsula 20mg', 'Inibidor de bomba de prótons para tratamento de úlceras.', 'Cápsula', 'Antiácido', @NOW, NULL, 1),
            ('Ondansetrona 8mg', 'Antiemético para náuseas e vômitos mais severos.', 'Comprimido', 'Antiemético', @NOW, NULL, 1),
            ('Pantoprazol 20mg', 'Inibidor de bomba de prótons para azia e refluxo.', 'Comprimido', 'Antiácido', @NOW, NULL, 1),
            ('Paracetamol Solução Oral 200mg/ml', 'Analgésico e antitérmico para bebês.', 'Solução oral', 'Analgésico/Antitérmico/Pediatria', @NOW, NULL, 1),
            ('Pazopanibe 400mg', 'Medicamento oncológico para tratamento de câncer.', 'Comprimido', 'Oncológico', @NOW, NULL, 1),
            ('Pregabalina 75mg', 'Analgésico para dor neuropática e fibromialgia.', 'Cápsula', 'Neurológico', @NOW, NULL, 1),
            ('Pregabalina 150mg', 'Tratamento de dor neuropática e convulsões.', 'Cápsula', 'Neurológico', @NOW, NULL, 1),
            ('Quetiapina 200mg', 'Antipsicótico para casos mais severos.', 'Comprimido', 'Antipsicótico', @NOW, NULL, 1),
            ('Risperidona 1mg', 'Antipsicótico para esquizofrenia e transtorno bipolar.', 'Comprimido', 'Antipsicótico', @NOW, NULL, 1),
            ('Risperidona 3mg', 'Antipsicótico para transtornos mentais graves.', 'Comprimido', 'Antipsicótico', @NOW, NULL, 1),
            ('Salbutamol Aerossol 100mcg/dose', 'Broncodilatador de alívio rápido para asma.', 'Aerossol dosimetrado', 'Respiratório', @NOW, NULL, 1),
            ('Sulfametoxazol + Trimetoprima Suspensão', 'Antibiótico para infecções bacterianas.', 'Suspensão oral', 'Antibiótico', @NOW, NULL, 1),
            ('Tramadol Gotas 100mg/ml', 'Analgésico opioide para dor moderada a intensa.', 'Solução oral (Gotas)', 'Analgésico/Opiáceo', @NOW, NULL, 1),
            ('Trazodona 50mg', 'Antidepressivo e sedativo para insônia.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Fentermina 37.5mg', 'Anorexígeno para tratamento de obesidade.', 'Cápsula', 'Obesidade', @NOW, NULL, 1),
            ('Espirolactona 25mg', 'Diurético poupador de potássio.', 'Comprimido', 'Diurético', @NOW, NULL, 1),
            ('Gliclazida 40mg', 'Antidiabético oral para diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Buspirona 5mg', 'Ansiolítico não benzodiazepínico.', 'Comprimido', 'Ansiolítico', @NOW, NULL, 1),
            ('Acetilcisteína 600mg', 'Mucolítico para dissolver o muco em doenças respiratórias.', 'Comprimido efervescente', 'Respiratório', @NOW, NULL, 1),
            ('Doxiciclina 200mg', 'Antibiótico para acne, rosácea e outras infecções.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Digoxina 0,25mg', 'Cardiotônico para insuficiência cardíaca e arritmias.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Cloridrato de Venlafaxina 75mg', 'Antidepressivo para transtornos de ansiedade.', 'Cápsula de liberação prolongada', 'Antidepressivo', @NOW, NULL, 1),
            ('Arípripazol 15mg', 'Antipsicótico para doenças psicóticas.', 'Comprimido', 'Antipsicótico', @NOW, NULL, 1),
            ('Ciprofloxacino 250mg', 'Antibiótico para infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, NULL, 1),
            ('Hidroxicloroquina 200mg', 'Antimalárico e imunomodulador.', 'Comprimido', 'Imunomodulador', @NOW, NULL, 1),
            ('Bissulfato de Clopidogrel 75mg', 'Antiplaquetário para prevenção de eventos cardiovasculares.', 'Comprimido', 'Antitrombótico', @NOW, NULL, 1),
            ('Clortalidona 12,5mg', 'Diurético tiazídico para hipertensão.', 'Comprimido', 'Diurético', @NOW, NULL, 1),
            ('Gabapentina 400mg', 'Tratamento de convulsões e dor neuropática.', 'Cápsula', 'Neurológico', @NOW, NULL, 1),
            ('Mebendazol Suspensão 20mg/ml', 'Antiparasitário para verminoses em crianças.', 'Suspensão oral', 'Antiparasitário/Pediatria', @NOW, NULL, 1),
            ('Nifedipino Oros 30mg', 'Anti-hipertensivo de liberação controlada.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Bacitracina + Neomicina Pomada', 'Antibiótico tópico para cortes e arranhões.', 'Pomada', 'Antibiótico/Dermatológico', @NOW, NULL, 1),
            ('Lamotrigina 100mg', 'Antiepiléptico e estabilizador de humor.', 'Comprimido', 'Antiepilético', @NOW, NULL, 1),
            ('Risedronato 35mg', 'Bifosfonato para osteoporose (uso semanal).', 'Comprimido', 'Saúde Óssea', @NOW, NULL, 1),
            ('Ácido Fólico 0,2mg', 'Suplemento para gestantes e prevenção de anemia.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Cloreto de Magnésio Hexahidratado', 'Suplemento de magnésio.', 'Comprimido', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Chá de Hibisco', 'Diurético e antioxidante natural.', 'Sachê', 'Fitoterápico', @NOW, NULL, 1),
            ('Feno Grego 500mg', 'Auxiliar no controle de glicemia e libido.', 'Cápsula', 'Fitoterápico/Metabólico', @NOW, NULL, 1),
            ('Implante Contraceptivo (Etonogestrel)', 'Anticoncepcional de longa duração.', 'Implante', 'Hormônio/Contraceptivo', @NOW, NULL, 1),
            ('Minoxidil 10mg', 'Vasodilatador para hipertensão (também para calvície).', 'Comprimido', 'Antihipertensivo/Dermatológico', @NOW, NULL, 1),
            ('Tansulosina 0,4mg', 'Alfa-bloqueador para hiperplasia prostática benigna (HPB).', 'Cápsula', 'Urológico', @NOW, NULL, 1),
            ('Clonazepam 0,5mg', 'Ansiolítico e anticonvulsivante.', 'Comprimido', 'Ansiolítico', @NOW, NULL, 1),
            ('Naltrexona 50mg', 'Antagonista opioide para dependência.', 'Comprimido', 'Antídoto', @NOW, NULL, 1),
            ('Citalopram 20mg', 'Antidepressivo ISRS para depressão e pânico.', 'Comprimido', 'Antidepressivo', @NOW, NULL, 1),
            ('Atenolol 25mg', 'Beta-bloqueador para hipertensão leve.', 'Comprimido', 'Cardiovascular', @NOW, @NOW, 0),
            ('Propranolol 20mg', 'Beta-bloqueador para hipertensão e ansiedade.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Cloridrato de Propranolol 80mg', 'Beta-bloqueador para hipertensão, angina e enxaqueca.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Domperidona 10mg', 'Antiemético e procinético.', 'Comprimido', 'Antiemético', @NOW, NULL, 1),
            ('Óleo de Linhaça 1000mg', 'Suplemento de ômega 3 e 6.', 'Cápsula', 'Suplemento', @NOW, NULL, 1),
            ('Semaglutida 0,5mg', 'Agonista GLP-1 para diabetes tipo 2 e perda de peso.', 'Caneta injetora', 'Antidiabético/Obesidade', @NOW, NULL, 1),
            ('Pramipexol 0,25mg', 'Agonista dopaminérgico para Parkinson.', 'Comprimido', 'Neurológico', @NOW, NULL, 1),
            ('Rivastigmina 1,5mg', 'Inibidor de colinesterase para Alzheimer.', 'Cápsula', 'Neurológico', @NOW, NULL, 1),
            ('Curcuma com Piperina', 'Anti-inflamatório natural com maior absorção.', 'Cápsula', 'Fitoterápico/Suplemento', @NOW, NULL, 1),
            ('Cetoconazol Xampu 2%', 'Antifúngico para caspa e seborreia.', 'Xampu', 'Dermatológico', @NOW, NULL, 1),
            ('Hidrocortisona Creme 1%', 'Corticosteroide leve para inflamações e coceiras.', 'Creme', 'Dermatológico', @NOW, NULL, 1),
            ('Testosterona Gel 1%', 'Hormônio para reposição hormonal masculina.', 'Gel tópico', 'Hormônio', @NOW, NULL, 1),
            ('Estradiol Adesivo Transdérmico 0,1mg/dia', 'Hormônio para terapia de reposição hormonal.', 'Adesivo transdérmico', 'Hormônio/Ginecológico', @NOW, NULL, 1),
            ('Drosperinona + Etinilestradiol', 'Anticoncepcional oral combinado.', 'Comprimido', 'Hormônio/Contraceptivo', @NOW, NULL, 1),
            ('Levonorgestrel 0,75mg', 'Anticoncepcional de emergência.', 'Comprimido', 'Hormônio/Contraceptivo', @NOW, NULL, 1),
            ('DIU Hormonal (Levonorgestrel)', 'Dispositivo intrauterino hormonal.', 'Dispositivo intrauterino', 'Hormônio/Contraceptivo', @NOW, NULL, 1),
            ('Terazosina 2mg', 'Alfa-bloqueador para HPB e hipertensão.', 'Comprimido', 'Urológico/Antihipertensivo', @NOW, NULL, 1),
            ('Combodart (Dutasterida + Tansulosina)', 'Combinação para HPB.', 'Cápsula', 'Urológico', @NOW, NULL, 1),
            ('Clotrimazol Creme 1%', 'Antifúngico tópico para infecções de pele.', 'Creme', 'Antifúngico/Dermatológico', @NOW, NULL, 1),
            ('Clindamicina Gel 1%', 'Antibiótico tópico para acne.', 'Gel', 'Dermatológico', @NOW, NULL, 1),
            ('Ácido Salicílico 2%', 'Queratolítico para acne, psoríase e calos.', 'Loção', 'Dermatológico', @NOW, NULL, 1),
            ('Ureia Creme 10%', 'Hidratante e queratolítico para pele seca.', 'Creme', 'Dermatológico', @NOW, NULL, 1),
            ('Triancinolona Acetonida Creme 0,1%', 'Corticosteroide tópico para inflamações e alergias.', 'Creme', 'Dermatológico', @NOW, NULL, 1),
            ('Betametasona + Ácido Salicílico Loção', 'Corticosteroide e queratolítico para psoríase.', 'Loção', 'Dermatológico', @NOW, NULL, 1),
            ('Clobetasol Propionato Creme 0,05%', 'Corticosteroide superpotente para dermatoses severas.', 'Creme', 'Dermatológico', @NOW, NULL, 1),
            ('Alopurinol 300mg', 'Redutor de ácido úrico para gota e cálculos renais.', 'Comprimido', 'Reumatológico/Urológico', @NOW, NULL, 1),
            ('Rivastigmina Adesivo Transdérmico 4.6mg/24h', 'Inibidor de colinesterase para doença de Alzheimer.', 'Adesivo transdérmico', 'Neurológico', @NOW, NULL, 1),
            ('Deferasirox 360mg', 'Quelante de ferro para sobrecarga de ferro crônica.', 'Comprimido dispersível', 'Hematológico', @NOW, NULL, 1),
            ('Saxagliptina 5mg', 'Inibidor da DPP-4 para diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Sitagliptina 100mg', 'Inibidor da DPP-4 para diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Vildagliptina 50mg', 'Inibidor da DPP-4 para diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Linagliptina 5mg', 'Inibidor da DPP-4 para diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, NULL, 1),
            ('Dutasterida + Tansulosina', 'Combinação para tratamento de hiperplasia prostática benigna (HPB).', 'Cápsula', 'Urológico', @NOW, NULL, 1),
            ('Silodosina 8mg', 'Alfa-bloqueador para hiperplasia prostática benigna (HPB).', 'Cápsula', 'Urológico', @NOW, NULL, 1),
            ('Finasterida 5mg', 'Inibidor da 5-alfa-redutase para hiperplasia prostática benigna (HPB).', 'Comprimido', 'Urológico', @NOW, NULL, 1),
            ('Solifenacina 5mg', 'Antagonista muscarínico para bexiga hiperativa.', 'Comprimido', 'Urológico', @NOW, NULL, 1),
            ('Mirabegrona 50mg', 'Agonista beta-3 adrenérgico para bexiga hiperativa.', 'Comprimido', 'Urológico', @NOW, NULL, 1),
            ('Fesoterodina 4mg', 'Antagonista muscarínico para bexiga hiperativa.', 'Comprimido de liberação prolongada', 'Urológico', @NOW, NULL, 1),
            ('Cloreto de Oxibutinina 5mg', 'Antiespasmódico urinário para bexiga hiperativa.', 'Comprimido', 'Urológico', @NOW, NULL, 1),
            ('Trospio 20mg', 'Antagonista muscarínico para bexiga hiperativa.', 'Comprimido', 'Urológico', @NOW, NULL, 1),
            ('Darifenacina 7.5mg', 'Antagonista muscarínico para bexiga hiperativa.', 'Comprimido de liberação prolongada', 'Urológico', @NOW, NULL, 1),
            ('Bicalutamida 50mg', 'Antiandrogênio para câncer de próstata.', 'Comprimido', 'Oncológico', @NOW, NULL, 1),
            ('Enzalutamida 40mg', 'Inibidor do receptor androgênico para câncer de próstata.', 'Cápsula', 'Oncológico', @NOW, NULL, 1),
            ('Abiraterona 250mg', 'Inibidor da biossíntese de androgênios para câncer de próstata.', 'Comprimido', 'Oncológico', @NOW, NULL, 1),
            ('Leuprorrelina 3.75mg', 'Agonista do GnRH para câncer de próstata e endometriose.', 'Ampola injetável', 'Oncológico/Hormônio', @NOW, NULL, 1),
            ('Goserrelina 3.6mg', 'Agonista do GnRH para câncer de próstata e mama.', 'Implante subcutâneo', 'Oncológico/Hormônio', @NOW, NULL, 1),
            ('Anastrozol 1mg', 'Inibidor da aromatase para câncer de mama.', 'Comprimido', 'Oncológico/Hormônio', @NOW, NULL, 1),
            ('Letrozol 2.5mg', 'Inibidor da aromatase para câncer de mama.', 'Comprimido', 'Oncológico/Hormônio', @NOW, NULL, 1),
            ('Tamoxifeno 20mg', 'Modulador seletivo do receptor de estrogênio para câncer de mama.', 'Comprimido', 'Oncológico/Hormônio', @NOW, NULL, 1),
            ('Trastuzumabe 150mg', 'Anticorpo monoclonal para câncer de mama HER2-positivo.', 'Pó para solução injetável', 'Oncológico', @NOW, NULL, 1),
            ('Rituximabe 100mg', 'Anticorpo monoclonal para linfoma e artrite reumatoide.', 'Solução injetável', 'Oncológico/Imunomodulador', @NOW, NULL, 1),
            ('Ciclofosfamida 50mg', 'Agente alquilante para câncer e doenças autoimunes.', 'Comprimido', 'Oncológico/Imunomodulador', @NOW, NULL, 1),
            ('Metotrexato 10mg', 'Antimetabólito para câncer e doenças autoimunes.', 'Comprimido', 'Oncológico/Reumatológico', @NOW, NULL, 1),
            ('Paclitaxel 100mg', 'Agente antineoplásico para câncer de mama, ovário e pulmão.', 'Solução para infusão', 'Oncológico', @NOW, NULL, 1),
            ('Cisplatina 50mg', 'Agente alquilante para diversos tipos de câncer.', 'Solução para infusão', 'Oncológico', @NOW, NULL, 1),
            ('Fluorouracil 500mg', 'Antimetabólito para câncer gastrointestinal e de mama.', 'Solução para infusão', 'Oncológico', @NOW, NULL, 1),
            ('Leucovorina 50mg', 'Antídoto para metotrexato.', 'Pó para solução injetável', 'Oncológico/Antídoto', @NOW, NULL, 1),
            ('Oximetolona 50mg', 'Esteróide anabolizante para anemias e perda de peso.', 'Comprimido', 'Hematológico', @NOW, @NOW, 0),
            ('Filgrastim 300mcg', 'Fator estimulador de colônias de granulócitos para neutropenia.', 'Seringa preenchida', 'Hematológico', @NOW, NULL, 1),
            ('Eritropoetina Alfa 4000UI', 'Estimulador da eritropoiese para anemia.', 'Seringa preenchida', 'Hematológico', @NOW, NULL, 1),
            ('Ferro Sacarato Injetável 100mg', 'Suplemento de ferro intravenoso para anemia severa.', 'Ampola injetável', 'Suplemento/Anemia', @NOW, NULL, 1),
            ('Ácido Fólico 1mg', 'Suplemento para anemia megaloblástica e gestação.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Hidroxiureia 500mg', 'Antineoplásico para leucemia e anemia falciforme.', 'Cápsula', 'Oncológico/Hematológico', @NOW, NULL, 1),
            ('Deflazacorte 6mg', 'Corticosteroide para doenças inflamatórias e autoimunes.', 'Comprimido', 'Corticosteroide', @NOW, NULL, 1),
            ('Fluticasona Propionato Spray Nasal 50mcg/dose', 'Corticosteroide para rinite alérgica.', 'Spray nasal', 'Respiratório/Antialérgico', @NOW, NULL, 1),
            ('Mometasona Furoato Spray Nasal 50mcg/dose', 'Corticosteroide para rinite alérgica e pólipos nasais.', 'Spray nasal', 'Respiratório/Antialérgico', @NOW, NULL, 1),
            ('Budesonida Spray Nasal 64mcg/dose', 'Corticosteroide para rinite alérgica.', 'Spray nasal', 'Respiratório/Antialérgico', @NOW, NULL, 1),
            ('Fexofenadina 180mg', 'Antialérgico não-sedante para urticária e rinite alérgica.', 'Comprimido', 'Antialérgico', @NOW, NULL, 1),
            ('Ebastina 10mg', 'Antialérgico para rinite e urticária.', 'Comprimido', 'Antialérgico', @NOW, NULL, 1),
            ('Bilastina 20mg', 'Antialérgico para rinite alérgica e urticária.', 'Comprimido', 'Antialérgico', @NOW, NULL, 1),
            ('Desloratadina Xarope 0,5mg/ml', 'Antialérgico para crianças.', 'Xarope', 'Antialérgico/Pediatria', @NOW, NULL, 1),
            ('Levocetirizina 5mg', 'Antialérgico para rinite e urticária.', 'Comprimido', 'Antialérgico', @NOW, NULL, 1),
            ('Rosuvastatina 20mg', 'Estatina de alta potência para hipercolesterolemia.', 'Comprimido', 'Anticolesterol', @NOW, NULL, 1),
            ('Atorvastatina 40mg', 'Estatina para redução de colesterol.', 'Comprimido', 'Anticolesterol', @NOW, NULL, 1),
            ('Sinvastatina 80mg', 'Estatina para dislipidemia severa.', 'Comprimido', 'Anticolesterol', @NOW, NULL, 1),
            ('Ezetimiba 10mg', 'Inibidor da absorção de colesterol.', 'Comprimido', 'Anticolesterol', @NOW, NULL, 1),
            ('Pravastatina 20mg', 'Estatina para redução de colesterol.', 'Comprimido', 'Anticolesterol', @NOW, NULL, 1),
            ('Fenofibrato 160mg', 'Fibrato para hipertrigliceridemia.', 'Cápsula', 'Anticolesterol', @NOW, NULL, 1),
            ('Niacina (Vitamina B3) 500mg', 'Redutor de colesterol e triglicerídeos.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Colestiramina 4g', 'Resina sequestradora de ácidos biliares para hipercolesterolemia.', 'Sachê', 'Anticolesterol', @NOW, NULL, 1),
            ('Lercanidipino 10mg', 'Bloqueador de canal de cálcio para hipertensão.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Indapamida 1.5mg', 'Diurético tiazídico-like para hipertensão.', 'Comprimido de liberação prolongada', 'Diurético', @NOW, NULL, 1),
            ('Bisoprolol 5mg', 'Beta-bloqueador para hipertensão e insuficiência cardíaca.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Nebivolol 5mg', 'Beta-bloqueador seletivo para hipertensão e insuficiência cardíaca.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Propranolol 10mg', 'Beta-bloqueador para hipertensão, angina, enxaqueca e ansiedade.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Candesartana 8mg', 'Bloqueador do receptor de angiotensina II para hipertensão.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Telmisartana 40mg', 'Bloqueador do receptor de angiotensina II para hipertensão e proteção cardiovascular.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Olmesartana 20mg', 'Bloqueador do receptor de angiotensina II para hipertensão.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Perindopril 10mg', 'Inibidor da ECA para hipertensão e doença coronariana.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Lacidipino 4mg', 'Bloqueador de canal de cálcio para hipertensão.', 'Comprimido', 'Antihipertensivo', @NOW, NULL, 1),
            ('Diltiazem 90mg', 'Bloqueador de canal de cálcio para angina e hipertensão.', 'Comprimido de liberação prolongada', 'Cardiovascular', @NOW, NULL, 1),
            ('Amiodarona 100mg', 'Antiarrítmico para arritmias cardíacas.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Digoxina 0,125mg', 'Glicosídeo cardíaco para insuficiência cardíaca e fibrilação atrial.', 'Comprimido', 'Cardiovascular', @NOW, NULL, 1),
            ('Clonazepam Gotas 2.5mg/ml', 'Ansiolítico e anticonvulsivante para uso pediátrico e em adultos com dificuldade de deglutição.', 'Solução oral (Gotas)', 'Ansiolítico/Neurológico', @NOW, NULL, 1),
            ('Gabapentina 600mg', 'Anticonvulsivante e para dor neuropática.', 'Comprimido', 'Neurológico', @NOW, NULL, 1),
            ('Pregabalina 25mg', 'Analgésico para dor neuropática e fibromialgia.', 'Cápsula', 'Neurológico', @NOW, NULL, 1),
            ('Topiramato 50mg', 'Anticonvulsivante para epilepsia e profilaxia da enxaqueca.', 'Comprimido', 'Neurológico', @NOW, NULL, 1),
            ('Lamotrigina 200mg', 'Antiepiléptico e estabilizador de humor.', 'Comprimido', 'Antiepilético', @NOW, NULL, 1),
            ('Levetiracetam 500mg', 'Anticonvulsivante para epilepsia.', 'Comprimido', 'Antiepilético', @NOW, NULL, 1),
            ('Ácido Valproico Xarope 250mg/5ml', 'Antiepilético e estabilizador de humor para uso pediátrico.', 'Xarope', 'Antiepilético/Pediatria', @NOW, NULL, 1),
            ('Fenitoína 100mg', 'Anticonvulsivante para epilepsia.', 'Comprimido', 'Antiepilético', @NOW, NULL, 1),
            ('Oximetazolina Spray Nasal 0,05%', 'Descongestionante nasal tópico.', 'Spray nasal', 'Respiratório', @NOW, NULL, 1),
            ('Pseudoefedrina 60mg', 'Descongestionante nasal oral.', 'Comprimido', 'Respiratório', @NOW, NULL, 1),
            ('Dextrometorfano Xarope 15mg/5ml', 'Antitussígeno para tosse seca.', 'Xarope', 'Respiratório', @NOW, NULL, 1),
            ('Codeína + Paracetamol', 'Analgésico opioide e antitérmico para dor moderada a severa.', 'Comprimido', 'Analgésico/Opiáceo', @NOW, NULL, 1),
            ('Tramadol + Paracetamol', 'Analgésico opioide e antitérmico para dor moderada a severa.', 'Comprimido', 'Analgésico/Opiáceo', @NOW, NULL, 1),
            ('Naloxona 0,4mg/ml', 'Antagonista opioide para reversão de overdose.', 'Ampola injetável', 'Antídoto', @NOW, NULL, 1),
            ('Flumazenil 0,1mg/ml', 'Antagonista de benzodiazepínicos para reversão de sedação.', 'Ampola injetável', 'Antídoto', @NOW, NULL, 1),
            ('Vitamina K1 Oral 5mg', 'Vitamina para coagulação sanguínea, para reverter anticoagulação.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Cianocobalamina Injetável 5000mcg/ml', 'Vitamina B12 para deficiência severa.', 'Ampola injetável', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Piridoxina 100mg', 'Vitamina B6 para deficiência e neuropatia.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Riboflavina 10mg', 'Vitamina B2 para deficiência.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Niacinamida 500mg', 'Vitamina B3 para deficiência e saúde da pele.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Ácido Pantotênico 250mg', 'Vitamina B5 para saúde geral.', 'Cápsula', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Biotina 10mg', 'Suplemento para cabelo, pele e unhas.', 'Comprimido', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Citrato de Cálcio 1000mg + Vitamina D3 200UI', 'Suplemento para saúde óssea.', 'Comprimido', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Cloreto de Potássio 600mg', 'Suplemento de potássio para hipocalemia.', 'Comprimido de liberação prolongada', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Sulfato de Zinco 50mg', 'Suplemento de zinco para deficiência e suporte imunológico.', 'Comprimido', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Sulfato de Cobre 2mg', 'Suplemento de cobre.', 'Comprimido', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Picolinato de Cromo 200mcg', 'Suplemento para controle de glicemia.', 'Cápsula', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Selênio 100mcg', 'Antioxidante e suporte da tireoide.', 'Comprimido', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Iodo 150mcg', 'Suplemento para saúde da tireoide.', 'Comprimido', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Manganês 5mg', 'Suplemento de manganês.', 'Comprimido', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Molibdênio 50mcg', 'Suplemento de molibdênio.', 'Comprimido', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Boro 3mg', 'Suplemento para saúde óssea e hormonal.', 'Cápsula', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Vitamina A 10000UI', 'Suplemento para visão e imunidade.', 'Cápsula', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Vitamina D2 50000UI', 'Suplemento para deficiência severa de Vitamina D.', 'Cápsula', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Vitamina K2 100mcg', 'Suplemento para saúde óssea e cardiovascular.', 'Cápsula', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Complexo B Injetável', 'Suplemento de vitaminas do complexo B para deficiência.', 'Ampola injetável', 'Suplemento/Vitamina', @NOW, NULL, 1),
            ('Ômega 3 Concentrado 1000mg (EPA/DHA)', 'Suplemento para saúde cardiovascular e cerebral com alta pureza.', 'Cápsula', 'Suplemento', @NOW, NULL, 1),
            ('Óleo de Coco Extra Virgem', 'Suplemento para energia e metabolismo.', 'Cápsula', 'Suplemento', @NOW, NULL, 1),
            ('Cromo Picolinato 200mcg', 'Suplemento para auxiliar no controle de glicemia e peso.', 'Cápsula', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Magnésio Dimalato 350mg', 'Suplemento de magnésio com ácido málico para energia e dor muscular.', 'Cápsula', 'Suplemento/Mineral', @NOW, NULL, 1),
            ('Coenzima Q10 200mg', 'Suplemento para energia celular e saúde cardíaca.', 'Cápsula', 'Suplemento', @NOW, NULL, 1),
            ('Resveratrol 250mg', 'Antioxidante natural.', 'Cápsula', 'Fitoterápico/Suplemento', @NOW, NULL, 1),
            ('Ginseng Coreano 500mg', 'Adaptógeno para energia e vitalidade.', 'Cápsula', 'Fitoterápico', @NOW, NULL, 1),
            ('Ashwagandha 400mg', 'Adaptógeno para estresse e ansiedade.', 'Cápsula', 'Fitoterápico', @NOW, NULL, 1),
            ('Rhodiola Rosea 250mg', 'Adaptógeno para fadiga e estresse.', 'Cápsula', 'Fitoterápico', @NOW, NULL, 1),
            ('Cardo Mariano 150mg', 'Fitoterápico para saúde do fígado.', 'Cápsula', 'Fitoterápico', @NOW, NULL, 1),
            ('Saw Palmetto 320mg', 'Fitoterápico para saúde da próstata.', 'Cápsula', 'Fitoterápico', @NOW, NULL, 1),
            ('Hipérico (Erva de São João) 300mg', 'Fitoterápico para depressão leve a moderada.', 'Cápsula', 'Fitoterápico', @NOW, @NOW, 0),
            ('Valeriana 200mg', 'Fitoterápico para insônia e ansiedade.', 'Cápsula', 'Fitoterápico', @NOW, NULL, 1),
            ('Passiflora 250mg', 'Fitoterápico para ansiedade e insônia.', 'Cápsula', 'Fitoterápico', @NOW, NULL, 1),
            ('Melatonina 3mg', 'Hormônio para regular o sono.', 'Comprimido', 'Hormônio/Suplemento', @NOW, NULL, 1),
            ('5-HTP 100mg', 'Precursor da serotonina para humor e sono.', 'Cápsula', 'Suplemento', @NOW, NULL, 1),
            ('L-Teanina 200mg', 'Aminoácido para relaxamento e foco.', 'Cápsula', 'Suplemento', @NOW, NULL, 1),
            ('Glicerina Supositório Infantil', 'Laxante suave para crianças.', 'Supositório', 'Laxante/Pediatria', @NOW, NULL, 1),
            ('Simeticona Gotas 75mg/ml', 'Antiflatulência para bebês e crianças.', 'Solução oral (Gotas)', 'Gastrointestinal/Pediatria', @NOW, NULL, 1),
            ('Pedialyte Solução Oral', 'Reidratante oral para crianças e adultos.', 'Solução oral', 'Hidratante Oral', @NOW, NULL, 1),
            ('Enzimas Digestivas', 'Suplemento para melhorar a digestão.', 'Cápsula', 'Suplemento/Gastrointestinal', @NOW, NULL, 1),
            ('Probiótico Multicepas', 'Suplemento com diversas cepas de bactérias benéficas.', 'Cápsula', 'Probiótico', @NOW, NULL, 1),
            ('Cânfora Pomada', 'Analgésico e anti-inflamatório tópico para dores musculares.', 'Pomada', 'Musculoesquelético/Tópico', @NOW, NULL, 1),
            ('Salicilato de Metila Pomada', 'Analgésico e anti-inflamatório tópico.', 'Pomada', 'Musculoesquelético/Tópico', @NOW, NULL, 1),
            ('Creme de Capsaicina 0,025%', 'Analgésico tópico para dor neuropática e artrite.', 'Creme', 'Musculoesquelético/Tópico', @NOW, NULL, 1),
            ('Diclofenaco Gel 1%', 'Anti-inflamatório tópico para dores e inflamações localizadas.', 'Gel', 'Anti-inflamatório/Tópico', @NOW, NULL, 1),
            ('Ibuprofeno Gel 5%', 'Anti-inflamatório tópico.', 'Gel', 'Anti-inflamatório/Tópico', @NOW, NULL, 1),
            ('Lidocaína Spray 10%', 'Anestésico local para alívio da dor.', 'Spray', 'Anestésico/Dermatológico', @NOW, NULL, 1),
            ('Prilocaína + Lidocaína Creme', 'Anestésico tópico para procedimentos de pele.', 'Creme', 'Anestésico/Dermatológico', @NOW, @NOW, 0),
            ('Peróxido de Hidrogênio 10 volumes', 'Antisséptico para limpeza de feridas.', 'Solução', 'Antisséptico', @NOW, NULL, 1),
            ('Clorexidina Solução 0,5%', 'Antisséptico para pele e mucosas.', 'Solução', 'Antisséptico', @NOW, NULL, 1),
            ('Povidone-Iodo Solução 10%', 'Antisséptico de amplo espectro.', 'Solução', 'Antisséptico', @NOW, NULL, 1),
            ('Álcool 70% Líquido', 'Antisséptico para desinfecção.', 'Líquido', 'Antisséptico', @NOW, NULL, 1),
            ('Luvas de Procedimento (Caixa c/ 100)', 'Equipamento de proteção individual.', 'Caixa', 'Material Hospitalar', @NOW, NULL, 1),
            ('Seringa Descartável 3ml', 'Material para injeções.', 'Unidade', 'Material Hospitalar', @NOW, NULL, 1),
            ('Agulha Descartável 25x7', 'Material para injeções.', 'Unidade', 'Material Hospitalar', @NOW, NULL, 1),
            ('Máscara Cirúrgica Descartável', 'Equipamento de proteção respiratória.', 'Unidade', 'Material Hospitalar', @NOW, NULL, 1),
            ('Esparadrapo', 'Fita adesiva para curativos.', 'Rolo', 'Material Hospitalar', @NOW, NULL, 1),
            ('Gaze Estéril 7.5x7.5cm', 'Material para curativos e limpeza.', 'Pacote', 'Material Hospitalar', @NOW, NULL, 1),
            ('Atadura de Crepe 10cm', 'Material para imobilização e compressão.', 'Rolo', 'Material Hospitalar', @NOW, NULL, 1),
            ('Compressa de Gaze Não Estéril', 'Material para limpeza e absorção.', 'Pacote', 'Material Hospitalar', @NOW, NULL, 1),
            ('Cânula Nasal para Oxigênio', 'Dispositivo para administração de oxigênio.', 'Unidade', 'Material Hospitalar', @NOW, NULL, 1),
            ('Umidificador de Oxigênio', 'Acessório para oxigenoterapia.', 'Unidade', 'Material Hospitalar', @NOW, @NOW, 0),
            ('Sonda de Aspiração Traqueal', 'Material para aspiração de secreções respiratórias.', 'Unidade', 'Material Hospitalar', @NOW, NULL, 1),
            ('Sonda Vesical de Foley', 'Material para drenagem urinária.', 'Unidade', 'Material Hospitalar', @NOW, NULL, 1),
            ('Equipo para Infusão', 'Material para administração de fluidos intravenosos.', 'Unidade', 'Material Hospitalar', @NOW, NULL, 1),
            ('Scalp para Punção Venosa', 'Dispositivo para acesso venoso.', 'Unidade', 'Material Hospitalar', @NOW, @NOW, 0),
            ('Cateter Intravenoso', 'Dispositivo para acesso venoso periférico.', 'Unidade', 'Material Hospitalar', @NOW, NULL, 1),
            ('Bolsa Coletora de Urina', 'Material para coleta de urina.', 'Unidade', 'Material Hospitalar', @NOW, NULL, 1),
            ('Fita Reagente para Glicemia', 'Material para teste de glicemia capilar.', 'Frasco', 'Material Hospitalar', @NOW, NULL, 1),
            ('Lanceta para Dedo', 'Material para coleta de sangue capilar.', 'Unidade', 'Material Hospitalar', @NOW, NULL, 1),
            ('Aparelho de Pressão Arterial (Esfigmomanômetro)', 'Dispositivo para medição da pressão arterial.', 'Unidade', 'Equipamento Médico', @NOW, NULL, 1),
            ('Estetoscópio', 'Dispositivo para ausculta médica.', 'Unidade', 'Equipamento Médico', @NOW, NULL, 1),
            ('Termômetro Digital', 'Dispositivo para medição da temperatura corporal.', 'Unidade', 'Equipamento Médico', @NOW, NULL, 1),
            ('Oxímetro de Pulso', 'Dispositivo para medição da saturação de oxigênio no sangue.', 'Unidade', 'Equipamento Médico', @NOW, NULL, 1),
            ('Balança Digital', 'Dispositivo para medição de peso corporal.', 'Unidade', 'Equipamento Médico', @NOW, NULL, 1),
            ('Nebulizador Portátil', 'Dispositivo para administração de medicamentos inalatórios.', 'Unidade', 'Equipamento Médico', @NOW, NULL, 1),
            ('Inalador de Dose Medida (Spacer)', 'Acessório para otimizar o uso de inaladores.', 'Unidade', 'Equipamento Médico', @NOW, NULL, 1),
            ('Kit de Primeiros Socorros (Básico)', 'Conjunto de materiais para emergências.', 'Kit', 'Material Hospitalar', @NOW, @NOW, 0),
            ('Compressa Quente/Fria', 'Para alívio de dor e inchaço.', 'Unidade', 'Material Hospitalar', @NOW, NULL, 1),
            ('Bandagem Elástica', 'Para suporte e compressão de lesões.', 'Rolo', 'Material Hospitalar', @NOW, NULL, 1);
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

INSERT INTO [dbo].[Stock]
            ([ProductId]
            ,[Quantity]
            ,[Batch])
VALUES
            -- ('ProductId', 'Quantity', 'Batch')
            (1, 0, ''),
            (2, 0, ''),
            (3, 0, ''),
            (4, 0, ''),
            (5, 0, ''),
            (6, 0, ''),
            (7, 0, ''),
            (8, 0, ''),
            (9, 0, ''),
            (10, 0, ''),
            (11, 0, ''),
            (12, 0, ''),
            (13, 0, ''),
            (14, 0, ''),
            (15, 0, ''),
            (16, 0, ''),
            (17, 0, ''),
            (18, 0, ''),
            (19, 0, ''),
            (20, 0, ''),
            (21, 0, ''),
            (22, 0, ''),
            (23, 0, ''),
            (24, 0, ''),
            (25, 0, ''),
            (26, 0, ''),
            (27, 0, ''),
            (28, 0, ''),
            (29, 0, ''),
            (30, 0, ''),
            (31, 0, ''),
            (32, 0, ''),
            (33, 0, ''),
            (34, 0, ''),
            (35, 0, ''),
            (36, 0, ''),
            (37, 0, ''),
            (38, 0, ''),
            (39, 0, ''),
            (40, 0, ''),
            (41, 0, ''),
            (42, 0, ''),
            (43, 0, ''),
            (44, 0, ''),
            (45, 0, ''),
            (46, 0, ''),
            (47, 0, ''),
            (48, 0, ''),
            (49, 0, ''),
            (50, 0, ''),
            (51, 0, ''),
            (52, 0, ''),
            (53, 0, ''),
            (54, 0, ''),
            (55, 0, ''),
            (56, 0, ''),
            (57, 0, ''),
            (58, 0, ''),
            (59, 0, ''),
            (60, 0, ''),
            (61, 0, ''),
            (62, 0, ''),
            (63, 0, ''),
            (64, 0, ''),
            (65, 0, ''),
            (66, 0, ''),
            (67, 0, ''),
            (68, 0, ''),
            (69, 0, ''),
            (70, 0, ''),
            (71, 0, ''),
            (72, 0, ''),
            (73, 0, ''),
            (74, 0, ''),
            (75, 0, ''),
            (76, 0, ''),
            (77, 0, ''),
            (78, 0, ''),
            (79, 0, ''),
            (80, 0, ''),
            (81, 0, ''),
            (82, 0, ''),
            (83, 0, ''),
            (84, 0, ''),
            (85, 0, ''),
            (86, 0, ''),
            (87, 0, ''),
            (88, 0, ''),
            (89, 0, ''),
            (90, 0, ''),
            (91, 0, ''),
            (92, 0, ''),
            (93, 0, ''),
            (94, 0, ''),
            (95, 0, ''),
            (96, 0, ''),
            (97, 0, ''),
            (98, 0, ''),
            (99, 0, ''),
            (100, 0, ''),
            (101, 0, ''),
            (102, 0, ''),
            (103, 0, ''),
            (104, 0, ''),
            (105, 0, ''),
            (106, 0, ''),
            (107, 0, ''),
            (108, 0, ''),
            (109, 0, ''),
            (110, 0, ''),
            (111, 0, ''),
            (112, 0, ''),
            (113, 0, ''),
            (114, 0, ''),
            (115, 0, ''),
            (116, 0, ''),
            (117, 0, ''),
            (118, 0, ''),
            (119, 0, ''),
            (120, 0, ''),
            (121, 0, ''),
            (122, 0, ''),
            (123, 0, ''),
            (124, 0, ''),
            (125, 0, ''),
            (126, 0, ''),
            (127, 0, ''),
            (128, 0, ''),
            (129, 0, ''),
            (130, 0, ''),
            (131, 0, ''),
            (132, 0, ''),
            (133, 0, ''),
            (134, 0, ''),
            (135, 0, ''),
            (136, 0, ''),
            (137, 0, ''),
            (138, 0, ''),
            (139, 0, ''),
            (140, 0, ''),
            (141, 0, ''),
            (142, 0, ''),
            (143, 0, ''),
            (144, 0, ''),
            (145, 0, ''),
            (146, 0, ''),
            (147, 0, ''),
            (148, 0, ''),
            (149, 0, ''),
            (150, 0, ''),
            (151, 0, ''),
            (152, 0, ''),
            (153, 0, ''),
            (154, 0, ''),
            (155, 0, ''),
            (156, 0, ''),
            (157, 0, ''),
            (158, 0, ''),
            (159, 0, ''),
            (160, 0, ''),
            (161, 0, ''),
            (162, 0, ''),
            (163, 0, ''),
            (164, 0, ''),
            (165, 0, ''),
            (166, 0, ''),
            (167, 0, ''),
            (168, 0, ''),
            (169, 0, ''),
            (170, 0, ''),
            (171, 0, ''),
            (172, 0, ''),
            (173, 0, ''),
            (174, 0, ''),
            (175, 0, ''),
            (176, 0, ''),
            (177, 0, ''),
            (178, 0, ''),
            (179, 0, ''),
            (180, 0, ''),
            (181, 0, ''),
            (182, 0, ''),
            (183, 0, ''),
            (184, 0, ''),
            (185, 0, ''),
            (186, 0, ''),
            (187, 0, ''),
            (188, 0, ''),
            (189, 0, ''),
            (190, 0, ''),
            (191, 0, ''),
            (192, 0, ''),
            (193, 0, ''),
            (194, 0, ''),
            (195, 0, ''),
            (196, 0, ''),
            (197, 0, ''),
            (198, 0, ''),
            (199, 0, ''),
            (200, 0, ''),
            (201, 0, ''),
            (202, 0, ''),
            (203, 0, ''),
            (204, 0, ''),
            (205, 0, ''),
            (206, 0, ''),
            (207, 0, ''),
            (208, 0, ''),
            (209, 0, ''),
            (210, 0, ''),
            (211, 0, ''),
            (212, 0, ''),
            (213, 0, ''),
            (214, 0, ''),
            (215, 0, ''),
            (216, 0, ''),
            (217, 0, ''),
            (218, 0, ''),
            (219, 0, ''),
            (220, 0, ''),
            (221, 0, ''),
            (222, 0, ''),
            (223, 0, ''),
            (224, 0, ''),
            (225, 0, ''),
            (226, 0, ''),
            (227, 0, ''),
            (228, 0, ''),
            (229, 0, ''),
            (230, 0, ''),
            (231, 0, ''),
            (232, 0, ''),
            (233, 0, ''),
            (234, 0, ''),
            (235, 0, ''),
            (236, 0, ''),
            (237, 0, ''),
            (238, 0, ''),
            (239, 0, ''),
            (240, 0, ''),
            (241, 0, ''),
            (242, 0, ''),
            (243, 0, ''),
            (244, 0, ''),
            (245, 0, ''),
            (246, 0, ''),
            (247, 0, ''),
            (248, 0, ''),
            (249, 0, ''),
            (250, 0, ''),
            (251, 0, ''),
            (252, 0, ''),
            (253, 0, ''),
            (254, 0, ''),
            (255, 0, ''),
            (256, 0, ''),
            (257, 0, ''),
            (258, 0, ''),
            (259, 0, ''),
            (260, 0, ''),
            (261, 0, ''),
            (262, 0, ''),
            (263, 0, ''),
            (264, 0, ''),
            (265, 0, ''),
            (266, 0, ''),
            (267, 0, ''),
            (268, 0, ''),
            (269, 0, ''),
            (270, 0, ''),
            (271, 0, ''),
            (272, 0, ''),
            (273, 0, ''),
            (274, 0, ''),
            (275, 0, ''),
            (276, 0, ''),
            (277, 0, ''),
            (278, 0, ''),
            (279, 0, ''),
            (280, 0, ''),
            (281, 0, ''),
            (282, 0, ''),
            (283, 0, ''),
            (284, 0, ''),
            (285, 0, ''),
            (286, 0, ''),
            (287, 0, ''),
            (288, 0, ''),
            (289, 0, ''),
            (290, 0, ''),
            (291, 0, ''),
            (292, 0, ''),
            (293, 0, ''),
            (294, 0, ''),
            (295, 0, ''),
            (296, 0, ''),
            (297, 0, ''),
            (298, 0, ''),
            (299, 0, ''),
            (300, 0, ''),
            (301, 0, ''),
            (302, 0, ''),
            (303, 0, ''),
            (304, 0, ''),
            (305, 0, ''),
            (306, 0, ''),
            (307, 0, ''),
            (308, 0, ''),
            (309, 0, ''),
            (310, 0, ''),
            (311, 0, ''),
            (312, 0, ''),
            (313, 0, ''),
            (314, 0, ''),
            (315, 0, ''),
            (316, 0, ''),
            (317, 0, ''),
            (318, 0, ''),
            (319, 0, ''),
            (320, 0, ''),
            (321, 0, ''),
            (322, 0, ''),
            (323, 0, ''),
            (324, 0, ''),
            (325, 0, ''),
            (326, 0, ''),
            (327, 0, ''),
            (328, 0, ''),
            (329, 0, ''),
            (330, 0, ''),
            (331, 0, ''),
            (332, 0, ''),
            (333, 0, ''),
            (334, 0, ''),
            (335, 0, ''),
            (336, 0, ''),
            (337, 0, ''),
            (338, 0, ''),
            (339, 0, ''),
            (340, 0, ''),
            (341, 0, ''),
            (342, 0, ''),
            (343, 0, ''),
            (344, 0, ''),
            (345, 0, ''),
            (346, 0, ''),
            (347, 0, ''),
            (348, 0, ''),
            (349, 0, ''),
            (350, 0, ''),
            (351, 0, ''),
            (352, 0, ''),
            (353, 0, ''),
            (354, 0, ''),
            (355, 0, ''),
            (356, 0, ''),
            (357, 0, ''),
            (358, 0, ''),
            (359, 0, ''),
            (360, 0, ''),
            (361, 0, ''),
            (362, 0, ''),
            (363, 0, ''),
            (364, 0, ''),
            (365, 0, ''),
            (366, 0, ''),
            (367, 0, ''),
            (368, 0, ''),
            (369, 0, ''),
            (370, 0, ''),
            (371, 0, ''),
            (372, 0, ''),
            (373, 0, ''),
            (374, 0, ''),
            (375, 0, ''),
            (376, 0, ''),
            (377, 0, ''),
            (378, 0, ''),
            (379, 0, ''),
            (380, 0, ''),
            (381, 0, ''),
            (382, 0, ''),
            (383, 0, ''),
            (384, 0, ''),
            (385, 0, ''),
            (386, 0, ''),
            (387, 0, ''),
            (388, 0, ''),
            (389, 0, ''),
            (390, 0, ''),
            (391, 0, ''),
            (392, 0, ''),
            (393, 0, ''),
            (394, 0, ''),
            (395, 0, ''),
            (396, 0, ''),
            (397, 0, ''),
            (398, 0, ''),
            (399, 0, ''),
            (400, 0, ''),
            (401, 0, ''),
            (402, 0, ''),
            (403, 0, ''),
            (404, 0, ''),
            (405, 0, ''),
            (406, 0, ''),
            (407, 0, ''),
            (408, 0, ''),
            (409, 0, ''),
            (410, 0, ''),
            (411, 0, ''),
            (412, 0, ''),
            (413, 0, ''),
            (414, 0, ''),
            (415, 0, ''),
            (416, 0, ''),
            (417, 0, ''),
            (418, 0, ''),
            (419, 0, ''),
            (420, 0, ''),
            (421, 0, ''),
            (422, 0, ''),
            (423, 0, ''),
            (424, 0, ''),
            (425, 0, ''),
            (426, 0, ''),
            (427, 0, ''),
            (428, 0, ''),
            (429, 0, ''),
            (430, 0, ''),
            (431, 0, ''),
            (432, 0, ''),
            (433, 0, ''),
            (434, 0, ''),
            (435, 0, ''),
            (436, 0, ''),
            (437, 0, ''),
            (438, 0, ''),
            (439, 0, ''),
            (440, 0, ''),
            (441, 0, ''),
            (442, 0, ''),
            (443, 0, ''),
            (444, 0, ''),
            (445, 0, ''),
            (446, 0, ''),
            (447, 0, ''),
            (448, 0, ''),
            (449, 0, ''),
            (450, 0, ''),
            (451, 0, ''),
            (452, 0, ''),
            (453, 0, ''),
            (454, 0, ''),
            (455, 0, ''),
            (456, 0, ''),
            (457, 0, ''),
            (458, 0, ''),
            (459, 0, ''),
            (460, 0, ''),
            (461, 0, ''),
            (462, 0, ''),
            (463, 0, ''),
            (464, 0, ''),
            (465, 0, ''),
            (466, 0, ''),
            (467, 0, ''),
            (468, 0, ''),
            (469, 0, ''),
            (470, 0, ''),
            (471, 0, ''),
            (472, 0, ''),
            (473, 0, ''),
            (474, 0, ''),
            (475, 0, ''),
            (476, 0, ''),
            (477, 0, ''),
            (478, 0, ''),
            (479, 0, ''),
            (480, 0, ''),
            (481, 0, ''),
            (482, 0, ''),
            (483, 0, ''),
            (484, 0, ''),
            (485, 0, ''),
            (486, 0, ''),
            (487, 0, ''),
            (488, 0, ''),
            (489, 0, ''),
            (490, 0, ''),
            (491, 0, ''),
            (492, 0, ''),
            (493, 0, ''),
            (494, 0, ''),
            (495, 0, ''),
            (496, 0, ''),
            (497, 0, ''),
            (498, 0, ''),
            (499, 0, ''),
            (500, 0, ''),
            (501, 0, ''),
            (502, 0, ''),
            (503, 0, ''),
            (504, 0, ''),
            (505, 0, ''),
            (506, 0, ''),
            (507, 0, ''),
            (508, 0, ''),
            (509, 0, ''),
            (510, 0, ''),
            (511, 0, ''),
            (512, 0, ''),
            (513, 0, ''),
            (514, 0, '');
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @NOW DATETIME
SET @NOW = GETDATE()

INSERT INTO [dbo].[AspNetUsers]
            ([CreatedOn]
            ,[UpdatedOn]
            ,[IsActive]
            ,[FacilityId]
            ,[UserName]
            ,[NormalizedUserName]
            ,[Email]
            ,[NormalizedEmail]
            ,[EmailConfirmed]
            ,[PasswordHash]
            ,[SecurityStamp]
            ,[ConcurrencyStamp]
            ,[PhoneNumber]
            ,[PhoneNumberConfirmed]
            ,[TwoFactorEnabled]
            ,[LockoutEnd]
            ,[LockoutEnabled]
            ,[AccessFailedCount])
     VALUES
            -- ('CreatedOn', 'UpdatedOn', 'IsActive', 'FacilityId', 'UserName', 'NormalizedUserName', 'Email', 'NormalizedEmail', 'EmailConfirmed', 'PasswordHash', 'SecurityStamp', 'ConcurrencyStamp', 'PhoneNumber', 'PhoneNumberConfirmed', 'TwoFactorEnabled', 'LockoutEnd', 'LockoutEnabled', 'AccessFailedCount')
            -- (@NOW, NULL, 1, 1, 'sms_master', 'SMS_MASTER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEEqeBGF+Rvx70SKaJEf8a7fAWWMLi+icLvnqu5uiLw3uR23FB+X6dxnr0jBGFs2ZnA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 1, 'sms_admin', 'SMS_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAELrbTaOsjU/nSbwwor8wr2irt9ZJhh26FRn0Fpwse8Yqwc/XQ7B3KR9AAYNPh65/7w==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 1, 'sms_user', 'SMS_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEDR5p/FDbjAZWg8GmxSkqYBjbxoUS3Pnctb69y51r/JkRQYObcr+A67yTVm6TS9fYA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 2, 'cdm_master', 'CDM_MASTER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEDgZorTwRiBt+jaGuACqXQEaqsge9wX/yUrEAINreRN8HxEAmmgV5j8xtk8hX9P8vg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 2, 'cdm_admin', 'CDM_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEC3tHi0zyN8zMRirOzKEzXsqx/QRsuPNEazbbdZhvX6Pj+vUpH8MXcxUILtIBw0x2A==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 2, 'cdm_user', 'CDM_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEG3wsZnFjqrLpEEr1riCXtf66MaQiJLlMwrCQw1rTseC4LmTqi6KxGJdnQacQoDs+A==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 2, 'cdm_user2', 'CDM_USER2', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEBjwkJTYyjHFP36i76CYr2wgEPioZOiOapk8vnBx2xFh4ez+paR4+7ZTEQo4I2EwMw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 3, 'ubs_ev_admin', 'UBS_EV_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEN35ulBBEEMdYsGe+Dr7rRhlVJbgreodBOY+cp3TbhMIO6+Wh9QeoW/4JAVZBC+zPg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 3, 'ubs_ev_user', 'UBS_EV_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAELbjypAfD7G2SU6v0ZVh9LeedEMh4PTKuFayYudQL3O8qCaPpHuVib7/RBqjqjf8Fw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 4, 'upa_esf_admin', 'UPA_ESF_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEPH+BChfALUyi+RjRLk2vAb79jj6WM2Qtt3I4uoQwZiI02sRqWaBMq8KhFbWTt2txA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 4, 'upa_esf_user', 'UPA_ESF_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEBzVzrKy6v5xX+GjxJG4j3niaI2MTSzkGybeJVeSy95y1vqsnffwrLhNzSFr5BbDLw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 5, 'fac_admin', 'FAC_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEGxoWPSzzmuqfXMBV2tJLoT4ZWmAbwfGuBspfSRZEaAUKi7hXKN4sa+LBrEjx4bk0A==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 5, 'fac_user', 'FAC_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEJp1Na9cUFhHrwz7GN+HugdN6761k5rYkS2Of4FgxPF0MywZtueJ7vNvDTg/L0I3ww==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 6, 'samu_admin', 'SAMU_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEGJdbUKsGVD/G7yYWPYb82YDdZ4/ZBxkODzQZp7WcPYtNV/SCHC71uNUxVsoOOp+pA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 6, 'samu_user', 'SAMU_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEAaMeanAynQIdnL/lhr1dcSbthu1mah7NhN4k+Ap1pMv5ug4Y1GurFUC7yaAfrmvxA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 7, 'psf_eu_admin', 'PSF_EU_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEMGW9L9w2cJs7rptSIqeSrs7BXLCuUqS6Dht2WDOUcwLMk8rLYHcaFJtgBCstZ/vIQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 7, 'psf_eu_user', 'PSF_EU_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEJlhIrDYynGAjjhdBGXTQFcek1fdNV0UbHjI6N1MYEf5XTjNp+oDcDohNwPZx4QFMw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 8, 'psf_ndl_admin', 'PSF_NDL_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEEfenVMhf32yrobWPKimmegSZUvB7/LelT8oyOIQni/irgb053F/Qx7t6RWaX1lyFg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 8, 'psf_ndl_user', 'PSF_NDL_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEKhmianNIvwaus1nubY3RL9jBrlgJQPYW72b+9mkhpN3SgbZrg8ME0AMCV22xfRCjw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 9, 'psf_jm_admin', 'PSF_JM_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEA6Te8vIUWZnb2Nmx4197fIErzWuMKtxgMe3Mxg3aRHCY3OZDB2oCl+BXbU4UlhwCw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 9, 'psf_jm_user', 'PSF_JM_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEOrV65A44ugH+d3+fLdNSZkwX0Od4p9J4Fi6Zf+eXEUAl/cc6M9WbTwp11H80G2fQQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 10, 'ubs_jf_admin', 'UBS_JF_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEFgYqO74PFN+hg3jCnqYThjMqe3q/t1d8vPDj6dHKE6jZ1rlkxS9bLNxbU68/KSzOA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 10, 'ubs_jf_user', 'UBS_JF_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAENc9ihwYOGcD4geaiJ3bKjY4zTiUrqaB5hcGrev/A6RKGtzMqHOg8IJgfyd3ZLey8g==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 11, 'caem_ns_admin', 'CAEM_NS_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEP42qRqIgquEENAXkhy83LXOxJwd5kIGg0oorANzyAb347P7QJwMh1xcTSFT1Pq7Tg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 11, 'caem_ns_user', 'CAEM_NS_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEDzFiUC5fF3KrLFPFWQv7LQ0SCSrokUOKjHLFdLpc91E9FNXIu1JL75FRwzns4NvPA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 12, 'asm_ab_admin', 'ASM_AB_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEHmOJB0MuhFDB2Vo4StmKBn+H5ojOB+6w5uG1nCQdIODwkfmqtGufhK5PVFkLPCMyw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 12, 'asm_ab_user', 'ASM_AB_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEAD/7uqisMnoBWf7noJT6wto/yd/S9sW7fFBvkdcI9yFdzTi/Qtrw1Rh7K2o/d8d6Q==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 13, 'caps_ad_admin', 'CAPS_AD_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAELf9f+aBTfDYkPem7vkscjqEYgN7zUEHcYHWDRHrYPMdgAhzPI90CSFh3O56oL8eeg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 13, 'caps_ad_user', 'CAPS_AD_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEB6dXFwLmGfOXpXkBUXNO1mJVe7iyG29kJJXiMz9kgVYF+8PjdapFQ5/fupEMuCfSA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 14, 'ccz_admin', 'CCZ_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAECWPaVYScJtNwx+WBYJJBBXdAwpFtGhZcX9CVBhzYhPot1HBDW+QqMLYQJuGE75kbA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 14, 'ccz_user', 'CCZ_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEAf0HS/1Kaakil7wN1pI3Ab9Cp4qAMPyYH1LvETWdxqvoDLmcgZWPGxsMWm1LLMuzw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 15, 'ubs_sj_admin', 'UBS_SJ_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEFKhRq3tyb81NTtNEC7TM1g7KHKZmXQpEfRAS77eKMo7PZj46qkYqELqoR9sd4s/5Q==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 15, 'ubs_sj_user', 'UBS_SJ_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEKzNHCbS/5aZrwwGERf7q3siUz/QKVtTjb1sXfiJOUZ9SKyVs7oVjfLoQXCXvT5WHg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 16, 'psf_jo_admin', 'PSF_JO_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEPnesHyPlpQduabL7SyXFRcAUbFap96132tU7CUBfL/coFsMtbZw8wj+oLIJ9ngzbA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 16, 'psf_jo_user', 'PSF_JO_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEIC8VRpLEFNCD/Pa6A1qt0frYD7h5CrBz5beL2Ldlarmz4V5gQMkupFtAOd2J867Kg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 17, 'ubs_vp_admin', 'UBS_VP_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEKJ6DMC2J27/R3Paf1slCokeHBspmsnk2WcaGyn7QyNludT2Pt1zKUgTBJG/S9AxXg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 17, 'ubs_vp_user', 'UBS_VP_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEOLJF5KQSiv9lxQ+LyMp4vMfko/ttBx5NuX+w+eKrcXzl6kUy8QFVwLCLGbaG2YkDw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 18, 'psf_pt_admin', 'PSF_PT_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAENatpMQKHkO4G/vVQZf60thyQ5djjWHOIhCO2P7lDbIL8JcKqEo5vEGjC5hYuZTjMQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 18, 'psf_pt_user', 'PSF_PT_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEPdqUcxFP1d2EAOimcFlLyzwqf+mQW7BTxXsL2Kf7+zYHUXmrgSv8mktaGB6mqMM0g==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 19, 'ubs_vs_admin', 'UBS_VS_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAECJ122ApExmNxe6IGPuAQG2TP+YyjrsydlkiuautIW8Q6AHhzcU2vGg8Jg/tV/KvYg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 19, 'ubs_vs_user', 'UBS_VS_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEHOgtFU8mHySklwtuAZx+HDlpTYvff2b8wlvrfmaFWSYe2xuzfigpu7OnAOlivIY5A==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 20, 'caps_2_admin', 'CAPS_2_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEB6uHnaIYbaLPJ9OOE7fyBhCjlA6hkJ7kgMBySfe2M0OwG7512dOTEMm7mJt/OZu5g==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 20, 'caps_2_user', 'CAPS_2_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEGSrkq3o1XiK7ehn91utF8fOFNeyljE20Ajl2S/qIoVFoYbWtR3ZOkfvuZpTH1fUPw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 21, 'psf_rsb_admin', 'PSF_RSB_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEEh9VUkMsx12hKJJrPoP+Sb+Iw3BymFrwhdNgCdksUR2ypi97kUB0RKBhD7O40sUfQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 21, 'psf_rsb_user', 'PSF_RSB_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEP/DNfPLCYKCMk/+So38ArkFML2hCEvKz9kJYQopHUDQCsgbj1rr8MaPKqsLYnnbJA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 22, 'psf_rg_admin', 'PSF_RG_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEPRbZIDNgYg3UAatFO7i0R/JxIy1kX4pISxIxv+QHiJ3PKOAaTpsy5Vou99MAh0jrQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 22, 'psf_rg_user', 'PSF_RG_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEKglZ79JeWXk2N5nK7+cxAluU6EZCH+xQvjrQ7ZCq5ub1MM6RXczo32OD5ryFs+KpA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 23, 'ubs_sr_admin', 'UBS_SR_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEG9h1KwPOXhf2Ue9Fxvkg18OaNa4tOKmAe99A+zI0O8jkUoBhPi8DaKSJro++rGElg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 23, 'ubs_sr_user', 'UBS_SR_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEPb5Mlws9GhGztEtGtlh052VmSiTf54x0joWVBcPuYGmPnlfVQSpmOg7j4WCp3u5kA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 24, 'ubs_esj_admin', 'UBS_ESJ_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAENnpMBKLoaUsYuAAVe8DosE2yxoBp+rA5qPFB4kBjku444vS1DhEli25ZDqHKxpotw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 24, 'ubs_esj_user', 'UBS_ESJ_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEDWK5kr4PBApUFdWnjG1PN7geFNeZ1y5iLxu6lTICwob7hvdTOJIqFSHMTh9D/PdxQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 25, 'psf_rsj_admin', 'PSF_RSJ_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEOccwQshuQf79qANYAjSGtLhXce/mrJ0lcjQhN6kr5db4ouA5Z/B4yAqkUHIL3Mhog==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 25, 'psf_rsj_user', 'PSF_RSJ_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEGe2gqpA3i+j+iL2flK6BVgGy0hKlrU+GXtjZbQQ+/VKh6BNNEmjwmrWU50cdP2NqA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 26, 'ubs_je_admin', 'UBS_JE_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEFNebTUd/DIYZUKVoCp1T3GkJupAUs10Vs+Rm+QWHH8pWi9prXYpgWRzqtPPo8ytmg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 26, 'ubs_je_user', 'UBS_JE_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAED7gIoCCSuH0HI2D5Z39snk7G7oU3CXmgodaLL/d2+4TsFH30Z1mp0DiYq1x7zJhcA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, @NOW, 0, 27, 'apa_sfo_admin', 'APA_SFO_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEGqalT3NMD/gcz6fwwS4az3kowlAhzMItmGPx7tUy/DNz8HYrmgllmHCYmy6IFI4NA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, @NOW, 0, 27, 'apa_sfo_user', 'APA_SFO_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAENIGuS/kKaTVHh9i0b3AMhhcNNVCDgNR291eu/dAtn4Rjy9B1olJxazW4Y6ZARuxuQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 28, 'vs_admin', 'VS_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEIdW+Sito6knIRmzlirKRSpAdtmLdBzi9i2qyITeOytMlf3LsgxXXAQe1sCQWQ9pBg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 28, 'vs_user', 'VS_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEIOx/Mt1etL7C2KGBvClIymx2TQ3jE6j44Kzmr2c3t8RqmJFLevY2q9mdnkoFLnUQQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 29, 'umo_admin', 'UMO_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEMz17gHOKJOZcll5gvbNde+I19vyRFuveNOIhf/Pe/dZtQcexjn9D0mwNSYqX+VgCg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 29, 'umo_user', 'UMO_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAECxH7N5T+uef3Sy1UD04gon+576U6aTgIUIwte3Jg6HghWip+JcrTwNBYhvspUstgQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 30, 'uve_admin', 'UVE_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAED7pWOjnRGf09WbltfZvH37rtEj8F1q9m7tPD1Cc2gQonBgUN6L7wBUexLwtR8pm3Q==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 30, 'uve_user', 'UVE_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEK1Sp7mUn5wLWS0iJlAhlw5vrccaCH0SkfHKCskpltTxIrabnY0R/KyVF0rGTr5PYw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 31, 'ubs_osd_admin', 'UBS_OSD_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEDMRy7IL8ZrYW4K5ppID9EXcYWF9N0OOL3QGn23PqXRPxEBAT5BPBKE94V8Azj3aSg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 31, 'ubs_osd_user', 'UBS_OSD_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAECaKEkZdRsQexYC/YpSbqaEDonAZt3H9fZr6agiDO320d7mPPjdwN6ST2/U1OslB+A==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 32, 'ubs_hrj_admin', 'UBS_HRJ_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEClI2cFIDFDYbKW51LNZ4s2W62vO+he6cglzxD12tKVsGhTxit4lPaINk3QfiNJvNA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 32, 'ubs_hrj_user', 'UBS_HRJ_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEN9Eea+2DZHj8mqLqJeh8ziy+rA538oi8EjVFnlWp8S+Nq+eMMAwcUnXVlC3uUk5tw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 33, 'ubs_em_admin', 'UBS_EM_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEOfdXxkBREwxS4VMcnhxpeMyQ8uVXSedLnH9cP6ttmGJ1Qa2sRY2YETYbcUsbWy1xA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 33, 'ubs_em_user', 'UBS_EM_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEPNk6binzSWicXhphUs4PTTbrEd5M+Z2RPNTPkMwplUZ9nru4soC4TVBMNhxMLxUGQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, @NOW, 0, 34, 'ubs_asp_admin', 'UBS_ASP_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEODC9pjkbtr12UzU80e6S6tcDu50H2rN8mJHzZ8hsRqJ7ocqrA2CMN/ifxQvlx8HZg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, @NOW, 0, 34, 'ubs_asp_user', 'UBS_ASP_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEABNrdHXiBF67z+i+5ScB3d+77dafaLLwJVEVRdOe0yFklmhH4bQvdXLQ2eVgcjGDQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 35, 'ubs_acf_admin', 'UBS_ACF_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEIHpwKNvwRCf7r9WRhGcI393VP8LdCaT3C1u9XLRr0L0v+nUK1xlh/6bIMFczRMc4Q==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 35, 'ubs_acf_user', 'UBS_ACF_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEOUdi5vKKcFNHtHpv+xuxccn6XbIlM0f4bXPXzc6M7dK6g4hkPN7GYcmxuKmaYuz5A==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 36, 'ubs_af_admin', 'UBS_AF_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEBSX80VMHrcffGF/lD/FIzapIygQA8VlscFsMhrMbwoW8vFTjtaG7oiQiD25Wd10aQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 36, 'ubs_af_user', 'UBS_AF_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEENCLOPCWQGozKQXxWwV/4jWm2w0TSoVeyedsHSRIvTeO8RHSqcmEIJwWSmN7CIUCQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 37, 'hps_admin', 'HPS_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEImFHsOVLe9HXjlKD8lpFNVUMQ84OAmTin8rriSIJUfqJK6zbUsCiXvpiz7GE239Gg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 37, 'hps_user', 'HPS_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEOR0CDzLdqB1oipoVmmA/uGKaZx+cPwjyMhd0a84uH/RmpUjoTptdcvaVNXj4oZdLQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, @NOW, 0, 38, 'ps_afo_admin', 'PS_AFO_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEMWTcZxQXqOF498KRCKWrptmx5G6wTxtTp8fJE781jcm1IaA3dL0bxF2fNUiCDY+nA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, @NOW, 0, 38, 'ps_afo_user', 'PS_AFO_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAENz3CzLPv0LrC/3ra2Yqt6TMcJFQOswSMTivRlz58kkZnjEqqU+UqZ2fguGXGRnvHw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 39, 'easg_admin', 'EASG_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEE88tNQrj3L3StrsdsYNkUtmnYjUX2e1o9lymnQcTz+Wx6cvbMAhfSsK/fbKLqaovA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 39, 'easg_user', 'EASG_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAECvkeJyFJEtbPOCHVRGocxsAYCzRX5PPI0cbQqcKNGijzdlHvKhFwF/VjADgBSUjog==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, @NOW, 0, 40, 'pa_eacc_admin', 'PA_EACC_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEMLV1vh5IIne6aCnMPp2IEVI/snNvaZMzBVb6FFtsXQ7EwJKGUDwZUzl9P1SqOlwzA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, @NOW, 0, 40, 'pa_eacc_user', 'PA_EACC_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEJppkLl/GRLS5dl/LXXkucaQu06igZ0Z4ld8reYzGbsh5C37YFQIJOen5QIzjDC8qQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 41, 'mdcs_admin', 'MDCS_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEDwJmsC1VqzrVIf1um8n4Vy6SxUo7b1tR8A1kc6AUEXzGE84N6kWWw0KYJSgn8sjig==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 41, 'mdcs_user', 'MDCS_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEINSTaDrCnHzIQP9N58xdfWYgjQpLTF8c+Iz/JaCBEuvTmFsbV4pqFwkFsMX5bvVew==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 42, 'lv_admin', 'LV_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEKk9EilNuzNDgzGVmsp94PZPvoWyQ+aFCQHQicO+UM2hLJ10nS1x52QpYe4rrVuY5g==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 42, 'lv_user', 'LV_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEN2gpT/sY3zzBw5GQQFSqVfg52agPIzZuXZ5u9hPUskCPzW45fTB8z7WW/5YnhasaA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 43, 'esf_vph_admin', 'ESF_VPH_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAECz+Pl22l4/rre1So56FAWpbfEjCgEYfGnBfn/mRCsRuBPnOp3hIsqOH/hDT5LCA+A==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 43, 'esf_vph_user', 'ESF_VPH_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEAErhhQdnKP5Xt7vmYDfax4aDWcOnCiUIHYuu8Bx/PGbGgR8/2y3TqnT3htovR7I4A==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 44, 'esf_zr_admin', 'ESF_ZR_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEDUtd1MXpcQUL+T9RXwb0zJTftiokfMV+Hq7tvZDR2B7BO7L+n56QVzp8vzstd2E6w==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 44, 'esf_zr_user', 'ESF_ZR_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEO8EQeeUDiLzULObXZi0yVITKsKb75GaT7yananuJoVxAzNCPtnKc4brmwCP29vmNg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, @NOW, 0, 45, 'hcc19_admin', 'HCC19_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEFDpcberLid53T0HfYhuHWbFveHVYji9btXDVDb2Hn1zek9w95leEbPtOJc0CY7d7g==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, @NOW, 0, 45, 'hcc19_user', 'HCC19_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEOUxAAQe8qz7IpTKDsEMzjmFmNHDa03/fIsr8ofPGX5XCXaVK5uhvHI7sfxyUALHFg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 46, 'hslm_admin', 'HSLM_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAENYZK47bcJHa3F3ZrmFVA5qeT3aFignT5K5Q+Gjrw6CSRkN2mD5hO8pisg1F1qNnxA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 46, 'hslm_user', 'HSLM_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEE1y3EoyayrWkljaTpONEAQ3DNcpoQFU1AOQsd2pzlfszIBUztYsdft1vLza5mTmaA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 47, 'hiscma_admin', 'HISCMA_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAELR59iriPH2Y9u6ieExWGekd4/meyB4UFteACXssClmTm2PFSxkyNRuh/Quw/8sIqg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 47, 'hiscma_user', 'HISCMA_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAECTUhYOj17/YWoBf64o5usn1Ns4/SbDzyzJO7IPXJz5RAM7ctLBrRXftoDvqlhs8og==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 48, 'esf_oz_admin', 'ESF_OZ_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEJ9ZP5f07g/59PIoKfwfNks8AQiI9wCgsxApz8z959wmbapsjDUfZwWa+JGf2lXobw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 48, 'esf_oz_user', 'ESF_OZ_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEM2EfzhYjilXQHGJqvyp4LwKH/1CTwVyuj/C/X7OmVUxHkOy74FXoH5cczReqZyouA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, @NOW, 0, 49, 'esf_sjm_admin', 'ESF_SJM_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEB4QlTnoETLczEyC3f6rJurnUGLMMe2zyzd65cdaEj4K6wp3whfPjjV+Z9K+npVyZQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, @NOW, 0, 49, 'esf_sjm_user', 'ESF_SJM_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEFlAM/TvYVPL1wL9AzSjSZWQLWByuHwV25OEfCuxc3aRGOp17KE3UHWrGB5YXqeHtg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 50, 'esf_fnc_admin', 'ESF_FNC_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAELE0Cp3ppu4TWByST0/MwjUiXsfkWwgWgh3dBa+23h5pcAwpL10JMErWZytjATIIAA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 50, 'esf_fnc_user', 'ESF_FNC_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAELixgyLmUk8pcWeB35zJ6URdH40s4dUnE+z8pOBFkNT4a8Krkls8IzZbKnmD1UjhMQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 51, 'esf_jo_admin', 'ESF_JO_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAED/RzSL8j2BLAulbZohRGsAF42PS5Co79ptsBoQEicZSod8r79WOJ4vOGYQeicE1kw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 51, 'esf_jo_user', 'ESF_JO_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEAAljIl8WD1wCJrPU9ggK9SJMir3rIs7ziWm+ib0nGeTTLHctDUxxsQhsJP8tTdlAg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 52, 'esf_lbm_admin', 'ESF_LBM_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEAupG/M5XDxWL1ZQz9iTVXo2d1rdpYFc7qGSGs2Hj4oToURMWiTn24hZGCQq9dyemw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 52, 'esf_lbm_user', 'ESF_LBM_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEBYgz9F2D5oSeziduOA7VxLPOPM36ODwTXV72tYdBx+XquGxnCXjySjQS9IJgHJ9Eg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 53, 'esf_mcr_admin', 'ESF_MCR_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEFG98BeYflT5UoFzApJnS023phmn0mwsjPO0jnHzdXwOUUccrdYYW6Bw+GfPhvoGRw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 53, 'esf_mcr_user', 'ESF_MCR_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAENUUW4gdhEh7DJKw0fH6w7watwT1r+X1D/pZZ/9K6c5P2ck1UD0yH7S/zJPhO874OA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 54, 'esf_ng_admin', 'ESF_NG_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEO5rFlb9O36UeV47+o7FEMqEuUTPul4GjTvxX/C74ZE3W6App72LcByovi8ZOV+0hQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 54, 'esf_ng_user', 'ESF_NG_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEKO151w7ySdteP1tmaOhm4Jta0t0SeJMjl5co/nsIlXunQV96fbTVZp5L+JNGQLodw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 55, 'esf_ogp_admin', 'ESF_OGP_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAELLDPpeir15UlZ7KBj/6uZ+fNH7/3Z2wr1MQwov43LqVZupc3Rrzx6r7wngRlFSILA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 55, 'esf_ogp_user', 'ESF_OGP_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEEi+G8YlbQdC3/xi9mu7tH3WjhCEHxWcanVMUdQHE3S9cNdwkyavw4bxABqlbr24tw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 56, 'esf_ojb_admin', 'ESF_OJB_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEEyA0fjr2Lrnak2Nc47q/Aiw4LfUCInSswQeSGmfrnBOMj6+fG/7FCJbedUNpCWqhA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 56, 'esf_ojb_user', 'ESF_OJB_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAENAIaJfu5jYakIAn9uEnvZWSPg19LTQL1ias/5/qXJERqFmBN7MSrw2+GTn1X4sbaw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 57, 'esf_fbv_admin', 'ESF_FBV_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEIbkGLpMG3FRXXPfXKoAueuJFaBL3Wv1IIXghVw2RBVr+WR7CFxc/y0RDod2/IozqA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 57, 'esf_fbv_user', 'ESF_FBV_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEMWPpTQG49O+LAPXAO0K4x+mdY7Zd6CaBlhsdjRus0Yfvb3odB+7VQc8aUygKCWNtQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 58, 'esf_bf_admin', 'ESF_BF_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEJJTLGbNwf1KwHn6xsN7VAUCxZpGfU7qj/tO+AG6ae2KCd08PfIV2fYpKxBizPcfvQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 58, 'esf_bf_user', 'ESF_BF_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEINH+fq2L/Q1ScuW8WzDnHfk/3qDeu6cEEwQhopFG58xPVOBUUpkSt3BOhoE9XBc7A==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 59, 'esf_asp_admin', 'ESF_ASP_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEP2KLrwFKJqC5q2q3va/1RyuO0TFVGFu8JIr+E6EsEDj/4LPVigo0cBBu5LVLIKd2w==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 59, 'esf_asp_user', 'ESF_ASP_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAECTaMb56SFZmN0I7QuMxLcc7BiYi3fy3wX3cfSykG0xDFHJmMGU6BvMzRFBnU3/6CQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 60, 'cr_admin', 'CR_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAENCL/UfpCF7AGtWBEARX+STNx4etGXqXEx8AlSKIHugxpmgijaN96aIPQM2YinH+jw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 60, 'cr_user', 'CR_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEIv40keO92ZCJo0PKPEL0nIJR76Jfe/VsTAvN+OMDjQzoTc1UILxeSnUhzWLpK4bUw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, @NOW, 0, 61, 'co_sof_admin', 'CO_SOF_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEF6e7kCt1IXrF6uppR2lJ0QC1m/CiNk153AiSE0auMN2FIzdaBsJWye8EhMLEsN+cw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, @NOW, 0, 61, 'co_sof_user', 'CO_SOF_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEB7l0HdYOx0719/TzgHZSi/MSiXO50r+wsGPAOXv2LeY9KUtUaNvPmdRvumn3ZcHnA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, @NOW, 0, 62, 'cm_imdp_admin', 'CM_IMDP_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEE9rhH8Qet7DtebCZuqY9dhV72ODgqKM9I4T+S7Oc7tRmna2Q565hxuwv+fgKeD9BA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, @NOW, 0, 62, 'cm_imdp_user', 'CM_IMDP_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEIa1cvqZU9hUZdFleF5GM0jYBTecIRQTJtM35XPh8pbIVvWqpgabrlp/zBP7I5OO+g==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 63, 'ci_hmca_admin', 'CI_HMCA_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEAgUUTyxnUO+SeP1wqR9xFVGOjiBpZyzWNQk99iwDNme4ELRVMIyNltdahkZwZQWLQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 63, 'ci_hmca_user', 'CI_HMCA_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEChDjkqWQlh8pjzAcYFoDhIERqZJjl5iN/p5ynNnh8KRec6WwJ1yNpAvB9KjvK3qAg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 64, 'cs_rct_admin', 'CS_RCT_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEKaarSg41ZUXAgk4lgvBnvOblwbRV8tIfrBSsCeFUifXGXRuQpDz1DA5y0ofssFCFA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 64, 'cs_rct_user', 'CS_RCT_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEE9wylBXK19SMMmqvtrwutChbxNBCP2Kn1hdBMKEfdPg3l9rpDw2MLr2023KlbXHVw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 65, 'csm_jad_admin', 'CSM_JAD_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEDVxdAN9GLSPdsTnjRMtMacMVkb62SASVz6fHzGx+KYbMxoDKDk6ycA7lAOqLliEDg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 65, 'csm_jad_user', 'CSM_JAD_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEHpmkGXdAmfRtzzw5bgtnSxr4honedh/p6kurP94Ni09nu0Ow+PH9mZRNx/2icKt8w==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, @NOW, 0, 66, 'cim_admin', 'CIM_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEJLNLl0px54ELyKVV0lloFJbnlaM45VGFhSkTc4d5dR+Fwg75PMHSs9XXsRWk7gbRQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, @NOW, 0, 66, 'cim_user', 'CIM_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEOWBjhb1rdKgF5rU2l3DTa+hypIJgiU9mesofoD8lkTb617jve/G2aVlNJrH6cUDYQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, @NOW, 0, 67, 'cdis_admin', 'CDIS_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEDHFso++6mDy0SVr7yQzeDmVdtl2V91sXS7VU+bjkEic+rmSvhZO8E6dxQajGXyX0g==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, @NOW, 0, 67, 'cdis_user', 'CDIS_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEFgJ1Eguus+oX10oOOGdqmNPkicBEZCtmXXGXByXxA1FcMCj1ZyKjE1b94hcoog/LQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 68, 'caps_ij_admin', 'CAPS_IJ_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEBqOQ5x/GHXEAyUZGLw/iD6Mqpyk/ma9MOsl2ZY/R//x5hqjL+0598XGLcm6wqBEWw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 68, 'caps_ij_user', 'CAPS_IJ_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEAW5H1r+gd+rJ3zr308+2Fxo9IvgFa5ZguUGDJjDWK2ZX2f+tvVFJHpL/irOp6fycw==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 69, 'caps_icv_admin', 'CAPS_ICV_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEM5ayTOMDaxjjL9OTMgtXZMLRBx5NNZWbdjk0PabppFLI3rUp/QPGc034gGzlzoB2g==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 69, 'caps_icv_user', 'CAPS_ICV_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAECVdCsPDxq2+1K5LuhvwBCBP9CQ+12LYX745OqQg3eVnO5SvPmNi0F7MlHQPfjSYLQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 70, 'caps_as_admin', 'CAPS_AS_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEN+7nYYFrwTbzW/sY+5Qkb1k6P295CDFVvUm1mM/TU8APXIDdwIoxk+9RH3RMGMDjg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 70, 'caps_as_user', 'CAPS_AS_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEGuImZNfNz/R9ejoxm3EEHe2XovJG7JL3rKMVwjoisLG2OCu3A4j7UNwrl75wLcIHQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 71, 'apae_admin', 'APAE_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAECRlgrUvKxr13AqAmpP1A/YLJ96hjR8R9CqQL94jNRXSxIjaaNdnzXCsWvnHlBJoMQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 71, 'apae_user', 'APAE_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEPwpEEiCAj27UYkEHxBLnj6DR+NLVivFMXu0HpiCjAYiH8SFrJMPcQ66iPmiDd2fuQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 72, 'cdi_admin', 'CDI_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEGcdPGLtTPVBf7nEZkQNXLW8WPDvf9WZYILPfhy3BWc29ldeYnOFrzWRX7iJYaFPlg==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 72, 'cdi_user', 'CDI_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEB3uLK1LdeQ8ru1IAVxd/zDhXxzdlaX04YC3eAicwK3+eeMrP3wl1j7QSn2WvVeifQ==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

            (@NOW, NULL, 1, 73, 'cdb_admin', 'CDB_ADMIN', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEMJt1byOsA2sNlRR4yV3faUB9az83fwKDZ2uxgMlDfw6Npq4KfsFEx+af33J8cYE/A==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),
            (@NOW, NULL, 1, 73, 'cdb_user', 'CDB_USER', NULL, NULL, 0, 'AQAAAAIAAYagAAAAEIQO0SpBsvmevziwDg6COjjMopZCuqvF+hHJxd/qSxBB/0hihRRSo/up10NJTqneaA==', NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0);
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

INSERT INTO [dbo].[AspNetUserRoles]
            ([UserId]
            ,[RoleId])
     VALUES
            -- ('UserId', 'RoleId'),
            -- (1, 1),
            (2, 2),
            (3, 3),

            (4, 1),
            (5, 2),
            (6, 3),
            (7, 3),

            (8, 2),
            (9, 3),

            (10, 2),
            (11, 3),

            (12, 2),
            (13, 3),

            (14, 2),
            (15, 3),

            (16, 2),
            (17, 3),

            (18, 2),
            (19, 3),

            (20, 2),
            (21, 3),

            (22, 2),
            (23, 3),

            (24, 2),
            (25, 3),

            (26, 2),
            (27, 3),

            (28, 2),
            (29, 3),

            (30, 2),
            (31, 3),

            (32, 2),
            (33, 3),

            (34, 2),
            (35, 3),

            (36, 2),
            (37, 3),

            (38, 2),
            (39, 3),

            (40, 2),
            (41, 3),

            (42, 2),
            (43, 3),

            (44, 2),
            (45, 3),

            (46, 2),
            (47, 3),

            (48, 2),
            (49, 3),

            (50, 2),
            (51, 3),

            (52, 2),
            (53, 3),

            (54, 2),
            (55, 3),

            (56, 2),
            (57, 3),

            (58, 2),
            (59, 3),

            (60, 2),
            (61, 3),

            (62, 2),
            (63, 3),

            (64, 2),
            (65, 3),

            (66, 2),
            (67, 3),

            (68, 2),
            (69, 3),

            (70, 2),
            (71, 3),

            (72, 2),
            (73, 3),

            (74, 2),
            (75, 3),

            (76, 2),
            (77, 3),

            (78, 2),
            (79, 3),

            (80, 2),
            (81, 3),

            (82, 2),
            (83, 3),

            (84, 2),
            (85, 3),

            (86, 2),
            (87, 3),

            (88, 2),
            (89, 3),

            (90, 2),
            (91, 3),

            (92, 2),
            (93, 3),

            (94, 2),
            (95, 3),

            (96, 2),
            (97, 3),

            (98, 2),
            (99, 3),

            (100, 2),
            (101, 3),

            (102, 2),
            (103, 3),

            (104, 2),
            (105, 3),

            (106, 2),
            (107, 3),

            (108, 2),
            (109, 3),

            (110, 2),
            (111, 3),

            (112, 2),
            (113, 3),

            (114, 2),
            (115, 3),

            (116, 2),
            (117, 3),

            (118, 2),
            (119, 3),

            (120, 2),
            (121, 3),

            (122, 2),
            (123, 3),

            (124, 2),
            (125, 3),

            (126, 2),
            (127, 3),

            (128, 2),
            (129, 3),

            (130, 2),
            (131, 3),

            (132, 2),
            (133, 3),

            (134, 2),
            (135, 3),

            (136, 2),
            (137, 3),

            (138, 2),
            (139, 3),

            (140, 2),
            (141, 3),

            (142, 2),
            (143, 3),

            (144, 2),
            (145, 3),

            (146, 2),
            (147, 3),

            (148, 2),
            (149, 3);
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

INSERT INTO [dbo].[Receiving]
           ([InvoiceNumber]
           ,[SupplyAuthorization]
           ,[Observation]
           ,[ReceivingDate]
           ,[TotalValue]
           ,[SupplierId]
           ,[ResponsibleId]
           ,[AccountId])
     VALUES
           -- (<InvoiceNumber, nvarchar(max),>
           -- ,<SupplyAuthorization, nvarchar(max),>
           -- ,<Observation, nvarchar(max),>
           -- ,<ReceivingDate, datetime2(7),>
           -- ,<TotalValue, decimal(18,2),>
           -- ,<SupplierId, int,>
           -- ,<ResponsibleId, int,>
           -- ,<AccountId, int,>),
           ('365217498', 'AF 2020/000001', '', '2020-01-06', 4321.50, 10, 7, 6), -- Receiving 1
           ('194623087', 'AF 2020/000002', '', '2020-01-09', 8000.00, 1, 12, 7), -- Receiving 2
           ('748291305', 'AF 2020/000003', 'Atraso de 2 dias', '2020-01-17', 13693.08, 18, 12, 6), -- Receiving 3
           ('185062947', 'AF 2020/000004', '', '2020-02-11', 24729.20, 9, 7, 5), -- Receiving 4
           ('904153278', 'AF 2020/000005', '', '2020-02-27', 14167.10, 3, 8, 7), -- Receiving 5
           ('632790415', 'AF 2020/000006', '', '2020-03-05', 7193.00, 26, 19, 6), -- Receiving 6
           ('129467381', 'AF 2020/000007', '', '2020-04-08', 9763.68, 11, 4, 5), -- Receiving 7
           ('470318926', 'AF 2020/000008', 'Caixa rasgada', '2020-06-23', 12647.30, 30, 7, 7),   -- Receiving 8
           ('386250197', 'AF 2020/000009', '', '2020-07-14', 11912.95, 5, 8, 6), -- Receiving 9
           ('702185634', 'AF 2020/000010', '', '2020-09-01', 75704.40, 1, 12, 5), -- Receiving 10
           ('217843506', 'AF 2020/000011', '', '2020-10-19', 27989.70, 21, 19, 6), -- Receiving 11
           ('593710824', 'AF 2020/000012', '', '2020-12-06', 22913.75, 15, 4, 7), -- Receiving 12
           ('912345678', 'AF 2021/000013', '', '2021-01-12', 10300.50, 17, 7, 5), -- Receiving 13
           ('823456789', 'AF 2021/000014', 'Recebimento ok', '2021-01-25', 118900.20, 9, 12, 6), -- Receiving 14
           ('734567890', 'AF 2021/000015', '', '2021-02-08', 47068.00, 25, 8, 7), -- Receiving 15
           ('645678901', 'AF 2021/000016', '', '2021-02-28', 17310.20, 12, 4, 5), -- Receiving 16
           ('556789012', 'AF 2021/000017', '', '2021-03-14', 40989.70, 31, 19, 6), -- Receiving 17
           ('467890123', 'AF 2021/000018', 'Chegou atrasado', '2021-03-30', 28714.40, 22, 7, 7), -- Receiving 18
           ('378901234', 'AF 2021/000019', '', '2021-04-11', 22973.70, 7, 4, 6), -- Receiving 19
           ('289012345', 'AF 2021/000020', '', '2021-04-29', 29841.5, 14, 8, 5), -- Receiving 20
           ('190123456', 'AF 2021/000021', '', '2021-05-18', 13971.50, 2, 19, 6), -- Receiving 21
           ('901234567', 'AF 2021/000022', '', '2021-06-05', 7885.0, 30, 12, 7), -- Receiving 22
           ('812345679', 'AF 2021/000023', '', '2021-07-23', 20539.90, 20, 7, 5), -- Receiving 23
           ('723456780', 'AF 2021/000024', '', '2021-08-10', 77458.50, 5, 4, 6), -- Receiving 24
           ('634567891', 'AF 2021/000025', '', '2021-08-29', 39842.90, 13, 8, 7), -- Receiving 25
           ('545678902', 'AF 2021/000026', '', '2021-09-14', 33145.40, 8, 19, 5), -- Receiving 26
           ('456789013', 'AF 2021/000027', '', '2021-11-30', 44072.30, 1, 12, 6), -- Receiving 27
           ('123456789', 'AF 2022/000028', '', '2022-01-15', 58234.10, 7, 4, 6), -- Receiving 28
           ('987654321', 'AF 2022/000029', 'Atraso de 1 dia', '2022-02-20', 49167.70, 14, 8, 5), -- Receiving 29
           ('564738291', 'AF 2022/000030', '', '2022-03-10', 16960.90, 2, 19, 6), -- Receiving 30
           ('192837465', 'AF 2022/000031', '', '2022-04-25', 32909.50, 30, 12, 7), -- Receiving 31
           ('847362519', 'AF 2022/000032', '', '2022-05-18', 16208.50, 20, 7, 5), -- Receiving 32
           ('675849302', 'AF 2022/000033', '', '2022-06-29', 54042.30, 5, 4, 6), -- Receiving 33
           ('310294857', 'AF 2022/000034', '', '2022-07-07', 29762.90, 13, 8, 7), -- Receiving 34
           ('908172635', 'AF 2022/000035', '', '2022-08-16', 4891.10, 8, 19, 5), -- Receiving 35
           ('564538291', 'AF 2022/000036', '', '2022-09-30', 39087.40, 1, 12, 6), -- Receiving 36
           ('123987654', 'AF 2022/000037', 'Caixa rasgada', '2022-10-22', 16311.70, 1, 12, 6), -- Receiving 37
           ('789654123', 'AF 2022/000038', '', '2022-11-15', 22085.90, 1, 12, 6), -- Receiving 38
           ('321654987', 'AF 2023/000039', '', '2023-01-09', 36876.75, 17, 9, 6), -- Receiving 39
           ('654123789', 'AF 2023/000040', '', '2023-01-25', 68622.60, 3, 3, 7), -- Receiving 40
           ('789321456', 'AF 2023/000041', '', '2023-02-12', 33552.62, 28, 11, 5), -- Receiving 41
           ('912834756', 'AF 2023/000042', '', '2023-03-03', 37898.10, 12, 7, 6), -- Receiving 42
           ('203948576', 'AF 2023/000043', '', '2023-03-27', 9523.80, 7, 15, 5), -- Receiving 43
           ('758392046', 'AF 2023/000044', '', '2023-04-11', 8139.40, 30, 18, 7), -- Receiving 44
           ('847362910', 'AF 2023/000045', '', '2023-04-26', 8063.80, 6, 6, 6), -- Receiving 45
           ('619283745', 'AF 2023/000046', '', '2023-05-07', 13515.70, 14, 4, 5), -- Receiving 46
           ('305948172', 'AF 2023/000047', '', '2023-05-30', 59984.60, 24, 7, 6), -- Receiving 47
           ('584729103', 'AF 2023/000048', '', '2023-06-14', 23389.90, 2, 10, 5), -- Receiving 48
           ('294857103', 'AF 2023/000049', '', '2023-07-02', 9640.10, 19, 6, 6), -- Receiving 49
           ('719384650', 'AF 2023/000050', '', '2023-07-29', 115291.12, 21, 13, 7), -- Receiving 50
           ('850294716', 'AF 2023/000051', 'Chegou atrasado', '2023-08-18', 9214.40, 9, 11, 5), -- Receiving 51
           ('739201846', 'AF 2023/000052', '', '2023-09-05', 15958.00, 33, 14, 6), -- Receiving 52
           ('684920173', 'AF 2023/000053', '', '2023-09-28', 17751.80, 5, 2, 7), -- Receiving 53
           ('310487259', 'AF 2023/000054', '', '2023-10-13', 13104.30, 8, 9, 5), -- Receiving 54
           ('902384716', 'AF 2023/000055', '', '2023-11-22', 12783.30, 1, 17, 6), -- Receiving 55
           ('487215309', 'AF 2024/000056', '', '2024-01-10', 14807.36, 11, 5, 7), -- Receiving 56
           ('593820174', 'AF 2024/000057', '', '2024-01-29', 66469.80, 22, 9, 6), -- Receiving 57
           ('120398475', 'AF 2024/000058', '', '2024-02-15', 23996.80, 3, 12, 5), -- Receiving 58
           ('876543210', 'AF 2024/000059', '', '2024-03-03', 17772.60, 29, 4, 7), -- Receiving 59
           ('340918273', 'AF 2024/000060', '', '2024-03-25', 10219.20, 17, 7, 6), -- Receiving 60
           ('729384650', 'AF 2024/000061', '', '2024-04-08', 19408.90, 14, 11, 5), -- Receiving 61
           ('834920175', 'AF 2024/000062', '', '2024-04-22', 11423.10, 9, 14, 7), -- Receiving 62
           ('650293847', 'AF 2024/000063', '', '2024-05-14', 16001.90, 31, 6, 5), -- Receiving 63
           ('312094857', 'AF 2024/000064', '', '2024-05-30', 13847.00, 8, 13, 6), -- Receiving 64
           ('592837104', 'AF 2024/000065', '', '2024-06-13', 16661.54, 2, 10, 7), -- Receiving 65
           ('849201736', 'AF 2024/000066', '', '2024-07-05', 25269.40, 20, 9, 5), -- Receiving 66
           ('703918246', 'AF 2024/000067', '', '2024-07-28', 21566.40, 7, 15, 6), -- Receiving 67
           ('958273640', 'AF 2024/000068', '', '2024-08-17', 18547.00, 26, 8, 7), -- Receiving 68
           ('614203987', 'AF 2024/000069', '', '2024-09-06', 17672.00, 13, 4, 5), -- Receiving 69
           ('735810294', 'AF 2024/000070', '', '2024-10-29', 17141.20, 15, 11, 6), -- Receiving 70
           ('309485726', 'AF 2024/000071', '', '2024-10-12', 26966.92, 28, 7, 7), -- Receiving 71
           ('901284736', 'AF 2024/000072', '', '2024-12-21', 73055.00, 1, 12, 5); -- Receiving 72
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

INSERT INTO [dbo].[ReceivingItem]
           ([Quantity]
           ,[UnitValue]
           ,[TotalValue]
           ,[Batch]
           ,[ExpiryDate]
           ,[ProductId]
           ,[ReceivingId])
     VALUES
           -- (<Quantity, int,>
           -- ,<UnitValue, decimal(18,2),>
           -- ,<TotalValue, decimal(18,2),>
           -- ,<Batch, nvarchar(max),>
           -- ,<ExpiryDate, datetime2(7),>
           -- ,<ProductId, int,>
           -- ,<ReceivingId, int,>),
           (2500, 0.34, 850, 'LOT123456', '2025-02-01', 5, 1), -- Receiving 1
           (1800, 0.48, 864, 'LOT673456', '2026-09-06', 8, 1), -- Receiving 1
           (2450, 0.91, 2229.5, 'LOT273456', '2027-09-26', 25, 1), -- Receiving 1
           (900, 0.42, 378, 'LOT283446', '2026-10-16', 10, 1), -- Receiving 1

           (12500, 0.64, 8000, 'LOT563456', '2025-05-08', 100, 2), -- Receiving 2
           (10500, 0.92, 9660, 'LOT374556', '2027-04-18', 25, 2), -- Receiving 2
           (4500, 1.84, 8280, 'LOT343745', '2024-07-26', 14, 2), -- Receiving 2
           (8600, 0.73, 6278, 'LOT756346', '2028-01-21', 33, 2), -- Receiving 2
           (7500, 1.05, 7875, 'LOT975456', '2023-08-14', 75, 2), -- Receiving 2
           (10500, 0.99, 10395, 'LOT124456', '2022-02-13', 89, 2), -- Receiving 2

           (2235, 0.68, 1519.8, 'LOT737388', '2026-12-26', 120, 3), -- Receiving 3
           (1827, 0.54, 986.58, 'LOT605907', '2029-02-08', 89, 3), -- Receiving 3
           (1864, 0.58, 1081.12, 'LOT769390', '2027-05-13', 148, 3), -- Receiving 3
           (2082, 0.04, 83.28, 'LOT515983', '2028-10-13', 63, 3), -- Receiving 3
           (1976, 0.2, 395.2, 'LOT348892', '2026-09-02', 103, 3), -- Receiving 3
           (2020, 0.13, 262.6, 'LOT326038', '2028-05-13', 143, 3), -- Receiving 3
           (307, 1.9, 583.3, 'LOT726754', '2026-05-20', 13, 3), -- Receiving 3
           (1619, 2.7, 4371.3, 'LOT148928', '2025-11-19', 20, 3), -- Receiving 3
           (2610, 1.69, 4410.9, 'LOT519061', '2028-08-08', 83, 3), -- Receiving 3

           (1550, 0.19, 294.50, 'LOT778619', '2029-01-10', 115, 4), -- Receiving 4
           (2610, 0.38, 991.80, 'LOT607306', '2026-10-20', 29, 4), -- Receiving 4
           (1060, 0.99, 1049.40, 'LOT823972', '2027-04-23', 106, 4), -- Receiving 4
           (2150, 0.24, 516.00, 'LOT936252', '2025-09-22', 12, 4), -- Receiving 4
           (335, 1.25, 418.75, 'LOT356433', '2028-04-07', 136, 4), -- Receiving 4
           (920, 0.67, 616.40, 'LOT206384', '2026-02-25', 128, 4), -- Receiving 4
           (7360, 0.8, 5888.00, 'LOT676476', '2026-01-01', 148, 4), -- Receiving 4
           (1160, 4.48, 5196.80, 'LOT682569', '2027-11-09', 59, 4), -- Receiving 4
           (2660, 0.53, 1409.80, 'LOT495476', '2025-10-25', 36, 4), -- Receiving 4
           (1300, 0.06, 78.00, 'LOT972084', '2029-02-06', 95, 4), -- Receiving 4
           (3460, 1.56, 5397.60, 'LOT253695', '2028-12-20', 31, 4), -- Receiving 4
           (2565, 1.51, 3873.15, 'LOT792708', '2028-02-03', 54, 4), -- Receiving 4

           (2450, 0.21, 514.50, 'LOT791078', '2027-10-17', 19, 5), -- Receiving 5
           (1960, 0.53, 1038.80, 'LOT756513', '2025-11-21', 5, 5), -- Receiving 5
           (2120, 0.32, 678.40, 'LOT643581', '2028-12-30', 8, 5), -- Receiving 5
           (465, 2.44, 1134.60, 'LOT625352', '2027-01-30', 133, 5), -- Receiving 5
           (2100, 0.16, 336.00, 'LOT147058', '2026-01-24', 77, 5), -- Receiving 5
           (1420, 1.74, 2470.80, 'LOT325631', '2028-09-30', 113, 5), -- Receiving 5
           (750, 10.66, 7995.00, 'LOT215995', '2029-01-24', 115, 5), -- Receiving 5

           (1840, 0.15, 276.00, 'LOT972114', '2026-03-16', 87, 6), -- Receiving 6
           (2280, 0.74, 1687.20, 'LOT869678', '2027-11-02', 13, 6), -- Receiving 6
           (1240, 0.98, 1215.20, 'LOT945176', '2026-02-24', 27, 6), -- Receiving 6
           (2560, 0.29, 742.40, 'LOT658108', '2028-10-13', 96, 6), -- Receiving 6
           (2750, 0.22, 605.00, 'LOT211628', '2028-02-21', 104, 6), -- Receiving 6
           (1910, 1.92, 3667.20, 'LOT373648', '2027-11-11', 3, 6), -- Receiving 6

           (460, 0.63, 289.80, 'LOT120386', '2028-08-25', 101, 7), -- Receiving 7
           (1130, 0.89, 1005.70, 'LOT282095', '2025-09-26', 13, 7), -- Receiving 7
           (1860, 0.36, 669.60, 'LOT823168', '2026-01-21', 41, 7), -- Receiving 7
           (820, 0.94, 770.80, 'LOT722766', '2026-02-16', 9, 7), -- Receiving 7
           (2960, 0.59, 1746.40, 'LOT710284', '2028-04-02', 43, 7), -- Receiving 7
           (15860, 3.33, 5281.38, 'LOT851021', '2027-04-28', 70, 7), -- Receiving 7

           (1220, 0.41, 500.20, 'LOT920885', '2027-08-25', 34, 8), -- Receiving 8
           (1775, 0.47, 834.25, 'LOT883557', '2025-08-04', 9, 8), -- Receiving 8
           (1060, 0.30, 318.00, 'LOT501451', '2026-03-11', 121, 8), -- Receiving 8
           (6130, 1.20, 7356.00, 'LOT537656', '2027-01-16', 127, 8), -- Receiving 8
           (2740, 0.27, 739.80, 'LOT486995', '2028-10-24', 140, 8), -- Receiving 8
           (1110, 0.44, 488.40, 'LOT291341', '2027-09-22', 141, 8), -- Receiving 8
           (2435, 0.99, 2410.65, 'LOT931488', '2025-11-12', 136, 8), -- Receiving 8

           (193, 2.09, 403.37, 'LOT782326', '2026-07-02', 101, 9), -- Receiving 9
           (1633, 0.68, 1110.44, 'LOT326134', '2027-03-15', 83, 9), -- Receiving 9
           (1309, 0.32, 418.88, 'LOT428827', '2028-10-17', 59, 9), -- Receiving 9
           (2913, 0.26, 757.38, 'LOT329369', '2028-07-25', 111, 9), -- Receiving 9
           (2769, 0.14, 387.66, 'LOT753836', '2028-09-01', 15, 9), -- Receiving 9
           (2089, 0.25, 522.25, 'LOT171020', '2027-05-28', 10, 9), -- Receiving 9
           (2523, 0.89, 2245.47, 'LOT747209', '2028-08-07', 50, 9), -- Receiving 9
           (1618, 3.75, 6067.50, 'LOT600960', '2028-12-24', 123, 9), -- Receiving 9

           (460, 2.14, 984.40, 'LOT306132', '2026-06-22', 103, 10), -- Receiving 10
           (1430, 3.69, 5276.70, 'LOT796781', '2027-03-10', 140, 10), -- Receiving 10
           (5300, 1.24, 6572.00, 'LOT854546', '2026-11-20', 62, 10), -- Receiving 10
           (7180, 1.19, 8544.20, 'LOT448469', '2027-02-19', 8, 10), -- Receiving 10
           (25970, 0.25, 6492.50, 'LOT531305', '2027-08-18', 25, 10), -- Receiving 10
           (25580, 1.87, 47834.60, 'LOT931040', '2026-07-30', 99, 10), -- Receiving 10

           (2530, 0.06, 151.80, 'LOT474021', '2028-11-15', 109, 11), -- Receiving 11
           (1850, 0.41, 758.50, 'LOT209581', '2026-06-27', 99, 11), -- Receiving 11
           (1540, 0.32, 492.80, 'LOT378474', '2027-12-20', 65, 11), -- Receiving 11
           (1770, 0.49, 867.30, 'LOT801189', '2028-05-08', 109, 11), -- Receiving 11
           (6140, 2.08, 12771.20, 'LOT437595', '2027-09-16', 100, 11), -- Receiving 11
           (2850, 2.20, 6270.00, 'LOT561048', '2028-04-17', 97, 11), -- Receiving 11
           (2050, 0.33, 676.50, 'LOT371565', '2025-06-03', 67, 11), -- Receiving 11
           (2480, 2.42, 6001.60, 'LOT713090', '2026-03-20', 27, 11), -- Receiving 11

           (2440, 0.34, 829.60, 'LOT715292', '2027-02-27', 130, 12), -- Receiving 12
           (1960, 0.21, 411.60, 'LOT146413', '2027-01-08', 18, 12), -- Receiving 12
           (1115, 0.21, 234.15, 'LOT351641', '2026-01-18', 66, 12), -- Receiving 12
           (2360, 0.39, 920.40, 'LOT179462', '2028-07-28', 77, 12), -- Receiving 12
           (2860, 0.18, 514.80, 'LOT744401', '2026-09-27', 34, 12), -- Receiving 12
           (26200, 1.03, 2698.60, 'LOT518301', '2028-01-10', 122, 12), -- Receiving 12
           (2640, 0.55, 1452.00, 'LOT319324', '2025-08-23', 135, 12), -- Receiving 12
           (9390, 0.99, 9296.10, 'LOT147365', '2026-06-14', 142, 12), -- Receiving 12
           (1410, 4.65, 6556.50, 'LOT698022', '2026-11-03', 29, 12), -- Receiving 12

           (680, 2.0, 1360.00, 'LOT873794', '2023-03-09', 43, 13), -- Receiving 13
           (2550, 0.39, 994.50, 'LOT333717', '2028-01-21', 102, 13), -- Receiving 13
           (1030, 0.82, 844.60, 'LOT284390', '2027-05-18', 4, 13), -- Receiving 13
           (2550, 0.37, 943.50, 'LOT225008', '2028-06-12', 116, 13), -- Receiving 13
           (1710, 0.91, 1556.10, 'LOT314797', '2025-08-24', 12, 13), -- Receiving 13
           (1160, 0.52, 603.20, 'LOT232466', '2026-11-08', 107, 13), -- Receiving 13
           (2840, 0.4, 1136.00, 'LOT546474', '2028-01-19', 49, 13), -- Receiving 13
           (390, 7.34, 2862.60, 'LOT566229', '2027-01-23', 119, 13), -- Receiving 13

           (1210, 0.68, 822.80, 'LOT871458', '2026-04-01', 144, 14), -- Receiving 14
           (29530, 0.15, 4429.50, 'LOT979870', '2028-02-02', 28, 14), -- Receiving 14
           (19040, 0.8, 15232.00, 'LOT890973', '2023-09-23', 74, 14), -- Receiving 14
           (16690, 1.01, 16856.90, 'LOT753211', '2024-01-18', 118, 14), -- Receiving 14
           (2850, 0.36, 1026.00, 'LOT315505', '2023-02-17', 74, 14), -- Receiving 14
           (23100, 0.81, 18711.00, 'LOT447009', '2026-11-30', 138, 14), -- Receiving 14
           (4550, 4.9, 22295.00, 'LOT142287', '2028-03-28', 34, 14), -- Receiving 14
           (17640, 1.29, 22755.60, 'LOT432488', '2025-02-13', 94, 14), -- Receiving 14
           (6420, 4.17, 26771.40, 'LOT717190', '2028-02-11', 116, 14), -- Receiving 14

           (6440, 1.94, 12481.60, 'LOT126700', '2023-04-04', 117, 15), -- Receiving 15
           (2440, 0.28, 683.20, 'LOT871059', '2026-03-21', 127, 15), -- Receiving 15
           (1000, 2.12, 2120.00, 'LOT630080', '2026-07-20', 148, 15), -- Receiving 15
           (2280, 0.75, 1710.00, 'LOT686541', '2023-06-13', 37, 15), -- Receiving 15
           (10300, 0.84, 8652.00, 'LOT932736', '2025-08-23', 97, 15), -- Receiving 15
           (1290, 0.41, 528.90, 'LOT879891', '2023-04-05', 96, 15), -- Receiving 15
           (21600, 0.69, 14904.00, 'LOT940595', '2025-05-22', 9, 15), -- Receiving 15
           (2870, 1.39, 3989.30, 'LOT321311', '2028-11-22', 10, 15), -- Receiving 15

           (390, 3.3, 1287.00, 'LOT626741', '2027-06-15', 114, 16), -- Receiving 16
           (6750, 0.52, 3510.00, 'LOT295576', '2023-03-18', 61, 16), -- Receiving 16
           (2300, 2.33, 5359.00, 'LOT875792', '2026-05-06', 69, 16), -- Receiving 16
           (2160, 1.23, 2656.80, 'LOT198023', '2024-10-09', 28, 16), -- Receiving 16
           (2260, 1.99, 4497.40, 'LOT340026', '2027-02-19', 71, 16), -- Receiving 16

           (2430, 0.35, 850.50, 'LOT382124', '2023-05-06', 33, 17), -- Receiving 17
           (10820, 0.41, 4436.20, 'LOT758498', '2026-08-03', 27, 17), -- Receiving 17
           (470, 2.46, 1156.20, 'LOT235603', '2025-07-16', 50, 17), -- Receiving 17
           (6120, 1.99, 1218.00, 'LOT621693', '2023-10-30', 96, 17), -- Receiving 17
           (870, 1.29, 1122.30, 'LOT270117', '2026-12-22', 11, 17), -- Receiving 17
           (990, 1.62, 1603.80, 'LOT769680', '2023-10-12', 23, 17), -- Receiving 17
           (12600, 0.84, 10584.00, 'LOT597956', '2025-10-26', 121, 17), -- Receiving 17
           (690, 1.37, 945.30, 'LOT445324', '2027-07-29', 129, 17), -- Receiving 17
           (29660, 0.64, 18982.40, 'LOT254930', '2027-11-09', 11, 17), -- Receiving 17

           (570, 1.92, 1094.40, 'LOT316157', '2027-11-14', 132, 18), -- Receiving 18
           (960, 2.4, 2304.00, 'LOT388848', '2024-07-25', 131, 18), -- Receiving 18
           (2270, 1.03, 2338.10, 'LOT909532', '2023-11-10', 24, 18), -- Receiving 18
           (19370, 0.99, 19176.30, 'LOT929357', '2023-03-19', 88, 18), -- Receiving 18
           (1280, 2.97, 3801.60, 'LOT457586', '2028-11-12', 58, 18), -- Receiving 18

           (1750, 0.35, 612.5, 'LOT619809', '2025-08-16', 58, 19), -- Receiving 19
           (2320, 0.33, 765.6, 'LOT541329', '2026-04-08', 2, 19), -- Receiving 19
           (2370, 0.28, 663.6, 'LOT809357', '2027-09-09', 14, 19), -- Receiving 19
           (2620, 0.44, 1152.8, 'LOT874011', '2023-04-06', 57, 19), -- Receiving 19
           (28580, 0.45, 12861.0, 'LOT873548', '2024-09-27', 46, 19), -- Receiving 19
           (20190, 0.18, 3634.2, 'LOT361601', '2024-04-13', 113, 19), -- Receiving 19
           (1880, 1.8, 3384.0, 'LOT144373', '2027-12-23', 19, 19), -- Receiving 19

           (530, 1.34, 710.2, 'LOT576585', '2025-12-04', 116, 20), -- Receiving 20
           (860, 1.39, 1195.4, 'LOT866120', '2026-12-20', 75, 20), -- Receiving 20
           (1610, 1.09, 1749.9, 'LOT777803', '2024-09-01', 25, 20), -- Receiving 20
           (1930, 0.77, 1486.1, 'LOT689248', '2025-04-06', 10, 20), -- Receiving 20
           (1200, 0.83, 996.0, 'LOT885765', '2023-01-19', 90, 20), -- Receiving 20
           (20770, 0.95, 19731.5, 'LOT114340', '2024-09-14', 52, 20), -- Receiving 20
           (2280, 1.83, 4172.4, 'LOT607572', '2026-08-06', 9, 20), -- Receiving 20

           (445, 1.64, 729.8, 'LOT590435', '2023-01-29', 106, 21), -- Receiving 21
           (2650, 1.05, 2782.5, 'LOT888734', '2025-08-20', 41, 21), -- Receiving 21
           (1050, 1.52, 1596.0, 'LOT679635', '2026-09-04', 117, 21), -- Receiving 21
           (2340, 1.24, 2901.6, 'LOT882633', '2026-08-07', 128, 21), -- Receiving 21
           (1840, 3.24, 5961.6, 'LOT331676', '2027-08-30', 86, 21), -- Receiving 21

           (330, 1.62, 534.6, 'LOT460348', '2025-08-25', 120, 22), -- Receiving 22
           (880, 1.12, 985.6, 'LOT428539', '2024-04-01', 3, 22), -- Receiving 22
           (14300, 0.36, 5148.0, 'LOT237227', '2024-04-18', 46, 22), -- Receiving 22
           (20980, 0.58, 1216.8, 'LOT790864', '2023-08-25', 82, 22), -- Receiving 22

           (27400, 0.26, 7124.0, 'LOT448410', '2026-09-29', 22, 23), -- Receiving 23
           (2390, 0.65, 1553.5, 'LOT494713', '2023-06-11', 49, 23), -- Receiving 23
           (1630, 1.69, 2754.7, 'LOT312634', '2025-05-23', 143, 23), -- Receiving 23
           (15730, 0.54, 8494.2, 'LOT303800', '2025-06-28', 141, 23), -- Receiving 23
           (520, 1.18, 613.6, 'LOT139520', '2025-03-16', 37, 23), -- Receiving 23

           (1630, 0.9, 1467.0, 'LOT556311', '2023-07-20', 126, 24), -- Receiving 24
           (2510, 0.65, 1631.5, 'LOT378935', '2028-11-19', 28, 24), -- Receiving 24
           (15860, 0.41, 6502.6, 'LOT984353', '2024-12-25', 78, 24), -- Receiving 24
           (21880, 0.46, 10064.8, 'LOT596786', '2028-09-09', 113, 24), -- Receiving 24
           (2200, 0.13, 286.0, 'LOT943307', '2024-09-21', 38, 24), -- Receiving 24
           (21420, 1.18, 25275.6, 'LOT225277', '2028-06-19', 108, 24), -- Receiving 24
           (10550, 2.62, 27641.0, 'LOT128932', '2023-01-03', 100, 24), -- Receiving 24
           (2930, 1.43, 4190.0, 'LOT926313', '2026-01-11', 23, 24), -- Receiving 24

           (2690, 0.05, 134.5, 'LOT537008', '2025-08-23', 130, 25), -- Receiving 25
           (6920, 0.91, 6297.2, 'LOT263043', '2024-06-28', 8, 25), -- Receiving 25
           (16430, 0.09, 1478.7, 'LOT921894', '2024-08-16', 62, 25), -- Receiving 25
           (20820, 0.5, 10410.0, 'LOT831424', '2025-09-22', 108, 25), -- Receiving 25
           (2080, 1.38, 2870.4, 'LOT571896', '2023-05-15', 71, 25), -- Receiving 25
           (27090, 0.69, 18652.1, 'LOT220923', '2023-05-30', 117, 25), -- Receiving 25

           (2690, 0.41, 1102.9, 'LOT648986', '2024-02-01', 68, 26), -- Receiving 26
           (9910, 0.64, 6342.4, 'LOT345618', '2026-08-13', 138, 26), -- Receiving 26
           (19860, 0.32, 6355.2, 'LOT778753', '2027-12-17', 37, 26), -- Receiving 26
           (2770, 0.41, 1135.7, 'LOT292029', '2026-05-01', 43, 26), -- Receiving 26
           (23460, 0.68, 15952.8, 'LOT951262', '2023-08-30', 38, 26), -- Receiving 26
           (19540, 0.4, 7816.0, 'LOT779548', '2028-06-01', 138, 26), -- Receiving 26
           (2890, 0.36, 1040.4, 'LOT238874', '2026-04-13', 140, 26), -- Receiving 26
           (1800, 0.5, 900.0, 'LOT534039', '2024-06-29', 113, 26), -- Receiving 26

           (28460, 0.37, 10540.2, 'LOT801085', '2023-09-23', 58, 27), -- Receiving 27
           (2460, 0.52, 1279.2, 'LOT904335', '2025-11-17', 93, 27), -- Receiving 27
           (430, 1.28, 550.4, 'LOT507764', '2023-05-25', 120, 27), -- Receiving 27
           (18310, 0.57, 10446.7, 'LOT991266', '2028-10-10', 36, 27), -- Receiving 27
           (2180, 0.89, 1940.2, 'LOT650005', '2028-05-24', 81, 27), -- Receiving 27
           (1290, 0.82, 1057.8, 'LOT187294', '2028-06-18', 99, 27), -- Receiving 27
           (2210, 0.65, 1436.5, 'LOT216312', '2028-09-19', 102, 27), -- Receiving 27
           (17090, 0.32, 5468.8, 'LOT544979', '2024-08-12', 9, 27), -- Receiving 27
           (11950, 0.95, 11352.5, 'LOT303561', '2024-01-14', 131, 27), -- Receiving 27

           (2080, 0.36, 748.8, 'LOT107089', '2024-05-21', 87, 28), -- Receiving 28
           (15830, 0.88, 13930.4, 'LOT420715', '2027-12-20', 21, 28), -- Receiving 28
           (20010, 0.29, 5802.9, 'LOT397855', '2028-12-24', 88, 28), -- Receiving 28
           (2850, 2.02, 5757.0, 'LOT548968', '2027-05-16', 42, 28), -- Receiving 28
           (23700, 1.35, 31995.0, 'LOT609214', '2026-04-17', 120, 28), -- Receiving 28

           (22040, 0.06, 1322.4, 'LOT712530', '2027-05-11', 141, 29), -- Receiving 29
           (490, 3.66, 1793.4, 'LOT903901', '2026-04-02', 86, 29), -- Receiving 29
           (13030, 0.16, 2084.8, 'LOT754281', '2025-12-19', 91, 29), -- Receiving 29
           (2480, 0.62, 1537.6, 'LOT959436', '2027-07-09', 43, 29), -- Receiving 29
           (19180, 1.34, 25701.2, 'LOT693137', '2024-03-17', 129, 29), -- Receiving 29
           (27670, 0.44, 12174.8, 'LOT409616', '2028-07-23', 113, 29), -- Receiving 29
           (2270, 2.05, 4653.5, 'LOT558476', '2026-08-10', 89, 29), -- Receiving 29

           (290, 3.11, 901.9, 'LOT158134', '2026-06-01', 93, 30), -- Receiving 30
           (12580, 0.21, 2641.8, 'LOT939911', '2029-09-21', 67, 30), -- Receiving 30
           (12830, 0.23, 2950.9, 'LOT183220', '2027-07-17', 15, 30), -- Receiving 30
           (7280, 0.43, 3130.4, 'LOT373110', '2025-10-22', 27, 30), -- Receiving 30
           (27170, 0.27, 7335.9, 'LOT775438', '2026-01-12', 137, 30), -- Receiving 30

           (5150, 1.0, 5150.0, 'LOT126506', '2027-01-25', 95, 31), -- Receiving 31
           (17710, 0.75, 13282.5, 'LOT582193', '2027-01-20', 61, 31), -- Receiving 31
           (1460, 0.9, 1314.0, 'LOT269699', '2029-01-08', 22, 31), -- Receiving 31
           (1490, 0.39, 581.1, 'LOT113002', '2026-10-28', 33, 31), -- Receiving 31
           (17960, 0.59, 10696.4, 'LOT893632', '2028-10-15', 109, 31), -- Receiving 31
           (670, 1.12, 750.4, 'LOT328972', '2029-03-09', 117, 31), -- Receiving 31
           (690, 1.79, 1235.1, 'LOT741605', '2024-07-06', 141, 31), -- Receiving 31

           (1400, 2.97, 4158.0, 'LOT877084', '2025-12-06', 83, 32), -- Receiving 32
           (29540, 1.06, 3130.2, 'LOT309707', '2025-08-19', 125, 32), -- Receiving 32
           (2220, 1.61, 3574.2, 'LOT998814', '2029-01-23', 13, 32), -- Receiving 32
           (27700, 1.93, 5346.1, 'LOT528486', '2029-04-29', 35, 32), -- Receiving 32

           (21720, 0.57, 12380.4, 'LOT774644', '2029-03-17', 104, 33), -- Receiving 33
           (590, 1.96, 1156.4, 'LOT959496', '2026-10-22', 115, 33), -- Receiving 33
           (7180, 0.83, 5959.4, 'LOT230115', '2029-09-28', 105, 33), -- Receiving 33
           (1750, 1.24, 2170.0, 'LOT274586', '2026-12-30', 135, 33), -- Receiving 33
           (2360, 1.15, 2714.0, 'LOT226378', '2027-05-07', 2, 33), -- Receiving 33
           (19710, 1.51, 29762.1, 'LOT416872', '2029-02-03', 96, 33), -- Receiving 33

           (880, 1.6, 1408.0, 'LOT880100', '2029-07-29', 60, 34), -- Receiving 34
           (1400, 1.46, 2044.0, 'LOT161201', '2026-08-04', 85, 34), -- Receiving 34
           (21200, 0.11, 2332.0, 'LOT727636', '2026-07-16', 104, 34), -- Receiving 34
           (11230, 1.81, 20312.3, 'LOT402659', '2025-08-08', 66, 34), -- Receiving 34
           (945, 3.88, 3666.6, 'LOT783645', '2025-11-03', 94, 34), -- Receiving 34

           (2560, 0.79, 2022.4, 'LOT117159', '2029-08-01', 13, 35), -- Receiving 35
           (1735, 1.07, 1856.5, 'LOT545556', '2024-09-24', 52, 35), -- Receiving 35
           (1740, 0.39, 678.6, 'LOT493034', '2026-12-28', 76, 35), -- Receiving 35
           (1600, 0.12, 192.0, 'LOT797411', '2025-08-13', 78, 35), -- Receiving 35
           (7080, 0.27, 141.6, 'LOT376721', '2028-09-14', 114, 35), -- Receiving 35

           (1440, 2.5, 3600.0, 'LOT712731', '2024-01-07', 104, 36), -- Receiving 36
           (2800, 1.2, 3360.0, 'LOT230494', '2027-07-27', 46, 36), -- Receiving 36
           (28250, 0.89, 25142.5, 'LOT510000', '2026-03-30', 134, 36), -- Receiving 36
           (1990, 3.51, 6984.9, 'LOT655420', '2026-02-20', 43, 36), -- Receiving 36

           (11010, 0.53, 5835.3, 'LOT780764', '2026-06-23', 30, 37), -- Receiving 37
           (10200, 0.23, 2346.0, 'LOT555852', '2026-07-23', 7, 37), -- Receiving 37
           (1210, 1.3, 1573.0, 'LOT409736', '2024-09-12', 1, 37), -- Receiving 37
           (1460, 1.98, 2890.8, 'LOT364632', '2029-04-03', 67, 37), -- Receiving 37
           (2910, 1.26, 3666.6, 'LOT398452', '2027-07-23', 42, 37), -- Receiving 37

           (2370, 1.14, 2701.8, 'LOT530218', '2029-02-20', 122, 38), -- Receiving 38
           (26100, 0.12, 3132.0, 'LOT842719', '2024-09-21', 101, 38), -- Receiving 38
           (16000, 0.43, 6880.0, 'LOT514777', '2025-08-26', 82, 38), -- Receiving 38
           (550, 3.91, 2150.5, 'LOT286031', '2025-11-24', 144, 38), -- Receiving 38
           (2020, 3.58, 7221.6, 'LOT227239', '2026-11-21', 19, 38), -- Receiving 38

           (190, 5.42, 1029.8, 'LOT890142', '2029-07-19', 83, 39), -- Receiving 39
           (22690, 0.34, 7714.6, 'LOT193101', '2028-02-13', 90, 39), -- Receiving 39
           (7060, 2.17, 15320.2, 'LOT640164', '2026-09-15', 118, 39), -- Receiving 39
           (22420, 0.56, 12555.2, 'LOT375056', '2025-07-12', 13, 39), -- Receiving 39
           (571, 0.45, 256.95, 'LOT566568', '2028-03-06', 56, 39), -- Receiving 39

           (2675, 0.48, 1284.0, 'LOT136434', '2025-10-11', 122, 40), -- Receiving 40
           (3160, 3.15, 9954.0, 'LOT288282', '2025-04-18', 74, 40), -- Receiving 40
           (21890, 0.97, 21233.3, 'LOT767923', '2029-12-25', 131, 40), -- Receiving 40
           (530, 2.79, 1478.7, 'LOT930535', '2025-07-02', 86, 40), -- Receiving 40
           (20580, 0.97, 19962.6, 'LOT409692', '2029-04-14', 35, 40), -- Receiving 40
           (2220, 1.07, 2375.4, 'LOT379861', '2029-06-01', 123, 40), -- Receiving 40
           (8500, 0.75, 6375.0, 'LOT478174', '2029-08-24', 100, 40), -- Receiving 40
           (2820, 2.82, 7959.6, 'LOT989625', '2029-08-05', 18, 40), -- Receiving 40

           (26180, 0.42, 10995.6, 'LOT342286', '2028-07-19', 111, 41), -- Receiving 41
           (700, 1.78, 1246.0, 'LOT388268', '2028-10-08', 127, 41), -- Receiving 41
           (2560, 0.84, 2150.4, 'LOT211507', '2027-01-03', 101, 41), -- Receiving 41
           (29070, 0.46, 13372.2, 'LOT452376', '2027-04-16', 27, 41), -- Receiving 41
           (1870, 1.06, 1982.2, 'LOT626527', '2027-11-11', 47, 41), -- Receiving 41
           (2409, 1.58, 3806.22, 'LOT645472', '2025-06-05', 42, 41), -- Receiving 41

           (1350, 0.33, 445.5, 'LOT490531', '2025-04-14', 1, 42), -- Receiving 42
           (2720, 0.59, 1604.8, 'LOT155398', '2025-07-20', 28, 42), -- Receiving 42
           (3270, 0.43, 1406.1, 'LOT316237', '2028-04-02', 73, 42), -- Receiving 42
           (2510, 1.47, 3699.7, 'LOT794490', '2027-06-28', 122, 42), -- Receiving 42
           (1995, 1.0, 1995.0, 'LOT304082', '2026-03-14', 10, 42), -- Receiving 42
           (28400, 0.69, 19596.0, 'LOT122800', '2027-02-11', 4, 42), -- Receiving 42
           (2860, 2.85, 8151.0, 'LOT849936', '2026-03-18', 43, 42), -- Receiving 42

           (9710, 0.38, 3689.8, 'LOT919230', '2026-01-26', 11, 43), -- Receiving 43
           (2420, 0.22, 532.4, 'LOT245304', '2028-06-14', 18, 43), -- Receiving 43
           (740, 2.07, 1531.8, 'LOT578049', '2027-02-19', 79, 43), -- Receiving 43
           (2960, 0.67, 1983.2, 'LOT949714', '2027-03-18', 116, 43), -- Receiving 43
           (1790, 0.3, 537.0, 'LOT678348', '2026-08-14', 100, 43), -- Receiving 43
           (1760, 0.71, 1249.6, 'LOT458226', '2028-04-05', 111, 43), -- Receiving 43

           (840, 1.05, 882.0, 'LOT147386', '2026-06-23', 46, 44), -- Receiving 44
           (390, 1.52, 592.8, 'LOT398170', '2029-08-01', 18, 44), -- Receiving 44
           (1870, 0.25, 467.5, 'LOT236805', '2028-05-07', 28, 44), -- Receiving 44
           (18970, 0.19, 3604.3, 'LOT926933', '2027-06-29', 115, 44), -- Receiving 44
           (420, 2.51, 1054.2, 'LOT561055', '2029-02-10', 37, 44), -- Receiving 44
           (1570, 0.98, 1538.6, 'LOT732844', '2025-05-30', 64, 44), -- Receiving 44

           (1760, 0.33, 580.8, 'LOT195747', '2026-10-17', 22, 45), -- Receiving 45
           (2810, 1.26, 3540.6, 'LOT575078', '2026-06-05', 10, 45), -- Receiving 45
           (1960, 1.72, 3371.2, 'LOT839608', '2025-11-02', 56, 45), -- Receiving 45
           (2040, 0.28, 571.2, 'LOT153387', '2027-06-28', 133, 45), -- Receiving 45

           (1340, 0.39, 522.6, 'LOT532874', '2027-09-17', 22, 46), -- Receiving 46
           (7360, 0.83, 6108.8, 'LOT494093', '2029-12-25', 3, 46), -- Receiving 46
           (890, 1.89, 1682.1, 'LOT978373', '2027-04-10', 10, 46), -- Receiving 46
           (900, 3.77, 3393.0, 'LOT939659', '2029-08-13', 38, 46), -- Receiving 46
           (870, 0.36, 313.2, 'LOT282131', '2027-12-29', 76, 46), -- Receiving 46
           (1700, 0.88, 1496.0, 'LOT817061', '2025-05-15', 83, 46), -- Receiving 46

           (9400, 0.34, 3196.0, 'LOT382005', '2026-05-29', 106, 47), -- Receiving 47
           (2480, 0.34, 843.2, 'LOT657912', '2028-04-18', 131, 47), -- Receiving 47
           (2500, 0.42, 1050.0, 'LOT663432', '2025-01-25', 117, 47), -- Receiving 47
           (21820, 2.47, 53895.4, 'LOT640362', '2027-11-12', 27, 47), -- Receiving 47

           (800, 1.73, 1384.0, 'LOT357717', '2025-10-28', 36, 48), -- Receiving 48
           (2380, 0.72, 1713.6, 'LOT839580', '2029-06-20', 132, 48), -- Receiving 48
           (2410, 0.55, 1325.5, 'LOT459604', '2029-09-26', 126, 48), -- Receiving 48
           (1360, 1.08, 1468.8, 'LOT831988', '2026-10-30', 96, 48), -- Receiving 48
           (15910, 0.72, 11455.2, 'LOT763952', '2026-11-03', 69, 48), -- Receiving 48
           (2260, 1.1, 2486.0, 'LOT189832', '2025-07-27', 120, 48), -- Receiving 48
           (1140, 3.12, 3556.8, 'LOT479441', '2028-02-25', 68, 48), -- Receiving 48

           (720, 2.66, 1915.2, 'LOT497316', '2025-08-13', 73, 49), -- Receiving 49
           (1150, 0.68, 782.0, 'LOT684969', '2026-06-16', 141, 49), -- Receiving 49
           (2010, 0.26, 522.6, 'LOT241586', '2026-02-08', 71, 49), -- Receiving 49
           (880, 1.47, 1293.6, 'LOT754019', '2027-06-29', 148, 49), -- Receiving 49
           (1090, 1.83, 1994.7, 'LOT509248', '2025-09-11', 10, 49), -- Receiving 49
           (2700, 1.16, 3132.0, 'LOT274650', '2029-06-23', 79, 49), -- Receiving 49

           (24960, 0.64, 15974.4, 'LOT770963', '2026-01-20', 20, 50), -- Receiving 50
           (22480, 0.39, 8777.2, 'LOT405196', '2026-02-02', 106, 50), -- Receiving 50
           (562, 3.26, 1831.12, 'LOT894074', '2027-02-24', 148, 50), -- Receiving 50
           (28090, 3.16, 88708.4, 'LOT159097', '2026-07-04', 99, 50), -- Receiving 50

           (1830, 0.83, 1518.9, 'LOT790639', '2025-07-29', 46, 51), -- Receiving 51
           (2140, 1.68, 3595.2, 'LOT930500', '2026-02-25', 117, 51), -- Receiving 51
           (1200, 3.07, 3684.0, 'LOT313767', '2026-01-11', 10, 51), -- Receiving 51
           (1810, 0.23, 416.3, 'LOT280730', '2026-06-26', 92, 51), -- Receiving 51

           (1170, 3.17, 3708.9, 'LOT490852', '2027-06-03', 90, 52), -- Receiving 52
           (750, 2.51, 1882.5, 'LOT223023', '2027-03-25', 103, 52), -- Receiving 52
           (1950, 2.19, 4270.5, 'LOT401766', '2028-12-21', 88, 52), -- Receiving 52
           (850, 0.87, 739.5, 'LOT479566', '2028-02-08', 107, 52), -- Receiving 52
           (1810, 2.96, 5357.6, 'LOT248183', '2029-01-22', 63, 52), -- Receiving 52

           (1310, 1.57, 2056.7, 'LOT592033', '2025-01-30', 91, 53), -- Receiving 53
           (9240, 0.58, 5359.2, 'LOT726804', '2025-06-28', 93, 53), -- Receiving 53
           (2630, 0.49, 1288.7, 'LOT161075', '2027-05-12', 68, 53), -- Receiving 53
           (1490, 2.22, 3307.8, 'LOT962733', '2029-11-10', 36, 53), -- Receiving 53
           (2160, 0.43, 928.8, 'LOT764530', '2028-08-29', 141, 53), -- Receiving 53
           (1340, 3.59, 4810.6, 'LOT290922', '2027-09-07', 25, 53), -- Receiving 53

           (2650, 0.56, 1484.0, 'LOT571895', '2026-05-30', 109, 54), -- Receiving 54
           (2050, 1.2, 2460.0, 'LOT910024', '2026-02-15', 99, 54), -- Receiving 54
           (2080, 0.84, 1747.2, 'LOT529263', '2027-01-01', 61, 54), -- Receiving 54
           (24550, 0.23, 5646.5, 'LOT389904', '2026-12-10', 138, 54), -- Receiving 54
           (1460, 1.21, 1766.6, 'LOT134481', '2028-05-04', 68, 54), -- Receiving 54

           (2300, 0.61, 1403.0, 'LOT543097', '2025-01-29', 110, 55), -- Receiving 55
           (780, 1.97, 1536.6, 'LOT703198', '2027-12-28', 33, 55), -- Receiving 55
           (1080, 0.49, 529.2, 'LOT771883', '2029-05-21', 65, 55), -- Receiving 55
           (1180, 1.49, 1760.2, 'LOT370966', '2025-06-12', 44, 55), -- Receiving 55
           (1200, 1.66, 1992.0, 'LOT844247', '2027-03-28', 130, 55), -- Receiving 55
           (2690, 0.6, 1614.0, 'LOT728429', '2029-12-17', 50, 55), -- Receiving 55
           (1770, 1.26, 2230.2, 'LOT807498', '2025-09-30', 107, 55), -- Receiving 55
           (690, 2.49, 1718.1, 'LOT254625', '2028-10-16', 96, 55), -- Receiving 55

           (1050, 0.53, 556.5, 'LOT495935', '2028-03-03', 10, 56), -- Receiving 56
           (1630, 2.71, 4417.3, 'LOT621766', '2029-04-17', 12, 56), -- Receiving 56
           (1210, 3.54, 4283.4, 'LOT467798', '2025-03-12', 102, 56), -- Receiving 56
           (417, 4.28, 1785.96, 'LOT201994', '2027-01-03', 101, 56), -- Receiving 56
           (1180, 3.19, 3764.2, 'LOT937384', '2026-07-30', 64, 56), -- Receiving 56

           (22600, 0.6, 13560.0, 'LOT308619', '2028-07-17', 91, 57), -- Receiving 57
           (3410, 4.67, 15924.7, 'LOT887551', '2027-05-27', 62, 57), -- Receiving 57,
           (15670, 0.96, 15043.2, 'LOT212380', '2030-03-30', 20, 57), -- Receiving 57
           (20210, 0.5, 10105.0, 'LOT554106', '2030-09-26', 7, 57), -- Receiving 57
           (24710, 0.17, 4200.7, 'LOT685229', '2028-11-20', 12, 57), -- Receiving 57
           (24690, 0.07, 1728.3, 'LOT440163', '2028-12-28', 98, 57), -- Receiving 57
           (1850, 0.51, 943.5, 'LOT928068', '2026-10-22', 91, 57), -- Receiving 57
           (2520, 1.97, 4964.4, 'LOT789692', '2029-06-29', 90, 57), -- Receiving 57

           (3140, 1.91, 5997.4, 'LOT856701', '2029-10-18', 86, 58), -- Receiving 58
           (19510, 0.04, 780.4, 'LOT656697', '2026-05-02', 13, 58), -- Receiving 58
           (26920, 0.6, 16152.0, 'LOT536308', '2027-10-16', 80, 58), -- Receiving 58
           (1940, 0.55, 1067.0, 'LOT883314', '2027-11-10', 106, 58), -- Receiving 58

           (2880, 0.37, 1065.6, 'LOT550683', '2025-11-04', 54, 59), -- Receiving 59
           (29910, 0.18, 5383.8, 'LOT115893', '2025-12-10', 140, 59), -- Receiving 59
           (2750, 0.66, 1815.0, 'LOT420599', '2030-08-25', 64, 59), -- Receiving 59
           (910, 2.16, 1965.6, 'LOT561328', '2028-06-23', 128, 59), -- Receiving 59
           (1230, 1.68, 2066.4, 'LOT576430', '2026-01-19', 52, 59), -- Receiving 59
           (1040, 0.39, 405.6, 'LOT433648', '2029-01-23', 60, 59), -- Receiving 59
           (1330, 3.82, 5070.6, 'LOT992446', '2026-08-07', 28, 59), -- Receiving 59

           (3750, 0.27, 1012.5, 'LOT684352', '2028-09-26', 33, 60), -- Receiving 60
           (1280, 2.42, 3097.6, 'LOT690768', '2027-04-17', 146, 60), -- Receiving 60
           (1330, 0.48, 638.4, 'LOT221088', '2027-12-25', 106, 60), -- Receiving 60
           (2270, 2.41, 5470.7, 'LOT501934', '2026-10-27', 143, 60), -- Receiving 60

           (2740, 0.21, 575.4, 'LOT696327', '2029-06-08', 24, 61), -- Receiving 61
           (1930, 0.83, 1591.9, 'LOT174195', '2030-06-15', 90, 61), -- Receiving 61
           (1080, 2.35, 2538.0, 'LOT186712', '2029-02-03', 55, 61), -- Receiving 61
           (2100, 0.68, 1428.0, 'LOT158651', '2025-08-04', 5, 61), -- Receiving 61
           (920, 2.48, 2281.6, 'LOT180211', '2028-09-26', 90, 61), -- Receiving 61
           (22150, 0.15, 3322.5, 'LOT607815', '2026-07-04', 8, 61), -- Receiving 61
           (820, 1.35, 1107.0, 'LOT194248', '2025-07-02', 71, 61), -- Receiving 61
           (2420, 2.63, 6364.6, 'LOT375095', '2029-08-05', 4, 61), -- Receiving 61

           (2100, 0.29, 609.0, 'LOT201172', '2026-12-01', 70, 62), -- Receiving 62
           (2040, 1.15, 2346.0, 'LOT610713', '2029-11-10', 61, 62), -- Receiving 62
           (2100, 1.11, 2331.0, 'LOT534908', '2030-08-26', 95, 62), -- Receiving 62
           (1730, 1.05, 1816.5, 'LOT105285', '2026-03-05', 132, 62), -- Receiving 62
           (1250, 0.74, 925.0, 'LOT497068', '2030-09-26', 61, 62), -- Receiving 62
           (1960, 1.61, 3155.6, 'LOT483826', '2027-09-19', 139, 62), -- Receiving 62
           (2400, 0.10, 240.0, 'LOT488458', '2030-07-23', 136, 62), -- Receiving 62

           (2910, 1.09, 3171.9, 'LOT320513', '2028-09-17', 5, 63), -- Receiving 63
           (1720, 1.47, 2528.4, 'LOT766919', '2030-11-17', 70, 63), -- Receiving 63
           (2200, 0.38, 836.0, 'LOT885713', '2030-01-05', 45, 63), -- Receiving 63
           (480, 1.65, 792.0, 'LOT786869', '2030-03-11', 12, 63), -- Receiving 63
           (9870, 0.88, 8673.6, 'LOT827590', '2030-01-16', 109, 63), -- Receiving 63

           (4430, 2.16, 9568.8, 'LOT312286', '2029-06-22', 8, 64), -- Receiving 64
           (1900, 0.5, 950.0, 'LOT661521', '2030-03-04', 89, 64), -- Receiving 64
           (631, 1.63, 1027.53, 'LOT230190', '2026-10-14', 102, 64), -- Receiving 64
           (580, 1.78, 1032.4, 'LOT138030', '2029-07-26', 93, 64), -- Receiving 64
           (475, 2.67, 1268.25, 'LOT700727', '2028-07-11', 69, 64), -- Receiving 64

           (2260, 1.42, 3209.2, 'LOT710247', '2027-05-06', 17, 65), -- Receiving 65
           (2480, 1.54, 3819.2, 'LOT666220', '2026-02-26', 74, 65), -- Receiving 65
           (1420, 1.57, 2230.4, 'LOT486084', '2029-04-19', 90, 65), -- Receiving 65
           (1070, 2.67, 2856.9, 'LOT720706', '2027-03-12', 51, 65), -- Receiving 65
           (29140, 1.56, 4545.84, 'LOT920822', '2028-07-30', 117, 65), -- Receiving 65

           (2950, 1.02, 3009.0, 'LOT394066', '2029-08-06', 28, 66), -- Receiving 66
           (3640, 2.27, 8262.8, 'LOT496357', '2027-12-30', 2, 66), -- Receiving 66
           (2200, 1.1, 2420.0, 'LOT664026', '2029-06-22', 54, 66), -- Receiving 66
           (460, 3.8, 1748.0, 'LOT105570', '2029-05-30', 44, 66), -- Receiving 66
           (1760, 2.26, 3977.6, 'LOT659911', '2026-06-17', 52, 66), -- Receiving 66
           (2660, 2.2, 5852.0, 'LOT284867', '2030-10-06', 77, 66), -- Receiving 66

           (800, 1.26, 1008.0, 'LOT575048', '2027-11-27', 84, 67), -- Receiving 67
           (14060, 0.34, 4780.4, 'LOT129893', '2029-08-10', 30, 67), -- Receiving 67
           (8350, 0.34, 2839.0, 'LOT204395', '2029-04-21', 38, 67), -- Receiving 67
           (1090, 1.74, 1896.6, 'LOT814663', '2029-11-10', 121, 67), -- Receiving 67
           (1310, 1.43, 1873.3, 'LOT127005', '2028-03-12', 78, 67), -- Receiving 67
           (1220, 0.18, 219.6, 'LOT168451', '2027-09-25', 133, 67), -- Receiving 67
           (2710, 0.85, 2303.5, 'LOT821207', '2026-07-11', 27, 67), -- Receiving 67
           (2720, 2.37, 6446.4, 'LOT274490', '2027-04-15', 65, 67), -- Receiving 67

           (5250, 0.92, 4830.0, 'LOT877610', '2025-01-06', 9, 68), -- Receiving 68
           (950, 1.82, 1729.0, 'LOT327495', '2028-06-18', 2, 68), -- Receiving 68
           (2700, 1.64, 4428.0, 'LOT366020', '2026-04-14', 9, 68), -- Receiving 68
           (2160, 3.5, 7560.0, 'LOT799753', '2029-09-04', 49, 68), -- Receiving 68

           (2620, 0.27, 707.4, 'LOT533733', '2025-01-15', 127, 69), -- Receiving 69
           (1910, 0.15, 286.5, 'LOT191794', '2025-11-30', 46, 69), -- Receiving 69
           (1470, 0.39, 573.3, 'LOT705908', '2027-11-25', 103, 69), -- Receiving 69
           (870, 3.81, 3314.7, 'LOT703638', '2029-05-09', 133, 69), -- Receiving 69
           (8460, 1.5, 12690.0, 'LOT455228', '2025-11-19', 45, 69), -- Receiving 69

           (7660, 1.1, 8426.0, 'LOT281906', '2025-01-21', 135, 70), -- Receiving 70
           (2130, 1.77, 3760.1, 'LOT100554', '2027-05-10', 101, 70), -- Receiving 70
           (320, 1.39, 444.8, 'LOT899337', '2025-05-12', 86, 70), -- Receiving 70
           (1910, 2.13, 4068.3, 'LOT422641', '2028-01-11', 144, 70), -- Receiving 70
           (170, 2.6, 442.0, 'LOT491175', '2026-05-30', 94, 70), -- Receiving 70

           (22907, 0.48, 10995.36, 'LOT824326', '2026-10-09', 49, 71), -- Receiving 71
           (2030, 0.37, 751.1, 'LOT119485', '2025-04-07', 116, 71), -- Receiving 71
           (2990, 0.98, 2930.2, 'LOT729976', '2026-01-24', 112, 71), -- Receiving 71
           (2530, 0.54, 1366.2, 'LOT247435', '2027-12-05', 45, 71), -- Receiving 71
           (610, 1.57, 957.7, 'LOT306527', '2027-04-27', 143, 71), -- Receiving 71
           (14020, 2.23, 3126.46, 'LOT557987', '2026-07-21', 92, 71), -- Receiving 71
           (2010, 1.09, 2190.9, 'LOT235406', '2030-05-03', 95, 71), -- Receiving 71
           (28320, 2.03, 5749.0, 'LOT541938', '2027-01-23', 108, 71), -- Receiving 71

           (1980, 0.78, 1544.4, 'LOT363534', '2029-05-17', 38, 72), -- Receiving 72
           (280, 202, 56560.0, 'LOT814862', '2026-01-04', 22, 72), -- Receiving 72
           (1910, 1.3, 2483.0, 'LOT246498', '2030-04-14', 94, 72), -- Receiving 72
           (1880, 1.02, 1917.6, 'LOT664845', '2027-09-29', 57, 72), -- Receiving 72
           (1690, 1.09, 1842.1, 'LOT339296', '2028-07-15', 99, 72), -- Receiving 72
           (1060, 0.83, 879.8, 'LOT867727', '2026-11-17', 60, 72), -- Receiving 72
           (2950, 0.33, 973.5, 'LOT985262', '2025-01-14', 145, 72), -- Receiving 72
           (2380, 2.67, 6354.6, 'LOT745928', '2028-01-02', 132, 72); -- Receiving 72
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

INSERT INTO [dbo].[Stock]
           ([ProductId]
           ,[Quantity]
           ,[Batch])
     VALUES
           -- (<ProductId, int,>
           -- ,<Quantity, int,>
           -- ,<Batch, nvarchar(max),>),
           (5, 2500, 'LOT123456'), -- Receiving 1
           (8, 1800, 'LOT673456'), -- Receiving 1
           (25, 2450, 'LOT273456'), -- Receiving 1
           (10, 900, 'LOT283446'), -- Receiving 1

           (100, 12500, 'LOT563456'), -- Receiving 2
           (25, 10500, 'LOT374556'), -- Receiving 2
           (14, 4500, 'LOT343745'), -- Receiving 2
           (33, 8600, 'LOT756346'), -- Receiving 2
           (75, 7500, 'LOT975456'), -- Receiving 2
           (89, 10500, 'LOT124456'), -- Receiving 2

           (120, 2235, 'LOT737388'), -- Receiving 3
           (89, 1827, 'LOT605907'), -- Receiving 3
           (148, 864, 'LOT769390'), -- Receiving 3
           (63, 2082, 'LOT515983'), -- Receiving 3
           (103, 1976, 'LOT348892'), -- Receiving 3
           (143, 2020, 'LOT326038'), -- Receiving 3
           (13, 307, 'LOT726754'), -- Receiving 3
           (20, 1619, 'LOT148928'), -- Receiving 3
           (83, 2610, 'LOT519061'), -- Receiving 3

           (115, 1550, 'LOT778619'), -- Receiving 4
           (29, 610, 'LOT607306'), -- Receiving 4
           (106, 1060, 'LOT823972'), -- Receiving 4
           (12, 2150, 'LOT936252'), -- Receiving 4
           (136, 335, 'LOT356433'), -- Receiving 4
           (128, 920, 'LOT206384'), -- Receiving 4
           (148, 7360, 'LOT676476'), -- Receiving 4
           (59, 1160, 'LOT682569'), -- Receiving 4
           (36, 2660, 'LOT495476'), -- Receiving 4
           (95, 1300, 'LOT972084'), -- Receiving 4
           (31, 3460, 'LOT253695'), -- Receiving 4
           (54, 2565, 'LOT792708'), -- Receiving 4

           (19, 2450, 'LOT791078'), -- Receiving 5
           (5, 1960, 'LOT756513'), -- Receiving 5
           (8, 2120, 'LOT643581'), -- Receiving 5
           (133, 465, 'LOT625352'), -- Receiving 5
           (77, 2100, 'LOT147058'), -- Receiving 5
           (113, 1420, 'LOT325631'), -- Receiving 5
           (115, 750, 'LOT215995'), -- Receiving 5

           (87, 1840, 'LOT972114'), -- Receiving 6
           (13, 2280, 'LOT869678'), -- Receiving 6
           (27, 1240, 'LOT945176'), -- Receiving 6
           (96, 2560, 'LOT658108'), -- Receiving 6
           (104, 2750, 'LOT211628'), -- Receiving 6
           (3, 1910, 'LOT373648'), -- Receiving 6

           (101, 460, 'LOT120386'), -- Receiving 7
           (13, 1130, 'LOT282095'), -- Receiving 7
           (41, 1860, 'LOT823168'), -- Receiving 7
           (9, 820, 'LOT722766'), -- Receiving 7
           (43, 2960, 'LOT710284'), -- Receiving 7
           (70, 15860, 'LOT851021'), -- Receiving 7

           (34, 1220, 'LOT920885'), -- Receiving 8
           (9, 1775, 'LOT883557'), -- Receiving 8
           (121, 1060, 'LOT501451'), -- Receiving 8
           (127, 6130, 'LOT537656'), -- Receiving 8
           (140, 2740, 'LOT486995'), -- Receiving 8
           (141, 1110, 'LOT291341'), -- Receiving 8
           (136, 2435, 'LOT931488'), -- Receiving 8

           (101, 193, 'LOT782326'), -- Receiving 9
           (83, 1633, 'LOT326134'), -- Receiving 9
           (59, 1309, 'LOT428827'), -- Receiving 9
           (111, 2913, 'LOT329369'), -- Receiving 9
           (15, 2769, 'LOT753836'), -- Receiving 9
           (10, 2089, 'LOT171020'), -- Receiving 9
           (50, 2523, 'LOT747209'), -- Receiving 9
           (123, 1618, 'LOT600960'), -- Receiving 9

           (103, 460, 'LOT306132'), -- Receiving 10
           (140, 1430, 'LOT796781'), -- Receiving 10
           (62, 5300, 'LOT854546'), -- Receiving 10
           (8, 7180, 'LOT448469'), -- Receiving 10
           (25, 25970, 'LOT531305'), -- Receiving 10
           (99, 25580, 'LOT931040'), -- Receiving 10

           (109, 2530, 'LOT474021'), -- Receiving 11
           (99, 1850, 'LOT209581'), -- Receiving 11
           (65, 1540, 'LOT378474'), -- Receiving 11
           (109, 1770, 'LOT801189'), -- Receiving 11
           (100, 6140, 'LOT437595'), -- Receiving 11
           (97, 2850, 'LOT561048'), -- Receiving 11
           (67, 2050, 'LOT371565'), -- Receiving 11
           (27, 2480, 'LOT713090'), -- Receiving 11

           (130, 2440, 'LOT715292'), -- Receiving 12
           (18, 1960, 'LOT146413'), -- Receiving 12
           (66, 1115, 'LOT351641'), -- Receiving 12
           (77, 2360, 'LOT179462'), -- Receiving 12
           (34, 2860, 'LOT744401'), -- Receiving 12
           (122, 26200, 'LOT518301'), -- Receiving 12
           (135, 2640, 'LOT319324'), -- Receiving 12
           (142, 9390, 'LOT147365'), -- Receiving 12
           (29, 1410, 'LOT698022'), -- Receiving 12

           (43, 680, 'LOT873794'), -- Receiving 13
           (102, 2550, 'LOT333717'), -- Receiving 13
           (4, 1030, 'LOT284390'), -- Receiving 13
           (116, 2550, 'LOT225008'), -- Receiving 13
           (12, 1710, 'LOT314797'), -- Receiving 13
           (107, 1160, 'LOT232466'), -- Receiving 13
           (49, 2840, 'LOT546474'), -- Receiving 13
           (119, 390, 'LOT566229'), -- Receiving 13

           (144, 1210, 'LOT871458'), -- Receiving 14
           (28, 29530, 'LOT979870'), -- Receiving 14
           (74, 19040, 'LOT890973'), -- Receiving 14
           (118, 16690, 'LOT753211'), -- Receiving 14
           (74, 2850, 'LOT315505'), -- Receiving 14
           (138, 23100, 'LOT447009'), -- Receiving 14
           (34, 4550, 'LOT142287'), -- Receiving 14
           (94, 17640, 'LOT432488'), -- Receiving 14
           (116, 6420, 'LOT717190'), -- Receiving 14

           (117, 6440, 'LOT126700'), -- Receiving 15
           (127, 2440, 'LOT871059'), -- Receiving 15
           (148, 1000, 'LOT630080'), -- Receiving 15
           (37, 2280, 'LOT686541'), -- Receiving 15
           (97, 10300, 'LOT932736'), -- Receiving 15
           (96, 1290, 'LOT879891'), -- Receiving 15
           (9, 21600, 'LOT940595'), -- Receiving 15
           (10, 2870, 'LOT321311'), -- Receiving 15

           (114, 390, 'LOT626741'), -- Receiving 16
           (61, 6750, 'LOT295576'), -- Receiving 16
           (69, 2300, 'LOT875792'), -- Receiving 16
           (28, 2160, 'LOT198023'), -- Receiving 16
           (71, 2260, 'LOT340026'), -- Receiving 16

           (33, 2430, 'LOT382124'), -- Receiving 17
           (27, 10820, 'LOT758498'), -- Receiving 17
           (50, 470, 'LOT235603'), -- Receiving 17
           (96, 6120, 'LOT621693'), -- Receiving 17
           (11, 870, 'LOT270117'), -- Receiving 17
           (23, 990, 'LOT769680'), -- Receiving 17
           (121, 12600, 'LOT597956'), -- Receiving 17
           (129, 690, 'LOT445324'), -- Receiving 17
           (11, 29660, 'LOT254930'), -- Receiving 17

           (132, 570, 'LOT316157'), -- Receiving 18
           (131, 960, 'LOT388848'), -- Receiving 18
           (24, 2270, 'LOT909532'), -- Receiving 18
           (88, 19370, 'LOT929357'), -- Receiving 18
           (58, 1280, 'LOT457586'), -- Receiving 18

           (58, 1750, 'LOT619809'), -- Receiving 19
           (2, 2320, 'LOT541329'), -- Receiving 19
           (14, 2370, 'LOT809357'), -- Receiving 19
           (57, 2620, 'LOT874011'), -- Receiving 19
           (46, 28580, 'LOT873548'), -- Receiving 19
           (113, 20190, 'LOT361601'), -- Receiving 19
           (19, 1880, 'LOT144373'), -- Receiving 19

           (116, 530, 'LOT576585'), -- Receiving 20
           (75, 860, 'LOT866120'), -- Receiving 20
           (25, 1610, 'LOT777803'), -- Receiving 20
           (10, 1930, 'LOT689248'), -- Receiving 20
           (90, 1200, 'LOT885765'), -- Receiving 20
           (52, 20770, 'LOT114340'), -- Receiving 20
           (9, 2280, 'LOT607572'), -- Receiving 20

           (106, 445, 'LOT590435'), -- Receiving 21
           (41, 2650, 'LOT888734'), -- Receiving 21
           (117, 1050, 'LOT679635'), -- Receiving 21
           (128, 2340, 'LOT882633'), -- Receiving 21
           (86, 1840, 'LOT331676'), -- Receiving 21

           (120, 330, 'LOT460348'), -- Receiving 22
           (3, 880, 'LOT428539'), -- Receiving 22
           (46, 14300, 'LOT237227'), -- Receiving 22
           (82, 20980, 'LOT790864'), -- Receiving 22

           (22, 27400, 'LOT448410'), -- Receiving 23
           (49, 2390, 'LOT494713'), -- Receiving 23
           (143, 1630, 'LOT312634'), -- Receiving 23
           (141, 15730, 'LOT303800'), -- Receiving 23
           (37, 520, 'LOT139520'), -- Receiving 23

           (126, 1630, 'LOT556311'), -- Receiving 24
           (28, 2510, 'LOT378935'), -- Receiving 24
           (78, 15860, 'LOT984353'), -- Receiving 24
           (113, 21880, 'LOT596786'), -- Receiving 24
           (38, 2200, 'LOT943307'), -- Receiving 24
           (108, 21420, 'LOT225277'), -- Receiving 24
           (100, 10550, 'LOT128932'), -- Receiving 24
           (23, 2930, 'LOT926313'), -- Receiving 24

           (130, 2690, 'LOT537008'), -- Receiving 25
           (8, 6920, 'LOT263043'), -- Receiving 25
           (62, 16430, 'LOT921894'), -- Receiving 25
           (108, 20820, 'LOT831424'), -- Receiving 25
           (71, 2080, 'LOT571896'), -- Receiving 25
           (117, 27090, 'LOT220923'), -- Receiving 25

           (68, 2690, 'LOT648986'), -- Receiving 26
           (138, 9910, 'LOT345618'), -- Receiving 26
           (37, 19860, 'LOT778753'), -- Receiving 26
           (43, 2770, 'LOT292029'), -- Receiving 26
           (38, 23460, 'LOT951262'), -- Receiving 26
           (138, 19540, 'LOT779548'), -- Receiving 26
           (140, 2890, 'LOT238874'), -- Receiving 26
           (113, 1800, 'LOT534039'), -- Receiving 26

           (58, 28460, 'LOT801085'), -- Receiving 27
           (93, 2460, 'LOT904335'), -- Receiving 27
           (120, 430, 'LOT507764'), -- Receiving 27
           (36, 18310, 'LOT991266'), -- Receiving 27
           (81, 2180, 'LOT650005'), -- Receiving 27
           (99, 1290, 'LOT187294'), -- Receiving 27
           (102, 2210, 'LOT216312'), -- Receiving 27
           (9, 17090, 'LOT544979'), -- Receiving 27
           (131, 11950, 'LOT303561'), -- Receiving 27

           (87, 2080, 'LOT107089'), -- Receiving 28
           (21, 15830, 'LOT420715'), -- Receiving 28
           (88, 20010, 'LOT397855'), -- Receiving 28
           (42, 2850, 'LOT548968'), -- Receiving 28
           (120, 23700, 'LOT609214'), -- Receiving 28

           (141, 22040, 'LOT712530'), -- Receiving 29
           (86, 490, 'LOT903901'), -- Receiving 29
           (91, 13030, 'LOT754281'), -- Receiving 29
           (43, 2480, 'LOT959436'), -- Receiving 29
           (129, 19180, 'LOT693137'), -- Receiving 29
           (113, 27670, 'LOT409616'), -- Receiving 29
           (89, 2270, 'LOT558476'), -- Receiving 29

           (93, 290, 'LOT158134'), -- Receiving 30
           (67, 12580, 'LOT939911'), -- Receiving 30
           (15, 12830, 'LOT183220'), -- Receiving 30
           (27, 7280, 'LOT373110'), -- Receiving 30
           (137, 27170, 'LOT775438'), -- Receiving 30

           (95, 5150, 'LOT126506'), -- Receiving 31
           (61, 17710, 'LOT582193'), -- Receiving 31
           (22, 1460, 'LOT269699'), -- Receiving 31
           (33, 1490, 'LOT113002'), -- Receiving 31
           (109, 17960, 'LOT893632'), -- Receiving 31
           (117, 670, 'LOT328972'), -- Receiving 31
           (141, 690, 'LOT741605'), -- Receiving 31

           (83, 1400, 'LOT877084'), -- Receiving 32
           (125, 29540, 'LOT309707'), -- Receiving 32
           (13, 2220, 'LOT998814'), -- Receiving 32
           (35, 27700, 'LOT528486'), -- Receiving 32

           (104, 21720, 'LOT774644'), -- Receiving 33
           (115, 590, 'LOT959496'), -- Receiving 33
           (105, 7180, 'LOT230115'), -- Receiving 33
           (135, 1750, 'LOT274586'), -- Receiving 33
           (2, 2360, 'LOT226378'), -- Receiving 33
           (96, 19710, 'LOT416872'), -- Receiving 33

           (60, 880, 'LOT880100'), -- Receiving 34
           (85, 1400, 'LOT161201'), -- Receiving 34
           (104, 21200, 'LOT727636'), -- Receiving 34
           (66, 11230, 'LOT402659'), -- Receiving 34
           (94, 945, 'LOT783645'), -- Receiving 34

           (13, 2560, 'LOT117159'), -- Receiving 35
           (52, 1735, 'LOT545556'), -- Receiving 35
           (76, 1740, 'LOT493034'), -- Receiving 35
           (78, 1600, 'LOT797411'), -- Receiving 35
           (114, 7080, 'LOT376721'), -- Receiving 35

           (104, 1440, 'LOT712731'), -- Receiving 36
           (46, 2800, 'LOT230494'), -- Receiving 36
           (134, 28250, 'LOT510000'), -- Receiving 36
           (43, 1990, 'LOT655420'), -- Receiving 36

           (30, 11010, 'LOT780764'), -- Receiving 37
           (7, 10200, 'LOT555852'), -- Receiving 37
           (1, 1210, 'LOT409736'), -- Receiving 37
           (67, 1460, 'LOT364632'), -- Receiving 37
           (42, 2910, 'LOT398452'), -- Receiving 37

           (122, 2370, 'LOT530218'), -- Receiving 38
           (101, 26100, 'LOT842719'), -- Receiving 38
           (82, 16000, 'LOT514777'), -- Receiving 38
           (144, 550, 'LOT286031'), -- Receiving 38
           (19, 2020, 'LOT227239'), -- Receiving 38

           (83, 190, 'LOT890142'), -- Receiving 39
           (90, 22690, 'LOT193101'), -- Receiving 39
           (118, 7060, 'LOT640164'), -- Receiving 39
           (13, 22420, 'LOT375056'), -- Receiving 39
           (56, 571, 'LOT566568'), -- Receiving 39

           (122, 2675, 'LOT136434'), -- Receiving 40
           (74, 3160, 'LOT288282'), -- Receiving 40
           (131, 21890, 'LOT767923'), -- Receiving 40
           (86, 530, 'LOT930535'), -- Receiving 40
           (35, 20580, 'LOT409692'), -- Receiving 40
           (123, 2220, 'LOT379861'), -- Receiving 40
           (100, 8500, 'LOT478174'), -- Receiving 40
           (18, 2820, 'LOT989625'), -- Receiving 40

           (111, 26180, 'LOT342286'), -- Receiving 41
           (127, 700, 'LOT388268'), -- Receiving 41
           (101, 2560, 'LOT211507'), -- Receiving 41
           (27, 29070, 'LOT452376'), -- Receiving 41
           (47, 1870, 'LOT626527'), -- Receiving 41
           (42, 2409, 'LOT645472'), -- Receiving 41

           (1, 1350, 'LOT490531'), -- Receiving 42
           (28, 2720, 'LOT155398'), -- Receiving 42
           (73, 3270, 'LOT316237'), -- Receiving 42
           (122, 2510, 'LOT794490'), -- Receiving 42
           (10, 1995, 'LOT304082'), -- Receiving 42
           (4, 28400, 'LOT122800'), -- Receiving 42
           (43, 2860, 'LOT849936'), -- Receiving 42

           (11, 9710, 'LOT919230'), -- Receiving 43
           (18, 2420, 'LOT245304'), -- Receiving 43
           (79, 740, 'LOT578049'), -- Receiving 43
           (116, 2960, 'LOT949714'), -- Receiving 43
           (100, 1790, 'LOT678348'), -- Receiving 43
           (111, 1760, 'LOT458226'), -- Receiving 43

           (46, 840, 'LOT147386'), -- Receiving 44
           (18, 390, 'LOT398170'), -- Receiving 44
           (28, 1870, 'LOT236805'), -- Receiving 44
           (115, 18970, 'LOT926933'), -- Receiving 44
           (37, 420, 'LOT561055'), -- Receiving 44
           (64, 1570, 'LOT732844'), -- Receiving 44

           (22, 1760, 'LOT195747'), -- Receiving 45
           (10, 2810, 'LOT575078'), -- Receiving 45
           (56, 1960, 'LOT839608'), -- Receiving 45
           (133, 2040, 'LOT153387'), -- Receiving 45

           (22, 1340, 'LOT532874'), -- Receiving 46
           (3, 7360, 'LOT494093'), -- Receiving 46
           (10, 890, 'LOT978373'), -- Receiving 46
           (38, 900, 'LOT939659'), -- Receiving 46
           (76, 870, 'LOT282131'), -- Receiving 46
           (83, 1700, 'LOT817061'), -- Receiving 46

           (106, 9400, 'LOT382005'), -- Receiving 47
           (131, 2480, 'LOT657912'), -- Receiving 47
           (117, 2500, 'LOT663432'), -- Receiving 47
           (27, 21820, 'LOT640362'), -- Receiving 47

           (36, 800, 'LOT357717'), -- Receiving 48
           (132, 2380, 'LOT839580'), -- Receiving 48
           (126, 2410, 'LOT459604'), -- Receiving 48
           (96, 1360, 'LOT831988'), -- Receiving 48
           (69, 15910, 'LOT763952'), -- Receiving 48
           (120, 2260, 'LOT189832'), -- Receiving 48
           (68, 1140, 'LOT479441'), -- Receiving 48

           (73, 720, 'LOT497316'), -- Receiving 49
           (141, 1150, 'LOT684969'), -- Receiving 49
           (71, 2010, 'LOT241586'), -- Receiving 49
           (148, 880, 'LOT754019'), -- Receiving 49
           (10, 1090, 'LOT509248'), -- Receiving 49
           (79, 2700, 'LOT274650'), -- Receiving 49

           (20, 24960, 'LOT770963'), -- Receiving 50
           (106, 22480, 'LOT405196'), -- Receiving 50
           (148, 562, 'LOT894074'), -- Receiving 50
           (99, 28090, 'LOT159097'), -- Receiving 50

           (46, 1830, 'LOT790639'), -- Receiving 51
           (117, 2140, 'LOT930500'), -- Receiving 51
           (10, 1200, 'LOT313767'), -- Receiving 51
           (92, 1810, 'LOT280730'), -- Receiving 51

           (90, 1170, 'LOT490852'), -- Receiving 52
           (103, 750, 'LOT223023'), -- Receiving 52
           (88, 1950, 'LOT401766'), -- Receiving 52
           (107, 850, 'LOT479566'), -- Receiving 52
           (63, 1810, 'LOT248183'), -- Receiving 52

           (91, 1310, 'LOT592033'),  -- Receiving 53
           (93, 9240, 'LOT726804'),  -- Receiving 53
           (68, 2630, 'LOT161075'),  -- Receiving 53
           (36, 1490, 'LOT962733'),  -- Receiving 53
           (141, 2160, 'LOT764530'), -- Receiving 53
           (25, 1340, 'LOT290922'),  -- Receiving 53

           (109, 2650, 'LOT571895'), -- Receiving 54
           (99, 2050, 'LOT910024'), -- Receiving 54
           (61, 2080, 'LOT529263'), -- Receiving 54
           (138, 24550, 'LOT389904'), -- Receiving 54
           (68, 1460, 'LOT134481'), -- Receiving 54

           (110, 2300, 'LOT543097'), -- Receiving 55
           (33, 780, 'LOT703198'), -- Receiving 55
           (65, 1080, 'LOT771883'), -- Receiving 55
           (44, 1180, 'LOT370966'), -- Receiving 55
           (130, 1200, 'LOT844247'), -- Receiving 55
           (50, 2690, 'LOT728429'), -- Receiving 55
           (107, 1770, 'LOT807498'), -- Receiving 55
           (96, 690, 'LOT254625'), -- Receiving 55

           (10, 1050, 'LOT495935'), -- Receiving 56
           (12, 1630, 'LOT621766'), -- Receiving 56
           (102, 1210, 'LOT467798'), -- Receiving 56
           (101, 417, 'LOT201994'), -- Receiving 56
           (64, 1180, 'LOT937384'), -- Receiving 56

           (91, 22600, 'LOT308619'), -- Receiving 57
           (62, 3410, 'LOT887551'), -- Receiving 57
           (20, 15670, 'LOT212380'), -- Receiving 57
           (7, 20210, 'LOT554106'), -- Receiving 57
           (12, 24710, 'LOT685229'), -- Receiving 57
           (98, 24690, 'LOT440163'), -- Receiving 57
           (91, 1850, 'LOT928068'), -- Receiving 57
           (90, 2520, 'LOT789692'), -- Receiving 57

           (86, 3140, 'LOT856701'), -- Receiving 58
           (13, 19510, 'LOT656697'), -- Receiving 58
           (80, 26920, 'LOT536308'), -- Receiving 58
           (106, 1940, 'LOT883314'), -- Receiving 58

           (54, 2880, 'LOT550683'), -- Receiving 59
           (140, 29910, 'LOT115893'), -- Receiving 59
           (64, 2750, 'LOT420599'), -- Receiving 59
           (128, 910, 'LOT561328'), -- Receiving 59
           (52, 1230, 'LOT576430'), -- Receiving 59
           (60, 1040, 'LOT433648'), -- Receiving 59
           (28, 1330, 'LOT992446'), -- Receiving 59

           (33, 3750, 'LOT684352'), -- Receiving 60
           (146, 1280, 'LOT690768'), -- Receiving 60
           (106, 1330, 'LOT221088'), -- Receiving 60
           (143, 2270, 'LOT501934'), -- Receiving 60

           (24, 2740, 'LOT696327'), -- Receiving 61
           (90, 1930, 'LOT174195'), -- Receiving 61
           (55, 1080, 'LOT186712'), -- Receiving 61
           (5, 2100, 'LOT158651'), -- Receiving 61
           (90, 920, 'LOT180211'), -- Receiving 61
           (8, 22150, 'LOT607815'), -- Receiving 61
           (71, 820, 'LOT194248'), -- Receiving 61
           (4, 2420, 'LOT375095'), -- Receiving 61

           (70, 2100, 'LOT201172'), -- Receiving 62
           (61, 2040, 'LOT610713'), -- Receiving 62
           (95, 2100, 'LOT534908'), -- Receiving 62
           (132, 1730, 'LOT105285'), -- Receiving 62
           (61, 1250, 'LOT497068'), -- Receiving 62
           (139, 1960, 'LOT483826'), -- Receiving 62
           (136, 2400, 'LOT488458'), -- Receiving 62

           (5, 2910, 'LOT320513'), -- Receiving 63
           (70, 1720, 'LOT766919'), -- Receiving 63
           (45, 2200, 'LOT885713'), -- Receiving 63
           (12, 480, 'LOT786869'), -- Receiving 63
           (109, 9870, 'LOT827590'), -- Receiving 63

           (8, 4430, 'LOT312286'), -- Receiving 64
           (89, 1900, 'LOT661521'), -- Receiving 64
           (102, 631, 'LOT230190'), -- Receiving 64
           (93, 580, 'LOT138030'), -- Receiving 64
           (69, 475, 'LOT700727'), -- Receiving 64

           (17, 2260, 'LOT710247'), -- Receiving 65
           (74, 2480, 'LOT666220'), -- Receiving 65
           (90, 1420, 'LOT486084'), -- Receiving 65
           (51, 1070, 'LOT720706'), -- Receiving 65
           (117, 29140, 'LOT920822'), -- Receiving 65

           (28, 2950, 'LOT394066'), -- Receiving 66
           (2, 3640, 'LOT496357'), -- Receiving 66
           (54, 2200, 'LOT664026'), -- Receiving 66
           (44, 460, 'LOT105570'), -- Receiving 66
           (52, 1760, 'LOT659911'), -- Receiving 66
           (77, 2660, 'LOT284867'), -- Receiving 66

           (84, 800, 'LOT575048'), -- Receiving 67
           (30, 14060, 'LOT129893'), -- Receiving 67
           (38, 8350, 'LOT204395'), -- Receiving 67
           (121, 1090, 'LOT814663'), -- Receiving 67
           (78, 1310, 'LOT127005'), -- Receiving 67
           (133, 1220, 'LOT168451'), -- Receiving 67
           (27, 2710, 'LOT821207'), -- Receiving 67
           (65, 2720, 'LOT274490'), -- Receiving 67

           (9, 5250, 'LOT877610'), -- Receiving 68
           (2, 950, 'LOT327495'), -- Receiving 68
           (9, 2700, 'LOT366020'), -- Receiving 68
           (49, 2160, 'LOT799753'), -- Receiving 68

           (127, 2620, 'LOT533733'), -- Receiving 69
           (46, 1910, 'LOT191794'), -- Receiving 69
           (103, 1470, 'LOT705908'), -- Receiving 69
           (133, 870, 'LOT703638'), -- Receiving 69
           (45, 8460, 'LOT455228'), -- Receiving 69

           (135, 7660, 'LOT281906'), -- Receiving 70
           (101, 2130, 'LOT100554'), -- Receiving 70
           (86, 320, 'LOT899337'), -- Receiving 70
           (144, 1910, 'LOT422641'), -- Receiving 70
           (94, 170, 'LOT491175'), -- Receiving 70

           (49, 22907, 'LOT824326'), -- Receiving 71
           (116, 2030, 'LOT119485'), -- Receiving 71
           (112, 2990, 'LOT729976'), -- Receiving 71
           (45, 2530, 'LOT247435'), -- Receiving 71
           (143, 610, 'LOT306527'), -- Receiving 71
           (92, 14020, 'LOT557987'), -- Receiving 71
           (95, 2010, 'LOT235406'), -- Receiving 71
           (108, 28320, 'LOT541938'), -- Receiving 71

           (38, 1980, 'LOT363534'), -- Receiving 72
           (22, 280, 'LOT814862'), -- Receiving 72
           (94, 1910, 'LOT246498'), -- Receiving 72
           (57, 1880, 'LOT664845'), -- Receiving 72
           (99, 1690, 'LOT339296'), -- Receiving 72
           (60, 1060, 'LOT867727'), -- Receiving 72
           (145, 2950, 'LOT985262'), -- Receiving 72
           (132, 2380, 'LOT745928'); -- Receiving 72

GO

-- ==================================================================================================================================
