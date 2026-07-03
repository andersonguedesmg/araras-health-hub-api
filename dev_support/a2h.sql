USE [ararashealthhub]
GO

DECLARE @MinDate DATETIME = '20250102'
DECLARE @MaxDate DATETIME = '20250117'
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @MaxDate)

;WITH RandomDates (Name, Cpf, [Function], Phone, IsActive, CreatedOn, UpdatedOn) AS (
      SELECT
            T.Name,
            T.Cpf,
            T.[Function],
            T.Phone,
            T.IsActive,

            -- 'CreatedOn'
            DATEADD(SECOND,
                (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
            ) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
                WHEN T.IsActive = 0
                THEN DATEADD(DAY, 1,
                        DATEADD(SECOND,
                            (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                            CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
                        )
                    )
                ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
               -- ('Name',                 'Cpf',             'Function',                 'Phone',           'IsActive')
                  ('Jed Bartlet',          '053.487.653-29',  'Coordenador',              '(19) 98564-8202',  1),
                  ('Matt Santos',          '428.196.772-00',  'Coordenador',              '(19) 98812-7589',  1),
                  ('Leo McGarry',          '619.043.208-87',  'Auxiliar Administrativo',  '(19) 97345-6402',  0),
                  ('Josh Lyman',           '387.904.053-48',  'Auxiliar Administrativo',  '(19) 99123-8527',  1),
                  ('Toby Ziegler',         '109.526.476-05',  'Auxiliar Administrativo',  '(19) 99765-4203',  1),
                  ('C. J. Cregg',          '975.614.608-72',  'Farmacêutico',             '(19) 98142-6349',  1),
                  ('Sam Seaborn',          '145.733.927-46',  'Auxiliar Administrativo',  '(19) 97149-5080',  1),
                  ('Donna Moss',           '814.391.135-95',  'Auxiliar de Farmácia',     '(19) 99985-3021',  1),
                  ('Charlie Young',        '605.573.148-79',  'Auxiliar Administrativo',  '(19) 97456-3146',  1),
                  ('Will Bailey',          '932.164.780-15',  'Auxiliar Administrativo',  '(19) 98230-4462',  1),
                  ('Kate Harper',          '248.601.734-51',  'Auxiliar Administrativo',  '(19) 98257-8901',  1),
                  ('Ainsley Hayes',        '540.832.179-05',  'Auxiliar de Farmácia',     '(19) 98734-7605',  1),
                  ('Amy Gardner',          '348.174.350-54',  'Farmacêutico',             '(19) 97417-9137',  1),
                  ('Percy Fitzwallace',    '456.151.820-75',  'Auxiliar Administrativo',  '(19) 98762-3698',  0),
                  ('Chandler Bing',        '356.918.420-56',  'Agente de Endemias',       '(19) 99564-7832',  0),
                  ('Joey Tribbiani',       '183.076.495-21',  'Auxiliar Administrativo',  '(19) 99642-1198',  1),
                  ('Rachel Green',         '401.597.332-68',  'Farmacêutico',             '(19) 98451-2389',  1),
                  ('Monica Geller',        '578.223.149-10',  'Auxiliar de Farmácia',     '(19) 98745-1023',  1),
                  ('Ross Geller',          '901.884.750-77',  'Auxiliar Administrativo',  '(19) 98982-7654',  1),
                  ('Phoebe Buffay',        '290.415.867-04',  'Farmacêutico',             '(19) 98821-4432',  1),
                  ('Gregory House',        '642.378.910-63',  'Enfermeiro',               '(19) 98976-2154',  1),
                  ('James Wilson',         '321.987.654-99',  'Enfermeiro',               '(19) 99112-9987',  1),
                  ('Allison Cameron',      '987.321.654-55',  'Enfermeiro',               '(19) 98098-3212',  1),
                  ('Matt Albie',           '174.053.820-00',  'Agente de Endemias',       '(19) 98333-3030',  0),
                  ('Danny Tripp',          '836.290.110-54',  'Farmacêutico',             '(19) 97297-3297',  1),
                  ('Jordan McDeere',       '285.741.056-11',  'Auxiliar de Farmácia',     '(19) 98686-1212',  1),
                  ('Alan Shore',           '318.490.572-00',  'Farmacêutico',             '(19) 98401-1234',  1),
                  ('Denny Crane',          '365.872.760-20',  'Auxiliar Administrativo',  '(19) 98876-5543',  1),
                  ('Mark Greene',          '930.417.586-77',  'Enfermeiro',               '(19) 99349-4770',  1),
                  ('John Carter',          '587.146.903-88',  'Farmacêutico',             '(19) 98123-4567',  1),
                  ('Abby Lockhart',        '169.324.570-90',  'Auxiliar de Farmácia',     '(19) 98045-6651',  1),
                  ('Neela Rasgotra',       '758.219.043-42',  'Enfermeiro',               '(19) 98076-7124',  1),
                  ('Lucien Dubenko',       '086.521.740-38',  'Enfermeiro',               '(19) 98760-4392',  1),
                  ('Carol Hathaway',       '012.345.678-90',  'Enfermeiro',               '(19) 98895-2291',  1),
                  ('Luka Kovač',           '059.143.700-98',  'Enfermeiro',               '(19) 98328-1147',  1),
                  ('Adrian Monk',          '713.849.520-22',  'Agente de Endemias',       '(19) 99811-2374',  1),
                  ('Michael Scofield',     '134.607.892-05',  'Auxiliar Administrativo',  '(19) 97564-4032',  1),
                  ('Tony Soprano',         '591.028.347-79',  'Farmacêutico',             '(19) 97987-1204',  0),
                  ('Ally McBeal',          '645.713.980-00',  'Auxiliar Administrativo',  '(19) 98543-6578',  1),
                  ('Frank Underwood',      '892.406.115-43',  'Coordenador',              '(19) 98439-1052',  1),
                  ('Sloan Sabbith',        '610.975.324-12',  'Auxiliar Administrativo',  '(19) 98244-3150',  1),
                  ('Don Keefer',           '789.201.463-55',  'Auxiliar Administrativo',  '(19) 98899-2340',  1),
                  ('Will McAvoy',          '654.729.330-62',  'Auxiliar de Farmácia',     '(19) 98323-4420',  1),
                  ('Natalie Hurley',       '068.591.309-47',  'Auxiliar Administrativo',  '(19) 98484-8485',  1),
                  ('Dana Whitaker',        '456.456.123-22',  'Auxiliar Administrativo',  '(19) 98383-8383',  1),
                  ('Jeremy Goodwin',       '147.258.369-44',  'Auxiliar Administrativo',  '(19) 98585-8586',  1),
                  ('Lennie Briscoe',       '607.219.860-49',  'Agente de Endemias',       '(19) 99233-0090',  0),
                  ('Ben Stone',            '305.691.440-30',  'Farmacêutico',             '(19) 99387-4456',  1),
                  ('Anita Van Buren',      '220.374.830-58',  'Farmacêutico',             '(19) 99012-6172',  1),
                  ('Adam Schiff',          '418.591.770-85',  'Auxiliar Administrativo',  '(19) 97582-3287',  0),
                  ('Abbie Carmichael',     '215.501.400-78',  'Auxiliar Administrativo',  '(19) 97483-6479',  1),
                  ('Connie Rubirosa',      '479.810.430-26',  'Auxiliar de Farmácia',     '(19) 98974-3196',  1),
                  ('Jack McCoy',           '188.967.230-36',  'Auxiliar Administrativo',  '(19) 98490-7633',  1),
                  ('Dexter Morgan',        '734.012.986-53',  'Auxiliar Administrativo',  '(19) 99384-2911',  1),
                  ('Jack Bauer',           '085.346.917-82',  'Agente de Endemias',       '(19) 99930-6871',  1),
                  ('David Palmer',         '482.395.990-58',  'Coordenador',              '(19) 98946-3045',  1),
                  ('Rosa Diaz',            '286.049.713-35',  'Auxiliar Administrativo',  '(19) 99475-3301',  1),
                  ('Amy Santiago',         '540.721.398-67',  'Auxiliar Administrativo',  '(19) 99213-6644',  1),
                  ('Raymond Holt',         '924.630.157-89',  'Auxiliar de Farmácia',     '(19) 99915-8720',  0),
                  ('Terry Jeffords',       '059.310.280-78',  'Auxiliar Administrativo',  '(19) 98702-9186',  1),
                  ('Lucifer Morningstar',  '187.593.240-66',  'Coordenador',              '(19) 99548-7299',  1),
                  ('Chloe Decker',         '043.167.892-05',  'Auxiliar Administrativo',  '(19) 98993-4108',  1),
                  ('Robin Scherbatsky',    '778.901.234-56',  'Auxiliar de Farmácia',     '(19) 99166-2930',  1),
                  ('Barney Stinson',       '889.012.345-67',  'Auxiliar Administrativo',  '(19) 98743-7099',  1),
                  ('Ted Mosby',            '530.149.370-43',  'Farmacêutico',             '(19) 99784-1155',  1),
                  ('Lorelai Gilmore',      '398.207.610-44',  'Auxiliar Administrativo',  '(19) 99076-3580',  1),
                  ('Luke Danes',           '738.921.060-22',  'Auxiliar Administrativo',  '(19) 99499-2841',  1),
                  ('Harvey Specter',       '434.567.890-12',  'Auxiliar Administrativo',  '(19) 98712-4350',  1),
                  ('Donna Paulsen',        '545.678.901-23',  'Farmacêutico',             '(19) 98413-6572',  1),
                  ('Louis Litt',           '656.789.012-34',  'Auxiliar Administrativo',  '(19) 98642-3033',  1)
      ) AS T (Name, Cpf, [Function], Phone, IsActive)
)

INSERT INTO [dbo].[Employees]
            ([Name]
            ,[Cpf]
            ,[Function]
            ,[Phone]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
SELECT
      Name,
      Cpf,
      [Function],
      Phone,
      CreatedOn,
      UpdatedOn,
      IsActive
FROM  RandomDates;
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @MinDate DATETIME = '20250106'
DECLARE @MaxDate DATETIME = '20250107'
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @MaxDate)

;WITH RandomDates (Name, IsActive, CreatedOn, UpdatedOn) AS (
      SELECT
            T.Name,
            T.IsActive,

            -- 'CreatedOn'
            DATEADD(SECOND,
                (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
            ) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
                WHEN T.IsActive = 0
                THEN DATEADD(DAY, 1,
                        DATEADD(SECOND,
                            (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                            CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
                        )
                    )
                ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
               -- ('Name',                          'IsActive')
                  ('Comprimido',                     1),
                  ('Vidro',                          0),
                  ('Bisnaga',                        1),
                  ('Cápsula',                        1),
                  ('Caixa de Madeira',               0),
                  ('Unidade',                        1),
                  ('Pacote de Amostra Grátis',       0),
                  ('Pacote com 10 unidades',         1),
                  ('Ampola',                         1),
                  ('Tambor 200 Litros',              0),
                  ('Flaconete',                      1),
                  ('Galão',                          1),
                  ('Caixa com 15 unidades',          0),
                  ('Caixa com 100 unidades',         1),
                  ('Caixa',                          1),
                  ('Saco Plástico Transparente',     0),
                  ('Suspensão Oral',                 1),
                  ('Pacote',                         1),
                  ('Pote de Vidro antigo',           0),
                  ('Frasco',                         1),
                  ('Frasco-Ampola',                  1),
                  ('Fardo',                          1),
                  ('Caixa com 7 unidades',           0),
                  ('Caixa com 12 unidades',          1),
                  ('Blister',                        1),
                  ('Dose Única Descartável',         0),
                  ('Pacote com 100 unidades',        1),
                  ('Sachê',                          1),
                  ('Garrafa PET',                    0),
                  ('Bloco com 100 folhas',           1),
                  ('Frasco Conta-Gotas',             1),
                  ('Pacote com 50 unidades',         1),
                  ('Caixa com 25 unidades',          0),
                  ('Tubo',                           1),
                  ('Par',                            1),
                  ('Caixa com 10 unidades',          1),
                  ('Galão de PVC Reciclado',         0),
                  ('Cartela com 4 unidades',         1),
                  ('Bolsa',                          1),
                  ('Envelope de Papel Pardo',        0),
                  ('Caixa com 5000 unidades',        1),
                  ('Quilo',                          1),
                  ('Rolo',                           1),
                  ('Saco de Linhagem/Ráfia',         0),
                  ('Caixa com 50 unidades',          1),
                  ('Kit',                            1),
                  ('Envelope estéril',               1),
                  ('Frasco de Alumínio',             0),
                  ('Pacote com 10 pares',            1),
                  ('Pote',                           1),
                  ('Bisnaga de Alumínio Amassável',  0),
                  ('Carretel',                       1),
                  ('Tambor Plástico Rotulado',       0),
                  ('Spray/Aerossol',                 1),
                  ('Frasco gotejador plástico',      0),
                  ('Bombona',                        1),
                  ('Caixa Isotérmica Descartável',   0),
                  ('Bloco',                          1)
      ) AS T (Name, IsActive)
)

INSERT INTO [dbo].[PackagingTypes]
            ([Name]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
SELECT
      Name,
      CreatedOn,
      UpdatedOn,
      IsActive
FROM  RandomDates;
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @MinDate DATETIME = '20250106'
DECLARE @MaxDate DATETIME = '20250107'
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @MaxDate)

;WITH RandomDates (Name, IsActive, CreatedOn, UpdatedOn) AS (
      SELECT
            T.Name,
            T.IsActive,

            -- 'CreatedOn'
            DATEADD(SECOND,
                (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
            ) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
                WHEN T.IsActive = 0
                THEN DATEADD(DAY, 1,
                        DATEADD(SECOND,
                            (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                            CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
                        )
                    )
                ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
               -- ('Name',                                      'IsActive')
                  ('Medicamento',                                1),
                  ('Remédio',                                    0),
                  ('Insumos de Vigilância em Saúde e Endemias',  1),
                  ('Material Hospitalar',                        1),
                  ('Material de Escritório',                     0),
                  ('Imunobiológicos e Vacinas',                  1),
                  ('Bens de Informática Obsoletos',              0),
                  ('Material de Limpeza',                        1),
                  ('Fraldas e Insumos de Higiene de Pacientes',  1),
                  ('Produtos Químicos Perigosos',                0),
                  ('Suprimento Administrativo e Operacional',    1),
                  ('Insumos Odontológicos',                      1),
                  ('Medicamentos da Farmácia Popular',           0),
                  ('Medicamento Vencido/Apreendido',             0),
                  ('Material de Manutenção de Prédios e UBS',    1),
                  ('Nutrição Parenteral e Suplementos',          1),
                  ('Equipamentos de Proteção Individual (EPI)',  1),
                  ('Uniformes e Vestuários',                     1),
                  ('Gases Medicinais',                           1),
                  ('Insumos de Laboratório e Reagentes',         1),
                  ('Ambulâncias e Peças Automotivas',            0),
                  ('Órteses, Próteses e Materiais Especiais',    1),
                  ('Móveis Hospitalares e Equipamentos',         0),
                  ('Material Didático e de Campanhas de Saúde',  1),
                  ('Alimentos Perecíveis de Cozinha',            0)
      ) AS T (Name, IsActive)
)

INSERT INTO [dbo].[MainCategories]
            ([Name]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
SELECT
      Name,
      CreatedOn,
      UpdatedOn,
      IsActive
FROM  RandomDates;
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @MinDate DATETIME = '20250108'
DECLARE @MaxDate DATETIME = '20250110'
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @MaxDate)

;WITH RandomDates (Name, MainCategoryId, IsActive, CreatedOn, UpdatedOn) AS (
      SELECT
            T.Name,
            T.MainCategoryId,
            T.IsActive,

            -- 'CreatedOn'
            DATEADD(SECOND,
                (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
            ) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
                WHEN T.IsActive = 0
                THEN DATEADD(DAY, 1,
                        DATEADD(SECOND,
                            (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                            CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
                        )
                    )
                ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
               -- ('Name',                               'MainCategoryId',  'IsActive')
                  ('Antipsicótico',                       1,                 1),
                  ('Material de Consumo Descartável',     4,                 1),
                  ('Acessório de Equipamento',            4,                 1),
                  ('AINE',                                1,                 1),
                  ('Anestésico Geral',                    1,                 0),
                  ('Antiparkinsoniano',                   1,                 1),
                  ('Papelaria e Impressos',               5,                 0),
                  ('Antialérgico',                        1,                 1),
                  ('Anticonvulsivante/Eletrólito',        1,                 1),
                  ('Hormonal/Endócrino',                  1,                 1),
                  ('Higiene Pessoal de Internação',       9,                 1),
                  ('Antitérmico',                         1,                 1),
                  ('Antidepressivo Tricíclico',           1,                 1),
                  ('Equipamento de Diagnóstico',          4,                 1),
                  ('Higiene Hospitalar Pesada',           8,                 1),
                  ('Anticonvulsivante',                   1,                 1),
                  ('Antivertiginoso',                     1,                 1),
                  ('Soros e Toxinas de Bloqueio',         6,                 1),
                  ('Antifúngico',                         1,                 1),
                  ('Anti-inflamatório Não Esteroidal',    1,                 0),
                  ('Inotrópico Cardíaco',                 1,                 1),
                  ('Anticoagulante',                      1,                 1),
                  ('Antiespasmódico',                     1,                 1),
                  ('EPI - Proteção Biológica',            4,                 1),
                  ('EPI - Administrativo',                5,                 0),
                  ('Suplemento Mineral',                  1,                 1),
                  ('Anestesia',                           1,                 1),
                  ('Uso Geral Almoxarifado',              5,                 0),
                  ('Gastrointestinal',                    1,                 1),
                  ('Analgésico/Antitérmico',              1,                 1),
                  ('Dermatológico',                       1,                 1),
                  ('Suprimentos Gerais de Enfermagem',    4,                 1),
                  ('Inseticidas e Larvicidas (Dengue)',   3,                 1),
                  ('Corticosteroide',                     1,                 1),
                  ('Vitamina',                            1,                 1),
                  ('Psicotrópico',                        1,                 1),
                  ('Antiviral',                           1,                 1),
                  ('Antibiótico',                         1,                 1),
                  ('Papelaria Correlata de UBS',          5,                 0),
                  ('Material de Apoio Clínico',           4,                 1),
                  ('Estabilizador de Humor',              1,                 1),
                  ('Documentação de Arquivo Morto',       5,                 0),
                  ('Detergente Enzimático',               8,                 1),
                  ('Instrumental de Exame Clínico',       4,                 1),
                  ('Diurético',                           1,                 1),
                  ('Ansiolítico',                         1,                 1),
                  ('Insumo Laboratorial e Reagentes',     4,                 1),
                  ('Antiulceroso',                        1,                 1),
                  ('Antiagregante Plaquetário',           1,                 1),
                  ('Anti-inflamatório Hormonal',          1,                 1),
                  ('Antiparasitário',                     1,                 1),
                  ('Antissépticos Tópicos',               4,                 1),
                  ('Agente Hiperglicemiante',             1,                 1),
                  ('EPI - Reutilizável de CD',            4,                 1),
                  ('Instrumental Cirúrgico Avançado',     4,                 1),
                  ('Curativo Simples',                    4,                 1),
                  ('Psiquiátrico Antigo',                 1,                 0),
                  ('Insumo de Diagnóstico Rápido',        4,                 1),
                  ('Antidepressivo',                      1,                 1),
                  ('Detergentes e Sabões de Piso',        8,                 1),
                  ('Analgésico/Opioide',                  1,                 0),
                  ('Saneantes/Desinfetantes',             8,                 1),
                  ('Material de Consumo Estéril',         4,                 1),
                  ('Antidiabético Oral',                  1,                 1),
                  ('Hematológico Especializado',          1,                 1),
                  ('Oftálmico',                           1,                 1),
                  ('Analgésico Opioide',                  1,                 1),
                  ('Anticonvulsivante/Sedativo',          1,                 1),
                  ('Higiene de Paciente Acamado',         9,                 1),
                  ('Antisséptico Bucal Odonto',           4,                 1),
                  ('Anti-histamínico',                    1,                 1),
                  ('Cicatrizante e Coagulante',           1,                 1),
                  ('Reposição Hidroeletrolítica',         1,                 0),
                  ('Antiemético',                         1,                 1),
                  ('Cardiovascular',                      1,                 1),
                  ('Material de Esterilização (CME)',     4,                 1),
                  ('Antihipertensivo',                    1,                 1),
                  ('Curativos Especiais (Grau III)',      4,                 1),
                  ('Antiagregante Clássico',              1,                 0),
                  ('Anestésico Local Odontológico',       1,                 1),
                  ('Solução Parenteral (Soros)',          1,                 1),
                  ('Diluente de Injetáveis',              1,                 0),
                  ('Expectorante',                        1,                 1),
                  ('Vasoprotetor',                        1,                 1),
                  ('Hidratação Endovenosa',               1,                 1),
                  ('Fraldas Geriátricas Tipo G/EG',       9,                 1),
                  ('Fraldas Geriátricas Descontinuadas',  9,                 0),
                  ('Vacinas de Rotina Pediátrica',        6,                 1),
                  ('Vacinas Campanhas Antigas',           6,                 0),
                  ('Equipamento de TI Sobressalente',     7,                 0),
                  ('Hotelaria Hospitalar (Lençóis)',      4,                 1),
                  ('Antigotoso',                          1,                 1),
                  ('Utensílios de Limpeza Mecânica',      8,                 1),
                  ('Reumatológico Especial',              1,                 0),
                  ('Solvente/Veículo Farmacêutico',       1,                 1),
                  ('Ansiolítico/Sedativo',                1,                 1),
                  ('Repositor Hidroeletrolítico',         1,                 1),
                  ('Kit de Procedimento Padrão',          4,                 1),
                  ('Anticoncepcional Oral/Injetável',     1,                 1),
                  ('Eletrólito Isolado',                  1,                 1)
      ) AS T (Name, MainCategoryId, IsActive)
)

INSERT INTO [dbo].[SubCategories]
            ([Name]
            ,[MainCategoryId]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
SELECT
      Name,
      MainCategoryId,
      CreatedOn,
      UpdatedOn,
      IsActive
FROM  RandomDates;
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @MinDate DATETIME = '20250102'
DECLARE @MaxDate DATETIME = '20250117'
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @MaxDate)

;WITH RandomDates (
      Name, Cnes, Cep, Street, Number, Neighborhood, City, State, Complement, Email, Phone, IsActive, CreatedOn, UpdatedOn
) AS (
      SELECT
            T.Name,
            T.Cnes,
            T.Cep,
            T.Street,
            T.Number,
            T.Neighborhood,
            T.City,
            T.State,
            T.Complement,
            T.Email,
            T.Phone,
            T.IsActive,

            -- 'CreatedOn'
            DATEADD(SECOND,
                (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
            ) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
                WHEN T.IsActive = 0
                THEN DATEADD(DAY, 1,
                        DATEADD(SECOND,
                            (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                            CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
                        )
                    )
                ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
               -- ('Name',                                                             'Cnes',     'Cep',          'Street',                                        'Complement',                        'Number',          'Neighborhood',                                                'City',          'State',          'Email',                                         'Phone',          'IsActive')
               -- ('Secretária Municipal da Saúde - Dr. João Geraldo Noronha',         '6345921',  '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'saude@araras.sp.gov.br',                        '(19) 3543-1522',  1),
                  ('Centro de Distribuição de Medicamentos Ricardo Francisco Vechin',  '1',        '13600-710',    'Rua Brasília',                                  '',                                  '295',             'Centro',                                                      'Araras',        'SP',             'dispensario@araras.sp.gov.br',                  '(19) 3544-3353',  1),
                  ('UBS Ênio Vitalli',                                                 '2067048',  '13604-066',    'Rua Franca',                                    '',                                  '99',              'Jardim Piratininga',                                          'Araras',        'SP',             'enio_vitalli@araras.sp.gov.br',                 '(19) 3544-4280',  1),
                  ('UPA Elisa Sbrissa Franchozza',                                     '5053293',  '13606-414',    'Avenida Irineu Carrocci',                       'até 1458/1459',                     '400',             'Jardim José Ometto II',                                       'Araras',        'SP',             'elisa_franchozza@araras.sp.gov.br',             '(19) 3543-5100',  1),
                  ('Farmácia de Alto Custo',                                           '20',       '13600-710',    'Rua Brasília',                                  '',                                  '295',             'Centro',                                                      'Araras',        'SP',             'farmacia_alto_custo@araras.sp.gov.br',          '(19) 3551-1096',  1),
                  ('SAMU Regional de Araras',                                          '7594933',  '13600-001',    'Avenida Dona Renata',                           'Norte - de 268 a 2732 - lado par',  '4585',            'Centro',                                                      'Araras',        'SP',             'samu@araras.sp.gov.br',                         '(19) 3541-6819',  1),
                  ('ESF Dr. Edmundo Ulson',                                            '2065320',  '13606-652',    'Rua Ângelo Francatto',                          '',                                  '393',             'Parque Tiradentes',                                           'Araras',        'SP',             'edmundo_ulson@araras.sp.gov.br',                '(19) 3544-5232',  1),
                  ('ESF Prof. Nilton De Lollo',                                        '2024926',  '13604-044',    'Rua Catanduva',                                 '',                                  '253',             'Jardim São João',                                             'Araras',        'SP',             'nilton_lollo@araras.sp.gov.br',                 '(19) 3544-7302',  1),
                  ('SAD Melhor em Casa',                                               '22',       '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'melhor_em_casa@araras.sp.gov.br',               '(19) 3543-1522',  1),
                  ('UBS José Fiori',                                                   '6676928',  '13607-088',    'Rua Ana da Silva',                              '(Inhana)',                          's/nº',            'Jardim Nova Suissa',                                          'Araras',        'SP',             'jose_fiori@araras.sp.gov.br',                   '(19) 3542-9308',  1),
                  ('CAEM Dr. Nelson Salomé',                                           '7013272',  '13606-390',    'Rua Nelson Ferreira',                           '',                                  's/nº',            'Jardim José Ometto II',                                       'Araras',        'SP',             'caem_nelson_salome@araras.sp.gov.br',           '(19) 3542-7602',  1),
                  ('Serviço de Saúde Mental Agnaldo Bianchini',                        '2038331',  '13607-200',    'Avenida Loreto',                                'até 1298 - lado par',               '1291',            'Jardim das Flores',                                           'Araras',        'SP',             'agnaldo_bianchini@araras.sp.gov.br',            '(19) 3544-2674',  1),
                  ('CAPS AD Arceu Scanavini',                                          '7739729',  '13601-001',    'Avenida Washington Luiz',                       'de 402/403 ao fim',                 '545',             'Vila Michielin',                                              'Araras',        'SP',             'caps_arceu_scanavini@araras.sp.gov.br',         '(19) 3542-4137',  1),
                  ('Centro de Controle de Zoonoses',                                   '25',       '13606-852',    'Estrada Municipal Luiz Segundo D''Alessandri',  '',                                  's/nº',            'Conjunto Residencial Prefeito Professor Jair Della Colleta',  'Araras',        'SP',             'controle_zoonoses@araras.sp.gov.br',            '(19) 3544-4413',  1),
                  ('Ambulatório de Pronto Atendimento Dr. Solon F. de Oliveira',       '5773989',  '13602-006',    'Rua dos Girassóis',                             '',                                  's/nº',            'Jardim Sobradinho',                                           'Araras',        'SP',             'solon_oliveira@araras.sp.gov.br',               '(19) 3544-5630',  0),
                  ('Vigilância Sanitária de Araras',                                   '2071541',  '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'vigilancia_sanitaria@araras.sp.gov.br',         '(19) 3543-1528',  1),
                  ('Unidade Móvel Odontológica',                                       '4369165',  '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'unidade_movel_odonto@araras.sp.gov.br',         '(19) 3543-1522',  0),
                  ('Unidade de Vigilância Epidemiológica',                             '3383504',  '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'vigilancia_epidemiologica@araras.sp.gov.br',    '(19) 3541-7037',  1),
                  ('UBS Osvaldo Salvador Devitte',                                     '2038358',  '13601-400',    'Avenida Presidente Castello Branco',            '',                                  '27',              'Conjunto Habitacional Narciso Gomes',                         'Araras',        'SP',             'osvaldo_devitte@araras.sp.gov.br',              '(19) 3544-4974',  1),
                  ('UBS Dr. Humberto Rodrigues Junior',                                '9059679',  '13607-005',    'Avenida Melvin Jones',                          'de 1 a 447 - lado ímpar',           's/nº',            'Jardim Nossa Senhora de Fátima',                              'Araras',        'SP',             'humberto_junior@araras.sp.gov.br',              '(19) 3544-6939',  1),
                  ('UBS Dr. Emerson Mercatelli',                                       '6880150',  '13609-384',    'Rua Aníbal Lopes da Silva',                     '',                                  '190',             'Residencial Bosque de Versalles',                             'Araras',        'SP',             'emerson_mercatelli@araras.sp.gov.br',           '(19) 3547-9609',  1),
                  ('UBS Dr. Antônio Simoes Pontes',                                    '0465658',  '13605-300',    'Avenida João Rossi',                            '',                                  's/nº',            'Chácaras Granja São Francisco',                               'Araras',        'SP',             'antonio_pontes@araras.sp.gov.br',               '(19) 3547-3195',  0),
                  ('UBS Antônio Carlos Fabricio',                                      '2067056',  '13606-320',    'Rua do Carpinteiro',                            '',                                  's/nº',            'Jardim José Ometto I',                                        'Araras',        'SP',             'antonio_fabricio@araras.sp.gov.br',             '(19) 3544-3569',  1),
                  ('UBS Alberto Franzini',                                             '9079912',  '13606-508',    'Rua Cássio Gonzaga',                            '',                                  's/nº',            'Jardim Morumbi',                                              'Araras',        'SP',             'alberto_franzini@araras.sp.gov.br',             '(19) 3541-8016',  1),
                  ('PS Dr. Alcides Franco de Oliveira',                                '4047206',  '13606-326',    'Avenida Lourenço Batistella',                   '',                                  '514',             'Jardim José Ometto I',                                        'Araras',        'SP',             'alcides_oliveira@araras.sp.gov.br',             '(19) 3541-7211',  0),
                  ('SAE/CTA Enfermeira Adalgisa dos Santos Gonçalves',                 '6758029',  '13600-559',    'Rua Doutor Francisco Paulo Russo',              '',                                  '119',             'Vila Bressan',                                                'Araras',        'SP',             'adalgisa_goncalves@araras.sp.gov.br',           '(19) 3544-2064',  1),
                  ('Posto de Atendimento Médico Eva Almeida Costa Cruz',               '2067560',  '13601-430',    'Avenida Presidente Café Filho',                 '',                                  '209',             'Conjunto Habitacional Narciso Gomes',                         'Araras',        'SP',             'eva_cruz@araras.sp.gov.br',                     '(19) 3541-7898',  0),
                  ('Farmácia CAM Guerino Bertolini',                                   '15',       '13606-414',    'Avenida Irineu Carrocci',                       'até 1458/1459',                     's/nº',            'Jardim José Ometto II',                                       'Araras',        'SP',             'guerino_bertolini@araras.sp.gov.br',            '(19) 3541-4211',  1),
                  ('Farmácia de Processos',                                            '11',       '13600-710',    'Rua Brasília',                                  '',                                  '295',             'Centro',                                                      'Araras',        'SP',             'farmacia_processos@araras.sp.gov.br',           '(19) 3551-1096',  1),
                  ('ESF Vital Pacífico Homem',                                         '2067587',  '13606-414',    'Avenida Irineu Carrocci',                       'até 1458/1459',                     '1469',            'Jardim José Ometto II',                                       'Araras',        'SP',             'vital_homem@araras.sp.gov.br',                  '(19) 3544-5411',  1),
                  ('Hospital de Campanha Covid 19',                                    '0611484',  '13606-390',    'Rua Nelson Ferreira',                           '',                                  's/nº',            'Jardim José Ometto II',                                       'Araras',        'SP',             'hospital_covid@araras.sp.gov.br',               '(19) 3543-1522',  0),
                  ('ESF Dr. Orlando Zaniboni',                                         '2066467',  '13606-643',    'Rua Francisco Cressoni',                        '',                                  '158',             'Parque Tiradentes',                                           'Araras',        'SP',             'orlando_zaniboni@araras.sp.gov.br',             '(19) 3541-7791',  1),
                  ('ESF Dr. Sebastião Jair Mourão',                                    '2066998',  '13606-314',    'Rua do Estudante',                              '',                                  '110',             'Jardim José Ometto I',                                        'Araras',        'SP',             'jair_mourao@araras.sp.gov.br',                  '(19) 3544-7754',  0),
                  ('ESF Francisco Nicola Cascelli',                                    '2066769',  '13604-172',    'Rua Melânia Baraldi Maróstica',                 '',                                  '550',             'Parque das Árvores',                                          'Araras',        'SP',             'francisco_cascelli@araras.sp.gov.br',           '(19) 3544-5424',  1),
                  ('ESF Jeronymo Ometto',                                              '3540049',  '13603-027',    'Rua Ciro Lagazzi',                              'até 798/799',                       '285',             'Jardim Cândida',                                              'Araras',        'SP',             'jeronymo_ometto@araras.sp.gov.br',              '(19) 3541-9490',  1),
                  ('ESF Lucia Boquette Meneghetti',                                    '2070464',  '13601-361',    'Rua Allan Kardec',                              '',                                  's/nº',            'Vila Dona Rosa Zurita',                                       'Araras',        'SP',             'lucia_meneghetti@araras.sp.gov.br',             '(19) 3544-7533',  1),
                  ('ESF Madre Carla Rabolin',                                          '2800764',  '13604-312',    'Rua Carlindo Fernandes',                        '',                                  's/nº',            'Jardim Residencial Alvorada',                                 'Araras',        'SP',             'madre_carla@araras.sp.gov.br',                  '(19) 3551-3563',  1),
                  ('ESF Narciso Gomes II',                                             '2067005',  '13601-430',    'Avenida Presidente Café Filho',                 '',                                  '209',             'Conjunto Habitacional Narciso Gomes',                         'Araras',        'SP',             'narciso_gomes@araras.sp.gov.br',                '(19) 3541-7898',  1),
                  ('ESF Ophelia Geraci Pesse',                                         '0467944',  '13604-472',    'Avenida Professor Dirçon Kammer',               '',                                  '880',             'Jardim Alto da Colina',                                       'Araras',        'SP',             'ophelia_pesse@araras.sp.gov.br',                '(19) 3542-4137',  1),
                  ('ESF Otavio João Breda',                                            '2024934',  '13606-839',    'Rua João Puppi',                                '',                                  '15',              'Parque Dom Pedro',                                            'Araras',        'SP',             'otavio_breda@araras.sp.gov.br',                 '(19) 3541-7593',  1),
                  ('ESF Dr. Fermin Blanco Vianna',                                     '2024896',  '13606-350',    'Rua Dalton Bird de Camargo Preto',              '',                                  '42',              'Jardim José Ometto II',                                       'Araras',        'SP',             'fermin_vianna@araras.sp.gov.br',                '(19) 3544-8559',  1),
                  ('ESF Dr. Bento Feres',                                              '3935574',  '13607-507',    'Rua Júlia Luiz Ruete',                          '',                                  '245',             'Jardim Ouro Verde II',                                        'Araras',        'SP',             'bento_feres@araras.sp.gov.br',                  '(19) 3542-5453',  1),
                  ('ESF Antônio Simoes Pontes',                                        '2024918',  '13605-300',    'Avenida João Rossi',                            '',                                  's/nº',            'Chácaras Granja São Francisco',                               'Araras',        'SP',             'antonio_pontes@araras.sp.gov.br',               '(19) 3547-3195',  1),
                  ('Centro Odontológico Dr. Solon de Oliveira Fernandes',              '2049422',  '13606-326',    'Avenida Lourenço Batistella',                   '',                                  '514',             'Jardim José Ometto I',                                        'Araras',        'SP',             'solon_oliveira@araras.sp.gov.br',               '(19) 3541-7211',  0),
                  ('Centro Médico Social Comunitário Irmã Maria Diva Patarra',         '2043645',  '13601-200',    'Avenida Padre Alarico Zacharias',               '',                                  '300',             'Jardim Belvedere',                                            'Araras',        'SP',             'irma_diva_patarra@araras.sp.gov.br',            '(19) 3543-3088',  0),
                  ('Centro de Atendimento Infantil Dr. Hercio Marcos Cintra Arantes',  '3988775',  '13606-314',    'Rua do Estudante',                              '',                                  '110',             'Jardim José Ometto I',                                        'Araras',        'SP',             'centro_infantil_hercio@araras.sp.gov.br',       '(19) 3542-9909',  1),
                  ('Centro de Saúde Dra. Rosa Chelminsk Teixeira',                     '2049414',  '13601-140',    'Avenida Governador Garcez',                     '',                                  '137',             'Jardim Belvedere',                                            'Araras',        'SP',             'rosa_teixeira@araras.sp.gov.br',                '(19) 3542-6164',  1),
                  ('Centro de Saúde da Mulher Jandira Alvares Leite Duarte',           '2022737',  '13602-005',    'Rua dos Antúrios',                              'até 48/49',                         '30',              'Jardim Sobradinho',                                           'Araras',        'SP',             'jandira_duarte@araras.sp.gov.br',               '(19) 3551-5440',  1),
                  ('Centro de Imagem Radiológica',                                     '2799367',  '13601-140',    'Avenida Governador Garcez',                     '',                                  's/nº',            'Jardim Belvedere',                                            'Araras',        'SP',             'imagem_radiologica@araras.sp.gov.br',           '(19) 3543-3055',  0),
                  ('CAPS IJ Infanto Juvenil',                                          '2870444',  '13601-008',    'Rua Carlindo Pereira da Costa',                 '',                                  's/nº',            'Vila Michielin',                                              'Araras',        'SP',             'caps_infanto_juvenil@araras.sp.gov.br',         '(19) 3551-0277',  1),
                  ('CAPS II Idalina Corredor Victorello',                              '3583686',  '13607-200',    'Avenida Loreto',                                'até 1298 - lado par',               '1291',            'Jardim das Flores',                                           'Araras',        'SP',             'caps_idalina_victorello@araras.sp.gov.br',      '(19) 3544-5874',  1),
                  ('Transporte Intermunicipal',                                        '12',       '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'transporte_intermunicipal@araras.sp.gov.br',    '(19) 3544-1878',  1),
                  ('Consultório na Rua',                                               '4662571',  '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'consultorio_rua@araras.sp.gov.br',              '(19) 3543-1522',  0),
                  ('Centro de Distribuição de Imunobiológicos de Araras',              '0500836',  '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'distribuicao_imunobiologico@araras.sp.gov.br',  '(19) 3543-1522',  0),
                  ('Endemias',                                                         '33',       '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'endemias@araras.sp.gov.br',                     '(19) 3551-5840',  1)
      ) AS T (Name, Cnes, Cep, Street, Complement, Number, Neighborhood, City, State, Email, Phone, IsActive)
)

INSERT INTO [dbo].[Facilities]
            ([Name]
            ,[Cnes]
            ,[Cep]
            ,[Street]
            ,[Number]
            ,[Neighborhood]
            ,[City]
            ,[State]
            ,[Complement]
            ,[Email]
            ,[Phone]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
SELECT
      Name,
      Cnes,
      Cep,
      Street,
      Number,
      Neighborhood,
      City,
      State,
      Complement,
      Email,
      Phone,
      CreatedOn,
      UpdatedOn,
      IsActive
FROM  RandomDates;
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @MinDate DATETIME = '20250102'
DECLARE @MaxDate DATETIME = '20250215'
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @MaxDate)

;WITH RandomDates (
      LegalName, TradeName, Cnpj, Cep, Street, Number, Neighborhood, City, State, Complement, Email, Phone, IsActive, CreatedOn, UpdatedOn
) AS (
      SELECT
            T.LegalName,
            T.TradeName,
            T.Cnpj,
            T.Cep,
            T.Street,
            T.Number,
            T.Neighborhood,
            T.City,
            T.State,
            T.Complement,
            T.Email,
            T.Phone,
            T.IsActive,

            -- 'CreatedOn'
            DATEADD(SECOND,
                (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
            ) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
                WHEN T.IsActive = 0
                THEN DATEADD(DAY, 1,
                        DATEADD(SECOND,
                            (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                            CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
                        )
                    )
                ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
               -- ('LegalName',                                                                      'TradeName',                                                  'Cnpj',                'Cep',          'Street',                                        'Complement'                           'Number',            'Neighborhood',                               'City',               'State',          'Email',                                'Phone',           'IsActive')
                  ('Droga Raia',                                                                     '',                                                           '44.177.977/0001-83',  '13607-280',    'Avenida Melvin Jones',                          'de 921 a 1699 - lado ímpar',          '1335',              'Centro',                                     'Araras',             'SP',             'sac@droga-raia.com.br',                '(19) 3541-0038',   1),
                  ('Farmais Distribuidora',                                                          '',                                                           '11.582.072/0001-12',  '04152-040',    'Avenida Maria Conceição',                       '',                                    '1050',              'Jardim da Saúde',                            'São Paulo',          'SP',             'comercial@farmais.com.br',             '(11) 5075-9911',   1),
                  ('Ultrafarma',                                                                     '',                                                           '06.862.412/0001-08',  '02751-000',    'Rua dos Três Irmãos',                           '',                                    '122',               'Vila Progredior',                            'São Paulo',          'SP',             'atendimento@ultrafarma.com.br',        '(11) 4003-4116',   1),
                  ('AstraZeneca Brasil',                                                             '',                                                           '60.582.059/0001-44',  '01000-000',    'Avenida Pasteur',                               '',                                    '500',               'Jardim Botânico',                            'São Paulo',          'SP',             'contato@astrazeneca.com',              '(11) 3463-5000',   1),
                  ('Biolab Sanus Farmaceutica LTDA',                                                 'Biolab & Co.',                                               '49.475.833/0016-84',  '06767-220',    'Avenida Paulo Ayres',                           '',                                    '280',               'Parque Pinheiros',                           'Taboão da Serra',    'SP',             'atendimento@biolab.com.br',            '(11) 3616-0800',   1),
                  ('Farmácia Avenida Araras',                                                        '',                                                           '44.214.385/0001-65',  '13607-061',    'Avenida da Saudade',                            '',                                    '174',               'Jardim Nossa Senhora de Fátima',             'Araras',             'SP',             'contato@avenida.com.br',               '(19) 3541-2345',   1),
                  ('Aché Laboratórios',                                                              '',                                                           '60.115.279/0001-18',  '07034-904',    'Rodovia Presidente Dutra',                      'km 222,2',                            'S/N',               'Porto da Igreja',                            'Guarulhos',          'SP',             'atendimento@ache.com.br',              '(11) 3278-1000',   1),
                  ('Marjan Farma',                                                                   '',                                                           '59.514.229/0001-49',  '04755-070',    'Rua Gibraltar',                                 '',                                    '195',               'Santo Amaro',                                'São Paulo',          'SP',             'marjan@marjan.com.br',                 '(11) 3078-3122',   0),
                  ('Ava Distribuidora de Produtos de Limpeza',                                       '',                                                           '11.880.018/0001-41',  '07739-095',    'Rua Alvarenga Peixoto',                         '(Vl S Gonçalo)',                      '143',               'Laranjeiras',                                'Caieiras',           'SP',             'atendimento@avadistribuidora.com.br',  '(11) 2952-2220',   1),
                  ('Laboratório Valeant',                                                            '',                                                           '60.610.038/0001-06',  '02058-000',    'Rua do Forte',                                  '',                                    '102',               'Centro',                                     'São Paulo',          'SP',             'atendimento@valeant.com.br',           '(11) 3178-4000',   0),
                  ('Central Farma Araras',                                                           '',                                                           '09.334.790/0001-27',  '13600-070',    'Rua Tiradentes',                                'até 630/631',                         '243',               'Centro',                                     'Araras',             'SP',             'contato@centralfarma.com.br',          '(19) 3541-3131',   1),
                  ('Laboratório Daudt',                                                              '',                                                           '60.215.498/0001-65',  '21540-100',    'Rua Simões da Mota',                            '',                                    '57',                'Turiaçu',                                    'Rio de Janeiro',     'RJ',             'sac@daudt.com.br',                     '(21) 3369-8500',   1),
                  ('Apsen Farmacêutica',                                                             '',                                                           '60.535.417/0001-80',  '04753-001',    'Rua Barão do Rio Branco',                       'de 462/463 ao fim',                   '835',               'Santo Amaro',                                'São Paulo',          'SP',             'apsen@apsen.com.br',                   '(11) 5645-5011',   1),
                  ('Cimed Indústria S.A.',                                                           '',                                                           '02.814.497/0001-07',  '01228-200',    'Avenida Angélica',                              'de 1698 ao fim - lado par',           '2248',              'Consolação',                                 'São Paulo',          'SP',             'tributario@grupocimed.com.br',         '(11) 3544-7200',   1),
                  ('Eurofarma Laboratórios',                                                         '',                                                           '62.579.262/0001-70',  '04603-903',    'Avenida Vereador José Diniz',                   '',                                    '3465',              'Santo Amaro',                                'São Paulo',          'SP',             'contato@eurofarma.com.br',             '(11) 3848-5000',   1),
                  ('EMS',                                                                            '',                                                           '61.442.807/0001-09',  '13186-901',    'Rodovia Jornalista Francisco Aguirre Proença',  'Km 08',                               'S/N',               'Chácaras Assay',                             'Hortolândia',        'SP',             'sac@ems.com.br',                       '(19) 3866-2000',   1),
                  ('Blau Farmacêutica',                                                              '',                                                           '02.438.344/0001-40',  '06705-030',    'Rodovia Raposo Tavares',                        'do km 28,002 ao km 31,000 - lado p',  '2833',              'Jardim do Rio Cotia',                        'Cotia',              'SP',             'contato@blaufarma.com.br',             '(11) 4615-9400',   1),
                  ('Center Cópias',                                                                  '',                                                           '54.298.978/0001-00',  '13600-060',    'Rua Júlio Mesquita',                            'até 628/629',                         '376',               'Centro',                                     'Araras',             'SP',             'contato@centercopias.com.br',          '(19) 3544-7016',   1),
                  ('Cristália Produtos Químicos Farmacêuticos LTDA',                                 'Laboratório Cristália',                                      '44.734.671/0001-51',  '13974-900',    'Avenida Paoletti',                              '',                                    '363',               'Jardim Bela Vista',                          'Itapira',            'SP',             'contato@cristalia.com.br',             '(11) 3083-2000',   1),
                  ('União Química Farmacêutica Nacional',                                            '',                                                           '61.104.342/0001-40',  '04552-000',    'Rua do Rocio',                                  '',                                    '2400',              'Vila Olímpia',                               'São Paulo',          'SP',             'contato@uniaofarmaceutica.com.br',     '(11) 3046-3300',   1),
                  ('Drogaria Romana',                                                                '',                                                           '52.935.954/0001-90',  '13603-004',    'Avenida Romana Ometto',                         '',                                    '231',               'Jardim Cândida',                             'Araras',             'SP',             'romana@sac.com.br',                    '(19) 3541-8910',   1),
                  ('Hypera Pharma',                                                                  '',                                                           '16.438.820/0001-97',  '05676-120',    'Avenida Magalhães de Castro',                   'de 1287/1288 ao fim',                 '4800',              'Cidade Jardim',                              'São Paulo',          'SP',             'sac@hypera.com.br',                    '(19) 3805-5000',   1),
                  ('Drogaria São Paulo',                                                             '',                                                           '74.248.725/0001-30',  '13600-001',    'Avenida Dona Renata',                           'Norte - de 268 a 2732 - lado par',    '1454',              'Centro',                                     'Araras',             'SP',             'araras1@drogariasaopaulo.com.br',      '(19) 99724-9873',  1),
                  ('Bayer Pharma',                                                                   '',                                                           '57.418.315/0001-14',  '04551-010',    'Rua Fidêncio Ramos',                            '',                                    '302',               'Vila Olímpia',                               'São Paulo',          'SP',             'contato@bayer.com.br',                 '(11) 3167-7000',   1),
                  ('Pfizer Brasil',                                                                  '',                                                           '33.202.663/0001-07',  '04583-905',    'Av. Dr. Chucri Zaidan',                         '',                                    '920',               'Vila Cordeiro',                              'São Paulo',          'SP',             'sac.brasil@pfizer.com',                '(11) 2127-7000',   1),
                  ('Sanofi Medley',                                                                  '',                                                           '33.557.704/0001-09',  '03071-000',    'Rua Humberto de Campos',                        '',                                    '400',               'Parque São Jorge',                           'São Paulo',          'SP',             'sac@medley.com.br',                    '(11) 2659-4000',   1),
                  ('Farmad',                                                                         '',                                                           '04.503.891/0001-33',  '13600-040',    'Praça Barão de Araras',                         '',                                    '418',               'Centro',                                     'Araras',             'SP',             'araras@farmad.com.br',                 '(19) 3542-9876',   1),
                  ('Multilab Indústria Farmacêutica',                                                '',                                                           '57.232.247/0001-15',  '03330-000',    'Rua São Jorge',                                 '',                                    '125',               'Jardim São Jorge',                           'São Paulo',          'SP',             'contato@multilab.com.br',              '(11) 2688-3000',   0),
                  ('Legrand Indústria Química e Farmacêutica',                                       '',                                                           '61.123.456/0001-08',  '01415-000',    'Rua das Acácias',                               '',                                    '500',               'Jardim América',                             'São Paulo',          'SP',             'contato@legrand.com.br',               '(11) 3815-6000',   1),
                  ('Neo Química Produtos Farmacêuticos',                                             '',                                                           '00.721.114/0001-60',  '04123-020',    'Rua dos Trabalhadores',                         '',                                    '500',               'Vila Mariana',                               'São Paulo',          'SP',             'sac@neoquimica.com.br',                '(11) 3134-7000',   1),
                  ('Sandoz Farmacêutica',                                                            '',                                                           '33.222.111/0001-30',  '01449-000',    'Av. Europa',                                    '',                                    '123',               'Jardim Europa',                              'São Paulo',          'SP',             'contato@sandoz.com.br',                '(11) 3897-9000',   1),
                  ('Drogaria Ultra Popular',                                                         '',                                                           '34.038.090/0001-21',  '13600-060',    'Rua Júlio Mesquita',                            'até 628/629',                         '466',               'Centro',                                     'Araras',             'SP',             'info@ultrapopular.com.br',             '(19) 3541-1234',   1),
                  ('Farmácia Ararense',                                                              '',                                                           '44.206.845/0001-03',  '13600-680',    'Praça Martinico Prado',                         '',                                    '38',                'Centro',                                     'Araras',             'SP',             'sac@ararenese.com.br',                 '(19) 3541-5678',   1),
                  ('Farmácia Drogal',                                                                '',                                                           '44.556.778/0001-52',  '13601-298',    'Avenida Padre Alarico Zacharias',               'de 841 ao fim - lado ímpar',          '1057',              'Jardim Nova Araras',                         'Araras',             'SP',             'drogalararas1@drogal.com.br',          '(19) 3542-6142',   1),
                  ('Ecolab Quimica LTDA',                                                            '',                                                           '00.536.772/0001-42',  '06422-120',    'Avenida Gupê',                                  'Galpao10.837',                        '10933',             'Jardim Belval',                              'Barueri',            'SP',             'atendimento@ecolab.com',               '(11) 2134-2754',   1),
                  ('Fragnari Distribuidora de Medicamentos LTDA',                                    '',                                                           '14.271.474/0001-82',  '18606-710',    'Rua Manoel Deodoro Pinheiro Machado',           'de 482/483 ao fim',                   '1218',              'Vila Santa Therezinha de Menino Jesus',      'Botucatu',           'SP',             'sac@fragnari.com.br',                  '(14) 3815-8574',   1),
                  ('Prohosp Distribuidora de Medicamentos LTDA',                                     '',                                                           '04.355.394/0001-51',  '81030-320',    'Rua José Ferreira de Barros',                   '',                                    '89',                'Fanny',                                      'Curitiba',           'PR',             'prohosp@prohosp.com.br',               '(41) 3246-3376',   1),
                  ('Laboratório Baldacci',                                                           '',                                                           '60.672.246/0001-49',  '04507-000',    'Rua Pedro Antônio de Magalhães',                '',                                    '640',               'Vila Nova Conceição',                        'São Paulo',          'SP',             'contato@baldacci.com.br',              '(11) 5082-1100',   0),
                  ('Papelaria 2000',                                                                 '',                                                           '85.866.786/0001-87',  '13600-110',    'Rua Marechal Deodoro',                          '',                                    '611',               'Centro',                                     'Araras',             'SP',             'contato@papelaria2000.com.br',         '(19) 3541-1276',   1),
                  ('Farmácia Belvedere',                                                             '',                                                           '02.872.781/0001-92',  '13601-100',    'Avenida Padre Atílio',                          '',                                    '144',               'Jardim Belvedere',                           'Araras',             'SP',             'vendas@farmaciabelvedere.com.br',      '(19) 3541-6666',   1),
                  ('Azulpharma Distribuidora de Medicamentos LTDA',                                  'Azul Farma',                                                 '03.634.617/0001-57',  '17123-056',    'Rua Octávio Tendolo',                           '',                                    '181',               'Jardim Márcia I',                            'Agudos',             'SP',             'vendas@azulpharma.com.br',             '(14) 3261-1644',   1),
                  ('Genérica Itatiba Distribuidora de Medicamentos LTDA',                            '',                                                           '41.319.803/0001-90',  '13255-360',    'Rua Romeu Augusto Rela',                        '',                                    '601',               'Jardim da Luz',                              'Itatiba',            'SP',             'vendas@genericaitatiba.com',           '(11) 4487-0295',   1),
                  ('Casa da Limpeza Araras LTDA',                                                    'Casa da Limpeza',                                            '58.010.257/0001-04',  '13600-569',    'Avenida Capitão Arthur dos Santos',             '',                                    '459',               'Vila Bressan',                               'Araras',             'SP',             'vendas@casadalimpezaararas.com',       '(19) 3351-1434',   1),
                  ('Phármakon Farmácia de Manipulação',                                              '',                                                           '29.334.112/0001-55',  '13600-040',    'Praça Barão de Araras',                         '',                                    '67',                'Centro',                                     'Araras',             'SP',             'biosaudeararas@farmacia.com.br',       '(19) 99910-9043',  0),
                  ('Mgf Distribuidora de Medicamentos LTDA',                                         '',                                                           '08.418.869/0001-62',  '97020-510',    'Rua Maria Noal',                                '',                                    '89',                'Noal',                                       'Santa Maria',        'RS',             'vendas@mgf.com.br',                    '(55) 99971-7660',  1),
                  ('Vasconcelos Industria Farmaceutica e Comercio LTDA',                             'Vmg Farmaceutica',                                           '05.155.425/0001-93',  '30620-070',    'Rua Caetano Pirri',                             '',                                    '520',               'Milionários (Barreiro',                      'Belo Horizonte',     'MG',             'sac@vmgfarmaceutica.com.br',           '(31) 3115-6120',   1),
                  ('Diffucap Chemobras',                                                             '',                                                           '45.161.472/0001-00',  '07024-000',    'Rua São Paulo',                                 '',                                    '200',               'Centro',                                     'Guarulhos',          'SP',             'contato@diffucap.com.br',              '(11) 2440-1000',   0),
                  ('Goldenplus - Comércio de Medicamentos e Produtos Hospitalares LTDA',             'Goldenplus',                                                 '17.472.278/0001-64',  '99740-000',    'Rua Das Roseiras',                              '',                                    '50',                'Centro',                                     'Barão de Cotegipe',  'RS',             'goldenplusdistribuidora@gmail.com',    '(54) 3523-2202',   1),
                  ('Nova Era Farmácia Homeopatia',                                                   '',                                                           '27.334.225/0001-13',  '13600-070',    'Rua Tiradentes',                                'até 630/631',                         '59',                'Centro',                                     'Araras',             'SP',             'orcamento@farmacianovaera.com.br',     '(19) 3541-3419',   0),
                  ('Comercial Sabbadini LTDA',                                                       'Comercial Sabbadini',                                        '39.013.917/0001-66',  '13600-120',    'Rua Benedita Nogueira',                         '',                                    '150',               'Centro',                                     'Araras',             'SP',             'orcamento@comercialsabbadini.com.br',  '(19) 3541-5221',   1),
                  ('Dife Distribuidora de Medicamentos LTDA',                                        '',                                                           '10.566.711/0001-81',  '85901-170',    'Rua Luiz Segundo Rossoni',                      '',                                    '315',               'Centro',                                     'Toledo',             'PR',             'difemedicamentos@hotmail.com',         '(44) 3528-4363',   1),
                  ('Nunesfarma Produtos Farmacêuticos LTDA',                                         'Nesh',                                                       '75.014.167/0001-00',  '80250-150',    'Rua Almirante Gonçalves',                       'de 2172/2173 ao fim',                 '2247',              'Água Verde',                                 'Curitiba',           'PR',             'nunesfarma@nunesfarma.com.br',         '(41) 3015-9824',   1),
                  ('Mantecorp Farmasa',                                                              '',                                                           '61.082.426/0002-07',  '06465-134',    'Rua Bonnard (Green Valley I)',                  '',                                    '980',               'Alphaville Empresarial',                     'Barueri',            'SP',             'daniel.almeida@hypera.com.br',         '(62) 3878-8150',   0),
                  ('Germed Farmacêutica',                                                            '',                                                           '45.992.062/0001-65',  '13186-901',    'Rodovia Jornalista Francisco Aguirre Proença',  '',                                    'S/N KM 08',         'Chácara Assay',                              'Hortolândia',        'SP',             'contabil.holding@ems.com.br',          '(19) 3887-9800',   1),
                  ('FQM Farmoquímica',                                                               '',                                                           '21.136.918/0001-32',  '04530-001',    'Rua Doutor Renato Paes de Barros',              'de 631/632 ao fim',                   '750',               'Itaim Bibi',                                 'São Paulo',          'SP',             'sac@fqm.com.br',                       '(11) 4000-0000',   1),
                  ('Werbran Distribuidora de Medicamentos LTDA',                                     '',                                                           '04.372.020/0001-44',  '85604-443',    'Avenida Natalino Faust',                        'até 1569 - lado ímpar',               '591',               'Padre Ulrico',                               'Francisco Beltrão',  'PR',             'werbran@werbran.com.br',               '(46) 3211-5000',   1),
                  ('Laboratório Teuto Brasileiro',                                                   '',                                                           '97.033.645/0001-62',  '05307-000',    'Rua Major Paladino',                            'até 469/470',                         '128',               'Vila Ribeiro de Barros',                     'São Paulo',          'SP',             'contato@teuto.com.br',                 '(11) 3645-0871',   1),
                  ('Geolab Indústria Farmacêutica',                                                  '',                                                           '36.889.126/0001-06',  '74000-000',    'Rua dos Laboratórios',                          '',                                    '200',               'Polo Industrial',                            'Goiânia',            'GO',             'contato@geolab.com.br',                '(62) 3900-0000',   1),
                  ('Drogasil Araras',                                                                '',                                                           '37.724.212/0001-21',  '13600-001',    'Avenida Dona Renata',                           'Norte - de 268 a 2732 - lado par',    '2345',              'Centro',                                     'Araras',             'SP',             'araras@drogasil.com.br',               '(19) 3541-4545',   1),
                  ('X-Data Informatica LTDA',                                                        'X-Data',                                                     '67.845.172/0001-37',  '13600-140',    'Rua José Bonifácio',                            '',                                    '717',               'Centro',                                     'Araras',             'SP',             'vendas@xdata.com.br',                  '(19) 3543-2000',   1),
                  ('Dimebrás Distribuidora Farmacêutica',                                            '',                                                           '42.545.039/0001-34',  '88133-560',    'Rua Cecília do Rego Almeida',                   '',                                    '300',               'Jardim Eldorado',                            'Palhoça',            'SC',             'dimebras@dimebras.com.br',             '(48) 3224-1834',   1),
                  ('Medmais Distribuidora',                                                          '',                                                           '54.223.019/0001-26',  '48400-000',    'Rua João Fernandes da Gama',                    '',                                    '160',               'Centro',                                     'Ribeira do Pombal',  'BA',             'medmais@medmais.com.br',               '(75) 9904-7884',   1),
                  ('VPA Atacadista',                                                                 '',                                                           '57.929.071/0001-90',  '03031-000',    'Rua Tiers',                                     '',                                    '505',               'Pari',                                       'Pari',               'SP',             'falecom@vpa.com.br',                   '(11) 3328-1145',   1),
                  ('Torrent Pharma',                                                                 '',                                                           '33.197.886/0001-00',  '01155-060',    'Rua Doutor Alfredo de Castro',                  '',                                    '200',               'Barra Funda',                                'São Paulo',          'SP',             'contato@torrentpharma.com.br',         '(11) 3874-9000',   1),
                  ('Libbs Farmacêutica',                                                             '',                                                           '42.332.686/0001-68',  '05036-040',    'Avenida Marquês de São Vicente',                'de 2200/2201 ao fim',                 '2219',              'Água Branca',                                'São Paulo',          'SP',             'contato@libbs.com.br',                 '(11) 3874-9000',   1),
                  ('Tecnofarma',                                                                     '',                                                           '35.897.853/0001-52',  '13000-000',    'Avenida Marechal Deodoro',                      '',                                    '789',               'Centro',                                     'Campinas',           'SP',             'contato@tecnofarma.com.br',            '(19) 3232-4444',   0),
                  ('Boehringer Ingelheim Brasil',                                                    '',                                                           '60.846.120/0001-00',  '04794-000',    'Avenida das Nações Unidas',                     'lado ímpar',                          '13797',             'Vila Gertrudes',                             'São Paulo',          'SP',             'contato@boehringer-ingelheim.com.br',  '(11) 4949-4700',   1),
                  ('Biosintética Farmacêutica',                                                      '',                                                           '61.272.164/0001-80',  '02055-000',    'Rua Doutor José Bernardo Pinto',                '',                                    '333',               'Vila Guilherme',                             'São Paulo',          'SP',             'contato@biosintetica.com.br',          '(11) 2171-8000',   0),
                  ('Pharma Total Zona Leste',                                                        '',                                                           '46.112.334/0001-34',  '13606-360',    'Avenida Presidente Vargas',                     'até 799 - lado ímpar',                '599',               'Jardim José Ometto II',                      'Araras',             'SP',             'pharmatotalzl@farmacia.com.br',        '(19) 3544-3072',   1),
                  ('Biobrás',                                                                        '',                                                           '30.136.215/0001-85',  '39400-000',    'Avenida Caxingui',                              '',                                    '25',                'Jardim Everest',                             'Montes Claros',      'MG',             'contato@biobras.com.br',               '(38) 3218-1000',   0),
                  ('Meizler-UCB Biopharma',                                                          '',                                                           '61.123.456/0001-09',  '04543-011',    'Avenida Presidente Juscelino Kubitschek',       'de 953 ao fim - lado ímpar',          '1327',              'Vila Nova Conceição',                        'São Paulo',          'SP',             'contato@meizler.com.br',               '(11) 3847-1700',   1),
                  ('Momenta Farmacêutica',                                                           '',                                                           '05.679.548/0001-90',  '02911-000',    'Rua Enéas Luís Carlos Barbanti',                '',                                    '216',               'Freguesia do Ó',                             'São Paulo',          'SP',             'sac@momentafarma.com.br',              '(11) 3977-9000',   1),
                  ('CM Hospitalar S.A.',                                                             'Mafra Hospitalar',                                           '12.420.164/0001-57',  '14097-052',    'Rua Miryan Strambi',                            '',                                    '2727',              'Recreio Anhangüera',                         'Ribeirão Preto',     'SP',             'contato@mafra.com.br',                 '(41) 3218-5000',   1),
                  ('Zambon Laboratórios',                                                            '',                                                           '61.189.789/0001-00',  '04794-000',    'Avenida das Nações Unidas',                     'lado ímpar',                          '14401',             'Vila Gertrudes',                             'São Paulo',          'SP',             'sac@zambon.com.br',                    '(11) 2110-4000',   1),
                  ('Lumar Comercio de Produtos Farmaceuticos LTDA',                                  'Lumar',                                                      '49.228.695/0001-52',  '14406-091',    'Avenida Wilson Begoi',                          '',                                    '745',               'Distrito Industrial Antônio Della - Torre',  'Franca',             'SP',             'sac@lumarfranca.com.br',               '(16) 3721-1102',   1),
                  ('Laboratório Farmacêutico Arboris',                                               '',                                                           '11.223.344/0001-91',  '18087-000',    'Rua das Indústrias',                            '',                                    '50',                'Distrito Industrial',                        'Sorocaba',           'SP',             'contato@arboris.com.br',               '(15) 3211-5000',   0),
                  ('Reval Atacado de Papelaria',                                                     '',                                                           '05.678.910/0001-12',  '17232-232',    'Rua Santo Antonio',                             '',                                    '1699',              'Distrito Industrial',                        'Itapuí',             'SP',             'vendas@reval.com.br',                  '(14) 3664-9811',   1),
                  ('Laboratório Catarinense',                                                        '',                                                           '84.683.746/0001-86',  '89204-000',    'Rua Doutor João Colin',                         '',                                    '1000',              'América',                                    'Joinville',          'SC',             'contato@labcatarinense.com.br',        '(47) 3451-2000',   0),
                  ('Lanlimp',                                                                        '',                                                           '22.334.556/0001-12',  '26373-280',    'Rua Minas Gerais',                              '',                                    '1300',              'Distrito Industrial',                        'Rio de Janeiro',     'RJ',             'atendimento@lanlimp.com.br',           '(24) 2106-9420',   1),
                  ('Multifarma Comércio e Representações LTDA',                                      '',                                                           '21.681.325/0001-57',  '33203-144',    'Avenida Três',                                  '',                                    '283',               'Parque Norte',                               'Vespasiano',         'MG',             'multifarma@multifarma.com.br',         '(31) 2522-8170',   1),
                  ('Distribuidora Alfa Saúde',                                                       '',                                                           '33.445.667/0001-01',  '13210-000',    'Rua das Mangueiras',                            '',                                    '321',               'Bairro Novo',                                'Jundiaí',            'SP',             'vendas@alfasaude.com.br',              '(11) 4588-9900',   0),
                  ('Zafra Distribuidora de Medicamentos e Produtos Hospitalares LTDA',               '',                                                           '41.347.974/0001-23',  '99704-396',    'Rua Espírito Santo',                            'de 1080 ao fim - lado par',           '1440',              'Linho',                                      'Erechim',            'RS',             'zaframedicamentos@gmail.com',          '(54) 99935-2862',  1),
                  ('Nalli Engenharia LTDA',                                                          'Nalli Engenharia',                                           '44.209.849/0001-45',  '13600-240',    'Rua Otávio Merlo',                              '',                                    '235',               'Jardim Anhangüera',                          'Araras',             'SP',             'nalli@nalli.com.br',                   '(19) 3321-5055',   1)
      ) AS T (LegalName, TradeName, Cnpj, Cep, Street, Complement, Number, Neighborhood, City, State, Email, Phone, IsActive)
)

INSERT INTO [dbo].[Suppliers]
            ([LegalName]
            ,[TradeName]
            ,[Cnpj]
            ,[Cep]
            ,[Street]
            ,[Number]
            ,[Neighborhood]
            ,[City]
            ,[State]
            ,[Complement]
            ,[Email]
            ,[Phone]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
SELECT
      LegalName,
      TradeName,
      Cnpj,
      Cep,
      Street,
      Number,
      Neighborhood,
      City,
      State,
      Complement,
      Email,
      Phone,
      CreatedOn,
      UpdatedOn,
      IsActive
FROM  RandomDates;
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @MinDate DATETIME = '20250108'
DECLARE @MaxDate DATETIME = '20250215'
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @MaxDate)

;WITH RandomDates (
      Name, Description, MainCategoryId, SubCategoryId, PackagingTypeId, IsActive, CreatedOn, UpdatedOn
) AS (
      SELECT
            T.Name,
            T.Description,
            T.MainCategoryId,
            T.SubCategoryId,
            T.PackagingTypeId,
            T.IsActive,

            -- 'CreatedOn'
            DATEADD(SECOND,
                (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
            ) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
                WHEN T.IsActive = 0
                THEN DATEADD(DAY, 1,
                        DATEADD(SECOND,
                            (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                            CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
                        )
                    )
                ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
         -- ('Name',                                                   'Description',                                                                              'MainCategoryId',  'SubCategoryId',  'PackagingTypeId',  'IsActive')
            ('Dipirona 500mg',                                         'Analgésico e antitérmico de uso oral.',                                                     1,                 29,               1,                  1),
            ('Paracetamol 750mg',                                      'Analgésico e antitérmico oral.',                                                            1,                 29,               1,                  1),
            ('Ibuprofeno 300mg',                                       'Anti-inflamatório não esteroidal (AINE) para dor e febre.',                                 1,                 4,                1,                  1),
            ('Amoxicilina 500mg',                                      'Antibiótico penicilínico de amplo espetro.',                                                1,                 38,               2,                  1),
            ('Cefalexina 250mg/5mL',                                   'Antibiótico cefalosporina em suspensão oral.',                                              1,                 38,               11,                 1),
            ('Omeprazol 20mg',                                         'Inibidor da bomba de prótons para redução da acidez gástrica.',                             1,                 48,               2,                  1),
            ('Loratadina 5mg/5mL',                                     'Anti-histamínico de segunda geração em xarope.',                                            1,                 71,               11,                 1),
            ('Máscara Proteção N95',                                   'Respirador PFF2 tipo N95 para proteção contra aerossóis.',                                  4,                 24,               3,                  1),
            ('Losartana Potássica 50mg',                               'Anti-hipertensivo, bloqueador de receptor de angiotensina.',                                1,                 76,               1,                  1),
            ('Cloridrato de Fluoxetina 20mg',                          'Antidepressivo inibidor seletivo da recaptação de serotonina (ISRS).',                      1,                 58,               2,                  1),
            ('Diazepam 10mg',                                          'Ansiolítico benzodiazepínico sujeito a controle especial.',                                 1,                 46,               1,                  1),
            ('Insulina NPH',                                           'Insulina de ação intermediária (basal) para controle do diabetes.',                         1,                 64,               29,                 1),
            ('Hidrocortisona 100mg',                                   'Glicocorticoide sistêmico injetável de ação rápida.',                                       1,                 34,               29,                 1),
            ('Dipirona Sódica 500mg/ml',                               'Analgésico e Antitérmico intravenoso ou intramuscular.',                                    1,                 29,               5,                  1),
            ('Cloridrato de Clorpromazina 100mg',                      'Antipsicótico típico estabilizador do sistema nervoso central.',                            1,                 1,                1,                  1),
            ('Carbonato de Lítio 300mg',                               'Estabilizador do humor indicado para transtorno bipolar.',                                  1,                 41,               1,                  1),
            ('Butilbrometo de Escopolamina',                           'Antiespasmódico indicado para cólicas gastrointestinais.',                                  1,                 23,               1,                  1),
            ('Adrenalina 1 mg/mL',                                     'Catecolamina para ressuscitação cardiopulmonar e choque anafilático.',                      1,                 94,               5,                  1),
            ('Cloridrato de Lidocaína 2% sem Vasoconstrictor',         'Anestésico local de curta duração para bloqueios e infiltrações.',                          1,                 82,               5,                  1),
            ('Soro Fisiológico 500mL',                                 'Solução isotônica de cloreto de sódio 0,9% para infusão.',                                  1,                 83,               21,                 1),
            ('Água Destilada 10 mL',                                   'Veículo estéril para diluição e reconstituição de injetáveis.',                             1,                 81,               5,                  1),
            ('Pilha Alcalina AAA (Palito)',                            'Fonte de energia para controles, lanternas e oxímetros.',                                   5,                 43,               3,                  1),
            ('Pilha Alcalina AA',                                      'Fonte de energia para mouses, termômetros e equipamentos médicos.',                         5,                 43,               3,                  1),
            ('Cloridrato de Levomepromazina 25mg',                     'Antipsicótico neuroleptico com potente ação sedativa.',                                     1,                 1,                1,                  1),
            ('Sulfato Ferroso 40mg',                                   'Antianêmico mineral para tratamento de anemia ferropriva.',                                 1,                 26,               1,                  1),
            ('Cloridrato de Amiodarona 200mg',                         'Antiarrítmico de classe III para controle de taquiarritmias.',                              1,                 74,               1,                  1),
            ('Cloridrato de Tramadol 50mg/mL',                         'Analgésico opioide de ação central para dores moderadas a intensas.',                       1,                 68,               5,                  1),
            ('Morfina 10mg',                                           'Analgésico opioide potente sujeito a controle sanitário estrito.',                          1,                 68,               5,                  1),
            ('Captopril 25mg',                                         'Anti-hipertensivo inibidor da enzima conversora de angiotensina (ECA).',                    1,                 76,               1,                  1),
            ('Furosemida 40mg',                                        'Diurético de alça para tratamento de edema e hipertensão.',                                 1,                 45,               1,                  1),
            ('Cloridrato de Sertralina 50mg',                          'Antidepressivo inibidor seletivo da recaptação de serotonina.',                             1,                 58,               2,                  1),
            ('Lorazepam 2mg',                                          'Ansiolítico benzodiazepínico de ação curta.',                                               1,                 46,               1,                  0),
            ('Vacina DTPa',                                            'Imunização acelular infantil contra difteria, tétano e coqueluche.',                        6,                 88,               29,                 1),
            ('Vacina Influenza Tetravalente',                          'Imunização anual fragmentada e inativada contra vírus da gripe.',                           6,                 88,               29,                 1),
            ('Cloreto de Benzalcônio',                                 'Antisséptico e desinfetante de superfícies e tecidos.',                                     4,                 51,               11,                 1),
            ('Sais de Reidratação Oral',                               'Mistura de eletrólitos para prevenção de desidratação por diarreia.',                       1,                 95,               28,                 1),
            ('Propranolol 40mg',                                       'Betabloqueador adrenérgico anti-hipertensivo e antiarrítmico.',                             1,                 76,               1,                  1),
            ('AAS 100mg',                                              'Antiagregante plaquetário indicado para prevenção cardiovascular.',                         1,                 49,               1,                  1),
            ('Cinarizina 75mg',                                        'Vasodilatador periférico e antivertiginoso para labirintopatias.',                          1,                 17,               1,                  1),
            ('Cloridrato de Clomipramina 25mg',                        'Antidepressivo tricíclico inibidor da recaptação de monoaminas.',                           1,                 13,               1,                  1),
            ('Cloridrato de Nortriptilina 25mg',                       'Antidepressivo tricíclico de segunda geração.',                                             1,                 13,               1,                  1),
            ('Loratadina 10mg',                                        'Anti-histamínico sistêmico de segunda geração.',                                            1,                 71,               1,                  1),
            ('Polivitamínico Baby',                                    'Suplemento vitamínico e mineral para lactentes e crianças pediátricas.',                    1,                 35,               11,                 1),
            ('Glicose 25%',                                            'Solução hipertônica injetável para reversão de hipoglicemia.',                              1,                 52,               5,                  1),
            ('Soro Fisiológico 0,9%',                                  'Solução de cloreto de sódio para lavagem e fluidoterapia.',                                 1,                 83,               21,                 1),
            ('Óculos de Proteção',                                     'Equipamento de proteção individual com hastes ajustáveis.',                                 4,                 24,               3,                  0),
            ('Cloridrato de Amitriptilina 25mg',                       'Antidepressivo tricíclico com propriedades ansiolíticas secundárias.',                      1,                 13,               1,                  1),
            ('Digoxina 0,25mg',                                        'Glicosídeo cardíaco com ação inotrópica positiva.',                                         1,                 20,               1,                  1),
            ('Espironolactona 25mg',                                   'Diurético poupador de potássio antagonista da aldosterona.',                                1,                 45,               1,                  1),
            ('Clonazepam 2mg',                                         'Anticonvulsivante e ansiolítico da classe dos benzodiazepínicos.',                          1,                 46,               1,                  1),
            ('Cloridrato de Levomepromazina 100mg',                    'Antipsicótico neuroléptico com potente ação sedativa.',                                     1,                 1,                1,                  1),
            ('Fenobarbital 40mg/mL',                                   'Anticonvulsivante barbitúrico em gotas de uso oral.',                                       1,                 16,               31,                 1),
            ('Metronidazol 250mg',                                     'Anti-infeccioso, antimicrobiano com ação antiprotozoária.',                                 1,                 38,               1,                  1),
            ('Fluconazol 150mg',                                       'Antifúngico triazólico de amplo espectro para dose única.',                                 1,                 19,               2,                  0),
            ('Cefalexina 500mg',                                       'Antibiótico cefalosporínico de primeira geração em cápsulas.',                              1,                 38,               2,                  1),
            ('Levotiroxina Sódica 100mcg',                             'Hormônio tireoidiano sintético para reposição no hipotireoidismo.',                         1,                 10,               1,                  1),
            ('Glicose 50%',                                            'Solução injetável altamente hipertônica para choque hipoglicêmico.',                        1,                 52,               5,                  1),
            ('Cloridrato de Prometazina 25mg',                         'Anti-histamínico h1 clássico com forte ação sedativa.',                                     1,                 71,               1,                  1),
            ('Dramin B6 DL EV 10mL',                                   'Antiemético associado a piridoxina para infusão endovenosa.',                               1,                 75,               5,                  1),
            ('Dersani',                                                'Loção oleosa à base de ácidos graxos essenciais para barreira dérmica.',                    1,                 61,               11,                 1),
            ('Varfarina 5mg',                                          'Anticoagulante oral inibidor da síntese dos fatores dependentes de vitamina K.',            1,                 21,               1,                  1),
            ('Dipirona Gotas 500mg/ml',                                'Analgésico e antitérmico em solução oral gotejadora.',                                      1,                 29,               31,                 1),
            ('Paracetamol Gotas 200mg/mL',                             'Analgésico de uso oral infantil com bico dosador gotejador.',                               1,                 29,               31,                 1),
            ('Metildopa 250mg',                                        'Anti-hipertensivo de ação central indicado na hipertensão gestacional.',                    1,                 76,               1,                  1),
            ('Lâmina Bisturi Nº15',                                    'Lâmina cirúrgica de aço carbono descartável esterilizada.',                                 4,                 54,               25,                 1),
            ('Lâmina Bisturi Nº23',                                    'Lâmina cirúrgica estéril para incisões cirúrgicas de tecidos densos.',                      4,                 54,               25,                 1),
            ('Nitroglicerina 5mg/mL',                                  'Vasodilatador coronariano potente para emergências cardiológicas.',                         1,                 74,               5,                  1),
            ('Alopurinol 300mg',                                       'Inibidor enzimático da xantina oxidase para redução de uratemia.',                          1,                 44,               1,                  0),
            ('Nitrazepam 5mg',                                         'Hipnótico e indutor do sono da família dos benzodiazepínicos.',                             1,                 46,               1,                  1),
            ('Prednisona 20mg',                                        'Glicocorticoide oral de potente ação anti-inflamatória e imunossupressora.',                1,                 34,               1,                  1),
            ('Fentanil 50mcg/ml',                                      'Analgésico opioide potente de curta duração para anestesia geral e sedação.',               1,                 68,               5,                  0),
            ('Biperideno 2mg',                                         'Anticolinérgico central para reversão de efeitos extrapiramidais.',                         1,                 6,                1,                  1),
            ('Haloperidol 2mg/mL',                                     'Antipsicótico neuroléptico em gotas para controle de agitação.',                            1,                 1,                31,                 1),
            ('Agulha Descartável 25 x 7',                              'Agulha hipodérmica siliconada com bisel trifacetado.',                                      4,                 2,                25,                 1),
            ('Agulha Descartável 25 x 8',                              'Agulha para injeção intramuscular profunda e aspiração.',                                   4,                 2,                25,                 1),
            ('Agulha 32G x 4mm',                                       'Agulha ultrafina para caneta de aplicação de insulina subcutânea.',                         4,                 2,                25,                 1),
            ('Haloperidol 5mg',                                        'Antipsicótico típico de alta potência para transtornos psicóticos.',                        1,                 1,                1,                  1),
            ('Bromoprida 4mg/mL',                                      'Antiemético e pró-cinético em solução oral.',                                               1,                 75,               31,                 1),
            ('Dexclorfeniramina 2mg',                                  'Anti-histamínico clássico para processos alérgicos sistêmicos.',                            1,                 71,               1,                  1),
            ('Levonorgestrel 0,75mg',                                  'Contraceptivo de emergência de dose única.',                                                1,                 99,               1,                  1),
            ('Carbonato de Cálcio 500mg',                              'Suplemento mineral para reposição e fixação de cálcio.',                                    1,                 26,               1,                  1),
            ('Bromoprida 5mg',                                         'Antiemético e pró-cinético de administração oral.',                                         1,                 75,               1,                  1),
            ('Ceftriaxona 1g',                                         'Antibiótico cefalosporínico de terceira geração injetável.',                                1,                 38,               29,                 1),
            ('Sulfato de Magnésio 10%',                                'Eletrólito utilizado na prevenção de crises convulsivas na eclampsia.',                     1,                 9,                5,                  1),
            ('Sabão Líquido Neutro 5L',                                'Sabão para higiene das mãos e limpeza de superfícies delicadas.',                           3,                 11,               6,                  1),
            ('Desengordurante Industrial 5L',                          'Desengordurante alcalino para áreas de cozinha e lavanderia.',                              3,                 60,               6,                  1),
            ('Alvejante sem Cloro 5L',                                 'Alvejante à base de peróxido para lavanderia hospitalar.',                                  3,                 62,               6,                  1),
            ('Cloridrato de Imipramina 25mg',                          'Antidepressivo tricíclico clássico.',                                                       1,                 13,               1,                  1),
            ('Clopidogrel 75mg',                                       'Antiagregante plaquetário para prevenção de eventos aterotrombóticos.',                     1,                 49,               1,                  1),
            ('Atenolol 50mg',                                          'Betabloqueador hidrofilico seletivo contra hipertensão.',                                   1,                 76,               1,                  1),
            ('Anlodipino 5mg',                                         'Anti-hipertensivo vasodilatador bloqueador de canais de cálcio.',                           1,                 76,               1,                  1),
            ('Diltiazem 60mg',                                         'Antagonista de canal de cálcio com efeito cardiodepressor.',                                1,                 76,               1,                  1),
            ('Insulina Regular',                                       'Insulina humana de ação rápida para controle agudo de glicemia.',                           1,                 64,               29,                 1),
            ('Noretisterona 0,35mg',                                   'Contraceptivo de progesterona isolada (minipílula).',                                       1,                 99,               1,                  1),
            ('Seringa 5ml',                                            'Seringa descartável sem agulha com bico luer lock.',                                        4,                 2,                3,                  1),
            ('Seringa 10ml',                                           'Seringa descartável com bico Luer Lock para infusão estável.',                              4,                 2,                3,                  1),
            ('Ácido Fólico 5mg',                                       'Vitamina do complexo B usada na prevenção de defeitos do tubo neural.',                     1,                 35,               1,                  1),
            ('Cloridrato de Levomepromazina 40mg/mL',                  'Antipsicótico com propriedades sedativas em gotas orais.',                                  1,                 1,                31,                 1),
            ('Dexametasona Creme 1mg/g',                               'Corticoide tópico para dermatoses responsivas a corticosteroides.',                         1,                 34,               18,                 1),
            ('Benzilpenicilina 1.200.000 UI',                          'Antibiótico penicilínico benzatina de ação prolongada (injetável).',                        1,                 38,               29,                 1),
            ('Cloreto de Suxametônio 100mg',                           'Bloqueador neuromuscular despolarizante de curta duração.',                                 1,                 26,               29,                 1),
            ('Dexclorfeniramina 2mg/5ml',                              'Antialérgico anti-histamínico em solução de xarope oral.',                                  1,                 71,               11,                 1),
            ('Hidróxido de Alumínio 61,5mg/mL',                        'Antiácido gástrico para alívio de azia e pirose.',                                          1,                 48,               11,                 1),
            ('Tiamina (B1) 300mg',                                     'Vitamina usada em deficiências nutricionais e encefalopatia metabólica.',                   1,                 35,               1,                  1),
            ('Fluoresceína 1% Colírio',                                'Corante para exames oftálmicos e diagnóstico de lesões corneanas.',                         1,                 82,               11,                 1),
            ('Hipoclorito de Sódio 1% 5L',                             'Solução clorada estável para desinfecção de superfícies e áreas críticas.',                 3,                 62,               6,                  1),
            ('Cloreto de Sódio 0,9% 10 mL',                            'Diluente estéril e solução fisiológica para reconstituição.',                               1,                 81,               5,                  1),
            ('Bicarbonato de Sódio 8,4% 10 mL',                        'Agente alcalinizante injetável para correção rápida de acidose.',                           1,                 81,               5,                  1),
            ('Dopamina 50mg/ml',                                       'Inotrópico adrenérgico para choque cardiogênico ou circulatório.',                          1,                 94,               5,                  1),
            ('Ciprofloxacino 500mg',                                   'Antibiótico quinolona de amplo espectro de uso oral.',                                      1,                 38,               1,                  1),
            ('Carbamazepina 20mg/mL',                                  'Anticonvulsivante estabilizador de membrana em suspensão oral.',                            1,                 16,               11,                 1),
            ('Soro Fisiológico 1000mL',                                'Solução isotônica de cloreto de sódio 0,9% para grande volume.',                            1,                 83,               21,                 1),
            ('Complexo B',                                             'Mistura balanceada de vitaminas hidrossolúveis do complexo B.',                             1,                 35,               1,                  1),
            ('Cetoprofeno 50mg/mL',                                    'Anti-inflamatório não esteroidal (AINE) injetável.',                                        1,                 4,                5,                  1),
            ('Touca com Elástico',                                     'Touca descartável em TNT para proteção de campo e procedimentos.',                          4,                 24,               8,                  1),
            ('Propé Descartável',                                      'Cobertura descartável sanfonada em TNT para calçados.',                                     4,                 24,               8,                  0),
            ('Prednisona 5mg',                                         'Corticoide sistêmico de manutenção de baixa dosagem.',                                      1,                 34,               1,                  1),
            ('Dexametasona 2mg/mL',                                    'Corticoide sistêmico injetável anti-inflamatório.',                                         1,                 34,               5,                  1),
            ('Fenitoína 100mg',                                        'Anticonvulsivante hidantoínico estabilizador de canais de sódio.',                          1,                 16,               1,                  1),
            ('Diclofenaco Sódico 50mg',                                'AINE de ação rápida para controle de dor aguda e inflamação.',                              1,                 4,                1,                  1),
            ('Nimesulida 50mg/mL',                                     'AINE com propriedades analgésicas em gotas orais.',                                         1,                 4,                31,                 1),
            ('Nifedipina 20mg',                                        'Vasodilatador periférico e coronariano, bloqueador de canais de cálcio.',                   1,                 76,               1,                  1),
            ('Carbamazepina 200mg',                                    'Anticonvulsivante de primeira linha e estabilizador do humor.',                             1,                 16,               1,                  1),
            ('Glicazida 30mg',                                         'Antidiabético oral da classe das sulfonilureias de liberação modificada.',                  1,                 64,               1,                  1),
            ('Periciazina 10mg',                                       'Antipsicótico fenotiazínico sedativo regulador de comportamento.',                          1,                 1,                1,                  1),
            ('Nitrato de Miconazol 20mg/g',                            'Antifúngico imidazólico de amplo espectro em creme dermatológico.',                         1,                 19,               18,                 1),
            ('Levofloxacino 500mg',                                    'Antibiótico fluoroquinolona de terceira geração.',                                          1,                 38,               1,                  1),
            ('Sulfadiazina de Prata 1%',                               'Agente antimicrobiano e cicatrizante tópico para queimaduras.',                             1,                 61,               18,                 1),
            ('Fita Adesiva Transparente (Durex Grande)',               'Fita multiuso para lacração de embalagens e pacotes de envio.',                             5,                 43,               23,                 1),
            ('Vitaminas + Sais Minerais',                              'Suplemento polivitamínico e mineral antioxidante para idosos.',                             1,                 35,               1,                  1),
            ('Carvedilol 6,25mg',                                      'Betabloqueador de terceira geração com ação vasodilatadora alfa-1.',                        1,                 76,               1,                  1),
            ('Cimetidina 150mg/mL',                                    'Antagonista H2 injetável para profilaxia de úlcera por estresse.',                          1,                 48,               5,                  1),
            ('Ambroxol 15mg/mL',                                       'Mucolítico e expectorante em xarope de uso infantil.',                                      1,                 86,               11,                 1),
            ('Citrato de Fentanila 0,05 mg/mL',                        'Opioide de alta potência para analgesia profunda e anestesia.',                             1,                 68,               5,                  1),
            ('Extensão Elétrica (3 Metros)',                           'Extensão reforçada tripolar para alimentação de equipamentos.',                             5,                 43,               3,                  1),
            ('Aciclovir 200mg',                                        'Antiviral análogo nucleosídeo para tratamento contra Herpesvírus.',                         1,                 36,               1,                  1),
            ('Gluconato de Cálcio 10%',                                'Solução injetável de eletrólito para correção rápida de hipocalcemia.',                     1,                 81,               5,                  1),
            ('Cimetidina 200mg',                                       'Antagonista dos receptores H2 para redução da acidez gástrica oral.',                       1,                 48,               1,                  1),
            ('Levonorgestrel 0,15 + Etinilestradiol 0,03',             'Contraceptivo hormonal oral combinado monofásico.',                                         1,                 99,               1,                  1),
            ('Ácido Valproico 250mg',                                  'Antiepiléptico de amplo espectro gástrico.',                                                1,                 16,               1,                  1),
            ('Tioridazina 100mg',                                      'Antipsicótico fenotiazínico neuroléptico com fraca ação extrapiramidal.',                   1,                 1,                1,                  1),
            ('Fita Teste de Glicemia',                                 'Tiras reagentes para monitorização e leitura de glicose capilar.',                          4,                 58,               8,                  1),
            ('Bicarbonato de Sódio 8,4% 250 mL',                       'Solução eletrolítica alcalinizante sistêmica volumosa.',                                    1,                 83,               21,                 1),
            ('Luva Látex Procedimento P',                              'Luva de látex não estéril para exames, proteção com pó biológico.',                         4,                 24,               8,                  1),
            ('Luva Látex Procedimento M',                              'Luva de látex não estéril para exames, proteção com pó biológico.',                         4,                 24,               8,                  1),
            ('Luva Látex Procedimento G',                              'Luva de látex não estéril para exames, proteção com pó biológico.',                         4,                 24,               8,                  1),
            ('Sonda Aspiração Traqueal c/ V Nº12',                     'Sonda plástica flexível com válvula reguladora para aspiração.',                            4,                 2,                3,                  1),
            ('Luva Estéril Nº7,5',                                     'Luva cirúrgica anatômica de látex estéril para procedimentos invasivos.',                   4,                 24,               8,                  1),
            ('Luva Estéril Nº8,0',                                     'Luva cirúrgica anatômica de látex estéril para procedimentos invasivos.',                   4,                 24,               8,                  1),
            ('Máscara Hudson com Reservatório Adulto',                 'Máscara facial para oxigenoterapia de alto fluxo com bolsa.',                               4,                 2,                3,                  1),
            ('Máscara N95 PFF2',                                       'Respirador descartável filtrante contra aerossóis de patógenos.',                           4,                 24,               3,                  0),
            ('Sonda Foley 2 Vias Nº14',                                'Sonda uretral de demora em látex siliconado com balão de retenção.',                        4,                 2,                3,                  1),
            ('Avental Camisola Hospitalar Tamanho M',                  'Vestuário hospitalar para permanência de pacientes em leito.',                              4,                 24,               3,                  1),
            ('Avental Camisola Hospitalar Tamanho P',                  'Vestuário hospitalar para permanência de pacientes em leito.',                              4,                 24,               3,                  1),
            ('Lápis Preto número 2',                                   'Grafite graduado para rascunhos e anotações administrativas rápidas.',                      5,                 43,               3,                  0),
            ('Protetor Facial Face Shield',                            'Barreira plástica transparente de policarbonato para proteção facial.',                     4,                 24,               3,                  1),
            ('Seringa 3ml',                                            'Seringa hipodérmica cilíndrica descartável graduada.',                                      4,                 2,                3,                  1),
            ('Seringa Insulina 1ml',                                   'Seringa descartável com agulha integrada para microdosagem de insulina.',                   4,                 2,                3,                  1),
            ('Agulha Descartável 30 x 8',                              'Agulha hipodérmica estéril para aplicação intramuscular profunda.',                         4,                 2,                25,                 1),
            ('Agulha Descartável 30 x 7',                              'Agulha hipodérmica estéril para injeção intramuscular e infusão.',                          4,                 2,                25,                 1),
            ('Scalp 23',                                               'Dispositivo do tipo borboleta para infusão e coleta de sangue venoso.',                     4,                 2,                3,                  1),
            ('Sonda Foley 2 Vias Nº16',                                'Sonda vesical de demora em látex siliconado para drenagem contínua.',                       4,                 2,                3,                  1),
            ('Abaixador de Língua - Espátula de Madeira',              'Espátula descartável de madeira cilíndrica para inspeção clínica.',                         4,                 65,               8,                  1),
            ('Compressa de Gaze Estéril',                              'Gaze hidrófila estéril dobrada em camadas para curativos limpos.',                          4,                 65,               8,                  1),
            ('Compressa de Gaze Não Estéril',                          'Gaze em rolo ou pacote não estéril para limpeza e absorção.',                               4,                 65,               8,                  1),
            ('Algodão Hidrófilo Rolo 500g',                            'Algodão macio de alta absorção para procedimentos e assepsia.',                             4,                 65,               23,                 1),
            ('Caneta Esferográfica',                                   'Caneta plástica de tinta azul para preenchimento de documentos físicos.',                   5,                 43,               3,                  0),
            ('Atadura de Crepe 10cm',                                  'Faixa elástica de crepe para imobilização provisória e curativos.',                         4,                 65,               23,                 1),
            ('Esparadrapo Médio',                                      'Fita adesiva de tecido impermeável para fixação pesada de coberturas.',                     4,                 65,               23,                 1),
            ('Fita Micropore 50x10',                                   'Fita adesiva de papel poroso hipoalergênico para fixações leves.',                          4,                 65,               23,                 1),
            ('Lençol de Papel Descartável',                            'Rolo de lençol de papel para cobertura higiênica de macas clínicas.',                       4,                 24,               23,                 1),
            ('Envelope Branco para Exames (260x360mm)',                'Envelope para acondicionamento seguro e entrega de exames de imagem.',                      5,                 7,                8,                  1),
            ('Gel para ECG e Ultrassom 100g',                          'Gel condutor hipoalergênico, solúvel em água para exames de diagnóstico.',                  4,                 58,               11,                 1),
            ('Papel Sulfite A4',                                       'Papel sulfite para impressão de laudos, receitas e prontuários.',                           5,                 7,                8,                  0),
            ('Eletrodos Descartáveis para ECG',                        'Eletrodo autoadesivo com gel sólido para monitorização cardíaca contínua.',                 4,                 58,               8,                  1),
            ('Papel Térmico ECG 210mm x 30m',                          'Papel termossensível em rolo para registro de eletrocardiograma.',                          4,                 58,               23,                 1),
            ('Tesoura Mayo 17cm',                                      'Tesoura cirúrgica em aço inoxidável para corte de fios e tecidos.',                         4,                 55,               3,                  1),
            ('Seringa 1ml sem Agulha',                                 'Seringa de precisão para microdosagens e aplicações intradérmicas.',                        4,                 2,                3,                  1),
            ('Sonda Retal Nº04',                                       'Sonda flexível para alívio e administração via retal.',                                     4,                 2,                3,                  0),
            ('Abocath Nº22 com Dispositivo de Segurança',              'Cateter intravenoso periférico com dispositivo de segurança ativo contra perfurações.',     4,                 2,                3,                  1),
            ('Agulha Descartável 13 x 4,5',                            'Agulha hipodérmica curta para administração de medicamentos via subcutânea.',               4,                 2,                25,                 1),
            ('Oxímetro de Pulso de Dedo',                              'Dispositivo médico portátil para monitorização não invasiva da SpO2 e pulso.',              4,                 91,               3,                  0),
            ('Clorexidina Hidroalcoólica 0,5%',                        'Antisséptico alcoólico de uso tópico para demarcação de campo operatório.',                 1,                 74,               11,                 1),
            ('Seringa 20ml',                                           'Seringa hipodérmica descartável de grande volume com bico Luer Lock.',                      4,                 2,                3,                  1),
            ('Sonda Uretral Nº20',                                     'Sonda uretral plástica transparente de grande calibre para alívio intermitente.',           4,                 2,                3,                  1),
            ('Tala Aramada Revestida G',                               'Tala em aramado maleável revestida com espuma para imobilização ortopédica.',               4,                 65,               3,                  1),
            ('Termômetro Digital',                                     'Termômetro clínico digital de contato para medição axilar de temperatura.',                 4,                 91,               3,                  1),
            ('Termômetro Infravermelho',                               'Termômetro digital clínico com sensor infravermelho para medição sem contato.',             4,                 91,               3,                  1),
            ('Pano de Microfibra Verde',                               'Pano de alta absorção codificado por cor para áreas de nutrição/cozinha.',                  5,                 96,               8,                  1),
            ('Receituário Médico Padrão (Bloco)',                      'Bloco impresso para prescrição médica simples de medicamentos não controlados.',            5,                 7,                16,                 1),
            ('Desinfetante para Superfícies 5L',                       'Desinfetante hospitalar de nível intermediário para superfícies fixas.',                    3,                 62,               6,                  1),
            ('Álcool Etílico 70% Líquido 1L',                          'Desinfetante e antisséptico para fricção em superfícies fixas.',                            3,                 62,               11,                 1),
            ('Desincrustante Ácido 5L',                                'Detergente ácido concentrado para remoção de incrustações minerais em pisos.',              3,                 60,               6,                  1),
            ('Detergente Enzimático 5L',                               'Detergente com quatro enzimas para remoção de matéria orgânica em instrumentais.',          3,                 60,               6,                  1),
            ('Avental Camisola Hospitalar Tamanho G',                  'Vestuário descartável para paciente em internação ou exames clínicos.',                     4,                 24,               3,                  1),
            ('Pano de Microfibra Azul',                                'Pano de alta absorção codificado por cor para limpeza geral de mobiliário.',                5,                 96,               8,                  1),
            ('Pano de Microfibra Vermelho',                            'Pano de alta absorção codificado por cor para áreas de alto risco (sanitários).',           5,                 96,               8,                  1),
            ('Papel Sulfite A4 75g',                                   'Papel multiuso para impressão de laudos, receitas e relatórios clínicos.',                  5,                 7,                8,                  1),
            ('Mop Flat',                                               'Equipamento ergonômico completo para aplicação de saneantes e limpeza úmida.',              5,                 96,               3,                  1),
            ('Detergente Enzimático',                                  'Detergente com formulação enzimática para pré-lavagem de artigos médicos.',                 3,                 60,               11,                 0),
            ('Placa de Sinalização "Piso Molhado"',                    'Item de segurança para sinalização visual de perigo em superfícies escorregadias.',         5,                 96,               3,                  1),
            ('Lixeira com Pedal 50L',                                  'Recipiente plástico reforçado para descarte de resíduos por acionamento de pé.',            5,                 96,               3,                  1),
            ('Papel Toalha Interfolhado',                              'Papel toalha folha dupla gofrado para secagem higiênica das mãos.',                         5,                 11,               8,                  1),
            ('Dispenser de Papel Toalha',                              'Suporte de parede em ABS para acondicionamento e corte de papel toalha.',                   5,                 96,               3,                  1),
            ('Sabonete Líquido Neutro 5L',                             'Sabonete líquido para higienização e remoção de sujidades leves nas mãos.',                 5,                 11,               6,                  1),
            ('Dispenser de Sabonete Líquido',                          'Suporte de parede para dosagem de sabonete líquido ou álcool em gel.',                      5,                 96,               3,                  1),
            ('Papel Higiênico Rolão 300m',                             'Papel higiênico folha simples de alta metragem para dispensers de alto fluxo.',             5,                 11,               8,                  1),
            ('Saco Plástico Hospitalar 100L',                          'Saco plástico reforçado para descarte de resíduos biológicos infectantes.',                 4,                 24,               8,                  1),
            ('Saco de Lixo Branco Hospitalar 50L',                     'Saco plástico para descarte de resíduos infectantes de médio porte.',                       4,                 24,               8,                  1),
            ('Sonda Retal Nº14',                                       'Sonda retal de calibre médio para procedimentos de lavagem ou alívio gástrico.',            4,                 2,                3,                  1),
            ('Caneta Esferográfica (Azul)',                            'Caneta esferográfica para escrita e preenchimento manual de prontuários.',                  5,                 43,               3,                  1),
            ('Caneta Esferográfica (Vermelha)',                        'Caneta esferográfica para alertas visuais e assinaturas institucionais.',                   5,                 43,               3,                  1),
            ('Caneta Esferográfica (Preta)',                           'Caneta esferográfica para preenchimento de prontuários oficiais.',                          5,                 43,               3,                  1),
            ('Lápis Preto Nº 2',                                       'Grafite graduado de escrita macia para rascunhos internos.',                                5,                 43,               3,                  1),
            ('Borracha Branca',                                        'Borracha isenta de látex para correção de escrita a lápis.',                                5,                 43,               3,                  1),
            ('Grampeador de Mesa',                                     'Equipamento mecânico para fixação e união de folhas e relatórios.',                         5,                 43,               3,                  1),
            ('Grampos 26/6 Galvanizados',                              'Grampos metálicos resistentes para suprimento de grampeadores de mesa.',                    5,                 43,               8,                  1),
            ('Clipes para Papel Nº 3/0',                               'Clipes metálicos niquelados para organização temporária de papéis.',                        5,                 43,               8,                  1),
            ('Envelope Pardo Ofício',                                  'Envelope pardo resistente para transporte de documentos internos.',                         5,                 7,                8,                  1),
            ('Toner para Impressora Laser',                            'Insumo de tinta em pó para impressão de laudos e exames em lote.',                          5,                 38,               3,                  0),
            ('Cartucho de Tinta Preto',                                'Insumo de tinta líquida preta para impressoras jato de tinta de recepção.',                 5,                 38,               3,                  0),
            ('Paracetamol 500mg',                                      'Analgésico e antitérmico para alívio de dores leves a moderadas.',                          1,                 29,               1,                  1),
            ('Ibuprofeno 400mg',                                       'Anti-inflamatório não esteroidal (AINE) com ação analgésica oral.',                         1,                 4,                1,                  1),
            ('Amoxicilina 250mg/5mL',                                  'Antibiótico penicilínico de amplo espectro em pó para suspensão oral.',                     1,                 38,               11,                 1),
            ('Omeprazol 40mg',                                         'Inibidor da bomba de prótons para redução da acidez gástrica (cápsulas).',                  1,                 48,               1,                  1),
            ('Sinvastatina 20mg',                                      'Hipolipemiante para controle clínico de níveis de colesterol sérico.',                      1,                 77,               1,                  0),
            ('Losartana Potássica 25mg',                               'Anti-hipertensivo oral para controle de pressão arterial sistêmica.',                       1,                 77,               1,                  1),
            ('Cloridrato de Fluoxetina 10mg',                          'Antidepressivo inibidor seletivo da recaptação de serotonina (ISRS).',                      1,                 35,               1,                  1),
            ('Diazepam 10mg/2mL',                                      'Benzodiazepínico injetável para sedação, ansiedade aguda e crises convulsivas.',            1,                 35,               5,                  1),
            ('Luva de Borracha Tamanho G',                             'Luva de proteção reforçada para manuseio de agentes químicos e umidade.',                   5,                 96,               8,                  1),
            ('Hidrocortisona 500mg',                                   'Corticoide injetável liofilizado de ação rápida para administração EV.',                    1,                 33,               5,                  0),
            ('Gel para Ultrassom 300g',                                'Gel condutor hipoalergênico e solúvel em água para exames de imagem e Doppler.',            4,                 58,               11,                 1),
            ('Pera para ECG',                                          'Pêra de borracha reutilizável para fixação de ventosa de ECG.',                             4,                 58,               3,                  1),
            ('Pilha Alcalina D (Grande)',                              'Fonte de energia alcalina de alta durabilidade para equipamentos pesados.',                 5,                 38,               8,                  1),
            ('Cimetidina 300mg/2mL',                                   'Antagonista dos receptores H2 de histamina injetável para redução de acidez.',              1,                 28,               5,                  1),
            ('Azitromicina 250mg',                                     'Antibiótico macrolídeo de amplo espectro em comprimidos.',                                  1,                 37,               1,                  1),
            ('Cloridrato de Lidocaína 2% com Vasoconstrictor',         'Anestésico local injetável com vasoconstritor para procedimentos cirúrgicos.',              1,                 83,               5,                  1),
            ('Soro Fisiológico 100mL',                                 'Solução isotônica de cloreto de sódio 0,9% para infusão ou irrigação.',                     1,                 89,               21,                 1),
            ('Soro Glicosado 5%',                                      'Solução glicosada a 5% de grande volume para reposição calórica e hidratação.',             1,                 89,               21,                 1),
            ('Cumarina + Troxirrutina',                                'Flebotônico oral indicado para o tratamento de varizes e insuficiência venosa.',            1,                 88,               1,                  1),
            ('Captopril 50mg',                                         'Anti-hipertensivo oral, inibidor da enzima conversora de angiotensina (ECA).',              1,                 77,               1,                  0),
            ('Furosemida 10mg/mL',                                     'Diurético de alça injetável para o tratamento de edema e hipertensão aguda.',               1,                 44,               5,                  1),
            ('Sertralina 100mg',                                       'Antidepressivo oral inibidor seletivo da recaptação de serotonina.',                        1,                 35,               1,                  0),
            ('Lorazepam 1mg',                                          'Ansiolítico e sedativo de tarja preta (Benzodiazepínico).',                                 1,                 35,               1,                  1),
            ('Propranolol 80mg',                                       'Betabloqueador adrenérgico para controle de arritmias e hipertensão arterial.',             1,                 77,               1,                  0),
            ('Pilha AA',                                               'Pilha alcalina AA para alimentação de aparelhos de diagnóstico de mão.',                    5,                 38,               8,                  0),
            ('Pilha AAA',                                              'Pilha alcalina palito AAA para lanternas pupilares e termômetros digitais.',                5,                 38,               8,                  0),
            ('Dipirona Sódica 1g/2ml',                                 'Analgésico e antitérmico injetável de pronta ação para uso EV/IM.',                         1,                 29,               5,                  1),
            ('Isossorbida 10mg',                                       'Vasodilatador coronariano para profilaxia e tratamento da angina de peito.',                1,                 77,               1,                  1),
            ('Complexo B Injetável',                                   'Solução injetável contendo vitaminas do complexo B para reposição metabólica.',             1,                 34,               5,                  1),
            ('Clonazepam Gotas',                                       'Anticonvulsivante e ansiolítico em solução oral de controle especial.',                     1,                 35,               11,                 1),
            ('Metronidazol 40mg/mL',                                   'Antimicrobiano e antiprotozoário em suspensão oral de uso adulto e pediátrico.',            1,                 37,               11,                 1),
            ('Flumazenil Solução Injetável',                           'Antidoto específico para reversão completa dos efeitos sedativos de benzodiazepínicos.',    1,                 46,               5,                  1),
            ('Albendazol 400mg',                                       'Antiparasitário de amplo espectro em dose única mastigável.',                               1,                 50,               1,                  1),
            ('Varfarina Sódica 2.5mg',                                 'Anticoagulante oral indicado para prevenção de acidentes tromboembólicos.',                 1,                 21,               1,                  1),
            ('Tubo Endotraqueal 8,0',                                  'Tubo com balonete (cuff) para manutenção de via aérea e ventilação mecânica.',              4,                 2,                3,                  1),
            ('Hipoclorito 2,5% 5L',                                    'Desinfetante clorado concentrado para desinfecção de superfícies e áreas críticas.',        3,                 62,               6,                  0),
            ('Detergente Neutro para Louças 5L',                       'Detergente líquido neutro de uso geral para limpeza de utensílios de copa.',                3,                 60,               6,                  1),
            ('Luva de Borracha Tamanho M',                             'Luva de proteção em látex reforçado para procedimentos de higienização.',                   5,                 96,               8,                  1),
            ('Saco de Lixo Cinza 40L',                                 'Saco plástico padrão para acondicionamento de resíduos comuns não recicláveis.',            5,                 96,               8,                  1),
            ('Catgut 3.0 com Agulha',                                  'Fio cirúrgico absorvível de origem animal montado com agulha para suturas internas.',       4,                 2,                25,                 1),
            ('Catgut 4.0 com Agulha',                                  'Fio cirúrgico absorvível de menor calibre para suturas internas delicadas.',                4,                 2,                25,                 1),
            ('Sonda Aspiração Traqueal c/ V Nº6',                      'Sonda flexível transparente com válvula de controle para aspiração de secreções.',          4,                 2,                3,                  1),
            ('Sonda Foley 2 Vias Nº20',                                'Sonda vesical de demora em látex para drenagem contínua de urina.',                         4,                 2,                3,                  0),
            ('Clorexidina Aquosa 1% 1L',                               'Antisséptico de base aquosa indicado para antissepsia de peles delicadas e mucosas.',       1,                 74,               11,                 1),
            ('Clorexidina Degermante 2% 1L',                           'Antisséptico com tensoativos para lavagem antisséptica das mãos e campo cirúrgico.',        1,                 74,               11,                 1),
            ('Esparadrapo 10cm',                                       'Fita adesiva tradicional de alta fixação para proteção de curativos.',                      4,                 36,               23,                 1),
            ('Nebulizador',                                            'Aparelho compressor pneumático para administração de medicamentos inalatórios.',            4,                 91,               3,                  0),
            ('Flanela Laranja',                                        'Pano de algodão macio para limpeza a seco e polimento de mobiliários.',                     5,                 96,               3,                  1),
            ('Sabonete Neutro',                                        'Sabonete neutro hipoalergênico para higiene pessoal e lavagem de mãos.',                    5,                 11,               3,                  1),
            ('Abocath Nº18',                                           'Cateter intravenoso periférico de calibre intermediário para hidratação/medicação.',        4,                 2,                3,                  1),
            ('Oxímetro de Pulso Infantil Display LED',                 'Dispositivo médico portátil calibrado para monitorização de SpO2 em pediatria.',            4,                 91,               3,                  1),
            ('Aparelho de Glicemia',                                   'Monitor portátil (glicosímetro) para medição quantitativa da glicose capilar.',             4,                 91,               3,                  1),
            ('Agulha Descartável 40 x 12',                             'Agulha hipodérmica de grande calibre (rosa) para aspiração de medicamentos.',               4,                 2,                25,                 1),
            ('Agulha para Caneta de Insulina 4mm',                     'Agulha ativa siliconada de comprimento curto para aplicação subcutânea de insulina.',       4,                 2,                25,                 1),
            ('Luva Estéril Nº8,5',                                     'Luva cirúrgica de látex estéril e lubrificada para procedimentos cirúrgicos.',              4,                 24,               8,                  1),
            ('Otoscópio',                                              'Equipamento médico portátil com iluminação direta para exames do canal auditivo.',          4,                 91,               3,                  1),
            ('Nebulizador tipo Copinho',                               'Kit de micronebulização descartável completo para conexão em rede de oxigênio.',            4,                 2,                3,                  0),
            ('Máscara Respiratória PFF2 Sem Válvula',                  'Respirador descartável de eficiência filtrante contra aerossóis e patógenos.',              4,                 24,               3,                  1),
            ('Sonda Nasogástrica Longa Nº14',                          'Sonda de poliuretano/pvc para descompressão gástrica ou introdução de dietas.',             4,                 2,                3,                  1),
            ('Tubo Cirúrgico Silicone',                                'Tubo flexível de silicone grau médico para drenos ou condução de fluidos.',                 4,                 2,                3,                  1),
            ('Sapatilha Cirúrgica Estéril (Propé)',                    'Sapatilha descartável em TNT antiderrapante para uso em áreas restritas.',                  4,                 24,               8,                  1),
            ('Luva Nitrílica Procedimento G',                          'Luva de procedimento nitrílica livre de pó, ideal para alérgicos ao látex.',                4,                 24,               8,                  1),
            ('Espátula de Ayres c/ 100',                               'Espátula de madeira descartável em embalagem coletiva para exames ginecológicos.',          4,                 65,               14,                 1),
            ('Espéculo Descartável G',                                 'Espéculo vaginal ginecológico descartável em poliestireno cristal tamanho G.',              4,                 65,               3,                  1),
            ('Atadura de Crepe 15cm',                                  'Faixa elástica de algodão para imobilizações leves, fixação e compressão.',                 4,                 36,               23,                 1),
            ('Pano de Chão Grosso',                                    'Pano de algodão alvejado de alta gramatura para higienização pesada de pisos.',             5,                 96,               3,                  1),
            ('Vassoura de Piaçava',                                    'Vassoura com cerdas naturais de piaçava para varrição de áreas externas.',                  5,                 96,               3,                  0),
            ('Pá de Lixo com Cabo',                                    'Pá plástica coletora com cabo longo ergonômico para resíduos operacionais.',                5,                 96,               3,                  0),
            ('Álcool em Gel 70% 5L',                                   'Higienizador antisséptico de mãos em gel para reabastecimento de dispensers.',              5,                 11,               6,                  1),
            ('Avental Impermeável de PVC',                             'EPI impermeável em PVC para proteção do tronco em áreas de expurgo ou lavanderia.',         5,                 96,               3,                  1),
            ('Formulário de Relatório de Enfermagem (Bloco)',          'Bloco de papel impresso padronizado para anotações de plantão da enfermagem.',              5,                 7,                16,                 1),
            ('Porta Canetas de Mesa (Acrílico)',                       'Organizador de mesa em acrílico para canetas e materiais administrativos.',                 5,                 43,               3,                  1),
            ('Tesoura de Escritório Grande',                           'Tesoura multiuso de ponta fina para corte de papéis e envelopes de mesa.',                  5,                 43,               3,                  1),
            ('Fita Dupla Face',                                        'Fita adesiva dupla face para fixação de quadros de avisos e cartazes.',                     5,                 43,               23,                 1),
            ('Alvejante Clorado 5L',                                   'Agente clorado concentrado para desinfecção pesada de pisos e superfícies.',                3,                 62,               6,                  1),
            ('Bolsa Coletora de Urina Sistema Fechado',                'Sistema estéril fechado com válvula antirreflexo para drenagem urinária.',                  4,                 2,                3,                  1),
            ('Lâmina Bisturi Nº11',                                    'Lâmina cirúrgica descartável em aço carbono de alta precisão para punções.',                4,                 2,                8,                  1),
            ('Bota de Unna',                                           'Bandagem flexível impregnada com pasta de óxido de zinco para terapia vascular.',           4,                 36,               23,                 1),
            ('Kit Papanicolau Tamanho P',                              'Kit ginecológico estéril contendo espéculo P, escova e espátula para coleta.',              4,                 2,                3,                  1),
            ('Kit Sondagem Vesical Estéril',                           'Conjunto cirúrgico completo com campos, pinças e cubas para cateterismo urinário.',         4,                 2,                3,                  1),
            ('Solução Degermante PVPI 10% 1L',                         'Antisséptico de uso tópico com tensoativos à base de polivinilpirrolidona iodo.',           1,                 74,               11,                 1),
            ('Abocath Nº18 com Dispositivo de Segurança',              'Cateter venoso periférico com acionamento de segurança ativo pós-punção.',                  4,                 2,                3,                  1),
            ('Sonda Nasogástrica Longa Nº06',                          'Sonda gástrica flexível de fino calibre em PVC para descompressão ou lavagem.',             4,                 2,                3,                  1),
            ('Luva Estéril Nº7,0',                                     'Luva cirúrgica estéril confeccionada em látex natural texturizado tamanho 7,0.',            4,                 24,               8,                  1),
            ('Sonda Nasogástrica Longa Nº16',                          'Sonda de alto calibre para drenagem ou lavagem gástrica de urgência.',                      4,                 2,                3,                  1),
            ('Saco para Lixo Hospitalar Vermelho 100L',                'Saco plástico reforçado para descarte de resíduos biológicos com risco específico.',        4,                 24,               8,                  1),
            ('Descarpak 7 Litros',                                     'Coletor rígido de papelão ondulado blindado para descarte de perfurocortantes 7L.',         4,                 24,               3,                  1),
            ('Curativo Antimicrobiano 3 Camadas',                      'Curativo cirúrgico multicamadas estéril impregnado com agente antimicrobiano.',             4,                 36,               3,                  1),
            ('Coletor Descartável Perfurocortante 3L',                 'Coletor rígido plástico/papelão para descarte seguro de agulhas e bisturis.',               4,                 24,               3,                  0),
            ('Teste de Gravidez Tira',                                 'Tira reagente para detecção rápida e qualitativa de hCG na urina.',                         4,                 2,                8,                  1),
            ('Luva Vinil Procedimento G',                              'Luva de procedimento em vinil livre de pó, indicada para exames leves.',                    4,                 24,               8,                  1),
            ('Toalha de Banho',                                        'Toalha de banho em felpa de algodão para higienização de leito de pacientes.',              4,                 24,               3,                  1),
            ('Jaleco de TNT Descartável',                              'Avental cirúrgico/visitante em TNT de mangas longas com punho elástico.',                   4,                 24,               3,                  1),
            ('Abocath Nº16',                                           'Cateter intravenoso periférico calibroso para infusão rápida de fluidos ou sangue.',        4,                 2,                3,                  1),
            ('Sonda Foley Nº18 3 Vias',                                'Sonda vesical de demora em látex siliconado com via adicional de irrigação.',               4,                 2,                3,                  1),
            ('Sabão em Pó Industrial 25kg',                            'Detergente em pó alcalino concentrado para lavagem pesada de enxovais sanitários.',         3,                 60,               10,                 1),
            ('Calçados de Segurança Antiderrapantes',                  'Sapato de segurança profissional em EVA impermeável com solado antiderrapante.',            5,                 96,               3,                  1),
            ('Botas de Borracha',                                      'Bota de PVC impermeável cano longo para higienização de áreas externas e expurgos.',        5,                 96,               3,                  1),
            ('Pasta Arquivo Morto (Papelão)',                          'Caixa organizadora em papelão ondulado para armazenamento de prontuários antigos.',         5,                 7,                19,                 1),
            ('Sonda Aspiração Traqueal c/ V Nº14',                     'Sonda flexível calibrosa com válvula reguladora para remoção de secreções aéreas.',         4,                 2,                3,                  1),
            ('Sonda Nasoenteral 12Fr',                                 'Sonda radiopaca de poliuretano com guia metálico para nutrição enteral de longa.',          4,                 2,                3,                  1),
            ('Luva Estéril Nº6,5',                                     'Luva cirúrgica estéril confeccionada em látex natural texturizado tamanho 6,5.',            4,                 24,               8,                  1),
            ('Cateter de Oxigênio Adulto Tipo Óculos',                 'Extensão nasal em PVC macio para administração de oxigenoterapia de baixo fluxo.',          4,                 2,                3,                  1),
            ('Cânula de Guedel Nº3',                                   'Dispositivo orofaríngeo rígido para manter a via aérea pérvia em adultos.',                 4,                 2,                3,                  1),
            ('Detergente Desincrustante Ácido 5L',                     'Detergente ácido de alta performance para remoção de resíduos calcários e minerais.',       3,                 60,               6,                  1),
            ('Limpa Vidros Concentrado 5L',                            'Solução concentrada química de alto brilho para vidros, telas e divisórias.',               3,                 60,               6,                  1),
            ('Lâmina para Microscopia',                                'Lâmina de vidro polido com borda fosca para fixação de lâminas laboratoriais.',             4,                 2,                8,                  1),
            ('Cânula de Guedel Nº2',                                   'Dispositivo orofaríngeo rígido indicado para ventilação assistida em adolescentes.',        4,                 2,                3,                  1),
            ('Saco de Lixo Transparente 40L',                          'Saco plástico translúcido para descarte seletivo e triagem de recicláveis.',                5,                 96,               8,                  1),
            ('Avental Camisola Hospitalar Tamanho GG',                 'Avental/camisola em tecido descartável ou algodão leve para exames clínicos GG.',           4,                 24,               3,                  1),
            ('Curativo Transparente 10x10cm',                          'Filme de poliuretano transparente adesivo e estéril para fixação de cateteres.',            4,                 36,               8,                  1),
            ('Caneta para Aplicação de Insulina 3ml',                  'Caneta injetora mecânica reutilizável para cartuchos de insulina de 3ml.',                  4,                 2,                3,                  1),
            ('Haste Flexível Algodão c/100',                           'Hastes plásticas com pontas de algodão para higiene local e swabs.',                        4,                 24,               14,                 1),
            ('Sonda Uretral Nº12',                                     'Sonda de alívio uretral em PVC transparente de calibre intermediário.',                     4,                 2,                3,                  1),
            ('Sonda Uretral Nº08',                                     'Sonda de alívio uretral em PVC flexível de fino calibre para cateterismo.',                 4,                 2,                3,                  1),
            ('Absorvente Higiênico c/ 8',                              'Absorvente descartável indicado para uso ginecológico ou pós-parto imediato.',              5,                 11,               10,                 1),
            ('Copo Descartável para Água',                             'Copo descartável confeccionado em poliestireno transparente de 200ml.',                     5,                 31,               10,                 1),
            ('Aparelho de Barbear Descartável',                        'Lâmina descartável indicada para tricotomia pré-operatória e higiene corporal.',            5,                 11,               3,                  1),
            ('Almotolia',                                              'Frasco plástico graduado indicado para acondicionamento de antissépticos líquidos.',        4,                 2,                3,                  1),
            ('Lenço de Papel Caixa c/50',                              'Lenços de papel descartáveis de folha dupla para higiene e cuidados gerais.',               5,                 11,               8,                  1),
            ('Abocath Nº14',                                           'Cateter intravenoso periférico calibroso para infusões de grande volume.',                  4,                 2,                3,                  1),
            ('Abocath Nº20 com Dispositivo de Segurança',              'Cateter intravenoso com barreira de proteção ativa contra acidentes biológicos.',           4,                 2,                3,                  1),
            ('Scalp 19',                                               'Dispositivo de agulha tipo borboleta para infusão ou coleta venosa.',                       4,                 2,                3,                  1),
            ('Cânula de Guedel Nº0',                                   'Cânula orofaríngea rígida para desobstrução mecânica de vias aéreas.',                      4,                 2,                3,                  1),
            ('Cânula de Guedel Nº1',                                   'Cânula orofaríngea para manejo e ventilação mecânica assistida.',                           4,                 2,                3,                  1),
            ('Scalp 21',                                               'Dispositivo de fixação borboleta com agulha para venóclise de médio calibre.',              4,                 2,                3,                  1),
            ('Cânula de Guedel Nº5',                                   'Cânula orofaríngea rígida indicada para manutenção da via aérea em adultos.',               4,                 2,                3,                  0),
            ('Scalp 25',                                               'Dispositivo de infusão de fino calibre para redes venosas sensíveis ou pediatria.',         4,                 2,                8,                  1),
            ('Sonda Foley 2 Vias Nº22',                                'Sonda vesical de demora em látex para esvaziamento urinário prolongado.',                   4,                 2,                3,                  1),
            ('Sonda Aspiração Traqueal s/ V Nº8',                      'Sonda flexível de alívio para remoção de secreções respiratórias sem válvula.',             4,                 2,                3,                  1),
            ('Sonda Aspiração Traqueal c/ V Nº4',                      'Sonda de aspiração infantil de fino calibre com controle de sucção por válvula.',           4,                 2,                3,                  1),
            ('Sonda Foley 3 Vias Nº16',                                'Sonda vesical de demora com via adicional para irrigação contínua da bexiga.',              4,                 2,                3,                  1),
            ('Sonda Aspiração Traqueal c/ V Nº10',                     'Sonda flexível com válvula reguladora para aspiração traqueal profunda.',                   4,                 2,                3,                  1),
            ('Sonda Foley 3 Vias Nº22',                                'Sonda vesical tripla indicada para irrigação pós-operatória e drenagem de coágulos.',       4,                 2,                3,                  1),
            ('Sonda Foley 3 Vias Nº24',                                'Sonda de grande calibre para irrigação contínua de vias urinárias baixas.',                 4,                 2,                3,                  0),
            ('Sonda Nasogástrica Longa Nº04',                          'Sonda de descompressão ou alimentação gástrica em PVC flexível de fino calibre.',           4,                 2,                3,                  1),
            ('Sonda Retal Nº28',                                       'Sonda para drenagem e lavagem de efluentes no trato retal inferior.',                       4,                 2,                3,                  0),
            ('Sonda Retal Nº10',                                       'Sonda retal flexível para drenagem e eliminação de gases ou flatus.',                       4,                 2,                3,                  1),
            ('Sonda Retal Nº12',                                       'Sonda de médio calibre indicada para procedimentos de enema ou lavagem intestinal.',        4,                 2,                3,                  1),
            ('Sonda Nasogástrica Longa Nº20',                          'Sonda de grande calibre para aspiração de resíduos ou lavagens gástricas de urgência.',     4,                 2,                3,                  1),
            ('Sonda Retal Nº30',                                       'Sonda retal calibrosa para descompressão ou administração de lavagens intestinais.',        4,                 2,                3,                  1),
            ('Sonda Uretral Nº04',                                     'Sonda de alívio em PVC para cateterismo urinário intermitente de fino calibre.',            4,                 2,                3,                  0),
            ('Sonda Uretral Nº10',                                     'Sonda de alívio uretral estéril para esvaziamento vesical imediato.',                       4,                 2,                3,                  1),
            ('Sonda Nasogástrica Longa Nº22',                          'Sonda gástrica calibrosa em PVC para descompressão e drenagem de estase.',                  4,                 2,                3,                  0),
            ('Sonda Uretral Nº14',                                     'Sonda de alívio uretral de médio calibre para coleta de urina asséptica.',                  4,                 2,                3,                  1),
            ('Luva Nitrílica Procedimento M',                          'Luva de procedimento em nitrilo, livre de látex, cor azul tamanho M.',                      4,                 24,               8,                  1),
            ('Luva Nitrílica Procedimento P',                          'Luva de procedimento em nitrilo, excelente barreira química tamanho P.',                    4,                 24,               8,                  1),
            ('Luva Vinil Procedimento P',                              'Luva de vinil hipoalergênica para procedimentos gerais não cirúrgicos P.',                  4,                 24,               8,                  1),
            ('Caneta Extra Fina para ECG',                             'Marcador permanente técnico com ponta extra fina para traçados de exames de ECG.',          5,                 43,               3,                  1),
            ('Luva Extra Pequena Látex',                               'Luva de procedimento em látex natural texturizada tamanho XP.',                             4,                 24,               8,                  0),
            ('Bateria CR2032 (Moeda)',                                 'Bateria botão de lítio 3V para alimentação de glicosímetros portáteis.',                    5,                 38,               3,                  1),
            ('Bateria LR41 (Botão)',                                   'Bateria botão alcalina para termômetros digitais e pequenos dispositivos.',                 5,                 38,               3,                  1),
            ('Espéculo Descartável M',                                 'Espéculo vaginal descartável em poliestireno cristal tamanho M.',                           4,                 2,                3,                  1),
            ('Espéculo Descartável P',                                 'Espéculo vaginal descartável em poliestireno cristal tamanho P.',                           4,                 2,                3,                  1),
            ('Kit Papanicolau Tamanho G',                              'Kit ginecológico estéril completo com espéculo G para coleta de citologia.',                4,                 2,                3,                  1),
            ('Kit Papanicolau Tamanho M',                              'Kit ginecológico estéril completo com espéculo M para exames citopatológicos.',             4,                 2,                3,                  1),
            ('Lâmpada LED 12V/50W',                                    'Lâmpada halógena/LED de reposição para focos cirúrgicos e auxiliares.',                     5,                 63,               3,                  0),
            ('Lanterna Clínica',                                       'Lanterna de alta intensidade portátil para avaliações pupilares e diagnóstico.',            5,                 63,               3,                  1),
            ('Papel Grau Cirúrgico 10cm',                              'Rolo de papel grau cirúrgico 10cm x 100m para esterilização térmica.',                      4,                 78,               23,                 1),
            ('Papel Grau Cirúrgico 15cm',                              'Rolo de papel grau cirúrgico 15cm x 100m para processos de autoclave.',                     4,                 78,               23,                 1),
            ('Papel Termo 110mm x 20m Vídeo Print',                    'Bobina térmica de alta definição para impressão de imagens de ultrassom.',                  4,                 46,               23,                 1),
            ('Papel Termossensível ECG 80mm x 20m',                    'Bobina de papel termossensível para registro de eletrocardiogramas contínuos.',             4,                 46,               23,                 1),
            ('Papel Termossensível Cardiotógrafo 150x90x150',          'Papel termosensível sanfonado para exames de cardiotocografia fetal.',                      4,                 46,               27,                 1),
            ('Pilha Alcalina C (Média)',                               'Pilha alcalina média C de longa duração para equipamentos portáteis de saúde.',             5,                 38,               3,                  1),
            ('Polifix 2 Vias',                                         'Extensor de linhas intravenosas multivias com clamp corta-fluxo.',                          4,                 2,                3,                  1),
            ('Termo Higrômetro',                                       'Aparelho digital para monitoramento térmico e de umidade em estoques de medicamentos.',     4,                 91,               3,                  0),
            ('Torneira 3 Vias',                                        'Válvula de três vias para direcionamento e controle de infusões intravenosas.',             4,                 2,                3,                  1),
            ('Tubo Endotraqueal 6,5',                                  'Tubo endotraqueal com balão em PVC para ventilação mecânica calibre 6,5mm.',                4,                 2,                3,                  1),
            ('Tubo Endotraqueal 7,0',                                  'Tubo endotraqueal com balonete para intubação e manejo de vias aéreas 7,0mm.',              4,                 2,                3,                  1),
            ('Equipo Macrogotas com Injetor Lateral',                  'Dispositivo para administração de soluções endovenosas por gravidade macrogotas.',          4,                 2,                3,                  1),
            ('Equipo Microgotas com Látex',                            'Equipo estéril microgotas com injetor em látex para infusões pediátricas ou precisas.',     4,                 2,                3,                  1),
            ('Fita Adesiva Branca',                                    'Fita adesiva de papel crepe branca para identificações gerais de laboratório.',             5,                 43,               23,                 1),
            ('Fralda Geriátrica Descartável Tamanho M c/30',           'Fralda geriátrica descartável anatômica indicada para incontinência severa M.',             9,                 86,               18,                 1),
            ('Larvicida Granulado para Controle de Vetores 1kg',       'Larvicida químico granulado indicado para eliminação de focos de Aedes aegypti.',           3,                 33,               42,                 1),
            ('Inseticida de Efeito Residual Fludora Co-Max',           'Inseticida concentrado para borrifamento intra-domiciliar de combate à malária/dengue.',    3,                 33,               20,                 1),
            ('Larvicida Biológico Técnico BTI',                        'Inseticida biológico líquido à base de Bacillus thuringiensis israelensis.',                3,                 33,               56,                 1),
            ('Vacina Pentavalente Injetável',                          'Vacina adsorvida difteria, tétano, coqueluche, hepatite B e Hib (rotina pediátrica).',      6,                 88,               21,                 1),
            ('Soro Anticrotálico Injetável',                           'Soroterapia homóloga indicada para neutralização de veneno de cascavel.',                   6,                 18,               21,                 1),
            ('Vacina Meningocócica C Conjugada',                       'Imunobiológico contra doença invasiva causada por Neisseria meningitidis do sorogrupo C.',  6,                 88,               21,                 1),
            ('Fralda Geriátrica Descartável Tamanho G c/30',           'Fralda descartável com barreiras antivazamento para pacientes acamados tamanho G.',         9,                 86,               18,                 1),
            ('Fralda Geriátrica Descartável Tamanho EG c/26',          'Fralda geriátrica descartável com alto poder de absorção tamanho extra grande.',            9,                 86,               18,                 1),
            ('Álcool Gel Antisséptico 70% 500ml',                      'Saneante para antissepsia das mãos com bomba dosadora para postos de saúde.',               8,                 11,               20,                 1),
            ('Shampoo Neutro Infantil Hospitalar 200ml',               'Shampoo suave hipoalergênico para higiene de pacientes pediátricos internados.',            9,                 11,               20,                 1),
            ('Suplemento Alimentar Hipercalórico Pó 400g',             'Fórmula nutricional em pó para recuperação de estado nutricional de idosos.',               16,                98,               50,                 1),
            ('Fórmula Infantil para Lactentes com Proteína Ext.',      'Fórmula infantil à base de proteína extensamente hidrolisada para alergias (APLV).',        16,                98,               50,                 1),
            ('Módulo de Carboidrato Maltodextrina 400g',               'Módulo de energia à base de carboidratos complexos purificados em pó.',                     16,                98,               50,                 1),
            ('Avental Impermeável Manga Longa 50g',                    'Avental de proteção em TNT com barreira laminada impermeável para expurgo.',                17,                24,               10,                 1),
            ('Anestésico Odontológico Lidocaína 2% c/ Epinefrina',     'Solução injetável odontológica estéril em tubetes de vidro 1,8ml.',                         12,                81,               12,                 1),
            ('Soro Antiaracnídico Trivalente',                         'Imunoglobulina heteróloga contra veneno de aranhas armadeira, marrom e escorpião.',         6,                 18,               21,                 1),
            ('Luva Extra Pequena Látex Reprovada',                     'Lote de luva de procedimento com alta taxa de furos durante o recebimento.',                4,                 24,               8,                  0),
            ('Anestésico Odontológico Mepivacaína 3% s/ Vasoconstr.',  'Cartuchos odontológicos de mepivacaína sem vaso para pacientes cardiopatas.',               12,                81,               12,                 1),
            ('Solução de Clorexidina 0,12% Antisséptico Bucal',        'Antisséptico bucal sem álcool para procedimentos odontológicos e pré-cirúrgicos.',          12,                70,               20,                 1),
            ('Indicador Químico Integrador Tipo 5',                    'Tiras de teste integradoras químicas internas para controle de ciclos de autoclave.',       4,                 76,               15,                 1),
            ('Fita Adesiva Indicadora de Vapor Autoclave',             'Fita adesiva termossensível para identificação visual de pacotes esterilizados.',           4,                 76,               43,                 1),
            ('Cilindro de Oxigênio Medicinal 1m³ (Páscoa)',            'Cilindro de oxigênio gasoso comprimido portátil para transporte de pacientes.',             19,                32,               6,                  1),
            ('Cilindro de Oxigênio Medicinal 7m³',                     'Cilindro de grande porte para backup de rede de gases e postos de saúde isolados.',         19,                32,               6,                  1),
            ('Bolsa para Coleta de Sangue Tripla',                     'Bolsa plástica estéril com anticoagulante CPDA-1 para processamento de sangue.',            20,                47,               39,                 1),
            ('Óculos de Proteção Contra Respingos',                    'Óculos de segurança com lentes de policarbonato e proteção lateral antiembaçante.',         17,                24,               6,                  1),
            ('Protetor Auricular Tipo Plug Silicone',                  'EPI para operadores de empilhadeira e separadores em áreas de alta ruidose no CD.',         17,                54,               35,                 1),
            ('Kit Teste Rápido Sífilis c/ 25',                         'Kit de diagnóstico rápido in vitro para detecção de anticorpos contra Treponema.',          20,                58,               46,                 1),
            ('Tubo de Coleta de Sangue Vácuo Gel Ativador 5ml',        'Tubo sorológico com ativador de coágulo e gel separador para análises clínicas.',           20,                47,               14,                 1),
            ('Ranitidina Cloridrato 150mg [SUSPENSO]',                 'Antiulceroso com recolhimento determinado devido a impurezas nitrosaminas.',                1,                 48,               1,                  0),
            ('Lanceta de Segurança Retrátil 21G',                      'Lanceta com acionamento automático por pressão para coleta de sangue capilar.',             20,                47,               14,                 1),
            ('Bolsa de Colostomia Drenável Porosa 57mm',               'Bolsa coletora sistema de uma peça para estomias intestinais e urinárias.',                 22,                32,               39,                 1),
            ('Placa Protetora de Pele para Estomia',                   'Placa sintética hidrocoloide indicada para proteção periestoma contra efluentes.',          22,                32,               15,                 1),
            ('Preservativo Masculino de Látex Distribuição SUS',       'Preservativo lubrificado para programas de prevenção de IST/Aids c/ 100.',                  24,                2,                27,                 1),
            ('Folder Informativo Arboviroses (Dengue/Zika)',           'Material gráfico impresso para distribuição em mutirões de combate a endemias.',            24,                2,                18,                 1),
            ('Agulha Gengival Curta 30G',                              'Agulha descartável siliconada para anestesia infiltrativa odontológica.',                   12,                2,                14,                 1),
            ('Diazepam 10mg',                                          'Anticonvulsivante e ansiolítico sujeito a controle especial - Portaria 344 B1.',            1,                 36,               1,                  1),
            ('Clonazepam 2,5mg/mL Solução Oral',                       'Ansiolítico e anticonvulsivante em gotas sujeito a controle especial (B1).',                1,                 45,               31,                 1),
            ('Carbonato de Lítio 300mg',                               'Estabilizador de humor indicado para transtorno afetivo bipolar.',                          1,                 41,               1,                  1),
            ('Fralda Geriátrica Descontinuada Tam G (Marca X)',        'Fralda de lote antigo reprovada pelo controle de qualidade e absorção do CD.',              9,                 87,               18,                 0),
            ('Haloperidol 5mg',                                        'Antipsicótico típico indicado para manejo de esquizofrenia e delírios.',                    1,                 1,                1,                  1),
            ('Fenobarbital 100mg',                                     'Anticonvulsivante e sedativo sujeito a controle especial da Portaria 344.',                 1,                 68,               1,                  1),
            ('Vacina Hepatite B (Recombinante)',                       'Imunobiológico termolábil (2°C a 8°C) indicado para prevenção da Hepatite B.',              6,                 88,               21,                 1),
            ('Insulina Humana NPH 100 UI/mL - 10mL',                   'Agente antidiabético termolábil de ação intermediária para controle glicêmico.',            1,                 64,               20,                 1),
            ('Insulina Humana Regular 100 UI/mL - 3mL',                'Agente antidiabético termolábil de ação rápida para uso endovenoso ou SC.',                 1,                 64,               21,                 1),
            ('Anlodipino Besilato 5mg',                                'Anti-hipertensivo bloqueador dos canais de cálcio para a rede básica.',                     1,                 77,               1,                  1),
            ('Agulha Hipodérmica 13x4,5 [LOTE SUSPENSO]',              'Agulha descartável infantil com desvio de qualidade na fixação do canhão.',                 4,                 2,                14,                 0),
            ('Atenolol 50mg',                                          'Anti-hipertensivo beta-bloqueador cardiosseletivo de rotina.',                              1,                 77,               1,                  1),
            ('Simvastatina 20mg',                                      'Agente hipolipemiante regulador do colesterol de ampla distribuição.',                      1,                 75,               1,                  1),
            ('Metformina Cloridrato 850mg',                            'Antidiabético oral biguanida para o tratamento da diabetes mellitus tipo 2.',               1,                 64,               1,                  1),
            ('Resina Composta Fotopolimerizável A2',                   'Material restaurador odontológico estético em seringa.',                                    12,                2,                34,                 1),
            ('Vacina Campanhas Antigas H1N1 (2019)',                   'Lote de imunobiológico de campanha anterior, recolhido para descarte.',                     6,                 89,               21,                 0),
            ('Fita para Teste de Glicemia Capilar c/ 50',              'Tiras reagentes para monitoramento de glicose em glicosímetros da rede.',                   4,                 58,               45,                 1),
            ('Sabão Líquido Hospitalar Antisséptico 1L',               'Sabonete líquido com clorexidina 2% para higienização das mãos da equipe.',                 8,                 11,               20,                 1),
            ('Clorpromazina 100mg [DESCONTINUADO]',                    'Antipsicótico descontinuado pelo fabricante - Substituído por novas dosagens.',             1,                 1,                1,                  0),
            ('Amoxicilina Pó Suspensão 250mg/5mL [VENCIDO]',           'Antibiótico que atingiu a data de validade no estoque de quarentena de perdas.',            1,                 38,               17,                 0)
      ) AS T (Name, Description, MainCategoryId, SubCategoryId, PackagingTypeId, IsActive)
)

INSERT INTO [dbo].[Products]
            ([Name]
            ,[Description]
            ,[MainCategoryId]
            ,[SubCategoryId]
            ,[PackagingTypeId]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
SELECT
      Name,
      Description,
      MainCategoryId,
      SubCategoryId,
      PackagingTypeId,
      CreatedOn,
      UpdatedOn,
      IsActive
FROM  RandomDates;
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @MinDate DATETIME = '20250102'
DECLARE @MaxDate DATETIME = '20250215'
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @MaxDate)

;WITH RandomDates (
      FacilityId, Scope, Role, IsActive, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, CreatedOn, UpdatedOn
) AS (
      SELECT
            T.FacilityId,
            T.Scope,
            T.Role,
            T.IsActive,
            T.UserName,
            T.NormalizedUserName,
            T.Email,
            T.NormalizedEmail,
            T.EmailConfirmed,
            T.PasswordHash,
            T.SecurityStamp,
            T.ConcurrencyStamp,
            T.PhoneNumber,
            T.PhoneNumberConfirmed,
            T.TwoFactorEnabled,
            T.LockoutEnd,
            T.LockoutEnabled,
            T.AccessFailedCount,

            -- 'CreatedOn'
            DATEADD(SECOND,
                (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
            ) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
                WHEN T.IsActive = 0
                THEN DATEADD(DAY, 1,
                        DATEADD(SECOND,
                            (ABS(CHECKSUM(NEWID())) % 28801) + 28800,
                            CAST(DATEADD(DAY, ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, @MinDate, @MaxDate) + 1), @MinDate) AS DATETIME)
                        )
                    )
                ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
               -- ('FacilityId', 'Scope', 'Role', 'IsActive', 'UserName',                           'NormalizedUserName',                 'Email', 'NormalizedEmail', 'EmailConfirmed', 'PasswordHash',                                                                        'SecurityStamp', 'ConcurrencyStamp', 'PhoneNumber', 'PhoneNumberConfirmed', 'TwoFactorEnabled', 'LockoutEnd', 'LockoutEnabled', 'AccessFailedCount')
               -- (1,             1,       1,      1,         'saude_master',                       'SAUDE_MASTER',                        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEEqeBGF+Rvx70SKaJEf8a7fAWWMLi+icLvnqu5uiLw3uR23FB+X6dxnr0jBGFs2ZnA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (1,             1,       2,      1,         'saude_admin',                        'SAUDE_ADMIN',                         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELrbTaOsjU/nSbwwor8wr2irt9ZJhh26FRn0Fpwse8Yqwc/XQ7B3KR9AAYNPh65/7w==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (1,             1,       3,      1,         'saude_user',                         'SAUDE_USER',                          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDR5p/FDbjAZWg8GmxSkqYBjbxoUS3Pnctb69y51r/JkRQYObcr+A67yTVm6TS9fYA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (1,             1,       3,      0,         'saude2_user',                        'SAUDE2_USER',                         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDR5p/FDbjAZWg8GmxSkqYBjbxoUS3Pnctb69y51r/JkRQYObcr+A67yTVm6TS9fYA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (2,             1,       1,      1,         'dispensario_master',                 'DISPENSARIO_MASTER',                  NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDgZorTwRiBt+jaGuACqXQEaqsge9wX/yUrEAINreRN8HxEAmmgV5j8xtk8hX9P8vg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (2,             1,       2,      1,         'dispensario_admin',                  'DISPENSARIO_ADMIN',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEC3tHi0zyN8zMRirOzKEzXsqx/QRsuPNEazbbdZhvX6Pj+vUpH8MXcxUILtIBw0x2A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (2,             1,       3,      1,         'dispensario_user',                   'DISPENSARIO_USER',                    NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEG3wsZnFjqrLpEEr1riCXtf66MaQiJLlMwrCQw1rTseC4LmTqi6KxGJdnQacQoDs+A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (2,             1,       3,      1,         'dispensario2_user',                  'DISPENSARIO2_USER',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBjwkJTYyjHFP36i76CYr2wgEPioZOiOapk8vnBx2xFh4ez+paR4+7ZTEQo4I2EwMw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (2,             1,       3,      1,         'dispensario3_user',                  'DISPENSARIO3_USER',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBjwkJTYyjHFP36i76CYr2wgEPioZOiOapk8vnBx2xFh4ez+paR4+7ZTEQo4I2EwMw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (2,             1,       3,      0,         'dispensario4_user',                  'DISPENSARIO4_USER',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBjwkJTYyjHFP36i76CYr2wgEPioZOiOapk8vnBx2xFh4ez+paR4+7ZTEQo4I2EwMw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (3,             2,       2,      1,         'enio_vitalli_admin',                 'ENIO_VITALLI_ADMIN',                  NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEN35ulBBEEMdYsGe+Dr7rRhlVJbgreodBOY+cp3TbhMIO6+Wh9QeoW/4JAVZBC+zPg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (3,             2,       3,      1,         'enio_vitalli_user',                  'ENIO_VITALLI_USER',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELbjypAfD7G2SU6v0ZVh9LeedEMh4PTKuFayYudQL3O8qCaPpHuVib7/RBqjqjf8Fw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (4,             2,       2,      1,         'elisa_franchozza_admin',             'ELISA_FRANCHOZZA_ADMIN',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEPH+BChfALUyi+RjRLk2vAb79jj6WM2Qtt3I4uoQwZiI02sRqWaBMq8KhFbWTt2txA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (4,             2,       3,      1,         'elisa_franchozza_user',              'ELISA_FRANCHOZZA_USER',               NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBzVzrKy6v5xX+GjxJG4j3niaI2MTSzkGybeJVeSy95y1vqsnffwrLhNzSFr5BbDLw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (5,             2,       2,      1,         'alto_custo_admin',                   'ALTO_CUSTO_ADMIN',                    NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEGxoWPSzzmuqfXMBV2tJLoT4ZWmAbwfGuBspfSRZEaAUKi7hXKN4sa+LBrEjx4bk0A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (5,             2,       3,      1,         'alto_custo_user',                    'ALTO_CUSTO_USER',                     NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJp1Na9cUFhHrwz7GN+HugdN6761k5rYkS2Of4FgxPF0MywZtueJ7vNvDTg/L0I3ww==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (6,             2,       2,      1,         'samu_admin',                         'SAMU_ADMIN',                          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEGJdbUKsGVD/G7yYWPYb82YDdZ4/ZBxkODzQZp7WcPYtNV/SCHC71uNUxVsoOOp+pA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (6,             2,       3,      1,         'samu_user',                          'SAMU_USER',                           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAaMeanAynQIdnL/lhr1dcSbthu1mah7NhN4k+Ap1pMv5ug4Y1GurFUC7yaAfrmvxA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (7,             2,       2,      1,         'edmundo_ulson_admin',                'EDMUNDO_ULSON_ADMIN',                 NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEMGW9L9w2cJs7rptSIqeSrs7BXLCuUqS6Dht2WDOUcwLMk8rLYHcaFJtgBCstZ/vIQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (7,             2,       3,      1,         'edmundo_ulson_user',                 'EDMUNDO_ULSON_USER',                  NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJlhIrDYynGAjjhdBGXTQFcek1fdNV0UbHjI6N1MYEf5XTjNp+oDcDohNwPZx4QFMw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (8,             2,       2,      1,         'nilton_lollo_admin',                 'NILTON_LOLLO_ADMIN',                  NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEEfenVMhf32yrobWPKimmegSZUvB7/LelT8oyOIQni/irgb053F/Qx7t6RWaX1lyFg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (8,             2,       3,      1,         'nilton_lollo_user',                  'NILTON_LOLLO_USER',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEKhmianNIvwaus1nubY3RL9jBrlgJQPYW72b+9mkhpN3SgbZrg8ME0AMCV22xfRCjw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (9,             2,       2,      1,         'melhor_casa_admin',                  'MELHOR_CASA_ADMIN',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEA6Te8vIUWZnb2Nmx4197fIErzWuMKtxgMe3Mxg3aRHCY3OZDB2oCl+BXbU4UlhwCw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (9,             2,       3,      1,         'melhor_casa_user',                   'MELHOR_CASA_USER',                    NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOrV65A44ugH+d3+fLdNSZkwX0Od4p9J4Fi6Zf+eXEUAl/cc6M9WbTwp11H80G2fQQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (10,            2,       2,      1,         'jose_fiori_admin',                   'JOSE_FIORI_ADMIN',                    NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEFgYqO74PFN+hg3jCnqYThjMqe3q/t1d8vPDj6dHKE6jZ1rlkxS9bLNxbU68/KSzOA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (10,            2,       3,      1,         'jose_fiori_user',                    'JOSE_FIORI_USER',                     NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENc9ihwYOGcD4geaiJ3bKjY4zTiUrqaB5hcGrev/A6RKGtzMqHOg8IJgfyd3ZLey8g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (11,            2,       2,      1,         'caem_nelson_salome_admin',           'CAEM_NELSON_SALOME_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEP42qRqIgquEENAXkhy83LXOxJwd5kIGg0oorANzyAb347P7QJwMh1xcTSFT1Pq7Tg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (11,            2,       3,      1,         'caem_nelson_salome_user',            'CAEM_NELSON_SALOME_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDzFiUC5fF3KrLFPFWQv7LQ0SCSrokUOKjHLFdLpc91E9FNXIu1JL75FRwzns4NvPA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (12,            2,       2,      1,         'agnaldo_bianchini_admin',            'AGNALDO_BIANCHINI_ADMIN',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEHmOJB0MuhFDB2Vo4StmKBn+H5ojOB+6w5uG1nCQdIODwkfmqtGufhK5PVFkLPCMyw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (12,            2,       3,      1,         'agnaldo_bianchini_user',             'AGNALDO_BIANCHINI_USER',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAD/7uqisMnoBWf7noJT6wto/yd/S9sW7fFBvkdcI9yFdzTi/Qtrw1Rh7K2o/d8d6Q==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (13,            2,       2,      1,         'caps_arceu_scanavini_admin',         'CAPS_ARCEU_SCANAVINI_ADMIN',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELf9f+aBTfDYkPem7vkscjqEYgN7zUEHcYHWDRHrYPMdgAhzPI90CSFh3O56oL8eeg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (13,            2,       3,      1,         'caps_arceu_scanavini_user',          'CAPS_ARCEU_SCANAVINI_USER',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEB6dXFwLmGfOXpXkBUXNO1mJVe7iyG29kJJXiMz9kgVYF+8PjdapFQ5/fupEMuCfSA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (14,            2,       2,      1,         'controle_zoonoses_admin',            'CONTROLE_ZOONOSES_ADMIN',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECWPaVYScJtNwx+WBYJJBBXdAwpFtGhZcX9CVBhzYhPot1HBDW+QqMLYQJuGE75kbA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (14,            2,       3,      1,         'controle_zoonoses_user',             'CONTROLE_ZOONOSES_USER',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAf0HS/1Kaakil7wN1pI3Ab9Cp4qAMPyYH1LvETWdxqvoDLmcgZWPGxsMWm1LLMuzw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (15,            2,       2,      0,         'solon_oliveira_admin',               'SOLON_OLIVEIRA_ADMIN',                NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEGqalT3NMD/gcz6fwwS4az3kowlAhzMItmGPx7tUy/DNz8HYrmgllmHCYmy6IFI4NA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (15,            2,       3,      0,         'solon_oliveira_user',                'SOLON_OLIVEIRA_USER',                 NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENIGuS/kKaTVHh9i0b3AMhhcNNVCDgNR291eu/dAtn4Rjy9B1olJxazW4Y6ZARuxuQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (16,            2,       2,      1,         'vigilancia_sanitaria_admin',         'VIGILANCIA_SANITARIA_ADMIN',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEIdW+Sito6knIRmzlirKRSpAdtmLdBzi9i2qyITeOytMlf3LsgxXXAQe1sCQWQ9pBg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (16,            2,       3,      1,         'vigilancia_sanitaria_user',          'VIGILANCIA_SANITARIA_USER',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEIOx/Mt1etL7C2KGBvClIymx2TQ3jE6j44Kzmr2c3t8RqmJFLevY2q9mdnkoFLnUQQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (17,            2,       2,      0,         'unidade_movel_odonto_admin',         'UNIDADE_MOVEL_ODONTO_ADMIN',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEMz17gHOKJOZcll5gvbNde+I19vyRFuveNOIhf/Pe/dZtQcexjn9D0mwNSYqX+VgCg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (17,            2,       3,      0,         'unidade_movel_odonto_user',          'UNIDADE_MOVEL_ODONTO_USER',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECxH7N5T+uef3Sy1UD04gon+576U6aTgIUIwte3Jg6HghWip+JcrTwNBYhvspUstgQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (18,            2,       2,      1,         'vigilancia_epidemiologica_admin',    'VIGILANCIA_EPIDEMIOLOGICA_ADMIN',     NULL,    NULL,              0,               'AQAAAAIAAYagAAAAED7pWOjnRGf09WbltfZvH37rtEj8F1q9m7tPD1Cc2gQonBgUN6L7wBUexLwtR8pm3Q==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (18,            2,       3,      1,         'vigilancia_epidemiologica_user',     'VIGILANCIA_EPIDEMIOLOGICA_USER',      NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEK1Sp7mUn5wLWS0iJlAhlw5vrccaCH0SkfHKCskpltTxIrabnY0R/KyVF0rGTr5PYw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (19,            2,       2,      1,         'osvaldo_devitte_admin',              'OSVALDO_DEVITTE_ADMIN',               NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDMRy7IL8ZrYW4K5ppID9EXcYWF9N0OOL3QGn23PqXRPxEBAT5BPBKE94V8Azj3aSg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (19,            2,       3,      1,         'osvaldo_devitte_user',               'OSVALDO_DEVITTE_USER',                NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECaKEkZdRsQexYC/YpSbqaEDonAZt3H9fZr6agiDO320d7mPPjdwN6ST2/U1OslB+A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (20,            2,       2,      1,         'humberto_junior_admin',              'HUMBERTO_JUNIOR_ADMIN',               NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEClI2cFIDFDYbKW51LNZ4s2W62vO+he6cglzxD12tKVsGhTxit4lPaINk3QfiNJvNA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (20,            2,       3,      1,         'humberto_junior_user',               'HUMBERTO_JUNIOR_USER',                NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEN9Eea+2DZHj8mqLqJeh8ziy+rA538oi8EjVFnlWp8S+Nq+eMMAwcUnXVlC3uUk5tw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (21,            2,       2,      1,         'emerson_mercatelli_admin',           'EMERSON_MERCATELLI_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOfdXxkBREwxS4VMcnhxpeMyQ8uVXSedLnH9cP6ttmGJ1Qa2sRY2YETYbcUsbWy1xA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (21,            2,       3,      1,         'emerson_mercatelli_user',            'EMERSON_MERCATELLI_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEPNk6binzSWicXhphUs4PTTbrEd5M+Z2RPNTPkMwplUZ9nru4soC4TVBMNhxMLxUGQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (22,            2,       2,      0,         'antonio_simoes_pontes_admin',        'ANTONIO_SIMOES_PONTES_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEODC9pjkbtr12UzU80e6S6tcDu50H2rN8mJHzZ8hsRqJ7ocqrA2CMN/ifxQvlx8HZg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (22,            2,       3,      0,         'antonio_simoes_pontes_user',         'ANTONIO_SIMOES_PONTES_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEABNrdHXiBF67z+i+5ScB3d+77dafaLLwJVEVRdOe0yFklmhH4bQvdXLQ2eVgcjGDQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (23,            2,       2,      1,         'antonio_fabricio_admin',             'ANTONIO_FABRICIO_ADMIN',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEIHpwKNvwRCf7r9WRhGcI393VP8LdCaT3C1u9XLRr0L0v+nUK1xlh/6bIMFczRMc4Q==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (23,            2,       3,      1,         'antonio_fabricio_user',              'ANTONIO_FABRICIO_USER',               NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOUdi5vKKcFNHtHpv+xuxccn6XbIlM0f4bXPXzc6M7dK6g4hkPN7GYcmxuKmaYuz5A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (24,            2,       2,      1,         'alberto_franzini_admin',             'ALBERTO_FRANZINI_ADMIN',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBSX80VMHrcffGF/lD/FIzapIygQA8VlscFsMhrMbwoW8vFTjtaG7oiQiD25Wd10aQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (24,            2,       3,      1,         'alberto_franzini_user',              'ALBERTO_FRANZINI_USER',               NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEENCLOPCWQGozKQXxWwV/4jWm2w0TSoVeyedsHSRIvTeO8RHSqcmEIJwWSmN7CIUCQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (25,            2,       2,      0,         'alcides_oliveira_admin',             'ALCIDES_OLIVEIRA_ADMIN',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEImFHsOVLe9HXjlKD8lpFNVUMQ84OAmTin8rriSIJUfqJK6zbUsCiXvpiz7GE239Gg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (25,            2,       3,      0,         'alcides_oliveira_user',              'ALCIDES_OLIVEIRA_USER',               NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOR0CDzLdqB1oipoVmmA/uGKaZx+cPwjyMhd0a84uH/RmpUjoTptdcvaVNXj4oZdLQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (26,            2,       2,      1,         'adalgisa_goncalves_admin',           'ADALGISA_GONCALVES_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEMWTcZxQXqOF498KRCKWrptmx5G6wTxtTp8fJE781jcm1IaA3dL0bxF2fNUiCDY+nA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (26,            2,       3,      1,         'adalgisa_goncalves_user',            'ADALGISA_GONCALVES_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENz3CzLPv0LrC/3ra2Yqt6TMcJFQOswSMTivRlz58kkZnjEqqU+UqZ2fguGXGRnvHw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (27,            2,       2,      0,         'eva_cruz_admin',                     'EVA_CRUZ_ADMIN',                      NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEE88tNQrj3L3StrsdsYNkUtmnYjUX2e1o9lymnQcTz+Wx6cvbMAhfSsK/fbKLqaovA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (27,            2,       3,      0,         'eva_cruz_user',                      'EVA_CRUZ_USER',                       NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECvkeJyFJEtbPOCHVRGocxsAYCzRX5PPI0cbQqcKNGijzdlHvKhFwF/VjADgBSUjog==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (28,            2,       2,      1,         'guerino_bertolini_admin',            'GUERINO_BERTOLINI_ADMIN',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEMLV1vh5IIne6aCnMPp2IEVI/snNvaZMzBVb6FFtsXQ7EwJKGUDwZUzl9P1SqOlwzA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (28,            2,       3,      1,         'guerino_bertolini_user',             'GUERINO_BERTOLINI_USER',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJppkLl/GRLS5dl/LXXkucaQu06igZ0Z4ld8reYzGbsh5C37YFQIJOen5QIzjDC8qQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (29,            2,       2,      1,         'farmacia_processos_admin',           'FARMACIA_PROCESSOS_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDwJmsC1VqzrVIf1um8n4Vy6SxUo7b1tR8A1kc6AUEXzGE84N6kWWw0KYJSgn8sjig==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (29,            2,       3,      1,         'farmacia_processos_user',            'FARMACIA_PROCESSOS_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEINSTaDrCnHzIQP9N58xdfWYgjQpLTF8c+Iz/JaCBEuvTmFsbV4pqFwkFsMX5bvVew==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (30,            2,       2,      1,         'vital_homem_admin',                  'VITAL_HOMEM_ADMIN',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEKk9EilNuzNDgzGVmsp94PZPvoWyQ+aFCQHQicO+UM2hLJ10nS1x52QpYe4rrVuY5g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (30,            2,       3,      1,         'vital_homem_user',                   'VITAL_HOMEM_USER',                    NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEN2gpT/sY3zzBw5GQQFSqVfg52agPIzZuXZ5u9hPUskCPzW45fTB8z7WW/5YnhasaA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (31,            2,       2,      0,         'hospital_covid_admin',               'HOSPITAL_COVID_ADMIN',                NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECz+Pl22l4/rre1So56FAWpbfEjCgEYfGnBfn/mRCsRuBPnOp3hIsqOH/hDT5LCA+A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (31,            2,       3,      0,         'hospital_covid_user',                'HOSPITAL_COVID_USER',                 NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAErhhQdnKP5Xt7vmYDfax4aDWcOnCiUIHYuu8Bx/PGbGgR8/2y3TqnT3htovR7I4A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (32,            2,       2,      1,         'orlando_zaniboni_admin',             'ORLANDO_ZANIBONI_ADMIN',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEFDpcberLid53T0HfYhuHWbFveHVYji9btXDVDb2Hn1zek9w95leEbPtOJc0CY7d7g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (32,            2,       3,      1,         'orlando_zaniboni_user',              'ORLANDO_ZANIBONI_USER',               NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOUxAAQe8qz7IpTKDsEMzjmFmNHDa03/fIsr8ofPGX5XCXaVK5uhvHI7sfxyUALHFg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (33,            2,       2,      0,         'jair_mourao_admin',                  'JAIR_MOURAO_ADMIN',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENYZK47bcJHa3F3ZrmFVA5qeT3aFignT5K5Q+Gjrw6CSRkN2mD5hO8pisg1F1qNnxA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (33,            2,       3,      0,         'jair_mourao_user',                   'JAIR_MOURAO_USER',                    NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEE1y3EoyayrWkljaTpONEAQ3DNcpoQFU1AOQsd2pzlfszIBUztYsdft1vLza5mTmaA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (34,            2,       2,      1,         'francisco_cascelli_admin',           'FRANCISCO_CASCELLI_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELR59iriPH2Y9u6ieExWGekd4/meyB4UFteACXssClmTm2PFSxkyNRuh/Quw/8sIqg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (34,            2,       3,      1,         'francisco_cascelli_user',            'FRANCISCO_CASCELLI_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECTUhYOj17/YWoBf64o5usn1Ns4/SbDzyzJO7IPXJz5RAM7ctLBrRXftoDvqlhs8og==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (35,            2,       2,      1,         'jeronymo_ometto_admin',              'JERONYMO_OMETTO_ADMIN',               NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJ9ZP5f07g/59PIoKfwfNks8AQiI9wCgsxApz8z959wmbapsjDUfZwWa+JGf2lXobw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (35,            2,       3,      1,         'jeronymo_ometto_user',               'JERONYMO_OMETTO_USER',                NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEM2EfzhYjilXQHGJqvyp4LwKH/1CTwVyuj/C/X7OmVUxHkOy74FXoH5cczReqZyouA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (36,            2,       2,      1,         'lucia_meneghetti_admin',             'LUCIA_MENEGHETTI_ADMIN',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEB4QlTnoETLczEyC3f6rJurnUGLMMe2zyzd65cdaEj4K6wp3whfPjjV+Z9K+npVyZQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (36,            2,       3,      1,         'lucia_meneghetti_user',              'LUCIA_MENEGHETTI_USER',               NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEFlAM/TvYVPL1wL9AzSjSZWQLWByuHwV25OEfCuxc3aRGOp17KE3UHWrGB5YXqeHtg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (37,            2,       2,      1,         'madre_carla_admin',                  'MADRE_CARLA_ADMIN',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELE0Cp3ppu4TWByST0/MwjUiXsfkWwgWgh3dBa+23h5pcAwpL10JMErWZytjATIIAA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (37,            2,       3,      1,         'madre_carla_user',                   'MADRE_CARLA_USER',                    NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELixgyLmUk8pcWeB35zJ6URdH40s4dUnE+z8pOBFkNT4a8Krkls8IzZbKnmD1UjhMQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (38,            2,       2,      1,         'narciso_gomes_admin',                'NARCISO_GOMES_ADMIN',                 NULL,    NULL,              0,               'AQAAAAIAAYagAAAAED/RzSL8j2BLAulbZohRGsAF42PS5Co79ptsBoQEicZSod8r79WOJ4vOGYQeicE1kw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (38,            2,       3,      1,         'narciso_gomes_user',                 'NARCISO_GOMES_USER',                  NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAAljIl8WD1wCJrPU9ggK9SJMir3rIs7ziWm+ib0nGeTTLHctDUxxsQhsJP8tTdlAg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (39,            2,       2,      1,         'ophelia_pesse_admin',                'OPHELIA_PESSE_ADMIN',                 NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAupG/M5XDxWL1ZQz9iTVXo2d1rdpYFc7qGSGs2Hj4oToURMWiTn24hZGCQq9dyemw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (39,            2,       3,      1,         'ophelia_pesse_user',                 'OPHELIA_PESSE_USER',                  NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBYgz9F2D5oSeziduOA7VxLPOPM36ODwTXV72tYdBx+XquGxnCXjySjQS9IJgHJ9Eg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (40,            2,       2,      1,         'otavio_breda_admin',                 'OTAVIO_BREDA_ADMIN',                  NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEFG98BeYflT5UoFzApJnS023phmn0mwsjPO0jnHzdXwOUUccrdYYW6Bw+GfPhvoGRw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (40,            2,       3,      1,         'otavio_breda_user',                  'OTAVIO_BREDA_USER',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENUUW4gdhEh7DJKw0fH6w7watwT1r+X1D/pZZ/9K6c5P2ck1UD0yH7S/zJPhO874OA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (41,            2,       2,      1,         'fermin_vianna_admin',                'FERMIN_VIANNA_ADMIN',                 NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEO5rFlb9O36UeV47+o7FEMqEuUTPul4GjTvxX/C74ZE3W6App72LcByovi8ZOV+0hQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (41,            2,       3,      1,         'fermin_vianna_user',                 'FERMIN_VIANNA_USER',                  NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEKO151w7ySdteP1tmaOhm4Jta0t0SeJMjl5co/nsIlXunQV96fbTVZp5L+JNGQLodw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (42,            2,       2,      1,         'bento_feres_admin',                  'BENTO_FERES_ADMIN',                   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELLDPpeir15UlZ7KBj/6uZ+fNH7/3Z2wr1MQwov43LqVZupc3Rrzx6r7wngRlFSILA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (42,            2,       3,      1,         'bento_feres_user',                   'BENTO_FERES_USER',                    NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEEi+G8YlbQdC3/xi9mu7tH3WjhCEHxWcanVMUdQHE3S9cNdwkyavw4bxABqlbr24tw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (43,            2,       2,      1,         'antonio_pontes_admin',               'ANTONIO_PONTES_ADMIN',                NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEEyA0fjr2Lrnak2Nc47q/Aiw4LfUCInSswQeSGmfrnBOMj6+fG/7FCJbedUNpCWqhA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (43,            2,       3,      1,         'antonio_pontes_user',                'ANTONIO_PONTES_USER',                 NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENAIaJfu5jYakIAn9uEnvZWSPg19LTQL1ias/5/qXJERqFmBN7MSrw2+GTn1X4sbaw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (44,            2,       2,      0,         'solon_oliveira_odonto_admin',        'SOLON_OLIVEIRA_ODONTO_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEIbkGLpMG3FRXXPfXKoAueuJFaBL3Wv1IIXghVw2RBVr+WR7CFxc/y0RDod2/IozqA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (44,            2,       3,      0,         'solon_oliveira_odonto_user',         'SOLON_OLIVEIRA_ODONTO_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEMWPpTQG49O+LAPXAO0K4x+mdY7Zd6CaBlhsdjRus0Yfvb3odB+7VQc8aUygKCWNtQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (45,            2,       2,      0,         'irma_diva_patarra_admin',            'IRMA_DIVA_PATARRA_ADMIN',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJJTLGbNwf1KwHn6xsN7VAUCxZpGfU7qj/tO+AG6ae2KCd08PfIV2fYpKxBizPcfvQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (45,            2,       3,      0,         'irma_diva_patarra_user',             'IRMA_DIVA_PATARRA_USER',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEINH+fq2L/Q1ScuW8WzDnHfk/3qDeu6cEEwQhopFG58xPVOBUUpkSt3BOhoE9XBc7A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (46,            2,       2,      1,         'centro_infantil_hercio_admin',       'CENTRO_INFANTIL_HERCIO_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEP2KLrwFKJqC5q2q3va/1RyuO0TFVGFu8JIr+E6EsEDj/4LPVigo0cBBu5LVLIKd2w==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (46,            2,       3,      1,         'centro_infantil_hercio_user',        'CENTRO_INFANTIL_HERCIO_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECTaMb56SFZmN0I7QuMxLcc7BiYi3fy3wX3cfSykG0xDFHJmMGU6BvMzRFBnU3/6CQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (47,            2,       2,      1,         'rosa_teixeira_admin',                'ROSA_TEIXEIRA_ADMIN',                 NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEF6e7kCt1IXrF6uppR2lJ0QC1m/CiNk153AiSE0auMN2FIzdaBsJWye8EhMLEsN+cw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (47,            2,       3,      1,         'rosa_teixeira_user',                 'ROSA_TEIXEIRA_USER',                  NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEB7l0HdYOx0719/TzgHZSi/MSiXO50r+wsGPAOXv2LeY9KUtUaNvPmdRvumn3ZcHnA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (48,            2,       2,      1,         'jandira_duarte_admin',               'JANDIRA_DUARTE_ADMIN',                NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEE9rhH8Qet7DtebCZuqY9dhV72ODgqKM9I4T+S7Oc7tRmna2Q565hxuwv+fgKeD9BA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (48,            2,       3,      1,         'jandira_duarte_user',                'JANDIRA_DUARTE_USER',                 NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEIa1cvqZU9hUZdFleF5GM0jYBTecIRQTJtM35XPh8pbIVvWqpgabrlp/zBP7I5OO+g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (49,            2,       2,      0,         'imagem_radiologica_admin',           'IMAGEM_RADIOLOGICA_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAgUUTyxnUO+SeP1wqR9xFVGOjiBpZyzWNQk99iwDNme4ELRVMIyNltdahkZwZQWLQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (49,            2,       3,      0,         'imagem_radiologica_user',            'IMAGEM_RADIOLOGICA_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEChDjkqWQlh8pjzAcYFoDhIERqZJjl5iN/p5ynNnh8KRec6WwJ1yNpAvB9KjvK3qAg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (50,            2,       2,      1,         'caps_infanto_juvenil_admin',         'CAPS_INFANTO_JUVENIL_ADMIN',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEKaarSg41ZUXAgk4lgvBnvOblwbRV8tIfrBSsCeFUifXGXRuQpDz1DA5y0ofssFCFA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (50,            2,       3,      1,         'caps_infanto_juvenil_user',          'CAPS_INFANTO_JUVENIL_USER',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEE9wylBXK19SMMmqvtrwutChbxNBCP2Kn1hdBMKEfdPg3l9rpDw2MLr2023KlbXHVw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (51,            2,       2,      1,         'caps_idalina_victorello_admin',      'CAPS_IDALINA_VICTORELLO_ADMIN',       NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDVxdAN9GLSPdsTnjRMtMacMVkb62SASVz6fHzGx+KYbMxoDKDk6ycA7lAOqLliEDg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (51,            2,       3,      1,         'caps_idalina_victorello_user',       'CAPS_IDALINA_VICTORELLO_USER',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEHpmkGXdAmfRtzzw5bgtnSxr4honedh/p6kurP94Ni09nu0Ow+PH9mZRNx/2icKt8w==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (52,            2,       2,      1,         'transporte_intermunicipal_admin',    'TRANSPORTE_INTERMUNICIPAL_ADMIN',     NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJLNLl0px54ELyKVV0lloFJbnlaM45VGFhSkTc4d5dR+Fwg75PMHSs9XXsRWk7gbRQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (52,            2,       3,      1,         'transporte_intermunicipal_user',     'TRANSPORTE_INTERMUNICIPAL_USER',      NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOWBjhb1rdKgF5rU2l3DTa+hypIJgiU9mesofoD8lkTb617jve/G2aVlNJrH6cUDYQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (53,            2,       2,      0,         'consultorio_rua_admin',              'CONSULTORIO_RUA_ADMIN',               NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDHFso++6mDy0SVr7yQzeDmVdtl2V91sXS7VU+bjkEic+rmSvhZO8E6dxQajGXyX0g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (53,            2,       3,      0,         'consultorio_rua_user',               'CONSULTORIO_RUA_USER',                NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEFgJ1Eguus+oX10oOOGdqmNPkicBEZCtmXXGXByXxA1FcMCj1ZyKjE1b94hcoog/LQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (54,            2,       2,      0,         'distribuicao_imunobiologico_admin',  'DISTRIBUICAO_IMUNOBIOLOGICO_ADMIN',   NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBqOQ5x/GHXEAyUZGLw/iD6Mqpyk/ma9MOsl2ZY/R//x5hqjL+0598XGLcm6wqBEWw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (54,            2,       3,      0,         'distribuicao_imunobiologico_user',   'DISTRIBUICAO_IMUNOBIOLOGICO_USER',    NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAW5H1r+gd+rJ3zr308+2Fxo9IvgFa5ZguUGDJjDWK2ZX2f+tvVFJHpL/irOp6fycw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (55,            2,       2,      1,         'endemias_admin',                     'ENDEMIAS_ADMIN',                      NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEM5ayTOMDaxjjL9OTMgtXZMLRBx5NNZWbdjk0PabppFLI3rUp/QPGc034gGzlzoB2g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (55,            2,       3,      1,         'endemias_user',                      'ENDEMIAS_USER',                       NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECVdCsPDxq2+1K5LuhvwBCBP9CQ+12LYX745OqQg3eVnO5SvPmNi0F7MlHQPfjSYLQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0)
      ) AS T (FacilityId, Scope, Role, IsActive, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
)

INSERT INTO [dbo].[ApplicationUsers]
            ([FacilityId]
            ,[Scope]
            ,[Role]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive]
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
SELECT
      FacilityId,
      Scope,
      Role,
      CreatedOn,
      UpdatedOn,
      IsActive,
      UserName,
      NormalizedUserName,
      Email,
      NormalizedEmail,
      EmailConfirmed,
      PasswordHash,
      SecurityStamp,
      ConcurrencyStamp,
      PhoneNumber,
      PhoneNumberConfirmed,
      TwoFactorEnabled,
      LockoutEnd,
      LockoutEnabled,
      AccessFailedCount
FROM  RandomDates;
GO

-- ==================================================================================================================================
-- Material de Apoio e Administrativo
-- 22, 23, 129, 135, 172, 190, 198, 211, 212, 213, 214, 215, 216, 217, 218, 219, 234, 292, 293, 294, 295, 320, 379, 385, 393,

-- Material de Limpeza
-- 85, 86, 87, 106, 183, 189, 191, 192, 193, 194, 196, 197, 199, 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 230,
-- 258, 259, 260, 269, 270, 287, 290, 291, 296, 307, 317, 318, 319, 326, 327, 330,

-- Material Hospitalar
-- 8, 65, 66, 74, 75, 76, 95, 96, 115, 142, 144, 145, 146, 147, 148, 149, 150, 152, 153, 154, 156, 157, 158, 159, 160, 161,
-- 162, 163, 164, 165, 166, 168, 169, 170, 171, 173, 175, 176, 177, 178, 180, 181, 184, 185, 186, 187, 188, 195, 210, 232,
-- 233, 256, 261, 262, 263, 265, 266, 267, 271, 272, 273, 274, 275, 276, 277, 279, 280, 281, 282, 283, 284, 285, 286, 297,
-- 298, 299, 300, 301, 303, 304, 305, 306, 308, 309, 311, 312, 313, 314, 315, 316, 321, 322, 323, 324, 325, 328, 329, 331,
-- 332, 333, 334, 335, 336, 337, 338, 339,  340, 341, 342, 343, 344, 345, 346, 347, 349, 350, 351, 352, 353, 354, 355, 357,
-- 359, 360, 361, 362, 364, 366, 367, 368, 369, 374,  375, 376, 377, 380, 381, 382, 383, 384, 386, 388, 389, 390, 391, 392,

-- Medicamento
-- 1, 2, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 24, 25, 26, 27, 28, 29, 30, 31, 33, 34, 35, 36, 37,
-- 38, 39, 40, 41, 42, 43, 44, 45, 47, 48, 49, 50, 51, 52, 53, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 67, 69, 70, 72, 73, 77,
-- 78, 79, 80, 81, 82, 83, 84, 88, 89, 90, 91, 92, 93, 94, 97, 98, 99, 100, 101, 102, 103, 104, 105, 107, 108, 109, 110, 111,
-- 112, 113, 114, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 130, 131, 132, 133, 134, 136, 137, 138, 139, 140,
-- 141, 143, 222, 223, 224, 225, 227, 228, 229, 235, 236, 237, 238, 239, 240, 242, 244, 248, 249, 250, 251, 252, 253, 254, 255, 302,

-- IsActive = 0
-- 32, 46, 54, 68, 71, 116, 151, 155, 167, 174, 179, 182, 220, 221, 226, 231, 241, 243, 245,
-- 246, 247, 257, 264, 268, 278, 288, 289, 310, 348, 356, 358, 363, 365, 371, 378, 387,

-- ----------------------------------------------------------------------------------------------------------------------------------
-- /api/account/login
-- "accountId": 5,
{
  "userName": "dispensario_master",
  "password": "A2H@master"
}

-- "accountId": 6,
{
  "userName": "dispensario_admin",
  "password": "A2H@admin"
}

-- "accountId": 7,
{
  "userName": "dispensario_user",
  "password": "A2H@user"
}

-- "accountId": 8,
{
  "userName": "dispensario2_user",
  "password": "A2H@user"
}

-- "accountId": 9,
{
  "userName": "dispensario3_user",
  "password": "A2H@user"
}

-- ----------------------------------------------------------------------------------------------------------------------------------
-- /api/receiving/create
{
  "invoiceNumber": "305112",
  "supplyAuthorization": "AF 2024/004870",
  "observation": "",
  "receivingDate": "2024-01-05T08:40:08.000Z",
  "supplierId": 14,
  "responsibleId": 10,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 1500, "unitValue": 0.72, "batch": "LOTG9H0I1J2K", "brand": "Cimed", "expiryDate": "2026-04-12", "productId": 38 },
    { "quantity": 1000, "unitValue": 1.30, "batch": "LOTL3M4N5O6P", "brand": "Libbs", "expiryDate": "2027-07-28", "productId": 31 },
    { "quantity": 800, "unitValue": 1.95, "batch": "LOTQ7R8S9T0U", "brand": "Germed", "expiryDate": "2028-03-01", "productId": 223 },
    { "quantity": 1200, "unitValue": 0.40, "batch": "LOTV1W2X3Y4Z", "brand": "Neo Química", "expiryDate": "2029-01-14", "productId": 10 },
    { "quantity": 1700, "unitValue": 0.55, "batch": "LOTA5B6C7D8E", "brand": "Sanofi", "expiryDate": "2030-05-09", "productId": 79 },
    { "quantity": 480, "unitValue": 2.20, "batch": "LOTF9S5H2I2L", "brand": "Eurofarma", "expiryDate": "2026-10-27", "productId": 55 },
    { "quantity": 1100, "unitValue": 0.72, "batch": "LOTE3F2G1H0I", "brand": "Sanofi", "expiryDate": "2030-01-25", "productId": 2 },
    { "quantity": 750, "unitValue": 0.15, "batch": "LOTK7L1M9S6O", "brand": "Medley", "expiryDate": "2027-01-07", "productId": 107 }
  ]
}

{
  "invoiceNumber": "100000",
  "supplyAuthorization": "AF 2024/000001",
  "observation": "",
  "receivingDate": "2024-01-08T09:18:52.763Z",
  "supplierId": 51,
  "responsibleId": 9,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 450, "unitValue": 0.58, "batch": "LOTC5D6E7F8G", "brand": "Cristália", "expiryDate": "2026-08-07", "productId": 227 },
    { "quantity": 950, "unitValue": 1.80, "batch": "LOTI9J0K1L2M", "brand": "União Química", "expiryDate": "2027-02-02", "productId": 131 },
    { "quantity": 1250, "unitValue": 0.33, "batch": "LOTN3O4P5Q6R", "brand": "Eurofarma", "expiryDate": "2028-07-29", "productId": 255 },
    { "quantity": 850, "unitValue": 1.40, "batch": "LOTV7T8F9V0X", "brand": "Neo Química", "expiryDate": "2029-03-18", "productId": 140 },
    { "quantity": 600, "unitValue": 0.70, "batch": "LOTX1Y2Z3A4B", "brand": "Cimed", "expiryDate": "2030-04-24", "productId": 91 },
    { "quantity": 1500, "unitValue": 0.20, "batch": "LOTU0D6E3S8G", "brand": "Medley", "expiryDate": "2026-11-17", "productId": 104 },
    { "quantity": 500, "unitValue": 2.60, "batch": "LOTI7F0C1L8M", "brand": "Pfizer", "expiryDate": "2027-10-06", "productId": 89 },
    { "quantity": 300, "unitValue": 1.10, "batch": "LOTS3T4P2Q6R", "brand": "AstraZeneca", "expiryDate": "2028-01-26", "productId": 136 },
    { "quantity": 400, "unitValue": 5.00, "batch": "LOTS7T8U9V0W", "brand": "Roche", "expiryDate": "2029-09-13", "productId": 18 },
    { "quantity": 500, "unitValue": 0.72, "batch": "LOTV2D2Z8A1B", "brand": "Sanofi", "expiryDate": "2030-01-05", "productId": 21 }
  ]
}

{
  "invoiceNumber": "489201",
  "supplyAuthorization": "AF 2024/001358",
  "observation": "",
  "receivingDate": "2024-01-12T10:32:45.000Z",
  "supplierId": 7,
  "responsibleId": 6,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 1200, "unitValue": 0.45, "batch": "LOTX1D8E7C", "brand": "Medley", "expiryDate": "2026-01-20", "productId": 1 },
    { "quantity": 500, "unitValue": 1.10, "batch": "LOT9F4AC3B2", "brand": "EMS", "expiryDate": "2026-01-15", "productId": 4 },
    { "quantity": 800, "unitValue": 0.75, "batch": "LOTB785A4D1", "brand": "Ache", "expiryDate": "2026-01-07", "productId": 10 }
  ]
}

{
  "invoiceNumber": "109876",
  "supplyAuthorization": "AF 2024/000421",
  "observation": "Conferência realizada",
  "receivingDate": "2024-01-29T10:13:21.000Z",
  "supplierId": 1,
  "responsibleId": 4,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 5, "unitValue": 215.77, "batch": "LOTAA1BB2C3", "brand": "Mikatos", "expiryDate": "2028-01-01", "productId": 277 },
    { "quantity": 5, "unitValue": 43.99, "batch": "LOTDD4EE5F6", "brand": "G-Tech", "expiryDate": "2027-12-31", "productId": 272 },
    { "quantity": 5, "unitValue": 14.45, "batch": "LOTGG7HH8I9", "brand": "G-Tech", "expiryDate": "2027-05-17", "productId": 188 }
  ]
}

{
  "invoiceNumber": "449012",
  "supplyAuthorization": "AF 2024/000889",
  "observation": "",
  "receivingDate": "2024-01-30T08:27:38.000Z",
  "supplierId": 9,
  -- Material de Limpeza
  "responsibleId": 11,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 5, "unitValue": 55.00, "batch": "LOT1A8F3D7C", "brand": "Diversey", "expiryDate": "2028-04-05", "productId": 194 },
    { "quantity": 5, "unitValue": 7.90, "batch": "LOT2C7E9A6B", "brand": "Bralimpia", "expiryDate": "2027-02-28", "productId": 201 },
    { "quantity": 250, "unitValue": 85.50, "batch": "LOT3B6D8C5A", "brand": "Kimberly-Clark", "expiryDate": "2026-11-17", "productId": 205 },
    { "quantity": 750, "unitValue": 1.50, "batch": "LOT4A5C7B4D", "brand": "Tork", "expiryDate": "2029-09-08", "productId": 207 },
    { "quantity": 45, "unitValue": 32.80, "batch": "LOT5D4B6A3C", "brand": "Omo", "expiryDate": "2030-01-01", "productId": 317 },
    { "quantity": 10, "unitValue": 48.00, "batch": "LOT6C3A5D2B", "brand": "Clorox", "expiryDate": "2027-10-30", "productId": 87 },
    { "quantity": 900, "unitValue": 11.20, "batch": "LOT7B2D4C1A", "brand": "Bombril", "expiryDate": "2028-06-19", "productId": 260 }
  ]
}

{
  "invoiceNumber": "998877",
  "supplyAuthorization": "AF 2024/000088",
  "observation": "",
  "receivingDate": "2024-02-07T09:31:47.000Z",
  "supplierId": 22,
  "responsibleId": 7,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 450, "unitValue": 85.50, "batch": "LOTA9B8C7D", "brand": "Missner", "expiryDate": "2027-09-08", "productId": 301 },
    { "quantity": 500, "unitValue": 2.10, "batch": "LOT1Z2X3C4", "brand": "Cremer", "expiryDate": "2027-10-10", "productId": 168 },
    { "quantity": 200, "unitValue": 8.50, "batch": "LOT6V7B8N9", "brand": "Vesta", "expiryDate": "2028-04-29", "productId": 8 },
    { "quantity": 950, "unitValue": 1.20, "batch": "LOTM5K4J3H", "brand": "Cremer", "expiryDate": "2029-06-05", "productId": 267 },
    { "quantity": 400, "unitValue": 0.90, "batch": "LOTG2D1S0A", "brand": "Medfio", "expiryDate": "2030-02-14", "productId": 181 },
    { "quantity": 100, "unitValue": 0.45, "batch": "LOTR4T3Y2U", "brand": "Descarpack", "expiryDate": "2026-07-28", "productId": 338 },
    { "quantity": 150, "unitValue": 0.22, "batch": "LOT1E2R3T4", "brand": "Descarpack", "expiryDate": "2027-11-09", "productId": 339 },
    { "quantity": 200, "unitValue": 1.10, "batch": "LOTQ7W8E9R", "brand": "Cremer", "expiryDate": "2028-08-18", "productId": 286 },
    { "quantity": 50, "unitValue": 45.00, "batch": "LOT0A1B2C3", "brand": "B. Braun", "expiryDate": "2029-03-24", "productId": 303 }
  ]
}

{
  "invoiceNumber": "193847",
  "supplyAuthorization": "AF 2024/007000",
  "observation": "Conferido e OK",
  "receivingDate": "2024-02-16T15:05:53.000Z",
  "supplierId": 67,
  "responsibleId": 9,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 1600, "unitValue": 0.60, "batch": "LOTP5Q6R7S8T", "brand": "EMS", "expiryDate": "2026-01-20", "productId": 222 },
    { "quantity": 850, "unitValue": 1.10, "batch": "LOTU9V0W1X2Y", "brand": "Sanofi", "expiryDate": "2027-06-16", "productId": 120 },
    { "quantity": 1200, "unitValue": 0.72, "batch": "LOTG9H0I1J2K", "brand": "Cimed", "expiryDate": "2026-04-12", "productId": 38 },
    { "quantity": 1000, "unitValue": 0.99, "batch": "LOTF9G0H1I2J", "brand": "Aché", "expiryDate": "2029-11-20", "productId": 3 },
    { "quantity": 750, "unitValue": 1.65, "batch": "LOTK3L4M5N6O", "brand": "Novartis", "expiryDate": "2030-03-03", "productId": 121 },
    { "quantity": 1500, "unitValue": 4.20, "batch": "LOTX3Y6Z3V4B", "brand": "Bayer", "expiryDate": "2026-12-12", "productId": 14 }
  ]
}

{
  -- /api/stock/create-adjustment
  "type": 1,
  "reason": "Doação",
  "observation": "",
  "adjustmentDate": "2024-03-04T14:25:16.000Z",
  "responsibleId": 5,
  "accountId": 6,
  "adjustmentItems": [
    { "productId": 373, "quantity": 100, "batch": "LOTT7S2S5G0U", "brand": "Elgin", "expiryDate": "2026-10-25", "unitValue": 5.25 },
    { "productId": 372, "quantity": 95, "batch": "LOTW7R5S1T0U", "brand": "Panasonic", "expiryDate": "2026-12-15", "unitValue": 29.99 }
  ]
}

{
  "invoiceNumber": "451890",
  "supplyAuthorization": "AF 2024/001357",
  "observation": "",
  "receivingDate": "2024-03-12T11:35:13.000Z",
  "supplierId": 4,
  "responsibleId": 11,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 300, "unitValue": 35.50, "batch": "LOTK9L8M7N6O", "brand": "Pfizer", "expiryDate": "2026-11-05", "productId": 12 },
    { "quantity": 950, "unitValue": 1.15, "batch": "LOTP5Q4R3S2T", "brand": "Eurofarma", "expiryDate": "2027-03-21", "productId": 70 },
    { "quantity": 1800, "unitValue": 0.48, "batch": "LOTU1V0W9X8Y", "brand": "Neo Química", "expiryDate": "2028-06-03", "productId": 103 },
    { "quantity": 400, "unitValue": 2.75, "batch": "LOTZ7A6B5C4D", "brand": "Roche", "expiryDate": "2029-12-19", "productId": 127 },
    { "quantity": 1100, "unitValue": 0.77, "batch": "LOTF6F2G1B0I", "brand": "Sanofi", "expiryDate": "2030-01-25", "productId": 2 }
  ]
}

{
  "invoiceNumber": "123456",
  "supplyAuthorization": "AF 2024/001001",
  "observation": "",
  "receivingDate": "2024-03-12T15:30:58.000Z",
  "supplierId": 46,
  "responsibleId": 10,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 50, "unitValue": 0.85, "batch": "LOTX3K9Q1A", "brand": "3M", "expiryDate": "2027-05-20", "productId": 145 },
    { "quantity": 80, "unitValue": 1.15, "batch": "LOTC8Z7E5R", "brand": "3M", "expiryDate": "2027-05-20", "productId": 146 },
    { "quantity": 300, "unitValue": 5.20, "batch": "LOT4A5B6C7", "brand": "Medix", "expiryDate": "2028-09-10", "productId": 148 },
    { "quantity": 1500, "unitValue": 0.18, "batch": "LOT9T8S7R6", "brand": "Descarpack", "expiryDate": "2026-11-25", "productId": 115 },
    { "quantity": 500, "unitValue": 0.35, "batch": "LOT5F6G7H8", "brand": "Descarpack", "expiryDate": "2027-03-01", "productId": 165 },
    { "quantity": 1700, "unitValue": 1.50, "batch": "LOT2B3C4D5", "brand": "BD", "expiryDate": "2029-01-15", "productId": 95 }
  ]
}

{
  "invoiceNumber": "777777",
  "supplyAuthorization": "AF 2024/001000",
  "observation": "Itens frágeis, conferidos com atenção.",
  "receivingDate": "2024-03-13T14:03:45.000Z",
  "supplierId": 57,
  "responsibleId": 12,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 250, "unitValue": 0.28, "batch": "LOTX1D2T6Y7", "brand": "Descarpack", "expiryDate": "2026-05-20", "productId": 144 },
    { "quantity": 80, "unitValue": 0.35, "batch": "LOTR0Q3A5Z9", "brand": "Supermax", "expiryDate": "2026-05-20", "productId": 145 },
    { "quantity": 50, "unitValue": 0.42, "batch": "LOTP9O8I7U6", "brand": "Medix", "expiryDate": "2026-05-20", "productId": 146 },
    { "quantity": 1000, "unitValue": 0.17, "batch": "LOTM4N5B6V7", "brand": "BD", "expiryDate": "2027-08-15", "productId": 74 },
    { "quantity": 1200, "unitValue": 0.19, "batch": "LOTC8X9Z0E1", "brand": "SR", "expiryDate": "2027-09-01", "productId": 75 }
  ]
}

{
  -- /api/stock/create-adjustment
  "type": 2,
  "reason": "Quebra",
  "observation": "",
  "adjustmentDate": "2024-03-13T15:26:37.000Z",
  "responsibleId": 7,
  "accountId": 6,
  "adjustmentItems": [
    { "productId": 18,  "quantity": 5, "batch": "LOTS7T8U9V0W",  "brand": "Roche", "expiryDate": "2029-09-13", "unitValue": 5.00 }
  ]
}

{
  "invoiceNumber": "213894",
  "supplyAuthorization": "AF 2024/001478",
  "observation": "",
  "receivingDate": "2024-03-25T10:38:52.000Z",
  "supplierId": 46,
  "responsibleId": 9,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 50, "unitValue": 120.00, "batch": "LOTR7S8T9U0V", "brand": "GSK", "expiryDate": "2026-09-01", "productId": 34 },
    { "quantity": 80, "unitValue": 85.00, "batch": "LOTW1X2Y3Z4A", "brand": "Butantan", "expiryDate": "2027-04-18", "productId": 33 },
    { "quantity": 1500, "unitValue": 0.70, "batch": "LOTM5C6M7E8F", "brand": "Aché", "expiryDate": "2028-08-30", "productId": 42 }
  ]
}

{
  "invoiceNumber": "789012",
  "supplyAuthorization": "AF 2024/007007",
  "observation": "",
  "receivingDate": "2024-04-01T11:12:13.000Z",
  "supplierId": 33,
  "responsibleId": 9,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 500, "unitValue": 15.70, "batch": "LOTN915I1U", "brand": "BD", "expiryDate": "2028-12-01", "productId": 74 },
    { "quantity": 500, "unitValue": 15.70, "batch": "LOTP9O8I7Z", "brand": "BD", "expiryDate": "2028-12-01", "productId": 75 },
    { "quantity": 100, "unitValue": 25.00, "batch": "LOTV4N2M1K", "brand": "Uniqmed", "expiryDate": "2029-04-10", "productId": 275 },
    { "quantity": 300, "unitValue": 1.80, "batch": "LOTE9D4F6A", "brand": "CRAL", "expiryDate": "2027-08-05", "productId": 347 },
    { "quantity": 350, "unitValue": 4.50, "batch": "LOTL2P3Z4X", "brand": "Descarpack", "expiryDate": "2026-03-17", "productId": 152 },
    { "quantity": 450, "unitValue": 3.20, "batch": "LOTQ7W6E5R", "brand": "Descarpack", "expiryDate": "2028-01-22", "productId": 162 },
    { "quantity": 100, "unitValue": 6.80, "batch": "LOTH6J5K2L", "brand": "Portex", "expiryDate": "2030-01-01", "productId": 390 }
  ]
}

{
  "invoiceNumber": "889900",
  "supplyAuthorization": "AF 2024/007123",
  "observation": "",
  "receivingDate": "2024-04-16T15:42:24.000Z",
  "supplierId": 28,
  "responsibleId": 10,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 250, "unitValue": 2.80, "batch": "LOTR7E6W5Q", "brand": "Descarpack", "expiryDate": "2028-01-05", "productId": 153 },
    { "quantity": 200, "unitValue": 2.80, "batch": "LOTP4O3I2U", "brand": "Descarpack", "expiryDate": "2028-01-05", "productId": 154 },
    { "quantity": 100, "unitValue": 2.80, "batch": "LOTY1T0R9E", "brand": "Descarpack", "expiryDate": "2028-01-05", "productId": 195 },
    { "quantity": 300, "unitValue": 3.50, "batch": "LOTW8Q7A6S", "brand": "Descarpack", "expiryDate": "2029-06-19", "productId": 331 },
    { "quantity": 150, "unitValue": 0.40, "batch": "LOTD5F4G3H", "brand": "Descarpack", "expiryDate": "2030-01-23", "productId": 282 },
    { "quantity": 50, "unitValue": 12.00, "batch": "LOTJ2K1L0M", "brand": "Kolplast", "expiryDate": "2027-10-01", "productId": 375 },
    { "quantity": 50, "unitValue": 12.00, "batch": "LOTN9B8V7C", "brand": "Kolplast", "expiryDate": "2027-10-01", "productId": 377 },
    { "quantity": 50, "unitValue": 15.00, "batch": "LOTX6Z5A4S", "brand": "Kolplast", "expiryDate": "2028-05-27", "productId": 300 }
  ]
}

{
  "invoiceNumber": "504030",
  "supplyAuthorization": "AF 2024/003344",
  "observation": "",
  "receivingDate": "2024-04-22T16:12:20.000Z",
  "supplierId": 9,
  -- Material de Limpeza
  "responsibleId": 12,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 15, "unitValue": 25.40, "batch": "LOTB8K9R0M1", "brand": "Tuff", "expiryDate": "2029-12-12", "productId": 87 },
    { "quantity": 5, "unitValue": 15.40, "batch": "LOTN2O3P4Q5", "brand": "Flash Limp", "expiryDate": "2027-10-30", "productId": 199 },
    { "quantity": 25, "unitValue": 223.00, "batch": "LOTR6S7T8U9", "brand": "AurosQuímica", "expiryDate": "2028-08-22", "productId": 317 },
    { "quantity": 5, "unitValue": 124.00, "batch": "LOTV0W1X2Y3", "brand": "Sandet", "expiryDate": "2026-09-16", "productId": 326 },
    { "quantity": 650, "unitValue": 12.50, "batch": "LOTZ4A5B6C7", "brand": "Salix", "expiryDate": "2030-03-01", "productId": 260 },
    { "quantity": 650, "unitValue": 40.65, "batch": "LOTD8E9F0G1", "brand": "Descarbox", "expiryDate": "2027-05-07", "productId": 208 },
    { "quantity": 5, "unitValue": 34.50, "batch": "LOTH2I3J4K5", "brand": "Limpol", "expiryDate": "2028-01-20", "productId": 85 },
    { "quantity": 150, "unitValue": 7.20, "batch": "LOTL6M7N8O9", "brand": "Vabene", "expiryDate": "2029-07-17", "productId": 259 },
    { "quantity": 350, "unitValue": 35.28, "batch": "LOTP0Q1R2S3", "brand": "Lamare", "expiryDate": "2026-11-04", "productId": 291 },
    { "quantity": 15, "unitValue": 38.92, "batch": "LOTT4U5V6W7", "brand": "Suprema", "expiryDate": "2030-05-18", "productId": 296 },
    { "quantity": 115, "unitValue": 21.15, "batch": "LOTX8Y9Z0A1", "brand": "Nobre", "expiryDate": "2027-04-14", "productId": 189 },
    { "quantity": 10, "unitValue": 73.55, "batch": "LOTB2C3D4E5", "brand": "START Sauce", "expiryDate": "2028-03-06", "productId": 86 },
    { "quantity": 5, "unitValue": 110.75, "batch": "LOTF6G7H8I9", "brand": "Plasutil", "expiryDate": "2029-01-05", "productId": 202 },
    { "quantity": 115, "unitValue": 21.15, "batch": "LOTJ0K1L2M3", "brand": "Nobre", "expiryDate": "2026-10-23", "productId": 197 }
  ]
}

{
  -- /api/stock/create-adjustment
  "type": 2,
  "reason": "Perda",
  "observation": "",
  "adjustmentDate": "2024-05-02T10:27:36.000Z",
  "responsibleId": 6,
  "accountId": 6,
  "adjustmentItems": [
    { "productId": 95, "quantity": 30, "batch": "LOT2B3C4D5", "brand": "BD", "expiryDate": "2029-01-15", "unitValue": 1.50 }
  ]
}

{
  "invoiceNumber": "452791",
  "supplyAuthorization": "AF 2024/110543",
  "observation": "Entrega parcial concluída.",
  "receivingDate": "2024-05-03T14:38:53.000Z",
  "supplierId": 4,
  "responsibleId": 12,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 400, "unitValue": 4.10, "batch": "LOTO0P1A2Z3", "brand": "Portex", "expiryDate": "2029-06-11", "productId": 256 },
    { "quantity": 450, "unitValue": 3.90, "batch": "LOTV4B5N6M7", "brand": "BD", "expiryDate": "2029-07-15", "productId": 389 },
    { "quantity": 500, "unitValue": 4.00, "batch": "LOTC8X9Z0Q1", "brand": "Sol-Millennium", "expiryDate": "2029-08-28", "productId": 390 },
    { "quantity": 600, "unitValue": 2.50, "batch": "LOTW2E3R4T5", "brand": "Embramed", "expiryDate": "2028-03-05", "productId": 354 },
    { "quantity": 700, "unitValue": 2.20, "batch": "LOTY6U7I8O9", "brand": "Descarpack", "expiryDate": "2028-04-10", "productId": 321 }
  ]
}

{
  "invoiceNumber": "321987",
  "supplyAuthorization": "AF 2024/004004",
  "observation": "",
  "receivingDate": "2024-05-15T09:28:16.000Z",
  "supplierId": 67,
  -- Material de Apoio e Administrativo
  "responsibleId": 6,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 10, "unitValue": 22.90, "batch": "LOTG2J7V3X0", "brand": "Bioland", "expiryDate": "2028-03-29", "productId": 379 },
    { "quantity": 100, "unitValue": 1.45, "batch": "LOTN9W5Y4Z1", "brand": "3M", "expiryDate": "2029-05-11", "productId": 129 },
    { "quantity": 1000, "unitValue": 0.04, "batch": "LOTR3A6B8C2", "brand": "Spiral", "expiryDate": "2027-09-08", "productId": 218 },
    { "quantity": 40, "unitValue": 3.80, "batch": "LOTL4D9E0F5", "brand": "Duracell", "expiryDate": "2027-11-25", "productId": 23 },
    { "quantity": 50, "unitValue": 0.90, "batch": "LOTV1H7J6K3", "brand": "Pentel", "expiryDate": "2026-07-19", "productId": 215 },
    { "quantity": 15, "unitValue": 4.50, "batch": "LOTP0Q2S8T4", "brand": "Staples", "expiryDate": "2030-01-07", "productId": 216 },
    { "quantity": 5, "unitValue": 35.00, "batch": "LOTZ6M1N9A7", "brand": "Tilibra", "expiryDate": "2028-10-04", "productId": 320 }
  ]
}

{
  "invoiceNumber": "178234",
  "supplyAuthorization": "AF 2024/009900",
  "observation": "",
  "receivingDate": "2024-06-18T09:33:52.000Z",
  "supplierId": 79,
  "responsibleId": 2,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 3000, "unitValue": 0.20, "batch": "LOTP0A1S2D3", "brand": "BD Plastipak", "expiryDate": "2026-11-20", "productId": 95 },
    { "quantity": 3500, "unitValue": 0.25, "batch": "LOTF4G5H6J7", "brand": "Injex", "expiryDate": "2026-12-10", "productId": 96 },
    { "quantity": 2500, "unitValue": 0.18, "batch": "LOTK8L9M0N1", "brand": "Descarpack", "expiryDate": "2027-01-05", "productId": 157 },
    { "quantity": 1000, "unitValue": 0.60, "batch": "LOTB2V3C4X5", "brand": "SR", "expiryDate": "2027-03-25", "productId": 184 },
    { "quantity": 1500, "unitValue": 0.08, "batch": "LOTZ6Q7W8E9", "brand": "Medix", "expiryDate": "2027-08-01", "productId": 181 },
    { "quantity": 1500, "unitValue": 0.10, "batch": "LOTR0T1Y2U3", "brand": "Uniqmed", "expiryDate": "2027-09-19", "productId": 159 },
    { "quantity": 1200, "unitValue": 0.10, "batch": "LOTI4O5P6A7", "brand": "BD", "expiryDate": "2027-10-05", "productId": 160 },
    { "quantity": 1500, "unitValue": 0.55, "batch": "LOTS8D9F0G1", "brand": "SR", "expiryDate": "2028-01-15", "productId": 180 },
    { "quantity": 1500, "unitValue": 0.58, "batch": "LOTH2J3K4L5", "brand": "Descarpack", "expiryDate": "2028-02-28", "productId": 343 },
    { "quantity": 1500, "unitValue": 0.65, "batch": "LOTM6N7B8V9", "brand": "BD", "expiryDate": "2028-03-10", "productId": 303 }
  ]
}

{
  "invoiceNumber": "190765",
  "supplyAuthorization": "AF 2024/334455",
  "observation": "",
  "receivingDate": "2024-07-03T09:38:12.000Z",
  "supplierId": 3,
  "responsibleId": 4,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 120, "unitValue": 0.85, "batch": "LOTD2S3A4P5", "brand": "Accu-Chek", "expiryDate": "2026-03-15", "productId": 142 },
    { "quantity": 1500, "unitValue": 0.14, "batch": "LOTF6G7H8J9", "brand": "NovoFine", "expiryDate": "2027-04-04", "productId": 275 },
    { "quantity": 1200, "unitValue": 0.95, "batch": "LOTK0L1M2N3", "brand": "BD", "expiryDate": "2028-07-20", "productId": 158 },
    { "quantity": 10, "unitValue": 90.00, "batch": "LOTP4Q5R6S7", "brand": "G-Tech", "expiryDate": "2030-01-30", "productId": 273 },
    { "quantity": 50, "unitValue": 7.50, "batch": "LOTU8V9W0X1", "brand": "Novopen", "expiryDate": "2030-02-01", "productId": 333 }
  ]
}

{
  -- /api/stock/create-adjustment
  "type": 1,
  "reason": "Doação",
  "observation": "",
  "adjustmentDate": "2024-07-04T11:22:33.000Z",
  "responsibleId": 6,
  "accountId": 6,
  "adjustmentItems": [
    { "productId": 250, "quantity": 90, "batch": "LOTF5D2S6G0D", "brand": "Pfizer", "expiryDate": "2026-09-15", "unitValue": 0.25 },
    { "productId": 249, "quantity": 180, "batch": "LOTB9A2G7G2U", "brand": "Neo Química", "expiryDate": "2026-11-04", "unitValue": 0.15 },
    { "productId": 251, "quantity": 30, "batch": "LOTQ7B5Y7T9G", "brand": "Eurofarma", "expiryDate": "2026-12-19", "unitValue": 0.85 }
  ]
}

{
  "invoiceNumber": "459021",
  "supplyAuthorization": "AF 2024/005128",
  "observation": "",
  "receivingDate": "2024-07-22T10:35:10.000Z",
  "supplierId": 24,
  "responsibleId": 11,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 150, "unitValue": 1.45, "batch": "LOTH3G4F5D6", "brand": "Johnson & Johnson", "expiryDate": "2028-11-10", "productId": 65 },
    { "quantity": 500, "unitValue": 1.55, "batch": "LOTS7A8D9F0", "brand": "BD", "expiryDate": "2028-11-10", "productId": 66 },
    { "quantity": 1000, "unitValue": 0.11, "batch": "LOTJ1K2L3M4", "brand": "Descarpack", "expiryDate": "2029-03-22", "productId": 115 },
    { "quantity": 750, "unitValue": 0.22, "batch": "LOTQ5W6E7R8", "brand": "3M", "expiryDate": "2028-06-05", "productId": 169 },
    { "quantity": 80, "unitValue": 0.60, "batch": "LOTY9T8R7E6", "brand": "Supermax", "expiryDate": "2027-12-01", "productId": 305 },
    { "quantity": 80, "unitValue": 0.65, "batch": "LOTZ0X1C2V3", "brand": "Talge", "expiryDate": "2027-12-01", "productId": 276 },
    { "quantity": 65, "unitValue": 14.78, "batch": "LOTB4N5M6L7", "brand": "Kolplast", "expiryDate": "2029-05-01", "productId": 300 }
  ]
}

{
  "invoiceNumber": "214365",
  "supplyAuthorization": "AF 2024/000042",
  "observation": "Amostras",
  "receivingDate": "2024-07-26T10:23:31.000Z",
  "supplierId": 18,
  "responsibleId": 9,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 2000, "unitValue": 0.18, "batch": "LOTD5C4B3A2", "brand": "Genom", "expiryDate": "2026-06-21", "productId": 254 },
    { "quantity": 1450, "unitValue": 0.79, "batch": "LOTF9E8D7C6", "brand": "Merck", "expiryDate": "2028-03-06", "productId": 25 },
    { "quantity": 1300, "unitValue": 1.60, "batch": "LOTB0A1C2D3", "brand": "Biolab", "expiryDate": "2029-08-11", "productId": 80 }
  ]
}

{
  "invoiceNumber": "351987",
  "supplyAuthorization": "AF 2024/004002",
  "observation": "",
  "receivingDate": "2024-07-29T13:15:00.000Z",
  "supplierId": 33,
  "responsibleId": 10,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 1200, "unitValue": 0.80, "batch": "LOTE1D2F3G", "brand": "BD", "expiryDate": "2028-03-03", "productId": 157 },
    { "quantity": 2200, "unitValue": 0.90, "batch": "LOTH4J5K6L", "brand": "BD", "expiryDate": "2028-03-03", "productId": 96 },
    { "quantity": 1050, "unitValue": 2.50, "batch": "LOTM7N8B9V", "brand": "Descarpack", "expiryDate": "2029-01-08", "productId": 184 },
    { "quantity": 150, "unitValue": 0.70, "batch": "LOTC1X2Z3A", "brand": "Missner", "expiryDate": "2030-07-21", "productId": 159 },
    { "quantity": 150, "unitValue": 0.70, "batch": "LOTS4D5F6G", "brand": "Missner", "expiryDate": "2030-07-21", "productId": 160 },
    { "quantity": 1300, "unitValue": 1.30, "batch": "LOTH7J8K9L", "brand": "Descarpack", "expiryDate": "2026-06-16", "productId": 178 }
  ]
}

{
  "invoiceNumber": "782345",
  "supplyAuthorization": "AF 2024/002981",
  "observation": "",
  "receivingDate": "2024-07-30T14:41:32.000Z",
  "supplierId": 25,
  "responsibleId": 10,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 50, "unitValue": 6.00, "batch": "LOTZ9X8C7V", "brand": "Ethicon", "expiryDate": "2027-04-01", "productId": 261 },
    { "quantity": 50, "unitValue": 6.00, "batch": "LOTB6N5M4K", "brand": "Ethicon", "expiryDate": "2027-04-01", "productId": 262 },
    { "quantity": 100, "unitValue": 2.50, "batch": "LOTJ3H2G1F", "brand": "Cremer", "expiryDate": "2028-10-25", "productId": 169 },
    { "quantity": 100, "unitValue": 5.00, "batch": "LOTD0S9A8Z", "brand": "Cremer", "expiryDate": "2029-07-16", "productId": 170 },
    { "quantity": 200, "unitValue": 0.40, "batch": "LOTX7C6V5B", "brand": "Missner", "expiryDate": "2030-04-18", "productId": 166 },
    { "quantity": 100, "unitValue": 1.90, "batch": "LOTN4M3K2J", "brand": "B. Braun", "expiryDate": "2026-02-09", "productId": 332 },
    { "quantity": 120, "unitValue": 35.00, "batch": "LOTH1G0F9D", "brand": "Uniqmed", "expiryDate": "2027-06-20", "productId": 309 }
  ]
}

{
  "invoiceNumber": "333444",
  "supplyAuthorization": "AF 2024/009191",
  "observation": "",
  "receivingDate": "2024-08-02T11:30:02.000Z",
  "supplierId": 3,
  "responsibleId": 12,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 500, "unitValue": 0.05, "batch": "LOT8F7G6H5", "brand": "Descarpack", "expiryDate": "2028-05-15", "productId": 334 },
    { "quantity": 500, "unitValue": 0.30, "batch": "LOT4J3K2L1", "brand": "Descarpack", "expiryDate": "2027-01-30", "productId": 341 },
    { "quantity": 100, "unitValue": 0.95, "batch": "LOT0M9N8B7", "brand": "Descarpack", "expiryDate": "2026-04-04", "productId": 337 },
    { "quantity": 300, "unitValue": 0.50, "batch": "LOT6V5C4X3", "brand": "Missner", "expiryDate": "2029-10-12", "productId": 163 },
    { "quantity": 50, "unitValue": 0.70, "batch": "LOT2Z1Y0T9", "brand": "Missner", "expiryDate": "2030-05-01", "productId": 171 },
    { "quantity": 20, "unitValue": 8.00, "batch": "LOTR5E4W3Q", "brand": "Medix", "expiryDate": "2027-07-07", "productId": 173 },
    { "quantity": 200, "unitValue": 1.50, "batch": "LOTY6U7I8O", "brand": "Medfio", "expiryDate": "2028-02-28", "productId": 175 },
    { "quantity": 100, "unitValue": 3.90, "batch": "LOTP9L8K7J", "brand": "Medix", "expiryDate": "2029-08-08", "productId": 232 },
    { "quantity": 50, "unitValue": 25.00, "batch": "LOTH3G2F1D", "brand": "Johnson", "expiryDate": "2026-12-19", "productId": 311 },
    { "quantity": 150, "unitValue": 1.20, "batch": "LOTS0A9Z8X", "brand": "Descarpack", "expiryDate": "2027-04-14", "productId": 312 },
    { "quantity": 100, "unitValue": 0.90, "batch": "LOTC7V6B5N", "brand": "Cremer", "expiryDate": "2028-11-20", "productId": 369 },
    { "quantity": 40, "unitValue": 7.50, "batch": "LOTM4K3J2I", "brand": "Descarpack", "expiryDate": "2029-05-03", "productId": 308 }
  ]
}

{
  "invoiceNumber": "660022",
  "supplyAuthorization": "AF 2024/002468",
  "observation": "",
  "receivingDate": "2024-08-05T14:31:14.000Z",
  "supplierId": 7,
  "responsibleId": 10,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 250, "unitValue": 2.15, "batch": "LOTC2V3B4N5", "brand": "DeltaPlus", "expiryDate": "2027-10-01", "productId": 8 },
    { "quantity": 350, "unitValue": 0.15, "batch": "LOTM6L7K8J9", "brand": "Talge", "expiryDate": "2028-09-09", "productId": 156 },
    { "quantity": 400, "unitValue": 0.90, "batch": "LOTI0U1Y2T3", "brand": "Descarpack", "expiryDate": "2028-11-25", "productId": 153 },
    { "quantity": 350, "unitValue": 0.85, "batch": "LOTR4E5W6Q7", "brand": "Medix", "expiryDate": "2028-12-12", "productId": 154 },
    { "quantity": 300, "unitValue": 1.10, "batch": "LOTA8S9D0F1", "brand": "Supermax", "expiryDate": "2029-01-08", "productId": 195 },
    { "quantity": 150, "unitValue": 1.95, "batch": "LOTG2H3J4K5", "brand": "Vabene", "expiryDate": "2029-04-18", "productId": 279 },
    { "quantity": 200, "unitValue": 0.38, "batch": "LOTL6M7N8B9", "brand": "Vulk", "expiryDate": "2028-05-30", "productId": 367 }
  ]
}

{
  "invoiceNumber": "654321",
  "supplyAuthorization": "AF 2024/002002",
  "observation": "",
  "receivingDate": "2024-08-23T14:45:35.000Z",
  "supplierId": 14,
  "responsibleId": 9,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 500, "unitValue": 0.85, "batch": "LOT6A5B4C3D", "brand": "Wyeth", "expiryDate": "2028-11-07", "productId": 4 },
    { "quantity": 1000, "unitValue": 1.05, "batch": "LOT8E7F6A5B", "brand": "Bristol-Myers Squibb", "expiryDate": "2027-02-02", "productId": 236 },
    { "quantity": 900, "unitValue": 2.55, "batch": "LOTC1D2E3F4", "brand": "Boehringer Ingelheim", "expiryDate": "2029-10-17", "productId": 139 }
  ]
}

{
  "invoiceNumber": "213456",
  "supplyAuthorization": "AF 2024/006001",
  "observation": "",
  "receivingDate": "2024-09-17T08:45:10.000Z",
  "supplierId": 23,
  "responsibleId": 8,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 950, "unitValue": 1.45, "batch": "LOTB71C0A9A", "brand": "Novartis", "expiryDate": "2028-05-20", "productId": 110 },
    { "quantity": 750, "unitValue": 0.88, "batch": "LOT4E9F23D6", "brand": "EMS", "expiryDate": "2029-01-15", "productId": 123 },
    { "quantity": 2500, "unitValue": 0.35, "batch": "LOTC83A6D1E", "brand": "Medley", "expiryDate": "2027-06-01", "productId": 37 },
    { "quantity": 600, "unitValue": 2.10, "batch": "LOT1A9345FF", "brand": "Eurofarma", "expiryDate": "2026-11-25", "productId": 240 },
    { "quantity": 750, "unitValue": 0.65, "batch": "LOT6B7B228C", "brand": "Ache", "expiryDate": "2028-09-10", "productId": 120 }
  ]
}

{
  "invoiceNumber": "605483",
  "supplyAuthorization": "AF 2024/998123",
  "observation": "Conferência completa e sem divergências.",
  "receivingDate": "2024-09-17T11:03:50.000Z",
  "supplierId": 14,
  "responsibleId": 12,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 500, "unitValue": 0.28, "batch": "LOTQ1W2E3R4", "brand": "Cremer", "expiryDate": "2026-07-01", "productId": 164 },
    { "quantity": 800, "unitValue": 0.15, "batch": "LOTT5Y6U7I8", "brand": "Medix", "expiryDate": "2026-08-10", "productId": 165 },
    { "quantity": 150, "unitValue": 1.99, "batch": "LOTO9P0A1S2", "brand": "Curatec", "expiryDate": "2027-05-05", "productId": 309 },
    { "quantity": 500, "unitValue": 0.95, "batch": "LOTD3F4G5H6", "brand": "Descarpack", "expiryDate": "2027-11-01", "productId": 168 },
    { "quantity": 400, "unitValue": 1.10, "batch": "LOTJ7K8L9M0", "brand": "Cremer", "expiryDate": "2028-03-18", "productId": 286 },
    { "quantity": 250, "unitValue": 8.50, "batch": "LOTN1B2V3C4", "brand": "Ortocenter", "expiryDate": "2030-01-10", "productId": 186 }
  ]
}

{
  "invoiceNumber": "612345",
  "supplyAuthorization": "AF 2024/005500",
  "observation": "Entrega antecipada",
  "receivingDate": "2024-09-19T13:16:48.000Z",
  "supplierId": 49,
  "responsibleId": 6,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 500, "unitValue": 1.90, "batch": "LOTP3Q7R0S4", "brand": "Supermax", "expiryDate": "2027-12-01", "productId": 367 },
    { "quantity": 500, "unitValue": 1.95, "batch": "LOTV8W2X6Y9", "brand": "Supermax", "expiryDate": "2027-12-01", "productId": 368 },
    { "quantity": 10, "unitValue": 35.50, "batch": "LOTZ0A4B8C3", "brand": "Incoterm", "expiryDate": "2029-02-18", "productId": 187 },
    { "quantity": 300, "unitValue": 8.10, "batch": "LOTD5E9F3G7", "brand": "Descarpack", "expiryDate": "2026-06-30", "productId": 347 }
  ]
}

{
  "invoiceNumber": "587634",
  "supplyAuthorization": "AF 2024/001099",
  "observation": "",
  "receivingDate": "2024-10-09T15:30:02.000Z",
  "supplierId": 63,
  "responsibleId": 11,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 1000, "unitValue": 0.20, "batch": "LOTJ6K0L4M8", "brand": "Descarpack", "expiryDate": "2027-09-06", "productId": 166 },
    { "quantity": 500, "unitValue": 0.45, "batch": "LOTN2O6P0Q4", "brand": "Descarpack", "expiryDate": "2026-10-23", "productId": 168 },
    { "quantity": 600, "unitValue": 2.10, "batch": "LOTR7S1T5U9", "brand": "Solidor", "expiryDate": "2028-01-08", "productId": 286 },
    { "quantity": 50, "unitValue": 6.30, "batch": "LOTV3W7X1Y5", "brand": "Supermax", "expiryDate": "2029-07-11", "productId": 305 },
    { "quantity": 500, "unitValue": 6.50, "batch": "LOTZ8A2B6C0", "brand": "Supermax", "expiryDate": "2029-07-11", "productId": 323 },
    { "quantity": 50, "unitValue": 6.80, "batch": "LOTD4E8F2G6", "brand": "Supermax", "expiryDate": "2029-07-11", "productId": 276 },
    { "quantity": 10, "unitValue": 85.00, "batch": "LOTN1O5P9Q2", "brand": "Accu-Chek", "expiryDate": "2026-08-10", "productId": 273 },
    { "quantity": 1500, "unitValue": 0.30, "batch": "LOTR6S0T4U8", "brand": "Descarpack", "expiryDate": "2029-06-03", "productId": 115 },
    { "quantity": 10, "unitValue": 15.20, "batch": "LOTV2W6X0Y4", "brand": "Microlife", "expiryDate": "2030-05-18", "productId": 188 },
    { "quantity": 50, "unitValue": 7.00, "batch": "LOTH0I4J8K3", "brand": "Supermax", "expiryDate": "2029-07-11", "productId": 146 },
    { "quantity": 50, "unitValue": 6.90, "batch": "LOTL5M9N3O7", "brand": "Supermax", "expiryDate": "2029-07-11", "productId": 145 },
    { "quantity": 50, "unitValue": 6.70, "batch": "LOTP1Q5R9S2", "brand": "Supermax", "expiryDate": "2029-07-11", "productId": 144 },
    { "quantity": 100, "unitValue": 0.95, "batch": "LOTT6U0V4W8", "brand": "Uniqmed", "expiryDate": "2028-03-29", "productId": 275 }
  ]
}

{
  -- /api/stock/create-adjustment
  "type": 2,
  "reason": "Perda",
  "observation": "",
  "adjustmentDate": "2024-10-09T15:45:23.000Z",
  "responsibleId": 6,
  "accountId": 6,
  "adjustmentItems": [
    { "productId": 175, "quantity": 30, "batch": "LOTY6U7I8O", "brand": "Medfio", "expiryDate": "2028-02-28", "unitValue": 1.50 },
    { "productId": 232, "quantity": 30, "batch": "LOTP9L8K7J", "brand": "Medix", "expiryDate": "2029-08-08", "unitValue": 3.90 },
    { "productId": 169, "quantity": 3, "batch": "LOTQ5W6E7R8", "brand": "3M", "expiryDate": "2028-06-05", "unitValue": 0.22 },
    { "productId": 305, "quantity": 2, "batch": "LOTY9T8R7E6", "brand": "Supermax", "expiryDate": "2027-12-01", "unitValue": 0.60 }
  ]
}

{
  "invoiceNumber": "834710",
  "supplyAuthorization": "AF 2024/304567",
  "observation": "",
  "receivingDate": "2024-10-14T11:12:13.000Z",
  "supplierId": 60,
  -- Material de Apoio e Administrativo
  "responsibleId": 10,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 10, "unitValue": 297.50, "batch": "LOTV6W7X8Y", "brand": "Chamex", "expiryDate": "2028-06-19", "productId": 198 },
    { "quantity": 5, "unitValue": 6.70, "batch": "LOTH5I6J7K", "brand": "CIS", "expiryDate": "2029-04-03", "productId": 217 },
    { "quantity": 5, "unitValue": 40.83, "batch": "LOTL8M9N0P", "brand": "Bic", "expiryDate": "2030-05-11", "productId": 213 },
    { "quantity": 10, "unitValue": 9.75, "batch": "LOTA9A0B1C", "brand": "Vonder", "expiryDate": "2027-09-28", "productId": 294 },
    { "quantity": 5, "unitValue": 15.50, "batch": "LOTQ1R2S3T", "brand": "Force Line", "expiryDate": "2026-12-24", "productId": 135 },
    { "quantity": 100, "unitValue": 41.20, "batch": "LOTU4W6W6X", "brand": "3M", "expiryDate": "2027-02-06", "productId": 295 },
    { "quantity": 10, "unitValue": 35.80, "batch": "LOTP7Z8B9B", "brand": "Bic", "expiryDate": "2028-03-21", "productId": 211 },
    { "quantity": 5, "unitValue": 38.85, "batch": "LOTD5E1F4F", "brand": "Bic", "expiryDate": "2028-12-30", "productId": 212 },
    { "quantity": 25, "unitValue": 28.10, "batch": "LOTC0D1E7U", "brand": "Mercur", "expiryDate": "2029-10-01", "productId": 215 },
    { "quantity": 250, "unitValue": 25.45, "batch": "LOTA9H4I5J", "brand": "DXM Print", "expiryDate": "2030-04-29", "productId": 190 }
  ]
}

{
  "invoiceNumber": "246802",
  "supplyAuthorization": "AF 2024/009009",
  "observation": "",
  "receivingDate": "2024-10-21T08:42:12.000Z",
  "supplierId": 60,
  "responsibleId": 12,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 500, "unitValue": 0.20, "batch": "LOTE1R2T3Y4", "brand": "Descarpack", "expiryDate": "2026-09-01", "productId": 341 },
    { "quantity": 800, "unitValue": 0.08, "batch": "LOTU5I6O7P8", "brand": "Medix", "expiryDate": "2027-01-10", "productId": 338 },
    { "quantity": 120, "unitValue": 0.15, "batch": "LOTA9S0D1F2", "brand": "Talge", "expiryDate": "2027-05-25", "productId": 339 },
    { "quantity": 300, "unitValue": 0.55, "batch": "LOTG3H4J5K6", "brand": "Clorhex", "expiryDate": "2028-04-12", "productId": 265 },
    { "quantity": 300, "unitValue": 0.65, "batch": "LOTL7M8N9B0", "brand": "Vic Pharma", "expiryDate": "2028-05-18", "productId": 266 },
    { "quantity": 50, "unitValue": 25.00, "batch": "LOTV1C2X3Z4", "brand": "Techline", "expiryDate": "2030-01-01", "productId": 187 },
    { "quantity": 5, "unitValue": 15.00, "batch": "LOTQ5W6E7R8", "brand": "Geratherm", "expiryDate": "2030-02-01", "productId": 188 },
    { "quantity": 50, "unitValue": 0.18, "batch": "LOTT9Y0U1I2", "brand": "Guedel", "expiryDate": "2029-03-03", "productId": 329 },
    { "quantity": 50, "unitValue": 0.20, "batch": "LOTO3P4A5S6", "brand": "Embramed", "expiryDate": "2029-04-04", "productId": 325 },
    { "quantity": 50, "unitValue": 0.15, "batch": "LOTD7F8G9H0", "brand": "Descarpack", "expiryDate": "2029-05-05", "productId": 345 },
    { "quantity": 50, "unitValue": 0.16, "batch": "LOTJ1K2L3M4", "brand": "Guedel", "expiryDate": "2029-06-06", "productId": 346 }
  ]
}

{
  "invoiceNumber": "005391",
  "supplyAuthorization": "AF 2024/000214",
  "observation": "",
  "receivingDate": "2024-11-05T11:20:58.000Z",
  "supplierId": 49,
  "responsibleId": 4,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 100, "unitValue": 0.90, "batch": "LOTX5Z6Q7W8", "brand": "Descarpack", "expiryDate": "2029-09-01", "productId": 175 },
    { "quantity": 500, "unitValue": 0.05, "batch": "LOTE9R0T1Y2", "brand": "Medix", "expiryDate": "2030-04-04", "productId": 334 },
    { "quantity": 100, "unitValue": 0.35, "batch": "LOTU3I4O5P6", "brand": "Injex", "expiryDate": "2030-05-15", "productId": 163 },
    { "quantity": 100, "unitValue": 20.12, "batch": "LOTA7S8D9F0", "brand": "BD", "expiryDate": "2029-11-20", "productId": 284 },
    { "quantity": 150, "unitValue": 1.15, "batch": "LOTG1H2J3K4", "brand": "Unigloves", "expiryDate": "2028-04-01", "productId": 374 },
    { "quantity": 100, "unitValue": 1.05, "batch": "LOTL5M6N7B8", "brand": "Supermax", "expiryDate": "2028-05-05", "productId": 375 },
    { "quantity": 150, "unitValue": 1.50, "batch": "LOTV9C0X1Z2", "brand": "Kolplast", "expiryDate": "2029-01-01", "productId": 376 },
    { "quantity": 150, "unitValue": 1.40, "batch": "LOTQ3W4E5R6", "brand": "Kolplast", "expiryDate": "2029-02-01", "productId": 377 }
  ]
}

{
  "invoiceNumber": "127856",
  "supplyAuthorization": "AF 2024/001099",
  "observation": "",
  "receivingDate": "2024-11-25T14:42:01.000Z",
  "supplierId": 4,
  "responsibleId": 11,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 1100, "unitValue": 0.95, "batch": "LOT2D5F0E4B", "brand": "Neo Química", "expiryDate": "2027-03-18", "productId": 222 },
    { "quantity": 850, "unitValue": 1.30, "batch": "LOT7E3C1B2A", "brand": "Sanofi", "expiryDate": "2029-12-05", "productId": 50 },
    { "quantity": 400, "unitValue": 0.22, "batch": "LOT8F0A2C9D", "brand": "Hypera Pharma", "expiryDate": "2026-08-08", "productId": 91 },
    { "quantity": 850, "unitValue": 0.49, "batch": "LOT5A6B3D4F", "brand": "Bayer", "expiryDate": "2030-01-28", "productId": 105 },
    { "quantity": 750, "unitValue": 3.15, "batch": "LOTD9C4A1B2", "brand": "Libbs", "expiryDate": "2028-07-04", "productId": 28 },
    { "quantity": 550, "unitValue": 0.77, "batch": "LOTF1A3B5C7", "brand": "Pfizer", "expiryDate": "2027-10-31", "productId": 89 }
  ]
}

{
  "invoiceNumber": "315622",
  "supplyAuthorization": "AF 2024/400987",
  "observation": "",
  "receivingDate": "2024-11-26T10:14:26.000Z",
  "supplierId": 14,
  "responsibleId": 10,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 2500, "unitValue": 0.18, "batch": "LOTP2Q7S3W", "brand": "Cimed", "expiryDate": "2028-04-18", "productId": 97 },
    { "quantity": 1800, "unitValue": 0.55, "batch": "LOTJ5T8U1I", "brand": "Medley", "expiryDate": "2027-08-30", "productId": 38 },
    { "quantity": 1500, "unitValue": 1.60, "batch": "LOTN3V6Y2E", "brand": "Neo Química", "expiryDate": "2026-12-05", "productId": 29 },
    { "quantity": 1500, "unitValue": 2.20, "batch": "LOTC1D4F9H", "brand": "Sanofi", "expiryDate": "2029-05-14", "productId": 37 },
    { "quantity": 850, "unitValue": 3.90, "batch": "LOTE8G2K5Z", "brand": "EMS", "expiryDate": "2027-02-28", "productId": 90 },
    { "quantity": 550, "unitValue": 0.95, "batch": "LOTB7L5M3X", "brand": "Eurofarma", "expiryDate": "2028-11-17", "productId": 227 }
  ]
}

{
  "invoiceNumber": "501927",
  "supplyAuthorization": "AF 2024/230987",
  "observation": "",
  "receivingDate": "2024-11-27T08:32:15.000Z",
  "supplierId": 4,
  "responsibleId": 12,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 1000, "unitValue": 2.30, "batch": "LOTF0E9D8C7", "brand": "Roche", "expiryDate": "2026-04-03", "productId": 131 },
    { "quantity": 1700, "unitValue": 0.45, "batch": "LOTA1B2C3D4", "brand": "Herz", "expiryDate": "2028-12-30", "productId": 92 },
    { "quantity": 2100, "unitValue": 0.14, "batch": "LOT5E6F7A8B", "brand": "União Química", "expiryDate": "2027-07-11", "productId": 103 },
    { "quantity": 1000, "unitValue": 0.80, "batch": "LOT9D0E1F2A", "brand": "Farmasa", "expiryDate": "2029-04-26", "productId": 11 }
  ]
}

-- ----------------------------------------------------------------------------------------------------------------------------------
-- 2025
{
  "invoiceNumber": "820356",
  "supplyAuthorization": "AF 2025/109876",
  "observation": "",
  "receivingDate": "2025-01-06T12:03:51.000Z",
  "supplierId": 57,
  "responsibleId": 10,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 1550, "unitValue": 1.10, "batch": "LOT8D7C6B5A", "brand": "Cristália", "expiryDate": "2027-08-01", "productId": 6 },
    { "quantity": 1700, "unitValue": 0.60, "batch": "LOT5B3H4D5E", "brand": "Glenmark", "expiryDate": "2028-05-04", "productId": 248 },
    { "quantity": 1250, "unitValue": 0.95, "batch": "LOT6A7B8C9D", "brand": "Brainfarma", "expiryDate": "2029-01-20", "productId": 5 },
    { "quantity": 1750, "unitValue": 0.35, "batch": "LOT0F1E2D3C", "brand": "Torrent", "expiryDate": "2026-11-16", "productId": 30 },
    { "quantity": 1400, "unitValue": 1.50, "batch": "LOT4B5C6D7E", "brand": "Germed", "expiryDate": "2028-03-27", "productId": 16 },
    { "quantity": 1600, "unitValue": 0.77, "batch": "LOT8C9D0E1F", "brand": "Wyeth", "expiryDate": "2030-04-01", "productId": 126 },
    { "quantity": 2000, "unitValue": 0.40, "batch": "LOT1D2E3F4A", "brand": "Bristol-Myers Squibb", "expiryDate": "2027-02-23", "productId": 80 },
    { "quantity": 750, "unitValue": 2.15, "batch": "LOT5B6C7D8E", "brand": "Boehringer Ingelheim", "expiryDate": "2029-09-08", "productId": 118 },
    { "quantity": 1500, "unitValue": 0.22, "batch": "LOT9F0A1B2C", "brand": "Genom", "expiryDate": "2028-10-15", "productId": 40 },
    { "quantity": 1250, "unitValue": 0.55, "batch": "LOT3A4B5C6D", "brand": "Merck", "expiryDate": "2026-05-29", "productId": 138 },
    { "quantity": 1950, "unitValue": 0.89, "batch": "LOT7E8F9A0B", "brand": "Biolab", "expiryDate": "2027-10-12", "productId": 13 },
    { "quantity": 700, "unitValue": 1.20, "batch": "LOTC1D2E3F4", "brand": "Cimed", "expiryDate": "2029-03-24", "productId": 121 },
    { "quantity": 1700, "unitValue": 0.65, "batch": "LOT5F6A7B8C", "brand": "AstraZeneca", "expiryDate": "2028-07-07", "productId": 56 },
    { "quantity": 1000, "unitValue": 0.15, "batch": "LOT9D8C7B6A", "brand": "Teva", "expiryDate": "2027-04-19", "productId": 82 },
    { "quantity": 850, "unitValue": 0.75, "batch": "LOT6B9E4D5G", "brand": "Novamed", "expiryDate": "2029-12-01", "productId": 114 }
  ]
}

{
  "invoiceNumber": "900418",
  "supplyAuthorization": "AF 2025/765012",
  "observation": "Prioridade de armazenamento.",
  "receivingDate": "2025-01-09T13:15:42.000Z",
  "supplierId": 3,
  "responsibleId": 11,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 2100, "unitValue": 0.70, "batch": "LOT1E2F3A4B", "brand": "Hypera Pharma", "expiryDate": "2028-02-19", "productId": 3 },
    { "quantity": 800, "unitValue": 1.90, "batch": "LOT5C6D7E8F", "brand": "Medley", "expiryDate": "2029-07-03", "productId": 127 },
    { "quantity": 900, "unitValue": 0.33, "batch": "LOT9A0B1C2D", "brand": "EMS", "expiryDate": "2027-11-20", "productId": 70 },
    { "quantity": 1200, "unitValue": 0.68, "batch": "LOT3D4E5F6A", "brand": "Eurofarma", "expiryDate": "2026-09-05", "productId": 47 },
    { "quantity": 250, "unitValue": 0.11, "batch": "LOT7B8C9D0E", "brand": "Ache", "expiryDate": "2030-02-14", "productId": 43 },
    { "quantity": 1100, "unitValue": 0.45, "batch": "LOTF1A2B3C4", "brand": "Bayer", "expiryDate": "2028-04-28", "productId": 113 },
    { "quantity": 1000, "unitValue": 1.35, "batch": "LOT6E7F8A9B", "brand": "Libbs", "expiryDate": "2027-01-08", "productId": 94 },
    { "quantity": 1650, "unitValue": 0.52, "batch": "LOT0C1D2E3F", "brand": "Novartis", "expiryDate": "2029-10-23", "productId": 72 },
    { "quantity": 750, "unitValue": 0.25, "batch": "LOT4G5B6C8D", "brand": "Takeda", "expiryDate": "2026-12-10", "productId": 12 }
  ]
}

{
  "invoiceNumber": "555111",
  "supplyAuthorization": "AF 2025/008080",
  "observation": "",
  "receivingDate": "2025-01-15T10:53:26.000Z",
  "supplierId": 7,
  "responsibleId": 10,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 1500, "unitValue": 3.40, "batch": "LOT3R1S9T7", "brand": "Cristália", "expiryDate": "2029-10-24", "productId": 19 },
    { "quantity": 900, "unitValue": 0.85, "batch": "LOT2U0V8W6", "brand": "Eurofarma", "expiryDate": "2028-12-15", "productId": 114 },
    { "quantity": 900, "unitValue": 5.20, "batch": "LOT1X9Y7Z5", "brand": "Novartis", "expiryDate": "2027-09-02", "productId": 134 }
  ]
}

{
  "invoiceNumber": "391745",
  "supplyAuthorization": "AF 2025/008005",
  "observation": "Itens frágeis, armazenar com cuidado.",
  "receivingDate": "2025-01-27T10:41:14.000Z",
  "supplierId": 1,
  "responsibleId": 12,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 150, "unitValue": 0.18, "batch": "LOTX6Y0Z4A8", "brand": "Descarpack", "expiryDate": "2028-02-05", "productId": 171 },
    { "quantity": 150, "unitValue": 1.25, "batch": "LOTB3C7D1E5", "brand": "Solidor", "expiryDate": "2026-04-30", "productId": 386 },
    { "quantity": 150, "unitValue": 1.80, "batch": "LOTF8G2H6I0", "brand": "Solidor", "expiryDate": "2026-04-30", "productId": 388 },
    { "quantity": 50, "unitValue": 5.20, "batch": "LOTJ4K8L2M6", "brand": "Portex", "expiryDate": "2029-11-15", "productId": 390 },
    { "quantity": 100, "unitValue": 4.80, "batch": "LOTN0O4P8Q1", "brand": "Portex", "expiryDate": "2029-11-15", "productId": 389 },
    { "quantity": 450, "unitValue": 5.35, "batch": "LOTR5S9T3U7", "brand": "Descarpack", "expiryDate": "2027-07-09", "productId": 298 },
    { "quantity": 45, "unitValue": 0.35, "batch": "LOTV1W5X9Y3", "brand": "Descarpack", "expiryDate": "2027-07-09", "productId": 345 },
    { "quantity": 50, "unitValue": 0.40, "batch": "LOTZ6A0B4C8", "brand": "Descarpack", "expiryDate": "2027-07-09", "productId": 329 },
    { "quantity": 200, "unitValue": 15.00, "batch": "LOTB5C9D3E7", "brand": "GMI", "expiryDate": "2027-02-13", "productId": 233 },
    { "quantity": 45, "unitValue": 0.45, "batch": "LOTD2E6F0G4", "brand": "Descarpack", "expiryDate": "2027-07-09", "productId": 325 }
  ]
}

{
  "invoiceNumber": "881304",
  "supplyAuthorization": "AF 2025/802917",
  "observation": "",
  "receivingDate": "2025-01-27T14:35:57.000Z",
  "supplierId": 21,
  "responsibleId": 10,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 1000, "unitValue": 3.10, "batch": "LOT4A1B2C3", "brand": "Aché", "expiryDate": "2029-03-22", "productId": 30 },
    { "quantity": 500, "unitValue": 5.50, "batch": "LOT7D8E9F0", "brand": "Bayer", "expiryDate": "2028-06-01", "productId": 70 },
    { "quantity": 750, "unitValue": 0.45, "batch": "LOT1G2H3I4", "brand": "Pfizer", "expiryDate": "2027-01-08", "productId": 42 },
    { "quantity": 1100, "unitValue": 1.70, "batch": "LOT5J6K7L8", "brand": "Bristol-Myers Squibb", "expiryDate": "2026-10-19", "productId": 94 }
  ]
}

{
  "invoiceNumber": "884103",
  "supplyAuthorization": "AF 2025/009001",
  "observation": "",
  "receivingDate": "2025-01-30T09:46:37.000Z",
  "supplierId": 14,
  "responsibleId": 2,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 1200, "unitValue": 0.88, "batch": "LOTD2C4E6F8", "brand": "Labor Import", "expiryDate": "2029-01-25", "productId": 178 },
    { "quantity": 900, "unitValue": 0.95, "batch": "LOT7A3F6D2C", "brand": "Mediglove", "expiryDate": "2027-09-09", "productId": 323 },
    { "quantity": 300, "unitValue": 1.30, "batch": "LOT5B8D1C4A", "brand": "Solidor", "expiryDate": "2028-04-18", "productId": 275 },
    { "quantity": 2100, "unitValue": 0.35, "batch": "LOT1E6B9D5F", "brand": "BD", "expiryDate": "2030-03-03", "productId": 76 }
  ]
}

{
  "invoiceNumber": "720054",
  "supplyAuthorization": "AF 2025/006020",
  "observation": "",
  "receivingDate": "2025-02-10T15:46:38.000Z",
  "supplierId": 18,
  "responsibleId": 9,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 1100, "unitValue": 1.99, "batch": "LOT2B7E5A0C", "brand": "Cimed", "expiryDate": "2028-04-12", "productId": 17 },
    { "quantity": 650, "unitValue": 0.55, "batch": "LOT5D3C1F6B", "brand": "Takeda", "expiryDate": "2029-05-09", "productId": 117 },
    { "quantity": 800, "unitValue": 4.50, "batch": "LOT9A1B2C3D", "brand": "Cristália", "expiryDate": "2026-03-29", "productId": 18 },
    { "quantity": 1200, "unitValue": 0.72, "batch": "LOTF4E3D2C1", "brand": "Glenmark", "expiryDate": "2027-12-19", "productId": 61 },
    { "quantity": 1400, "unitValue": 0.15, "batch": "LOT3C4D5E6F", "brand": "Brainfarma", "expiryDate": "2028-08-22", "productId": 42 },
    { "quantity": 1350, "unitValue": 1.25, "batch": "LOT7A8B9C0D", "brand": "Torrent", "expiryDate": "2029-03-03", "productId": 102 },
    { "quantity": 2200, "unitValue": 0.38, "batch": "LOTE1F2A3B4", "brand": "Germed", "expiryDate": "2027-01-14", "productId": 2 }
  ]
}

{
  "invoiceNumber": "940516",
  "supplyAuthorization": "AF 2025/803472",
  "observation": "Itens frágeis, armazenar com cuidado.",
  "receivingDate": "2025-02-14T13:14:15.000Z",
  "supplierId": 60,
  "responsibleId": 10,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 1350, "unitValue": 0.42, "batch": "LOT5F6A7B8C", "brand": "AstraZeneca", "expiryDate": "2027-04-24", "productId": 29 },
    { "quantity": 1150, "unitValue": 1.15, "batch": "LOT9D8C7B6A", "brand": "Teva", "expiryDate": "2029-11-13", "productId": 124 },
    { "quantity": 2300, "unitValue": 0.28, "batch": "LOT1A2B3C4D", "brand": "Novamed", "expiryDate": "2028-10-01", "productId": 30 },
    { "quantity": 950, "unitValue": 0.99, "batch": "LOT4E5F6A7B", "brand": "Lundbeck", "expiryDate": "2026-07-27", "productId": 140 },
    { "quantity": 1050, "unitValue": 3.75, "batch": "LOT8C9D0E1F", "brand": "Janssen", "expiryDate": "2030-03-09", "productId": 134 },
    { "quantity": 1550, "unitValue": 0.60, "batch": "LOT7B3C4G5E", "brand": "Alcon", "expiryDate": "2027-09-17", "productId": 105 },
    { "quantity": 2050, "unitValue": 0.10, "batch": "LOT6A7B8C9D", "brand": "Biosintética", "expiryDate": "2028-01-05", "productId": 39 },
    { "quantity": 1450, "unitValue": 0.50, "batch": "LOT0F1A2B3C", "brand": "Multilab", "expiryDate": "2029-06-16", "productId": 7 }
  ]
}

{
  "invoiceNumber": "637840",
  "supplyAuthorization": "AF 2025/556789",
  "observation": "",
  "receivingDate": "2025-02-14T15:37:26.000Z",
  "supplierId": 22,
  "responsibleId": 9,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 85, "unitValue": 1.55, "batch": "LOTX1G7F2Z5", "brand": "3M", "expiryDate": "2028-05-21", "productId": 145 },
    { "quantity": 850, "unitValue": 0.88, "batch": "LOTH8A4P3R9", "brand": "Descarpack", "expiryDate": "2027-01-15", "productId": 115 },
    { "quantity": 1500, "unitValue": 2.10, "batch": "LOTC2B5J6M7", "brand": "Embramed", "expiryDate": "2029-11-04", "productId": 96 },
    { "quantity": 400, "unitValue": 15.75, "batch": "LOTK9E0D1Y4", "brand": "Kolplast", "expiryDate": "2026-03-29", "productId": 377 },
    { "quantity": 500, "unitValue": 0.45, "batch": "LOTY4M1B0S8", "brand": "Vita Medical", "expiryDate": "2027-05-03", "productId": 338 },
    { "quantity": 250, "unitValue": 0.95, "batch": "LOTS3V6T8U2", "brand": "Medix", "expiryDate": "2030-08-10", "productId": 369 },
    { "quantity": 1100, "unitValue": 1.20, "batch": "LOTN5L2A0H6", "brand": "BD", "expiryDate": "2027-07-01", "productId": 160 },
    { "quantity": 600, "unitValue": 2.99, "batch": "LOTQ7Z3X8C1", "brand": "Solidor", "expiryDate": "28-04-18", "productId": 164 }
  ]
}

{
  "invoiceNumber": "748120",
  "supplyAuthorization": "AF 2025/004455",
  "observation": "Entrega de emergência.",
  "receivingDate": "2025-02-18T15:12:35.000Z",
  "supplierId": 3,
  "responsibleId": 12,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 500, "unitValue": 3.75, "batch": "LOTF6D9C0B3", "brand": "Cirúrgica", "expiryDate": "2026-10-10", "productId": 150 },
    { "quantity": 150, "unitValue": 2.15, "batch": "LOT2B7D4E1A", "brand": "Uniqmed", "expiryDate": "2027-02-28", "productId": 65 },
    { "quantity": 45, "unitValue": 0.40, "batch": "LOT3C0A9B4E", "brand": "Kolplast", "expiryDate": "2028-06-19", "productId": 346 },
    { "quantity": 5, "unitValue": 15.00, "batch": "LOT4E9D6C1B", "brand": "Promed", "expiryDate": "2027-01-07", "productId": 188 }
  ]
}

