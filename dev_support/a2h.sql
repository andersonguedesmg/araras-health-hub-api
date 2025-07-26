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
            ('Leo McGarry', '216.440.478-53', 'Auxiliar Administrativo', '(19) 97345-6402', @NOW, NULL, 0),
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
            ('Chandler Bing', '753.951.258-96', 'Coordenador', '(19) 99564-7832', @NOW, NULL, 0),
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
            ('Matt Albie', '951.159.357-00', 'Agente de Endemias', '(19) 98333-3030', @NOW, NULL, 0),
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
            ('Tony Soprano', '103.640.250-60', 'Farmacêutico', '(19) 97987-1204', @NOW, NULL, 0),
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
            ('Raymond Holt', '096.470.580-29', 'Coordenador', '(19) 99915-8720', @NOW, NULL, 0),
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
            ('Lennie Briscoe', '607.219.860-49', 'Agente de Endemias', '(19) 99233-0090', @NOW, NULL, 0),
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
            ('Ambulatório de Pronto Atendimento Dr. Solon F. de Oliveira', 'Rua Dos Girassois', 's/nº', 'Jd Sobradinho', 'Araras', 'SP', '13602-006', 'sms@araras.sp.gov.br', '(19) 3544-5630', @NOW, NULL, 0),
            ('Vigilância Sanitária de Araras', 'Rua Campos Sales', '33', 'Jardim Belvedere', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3543-1522', @NOW, NULL, 1),
            ('Unidade Movel Odontológica', 'Rua Campos Sales', '33', 'Jardim Belvedere', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3543-1522', @NOW, NULL, 1),
            ('Unidade de Vigilância Epidemiológica', 'Rua Campos Sales', '33', 'Jardim Belvedere', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3541-7037', @NOW, NULL, 1),
            ('UBS Osvaldo Salvador Devitte', 'Avenida Presidente Castelo Branco', '27', 'Conjunto Habitacional Narciso Gomes', 'Araras', 'SP', '13601-440', 'sms@araras.sp.gov.br', '(19) 3544-4974', @NOW, NULL, 1),
            ('UBS Dr. Humberto Rodrigues Junior', 'Avenida Melvin Jones', 's/nº', 'Jd Tangara', 'Araras', 'SP', '13607-005', 'sms@araras.sp.gov.br', '(19) 3544-6939', @NOW, NULL, 1),
            ('UBS Dr. Emerson Mercatelli', 'Rua Anibal Lopes Da Silva', '190', 'Residencial Bosque de Versalles', 'Araras', 'SP', '13609-384', 'sms@araras.sp.gov.br', '(19) 3547-9609', @NOW, NULL, 1),
            ('UBS Dr. Antônio Simoes Pontes', 'Avenida João Rossi', 's/nº', 'Jardim Aeroporto', 'Araras', 'SP', '13605-300', 'sms@araras.sp.gov.br', '(19) 3547-3195', @NOW, NULL, 0),
            ('UBS Antônio Carlos Fabricio', 'Rua Do Carpinteiro', 's/nº', 'Jardim José Ometto I', 'Araras', 'SP', '13606-320', 'sms@araras.sp.gov.br', '(19) 3544-3569', @NOW, NULL, 1),
            ('UBS Alberto Franzini', 'Rua Cassio Gonzaga', 's/nº', 'Jd Morumbi', 'Araras', 'SP', '13606-508', 'sms@araras.sp.gov.br', '(19) 3541-8016', @NOW, NULL, 1),
            ('Pró Saúde Hospital Geral', 'Avenida Augusta Viola Da Costa', '805', 'Loreto', 'Araras', 'SP', '13606-020', 'sms@araras.sp.gov.br', '(19) 3321-1260', @NOW, NULL, 1),
            ('PS Dr. Alcides Franco de Oliveira', 'Rua Lourenco Batistela', '514', 'Jardim José Ometto I', 'Araras', 'SP', '13606-326', 'sms@araras.sp.gov.br', '(19) 3541-7211', @NOW, NULL, 0),
            ('SAE/CTA Enfermeira Adalgisa dos Santos Gonçalves', 'Rua Francisco Paulo Russo', '119', 'Centro', 'Araras', 'SP', '13600-559', 'sms@araras.sp.gov.br', '(19) 3544-2064', @NOW, NULL, 1),
            ('Posto de Atendimento Médico Eva Almeida Costa Cruz', 'Avenida Presidente Cafe Filho', '209', 'Narciso Gomes', 'Araras', 'SP', '13601-430', 'sms@araras.sp.gov.br', '(19) 3541-7898', @NOW, NULL, 0),
            ('Medicina Diagnóstica Castro Soares', 'Rua Brasilia', '123', 'Centro', 'Araras', 'SP', '13600-710', 'sms@araras.sp.gov.br', '(19) 3541-4211', @NOW, NULL, 1),
            ('LabVitta Laboratório de Análises Clínicas', 'Rua Coronel Andre Ulson Junior', '244', 'Centro', 'Araras', 'SP', '13600-690', 'sms@araras.sp.gov.br', '(19) 3543-5400', @NOW, NULL, 1),
            ('ESF Vital Pacífico Homem', 'Rua Irineu Carroci', '1469', 'Jardim José Ometto IV', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3544-5411', @NOW, NULL, 1),
            ('ESF Zona Rural', 'Sitio Morro Grande', 's/nº', 'Zona Rural', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3543-1522', @NOW, NULL, 1),
            ('Hospital de Campanha Covid 19', 'Rua Nelson Ferreira', 's/nº', 'Jardim José Ometto II', 'Araras', 'SP', '13606-414', 'sms@araras.sp.gov.br', '(19) 3543-1522', @NOW, NULL, 0),
            ('Hospital São Leopoldo Mandic', 'Av Padre Alarico Zacharias', '1253', 'Belvedere', 'Araras', 'SP', '13601-200', 'sms@araras.sp.gov.br', '(19) 3543-3211', @NOW, NULL, 1),
            ('Hospital Irmandade da Santa Casa de Misericórdia de Araras', 'Praca Dr. Narcizo Gomes', '49', 'Centro', 'Araras', 'SP', '13600-695', 'sms@araras.sp.gov.br', '(19) 3543-5400', @NOW, NULL, 1),
            ('ESF Dr. Orlando Zaniboni', 'Rua Francisco Cressoni', '158', 'Parque Tiradentes', 'Araras', 'SP', '13606-643', 'sms@araras.sp.gov.br', '(19) 3541-7791', @NOW, NULL, 1),
            ('ESF Dr. Sebastião Jair Mourão', 'Rua Do Estudante', '110', 'Jardim José Ometto I', 'Araras', 'SP', '13606-314', 'sms@araras.sp.gov.br', '(19) 3544-7754', @NOW, NULL, 0),
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
            ('Centro Odontologico Dr. Solon de Oliveira Fernandes', 'Avenida Lourenco Batistella', '514', 'Jardim José Ometto I', 'Araras', 'SP', '13606-326', 'sms@araras.sp.gov.br', '(19) 3541-7211', @NOW, NULL, 0),
            ('Centro Médico Social Comunitário Irma Maria Diva Patarra', 'Avenida Padre Alarico Zacharias', '300', 'Jardim Belvedere', 'Araras', 'SP', '13601-111', 'sms@araras.sp.gov.br', '(19) 3543-3088', @NOW, NULL, 0),
            ('Centro Infantil Dr. Hercio Marcos Cintra Arantes', 'Avenida Washington Luiz', '545', 'Vila Michelin', 'Araras', 'SP', '13601-001', 'sms@araras.sp.gov.br', '(19) 3542-9909', @NOW, NULL, 1),
            ('Centro de Saúde Dra Rosa Chelminsk Teixeira', 'Avenida Governador Garcez', '137', 'Jardim Belvedere', 'Araras', 'SP', '13601-140', 'sms@araras.sp.gov.br', '(19) 3542-6164', @NOW, NULL, 1),
            ('Centro de Saúde Da Mulher Jandira A Leite Duarte', 'Rua Dos Anturios', '30', 'Jardim Sobradinho', 'Araras', 'SP', '13602-005', 'sms@araras.sp.gov.br', '(19) 3551-5440', @NOW, NULL, 1),
            ('Centro de Imagem Radiológica', 'Av Governador Garcez', 's/nº', 'Jardim Belvedere', 'Araras', 'SP', '13601-140', 'sms@araras.sp.gov.br', '(19) 3543-3055', @NOW, NULL, 0),
            ('CDI Syrius', 'Praca Doutor Narciso Gomes', '49', 'Centro', 'Araras', 'SP', '13600-695', 'sms@araras.sp.gov.br', '(19) 3805-3737', @NOW, NULL, 0),
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
          ('Grupo Martins', '01.407.377/0001-62', 'Avenida Pedro Álvarez Cabral', '3000', 'Vila Maria', 'São Paulo', 'SP', '02048-000', 'contato@martins.com.br', '(11) 2221-2222', @NOW, '', 1),
          ('Drogarias Pacheco', '30.246.478/0001-35', 'Rua do Ouvidor', '98', 'Centro', 'Rio de Janeiro', 'RJ', '20010-000', 'sac@drogariaspacheco.com.br', '(21) 4004-1234', @NOW, '', 1),
          ('Raia Drogasil', '44.454.240/0001-11', 'Rua dos Três Irmãos', '25', 'Vila Progredior', 'São Paulo', 'SP', '02751-000', 'atendimento@raiadrogasil.com.br', '(11) 4003-4116', @NOW, '', 1),
          ('Droga Raia', '44.177.977/0001-83', 'Avenida São João', '1500', 'Centro', 'São Paulo', 'SP', '01030-001', 'sac@droga-raia.com.br', '(11) 3333-7777', @NOW, '', 1),
          ('Farmais Distribuidora', '11.582.072/0001-12', 'Avenida Maria Conceição', '1050', 'Jardim da Saúde', 'São Paulo', 'SP', '04152-040', 'comercial@farmais.com.br', '(11) 5075-9911', @NOW, '', 1),
          ('Ultrafarma', '06.862.412/0001-23', 'Rua dos Três Irmãos', '122', 'Vila Progredior', 'São Paulo', 'SP', '02751-000', 'atendimento@ultrafarma.com.br', '(11) 4003-4116', @NOW, '', 1),
          ('AstraZeneca Brasil', '60.582.059/0001-70', 'Avenida Pasteur', '500', 'Jardim Botânico', 'São Paulo', 'SP', '01000-000', 'contato@astrazeneca.com', '(11) 3463-5000', @NOW, '', 1),
          ('EMS Sigma Pharma', '60.084.242/0001-91', 'Rua David de Oliveira', '800', 'Centro', 'Cotia', 'SP', '06711-000', 'contato@ems.com.br', '(11) 4183-9050', @NOW, '', 1),
          ('Hypermarcas', '33.376.213/0001-70', 'Avenida Engenheiro Luís Carlos Berrini', '1380', 'Vila Progredior', 'São Paulo', 'SP', '04571-000', 'sac@hypermarcas.com.br', '(11) 3146-1700', @NOW, '', 1),
          ('Biolab Sanus', '59.471.376/0001-39', 'Avenida Francisco Matarazzo', '1510', 'Lapa', 'São Paulo', 'SP', '05001-200', 'atendimento@biolab.com.br', '(11) 3616-0800', @NOW, '', 1),
          ('Eurofarma', '60.797.518/0001-64', 'Rua Américo Brasiliense', '280', 'Vila Progredior', 'São Paulo', 'SP', '04104-000', 'sac@eurofarma.com.br', '(11) 2121-2121', @NOW, '', 1),
          ('Laboratório Aché', '60.115.279/0001-18', 'Avenida do Estado', '500', 'Belenzinho', 'São Paulo', 'SP', '03082-000', 'atendimento@ache.com.br', '(11) 3278-1000', @NOW, '', 1),
          ('Marjan Farma', '59.514.229/0001-50', 'Rua Morato Coelho', '1215', 'Vila Progredior', 'São Paulo', 'SP', '05422-100', 'marjan@marjan.com.br', '(11) 3078-3122', @NOW, '', 1),
          ('Medley', '60.616.978/0001-14', 'Avenida Engenheiro Luís Carlos Berrini', '1070', 'Vila Progredior', 'São Paulo', 'SP', '04571-001', 'atendimento@medley.com.br', '(11) 5090-1000', @NOW, '', 1),
          ('Laboratório São Paulo', '60.159.618/0001-90', 'Avenida Celso Garcia', '2289', 'Belenzinho', 'São Paulo', 'SP', '03071-000', 'atendimento@labsp.com.br', '(11) 2295-7000', @NOW, '', 1),
          ('Medquímica', '60.259.512/0001-99', 'Rua Barão de Itapetininga', '102', 'Centro', 'São Paulo', 'SP', '01042-000', 'atendimento@medquimica.com.br', '(11) 3241-1234', @NOW, '', 1),
          ('Laboratório Cristália', '60.508.343/0001-92', 'Avenida João Batista Ribeiro', '140', 'Jardim São Luiz', 'Itapira', 'SP', '13971-000', 'sac@cristalia.com.br', '(19) 3861-5100', @NOW, '', 1),
          ('Laboratório Teuto', '60.616.978/0001-14', 'Rua Eugênio de Lima', '60', 'Vila Progredior', 'São Paulo', 'SP', '04571-001', 'atendimento@teuto.com.br', '(11) 3466-2200', @NOW, '', 1),
          ('Laboratório Valeant', '60.610.038/0001-88', 'Rua do Forte', '102', 'Centro', 'São Paulo', 'SP', '02058-000', 'atendimento@valeant.com.br', '(11) 3178-4000', @NOW, '', 1),
          ('Laboratório Biolab', '59.471.376/0001-39', 'Avenida Francisco Matarazzo', '1510', 'Lapa', 'São Paulo', 'SP', '05001-200', 'atendimento@biolab.com.br', '(11) 3616-0800', @NOW, '', 1),
          ('Laboratório Daudt', '60.215.498/0001-32', 'Rua dos Três Irmãos', '112', 'Vila Progredior', 'São Paulo', 'SP', '02751-000', 'sac@daudt.com.br', '(11) 3356-1234', @NOW, '', 1),
          ('Lavoisier', '60.689.447/0001-77', 'Rua Mário Lopes Leão', '400', 'Bela Vista', 'São Paulo', 'SP', '01050-000', 'atendimento@lavoisier.com.br', '(11) 3325-3345', @NOW, '', 1),
          ('Hermes Pardini', '60.774.400/0001-88', 'Rua do Ouvidor', '99', 'Centro', 'Rio de Janeiro', 'RJ', '20010-000', 'sac@hermespardini.com.br', '(21) 2223-3434', @NOW, '', 1),
          ('Cia. Muller', '60.707.188/0001-19', 'Rua da Consolação', '1200', 'Bela Vista', 'São Paulo', 'SP', '01050-100', 'contato@ciamuller.com.br', '(11) 3256-9876', @NOW, '', 1),
          ('Novartis', '60.659.480/0001-32', 'Rua Tabapuã', '1250', 'Vila Progredior', 'São Paulo', 'SP', '04531-000', 'atendimento@novartis.com.br', '(11) 2189-6060', @NOW, '', 1),
          ('Fresenius Kabi', '60.826.588/0001-72', 'Rua dos Três Irmãos', '560', 'Vila Progredior', 'São Paulo', 'SP', '02751-000', 'sac@fresenius-kabi.com.br', '(11) 3341-4444', @NOW, '', 1),
          ('Med Farma', '60.285.337/0001-80', 'Rua Santa Cruz', '342', 'Vila Santa Clara', 'São Paulo', 'SP', '04112-210', 'contato@medfarma.com.br', '(11) 5512-7823', @NOW, '', 1),
          ('Distribuidora Riosul', '60.944.315/0001-01', 'Avenida das Américas', '2050', 'Centro', 'Rio de Janeiro', 'RJ', '22775-150', 'atendimento@riosul.com.br', '(21) 3362-2222', @NOW, '', 1),
          ('Laboratório Apsen', '60.535.417/0001-80', 'Rua do Ouvidor', '56', 'Centro', 'São Paulo', 'SP', '20010-000', 'apsen@apsen.com.br', '(11) 3103-9000', @NOW, '', 1),
          ('Biolab Sanus', '59.471.376/0001-39', 'Avenida Francisco Matarazzo', '1510', 'Lapa', 'São Paulo', 'SP', '05001-200', 'atendimento@biolab.com.br', '(11) 3616-0800', @NOW, '', 1),
          ('Eurofarma', '60.797.518/0001-64', 'Rua Américo Brasiliense', '280', 'Vila Progredior', 'São Paulo', 'SP', '04104-000', 'sac@eurofarma.com.br', '(11) 2121-2121', @NOW, '', 1),
          ('Laboratório Aché', '60.115.279/0001-18', 'Avenida do Estado', '500', 'Belenzinho', 'São Paulo', 'SP', '03082-000', 'atendimento@ache.com.br', '(11) 3278-1000', @NOW, '', 1),
          ('Marjan Farma', '59.514.229/0001-50', 'Rua Morato Coelho', '1215', 'Vila Progredior', 'São Paulo', 'SP', '05422-100', 'marjan@marjan.com.br', '(11) 3078-3122', @NOW, '', 1);
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
          ('Dipirona Sódica 500mg', 'Analgésico e antitérmico utilizado para dor e febre.', 'Comprimido', 'Analgésico/Antitérmico', @NOW, '', 1),
          ('Dipirona Sódica 1g', 'Analgésico e antitérmico utilizado para dor e febre.', 'Ampola', 'Analgésico/Antitérmico', @NOW, '', 1),
          ('Paracetamol 750mg', 'Analgésico utilizado para dor e febre.', 'Comprimido', 'Analgésico/Antitérmico', @NOW, '', 1),
          ('Ibuprofeno 400mg', 'Anti-inflamatório utilizado para dor e inflamação.', 'Comprimido', 'Anti-inflamatório', @NOW, '', 1),
          ('Paracetamol 1g', 'Analgésico e antitérmico para dor e febre.', 'Comprimido', 'Analgésico/Antitérmico', @NOW, '', 1),
          ('Ibuprofeno 600mg', 'Anti-inflamatório para dor e inflamação.', 'Comprimido', 'Anti-inflamatório', @NOW, '', 1),
          ('Soro Glicosado 5% 250ml', 'Solução para uso intravenoso.', 'Bolsa', 'Hidratante/Infusão', @NOW, '', 1),
          ('Metformina 500mg', 'Controle de glicemia em pacientes com diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, '', 1),
          ('Amoxicilina 875mg', 'Antibiótico de largo espectro.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Dexametasona 0,5mg', 'Corticosteroide para inflamações leves.', 'Comprimido', 'Corticosteroide', @NOW, '', 1),
          ('Losartana 100mg', 'Anti-hipertensivo para controle da pressão arterial.', 'Comprimido', 'Antihipertensivo', @NOW, '', 1),
          ('Metformina 1000mg', 'Controle da diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, '', 1),
          ('Amoxicilina + Clavulanato 875mg', 'Antibiótico de amplo espectro.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Cefalexina 500mg', 'Antibiótico para infecções respiratórias e urinárias.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Sais para Reidratação Oral', 'Suplemento eletrolítico para desidratação.', 'Sachê', 'Hidratante Oral', @NOW, '', 1),
          ('Insulina Glargina 100UI/ml', 'Insulina de ação prolongada para diabetes tipo 1 e 2.', 'Caneta', 'Hormônio/Insulina', @NOW, '', 1),
          ('Insulina Regular 100UI/ml', 'Insulina de ação rápida.', 'Caneta', 'Hormônio/Insulina', @NOW, '', 1),
          ('Sais para Reidratação com Zinco', 'Suplemento eletrolítico com zinco para desidratação.', 'Sachê', 'Hidratante Oral', @NOW, '', 1),
          ('Rehidratante Infantil', 'Repositor de eletrólitos para crianças.', 'Sachê', 'Hidratante Oral', @NOW, '', 1),
          ('Soro Fisiológico 100ml', 'Solução para uso intravenoso ou nasal.', 'Bolsa', 'Hidratante/Infusão', @NOW, '', 1),
          ('Soro Glicosado 10% 500ml', 'Solução glicosada para uso hospitalar.', 'Bolsa', 'Hidratante/Infusão', @NOW, '', 1),
          ('Insulina NPH 100UI/ml', 'Insulina de ação intermediária.', 'Caneta', 'Hormônio/Insulina', @NOW, '', 1),
          ('Insulina Detemir 100UI/ml', 'Insulina basal de longa duração.', 'Caneta', 'Hormônio/Insulina', @NOW, '', 1),
          ('Insulina Lispro 100UI/ml', 'Insulina de ação ultra-rápida.', 'Caneta', 'Hormônio/Insulina', @NOW, '', 1),
          ('Amoxicilina 250mg', 'Antibiótico para infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Omeprazol 10mg', 'Inibidor de bomba de prótons para refluxo.', 'Comprimido', 'Antiácido', @NOW, '', 1),
          ('Hidroclorotiazida 25mg', 'Diurético para controle da pressão arterial.', 'Comprimido', 'Diurético', @NOW, '', 1),
          ('Levodopa + Carbidopa', 'Tratamento da doença de Parkinson.', 'Comprimido', 'Neurológico', @NOW, '', 1),
          ('Risperidona 2mg', 'Antipsicótico utilizado em transtornos mentais.', 'Comprimido', 'Antipsicótico', @NOW, '', 1),
          ('Diazepam 10mg', 'Ansiolítico e relaxante muscular.', 'Comprimido', 'Ansiolítico', @NOW, '', 1),
          ('Sinvastatina 10mg', 'Redutor de colesterol.', 'Comprimido', 'Anticolesterol', @NOW, '', 1),
          ('Vitamina D3 1000UI', 'Suplemento vitamínico.', 'Comprimido', 'Suplemento/Vitamina', @NOW, '', 1),
          ('Cloroquina 250mg', 'Medicamento utilizado em doenças autoimunes e malária.', 'Comprimido', 'Imunomodulador', @NOW, '', 0),
          ('Hidroxicloroquina 400mg', 'Tratamento para lúpus e artrite reumatoide.', 'Comprimido', 'Imunomodulador', @NOW, '', 1),
          ('Ranitidina 150mg', 'Bloqueador H2 utilizado para tratar úlceras.', 'Comprimido', 'Antiácido', @NOW, '', 1),
          ('Isotretinoína 20mg', 'Tratamento para acne grave.', 'Cápsula', 'Dermatológico', @NOW, '', 0),
          ('AAS 100mg', 'Antiagregante plaquetário para prevenção cardiovascular.', 'Comprimido', 'Antitrombótico', @NOW, '', 1),
          ('Sinvastatina 40mg', 'Redutor de colesterol.', 'Comprimido', 'Anticolesterol', @NOW, '', 1),
          ('Carvedilol 25mg', 'Tratamento para insuficiência cardíaca.', 'Comprimido', 'Cardiovascular', @NOW, '', 1),
          ('Soro Fisiológico 0,9% 500ml', 'Solução salina para hidratação ou limpeza.', 'Bolsa', 'Hidratante/Infusão', @NOW, '', 1),
          ('Espirolactona 100mg', 'Diurético poupador de potássio.', 'Comprimido', 'Diurético', @NOW, '', 1),
          ('Albendazol 400mg', 'Antiparasitário utilizado no tratamento de verminoses.', 'Comprimido', 'Antiparasitário', @NOW, '', 1),
          ('Lorazepam 1mg', 'Ansiolítico para tratamento de transtornos de ansiedade.', 'Comprimido', 'Ansiolítico', @NOW, '', 1),
          ('Buscopan 10mg', 'Antiespasmódico para cólicas intestinais.', 'Comprimido', 'Antiespasmódico', @NOW, '', 1),
          ('Bromoprida 10mg', 'Antiemético utilizado para enjoo e refluxo.', 'Comprimido', 'Antiemético', @NOW, '', 1),
          ('AAS 500mg', 'Analgésico e antipirético.', 'Comprimido', 'Analgésico/Antitérmico', @NOW, '', 1),
          ('Ondansetrona 4mg', 'Medicamento para náuseas e vômitos.', 'Comprimido', 'Antiemético', @NOW, '', 1),
          ('Doxiciclina 100mg', 'Antibiótico utilizado para tratar infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Lorazepam 2mg', 'Ansiolítico utilizado para tratar transtornos de ansiedade.', 'Comprimido', 'Ansiolítico', @NOW, '', 1),
          ('Prazosin 1mg', 'Medicamento utilizado para tratar hipertensão e sintomas de hipertrofia prostática.', 'Comprimido', 'Antihipertensivo', @NOW, '', 1),
          ('Fluoxetina 20mg', 'Antidepressivo utilizado para tratar depressão e transtorno obsessivo-compulsivo.', 'Comprimido', 'Antidepressivo', @NOW, '', 1),
          ('Vitamina C 500mg', 'Suplemento antioxidante.', 'Comprimido', 'Suplemento/Vitamina', @NOW, '', 1),
          ('Naproxeno 500mg', 'Anti-inflamatório utilizado para aliviar dor e inflamação.', 'Comprimido', 'Anti-inflamatório', @NOW, '', 1),
          ('Prednisona 20mg', 'Corticosteroide utilizado no tratamento de condições inflamatórias e autoimunes.', 'Comprimido', 'Corticosteroide', @NOW, '', 0),
          ('Ciprofloxacino 500mg', 'Antibiótico utilizado no tratamento de infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Atorvastatina 20mg', 'Medicamento utilizado para reduzir o colesterol e prevenir doenças cardiovasculares.', 'Comprimido', 'Anticolesterol', @NOW, '', 1),
          ('Desloratadina 5mg', 'Antialérgico para rinite e urticária.', 'Comprimido', 'Antialérgico', @NOW, '', 1),
          ('Levotiroxina Sódica 50mcg', 'Reposição hormonal da tireoide.', 'Comprimido', 'Hormônio/Tireoide', @NOW, '', 1),
          ('Levotiroxina Sódica 100mcg', 'Tratamento de hipotireoidismo.', 'Comprimido', 'Hormônio/Tireoide', @NOW, '', 1),
          ('Ranitidina 75mg', 'Bloqueador de ácido estomacal.', 'Comprimido', 'Antiácido', @NOW, '', 0),
          ('Claritromicina 500mg', 'Antibiótico para infecções respiratórias.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Azitromicina 500mg', 'Antibiótico macrolídeo para infecções respiratórias e ISTs.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Levofloxacino 500mg', 'Antibiótico para infecções graves.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Betametasona 0,5mg', 'Corticosteroide para alergias e inflamações.', 'Comprimido', 'Corticosteroide', @NOW, '', 1),
          ('Prednisona 5mg', 'Corticosteroide para doenças autoimunes.', 'Comprimido', 'Corticosteroide', @NOW, '', 1),
          ('Amoxicilina 500mg', 'Antibiótico de amplo espectro para infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Paracetamol 500mg', 'Analgésico e antitérmico utilizado para dor e febre.', 'Comprimido', 'Analgésico/Antitérmico', @NOW, '', 1),
          ('Metformina 850mg', 'Medicamento utilizado no controle de diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, '', 1),
          ('Loratadina 10mg', 'Antialérgico utilizado para tratar reações alérgicas.', 'Comprimido', 'Antialérgico', @NOW, '', 1),
          ('Losartana 50mg', 'Medicamento utilizado para hipertensão e insuficiência cardíaca.', 'Comprimido', 'Antihipertensivo', @NOW, '', 1),
          ('Cloridrato de Sertralina 50mg', 'Medicamento utilizado no tratamento de depressão e ansiedade.', 'Comprimido', 'Antidepressivo', @NOW, '', 1),
          ('Omeprazol 20mg', 'Inibidor da bomba de prótons utilizado para tratar úlceras gástricas e refluxo ácido.', 'Comprimido', 'Antiácido', @NOW, '', 1),
          ('Cetoconazol 200mg', 'Antifúngico utilizado no tratamento de infecções fúngicas.', 'Comprimido', 'Antifúngico', @NOW, '', 1),
          ('Lisinopril 10mg', 'Medicamento utilizado para tratar hipertensão e insuficiência cardíaca.', 'Comprimido', 'Antihipertensivo', @NOW, '', 1),
          ('Cloridrato de Clonazepam 2mg', 'Ansiolítico utilizado no tratamento de transtornos de ansiedade e convulsões.', 'Comprimido', 'Ansiolítico', @NOW, '', 1),
          ('Captopril 25mg', 'Medicamento utilizado no tratamento de hipertensão e insuficiência cardíaca.', 'Comprimido', 'Antihipertensivo', @NOW, '', 1),
          ('Furosemida 40mg', 'Diurético utilizado no tratamento de hipertensão e insuficiência cardíaca.', 'Comprimido', 'Diurético', @NOW, '', 1),
          ('Salbutamol 5ml', 'Broncodilatador utilizado para asma e doenças pulmonares.', 'Frasco', 'Broncodilatador', @NOW, '', 1),
          ('Zolpidem 10mg', 'Medicamento utilizado para o tratamento de insônia.', 'Comprimido', 'Hipnótico', @NOW, '', 1),
          ('Enoxaparina 40mg', 'Anticoagulante utilizado no tratamento e prevenção de trombose.', 'Tubo', 'Anticoagulante', @NOW, '', 1),
          ('Salbutamol 2,5mg', 'Broncodilatador utilizado para asma e doenças pulmonares.', 'Frasco', 'Broncodilatador', @NOW, '', 1),
          ('Prednisona 10mg', 'Anti-inflamatório e imunossupressor.', 'Comprimido', 'Corticosteroide', @NOW, '', 1),
          ('Ibuprofeno 200mg', 'Anti-inflamatório não esteroide (AINE) para dor e inflamação.', 'Comprimido', 'Anti-inflamatório', @NOW, '', 1),
          ('Ferro Sulfato 200mg', 'Suplemento de ferro utilizado para tratar e prevenir a anemia ferropriva.', 'Comprimido', 'Suplemento/Anemia', @NOW, '', 1),
          ('Enalapril 10mg', 'Medicamento utilizado para tratar hipertensão e insuficiência cardíaca.', 'Comprimido', 'Antihipertensivo', @NOW, '', 0),
          ('Ácido Fólico 5mg', 'Vitamina utilizada na prevenção de defeitos do tubo neural e tratamento de anemias.', 'Comprimido', 'Suplemento/Vitamina', @NOW, '', 1),
          ('Fluimucil 600mg', 'Mucolítico utilizado no tratamento de doenças respiratórias.', 'Comprimido)', 'Mucolítico', @NOW, '', 0),
          ('Gliclazida 80mg', 'Medicamento utilizado no controle de diabetes tipo 2.', 'Comprimido', 'Antidiabético', @NOW, '', 1),
          ('Carbamazepina 200mg', 'Antiepilético utilizado no tratamento de epilepsia e transtornos do humor.', 'Comprimido', 'Antiepilético', @NOW, '', 1),
          ('Cimetidina 200mg', 'Antagonista H2 utilizado no tratamento de úlceras gástricas e refluxo.', 'Comprimido', 'Antiácido', @NOW, '', 1),
          ('Dexametasona 4mg', 'Corticosteroide utilizado no tratamento de inflamações e reações alérgicas.', 'Comprimido', 'Corticosteroide', @NOW, '', 1),
          ('Alprazolam 1mg', 'Ansiolítico utilizado para transtornos de ansiedade.', 'Comprimido', 'Ansiolítico', @NOW, '', 1),
          ('Amitriptilina 25mg', 'Antidepressivo utilizado também para dor crônica.', 'Comprimido', 'Antidepressivo', @NOW, '', 1),
          ('Baclofeno 10mg', 'Relaxante muscular usado em espasticidade.', 'Comprimido', 'Musculoesquelético', @NOW, '', 1),
          ('Benzetacil 1.200.000UI', 'Antibiótico para infecções bacterianas.', 'Ampola', 'Antibiótico', @NOW, '', 1),
          ('Carbocisteína 250mg/5ml', 'Mucolítico utilizado em doenças respiratórias.', 'Xarope', 'Mucolítico', @NOW, '', 1),
          ('Cetirizina 10mg', 'Antialérgico para rinite e urticária.', 'Comprimido', 'Antialérgico', @NOW, '', 1),
          ('Clobutinol + Doxilamina', 'Antitussígeno e antialérgico para tosse.', 'Xarope', 'Respiratório', @NOW, '', 1),
          ('Clopidogrel 75mg', 'Antiplaquetário usado em prevenção de AVC e infarto.', 'Comprimido', 'Antitrombótico', @NOW, '', 1),
          ('Codeína 30mg', 'Analgésico opioide para dor moderada.', 'Comprimido', 'Analgésico/Opiáceo', @NOW, '', 1),
          ('Diltiazem 60mg', 'Tratamento de angina e hipertensão.', 'Comprimido', 'Cardiovascular', @NOW, '', 1),
          ('Doxiciclina 50mg', 'Antibiótico usado para tratar infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Escitalopram 10mg', 'Antidepressivo para depressão e ansiedade.', 'Comprimido', 'Antidepressivo', @NOW, '', 1),
          ('Espinheira Santa 500mg', 'Fitoterápico para problemas digestivos.', 'Comprimido', 'Fitoterápico', @NOW, '', 1),
          ('Finasterida 1mg', 'Tratamento da alopecia androgenética.', 'Comprimido', 'Dermatológico', @NOW, '', 1),
          ('Furosemida 20mg', 'Diurético para tratar retenção de líquidos.', 'Comprimido', 'Diurético', @NOW, '', 1),
          ('Glicose 50%', 'Solução de glicose para hipoglicemia.', 'Ampola', 'Hidratante/Infusão', @NOW, '', 1),
          ('Hioscina 10mg', 'Antiespasmódico para dores abdominais.', 'Comprimido', 'Antiespasmódico', @NOW, '', 1),
          ('Isosorbida 20mg', 'Vasodilatador para angina.', 'Comprimido', 'Cardiovascular', @NOW, '', 1),
          ('Lactulose 667mg/ml', 'Laxante utilizado em constipação.', 'Xarope', 'Laxante', @NOW, '', 1),
          ('Lamotrigina 50mg', 'Antiepiléptico e estabilizador de humor.', 'Comprimido', 'Antiepilético', @NOW, '', 1),
          ('Lansoprazol 30mg', 'Tratamento de refluxo e úlcera gástrica.', 'Comprimido', 'Antiácido', @NOW, '', 1),
          ('Maleato de Enalapril 5mg', 'Tratamento de hipertensão e insuficiência cardíaca.', 'Comprimido', 'Antihipertensivo', @NOW, '', 1),
          ('Meloxicam 15mg', 'Anti-inflamatório para dores articulares.', 'Comprimido', 'Anti-inflamatório', @NOW, '', 1),
          ('Montelucaste 10mg', 'Controle de asma e rinite alérgica.', 'Comprimido', 'Respiratório', @NOW, '', 1),
          ('Morfina 10mg', 'Analgésico opioide potente.', 'Ampola', 'Analgésico/Opiáceo', @NOW, '', 1),
          ('Nifedipino 20mg', 'Anti-hipertensivo e vasodilatador.', 'Comprimido', 'Antihipertensivo', @NOW, '', 1),
          ('Nistatina 100.000UI', 'Antifúngico oral para candidíase.', 'Suspensão', 'Antifúngico', @NOW, '', 1),
          ('Nitrofurantoína 100mg', 'Antibiótico para infecção urinária.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Nortriptilina 25mg', 'Antidepressivo tricíclico.', 'Comprimido', 'Antidepressivo', @NOW, '', 1),
          ('Omeprazol 40mg', 'Tratamento de úlcera e refluxo ácido.', 'Comprimido', 'Antiácido', @NOW, '', 1),
          ('Pantoprazol 40mg', 'Inibidor de bomba de prótons para úlceras.', 'Comprimido', 'Antiácido', @NOW, '', 1),
          ('Penicilina G Benzatina', 'Antibiótico para sífilis e amigdalite.', 'Ampola', 'Antibiótico', @NOW, '', 1),
          ('Propranolol 40mg', 'Beta-bloqueador usado para ansiedade e hipertensão.', 'Comprimido', 'Antihipertensivo', @NOW, '', 1),
          ('Quetiapina 25mg', 'Antipsicótico para esquizofrenia e bipolaridade.', 'Comprimido', 'Antipsicótico', @NOW, '', 1),
          ('Rivaroxabana 20mg', 'Anticoagulante oral para prevenção de AVC.', 'Comprimido', 'Anticoagulante', @NOW, '', 1),
          ('Sertralina 100mg', 'Antidepressivo para transtornos de humor.', 'Comprimido', 'Antidepressivo', @NOW, '', 1),
          ('Sulfametoxazol + Trimetoprima', 'Antibiótico para infecções bacterianas.', 'Comprimido', 'Antibiótico', @NOW, '', 1),
          ('Tiamina 300mg', 'Vitamina B1 usada na deficiência e alcoolismo.', 'Comprimido', 'Suplemento/Vitamina', @NOW, '', 1),
          ('Tiamina 100mg', 'Vitamina B1 para suplementação.', 'Comprimido', 'Suplemento/Vitamina', @NOW, '', 1),
          ('Tramadol 50mg', 'Analgésico opioide para dor moderada.', 'Comprimido', 'Analgésico/Opiáceo', @NOW, '', 1),
          ('Valproato de Sódio 500mg', 'Antiepilético e estabilizador de humor.', 'Comprimido', 'Antiepilético', @NOW, '', 1),
          ('Varfarina 5mg', 'Anticoagulante oral usado na prevenção de trombose.', 'Comprimido', 'Anticoagulante', @NOW, '', 1),
          ('Verapamil 80mg', 'Tratamento de arritmias e hipertensão.', 'Comprimido', 'Cardiovascular', @NOW, '', 1),
          ('Vitamina B12 1000mcg', 'Tratamento de deficiência de B12.', 'Comprimido', 'Suplemento/Vitamina', @NOW, '', 1),
          ('Zolmitriptana 2,5mg', 'Tratamento de crises de enxaqueca.', 'Comprimido', 'Neurológico', @NOW, '', 1),
          ('Mebendazol 100mg', 'Antiparasitário usado no tratamento de verminoses.', 'Comprimido', 'Antiparasitário', @NOW, '', 1),
          ('Bromazepam 3mg', 'Ansiolítico para transtornos de ansiedade.', 'Comprimido', 'Ansiolítico', @NOW, '', 1),
          ('Loratadina + Pseudoefedrina', 'Tratamento de rinite alérgica com congestão.', 'Comprimido', 'Antialérgico', @NOW, '', 1),
          ('Desloratadina + Betametasona', 'Anti-histamínico e anti-inflamatório.', 'Comprimido', 'Antialérgico', @NOW, '', 1),
          ('Ácido Acetilsalicílico 300mg', 'Antiagregante plaquetário.', 'Comprimido', 'Antitrombótico', @NOW, '', 1),
          ('Isossorbida Dinitrato 10mg', 'Vasodilatador utilizado em angina.', 'Comprimido', 'Cardiovascular', @NOW, '', 1),
          ('Perindopril 5mg', 'Anti-hipertensivo inibidor da ECA.', 'Comprimido', 'Antihipertensivo', @NOW, '', 1),
          ('Rosuvastatina 10mg', 'Estatina usada para controlar colesterol.', 'Comprimido', 'Anticolesterol', @NOW, '', 1),
          ('Cetoprofeno 100mg', 'Anti-inflamatório para dor e inflamação.', 'Cápsula', 'Anti-inflamatório', @NOW, '', 1),
          ('Nimesulida 100mg', 'Analgésico e anti-inflamatório.', 'Comprimido', 'Anti-inflamatório', @NOW, '', 1),
          ('Glicose 25%', 'Solução de glicose usada em hipoglicemia.', 'Ampola', 'Hidratante/Infusão', @NOW, '', 1),
          ('Ácido Tranexâmico 250mg', 'Antifibrinolítico usado para controle de sangramentos.', 'Comprimido', 'Hemostático', @NOW, '', 1);
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @NOW DATETIME
SET @NOW = GETDATE()

INSERT INTO [dbo].[Stock]
            ([ProductId]
            ,[Quantity]
            ,[Batch])
VALUES  (1, 0, ''),
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
        (148, 0, '');
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @NOW DATETIME
SET @NOW = GETDATE()

INSERT INTO [dbo].[AspNetUsers]
           ([UserName]
           ,[NormalizedUserName]
           ,[FacilityId]
           ,[PasswordHash]
           ,[IsActive]
           ,[SecurityStamp]
           ,[ConcurrencyStamp]
           ,[CreatedOn]
           ,[UpdatedOn]
           ,[Email]
           ,[NormalizedEmail]
           ,[EmailConfirmed]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEnd]
           ,[LockoutEnabled]
           ,[AccessFailedCount])
     VALUES
        --    ('sms_master'                            -- UserName
        --    ,'SMS_MASTER'                            -- NormalizedUserName
        --    ,1                                       -- FacilityId
        --    ,'AQAAAAEAACcQAAAAEEZhAoV7oE3GgcF7YtS0BDX9FYH38ZxYYU8Fl8ewtTLR5zdpJxQfiAKGhT5G9KmnwA==' -- PasswordHash
        --    ,1                                       -- IsActive
        --    ,NEWID()                                 -- SecurityStamp
        --    ,NEWID()                                 -- ConcurrencyStamp
        --    ,GETDATE()                               -- CreatedOn
        --    ,CONVERT(datetime2, '0001-01-01', 7)     -- UpdatedOn
        --    ,NULL                                    -- Email
        --    ,NULL                                    -- NormalizedEmail
        --    ,0                                       -- EmailConfirmed
        --    ,NULL                                    -- PhoneNumber
        --    ,0                                       -- PhoneNumberConfirmed
        --    ,0                                       -- TwoFactorEnabled
        --    ,NULL                                    -- LockoutEnd
        --    ,0                                       -- LockoutEnabled
        --    ,0),                                     -- AccessFailedCount

           ('sms_adm', 'SMS_ADM', 1, 'AQAAAAIAAYagAAAAEInDkN9GkBRjwZL1UTGSFszpxFvf9k9sOFUhuqi4znauqc6JO8lbfooD0SITg1UBOg==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('sms_user', 'SMS_USER', 1, 'AQAAAAIAAYagAAAAEM2pbNnxQjAZy1ulExcwNhD5P8uUdz9JCIOZrgVP9eNeY+D1QCN6cFWQ7mbL82vXlQ==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('cdm_master', 'CDM_MASTER', 2, 'AQAAAAIAAYagAAAAEFRqC6EXxKEk1X+t/9A7kD+mlP0eLh5hOSF67naQSVfVRuAAEUTDfBx8YwDN7Xb8zA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('cdm_adm', 'CDM_ADM', 2, 'AQAAAAIAAYagAAAAEGEznp4Mov+P807A8sXQeM3exnWC9HnnKiwS+g0w9J9wtTvY3heD1CZwp0PLV3jxOw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('cdm_user', 'CDM_USER', 2, 'AQAAAAIAAYagAAAAEHVpqFcQR594y6amhFY45ce+QR1OYR4OaC1Zqom/qF5pRrf2YcEBGj+gPqRWtfwU2g==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('cdm_user2', 'CDM_USER2', 2, 'AQAAAAIAAYagAAAAELCzawxsWKcTH++FqGHy0vMOkVUc3Y01SW+ZDKNo5HrCNxqOVqqP5FJBbG5hFXRrVw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('ubs_ev_adm', 'UBS_EV_ADM', 3, 'AQAAAAIAAYagAAAAEJNIvNnGLov/l/UED4c7CwzFGepgyVSaYSnZ2eSYivKx6PT4j92I2j5iqJOA4WaSTA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('ubs_ev_user', 'UBS_EV_USER', 3, 'AQAAAAIAAYagAAAAEEjf7rif30IW7acNOoTYqNik1Ro4691IyNrB3u0y9ui1jjZt2UZardhHEoprHSvppQ==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('upa_esf_adm', 'UPA_ESF_ADM', 4, 'AQAAAAIAAYagAAAAEEgcIeuUZjqfyOuof28XbT182pPA/9T09aKTLbZzSlZDy2PxG/THuyOuOlQon/W6UA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('upa_esf_user', 'UPA_ESF_USER', 4, 'AQAAAAIAAYagAAAAEBdbFwODdEHL0Vy42AxuMlUU7LuLrjqYoy8yES8tQYacW7Fl2uqp67B0whODjQo/sA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('fac_adm', 'FAC_ADM', 5, 'AQAAAAIAAYagAAAAEKasCL+Mw6RQ8jU368OHoC5rbKSJD0xm9PwXOwC8bqRl+hp6KACkDgOClo++tsvaFQ==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('fac_user', 'FAC_USER', 5, 'AQAAAAIAAYagAAAAEAvWYwjTHlGhEpQf50BJH4UMfYnlbjnrtwLeeLmRimDOy/7GHWljEGBvNxZGiLuN6Q==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('samu_adm', 'SAMU_ADM', 6, 'AQAAAAIAAYagAAAAELvDFeva3JzSRivYXOrj3WZepjpQpsx6nWHZmMQ52tE5Dn2b65N1Dm7gTAakW0CAGQ==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('samu_user', 'SAMU_USER', 6, 'AQAAAAIAAYagAAAAEGWBgT8org9flrFAVpavmmtYxV8YibiIKoYgspt62JHeTYLGU2m3Mr7IJIe3jGdyxw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('psf_eu_adm', 'PSF_EU_ADM', 7, 'AQAAAAIAAYagAAAAEKXH/iQs61MBHpR4wtEp6puw3K5DNM0pzfVDF/NZqvBok/U5CsBxgU1SbnzYsu1u4A==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('psf_eu_user', 'PSF_EU_USER', 7, 'AQAAAAIAAYagAAAAEBBVjClnkcRkthTk580D7RRV3PAr5eoQsSgCiS3eVhrM4XViY+jCeMvc8SX5k5W1xQ==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('psf_ndl_adm', 'PSF_NDL_ADM', 8, 'AQAAAAIAAYagAAAAEOnHq2t18LUkmmH4zRKWZKTtrECfOy7i7sIDOxQ4hyR76ybmkWFbUMhmzbV1CTrzaw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('psf_ndl_user', 'PSF_NDL_USER', 8, 'AQAAAAIAAYagAAAAEG7EVAtV4Tnx6h38NGLZR1bXMCcZk0BSuZVZ9eOEFZDVm/btvHrS+VSXZj/6i9UqBA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('psf_jm_adm', 'PSF_JM_ADM', 9, 'AQAAAAIAAYagAAAAEMw0F1LApy6G/OMqqozbQ8WC0gjJJNKUYv8l3w8Xc/3ydJJXtnTSsK4zqJHvcRv5qw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('psf_jm_user', 'PSF_JM_USER', 9, 'AQAAAAIAAYagAAAAEGKpbatgZWktGmp0Q1p8ZVPjybspM5loNvPsjuJdF3G1rEmY9fYS54xXNQf9MmhDmQ==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('ubs_jf_adm', 'UBS_JF_ADM', 10, 'AQAAAAIAAYagAAAAEIDvGtcVPZXd0wJMOwHAmlMIz0txR0sjxbGqQF+A7QqliyBaagx9gZaWYzZZqi/YmA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('ubs_jf_user', 'UBS_JF_USER', 10, 'AQAAAAIAAYagAAAAECbGhXoE0L9vU83/ve6tpoUPpPBi4VakK9EHY/iPUSiZ1kqXPBVm3vpFJ2ICfUDHVw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('caem_ns_adm', 'CAEM_NS_ADM', 11, 'AQAAAAIAAYagAAAAEHo/jYYefKVn2TjDVKUKCMcAeBLy3sZqlOw8ZXBiDnI6v96INeEyEq6vOSCRUCOSnQ==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('caem_ns_user', 'CAEM_NS_USER', 11, 'AQAAAAIAAYagAAAAEMHVjnJmZD02XN9/mgbEWy5oXYZf56pypAJmxplFW6cdQcUWgmQYloEy3uZliQ1xmw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('asm_ab_adm', 'ASM_AB_ADM', 12, 'AQAAAAIAAYagAAAAEH7PM+alE7Elpui/nqfVfzhSuGxB1kjgqBuz++in1RBmEZGP5afoYPQC2F2BSbJkiw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('asm_ab_user', 'ASM_AB_USER', 12, 'AQAAAAIAAYagAAAAEFRlPQo3LvkloWhQ9F/Gp6lDNpxdsU54UhjOSlJW55fRdwNOQrPuUlmohTODmTXB7A==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('caps_ad_adm', 'CAPS_AD_ADM', 13, 'AQAAAAIAAYagAAAAEGBvDaT5NNrOqIgxTzw85AXJrMuuG7VtxiGp9Fj/GjNQC7Rdt+2mlEOzMOd4Y6suQg==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('caps_ad_user', 'CAPS_AD_USER', 13, 'AQAAAAIAAYagAAAAEJRNkHH5pfoOczRbkhIdmHzKaVoKoaNuLV+g7X3cFsme35VwXd/U4QdMnVb73xHzcA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('ccz_adm', 'CCZ_ADM', 14, 'AQAAAAIAAYagAAAAEOai27EJJ8ZPGdqmlUUjVwDcD1gFPsrjk3f4rB7tGl5VT0b0ZbzcS2zioVjErg5vpA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('ccz_user', 'CCZ_USER', 14, 'AQAAAAIAAYagAAAAEJkeANhhudJCCl58Jc9Z6F74E94TeMSb0ruJ9BmOcUQJ+MJZeH3rXwQLzg6L3Eqynw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('ubs_sj_adm', 'UBS_SJ_ADM', 15, 'AQAAAAIAAYagAAAAEB0a4KQYTi6wgYPodEElD42IbrZEldGZmFV043akgwrP2D/qQ+XBdwUU5zmgDU6gdw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('ubs_sj_user', 'UBS_SJ_USER', 15, 'AQAAAAIAAYagAAAAEKbB3a6pPqqbjUcH4/Q1lIVjn6lqv+6FhYDJ4DGzLGxtrtOAdLkM+p+0k06qdhkOVg==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('psf_jo_adm', 'PSF_JO_ADM', 16, 'AQAAAAIAAYagAAAAENNXaw3U1rmuZOmtabMX4Ra9NKrkWyx9GgJgNc9umOxG3iBwMIdFiDAXP+VuuzPumQ==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('psf_jo_user', 'PSF_JO_USER', 16, 'AQAAAAIAAYagAAAAEKMG25TXKiCxydn3Bn+tJmxqz/0vfbmP7XcFce1WwAEIZmiAfGIRia3B8boA4+bHIA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('ubs_vp_adm', 'UBS_VP_ADM', 17, 'AQAAAAIAAYagAAAAEA1oZsGT0gaC6apXpIW34WSzTK9Gr3qPLKYSrGwImiOzi4c/1DPzEfVGK3Fm+1iuJw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('ubs_vp_user', 'UBS_VP_USER', 17, 'AQAAAAIAAYagAAAAEADU13Fz2StTHgtsC97gmHBIJJwODkKp2WRPkfvTEum/L4kDN2B6R26RlJWN1A23nQ==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('psf_pt_adm', 'PSF_PT_ADM', 18, 'AQAAAAIAAYagAAAAEMpTcHK9BuS1QJ9KNTdS515TwDluXe5/4tYp9Yv61KgKckneWIdQ6axLMjALM+bPYg==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('psf_pt_user', 'PSF_PT_USER', 18, 'AQAAAAIAAYagAAAAEI7IfGiAHjnDf8yzgDymkG76kKwziy579An9Wh15IMWKmzQNTJ9BgDE5yOpW8ZGI4A==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('ubs_vs_adm', 'UBS_VS_ADM', 19, 'AQAAAAIAAYagAAAAEJFU6ZHfiz4NGBIrEIjo6pL6E+PvCAxILQqfHRhGINijerhPVwdP/fz7QUglmJZdjA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('ubs_vs_user', 'UBS_VS_USER', 19, 'AQAAAAIAAYagAAAAEIfaFSbC6Ygyg1K+C6bcNEfJPkFVgb5/xw5d/UqobF2zLpP7Am6A6kEDElYsKtwP2g==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('caps_2_adm', 'CAPS_2_ADM', 20, 'AQAAAAIAAYagAAAAEA8SD842NmHpi+KIDp6Cps2QADaMbepuIKr+4R1kg8TZGHkC5bDXPjwZ81yS9mvIRA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('caps_2_user', 'CAPS_2_USER', 20, 'AQAAAAIAAYagAAAAEODDJoaHU++wbKns7SlvDa0SBbdFcDpuoTUnRbHBQuSDLTZfI4728m4GVHaqwxJLLw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('psf_rsb_adm', 'PSF_RSB_ADM', 21, 'AQAAAAIAAYagAAAAEOZKNYAl8nzCWbY1bHJRuHZM8RhKX3oNPxbHjdQC62SnPhW4UKu+ijej0bRa0iOtmw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('psf_rsb_user', 'PSF_RSB_USER', 21, 'AQAAAAIAAYagAAAAEBi4Z10w2p1ijfxSJtPZFj0ef65E/Bh166sV4G9MPD6OhMhv/oBa/+Oyi28SZvC0EA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('psf_rg_adm', 'PSF_RG_ADM', 22, 'AQAAAAIAAYagAAAAEEKi6tkwkQP1LmQfG1c4Ws0okbolefOa/UWdGaJ/WVgf5RTd4a4zwki5xUCP4HwL2w==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('psf_rg_user', 'PSF_RG_USER', 22, 'AQAAAAIAAYagAAAAEFXApjAAi6TFP3KAz/hDU4gHH1in3arcjING4lpsbD3MU4fXjQtLRFqMsQz1GkE8mg==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('ubs_sr_adm', 'UBS_SR_ADM', 23, 'AQAAAAIAAYagAAAAEENscNHKH4TvIYRn7d2JhiZoCXMV9qU9jdgpk8KzJXdVUp/hEsCU1OrL2s7yzfEgXw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('ubs_sr_user', 'UBS_SR_USER', 23, 'AQAAAAIAAYagAAAAENlfljRv1VRszHuuOmiSibtpSiEK02wyVV8mpsX1Xqmb2ISvLgQhjo5BGTdtbZOEKg==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('ubs_esj_adm', 'UBS_ESJ_ADM', 24, 'AQAAAAIAAYagAAAAEK8Xfz688AfumEA516BsLQ8kJufqoolj9zGaYWtQgVl+UpkVYi4PC9SBZUxcDxnS1A==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('ubs_esj_user', 'UBS_ESJ_USER', 24, 'AQAAAAIAAYagAAAAEH74u2NR2wdgiQ/UWgTxfsjNdUN7NulkzEjwBXVNe/s8zS5QFwsUs3k/IGLHRfQe0w==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('psf_rsj_adm', 'PSF_RSJ_ADM', 25, 'AQAAAAIAAYagAAAAEFvWaHoSHU4+2DJDINwiJ4/Qx4pRF22Fspzc9MUYD4YZZsPr8Ef1Y7Ecbtf4NISmxA==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('psf_rsj_user', 'PSF_RSJ_USER', 25, 'AQAAAAIAAYagAAAAEKLbJKM+iVyCWJ8KUfi27+IVHxm91tt2aHPZdGAkcrIyzq7OVuE7fdN16m1JFSlecw==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),

           ('ubs_je_adm', 'UBS_JE_ADM', 26, 'AQAAAAIAAYagAAAAEPxM/2ah57++TC+gTDsborkuXA8z0H7l/7OinYt1gEVOR669ZdjC2dTa9jHTtgT4qQ==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0),
           ('ubs_je_user', 'UBS_JE_USER', 26, 'AQAAAAIAAYagAAAAECQ6+53/DkBQFouc5i8FW2SkclPbU2gRaOuE2c80wKPWVDYjBxRYWhUf+2bOBlrVgg==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0);
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

INSERT INTO [dbo].[AspNetUserRoles]
           ([UserId]
           ,[RoleId])
     VALUES
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
           (55, 3);
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
