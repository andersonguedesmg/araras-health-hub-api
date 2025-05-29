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
        ('Jed Bartlet', '292.593.758-60', 'Coordenador', '(19) 98564-1205', @NOW, '', 1),
        ('Matt Santos', '759.353.678-58', 'Coordenador', '(19) 98812-7589', @NOW, '', 1),
        ('Leo McGarry', '216.440.478-53', 'Auxiliar Administrativo', '(19) 97345-6402', @NOW, '', 0),
        ('Donna Moss', '819.682.918-30', 'Farmacêutico', '(19) 99985-3021', @NOW, '', 1),
        ('Josh Lyman', '848.710.488-61', 'Enfermeiro', '(19) 99123-8527', @NOW, '', 1),
        ('C. J. Cregg', '975.614.608-72', 'Agente de Endemias', '(19) 98142-6349', @NOW, '', 1),
        ('Kate Harper', '942.440.518-99', 'Auxiliar Administrativo', '(19) 98257-8901', @NOW, '', 1),
        ('Toby Ziegler', '939.598.358-25','Auxiliar Administrativo', '(19) 99765-4203', @NOW, '', 1),
        ('Sam Seaborn', '497.785.508-67', 'Enfermeiro', '(19) 99123-5080', @NOW, '', 1),
        ('Abbey Bartlet', '030.116.108-94', 'Farmacêutico', '(19) 99301-1050', @NOW, '', 1),
        ('Charlie Young', '605.573.148-79', 'Agente de Endemias', '(19) 99475-5678', @NOW, '', 1),
        ('Will Bailey', '414.870.098-95', 'Auxiliar Administrativo', '(19) 98230-4462', @NOW, '', 1),
        ('Ainsley Hayes', '303.192.668-42', 'Enfermeiro', '(19) 98734-7605', @NOW, '', 1),
        ('Arnold Vinick', '301.777.668-91', 'Auxiliar Administrativo', '(19) 99658-3470', @NOW, '', 0),
        ('Rachel Green', '321.654.987-00', 'Farmacêutico', '(19) 98451-2389', @NOW, '', 1),
        ('Ross Geller', '987.654.321-00', 'Auxiliar Administrativo', '(19) 98123-7654', @NOW, '', 1),
        ('Monica Geller', '159.753.486-20', 'Enfermeiro', '(19) 98745-1023', @NOW, '', 1),
        ('Chandler Bing', '753.951.258-96', 'Coordenador', '(19) 99564-7832', @NOW, '', 0),
        ('Joey Tribbiani', '951.357.456-87', 'Auxiliar Administrativo', '(19) 99642-1198', @NOW, '', 1),
        ('Phoebe Buffay', '852.741.963-11', 'Farmacêutico', '(19) 98325-4432', @NOW, '', 0),
        ('Gregory House', '741.852.963-32', 'Enfermeiro', '(19) 98976-2154', @NOW, '', 1),
        ('Lisa Cuddy', '963.258.741-66', 'Coordenador', '(19) 98712-6663', @NOW, '', 1),
        ('James Wilson', '321.987.654-99', 'Farmacêutico', '(19) 99112-9987', @NOW, '', 1),
        ('Eric Foreman', '654.123.987-22', 'Agente de Endemias', '(19) 98455-8790', @NOW, '', 1),
        ('Allison Cameron', '987.321.654-55', 'Enfermeiro', '(19) 98098-3212', @NOW, '', 1),
        ('Robert Chase', '741.963.258-44', 'Auxiliar Administrativo', '(19) 97976-4433', @NOW, '', 0),
        ('Chris Taub', '258.741.963-77', 'Auxiliar Administrativo', '(19) 98888-9009', @NOW, '', 1),
        ('Remy Hadley', '159.456.753-88', 'Enfermeiro', '(19) 99777-6755', @NOW, '', 1),
        ('Matt Albie', '951.159.357-00', 'Agente de Endemias', '(19) 98333-3030', @NOW, '', 1),
        ('Danny Tripp', '753.456.159-11', 'Farmacêutico', '(19) 98484-8484', @NOW, '', 1),
        ('Jordan McDeere', '456.159.753-22', 'Coordenador', '(19) 98686-1212', @NOW, '', 1),
        ('Harriet Hayes', '357.951.159-33', 'Enfermeiro', '(19) 98787-7898', @NOW, '', 0),
        ('Simon Stiles', '159.357.951-44', 'Auxiliar Administrativo', '(19) 98989-4747', @NOW, '', 1),
        ('Tom Jeter', '654.789.123-55', 'Auxiliar Administrativo', '(19) 98585-8585', @NOW, '', 1),
        ('Casey McCall', '123.456.789-00', 'Farmacêutico', '(19) 98181-8181', @NOW, '', 1),
        ('Dan Rydell', '321.123.456-11', 'Enfermeiro', '(19) 98282-8282', @NOW, '', 1),
        ('Dana Whitaker', '456.456.123-22', 'Auxiliar Administrativo', '(19) 98383-8383', @NOW, '', 1),
        ('Natalie Hurley', '789.789.123-33', 'Auxiliar Administrativo', '(19) 98484-8485', @NOW, '', 0),
        ('Jeremy Goodwin', '147.258.369-44', 'Enfermeiro', '(19) 98585-8586', @NOW, '', 1),
        ('Isaac Jaffe', '963.147.258-55', 'Coordenador', '(19) 98686-8686', @NOW, '', 1),
        ('Alan Shore', '249.732.810-00', 'Farmacêutico', '(19) 98401-1234', @NOW, '', 1),
        ('Denny Crane', '365.872.760-20', 'Coordenador', '(19) 98876-5543', @NOW, '', 1),
        ('Adrian Monk', '184.321.940-40', 'Agente de Endemias', '(19) 99811-2374', @NOW, '', 1),
        ('Michael Scofield', '182.295.910-90', 'Auxiliar Administrativo', '(19) 98560-4032', @NOW, '', 1),
        ('Tony Soprano', '103.640.250-60', 'Farmacêutico', '(19) 97987-1204', @NOW, '', 1),
        ('Ally McBeal', '379.045.320-68', 'Auxiliar Administrativo', '(19) 98543-6578', @NOW, '', 1),
        ('Frank Underwood', '709.293.670-38', 'Auxiliar Administrativo', '(19) 98439-1052', @NOW, '', 1),
        ('Seth Cohen', '591.003.280-17', 'Enfermeiro', '(19) 99504-2371', @NOW, '', 1),
        ('Summer Roberts', '284.075.900-59', 'Enfermeiro', '(19) 99102-3470', @NOW, '', 1),
        ('Sandy Cohen', '673.102.550-06', 'Coordenador', '(19) 98332-7740', @NOW, '', 1),
        ('Will McAvoy', '654.729.330-62', 'Coordenador', '(19) 98323-4420', @NOW, '', 1),
        ('MacKenzie McHale', '308.491.540-09', 'Auxiliar Administrativo', '(19) 98276-1598', @NOW, '', 1),
        ('Sloan Sabbith', '310.768.200-61', 'Auxiliar Administrativo', '(19) 98244-3150', @NOW, '', 1),
        ('Don Keefer', '164.802.630-77', 'Enfermeiro', '(19) 98899-2340', @NOW, '', 1),
        ('Chuck Bartowski', '202.875.660-20', 'Enfermeiro', '(19) 99865-4477', @NOW, '', 1),
        ('Mark Greene', '712.987.100-01', 'Auxiliar Administrativo', '(19) 98123-4770', @NOW, '', 1),
        ('Doug Ross', '470.359.230-06', 'Enfermeiro', '(19) 98733-9087', @NOW, '', 1),
        ('John Carter', '116.842.600-20', 'Farmacêutico', '(19) 98123-4567', @NOW, '', 1),
        ('Abby Lockhart', '090.633.180-30', 'Agente de Endemias', '(19) 98045-6651', @NOW, '', 1),
        ('Peter Benton', '086.521.740-38', 'Enfermeiro', '(19) 98760-4392', @NOW, '', 1),
        ('Neela Rasgotra', '942.351.540-29', 'Coordenador', '(19) 98076-1194', @NOW, '', 1),
        ('Carol Hathaway', '253.170.670-43', 'Enfermeiro', '(19) 98895-2291', @NOW, '', 1),
        ('Luka Kovač', '059.143.700-98', 'Auxiliar Administrativo', '(19) 98328-1147', @NOW, '', 1),
        ('Harvey Specter', '089.173.690-40', 'Auxiliar Administrativo', '(19) 99425-7012', @NOW, '', 1),
        ('Donna Paulsen', '871.542.630-94', 'Farmacêutico', '(19) 98413-6572', @NOW, '', 1),
        ('Louis Litt', '036.285.810-87', 'Coordenador', '(19) 98642-3033', @NOW, '', 1),
        ('Jon Snow', '325.987.741-66', 'Enfermeiro', '(19) 98132-1100', @NOW, '', 1),
        ('Arya Stark', '741.852.963-88', 'Auxiliar Administrativo', '(19) 98101-2345', @NOW, '', 1),
        ('Daenerys Targaryen', '951.357.258-99', 'Coordenador', '(19) 98100-1234', @NOW, '', 1),
        ('Tyrion Lannister', '617.450.300-85', 'Agente de Endemias', '(19) 99601-8933', @NOW, '', 1),
        ('Lennie Briscoe', '607.219.860-49', 'Agente de Endemias', '(19) 99233-0090', @NOW, '', 1),
        ('Ben Stone', '305.691.440-30', 'Enfermeiro', '(19) 99387-4456', @NOW, '', 1),
        ('Anita Van Buren', '220.374.830-58', 'Farmacêutico', '(19) 99012-6172', @NOW, '', 1),
        ('Jack McCoy', '188.967.230-36', 'Coordenador', '(19) 98490-7633', @NOW, '', 1);
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
          ('Centro de Distribuição de Medicamentos Ricardo Francisco Vechin', 'Rua Brasília', '295', 'Centro', 'Araras', 'SP', '13600-710', 'sms@araras.sp.gov.br', '(19) 3544-4280', @NOW, '', 1),
          ('UBS Ênio Vitalli', 'Rua Franca', '99', 'Jd. Piratininga', 'Araras', 'SP', '13604-066', 'sms@araras.sp.gov.br', '(19) 3544-4280', @NOW, '', 1),
          ('UPA Elisa Sbrissa Franchozza', 'Av. Irineu Carrocci', '400', 'José Ometto II', 'Araras', 'SP', '13606-414', 'sms@araras.sp.gov.br', '(19) 3543-5100', @NOW, '', 1),
          ('Farmácia de Alto Custo', 'Rua Brasília', '295', 'Centro', 'Araras', 'SP', '13600-710', 'sms@araras.sp.gov.br', '(19) 3551-1096', @NOW, '', 1),
          ('SAMU', 'Avenida Dona Renata', '4585', 'Centro', 'Araras', 'SP', '13600-001', 'sms@araras.sp.gov.br', '(19) 3541-6819', @NOW, '', 1),
          ('PSF Edmundo Ulson', 'Rua Ângelo Francato', '393', 'Parque Tiradentes', 'Araras', 'SP', '13606-652', 'sms@araras.sp.gov.br', '(19) 3544-5232', @NOW, '', 1),
          ('PSF Nilton De Lollo', 'Rua Catanduva', '253', 'Jd. São João', 'Araras', 'SP', '13604-044', 'sms@araras.sp.gov.br', '(19) 3544-7302', @NOW, '', 1),
          ('PSF Jair Mourão', 'Rua do Estudante', '110', 'Jardim José Ometto I', 'Araras', 'SP', '13606-314', 'sms@araras.sp.gov.br', '(19) 3544-7754', @NOW, '', 1),
          ('UBS José Fiori', 'Rua Ana da Silva', 's/nº', 'Jardim Nova Suissa', 'Araras', 'SP', '13607-088', 'sms@araras.sp.gov.br', '(19) 3542-9308', @NOW, '', 1),
          ('CAEM Dr. Nelson Salomé', 'Rua Nelson Ferreira', 's/nº', 'Jardim José Ometto II', 'Araras', 'SP', '13606-390', 'sms@araras.sp.gov.br', '(19) 3542-7602', @NOW, '', 1),
          ('Ambulatório de Saúde Mental Agnaldo Bianchini', 'Avenida Loreto', '1291', 'Jardim das Flores', 'Araras', 'SP', '13607-200', 'sms@araras.sp.gov.br', '(19) 3544-2674', @NOW, '', 1),
          ('CAPS-AD', 'Avenida Washington Luiz', '545', 'Centro', 'Araras', 'SP', '13600-720', 'sms@araras.sp.gov.br', '(19) 3542-4137', @NOW, '', 1),
          ('Centro de Controle de Zoonoses', 'Estrada Municipal Luiz Segundo DAlessandri', 's/nº', 'Conjunto Residencial Prefeito Professor Jair Della Colleta', 'Araras', 'SP', '13606-852', 'sms@araras.sp.gov.br', '(19) 3544-4413', @NOW, '', 1),
          ('UBS São João', 'Rua São João', 's/nº', 'Jardim São João', 'Araras', 'SP', '13606-300', 'sms@araras.sp.gov.br', '(19) 3544-7887', @NOW, '', 1),
          ('PSF José Ometto', 'Rua Irmã Ignácia', '200', 'Jardim José Ometto', 'Araras', 'SP', '13607-250', 'sms@araras.sp.gov.br', '(19) 3544-7845', @NOW, '', 1),
          ('UBS Vila Poloni', 'Rua Américo Vespe', '123', 'Vila Poloni', 'Araras', 'SP', '13605-520', 'sms@araras.sp.gov.br', '(19) 3544-7465', @NOW, '', 1),
          ('PSF Parque Tiradentes', 'Rua Antônio Freire', '400', 'Parque Tiradentes', 'Araras', 'SP', '13606-700', 'sms@araras.sp.gov.br', '(19) 3544-6224', @NOW, '', 1),
          ('UBS Vila Santana', 'Rua Santo Antônio', '110', 'Vila Santana', 'Araras', 'SP', '13606-800', 'sms@araras.sp.gov.br', '(19) 3544-5999', @NOW, '', 1),
          ('CAPS II', 'Rua Marinalva Mendes', '50', 'Jardim das Palmeiras', 'Araras', 'SP', '13607-400', 'sms@araras.sp.gov.br', '(19) 3544-5376', @NOW, '', 1),
          ('PSF Rural São Benedito', 'Estrada São Benedito', 's/nº', 'Zona Rural', 'Araras', 'SP', '13606-900', 'sms@araras.sp.gov.br', '(19) 3544-9080', @NOW, '', 1),
          ('PSF Rural Guaporé', 'Estrada Guaporé', 's/nº', 'Zona Rural', 'Araras', 'SP', '13607-450', 'sms@araras.sp.gov.br', '(19) 3544-9120', @NOW, '', 1),
          ('UBS Santa Rita', 'Rua Santa Rita', '100', 'Santa Rita', 'Araras', 'SP', '13607-500', 'sms@araras.sp.gov.br', '(19) 3544-9280', @NOW, '', 1),
          ('UBS Estância São João', 'Rua Estância São João', '250', 'Estância São João', 'Araras', 'SP', '13606-950', 'sms@araras.sp.gov.br', '(19) 3544-9500', @NOW, '', 1),
          ('PSF Rural São José', 'Estrada São José', 's/nº', 'Zona Rural', 'Araras', 'SP', '13607-550', 'sms@araras.sp.gov.br', '(19) 3544-9620', @NOW, '', 1),
          ('UBS Jardim Eldorado', 'Rua Eldorado', '350', 'Jardim Eldorado', 'Araras', 'SP', '13608-000', 'sms@araras.sp.gov.br', '(19) 3544-9730', @NOW, '', 1);
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
          ('Marjan Farma', '59.514.229/0001-50', 'Rua Morato Coelho', '1215', 'Vila Progredior', 'São Paulo', 'SP', '05422-100', 'marjan@marjan.com.br', '(11) 3078-3122', @NOW, '', 1)
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
           ('ubs_je_user', 'UBS_JE_USER', 26, 'AQAAAAIAAYagAAAAECQ6+53/DkBQFouc5i8FW2SkclPbU2gRaOuE2c80wKPWVDYjBxRYWhUf+2bOBlrVgg==', 1, NEWID(), NEWID(), @NOW, '', NULL, NULL, 0, NULL, 0, 0, NULL, 0, 0)
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
           (55, 3)
GO

-- ==================================================================================================================================