{
  "invoiceNumber": "210987",
  "supplyAuthorization": "AF 2025/007320",
  "observation": "",
  "receivingDate": "2025-02-19T09:35:20.000Z",
  "supplierId": 28,
  "responsibleId": 5,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 750, "unitValue": 1.12, "batch": "LOT8A5F2D9C", "brand": "Duflex", "expiryDate": "2029-12-05", "productId": 391 },
    { "quantity": 1250, "unitValue": 1.10, "batch": "LOTG1B8C5E2", "brand": "Olen", "expiryDate": "2028-07-22", "productId": 17 },
    { "quantity": 50, "unitValue": 0.55, "batch": "LOT9D2F7A0C", "brand": "Procare", "expiryDate": "2029-05-11", "productId": 142 },
    { "quantity": 1600, "unitValue": 0.75, "batch": "LOTH6E3D1B5", "brand": "Holder", "expiryDate": "2027-03-30", "productId": 157 },
    { "quantity": 140, "unitValue": 1.05, "batch": "LOT2C5B8A3D", "brand": "Steri", "expiryDate": "2026-06-04", "productId": 332 },
    { "quantity": 1200, "unitValue": 0.22, "batch": "LOT0A7D4C6F", "brand": "Inje", "expiryDate": "2030-01-14", "productId": 163 },
    { "quantity": 400, "unitValue": 4.50, "batch": "LOTC8F3A1D6", "brand": "Portex", "expiryDate": "2027-07-07", "productId": 390 },
    { "quantity": 250, "unitValue": 1.90, "batch": "LOT5B2E9D4A", "brand": "Opti", "expiryDate": "2028-09-08", "productId": 388 }
  ]
}

{
  -- /api/stock/create-adjustment
  "type": 1,
  "reason": "Doação",
  "observation": "",
  "adjustmentDate": "2025-02-19T15:43:27.000Z",
  "responsibleId": 6,
  "accountId": 6,
  "adjustmentItems": [
    { "productId": 357, "quantity": 5, "batch": "LOT3FR6TGY7T", "brand": "MedSonda", "expiryDate": "2027-02-15", "unitValue": 2.25 },
    { "productId": 352, "quantity": 3, "batch": "LOT3W5S6RP8T", "brand": "Embramed", "expiryDate": "2026-05-30", "unitValue": 1.95 },
    { "productId": 355, "quantity": 7, "batch": "LOT4M4H6GU7I", "brand": "MedSonda", "expiryDate": "2026-09-21", "unitValue": 2.39 },
    { "productId": 353, "quantity": 2, "batch": "LOT7E5B5GY9S", "brand": "Embramed", "expiryDate": "2026-12-27", "unitValue": 2.99 }
  ]
}

{
  "invoiceNumber": "901234",
  "supplyAuthorization": "AF 2025/006006",
  "observation": "",
  "receivingDate": "2025-02-28T13:10:47.000Z",
  "supplierId": 24,
  "responsibleId": 7,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 10, "unitValue": 55.00, "batch": "LOTG2B7D4E1", "brand": "G-Tech", "expiryDate": "2026-03-15", "productId": 272 },
    { "quantity": 200, "unitValue": 0.99, "batch": "LOT4H1J8K6L", "brand": "Descarpack", "expiryDate": "2029-09-01", "productId": 282 },
    { "quantity": 450, "unitValue": 1.25, "batch": "LOT3M6N9P2Q", "brand": "Solidor", "expiryDate": "2027-10-23", "productId": 324 },
    { "quantity": 400, "unitValue": 0.50, "batch": "LOT7R0S5T8U", "brand": "Medix", "expiryDate": "2028-01-08", "productId": 341 },
    { "quantity": 500, "unitValue": 0.77, "batch": "LOT1V4W9X3Y", "brand": "Cremer", "expiryDate": "2030-05-27", "productId": 171 },
    { "quantity": 600, "unitValue": 0.15, "batch": "LOT5Z8A2B6C", "brand": "Opti", "expiryDate": "2027-04-19", "productId": 159 },
    { "quantity": 700, "unitValue": 0.85, "batch": "LOT0D3E7F4G", "brand": "BD", "expiryDate": "2029-10-31", "productId": 347 },
    { "quantity": 50, "unitValue": 0.33, "batch": "LOT6H9J2K5L", "brand": "Descarpack", "expiryDate": "2028-08-05", "productId": 345 },
    { "quantity": 900, "unitValue": 2.15, "batch": "LOTM0N3P7Q1", "brand": "Mediglove", "expiryDate": "2026-07-11", "productId": 283 }
  ]
}

{
  "invoiceNumber": "802468",
  "supplyAuthorization": "AF 2025/010010",
  "observation": "",
  "receivingDate": "2025-03-05T12:38:14.000Z",
  "supplierId": 25,
  "responsibleId": 11,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 25, "unitValue": 18.00, "batch": "LOTR7H5X4C2", "brand": "Medical", "expiryDate": "2027-04-05", "productId": 277 },
    { "quantity": 250, "unitValue": 35.00, "batch": "LOTD1Z9J0P7", "brand": "Medsonda", "expiryDate": "2026-08-28", "productId": 316 },
    { "quantity": 900, "unitValue": 0.85, "batch": "LOTB4N2K8M5", "brand": "Cremer", "expiryDate": "2029-01-18", "productId": 367 },
    { "quantity": 1100, "unitValue": 1.15, "batch": "LOTJ6Q0S3E9", "brand": "SR", "expiryDate": "2028-03-07", "productId": 349 },
    { "quantity": 1050, "unitValue": 0.78, "batch": "LOTF8W1A7R4", "brand": "Protec", "expiryDate": "2027-09-22", "productId": 157 },
    { "quantity": 5, "unitValue": 28.50, "batch": "LOTP6F9W4E3", "brand": "Oftalmos", "expiryDate": "2029-02-09", "productId": 272 },
    { "quantity": 750, "unitValue": 2.45, "batch": "LOTG3V5Y6T0", "brand": "Wexford", "expiryDate": "2030-06-11", "productId": 343 },
    { "quantity": 600, "unitValue": 1.90, "batch": "LOTL2H9P4J1", "brand": "Solidor", "expiryDate": "2026-11-03", "productId": 175 },
    { "quantity": 400, "unitValue": 0.20, "batch": "LOTM5B0S3Q7", "brand": "Missner", "expiryDate": "2029-05-14", "productId": 341 },
    { "quantity": 150, "unitValue": 22.00, "batch": "LOTK1C6D9F3", "brand": "Becton Dickinson", "expiryDate": "2027-10-08", "productId": 333 }
  ]
}

{
  "invoiceNumber": "601579",
  "supplyAuthorization": "AF 2025/003152",
  "observation": "",
  "receivingDate": "2025-04-14T11:45:20.000Z",
  "supplierId": 25,
  "responsibleId": 11,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 500, "unitValue": 0.68, "batch": "LOTU3V6W9X1", "brand": "3M", "expiryDate": "2028-02-04", "productId": 144 },
    { "quantity": 25, "unitValue": 10.50, "batch": "LOTP0Q4R7S2", "brand": "Oftalmos", "expiryDate": "2027-05-19", "productId": 176 },
    { "quantity": 1100, "unitValue": 0.92, "batch": "LOTZ7C1B5N8", "brand": "Viopa", "expiryDate": "2030-11-25", "productId": 161 },
    { "quantity": 1000, "unitValue": 0.30, "batch": "LOTD6F8G0H3", "brand": "Descarpack", "expiryDate": "2026-04-01", "productId": 340 },
    { "quantity": 800, "unitValue": 1.40, "batch": "LOTJ9K2L5M7", "brand": "Solidor", "expiryDate": "2029-01-31", "productId": 180 },
    { "quantity": 450, "unitValue": 2.20, "batch": "LOTI1O3P6Q9", "brand": "Embramed", "expiryDate": "2028-08-07", "productId": 156 },
    { "quantity": 1200, "unitValue": 0.77, "batch": "LOTE4A7B0C5", "brand": "Cremer", "expiryDate": "2027-10-20", "productId": 75 },
    { "quantity": 300, "unitValue": 75.50, "batch": "LOTG6X9Y2Z4", "brand": "Kolplast", "expiryDate": "2029-06-15", "productId": 301 },
    { "quantity": 400, "unitValue": 0.18, "batch": "LOTM0R5S8T3", "brand": "Missner", "expiryDate": "2030-03-09", "productId": 341 },
    { "quantity": 50, "unitValue": 3.50, "batch": "LOTK8N1J4L6", "brand": "Procare", "expiryDate": "2026-12-01", "productId": 305 },
    { "quantity": 50, "unitValue": 9.20, "batch": "LOTF3D6G9H2", "brand": "Medix", "expiryDate": "2028-05-12", "productId": 262 },
    { "quantity": 130, "unitValue": 2.00, "batch": "LOTC5W8T1U4", "brand": "B. Braun", "expiryDate": "2027-07-28", "productId": 392 },
    { "quantity": 250, "unitValue": 0.50, "batch": "LOTA2Z4Y7X9", "brand": "SR", "expiryDate": "2029-10-18", "productId": 171 },
    { "quantity": 100, "unitValue": 7.50, "batch": "LOTB5E8R0Q3", "brand": "3M", "expiryDate": "2026-09-06", "productId": 169 },
    { "quantity": 1600, "unitValue": 0.45, "batch": "LOTS9T2U5V8", "brand": "BD", "expiryDate": "2030-05-23", "productId": 338 }
  ]
}

{
  "invoiceNumber": "550019",
  "supplyAuthorization": "AF 2025/678901",
  "observation": "Itens frágeis, manuseio cuidadoso.",
  "receivingDate": "2025-04-25T14:36:07.000Z",
  "supplierId": 24,
  "responsibleId": 5,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 200, "unitValue": 3.50, "batch": "LOTX9Y1Z3A5", "brand": "MedSonda", "expiryDate": "2028-04-01", "productId": 147 },
    { "quantity": 150, "unitValue": 2.80, "batch": "LOTB6C8D0E2", "brand": "Solidor", "expiryDate": "2027-06-18", "productId": 366 },
    { "quantity": 500, "unitValue": 1.90, "batch": "LOTF3G5H7I9", "brand": "Sterilex", "expiryDate": "2029-03-09", "productId": 354 },
    { "quantity": 50, "unitValue": 18.00, "batch": "LOTJ0K2L4M6", "brand": "Descarpak", "expiryDate": "2026-12-07", "productId": 308 },
    { "quantity": 300, "unitValue": 0.55, "batch": "LOTN1P3Q5R7", "brand": "Lutex", "expiryDate": "2030-05-21", "productId": 165 },
    { "quantity": 50, "unitValue": 6.70, "batch": "LOTT8U0V2W4", "brand": "Lifecare", "expiryDate": "2028-02-17", "productId": 386 },
    { "quantity": 450, "unitValue": 1.50, "batch": "LOTR1S3T5U7", "brand": "MedSonda", "expiryDate": "2028-11-20", "productId": 185 },
    { "quantity": 100, "unitValue": 3.30, "batch": "LOTC2D4E6F8", "brand": "MedCir", "expiryDate": "2027-07-25", "productId": 392 },
    { "quantity": 50, "unitValue": 2.50, "batch": "LOTI7J9K1L3", "brand": "MedSonda", "expiryDate": "2028-11-20", "productId": 325 },
    { "quantity": 150, "unitValue": 0.70, "batch": "LOTB0C1D2E3", "brand": "Embramed", "expiryDate": "2029-09-11", "productId": 360 },
    { "quantity": 50, "unitValue": 2.00, "batch": "LOTM4N6P8Q0", "brand": "MedSonda", "expiryDate": "2028-11-20", "productId": 329 },
    { "quantity": 200, "unitValue": 3.90, "batch": "LOTZ5A7B9C1", "brand": "Solidor", "expiryDate": "2027-05-01", "productId": 350 },
    { "quantity": 150, "unitValue": 1.00, "batch": "LOTJ8K9L0M1", "brand": "Embramed", "expiryDate": "2029-09-11", "productId": 362 }
  ]
}

{
  "invoiceNumber": "987123",
  "supplyAuthorization": "AF 2025/005678",
  "observation": "",
  "receivingDate": "2025-05-09T11:41:36.000Z",
  "supplierId": 3,
  "responsibleId": 11,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 450, "unitValue": 15.00, "batch": "LOT9M0N1P2", "brand": "Eli Lilly", "expiryDate": "2029-09-07", "productId": 12 },
    { "quantity": 300, "unitValue": 8.00, "batch": "LOT3Q4R5S6", "brand": "Roche", "expiryDate": "2028-05-11", "productId": 93 },
    { "quantity": 900, "unitValue": 1.90, "batch": "LOT7T8U9V0", "brand": "Teuto", "expiryDate": "2027-10-04", "productId": 110 },
    { "quantity": 580, "unitValue": 0.65, "batch": "LOT1W2X3Y4", "brand": "Torrent", "expiryDate": "2030-02-20", "productId": 55 },
    { "quantity": 450, "unitValue": 0.40, "batch": "LOT5Z6A7B8", "brand": "Genéricos", "expiryDate": "2026-07-03", "productId": 4 }
  ]
}

{
  "invoiceNumber": "459012",
  "supplyAuthorization": "AF 2025/001345",
  "observation": "Entrega parcial",
  "receivingDate": "2025-05-14T11:24:32.000Z",
  "supplierId": 46,
  "responsibleId": 5,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1150, "unitValue": 2.80, "batch": "LOT3L1M9N7", "brand": "Merck", "expiryDate": "2028-03-05", "productId": 56 },
    { "quantity": 1300, "unitValue": 0.70, "batch": "LOT2P0Q8R6", "brand": "Genom", "expiryDate": "2029-06-19", "productId": 49 },
    { "quantity": 900, "unitValue": 0.99, "batch": "LOT1S9T7U5", "brand": "GlaxoSmithKline", "expiryDate": "2027-07-07", "productId": 91 },
    { "quantity": 450, "unitValue": 1.40, "batch": "LOT0V8W6X4", "brand": "AstraZeneca", "expiryDate": "2026-02-14", "productId": 9 }
  ]
}

{
  "invoiceNumber": "872361",
  "supplyAuthorization": "AF 2025/402810",
  "observation": "Verificar embalagem danificada em 2 itens.",
  "receivingDate": "2025-05-23T14:42:21.000Z",
  "supplierId": 79,
  "responsibleId": 10,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 1400, "unitValue": 0.30, "batch": "LOT9Y7Z5A3", "brand": "Novartis", "expiryDate": "2028-10-31", "productId": 255 },
    { "quantity": 1600, "unitValue": 0.48, "batch": "LOT8B6C4D2", "brand": "Bayer", "expiryDate": "2027-12-09", "productId": 61 },
    { "quantity": 2100, "unitValue": 1.25, "batch": "LOT7E5F3G1", "brand": "Pfizer", "expiryDate": "2026-08-23", "productId": 119 },
    { "quantity": 1300, "unitValue": 0.72, "batch": "LOT6H4I2J0", "brand": "Cimed", "expiryDate": "2029-01-01", "productId": 123 },
    { "quantity": 1900, "unitValue": 0.90, "batch": "LOT5K3L1M9", "brand": "Medley", "expiryDate": "2030-03-17", "productId": 124 },
    { "quantity": 950, "unitValue": 0.55, "batch": "LOT4N2P0Q8", "brand": "Aché", "expiryDate": "2027-06-06", "productId": 120 }
  ]
}

{
  "invoiceNumber": "934567",
  "supplyAuthorization": "AF 2025/006811",
  "observation": "",
  "receivingDate": "2025-05-23T15:27:28.000Z",
  "supplierId": 57,
  "responsibleId": 9,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 850, "unitValue": 2.65, "batch": "LOTA8B7C6D", "brand": "Genom", "expiryDate": "2026-04-01", "productId": 117 },
    { "quantity": 450, "unitValue": 0.45, "batch": "LOTE3F2G1H", "brand": "Medley", "expiryDate": "2029-08-10", "productId": 240 },
    { "quantity": 850, "unitValue": 7.00, "batch": "LOTI9J8K7L", "brand": "Aché", "expiryDate": "2027-11-27", "productId": 118 },
    { "quantity": 1100, "unitValue": 0.77, "batch": "LOTM4N3P2Q", "brand": "Neo Química", "expiryDate": "2028-02-04", "productId": 79 },
    { "quantity": 750, "unitValue": 0.52, "batch": "LOTV2W1X0Y", "brand": "EMS", "expiryDate": "2029-11-06", "productId": 82 },
    { "quantity": 500, "unitValue": 9.10, "batch": "LOTZ5A4B3C", "brand": "Eurofarma", "expiryDate": "2028-09-22", "productId": 83 }
  ]
}

{
  "invoiceNumber": "748123",
  "supplyAuthorization": "AF 2025/998877",
  "observation": "",
  "receivingDate": "2025-06-17T08:49:12.000Z",
  "supplierId": 15,
  "responsibleId": 2,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 100, "unitValue": 1.30, "batch": "LOTN2P4Q6R8", "brand": "Hospitalar", "expiryDate": "2026-04-10", "productId": 380 },
    { "quantity": 100, "unitValue": 1.60, "batch": "LOTS9T1U3V5", "brand": "Hospitalar", "expiryDate": "2026-04-10", "productId": 381 },
    { "quantity": 25, "unitValue": 35.00, "batch": "LOTW6X8Y0Z2", "brand": "Sony", "expiryDate": "2029-01-31", "productId": 382 },
    { "quantity": 25, "unitValue": 18.00, "batch": "LOTA3B5C7D9", "brand": "Nihon Kohden", "expiryDate": "2028-09-05", "productId": 383 },
    { "quantity": 50, "unitValue": 45.00, "batch": "LOTE0F2G4H6", "brand": "Bionet", "expiryDate": "2027-12-12", "productId": 384 },
    { "quantity": 50, "unitValue": 1.00, "batch": "LOTV8W0X2Y4", "brand": "MedSonda", "expiryDate": "2028-11-20", "productId": 345 },
    { "quantity": 100, "unitValue": 3.10, "batch": "LOTY5Z7A9B1", "brand": "MedCir", "expiryDate": "2027-07-25", "productId": 391 },
    { "quantity": 50, "unitValue": 28.00, "batch": "LOTI1J3K5L7", "brand": "Medsul", "expiryDate": "2030-10-01", "productId": 374 },
    { "quantity": 50, "unitValue": 27.00, "batch": "LOTM8N0P2Q4", "brand": "Medsul", "expiryDate": "2030-10-01", "productId": 375 },
    { "quantity": 30, "unitValue": 55.00, "batch": "LOTR5S7T9U1", "brand": "Kolplast", "expiryDate": "2026-08-22", "productId": 377 }
  ]
}

{
  "invoiceNumber": "543210",
  "supplyAuthorization": "AF 2025/008008",
  "observation": "",
  "receivingDate": "2025-06-17T15:30:41.000Z",
  "supplierId": 18,
  "responsibleId": 10,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 900, "unitValue": 8.00, "batch": "LOTL5M1N6O8", "brand": "Germed", "expiryDate": "2029-02-20", "productId": 236 },
    { "quantity": 1300, "unitValue": 0.33, "batch": "LOTP2Q7R9S4", "brand": "Neo Química", "expiryDate": "2027-04-26", "productId": 47 },
    { "quantity": 1000, "unitValue": 1.99, "batch": "LOTT4U1V5W2", "brand": "Pfizer", "expiryDate": "2028-12-10", "productId": 61 },
    { "quantity": 700, "unitValue": 0.95, "batch": "LOTY8Z3A0B1", "brand": "Novartis", "expiryDate": "2026-07-03", "productId": 78 },
    { "quantity": 1600, "unitValue": 1.90, "batch": "LOTJ8C3D1E6", "brand": "Hypera Pharma", "expiryDate": "2029-05-18", "productId": 31 },
    { "quantity": 2200, "unitValue": 0.52, "batch": "LOTF4G0H9I5", "brand": "Blau", "expiryDate": "2026-11-29", "productId": 42 }
    { "quantity": 350, "unitValue": 0.20, "batch": "LOTC6D4E9F7", "brand": "Bayer", "expiryDate": "2030-04-16", "productId": 240 },
    { "quantity": 550, "unitValue": 3.75, "batch": "LOTG0H5I2J4", "brand": "Janssen", "expiryDate": "2027-11-23", "productId": 11 }
  ]
}

{
  "invoiceNumber": "850117",
  "supplyAuthorization": "AF 2025/003301",
  "observation": "",
  "receivingDate": "2025-06-26T14:45:35.000Z",
  "supplierId": 43,
  -- Material de Limpeza
  "responsibleId": 8,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 200, "unitValue": 30.70, "batch": "LOT9E52C9F8", "brand": "Rioquimica", "expiryDate": "2029-01-25", "productId": 183 },
    { "quantity": 50, "unitValue": 7.40, "batch": "LOTF6B0D5A3", "brand": "Tupi", "expiryDate": "2028-07-17", "productId": 192 },
    { "quantity": 450, "unitValue": 12.90, "batch": "LOT1A8C7F0E", "brand": "Prolink", "expiryDate": "2027-03-05", "productId": 106 },
    { "quantity": 750, "unitValue": 54.15, "batch": "LOT8D7E3B21", "brand": "Europapel", "expiryDate": "2030-10-02", "productId": 207 },
    { "quantity": 115, "unitValue": 21.15, "batch": "LOT5C4A9D66", "brand": "Nobre", "expiryDate": "2026-11-14", "productId": 196 }
  ]
}

{
  "invoiceNumber": "193847",
  "supplyAuthorization": "AF 2025/076041",
  "observation": "",
  "receivingDate": "2025-07-01T08:18:28.000Z",
  "supplierId": 33,
  "responsibleId": 9,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 1100, "unitValue": 0.90, "batch": "LOTR7S0T3U5", "brand": "Cremer", "expiryDate": "2027-04-20", "productId": 74 },
    { "quantity": 250, "unitValue": 0.82, "batch": "LOTE9F2G5H8", "brand": "Embramed", "expiryDate": "2028-09-07", "productId": 360 },
    { "quantity": 300, "unitValue": 1.45, "batch": "LOTD1Z4X7Y9", "brand": "Solidor", "expiryDate": "2030-12-01", "productId": 173 },
    { "quantity": 100, "unitValue": 18.00, "batch": "LOTP6Q9R2S4", "brand": "Viopa", "expiryDate": "2026-02-14", "productId": 279 },
    { "quantity": 200, "unitValue": 1.10, "batch": "LOTK3L6M9N1", "brand": "Medsonda", "expiryDate": "2029-06-25", "productId": 359 },
    { "quantity": 1200, "unitValue": 0.50, "batch": "LOTA8B1C4D6", "brand": "BD", "expiryDate": "2028-01-02", "productId": 160 }
  ]
}

{
  "invoiceNumber": "321098",
  "supplyAuthorization": "AF 2025/674509",
  "observation": "",
  "receivingDate": "2025-07-29T13:15:30.000Z",
  "supplierId": 25,
  "responsibleId": 12,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 50, "unitValue": 1.10, "batch": "LOTR4S8T2U5", "brand": "Kolplast", "expiryDate": "2028-02-09", "productId": 377 },
    { "quantity": 40, "unitValue": 0.60, "batch": "LOTV9W1X5Y8", "brand": "Duflex", "expiryDate": "2029-06-21", "productId": 305 },
    { "quantity": 600, "unitValue": 0.30, "batch": "LOTZ3A7B0C4", "brand": "Cremer", "expiryDate": "2027-11-03", "productId": 164 },
    { "quantity": 200, "unitValue": 0.08, "batch": "LOTD8E2F6G9", "brand": "Descarpack", "expiryDate": "2030-01-01", "productId": 339 },
    { "quantity": 450, "unitValue": 0.45, "batch": "LOTH1J5K9L2", "brand": "Medix", "expiryDate": "2026-05-18", "productId": 336 },
    { "quantity": 200, "unitValue": 0.95, "batch": "LOTM6N0P4Q7", "brand": "Labor Import", "expiryDate": "2028-10-15", "productId": 366 },
    { "quantity": 300, "unitValue": 1.70, "batch": "LOTR1S5T9U3", "brand": "Portex", "expiryDate": "2029-03-09", "productId": 256 },
    { "quantity": 150, "unitValue": 19.25, "batch": "LOTV6W0X4Y8", "brand": "Procare", "expiryDate": "2027-08-27", "productId": 284 },
    { "quantity": 850, "unitValue": 7.12, "batch": "LOTZ1A5B9C3", "brand": "Olen", "expiryDate": "2026-11-29", "productId": 313 },
    { "quantity": 2000, "unitValue": 0.05, "batch": "LOTD6E0F4G7", "brand": "Olen", "expiryDate": "2028-04-12", "productId": 340 }
  ]
}

{
  "invoiceNumber": "987654",
  "supplyAuthorization": "AF 2025/003003",
  "observation": "",
  "receivingDate": "2025-08-02T11:05:11.000Z",
  "supplierId": 3,
  "responsibleId": 9,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 2500, "unitValue": 0.15, "batch": "LOTR9A0B1C3", "brand": "Germed", "expiryDate": "2027-12-19", "productId": 97 },
    { "quantity": 1000, "unitValue": 4.50, "batch": "LOTS5D4E6F8", "brand": "Neo Química", "expiryDate": "2028-04-01", "productId": 3 },
    { "quantity": 800, "unitValue": 0.60, "batch": "LOTT2G7H9I0", "brand": "Pfizer", "expiryDate": "2026-06-22", "productId": 117 },
    { "quantity": 600, "unitValue": 7.80, "batch": "LOTU8J1K3L5", "brand": "Novartis", "expiryDate": "2029-09-14", "productId": 12 },
    { "quantity": 750, "unitValue": 1.25, "batch": "LOTV6M0N2O7", "brand": "Bayer", "expiryDate": "2027-01-08", "productId": 139 },
    { "quantity": 500, "unitValue": 10.50, "batch": "LOTW3P9Q4R2", "brand": "Janssen", "expiryDate": "2028-07-25", "productId": 134 },
    { "quantity": 1100, "unitValue": 0.88, "batch": "LOTX1S7T8U9", "brand": "Cristália", "expiryDate": "2026-10-30", "productId": 79 }
  ]
}

{
  "invoiceNumber": "762001",
  "supplyAuthorization": "AF 2025/009187",
  "observation": "",
  "receivingDate": "2025-08-20T11:55:21.000Z",
  "supplierId": 14,
  "responsibleId": 12,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 10, "unitValue": 12.00, "batch": "LOTV3W7X1Y5", "brand": "Techline", "expiryDate": "2027-01-28", "productId": 187 },
    { "quantity": 300, "unitValue": 0.65, "batch": "LOTZ8A2B6C0", "brand": "Steri", "expiryDate": "2029-08-03", "productId": 262 },
    { "quantity": 250, "unitValue": 0.90, "batch": "LOTD3E7F1G5", "brand": "Labor Import", "expiryDate": "2026-03-01", "productId": 359 },
    { "quantity": 600, "unitValue": 0.20, "batch": "LOTH9J3K7L1", "brand": "Descarpack", "expiryDate": "2028-04-10", "productId": 312 },
    { "quantity": 750, "unitValue": 0.55, "batch": "LOTM4N8P2Q5", "brand": "Olen", "expiryDate": "2030-01-19", "productId": 354 },
    { "quantity": 450, "unitValue": 1.30, "batch": "LOTR9S3T7U1", "brand": "Mediglove", "expiryDate": "2027-05-22", "productId": 148 },
    { "quantity": 50, "unitValue": 0.10, "batch": "LOTV4W8X2Y6", "brand": "Vantagem", "expiryDate": "2029-10-25", "productId": 346 },
    { "quantity": 1200, "unitValue": 0.70, "batch": "LOTZ9A3B7C1", "brand": "BD", "expiryDate": "2028-06-05", "productId": 75 }
  ]
}

{
  "invoiceNumber": "456789",
  "supplyAuthorization": "AF 2025/002222",
  "observation": "",
  "receivingDate": "2025-08-20T14:57:18.000Z",
  "supplierId": 24,
  "responsibleId": 8,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 2000, "unitValue": 0.15, "batch": "LOTP3Q7R1S5", "brand": "Cimed", "expiryDate": "2026-05-10", "productId": 38 },
    { "quantity": 1500, "unitValue": 0.85, "batch": "LOTK8L2M6N0", "brand": "Neo Química", "expiryDate": "2029-02-23", "productId": 223 },
    { "quantity": 1100, "unitValue": 1.25, "batch": "LOTJ7K1L5M9", "brand": "EMS", "expiryDate": "2028-07-06", "productId": 117 },
    { "quantity": 900, "unitValue": 0.60, "batch": "LOTI4O8P2Q6", "brand": "Eurofarma", "expiryDate": "2027-10-14", "productId": 122 },
    { "quantity": 1300, "unitValue": 2.99, "batch": "LOTF0G4H8J2", "brand": "Medley", "expiryDate": "2030-01-20", "productId": 126 },
    { "quantity": 500, "unitValue": 6.70, "batch": "LOTA9B3C7D1", "brand": "Hypera Pharma", "expiryDate": "2028-04-03", "productId": 136 },
    { "quantity": 800, "unitValue": 4.15, "batch": "LOTV5W9X3Y7", "brand": "Sanofi", "expiryDate": "2029-11-16", "productId": 252 },
    { "quantity": 1200, "unitValue": 0.32, "batch": "LOTS6T0U4V8", "brand": "Pfizer", "expiryDate": "2027-03-27", "productId": 81 },
    { "quantity": 1200, "unitValue": 0.90, "batch": "LOTD1E5F9G3", "brand": "Novartis", "expiryDate": "2026-12-19", "productId": 59 },
    { "quantity": 2000, "unitValue": 0.15, "batch": "LOTB1N7A1U6", "brand": "Cimed", "expiryDate": "2027-05-12", "productId": 27 },
    { "quantity": 1500, "unitValue": 0.85, "batch": "LOTK9P8M6G2", "brand": "Neo Química", "expiryDate": "2027-05-23", "productId": 7 },
    { "quantity": 1100, "unitValue": 1.25, "batch": "LOTJ4T2L6M8", "brand": "EMS", "expiryDate": "2027-04-09", "productId": 5 },
    { "quantity": 900, "unitValue": 0.60, "batch": "LOTA4A8P2A6", "brand": "Eurofarma", "expiryDate": "2028-12-14", "productId": 113 },
    { "quantity": 950, "unitValue": 2.99, "batch": "LOTV8G2F8W2", "brand": "Medley", "expiryDate": "2027-01-25", "productId": 105 },
    { "quantity": 500, "unitValue": 6.70, "batch": "LOTB9F3R7A1", "brand": "Hypera Pharma", "expiryDate": "2028-08-03", "productId": 88 },
    { "quantity": 800, "unitValue": 4.15, "batch": "LOTV9G3B3Y3", "brand": "Sanofi", "expiryDate": "2028-11-26", "productId": 52 },
    { "quantity": 1200, "unitValue": 0.32, "batch": "LOTR5W0V4V8", "brand": "Pfizer", "expiryDate": "2028-05-13", "productId": 39 },
    { "quantity": 1450, "unitValue": 0.90, "batch": "LOTF1A8F9V1", "brand": "Eurofarma", "expiryDate": "2027-12-12", "productId": 225 }
  ]
}

{
  "invoiceNumber": "808080",
  "supplyAuthorization": "AF 2025/000888",
  "observation": "Entrega grande",
  "receivingDate": "2025-09-01T13:17:21.000Z",
  "supplierId": 26,
  "responsibleId": 5,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 10, "unitValue": 45.00, "batch": "LOTD8E2F6G0", "brand": "Opti", "expiryDate": "2028-06-01", "productId": 277 },
    { "quantity": 100, "unitValue": 1.99, "batch": "LOTH4J8K2L6", "brand": "3M", "expiryDate": "2029-01-20", "productId": 8 },
    { "quantity": 850, "unitValue": 2.50, "batch": "LOTM9N3P7Q0", "brand": "Portex", "expiryDate": "2027-11-25", "productId": 315 },
    { "quantity": 200, "unitValue": 0.85, "batch": "LOTR4S8T2U6", "brand": "Mediglove", "expiryDate": "2030-03-11", "productId": 367 },
    { "quantity": 250, "unitValue": 0.15, "batch": "LOTV9W3X7Y1", "brand": "Descarpack", "expiryDate": "2026-08-08", "productId": 166 },
    { "quantity": 300, "unitValue": 0.45, "batch": "LOTZ4A8B2C6", "brand": "Cremer", "expiryDate": "2029-05-04", "productId": 335 },
    { "quantity": 350, "unitValue": 0.70, "batch": "LOTD9E3F7G1", "brand": "Solidor", "expiryDate": "2027-02-17", "productId": 147 },
    { "quantity": 400, "unitValue": 0.90, "batch": "LOTH5J9K3L7", "brand": "BD", "expiryDate": "2028-10-29", "productId": 181 },
    { "quantity": 450, "unitValue": 1.20, "batch": "LOTM0N4P8Q1", "brand": "Labor Import", "expiryDate": "2026-11-15", "productId": 392 },
    { "quantity": 250, "unitValue": 0.22, "batch": "LOTR5S9T3U7", "brand": "Olen", "expiryDate": "2029-04-03", "productId": 331 },
    { "quantity": 550, "unitValue": 0.50, "batch": "LOTV0W4X8Y2", "brand": "Vantagem", "expiryDate": "2027-12-05", "productId": 274 },
    { "quantity": 60, "unitValue": 1.05, "batch": "LOTZ5A9B3C7", "brand": "Steri", "expiryDate": "2028-07-28", "productId": 308 },
    { "quantity": 650, "unitValue": 0.38, "batch": "LOTD0E4F8G2", "brand": "Pampers", "expiryDate": "2029-02-12", "productId": 351 }
  ]
}

{
  "invoiceNumber": "209531",
  "supplyAuthorization": "AF 2025/213456",
  "observation": "Reabastecimento urgente de estoque.",
  "receivingDate": "2025-09-04T09:54:56.000Z",
  "supplierId": 49,
  "responsibleId": 10,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 750, "unitValue": 0.70, "batch": "LOTQ7K2L8M4", "brand": "Eurofarma", "expiryDate": "2028-03-02", "productId": 227 },
    { "quantity": 300, "unitValue": 1.15, "batch": "LOTN0O3P6Q9", "brand": "Ache", "expiryDate": "2027-06-17", "productId": 91 },
    { "quantity": 1050, "unitValue": 0.28, "batch": "LOTB5R4S0T1", "brand": "Medley", "expiryDate": "2029-10-09", "productId": 255 },
    { "quantity": 800, "unitValue": 5.90, "batch": "LOTD9U6V3W7", "brand": "EMS", "expiryDate": "2026-03-24", "productId": 114 },
    { "quantity": 850, "unitValue": 0.35, "batch": "LOTY5Z6A2B7", "brand": "Cimed", "expiryDate": "2027-02-04", "productId": 50 },
    { "quantity": 1750, "unitValue": 0.63, "batch": "LOTH2X1Y4Z8", "brand": "Cimed", "expiryDate": "2028-08-07", "productId": 38 },
    { "quantity": 2100, "unitValue": 0.40, "batch": "LOTI6A5B9C0", "brand": "Hypera Pharma", "expiryDate": "2027-09-12", "productId": 136 },
    { "quantity": 950, "unitValue": 2.50, "batch": "LOTJ3D2E7F5", "brand": "Sanofi", "expiryDate": "2030-01-01", "productId": 127 },
    { "quantity": 1650, "unitValue": 0.18, "batch": "LOTK1G8H0I3", "brand": "Libbs", "expiryDate": "2026-12-05", "productId": 49 }
  ]
}

{
  "invoiceNumber": "268904",
  "supplyAuthorization": "AF 2025/700100",
  "observation": "Prioridade de armazenamento. Produtos de alto valor.",
  "receivingDate": "2025-09-05T15:41:17.000Z",
  "supplierId": 21,
  "responsibleId": 11,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 50, "unitValue": 55.00, "batch": "LOTG2Z5F1C9", "brand": "Vidas", "expiryDate": "2027-09-01", "productId": 256 },
    { "quantity": 500, "unitValue": 7.50, "batch": "LOTD8H3J6A4", "brand": "Hartmann", "expiryDate": "2029-10-20", "productId": 168 },
    { "quantity": 200, "unitValue": 1.10, "batch": "LOTB7E4I2O5", "brand": "Descarpack", "expiryDate": "2028-05-14", "productId": 186 },
    { "quantity": 1500, "unitValue": 0.85, "batch": "LOTL1P9M5K8", "brand": "Injex", "expiryDate": "2026-10-03", "productId": 344 },
    { "quantity": 50, "unitValue": 4.20, "batch": "LOTI3U7Y0T6", "brand": "Becton", "expiryDate": "2027-04-11", "productId": 388 },
    { "quantity": 800, "unitValue": 0.75, "batch": "LOTC5N1Q3R7", "brand": "SR", "expiryDate": "2028-08-08", "productId": 144 },
    { "quantity": 70, "unitValue": 0.75, "batch": "LOTV2W4X6Y8", "brand": "Sanro", "expiryDate": "2029-11-19", "productId": 146 },
    { "quantity": 250, "unitValue": 0.70, "batch": "LOTM9P1L3K5", "brand": "MedPex", "expiryDate": "2027-03-04", "productId": 312 },
    { "quantity": 120, "unitValue": 0.90, "batch": "LOTF6G8H0J2", "brand": "Tegaderm", "expiryDate": "2030-01-25", "productId": 332 },
    { "quantity": 200, "unitValue": 2.10, "batch": "LOTE0D2I4O6", "brand": "Dermacyd", "expiryDate": "2027-10-29", "productId": 265 }
  ]
}

{
  "invoiceNumber": "550382",
  "supplyAuthorization": "AF 2025/002047",
  "observation": "Conferido e aceito.",
  "receivingDate": "2025-09-15T13:18:25.000Z",
  "supplierId": 21,
  "responsibleId": 1,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1200, "unitValue": 1.55, "batch": "LOTJ3A7B1E4", "brand": "Medley", "expiryDate": "2027-05-21", "productId": 1 },
    { "quantity": 850, "unitValue": 0.98, "batch": "LOTC8F2D5A9", "brand": "EMS", "expiryDate": "2026-08-15", "productId": 222 },
    { "quantity": 1100, "unitValue": 0.45, "batch": "LOTG6E0C7D2", "brand": "Ache", "expiryDate": "2028-11-03", "productId": 29 },
    { "quantity": 900, "unitValue": 3.20, "batch": "LOTK1H5G9F0", "brand": "Eurofarma", "expiryDate": "2029-01-28", "productId": 89 },
    { "quantity": 1150, "unitValue": 0.75, "batch": "LOTP4I6J8K3", "brand": "Sanofi", "expiryDate": "2026-04-10", "productId": 37 },
    { "quantity": 700, "unitValue": 2.10, "batch": "LOTM7L2N4O1", "brand": "Libbs", "expiryDate": "2030-03-05", "productId": 110 }
  ]
}

{
  "invoiceNumber": "603810",
  "supplyAuthorization": "AF 2025/007123",
  "observation": "",
  "receivingDate": "2025-09-17T13:26:39.000Z",
  "supplierId": 25,
  "responsibleId": 12,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 1100, "unitValue": 0.90, "batch": "LOTK8L7M3N9", "brand": "Cristália", "expiryDate": "2026-01-18", "productId": 29 },
    { "quantity": 1500, "unitValue": 0.50, "batch": "LOTP4Q0R5S6", "brand": "Ache", "expiryDate": "2029-06-27", "productId": 103 },
    { "quantity": 1000, "unitValue": 0.10, "batch": "LOTT1U7V2W5", "brand": "Medley", "expiryDate": "2028-10-14", "productId": 104 },
    { "quantity": 900, "unitValue": 4.10, "batch": "LOTY3Z9A4B8", "brand": "Eurofarma", "expiryDate": "2027-08-08", "productId": 140 },
    { "quantity": 1000, "unitValue": 0.77, "batch": "LOTC6D1E5F0", "brand": "EMS", "expiryDate": "2030-02-09", "productId": 120 },
    { "quantity": 600, "unitValue": 2.30, "batch": "LOTH2I8J6K1", "brand": "Cimed", "expiryDate": "2028-05-25", "productId": 123 },
    { "quantity": 900, "unitValue": 3.10, "batch": "LOTT2U7V3W9", "brand": "Janssen", "expiryDate": "2028-09-20", "productId": 119 },
    { "quantity": 850, "unitValue": 0.44, "batch": "LOTM7N3O9P2", "brand": "Hypera Pharma", "expiryDate": "2026-09-01", "productId": 122 },
    { "quantity": 1800, "unitValue": 0.22, "batch": "LOTQ5R1S6T4", "brand": "Sanofi", "expiryDate": "2029-01-06", "productId": 224 },
    { "quantity": 750, "unitValue": 1.65, "batch": "LOTV8W4X0Y7", "brand": "Libbs", "expiryDate": "2027-03-29", "productId": 225 },
    { "quantity": 1600, "unitValue": 0.38, "batch": "LOTZ2A6B3C9", "brand": "Germed", "expiryDate": "2028-01-13", "productId": 27 },
    { "quantity": 400, "unitValue": 0.92, "batch": "LOTD0E7F4G5", "brand": "Neo Química", "expiryDate": "2026-11-04", "productId": 4 }
  ]
}

{
  "invoiceNumber": "404040",
  "supplyAuthorization": "AF 2025/001122",
  "observation": "Revisar lote",
  "receivingDate": "2025-10-14T14:01:51.000Z",
  "supplierId": 33,
  "responsibleId": 8,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 2000, "unitValue": 0.15, "batch": "LOT8W6X4Y2", "brand": "Hipolabor", "expiryDate": "2030-08-08", "productId": 20 },
    { "quantity": 1590, "unitValue": 0.08, "batch": "LOT7Z5A3B1", "brand": "Baxter", "expiryDate": "2029-12-12", "productId": 45 },
    { "quantity": 1500, "unitValue": 0.22, "batch": "LOT6C4D2E0", "brand": "Fresenius Kabi", "expiryDate": "2028-01-26", "productId": 238 },
    { "quantity": 500, "unitValue": 1.50, "batch": "LOT5F3G1H9", "brand": "Halex Istar", "expiryDate": "2027-04-09", "productId": 107 },
    { "quantity": 800, "unitValue": 0.75, "batch": "LOT4I2J0K8", "brand": "Eurofarma", "expiryDate": "2026-11-21", "productId": 21 }
  ]
}

{
  "invoiceNumber": "881230",
  "supplyAuthorization": "AF 2025/001007",
  "observation": "",
  "receivingDate": "2025-10-25T10:48:57.000Z",
  "supplierId": 60,
  "responsibleId": 12,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 250, "unitValue": 1.15, "batch": "LOTX1B7E20A", "brand": "3M", "expiryDate": "2027-05-20", "productId": 144 },
    { "quantity": 2500, "unitValue": 0.55, "batch": "LOTK4F8C1D6", "brand": "Descarpack", "expiryDate": "2028-09-01", "productId": 338 },
    { "quantity": 800, "unitValue": 1.75, "batch": "LOTH3A7B9C0", "brand": "BD", "expiryDate": "2026-03-15", "productId": 175 },
    { "quantity": 700, "unitValue": 3.90, "batch": "LOTZ0G6H5I4", "brand": "Medix", "expiryDate": "2029-11-10", "productId": 168 },
    { "quantity": 245, "unitValue": 34.90, "batch": "LOTN3O4P5Q6", "brand": "Vulkan", "expiryDate": "2026-06-12", "productId": 316 },
    { "quantity": 900, "unitValue": 1.70, "batch": "LOTR7S8T9U0", "brand": "Kolplast", "expiryDate": "2028-11-29", "productId": 285 },
    { "quantity": 450, "unitValue": 0.18, "batch": "LOTW1X2Y3Z4", "brand": "Bioclean", "expiryDate": "2027-04-05", "productId": 334 },
    { "quantity": 750, "unitValue": 2.10, "batch": "LOTB5C6D7E8", "brand": "Procare", "expiryDate": "2029-08-14", "productId": 297 },
    { "quantity": 10, "unitValue": 35.00, "batch": "LOTG9H0I1J2", "brand": "Welch Allyn", "expiryDate": "2030-05-03", "productId": 277 },
    { "quantity": 1400, "unitValue": 0.28, "batch": "LOTK3L4M5N6", "brand": "Solidor", "expiryDate": "2028-01-31", "productId": 163 },
    { "quantity": 1800, "unitValue": 0.95, "batch": "LOTY9J2K1L7", "brand": "Cremer", "expiryDate": "2027-01-25", "productId": 165 }
  ]
}

{
  "invoiceNumber": "301548",
  "supplyAuthorization": "AF 2025/000210",
  "observation": "Urgente",
  "receivingDate": "2025-11-04T08:26:17.000Z",
  "supplierId": 63,
  -- Material de Apoio e Administrativo
  "responsibleId": 10,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 10, "unitValue": 215.80, "batch": "LOT1A7B3E9C", "brand": "Report", "expiryDate": "2028-02-19", "productId": 198 },
    { "quantity": 10, "unitValue": 9.95, "batch": "LOTZ9B0B1C", "brand": "Tramontina", "expiryDate": "2030-09-28", "productId": 294 },
    { "quantity": 10, "unitValue": 38.75, "batch": "LOTF8D2C0A4", "brand": "Bic", "expiryDate": "2029-11-30", "productId": 211 },
    { "quantity": 10, "unitValue": 6.50, "batch": "LOT3E5B7C9D", "brand": "Eagle", "expiryDate": "2028-08-03", "productId": 217 },
    { "quantity": 25, "unitValue": 27.00, "batch": "LOTC0D1E2F", "brand": "Mercur", "expiryDate": "2029-10-01", "productId": 215 },
    { "quantity": 5, "unitValue": 41.65, "batch": "LOTH3H8I5J", "brand": "Bic", "expiryDate": "2030-04-29", "productId": 213 }
  ]
}

{
  "invoiceNumber": "456789",
  "supplyAuthorization": "AF 2025/005005",
  "observation": "",
  "receivingDate": "2025-11-07T15:52:26.000Z",
  "supplierId": 79,
  "responsibleId": 10,
  "accountId": 8,
  "receivedItems": [
    { "quantity": 700, "unitValue": 4.50, "batch": "LOTC1D8F4H", "brand": "Libbs", "expiryDate": "2028-07-16", "productId": 31 },
    { "quantity": 950, "unitValue": 2.10, "batch": "LOTJ3K6L9M", "brand": "Baldacci", "expiryDate": "2029-04-29", "productId": 10 },
    { "quantity": 600, "unitValue": 6.80, "batch": "LOTN2P5Q7R", "brand": "Biolab", "expiryDate": "2027-03-12", "productId": 228 },
    { "quantity": 1100, "unitValue": 0.88, "batch": "LOTS4T1U8V", "brand": "Cristália", "expiryDate": "2026-05-01", "productId": 50 }
  ]
}

{
  "invoiceNumber": "459012",
  "supplyAuthorization": "AF 2025/115793",
  "observation": "",
  "receivingDate": "2025-11-12T10:43:31.000Z",
  "supplierId": 50,
  -- Material de Limpeza
  "responsibleId": 5,
  "accountId": 9,
  "receivedItems": [
    { "quantity": 200, "unitValue": 12.50, "batch": "LOTB9F3A1C8", "brand": "Ecolab", "expiryDate": "2027-05-20", "productId": 192 },
    { "quantity": 10, "unitValue": 45.90, "batch": "LOTC6D2E0B7", "brand": "Riccel", "expiryDate": "2026-08-15", "productId": 85 },
    { "quantity": 350, "unitValue": 3.75, "batch": "LOTF8A5D4C2", "brand": "Santher", "expiryDate": "2028-11-01", "productId": 203 },
    { "quantity": 120, "unitValue": 25.00, "batch": "LOT7E3C2B1A", "brand": "3M", "expiryDate": "2029-01-25", "productId": 189 },
    { "quantity": 700, "unitValue": 68.30, "batch": "LOTD4B1C0A9", "brand": "Spartan", "expiryDate": "2026-12-10", "productId": 290 }
  ]
}

{
  "invoiceNumber": "713402",
  "supplyAuthorization": "AF 2025/554321",
  "observation": "",
  "receivingDate": "2025-11-18T10:42:32.000Z",
  "supplierId": 39,
  -- Material de Apoio e Administrativo
  "responsibleId": 11,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 100, "unitValue": 5.74, "batch": "LOTQ5D2P0J8", "brand": "Bacchi", "expiryDate": "2026-04-18", "productId": 217 },
    { "quantity": 200, "unitValue": 2.10, "batch": "LOTB0G6R9M3", "brand": "Acrilex", "expiryDate": "2029-10-22", "productId": 293 },
    { "quantity": 10, "unitValue": 0.60, "batch": "LOTS7E3L1F6", "brand": "Bic", "expiryDate": "2028-08-14", "productId": 212 },
    { "quantity": 50, "unitValue": 35.50, "batch": "LOTF8H4T5U7", "brand": "Papira", "expiryDate": "2027-02-01", "productId": 190 }
  ]
}

{
  "invoiceNumber": "555111",
  "supplyAuthorization": "AF 2025/003456",
  "observation": "",
  "receivingDate": "2025-12-10T09:45:41.000Z",
  "supplierId": 24,
  "responsibleId": 12,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 150, "unitValue": 1.55, "batch": "LOTX1D8E7H6", "brand": "3M", "expiryDate": "2027-05-20", "productId": 8 },
    { "quantity": 250, "unitValue": 7.15, "batch": "LOTF4K2P9Z1", "brand": "Descarpack", "expiryDate": "2026-08-15", "productId": 313 },
    { "quantity": 50, "unitValue": 0.45, "batch": "LOT9T5C7B4M", "brand": "Medix", "expiryDate": "2028-03-01", "productId": 145 },
    { "quantity": 2500, "unitValue": 0.15, "batch": "LOTQ2R6A3S8", "brand": "BD", "expiryDate": "2029-01-10", "productId": 95 },
    { "quantity": 500, "unitValue": 4.90, "batch": "LOTH3N6V2Y5", "brand": "Cremer", "expiryDate": "2027-11-05", "productId": 164 },
    { "quantity": 1200, "unitValue": 0.15, "batch": "LOTP8B5T4R1", "brand": "Embramed", "expiryDate": "2029-04-18", "productId": 338 },
    { "quantity": 300, "unitValue": 12.50, "batch": "LOTZ7J1L5K9", "brand": "Steris", "expiryDate": "2028-12-01", "productId": 266 },
    { "quantity": 5, "unitValue": 25.00, "batch": "LOTE6M4R8W2", "brand": "OtoFocus", "expiryDate": "2026-03-25", "productId": 277 }
  ]
}

-- ==================================================================================================================================
