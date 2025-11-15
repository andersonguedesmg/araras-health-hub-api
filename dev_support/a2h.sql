USE [ararashealthhub]
GO

DECLARE @MaxMonthsAgo INT = 10
DECLARE @NOW DATETIME = GETDATE()
DECLARE @MinDate DATETIME = DATEADD(MONTH, -@MaxMonthsAgo, @NOW)
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @NOW)

;WITH RandomDates (Name, Cpf, [Function], Phone, IsActive, CreatedOn, UpdatedOn) AS (
      SELECT
            T.Name,
            T.Cpf,
            T.[Function],
            T.Phone,
            T.IsActive,

            -- 'CreatedOn'
            DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % @RangeSeconds, @MinDate) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
            WHEN T.IsActive = 0
            THEN DATEADD(MINUTE, (ABS(CHECKSUM(NEWID())) % (60 * 24 * 30)) + 1, DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % @RangeSeconds, @MinDate))
            ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
               -- ('Name',               'Cpf',            'Function',                'Phone',           'IsActive')
                  ('Jed Bartlet',        '053.487.653-29', 'Coordenador',             '(19) 98564-1205',  1),
                  ('Matt Santos',        '428.196.772-00', 'Coordenador',             '(19) 98812-7589',  1),
                  ('Leo McGarry',        '619.043.208-87', 'Auxiliar Administrativo', '(19) 97345-6402',  0),
                  ('Donna Moss',         '814.391.135-95', 'Farmacêutico',            '(19) 99985-3021',  1),
                  ('Josh Lyman',         '387.904.053-48', 'Enfermeiro',              '(19) 99123-8527',  1),
                  ('Kate Harper',        '248.601.734-51', 'Auxiliar Administrativo', '(19) 98257-8901',  1),
                  ('Toby Ziegler',       '109.526.476-05', 'Auxiliar Administrativo', '(19) 99765-4203',  1),
                  ('Sam Seaborn',        '145.733.927-46', 'Enfermeiro',              '(19) 99123-5080',  1),
                  ('Will Bailey',        '932.164.780-15', 'Auxiliar Administrativo', '(19) 98230-4462',  1),
                  ('Ainsley Hayes',      '540.832.179-05', 'Enfermeiro',              '(19) 98734-7605',  1),
                  ('Chandler Bing',      '356.918.420-56', 'Coordenador',             '(19) 99564-7832',  0),
                  ('Joey Tribbiani',     '183.076.495-21', 'Auxiliar Administrativo', '(19) 99642-1198',  1),
                  ('Rachel Green',       '401.597.332-68', 'Farmacêutico',            '(19) 98451-2389',  1),
                  ('Monica Geller',      '578.223.149-10', 'Enfermeiro',              '(19) 98745-1023',  1),
                  ('Ross Geller',        '901.884.750-77', 'Auxiliar Administrativo', '(19) 98123-7654',  1),
                  ('Phoebe Buffay',      '290.415.867-04', 'Farmacêutico',            '(19) 98325-4432',  1),
                  ('Gregory House',      '642.378.910-63', 'Enfermeiro',              '(19) 98976-2154',  1),
                  ('Matt Albie',         '174.053.820-00', 'Agente de Endemias',      '(19) 98333-3030',  0),
                  ('Danny Tripp',        '836.290.110-54', 'Farmacêutico',            '(19) 98484-8484',  1),
                  ('Jordan McDeere',     '285.741.056-11', 'Coordenador',             '(19) 98686-1212',  1),
                  ('Natalie Hurley',     '068.591.309-47', 'Auxiliar Administrativo', '(19) 98484-8485',  1),
                  ('Alan Shore',         '318.490.572-00', 'Farmacêutico',            '(19) 98401-1234',  1),
                  ('Adrian Monk',        '713.849.520-22', 'Agente de Endemias',      '(19) 99811-2374',  1),
                  ('Michael Scofield',   '134.607.892-05', 'Auxiliar Administrativo', '(19) 98560-4032',  1),
                  ('Tony Soprano',       '591.028.347-79', 'Farmacêutico',            '(19) 97987-1204',  0),
                  ('Ally McBeal',        '645.713.980-00', 'Auxiliar Administrativo', '(19) 98543-6578',  1),
                  ('Frank Underwood',    '892.406.115-43', 'Auxiliar Administrativo', '(19) 98439-1052',  1),
                  ('Sloan Sabbith',      '610.975.324-12', 'Auxiliar Administrativo', '(19) 98244-3150',  1),
                  ('Don Keefer',         '789.201.463-55', 'Enfermeiro',              '(19) 98899-2340',  1),
                  ('Mark Greene',        '930.417.586-77', 'Auxiliar Administrativo', '(19) 98123-4770',  1),
                  ('John Carter',        '587.146.903-88', 'Farmacêutico',            '(19) 98123-4567',  1),
                  ('Abby Lockhart',      '169.324.570-90', 'Agente de Endemias',      '(19) 98045-6651',  1),
                  ('Neela Rasgotra',     '758.219.043-42', 'Coordenador',             '(19) 98076-1194',  1),
                  ('Carol Hathaway',     '012.345.678-90', 'Enfermeiro',              '(19) 98895-2291',  1),
                  ('Dexter Morgan',      '734.012.986-53', 'Enfermeiro',              '(19) 99384-2911',  1),
                  ('Jack Bauer',         '085.346.917-82', 'Agente de Endemias',      '(19) 99930-6871',  1),
                  ('Michelle Dessler',   '968.402.751-32', 'Farmacêutico',            '(19) 99653-2270',  1),
                  ('Chloe OBrian',       '370.158.496-03', 'Auxiliar Administrativo', '(19) 99128-4009',  1),
                  ('Jake Peralta',       '415.937.608-20', 'Auxiliar Administrativo', '(19) 99831-7192',  1),
                  ('Rosa Diaz',          '286.049.713-35', 'Auxiliar Administrativo', '(19) 99475-3301',  1),
                  ('Amy Santiago',       '540.721.398-67', 'Enfermeiro',              '(19) 99213-6644',  1),
                  ('Raymond Holt',       '924.630.157-89', 'Coordenador',             '(19) 99915-8720',  0),
                  ('Richard Castle',     '187.593.240-66', 'Farmacêutico',            '(19) 99548-7299',  1),
                  ('Kate Beckett',       '043.167.892-05', 'Auxiliar Administrativo', '(19) 98993-4108',  1),
                  ('Robin Scherbatsky',  '778.901.234-56', 'Auxiliar Administrativo', '(19) 99166-2930',  1),
                  ('Barney Stinson',     '889.012.345-67', 'Auxiliar Administrativo', '(19) 98743-7099',  1),
                  ('Harvey Specter',     '434.567.890-12', 'Auxiliar Administrativo', '(19) 98712-4350',  1),
                  ('Donna Paulsen',      '545.678.901-23', 'Farmacêutico',            '(19) 98413-6572',  1),
                  ('Louis Litt',         '656.789.012-34', 'Coordenador',             '(19) 98642-3033',  1)
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

DECLARE @MaxMonthsAgo INT = 10
DECLARE @NOW DATETIME = GETDATE()
DECLARE @MinDate DATETIME = DATEADD(MONTH, -@MaxMonthsAgo, @NOW)
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @NOW)

;WITH RandomDates (
      Name, Address_Cep, Address_Street, Address_Complement, Address_Number, Address_Neighborhood, Address_City, Address_State, Contact_Email, Contact_Phone, IsActive, CreatedOn, UpdatedOn
) AS (
      SELECT
            T.Name,
            T.Address_Cep,
            T.Address_Street,
            T.Address_Complement,
            T.Address_Number,
            T.Address_Neighborhood,
            T.Address_City,
            T.Address_State,
            T.Contact_Email,
            T.Contact_Phone,
            T.IsActive,

            -- 'CreatedOn'
            DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % @RangeSeconds, @MinDate) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
            WHEN T.IsActive = 0
            THEN DATEADD(MINUTE, (ABS(CHECKSUM(NEWID())) % (60 * 24 * 30)) + 1, DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % @RangeSeconds, @MinDate))
            ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
               -- ('Name',                                                             'Address_Cep',  'Address_Street',                                'Address_Complement',                'Address_Number',  'Address_Neighborhood',                                        'Address_City',  'Address_State',  'Contact_Email',               'Contact_Phone',  'IsActive')
               -- ('Secretaria Municipal da Saúde',	                                   '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'sms@araras.sp.gov.br',        '(19) 3543-1522',  1),
                  ('Centro de Distribuição de Medicamentos Ricardo Francisco Vechin',  '13600-710',    'Rua Brasília',                                  '',                                  '295',             'Centro',                                                      'Araras',        'SP',             'cdm@araras.sp.gov.br',        '(19) 3544-4280',  1),
                  ('UBS Ênio Vitalli',                                                 '13604-066',    'Rua Franca',                                    '',                                  '99',              'Jardim Piratininga',                                          'Araras',        'SP',             'ubs_ev@araras.sp.gov.br',     '(19) 3544-4280',  1),
                  ('UPA Elisa Sbrissa Franchozza',                                     '13606-414',    'Avenida Irineu Carrocci',                       'até 1458/1459',                     '400',             'Jardim José Ometto II',                                       'Araras',        'SP',             'upa_esf@araras.sp.gov.br',    '(19) 3543-5100',  1),
                  ('Farmácia de Alto Custo',                                           '13600-710',    'Rua Brasília',                                  '',                                  '295',             'Centro',                                                      'Araras',        'SP',             'fac@araras.sp.gov.br',        '(19) 3551-1096',  1),
                  ('SAMU Regional de Araras',                                          '13600-001',    'Avenida Dona Renata',                           'Norte - de 268 a 2732 - lado par',  '4585',            'Centro',                                                      'Araras',        'SP',             'samu@araras.sp.gov.br',       '(19) 3541-6819',  1),
                  ('PSF Edmundo Ulson',                                                '13606-652',    'Rua Ângelo Francatto',                          '',                                  '393',             'Parque Tiradentes',                                           'Araras',        'SP',             'psf_eu@araras.sp.gov.br',     '(19) 3544-5232',  1),
                  ('PSF Nilton De Lollo',                                              '13604-044',    'Rua Catanduva',                                 '',                                  '253',             'Jardim São João',                                             'Araras',        'SP',             'psf_ndl@araras.sp.gov.br',    '(19) 3544-7302',  1),
                  ('PSF Jair Mourão',                                                  '13606-314',    'Rua do Estudante',                              '',                                  '110',             'Jardim José Ometto I',                                        'Araras',        'SP',             'psf_jm@araras.sp.gov.br',     '(19) 3544-7754',  1),
                  ('UBS José Fiori',                                                   '13607-088',    'Rua Ana da Silva',                              '(Inhana)',                          's/nº',            'Jardim Nova Suissa',                                          'Araras',        'SP',             'ubs_jf@araras.sp.gov.br',     '(19) 3542-9308',  1),
                  ('CAEM Dr. Nelson Salomé',                                           '13606-390',    'Rua Nelson Ferreira',                           '',                                  's/nº',            'Jardim José Ometto II',                                       'Araras',        'SP',             'caem_ns@araras.sp.gov.br',    '(19) 3542-7602',  1),
                  ('Ambulatório de Saúde Mental Agnaldo Bianchini',                    '13607-200',    'Avenida Loreto',                                'até 1298 - lado par',               '1291',            'Jardim das Flores',                                           'Araras',        'SP',             'asm_ab@araras.sp.gov.br',     '(19) 3544-2674',  1),
                  ('CAPS-AD',                                                          '13600-720',    'Avenida Washington Luiz',                       'até 400/401',                       '545',             'Centro',                                                      'Araras',        'SP',             'caps_ad@araras.sp.gov.br',    '(19) 3542-4137',  1),
                  ('Centro de Controle de Zoonoses',                                   '13606-852',    'Estrada Municipal Luiz Segundo D''Alessandri',  '',                                  's/nº',            'Conjunto Residencial Prefeito Professor Jair Della Colleta',  'Araras',        'SP',             'ccz@araras.sp.gov.br',        '(19) 3544-4413',  1),
                  ('Ambulatório de Pronto Atendimento Dr. Solon F. de Oliveira',       '13602-006',    'Rua dos Girassóis',                             '',                                  's/nº',            'Jardim Sobradinho',                                           'Araras',        'SP',             'apa_sfo@araras.sp.gov.br',    '(19) 3544-5630',  0),
                  ('Vigilância Sanitária de Araras',                                   '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'vsa@araras.sp.gov.br',        '(19) 3543-1522',  1),
                  ('Unidade Móvel Odontológica',                                       '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'umo@araras.sp.gov.br',        '(19) 3543-1522',  0),
                  ('Unidade de Vigilância Epidemiológica',                             '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'uve@araras.sp.gov.br',        '(19) 3541-7037',  1),
                  ('UBS Osvaldo Salvador Devitte',                                     '13601-400',    'Avenida Presidente Castello Branco',            '',                                  '27',              'Conjunto Habitacional Narciso Gomes',                         'Araras',        'SP',             'ubs_osd@araras.sp.gov.br',    '(19) 3544-4974',  1),
                  ('UBS Dr. Humberto Rodrigues Junior',                                '13607-005',    'Avenida Melvin Jones',                          'de 1 a 447 - lado ímpar',           's/nº',            'Jardim Nossa Senhora de Fátima',                              'Araras',        'SP',             'ubs_hrj@araras.sp.gov.br',    '(19) 3544-6939',  1),
                  ('UBS Dr. Emerson Mercatelli',                                       '13609-384',    'Rua Aníbal Lopes da Silva',                     '',                                  '190',             'Residencial Bosque de Versalles',                             'Araras',        'SP',             'ubs_em@araras.sp.gov.br',     '(19) 3547-9609',  1),
                  ('UBS Dr. Antônio Simoes Pontes',                                    '13605-300',    'Avenida João Rossi',                            '',                                  's/nº',            'Chácaras Granja São Francisco',                               'Araras',        'SP',             'ubs_asp@araras.sp.gov.br',    '(19) 3547-3195',  0),
                  ('UBS Antônio Carlos Fabricio',                                      '13606-320',    'Rua do Carpinteiro',                            '',                                  's/nº',            'Jardim José Ometto I',                                        'Araras',        'SP',             'ubs_acf@araras.sp.gov.br',    '(19) 3544-3569',  1),
                  ('UBS Alberto Franzini',                                             '13606-508',    'Rua Cássio Gonzaga',                            '',                                  's/nº',            'Jardim Morumbi',                                              'Araras',        'SP',             'ubs_af@araras.sp.gov.br',     '(19) 3541-8016',  1),
                  ('Pró Saúde Hospital Geral',                                         '13606-020',    'Avenida Augusta Viola da Costa',                '',                                  '805',             'Jardim Celina',                                               'Araras',        'SP',             'hps@araras.sp.gov.br',        '(19) 3321-1260',  1),
                  ('PS Dr. Alcides Franco de Oliveira',                                '13606-326',    'Avenida Lourenço Batistella',                   '',                                  '514',             'Jardim José Ometto I',                                        'Araras',        'SP',             'sps_afoms@araras.sp.gov.br',  '(19) 3541-7211',  0),
                  ('SAE/CTA Enfermeira Adalgisa dos Santos Gonçalves',                 '13600-559',    'Rua Doutor Francisco Paulo Russo',              '',                                  '119',             'Vila Bressan',                                                'Araras',        'SP',             'easg@araras.sp.gov.br',       '(19) 3544-2064',  1),
                  ('Posto de Atendimento Médico Eva Almeida Costa Cruz',               '13601-430',    'Avenida Presidente Café Filho',                 '',                                  '209',             'Conjunto Habitacional Narciso Gomes',                         'Araras',        'SP',             'pa_eacc@araras.sp.gov.br',    '(19) 3541-7898',  0),
                  ('Medicina Diagnóstica Castro Soares',                               '13600-710',    'Rua Brasília',                                  '',                                  '123',             'Centro',                                                      'Araras',        'SP',             'mdcs@araras.sp.gov.br',       '(19) 3541-4211',  1),
                  ('LabVitta Laboratório de Análises Clínicas',                        '13600-690',    'Rua Coronel André Ulson Júnior',                '',                                  '244',             'Centro',                                                      'Araras',        'SP',             'labv@araras.sp.gov.br',       '(19) 3543-5400',  1),
                  ('ESF Vital Pacífico Homem',                                         '13606-414',    'Avenida Irineu Carrocci',                       'até 1458/1459',                     '1469',            'Jardim José Ometto II',                                       'Araras',        'SP',             'esf_vph@araras.sp.gov.br',    '(19) 3544-5411',  1),
                  ('Hospital de Campanha Covid 19',                                    '13606-414',    'Rua Nelson Ferreira',                           '',                                  's/nº',            'Jardim José Ometto II',                                       'Araras',        'SP',             'hcc19@araras.sp.gov.br',      '(19) 3543-1522',  0),
                  ('Hospital São Leopoldo Mandic',                                     '13601-200',    'Avenida Padre Alarico Zacharias',               '',                                  '1253',            'Jardim Belvedere',                                            'Araras',        'SP',             'hslm@araras.sp.gov.br',       '(19) 3543-3211',  1),
                  ('Hospital Irmandade da Santa Casa de Misericórdia de Araras',       '13600-695',    'Praça Doutor Narciso Gomes',                    '',                                  '49',              'Centro',                                                      'Araras',        'SP',             'hiscma@araras.sp.gov.br',     '(19) 3543-5400',  1),
                  ('ESF Dr. Orlando Zaniboni',                                         '13606-643',    'Rua Francisco Cressoni',                        '',                                  '158',             'Parque Tiradentes',                                           'Araras',        'SP',             'esf_oz@araras.sp.gov.br',     '(19) 3541-7791',  1),
                  ('ESF Dr. Sebastião Jair Mourão',                                    '13606-314',    'Rua do Estudante',                              '',                                  '110',             'Jardim José Ometto I',                                        'Araras',        'SP',             'esf_sjm@araras.sp.gov.br',    '(19) 3544-7754',  0),
                  ('ESF Francisco Nicola Cascelli',                                    '13604-172',    'Rua Melânia Baraldi Maróstica',                 '',                                  '550',             'Parque das Árvores',                                          'Araras',        'SP',             'esf_fnc@araras.sp.gov.br',    '(19) 3544-5424',  1),
                  ('ESF Jeronymo Ometto',                                              '13603-027',    'Rua Ciro Lagazzi',                              'até 798/799',                       '285',             'Jardim Cândida',                                              'Araras',        'SP',             'esf_jo@araras.sp.gov.br',     '(19) 3541-9490',  1),
                  ('ESF Lucia Boquette Meneghetti',                                    '13601-361',    'Rua Allan Kardec',                              '',                                  's/nº',            'Vila Dona Rosa Zurita',                                       'Araras',        'SP',             'esf_lbm@araras.sp.gov.br',    '(19) 3544-7533',  1),
                  ('ESF Madre Carla Rabolin',                                          '13604-312',    'Rua Carlindo Fernandes',                        '',                                  's/nº',            'Jardim Residencial Alvorada',                                 'Araras',        'SP',             'esf_mcr@araras.sp.gov.br',    '(19) 3551-3563',  1),
                  ('ESF Narciso Gomes II',                                             '13601-430',    'Avenida Presidente Café Filho',                 '',                                  '209',             'Conjunto Habitacional Narciso Gomes',                         'Araras',        'SP',             'esf_ng@araras.sp.gov.br',     '(19) 3541-7898',  1),
                  ('ESF Ophelia Geraci Pesse',                                         '13604-472',    'Avenida Professor Dirçon Kammer',               '',                                  '880',             'Jardim Alto da Colina',                                       'Araras',        'SP',             'esf_ogp@araras.sp.gov.br',    '(19) 3542-4137',  1),
                  ('ESF Otavio João Breda',                                            '13606-839',    'Rua João Puppi',                                '',                                  '15',              'Parque Dom Pedro',                                            'Araras',        'SP',             'esf_ojb@araras.sp.gov.br',    '(19) 3541-7593',  1),
                  ('ESF Dr. Fermin Blanco Vianna',                                     '13606-350',    'Rua Dalton Bird de Camargo Preto',              '',                                  '42',              'Jardim José Ometto II',                                       'Araras',        'SP',             'esf_fbv@araras.sp.gov.br',    '(19) 3544-8559',  1),
                  ('ESF Dr. Bento Feres',                                              '13607-507',    'Rua Júlia Luiz Ruete',                          '',                                  '245',             'Jardim Ouro Verde II',                                        'Araras',        'SP',             'esf_bf@araras.sp.gov.br',     '(19) 3542-5453',  1),
                  ('ESF Antônio Simoes Pontes',                                        '13605-300',    'Avenida João Rossi',                            '',                                  's/nº',            'Chácaras Granja São Francisco',                               'Araras',        'SP',             'esf_asp@araras.sp.gov.br',    '(19) 3547-3195',  1),
                  ('Centro Odontologico Dr. Solon de Oliveira Fernandes',              '13606-326',    'Avenida Lourenço Batistella',                   '',                                  '514',             'Jardim José Ometto I',                                        'Araras',        'SP',             'co_sof@araras.sp.gov.br',     '(19) 3541-7211',  0),
                  ('Centro Médico Social Comunitário Irma Maria Diva Patarra',         '13601-200',    'Avenida Padre Alarico Zacharias',               '',                                  '300',             'Jardim Belvedere',                                            'Araras',        'SP',             'cm_imdp@araras.sp.gov.br',    '(19) 3543-3088',  0),
                  ('Centro Infantil Dr. Hercio Marcos Cintra Arantes',                 '13601-001',    'Avenida Washington Luiz',                       'de 402/403 ao fim',                 '545',             'Vila Michielin',                                              'Araras',        'SP',             'ci_hmca@araras.sp.gov.br',    '(19) 3542-9909',  1),
                  ('Centro de Saúde Dra Rosa Chelminsk Teixeira',                      '13601-140',    'Avenida Governador Garcez',                     '',                                  '137',             'Jardim Belvedere',                                            'Araras',        'SP',             'cs_rct@araras.sp.gov.br',     '(19) 3542-6164',  1),
                  ('Centro de Saúde Da Mulher Jandira A Leite Duarte',                 '13602-005',    'Rua dos Antúrios',                              'até 48/49',                         '30',              'Jardim Sobradinho',                                           'Araras',        'SP',             'csm_jad@araras.sp.gov.br',    '(19) 3551-5440',  1),
                  ('Centro de Imagem Radiológica',                                     '13601-140',    'Avenida Governador Garcez',                     '',                                  's/nº',            'Jardim Belvedere',                                            'Araras',        'SP',             'cim@araras.sp.gov.br',        '(19) 3543-3055',  0),
                  ('CDI Syrius',                                                       '13600-695',    'Praça Doutor Narciso Gomes',                    '',                                  '49',              'Centro',                                                      'Araras',        'SP',             'cdis@araras.sp.gov.br',       '(19) 3805-3737',  0),
                  ('CAPS IJ Infanto Juvenil',                                          '13601-008',    'Rua Carlindo Pereira da Costa',                 '',                                  's/nº',            'Vila Michielin',                                              'Araras',        'SP',             'caps_ij@araras.sp.gov.br',    '(19) 3551-0277',  1),
                  ('CAPS II Idalina Corredor Victorello',                              '13607-200',    'Avenida Loreto',                                'até 1298 - lado par',               '1291',            'Jardim das Flores',                                           'Araras',        'SP',             'caps_icv@araras.sp.gov.br',   '(19) 3544-5874',  1),
                  ('CAPS AD Arceu Scanavini',                                          '13605-060',    'Rua Doutor Fábio Fachini',                      '',                                  '1011',            'Vila Candinha',                                               'Araras',        'SP',             'caps_as@araras.sp.gov.br',    '(19) 3542-0905',  1),
                  ('APAE de Araras Sitio Arco Iris',                                   '13609-300',    'Rodovia Wilson Finardi',                        '',                                  's/nº',            'Jardim dos Ypês',                                             'Araras',        'SP',             'apae@araras.sp.gov.br',       '(19) 3541-3133',  1),
                  ('Centro de Distribuicao de Imunobiológicos de Araras',              '13601-111',    'Rua Campos Sales',                              '',                                  '33',              'Jardim Belvedere',                                            'Araras',        'SP',             'cdi@araras.sp.gov.br',        '(19) 3543-1522',  0),
                  ('CDB Araras Centro de Diagnósticos Brasil',                         '13607-220',    'Rua Hercília Dal Pietro',                       'até 298/299',                       '555',             'Jardim das Flores',                                           'Araras',        'SP',             'cdb@araras.sp.gov.br',        '(19) 3543-4600',  1)
      ) AS T (Name, Address_Cep, Address_Street, Address_Complement, Address_Number, Address_Neighborhood, Address_City, Address_State, Contact_Email, Contact_Phone, IsActive)
)

INSERT INTO [dbo].[Facilities]
            ([Name]
            ,[Address_Cep]
            ,[Address_Street]
            ,[Address_Complement]
            ,[Address_Number]
            ,[Address_Neighborhood]
            ,[Address_City]
            ,[Address_State]
            ,[Contact_Email]
            ,[Contact_Phone]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
SELECT
      Name,
      Address_Cep,
      Address_Street,
      Address_Complement,
      Address_Number,
      Address_Neighborhood,
      Address_City,
      Address_State,
      Contact_Email,
      Contact_Phone,
      CreatedOn,
      UpdatedOn,
      IsActive
FROM  RandomDates;
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @MaxMonthsAgo INT = 10
DECLARE @NOW DATETIME = GETDATE()
DECLARE @MinDate DATETIME = DATEADD(MONTH, -@MaxMonthsAgo, @NOW)
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @NOW)

;WITH RandomDates (
      Name, Cnpj, Address_Cep, Address_Street, Address_Complement, Address_Number, Address_Neighborhood, Address_City, Address_State, Contact_Email, Contact_Phone, IsActive, CreatedOn, UpdatedOn
) AS (
      SELECT
            T.Name,
            T.Cnpj,
            T.Address_Cep,
            T.Address_Street,
            T.Address_Complement,
            T.Address_Number,
            T.Address_Neighborhood,
            T.Address_City,
            T.Address_State,
            T.Contact_Email,
            T.Contact_Phone,
            T.IsActive,

            -- 'CreatedOn'
            DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % @RangeSeconds, @MinDate) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
            WHEN T.IsActive = 0
            THEN DATEADD(MINUTE, (ABS(CHECKSUM(NEWID())) % (60 * 24 * 30)) + 1, DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % @RangeSeconds, @MinDate))
            ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
               -- ('Name',                                       'Cnpj',                'Address_Cep',  'Address_Street',                                'Address_Complement'                   'Address_Number',    'Address_Neighborhood',                 'Address_City',       'Address_State',  'Contact_Email',                        'Contact_Phone',   'IsActive')
                  ('Droga Raia',                                 '44.177.977/0001-83',  '13607-280',    'Avenida Melvin Jones',                          'de 921 a 1699 - lado ímpar',          '1335',              'Centro',                               'Araras',             'SP',             'sac@droga-raia.com.br',                '(19) 3541-0038',   1),
                  ('Farmais Distribuidora',                      '11.582.072/0001-12',  '04152-040',    'Avenida Maria Conceição',                       '',                                    '1050',              'Jardim da Saúde',                      'São Paulo',          'SP',             'comercial@farmais.com.br',             '(11) 5075-9911',   1),
                  ('Ultrafarma',                                 '06.862.412/0001-08',  '02751-000',    'Rua dos Três Irmãos',                           '',                                    '122',               'Vila Progredior',                      'São Paulo',          'SP',             'atendimento@ultrafarma.com.br',        '(11) 4003-4116',   1),
                  ('AstraZeneca Brasil',                         '60.582.059/0001-44',  '01000-000',    'Avenida Pasteur',                               '',                                    '500',               'Jardim Botânico',                      'São Paulo',          'SP',             'contato@astrazeneca.com',              '(11) 3463-5000',   1),
                  ('Biolab Sanus Farma',                         '59.471.376/0001-39',  '05001-200',    'Avenida Francisco Matarazzo',                   '',                                    '1510',              'Lapa',                                 'São Paulo',          'SP',             'atendimento@biolab.com.br',            '(11) 3616-0800',   1),
                  ('Farmácia Avenida Araras',                    '44.214.385/0001-65',  '13607-061',    'Avenida da Saudade',                            '',                                    '174',               'Jardim Nossa Senhora de Fátima',       'Araras',             'SP',             'contato@avenida.com.br',               '(19) 3541-2345',   1),
                  ('Aché Laboratórios',                          '60.115.279/0001-18',  '07034-904',    'Rodovia Presidente Dutra',                      'km 222,2',                            'S/N',               'Porto da Igreja',                      'Guarulhos',          'SP',             'atendimento@ache.com.br',              '(11) 3278-1000',   1),
                  ('Marjan Farma',                               '59.514.229/0001-49',  '04755-070',    'Rua Gibraltar',                                 '',                                    '195',               'Santo Amaro',                          'São Paulo',          'SP',             'marjan@marjan.com.br',                 '(11) 3078-3122',   0),
                  ('Ava Distribuidora de Produtos de Limpeza',   '11.880.018/0001-41',  '07739-095',    'Rua Alvarenga Peixoto',                         '(Vl S Gonçalo)',                      '143',               'Laranjeiras',                          'Caieiras',           'SP',             'atendimento@avadistribuidora.com.br',  '(11) 2952-2220',   1),
                  ('Laboratório Valeant',                        '60.610.038/0001-06',  '02058-000',    'Rua do Forte',                                  '',                                    '102',               'Centro',                               'São Paulo',          'SP',             'atendimento@valeant.com.br',           '(11) 3178-4000',   0),
                  ('Central Farma Araras',                       '09.334.790/0001-27',  '13600-070',    'Rua Tiradentes',                                'até 630/631',                         '243',               'Centro',                               'Araras',             'SP',             'contato@centralfarma.com.br',          '(19) 3541-3131',   1),
                  ('Laboratório Daudt',                          '60.215.498/0001-65',  '21540-100',    'Rua Simões da Mota',                            '',                                    '57',                'Turiaçu',                              'Rio de Janeiro',     'RJ',             'sac@daudt.com.br',                     '(21) 3369-8500',   1),
                  ('Apsen Farmacêutica',                         '60.535.417/0001-80',  '04753-001',    'Rua Barão do Rio Branco',                       'de 462/463 ao fim',                   '835',               'Santo Amaro',                          'São Paulo',          'SP',             'apsen@apsen.com.br',                   '(11) 5645-5011',   1),
                  ('Cimed Indústria Farmacêutica',               '02.814.497/0001-07',  '01228-200',    'Avenida Angélica',                              'de 1698 ao fim - lado par',           '2248',              'Consolação',                           'São Paulo',          'SP',             'tributario@grupocimed.com.br',         '(11) 3544-7200',   1),
                  ('Eurofarma Laboratórios',                     '62.579.262/0001-70',  '04603-903',    'Avenida Vereador José Diniz',                   '',                                    '3465',              'Santo Amaro',                          'São Paulo',          'SP',             'contato@eurofarma.com.br',             '(11) 3848-5000',   1),
                  ('EMS',                                        '61.442.807/0001-09',  '13186-901',    'Rodovia Jornalista Francisco Aguirre Proença',  'Km 08',                               'S/N',               'Chácaras Assay',                       'Hortolândia',        'SP',             'sac@ems.com.br',                       '(19) 3866-2000',   1),
                  ('Blau Farmacêutica',                          '02.438.344/0001-40',  '06705-030',    'Rodovia Raposo Tavares',                        'do km 28,002 ao km 31,000 - lado p',  '2833',              'Jardim do Rio Cotia',                  'Cotia',              'SP',             'contato@blaufarma.com.br',             '(11) 4615-9400',   1),
                  ('Center Cópias',                              '54.298.978/0001-00',  '13600-060',    'Rua Júlio Mesquita',                            'até 628/629',                         '376',               'Centro',                               'Araras',             'SP',             'contato@centercopias.com.br',          '(19) 3544-7016',   1),
                  ('Cristália Produtos Químicos Farmacêuticos',  '47.283.136/0001-20',  '05413-002',    'Av. Eugênio de Medeiros',                       '',                                    '1205',              'Pinheiros',                            'São Paulo',          'SP',             'contato@cristalia.com.br',             '(11) 3083-2000',   1),
                  ('União Química Farmacêutica Nacional',        '61.104.342/0001-40',  '04552-000',    'Rua do Rocio',                                  '',                                    '2400',              'Vila Olímpia',                         'São Paulo',          'SP',             'contato@uniaofarmaceutica.com.br',     '(11) 3046-3300',   1),
                  ('Drogaria Romana',                            '52.935.954/0001-90',  '13603-004',    'Avenida Romana Ometto',                         '',                                    '231',               'Jardim Cândida',                       'Araras',             'SP',             'romana@sac.com.br',                    '(19) 3541-8910',   1),
                  ('Hypera Pharma',                              '16.438.820/0001-97',  '05676-120',    'Avenida Magalhães de Castro',                   'de 1287/1288 ao fim',                 '4800',              'Cidade Jardim',                        'São Paulo',          'SP',             'sac@hypera.com.br',                    '(19) 3805-5000',   1),
                  ('Drogaria São Paulo',                         '74.248.725/0001-30',  '13600-001',    'Avenida Dona Renata',                           'Norte - de 268 a 2732 - lado par',    '1454',              'Centro',                               'Araras',             'SP',             'araras1@drogariasaopaulo.com.br',      '(19) 99724-9873',  1),
                  ('Bayer Pharma',                               '57.418.315/0001-14',  '04551-010',    'Rua Fidêncio Ramos',                            '',                                    '302',               'Vila Olímpia',                         'São Paulo',          'SP',             'contato@bayer.com.br',                 '(11) 3167-7000',   1),
                  ('Pfizer Brasil',                              '33.202.663/0001-07',  '04583-905',    'Av. Dr. Chucri Zaidan',                         '',                                    '920',               'Vila Cordeiro',                        'São Paulo',          'SP',             'sac.brasil@pfizer.com',                '(11) 2127-7000',   1),
                  ('Sanofi Medley',                              '33.557.704/0001-09',  '03071-000',    'Rua Humberto de Campos',                        '',                                    '400',               'Parque São Jorge',                     'São Paulo',          'SP',             'sac@medley.com.br',                    '(11) 2659-4000',   1),
                  ('Farmad',                                     '04.503.891/0001-33',  '13600-040',    'Praça Barão de Araras',                         '',                                    '418',               'Centro',                               'Araras',             'SP',             'araras@farmad.com.br',                 '(19) 3542-9876',   1),
                  ('Multilab Indústria Farmacêutica',            '57.232.247/0001-15',  '03330-000',    'Rua São Jorge',                                 '',                                    '125',               'Jardim São Jorge',                     'São Paulo',          'SP',             'contato@multilab.com.br',              '(11) 2688-3000',   0),
                  ('Legrand Indústria Química e Farmacêutica',   '61.123.456/0001-08',  '01415-000',    'Rua das Acácias',                               '',                                    '500',               'Jardim América',                       'São Paulo',          'SP',             'contato@legrand.com.br',               '(11) 3815-6000',   1),
                  ('Neo Química Produtos Farmacêuticos',         '00.721.114/0001-60',  '04123-020',    'Rua dos Trabalhadores',                         '',                                    '500',               'Vila Mariana',                         'São Paulo',          'SP',             'sac@neoquimica.com.br',                '(11) 3134-7000',   1),
                  ('Sandoz Farmacêutica',                        '33.222.111/0001-30',  '01449-000',    'Av. Europa',                                    '',                                    '123',               'Jardim Europa',                        'São Paulo',          'SP',             'contato@sandoz.com.br',                '(11) 3897-9000',   1),
                  ('Drogaria Ultra Popular',                     '34.038.090/0001-21',  '13600-060',    'Rua Júlio Mesquita',                            'até 628/629',                         '466',               'Centro',                               'Araras',             'SP',             'info@ultrapopular.com.br',             '(19) 3541-1234',   1),
                  ('Farmácia Ararense',                          '44.206.845/0001-03',  '13600-680',    'Praça Martinico Prado',                         '',                                    '38',                'Centro',                               'Araras',             'SP',             'sac@ararenese.com.br',                 '(19) 3541-5678',   1),
                  ('Farmácia Drogal',                            '44.556.778/0001-52',  '13601-298',    'Avenida Padre Alarico Zacharias',               'de 841 ao fim - lado ímpar',          '1057',              'Jardim Nova Araras',                   'Araras',             'SP',             'drogalararas1@drogal.com.br',          '(19) 3542-6142',   1),
                  ('Drogaria Total',                             '10.234.891/0001-40',  '13600-970',    'Rua Tiradentes',                                '336',                                 '610',               'Centro',                               'Araras',             'SP',             'atendimento@drogariatotal.com.br',     '(19) 3542-1212',   1),
                  ('Farmácia Aquarius',                          '62.493.837/0001-18',  '13601-430',    'Avenida Presidente Café Filho',                 '',                                    '262',               'Conjunto Habitacional Narciso Gomes',  'Araras',             'SP',             'sac@farmaciaaquarius.com.br',          '(19) 3352-5135',   1),
                  ('Farma Conde Araras',                         '01.838.443/0001-57',  '13600-060',    'Rua Júlio Mesquita',                            'até 628/629',                         '466',               'Centro',                               'Araras',             'SP',             'contato@farmaconde.com.br',            '(19) 3542-5197',   1),
                  ('Laboratório Baldacci',                       '60.672.246/0001-49',  '04507-000',    'Rua Pedro Antônio de Magalhães',                '',                                    '640',               'Vila Nova Conceição',                  'São Paulo',          'SP',             'contato@baldacci.com.br',              '(11) 5082-1100',   0),
                  ('Papelaria 2000',                             '85.866.786/0001-87',  '13600-110',    'Rua Marechal Deodoro',                          '',                                    '611',               'Centro',                               'Araras',             'SP',             'contato@papelaria2000.com.br',         '(19) 3541-1276',   1),
                  ('Farmácia Belvedere',                         '02.872.781/0001-92',  '13601-100',    'Avenida Padre Atílio',                          '',                                    '144',               'Jardim Belvedere',                     'Araras',             'SP',             'vendas@farmaciabelvedere.com.br',      '(19) 3541-6666',   1),
                  ('Drogaria Santa Cândida',                     '63.223.431/0001-45',  '13603-017',    'Rua Oswaldo Russo',                             '',                                    '190',               'Jardim Cândida',                       'Araras',             'SP',             'santacandida@araras.com.br',           '(19) 3542-4545',   1),
                  ('Drogaria Copacabana',                        '41.002.112/0001-76',  '13609-317',    'Rua João Melari',                               '',                                    '329',               'Jardim Copacabana',                    'Araras',             'SP',             'copacabana@drogaria.com.br',           '(19) 3541-7170',   1),
                  ('Casa da Limpeza',                            '05.432.109/0001-32',  '13600-569',    'Avenida Capitão Arthur dos Santos',             '',                                    '459',               'Vila Bressan',                         'Araras',             'SP',             'vendas@casadalimpezaararas.com',       '(19) 3351-1434',   1),
                  ('Phármakon Farmácia de Manipulação',          '29.334.112/0001-55',  '13600-040',    'Praça Barão de Araras',                         '',                                    '67',                'Centro',                               'Araras',             'SP',             'biosaudeararas@farmacia.com.br',       '(19) 99910-9043',  0),
                  ('Farmácia Ararense - Loja 2',                 '07.999.123/0001-81',  '13607-200',    'Avenida Loreto',                                'até 1298 - lado par',                 '1380',              'Jardim São João',                      'Araras',             'SP',             'sac@ararenese.com.br',                 '(19) 3544-8097',   1),
                  ('Droga Raia',                                 '08.445.678/0001-10',  '13600-200',    'Rua Tiradentes',                                'até 630/631',                         '501',               'Centro',                               'Araras',             'SP',             'sac@droga-raia.com.br',                '(19) 3547-8165',   1),
                  ('Diffucap Chemobras',                         '45.161.472/0001-00',  '07024-000',    'Rua São Paulo',                                 '',                                    '200',               'Centro',                               'Guarulhos',          'SP',             'contato@diffucap.com.br',              '(11) 2440-1000',   0),
                  ('Farmácia Drogal',                            '33.556.778/0001-09',  '13606-010',    'Rua Tiradentes',                                'até 630/631',                         '480',               'Centro',                               'Araras',             'SP',             'drogalararas2@drogal.com.br',          '(19) 3551-0202',   1),
                  ('Nova Era Farmácia Homeopatia',               '27.334.225/0001-13',  '13600-070',    'Rua Tiradentes',                                'até 630/631',                         '59',                'Centro',                               'Araras',             'SP',             'orcamento@farmacianovaera.com.br',     '(19) 3541-3419',   0),
                  ('Comercial Sabbadini',                        '61.777.888/0001-02',  '13600-120',    'Rua Benedita Nogueira',                         '',                                    '150',               'Centro',                               'Araras',             'SP',             'orcamento@comercialsabbadini.com.br',  '(19) 3541-5221',   1),
                  ('Drogaria Bem Viver',                         '65.334.225/0001-26',  '13601-200',    'Avenida Padre Alarico Zacharias',               '',                                    '70',                'Jardim Belvedere',                     'Araras',             'SP',             'bemviver@farmacia.com.br',             '(19) 3541-9797',   1),
                  ('Farmácia Drogal',                            '17.112.334/0001-90',  '13607-213',    'Avenida José Marques da Silva',                 '',                                    '1565',              'Jardim das Flores',                    'Araras',             'SP',             'drogalararas2@drogal.com.br',          '(19) 3352-5915',   1),
                  ('Mantecorp Farmasa',                          '61.082.426/0002-07',  '06465-134',    'Rua Bonnard (Green Valley I)',                  '',                                    '980',               'Alphaville Empresarial',               'Barueri',            'SP',             'daniel.almeida@hypera.com.br',         '(62) 3878-8150',   0),
                  ('Germed Farmacêutica',                        '45.992.062/0001-65',  '13186-901',    'Rodovia Jornalista Francisco Aguirre Proença',  '',                                    'S/N KM 08',         'Chácara Assay',                        'Hortolândia',        'SP',             'contabil.holding@ems.com.br',          '(19) 3887-9800',   1),
                  ('FQM Farmoquímica',                           '12.345.678/0001-15',  '04530-001',    'Rua Doutor Renato Paes de Barros',              'de 631/632 ao fim',                   '750',               'Itaim Bibi',                           'São Paulo',          'SP',             'sac@fqm.com.br',                       '(11) 4000-0000',   1),
                  ('Drogaria Tiradentes',                        '60.772.002/0001-92',  '13606-620',    'Rua Laerte Tognasca',                           '',                                    '462',               'Parque Tiradentes',                    'Araras',             'SP',             'tiradentes@drogaria.com.br',           '(19) 97818-4796',  1),
                  ('Laboratório Teuto Brasileiro',               '97.033.645/0001-62',  '05307-000',    'Rua Major Paladino',                            'até 469/470',                         '128',               'Vila Ribeiro de Barros',               'São Paulo',          'SP',             'contato@teuto.com.br',                 '(11) 3645-0871',   1),
                  ('Geolab Indústria Farmacêutica',              '98.765.432/0001-24',  '74000-000',    'Rua dos Laboratórios',                          '',                                    '200',               'Polo Industrial',                      'Goiânia',            'GO',             'contato@geolab.com.br',                '(62) 3900-0000',   1),
                  ('Drogasil Araras',                            '01.234.567/0001-08',  '13600-001',    'Avenida Dona Renata',                           'Norte - de 268 a 2732 - lado par',    '2345',              'Centro',                               'Araras',             'SP',             'araras@drogasil.com.br',               '(19) 3541-4545',   1),
                  ('X-Data Papelaria',                           '42.144.710/0001-35',  '13600-140',    'Rua José Bonifácio',                            '',                                    '717',               'Centro',                               'Araras',             'SP',             'vendas@xdata.com.br',                  '(19) 3543-2000',   1),
                  ('Dimebrás Distribuidora Farmacêutica',        '42.545.039/0001-34',  '88133-560',    'Rua Cecília do Rego Almeida',                   '',                                    '300',               'Jardim Eldorado',                      'Palhoça',            'SC',             'dimebras@dimebras.com.br',             '(48) 3224-1834',   1),
                  ('Medmais Distribuidora',                      '54.223.019/0001-26',  '48400-000',    'Rua João Fernandes da Gama',                    '',                                    '160',               'Centro',                               'Ribeira do Pombal',  'BA',             'medmais@medmais.com.br',               '(75) 9904-7884',   1),
                  ('VPA Atacadista',                             '57.929.071/0001-90',  '03031-000',    'Rua Tiers',                                     '',                                    '505',               'Pari',                                 'Pari',               'SP',             'falecom@vpa.com.br',                   '(11) 3328-1145',   1),
                  ('Torrent Pharma',                             '33.197.886/0001-00',  '01155-060',    'Rua Doutor Alfredo de Castro',                  '',                                    '200',               'Barra Funda',                          'São Paulo',          'SP',             'contato@torrentpharma.com.br',         '(11) 3874-9000',   1),
                  ('Libbs Farmacêutica',                         '33.197.886/0001-00',  '05036-040',    'Avenida Marquês de São Vicente',                'de 2200/2201 ao fim',                 '2219',              'Água Branca',                          'São Paulo',          'SP',             'contato@libbs.com.br',                 '(11) 3874-9000',   1),
                  ('Tecnofarma',                                 '00.111.222/0001-95',  '13000-000',    'Avenida Marechal Deodoro',                      '',                                    '789',               'Centro',                               'Campinas',           'SP',             'contato@tecnofarma.com.br',            '(19) 3232-4444',   0),
                  ('Boehringer Ingelheim Brasil',                '60.846.120/0001-00',  '04794-000',    'Avenida das Nações Unidas',                     'lado ímpar',                          '13797',             'Vila Gertrudes',                       'São Paulo',          'SP',             'contato@boehringer-ingelheim.com.br',  '(11) 4949-4700',   1),
                  ('Biosintética Farmacêutica',                  '61.272.164/0001-80',  '02055-000',    'Rua Doutor José Bernardo Pinto',                '',                                    '333',               'Vila Guilherme',                       'São Paulo',          'SP',             'contato@biosintetica.com.br',          '(11) 2171-8000',   0),
                  ('Pharma Total Zona Leste',                    '46.112.334/0001-34',  '13606-360',    'Avenida Presidente Vargas',                     'até 799 - lado ímpar',                '599',               'Jardim José Ometto II',                'Araras',             'SP',             'pharmatotalzl@farmacia.com.br',        '(19) 3544-3072',   1),
                  ('Biobrás',                                    '30.136.215/0001-85',  '39400-000',    'Avenida Caxingui',                              '',                                    '25',                'Jardim Everest',                       'Montes Claros',      'MG',             'contato@biobras.com.br',               '(38) 3218-1000',   0),
                  ('Meizler-UCB Biopharma',                      '61.123.456/0001-09',  '04543-011',    'Avenida Presidente Juscelino Kubitschek',       'de 953 ao fim - lado ímpar',          '1327',              'Vila Nova Conceição',                  'São Paulo',          'SP',             'contato@meizler.com.br',               '(11) 3847-1700',   1),
                  ('Momenta Farmacêutica',                       '05.679.548/0001-90',  '02911-000',    'Rua Enéas Luís Carlos Barbanti',                '',                                    '216',               'Freguesia do Ó',                       'São Paulo',          'SP',             'sac@momentafarma.com.br',              '(11) 3977-9000',   1),
                  ('Mafra Hospitalar',                           '80.006.136/0001-80',  '80730-000',    'Rua Padre Anchieta',                            '',                                    '2050',              'Bigorrilho',                           'Curitiba',           'PR',             'contato@mafra.com.br',                 '(41) 3218-5000',   1),
                  ('Zambon Laboratórios',                        '61.189.789/0001-00',  '04794-000',    'Avenida das Nações Unidas',                     'lado ímpar',                          '14401',             'Vila Gertrudes',                       'São Paulo',          'SP',             'sac@zambon.com.br',                    '(11) 2110-4000',   1),
                  ('Drogaria Araras Farma',                      '24.112.334/0001-11',  '13606-510',    'Rua Antonia Gomes da Silva Malvestiti',         '',                                    '165',               'Jardim Morumbi',                       'Araras',             'SP',             'sac@drogariaararasfarma.com.br',       '(19) 3541-0753',   1),
                  ('Laboratório Farmacêutico Arboris',           '11.223.344/0001-91',  '18087-000',    'Rua das Indústrias',                            '',                                    '50',                'Distrito Industrial',                  'Sorocaba',           'SP',             'contato@arboris.com.br',               '(15) 3211-5000',   0),
                  ('Reval Atacado de Papelaria',                 '05.678.910/0001-12',  '17232-232',    'Rua Santo Antonio',                             '',                                    '1699',              'Distrito Industrial',                  'Itapuí',             'SP',             'vendas@reval.com.br',                  '(14) 3664-9811',   1),
                  ('Laboratório Catarinense',                    '84.683.746/0001-86',  '89204-000',    'Rua Doutor João Colin',                         '',                                    '1000',              'América',                              'Joinville',          'SC',             'contato@labcatarinense.com.br',        '(47) 3451-2000',   0),
                  ('Lanlimp',                                    '22.334.556/0001-12',  '26373-280',    'Rua Minas Gerais',                              '',                                    '1300',              'Distrito Industrial',                  'Rio de Janeiro',     'RJ',             'atendimento@lanlimp.com.br',           '(24) 2106-9420',   1),
                  ('Drogaria Samval',                            '18.772.001/0001-88',  '13603-027',    'Rua Ciro Lagazzi',                              'até 798/799',                         '630',               'Jardim Cândida',                       'Araras',             'SP',             'sac@drogariasamval.com.br',            '(19) 3541-5832',   1),
                  ('Distribuidora Alfa Saúde',                   '33.445.667/0001-01',  '13210-000',    'Rua das Mangueiras',                            '',                                    '321',               'Bairro Novo',                          'Jundiaí',            'SP',             'vendas@alfasaude.com.br',              '(11) 4588-9900',   0)
      ) AS T (Name, Cnpj, Address_Cep, Address_Street, Address_Complement, Address_Number, Address_Neighborhood, Address_City, Address_State, Contact_Email, Contact_Phone, IsActive)
)

INSERT INTO [dbo].[Suppliers]
            ([Name]
            ,[Cnpj]
            ,[Address_Cep]
            ,[Address_Street]
            ,[Address_Complement]
            ,[Address_Number]
            ,[Address_Neighborhood]
            ,[Address_City]
            ,[Address_State]
            ,[Contact_Email]
            ,[Contact_Phone]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
SELECT
      Name,
      Cnpj,
      Address_Cep,
      Address_Street,
      Address_Complement,
      Address_Number,
      Address_Neighborhood,
      Address_City,
      Address_State,
      Contact_Email,
      Contact_Phone,
      CreatedOn,
      UpdatedOn,
      IsActive
FROM  RandomDates;
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @MaxMonthsAgo INT = 10
DECLARE @NOW DATETIME = GETDATE()
DECLARE @MinDate DATETIME = DATEADD(MONTH, -@MaxMonthsAgo, @NOW)
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @NOW)

;WITH RandomDates (
      Name, Description, MainCategory, SubCategory, PresentationForm, IsActive, CreatedOn, UpdatedOn
) AS (
      SELECT
            T.Name,
            T.Description,
            T.MainCategory,
            T.SubCategory,
            T.PresentationForm,
            T.IsActive,

            -- 'CreatedOn'
            DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % @RangeSeconds, @MinDate) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
            WHEN T.IsActive = 0
            THEN DATEADD(MINUTE, (ABS(CHECKSUM(NEWID())) % (60 * 24 * 30)) + 1, DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % @RangeSeconds, @MinDate))
            ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
         -- ('Name',                                                  'Description',                                                          'MainCategory',           'SubCategory',                      'PresentationForm',       'IsActive')
            ('Dipirona 500mg',                                        'Analgésico e antitérmico.',                                            'Medicamento',            'Analgésico/Antitérmico',           'Comprimido',              1),
            ('Paracetamol 750mg',                                     'Analgésico e antitérmico.',                                            'Medicamento',            'Analgésico/Antitérmico',           'Comprimido',              1),
            ('Ibuprofeno 300mg',                                      'AINE para dor e febre.',                                               'Medicamento',            'AINE',                             'Comprimido',              1),
            ('Amoxicilina 500mg',                                     'Antibiótico penicilínico.',                                            'Medicamento',            'Antibiótico',                      'Cápsula',                 1),
            ('Cefalexina 250mg/5mL',                                  'Antibiótico cefalosporina.',                                           'Medicamento',            'Antibiótico',                      'Suspensão Oral',          1),
            ('Omeprazol 20mg',                                        'Inibidor da bomba de prótons.',                                        'Medicamento',            'Gastrointestinal',                 'Comprimido',              1),
            ('Loratadina 5mg/5mL',                                    'Antialérgico.',                                                        'Medicamento',            'Antialérgico',                     'Xarope',                  1),
            ('Máscara N95',                                           'Máscara de alta filtração, para aerossóis.',                     'Material Hospitalar',    'Descartável (EPIs)',               'Unidade',                 1),
            ('Losartana Potássica 50mg',                              'Anti-hipertensivo, bloqueador de receptor de angiotensina.',     'Medicamento',            'Cardiovascular',                   'Comprimido',              1),
            ('Cloridrato de Fluoxetina 20mg',                         'Antidepressivo ISRS.',                                                 'Medicamento',            'Antidepressivo',                   'Comprimido',              1),
            ('Diazepam 10mg',                                         'Ansiolítico benzodiazepínico.',                                        'Medicamento',            'Ansiolítico',                      'Comprimido',              1),
            ('Insulina NPH',                                          'Insulina basal.',                                                      'Medicamento',            'Antidiabético',                    'Frasco/Ampola',           1),
            ('Hidrocortisona 100mg',                                  'Corticoide EV.',                                                       'Medicamento',            'Corticosteroide',                  'Ampola',                  1),
            ('Dipirona Sódica 500mg/ml',                              'Analgésico e Antitérmico intravenoso/intramuscular.',            'Medicamento',            'Analgésico/Antitérmico',           'Ampola',                  1),
            ('Cloridrato de Clorpromazina 100mg',                     'Antipsicótico típico.',                                                'Medicamento',            'Antipsicótico',                    'Comprimido',              1),
            ('Carbonato de Lítio 300mg',                              'Estabilizador do humor.',                                              'Medicamento',            'Psiquiátrico',                     'Comprimido',              1),
            ('Butilbrometo de Escopolamina',                          'Antiespasmódico para cólicas.',                                        'Medicamento',            'Antiespasmódico',                  'Comprimido',              1),
            ('Adrenalina 1 mg/mL',                                    'Catecolamina usada em anafilaxia e parada cardíaca.',                  'Medicamento',            'Emergência',                       'Ampola',                  1),
            ('Cloridrato de Lidocaína 2% sem Vasoconstrictor',        'Anestésico local.',                                                    'Medicamento',            'Anestésico',                       'Ampola',                  1),
            ('Soro Fisiológico 500mL',                                'Solução isotônica.',                                                   'Medicamento',            'Hidratação',                       'Frasco',                  1),
            ('Água Destilada 10 mL',                                  'Diluente para injeções.',                                              'Medicamento',            'Diluente',                         'Ampola',                  1),
            ('Pilha Alcalina AA',                                     'Para equipamentos.',                                             'Material de Escritório', 'Suprimento',                       'Cartela 4 unidades',      1),
            ('Pilha Alcalina AAA',                                    'Para equipamentos.',                                             'Material de Escritório', 'Suprimento',                       'Cartela 4 unidades',      1),
            ('Cloridrato de Levomepromazina 25mg',                    'Antipsicótico sedativo.',                                              'Medicamento',            'Antipsicótico',                    'Comprimido',              1),
            ('Sulfato Ferroso',                                       'Tratamento de anemia ferropriva.',                                     'Medicamento',            'Suplemento Mineral',               'Comprimido',              1),
            ('Cloridrato de Amiodarona 200mg',                        'Antiarrítmico classe III.',                                            'Medicamento',            'Cardiovascular',                   'Comprimido',              1),
            ('Cloridrato de Tramadol 50mg/mL',                        'Analgésico opioide.',                                                  'Medicamento',            'Analgésico Opioide',               'Ampola',                  1),
            ('Morfina 10mg',                                          'Analgésico opioide potente.',                                    'Medicamento',            'Analgésico/Opioide',               'Ampola',                  1),
            ('Captopril 25mg',                                        'Antihipertensivo inibidor da ECA.',                                    'Medicamento',            'Antihipertensivo',                 'Comprimido',              1),
            ('Furosemida 40mg',                                       'Diurético de alça.',                                                   'Medicamento',            'Diurético',                        'Comprimido',              1),
            ('Cloridrato de Sertralina 50mg',                         'Antidepressivo ISRS.',                                                 'Medicamento',            'Antidepressivo',                   'Comprimido',              1),
            ('Lorazepam 2mg',                                         'Ansiolítico, Benzodiazepínico.',                                 'Medicamento',            'Psicotrópico',                     'Comprimido',              1),
            ('Vacina DTPa',                                           'Imunização contra Difteria, Tétano e Coqueluche.',               'Medicamento',            'Vacina',                           'Frasco-ampola',           1),
            ('Vacina Influenza Tetravalente',                         'Imunização anual contra o vírus da gripe.',                      'Medicamento',            'Vacina',                           'Seringa Pré-Enchida',     1),
            ('Cloreto de Benzalcônio',                                'Antisséptico tópico.',                                                 'Medicamento',            'Antisséptico',                     'Solução',                 1),
            ('Sais de Reidratação Oral',                              'Reposição hidroeletrolítica.',                                         'Medicamento',            'Hidratação',                       'Sachê',                   1),
            ('Propranolol 40mg',                                      'Betabloqueador.',                                                      'Medicamento',            'Antihipertensivo',                 'Comprimido',              1),
            ('AAS 100mg',                                             'Antiagregante plaquetário para prevenção cardiovascular.',             'Medicamento',            'Antiagregante',                    'Comprimido',              1),
            ('Cinarizina 75mg',                                       'Vasodilatador e antivertiginoso.',                                     'Medicamento',            'Neurológico',                      'Comprimido',              1),
            ('Cloridrato de Clomipramina 25mg',                       'Antidepressivo tricíclico.',                                           'Medicamento',            'Antidepressivo',                   'Comprimido',              1),
            ('Cloridrato de Nortriptilina 25mg',                      'Antidepressivo tricíclico.',                                           'Medicamento',            'Antidepressivo',                   'Comprimido',              1),
            ('Loratadina 10mg',                                       'Antialérgico.',                                                        'Medicamento',            'Antialérgico',                     'Comprimido',              1),
            ('Polivitamínico Baby',                                   'Suplemento infantil.',                                                 'Medicamento',            'Vitamina',                         'Gotas',                   1),
            ('Glicose 25%',                                           'Reposição de glicose hiperosmolar.',                                   'Medicamento',            'Solução Energética',               'Ampola',                  1),
            ('Soro Fisiológico 0,9%',                                 'Solução Salina Estéril.',                                        'Medicamento',            'Solução Parenteral',               'Bolsa 100ml',             1),
            ('Óculos de Proteção',                                    'Para EPIs de proteção ocular.',                                  'Material Hospitalar',    'Descartável (EPIs)',               'Unidade',                 0),
            ('Cloridrato de Amitriptilina 25mg',                      'Antidepressivo tricíclico.',                                           'Medicamento',            'Antidepressivo',                   'Comprimido',              1),
            ('Digoxina 0,25mg',                                       'Glicosídeo cardíaco.',                                                 'Medicamento',            'Cardiovascular',                   'Comprimido',              1),
            ('Espironolactona 25mg',                                  'Diurético poupador de potássio.',                                'Medicamento',            'Renal/Diurético',                  'Comprimido',              1),
            ('Clonazepam 2mg',                                        'Benzodiazepínico ansiolítico e anticonvulsivante.',                    'Medicamento',            'Ansiolítico',                      'Comprimido',              1),
            ('Cloridrato de Levomepromazina 100mg',                   'Antipsicótico sedativo.',                                              'Medicamento',            'Antipsicótico',                    'Comprimido',              1),
            ('Fenobarbital 40mg/mL',                                  'Anticonvulsivante.',                                                   'Medicamento',            'Anticonvulsivante',                'Solução',                 1),
            ('Metronidazol 250mg',                                    'Antiprotozoário e antibacteriano anaeróbio.',                          'Medicamento',            'Antibiótico',                      'Comprimido',              1),
            ('Fluconazol 150mg',                                      'Antifúngico oral de dose única.',                                'Medicamento',            'Antifúngico',                      'Cápsula',                 1),
            ('Cefalexina 500mg',                                      'Antibiótico cefalosporina.',                                           'Medicamento',            'Antibiótico',                      'Cápsula',                 1),
            ('Levotiroxina Sódica 100mcg',                            'Hormônio tireoidiano.',                                          'Medicamento',            'Hormonal/Endócrino',               'Comprimido',              1),
            ('Glicose 50%',                                           'Reposição rápida de glicose.',                                         'Medicamento',            'Solução Energética',               'Ampola',                  1),
            ('Cloridrato de Prometazina 25mg',                        'Antialérgico e anti-histamínico.',                                     'Medicamento',            'Antialérgico',                     'Comprimido',              1),
            ('Dramin B6 DL EV 10mL',                                  'Antiemético.',                                                         'Medicamento',            'Antiemético',                      'Ampola',                  1),
            ('Dersani',                                               'Óleo vegetal para cicatrização.',                                      'Medicamento',            'Curativos',                        'Solução',                 1),
            ('Varfarina 5mg',                                         'Anticoagulante oral.',                                                 'Medicamento',            'Anticoagulante',                   'Comprimido',              1),
            ('Dipirona Gotas 500mg/ml',                               'Analgésico e Antitérmico.',                                            'Medicamento',            'Analgésico/Antitérmico',           'Frasco',                  1),
            ('Paracetamol Gotas 200mg/mL',                            'Analgésico e Antitérmico.',                                            'Medicamento',            'Analgésico/Antitérmico',           'Frasco',                  1),
            ('Metildopa 250mg',                                       'Antihipertensivo seguro na gestação.',                                 'Medicamento',            'Antihipertensivo',                 'Comprimido',              1),
            ('Bisturi Descartável Nº 15',                             'Para incisões cirúrgicas.',                                      'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Lâmina de Bisturi Nº 22',                               'Lâmina para uso com cabo reutilizável.',                         'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 100 unidades',      1),
            ('Nitroglicerina 5mg/mL',                                 'Vasodilatador para emergências.',                                      'Medicamento',            'Cardiovascular',                   'Ampola',                  1),
            ('Alopurinol 300mg',                                      'Para tratamento da Gota.',                                       'Medicamento',            'Reumatológico',                    'Comprimido',              1),
            ('Nitrazepam 5mg',                                        'Hipnótico benzodiazepínico.',                                          'Medicamento',            'Ansiolítico/Sedativo',             'Comprimido',              1),
            ('Prednisona 20mg',                                       'Corticoide sistêmico.',                                                'Medicamento',            'Corticosteroide',                  'Comprimido',              1),
            ('Fentanil 50mcg/ml',                                     'Analgésico opioide sintético.',                                  'Medicamento',            'Analgésico/Opioide',               'Ampola',                  1),
            ('Biperideno 2mg',                                        'Anticolinérgico para parkinsonismo e distonia.',                       'Medicamento',            'Neurológico',                      'Comprimido',              1),
            ('Haloperidol 2mg/mL',                                    'Antipsicótico típico.',                                                'Medicamento',            'Antipsicótico',                    'Ampola',                  1),
            ('Agulha Múltipla para Coleta a Vácuo',                   'Para sistema de coleta de sangue a vácuo.',                      'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 100 unidades',      1),
            ('Adaptador para Coleta a Vácuo (Holder)',                'Para sistema de coleta de sangue a vácuo.',                      'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 100 unidades',      1),
            ('Garrote (Torniquete) de Borracha',                      'Para punção venosa.',                                            'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Haloperidol 5mg',                                       'Antipsicótico típico.',                                                'Medicamento',            'Antipsicótico',                    'Comprimido',              1),
            ('Bromoprida 4mg/mL',                                     'Antiemético e pró-cinético.',                                          'Medicamento',            'Antiemético',                      'Gotas',                   1),
            ('Dexclorfeniramina 2mg',                                 'Anti-histamínico.',                                                    'Medicamento',            'Antialérgico',                     'Comprimido',              1),
            ('Levonorgestrel 0,75mg',                                 'Contraceptivo de emergência.',                                         'Medicamento',            'Anticoncepcional',                 'Comprimido',              1),
            ('Carbonato de Cálcio 500mg',                             'Reposição de cálcio.',                                                 'Medicamento',            'Suplemento Mineral',               'Comprimido',              1),
            ('Bromoprida 5mg',                                        'Antiemético e pró-cinético.',                                          'Medicamento',            'Antiemético',                      'Ampola',                  1),
            ('Ceftriaxona 1g',                                        'Antibiótico de amplo espectro.',                                       'Medicamento',            'Antibiótico',                      'Frasco-ampola',           1),
            ('Sulfato de Magnésio 10%',                               'Controle de convulsões e pré-eclâmpsia.',                              'Medicamento',            'Eletrólito',                       'Ampola',                  1),
            ('Sabão Líquido Neutro para Mãos 5L',                     'Higienização básica das mãos.',                                  'Material de Limpeza',    'Produto Químico',                  'Galão',                   1),
            ('Desengordurante Industrial',                            'Para áreas de cozinha e lavanderia.',                            'Material de Limpeza',    'Produto Químico',                  'Galão 5L',                1),
            ('Alvejante sem Cloro',                                   'Para lavanderia hospitalar.',                                    'Material de Limpeza',    'Produto Químico',                  'Galão 5L',                1),
            ('Cloridrato de Imipramina 25mg',                         'Antidepressivo tricíclico.',                                           'Medicamento',            'Antidepressivo',                   'Comprimido',              1),
            ('Clopidogrel 75mg',                                      'Antiagregante plaquetário.',                                     'Medicamento',            'Cardiovascular',                   'Comprimido',              1),
            ('Atenolol 50mg',                                         'Betabloqueador seletivo.',                                       'Medicamento',            'Cardiovascular',                   'Comprimido',              1),
            ('Anlodipino 5mg',                                        'Anti-hipertensivo bloqueador de canais de cálcio.',                    'Medicamento',            'Antihipertensivo',                 'Comprimido',              1),
            ('Diltiazem 60mg',                                        'Bloqueador de canal de cálcio.',                                       'Medicamento',            'Antihipertensivo',                 'Comprimido',              1),
            ('Insulina Regular',                                      'Insulina de ação rápida.',                                             'Medicamento',            'Antidiabético',                    'Frasco/Ampola',           1),
            ('Noretisterona 0,35mg',                                  'Contraceptivo progesterona isolada.',                                  'Medicamento',            'Anticoncepcional',                 'Comprimido',              1),
            ('Seringa Descartável 5ml sem Agulha',                    'Para aspiração ou administração oral/enteral.',                  'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 100 unidades',      1),
            ('Seringa Descartável 10ml com Agulha 40x12',             'Para medicações IV ou aspiração.',                               'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Ácido Fólico 5mg',                                      'Vitamina do complexo B usada na prevenção de anemia megaloblástica.',  'Medicamento',            'Vitamina',                         'Comprimido',              1),
            ('Cloridrato de Levomepromazina 40mg/mL',                 'Antipsicótico.',                                                       'Medicamento',            'Antipsicótico',                    'Solução',                 1),
            ('Dexametasona Creme',                                    'Corticoide tópico.',                                                   'Medicamento',            'Corticosteroide',                  'Creme',                   1),
            ('Benzilpenicilina 1.200.000 UI',                         'Antibiótico penicilínico de ação prolongada.',                         'Medicamento',            'Antibiótico',                      'Ampola',                  1),
            ('Cloreto de Suxametônio 100mg',                          'Bloqueador neuromuscular de ação rápida.',                             'Medicamento',            'Anestesia',                        'Ampola',                  1),
            ('Dexclorfeniramina Xarope',                              'Antialérgico infantil.',                                               'Medicamento',            'Antialérgico',                     'Xarope',                  1),
            ('Hidróxido de Alumínio',                                 'Antiácido.',                                                           'Medicamento',            'Gastrointestinal',                 'Suspensão Oral',          1),
            ('Tiamina (B1)',                                          'Vitamina usada em deficiências e alcoolismo.',                         'Medicamento',            'Vitamina',                         'Comprimido',              1),
            ('Fluoresceína 1% Colírio',                               'Corante para exames oftálmicos.',                                      'Medicamento',            'Oftálmico',                        'Colírio',                 1),
            ('Hipoclorito de Sódio 1% Solução (Água Sanitária)',      'Para desinfecção de áreas críticas.',                            'Material de Limpeza',    'Produto Químico',                  'Galão 5L',                1),
            ('Cloreto de Sódio 0,9% 10 mL',                           'Diluente e solução fisiológica.',                                      'Medicamento',            'Reposição Hidroeletrolítica',      'Ampola',                  1),
            ('Bicarbonato de Sódio 8,4% 10 mL',                       'Corretor de acidose metabólica.',                                      'Medicamento',            'Emergência',                       'Ampola',                  1),
            ('Dopamina 50mg/ml',                                      'Para choque cardiogênico.',                                      'Medicamento',            'Emergência',                       'Ampola',                  1),
            ('Ciprofloxacino 500mg',                                  'Antibiótico quinolona.',                                               'Medicamento',            'Antibiótico',                      'Comprimido',              1),
            ('Carbamazepina 20mg/mL',                                 'Anticonvulsivante em solução oral.',                                   'Medicamento',            'Anticonvulsivante',                'Suspensão Oral',          1),
            ('Soro Fisiológico 1000mL',                               'Solução isotônica.',                                                   'Medicamento',            'Hidratação',                       'Bolsa/Frasco',            1),
            ('Complexo B',                                            'Suplemento vitamínico.',                                               'Medicamento',            'Vitamina',                         'Comprimido',              1),
            ('Cetoprofeno 50mg/mL',                                   'Antiinflamatório não esteroidal.',                                     'Medicamento',            'AINE',                             'Ampola',                  1),
            ('Touca Descartável Branca',                              'Cobertura capilar, TNT.',                                        'Material Hospitalar',    'Descartável (EPIs)',               'Pacote 100 unidades',     1),
            ('Propé Descartável Azul',                                'Cobertura para calçados.',                                       'Material Hospitalar',    'Descartável (EPIs)',               'Pacote 100 unidades',     0),
            ('Prednisona 5mg',                                        'Corticoide sistêmico.',                                                'Medicamento',            'Corticosteroide',                  'Comprimido',              1),
            ('Dexametasona 2mg/mL',                                   'Corticoide sistêmico.',                                                'Medicamento',            'Corticosteroide',                  'Ampola',                  1),
            ('Fenitoína 100mg',                                       'Anticonvulsivante.',                                                   'Medicamento',            'Anticonvulsivante',                'Comprimido',              1),
            ('Diclofenaco Sódico 50mg',                               'AINE para dor e inflamação.',                                          'Medicamento',            'AINE',                             'Comprimido',              1),
            ('Nimesulida 50mg/mL',                                    'AINE para dor e inflamação.',                                          'Medicamento',            'AINE',                             'Suspensão Oral',          1),
            ('Nifedipina 20mg',                                       'Vasodilatador para hipertensão e angina.',                             'Medicamento',            'Antihipertensivo',                 'Comprimido',              1),
            ('Carbamazepina 200mg',                                   'Anticonvulsivante e estabilizador do humor.',                          'Medicamento',            'Anticonvulsivante',                'Comprimido',              1),
            ('Glicazida 30mg',                                        'Antidiabético sulfonilureia.',                                         'Medicamento',            'Antidiabético',                    'Comprimido',              1),
            ('Periciazina 10mg',                                      'Antipsicótico.',                                                       'Medicamento',            'Antipsicótico',                    'Comprimido',              1),
            ('Nitrato de Miconazol 20mg/g',                           'Antifúngico.',                                                         'Medicamento',            'Antifúngico',                      'Creme',                   1),
            ('Levofloxacino 500mg',                                   'Antibiótico quinolona.',                                               'Medicamento',            'Antibiótico',                      'Comprimido',              1),
            ('Sulfadiazina de Prata 1%',                              'Cicatrizante para queimaduras.',                                       'Medicamento',            'Curativos',                        'Pomada',                  1),
            ('Fita Adesiva Transparente (Durex Grande)',              'Para uso geral.',                                                'Material de Escritório', 'Uso Geral',                        'Rolo',                    1),
            ('Vitaminas + Sais Minerais',                             'Suplemento polivitamínico.',                                           'Medicamento',            'Vitamina',                         'Comprimido',              1),
            ('Carvedilol 6,25mg',                                     'Betabloqueador antihipertensivo.',                                     'Medicamento',            'Antihipertensivo',                 'Comprimido',              1),
            ('Cimetidina 150mg/mL',                                   'Antagonista H2 para gastrite e refluxo.',                              'Medicamento',            'Gastrointestinal',                 'Ampola',                  1),
            ('Ambroxol 15mg/mL',                                      'Mucolítico usado para secreções respiratórias.',                       'Medicamento',            'Expectorante',                     'Xarope',                  1),
            ('Citrato de Fentanila 0,05 mg/mL',                       'Opioide para analgesia e sedação.',                                    'Medicamento',            'Analgésico Opioide',               'Ampola',                  1),
            ('Extensão Elétrica de 3 Metros',                         'Para uso em consultórios.',                                      'Material de Escritório', 'Suprimento',                       'Unidade',                 1),
            ('Aciclovir 200mg',                                       'Antiviral para herpes simples e zoster.',                              'Medicamento',            'Antiviral',                        'Comprimido',              1),
            ('Gluconato de Cálcio 10%',                               'Reposição de cálcio intravenoso.',                                     'Medicamento',            'Eletrólitos',                      'Ampola',                  1),
            ('Cimetidina 200mg',                                      'Antagonista H2.',                                                      'Medicamento',            'Gastrointestinal',                 'Comprimido',              1),
            ('Levonorgestrel 0,15 + Etinilestradiol 0,03',            'Contraceptivo hormonal combinado.',                                    'Medicamento',            'Anticoncepcional',                 'Comprimido',              1),
            ('Ácido Valproico 250mg',                                 'Antiepiléptico e estabilizador do humor.',                             'Medicamento',            'Anticonvulsivante',                'Comprimido',              1),
            ('Tioridazina 100mg',                                     'Antipsicótico.',                                                       'Medicamento',            'Antipsicótico',                    'Comprimido',              1),
            ('Oxímetro de Pulso',                                     'Para medição não invasiva da saturação de oxigênio.',            'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Bicarbonato de Sódio 8,4% 250 mL',                      'Corretor de acidose metabólica.',                                      'Medicamento',            'Emergência',                       'Frasco',                  1),
            ('Luva de Procedimento Tamanho P',                        '100% látex, não estéril.',                                       'Material Hospitalar',    'Descartável (EPIs)',               'Caixa 100 unidades',      1),
            ('Luva de Procedimento Tamanho M',                        '100% látex, não estéril.',                                       'Material Hospitalar',    'Descartável (EPIs)',               'Caixa 100 unidades',      1),
            ('Luva de Procedimento Tamanho G',                        '100% látex, não estéril.',                                       'Material Hospitalar',    'Descartável (EPIs)',               'Caixa 100 unidades',      1),
            ('Sonda de Aspiração Traqueal Nº 12',                     'Para sucção de secreções.',                                      'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Luva Cirúrgica Estéril Nº 7.5',                         'Látex estéril, com pó, par.',                                    'Material Hospitalar',    'Descartável (EPIs)',               'Par',                     1),
            ('Luva Cirúrgica Estéril Nº 8.0',                         'Látex estéril, com pó, par.',                                    'Material Hospitalar',    'Descartável (EPIs)',               'Par',                     1),
            ('Máscara Cirúrgica Tripla com Elástico',                 'Barreira de proteção facial, TNT.',                              'Material Hospitalar',    'Descartável (EPIs)',               'Caixa 50 unidades',       1),
            ('Máscara N95 PFF2',                                      'Alta filtração, para aerossóis.',                                'Material Hospitalar',    'Descartável (EPIs)',               'Unidade',                 0),
            ('Cateter Vesical de Alívio Nº 14',                       'Sonda para esvaziamento temporário da bexiga.',                  'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Avental Cirúrgico Estéril Descartável',                 'Barreira para procedimentos invasivos.',                         'Material Hospitalar',    'Descartável (EPIs)',               'Unidade',                 1),
            ('Avental de Isolamento TNT',                             'Para contato e precaução padrão.',                               'Material Hospitalar',    'Descartável (EPIs)',               'Unidade',                 1),
            ('Lápis Preto número 2',                                  'Para rascunhos.',                                                'Material de Escritório', 'Uso Geral',                        'Caixa 12 unidades',       0),
            ('Protetor Facial (Face Shield)',                         'Proteção contra respingos (gotículas).',                         'Material Hospitalar',    'Descartável (EPIs)',               'Unidade',                 1),
            ('Seringa Descartável 3ml com Agulha 25x7',               'Para injeções intramusculares ou subcutâneas.',                  'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Seringa de Insulina 1ml (30 UI)',                       'Para aplicação de Insulina.',                                    'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 10 unidades',       1),
            ('Agulha Hipodérmica 20x5.5 (Verde)',                     'Agulha fina para injeção SC ou IM pediátrica.',                  'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 100 unidades',      1),
            ('Agulha Hipodérmica 30x7 (Amarela)',                     'Agulha para injeção IM.',                                        'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 100 unidades',      1),
            ('Scalp para Punção Nº 23 (Azul)',                        'Dispositivo para venopunção infantil ou difícil.',               'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 50 unidades',       1),
            ('Sonda Vesical de Demora (Foley) Nº 16',                 'Sonda para drenagem urinária contínua.',                         'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Aspirador Cirúrgico Descartável',                       'Cânula para sucção em cirurgias.',                               'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Gaze Estéril 7,5x7,5cm 11 fios',                        'Para curativos e procedimentos.',                                'Material Hospitalar',    'Descartável (Consumo)',            'Pacote 10 unidades',      1),
            ('Gaze Não Estéril 15x30cm',                              'Para limpeza e procedimentos gerais.',                           'Material Hospitalar',    'Descartável (Consumo)',            'Pacote 500 unidades',     1),
            ('Algodão Hidrófilo 500g',                                'Para higienização e preparo da pele.',                           'Material Hospitalar',    'Descartável (Consumo)',            'Rolo',                    1),
            ('Caneta Esferográfica Azul - Bic',                       'Para uso diário, escrita de prontuários.',                       'Material de Escritório', 'Uso Geral',                        'Caixa 50 unidades',       0),
            ('Atadura de Crepe 10cm x 4,5m',                          'Para imobilização e compressão.',                                'Material Hospitalar',    'Descartável (Consumo)',            'Rolo',                    1),
            ('Esparadrapo Hospitalar 5cm x 4,5m',                     'Fita adesiva de tecido para fixação.',                           'Material Hospitalar',    'Descartável (Consumo)',            'Rolo',                    1),
            ('Fita Microporosa Hipoalergênica 2,5cm x 10m',           'Para fixação de curativos delicados.',                           'Material Hospitalar',    'Descartável (Consumo)',            'Rolo',                    1),
            ('Lençol de Papel Picotado 70cm x 50m',                   'Para cobertura de macas em consultórios.',                       'Material Hospitalar',    'Descartável (Consumo)',            'Rolo',                    1),
            ('Envelope Branco para Exames (260x360mm)',               'Para entrega de exames de imagem.',                              'Material de Escritório', 'Uso Geral',                        'Pacote 10 unidades',      1),
            ('Gel para Ultrassom Neutro 1Kg',                         'Meio de contato para exames.',                                   'Material Hospitalar',    'Descartável (Consumo)',            'Frasco',                  1),
            ('Papel Sulfite A4',                                      'Para impressão de laudos, receitas e prontuários.',              'Material de Escritório', 'Registro/Documentação',            'Caixa',                   0),
            ('Eletrodos Descartáveis para ECG',                       'Para monitoramento cardíaco.',                                   'Material Hospitalar',    'Descartável (Consumo)',            'Pacote 50 unidades',      1),
            ('Tesoura Metzenbaum Curva 14cm',                         'Para dissecção delicada.',                                       'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Tesoura Mayo Reta 17cm',                                'Para corte de fios e materiais mais resistentes.',               'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Pinça Hemostática Halsted Mosquito Reta 12cm',          'Para hemostasia em pequenos vasos.',                             'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Pinça Dissecção Dente de Rato 14cm',                    'Para apreensão firme de tecidos.',                               'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Pinça Allis 15cm',                                      'Para apreensão atraumática de tecidos.',                         'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Aparelho de Pressão Digital Automático',                'Esfigmomanômetro digital.',                                      'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Oxímetro de Pulso de Dedo',                             'Para medição não invasiva da saturação de oxigênio.',            'Material Hospitalar',    'Equipamento',                      'Unidade',                 0),
            ('Sabonete Antisséptico Clorexidina 2% 1L',               'Para higienização cirúrgica das mãos.',                          'Material de Limpeza',    'Produto Químico',                  'Frasco',                  1),
            ('Aparelho de Raio-X Portátil',                           'Para exames em leitos hospitalares.',                            'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Ultrassom Portátil com 3 Transdutores',                 'Para exames de imagem à beira do leito.',                        'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Maca de Transporte com Rodas e Grades',                 'Para movimentação de pacientes.',                                'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Termômetro Clínico Digital',                            'Para medição de temperatura corporal.',                          'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Balança Antropométrica Digital',                        'Para pesagem de pacientes.',                                     'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Removedor de Cera para Pisos 5L',                       'Para manutenção de pisos.',                                      'Material de Limpeza',    'Produto Químico',                  'Galão',                   1),
            ('Receituário Médico Padrão (Bloco)',                     'Bloco para prescrição simples (não controlada).',                'Material de Escritório', 'Registro/Documentação',            'Bloco 100 folhas',        1),
            ('Desinfetante Hospitalar (Quaternário de Amônio) 5L',    'Desinfecção de alto nível para superfícies.',                    'Material de Limpeza',    'Produto Químico',                  'Galão',                   1),
            ('Álcool Etílico 70% Líquido 1L',                         'Antisséptico e desinfetante de superfícies.',                    'Material de Limpeza',    'Produto Químico',                  'Frasco',                  1),
            ('Álcool em Gel 70% 500ml (com válvula pump)',            'Higienização das mãos.',                                         'Material de Limpeza',    'Produto Químico',                  'Frasco',                  1),
            ('Detergente Enzimático 1L',                              'Para pré-limpeza de instrumentais cirúrgicos.',                  'Material de Limpeza',    'Produto Químico',                  'Frasco',                  1),
            ('Cadeira de Rodas Dobrável',                             'Para transporte de pacientes.',                                  'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Pano de Microfibra Azul',                               'Para limpeza de superfícies.',                                   'Material de Limpeza',    'Acessório',                        'Unidade',                 1),
            ('Pano de Microfibra Vermelho',                           'Para limpeza de áreas de alto risco.',                           'Material de Limpeza',    'Acessório',                        'Unidade',                 1),
            ('Papel Sulfite A4 75g',                                  'Para impressão de laudos, receitas e prontuários.',              'Material de Escritório', 'Registro/Documentação',            'Caixa 5 resmas',          1),
            ('Escova Sanitária com Suporte',                          'Para limpeza de vasos sanitários.',                              'Material de Limpeza',    'Higiene Pessoal',                  'Unidade',                 1),
            ('Escova para Limpeza de Instrumentais (Cerdas Macias)',  'Para pré-limpeza manual.',                                       'Material de Limpeza',    'Acessório',                        'Unidade',                 1),
            ('Placa de Sinalização "Piso Molhado"',                   'Para segurança de circulação.',                                  'Material de Limpeza',    'Acessório',                        'Unidade',                 1),
            ('Lixeira com Pedal 50L (Branca - Infectante)',           'Para descarte de resíduos biológicos (RDC 306).',                'Material de Limpeza',    'Acessório',                        'Unidade',                 1),
            ('Papel Toalha Interfolhado Extra Luxo (Branco)',         'Para secagem das mãos.',                                         'Material de Limpeza',    'Higiene Pessoal',                  'Fardo 6 pacotes',         1),
            ('Dispenser de Papel Toalha (Parede)',                    'Para acondicionamento do papel toalha.',                         'Material de Limpeza',    'Higiene Pessoal',                  'Unidade',                 1),
            ('Sabonete Líquido Neutro 800ml (Refil)',                 'Para uso em banheiros e pias.',                                  'Material de Limpeza',    'Higiene Pessoal',                  'Refil',                   1),
            ('Dispenser de Sabonete Líquido (Parede)',                'Para acondicionamento do sabonete líquido.',                     'Material de Limpeza',    'Higiene Pessoal',                  'Unidade',                 1),
            ('Papel Higiênico Rolão 300m',                            'Para uso em banheiros de alto tráfego.',                         'Material de Limpeza',    'Higiene Pessoal',                  'Fardo 8 rolos',           1),
            ('Saco de Lixo Preto 100L',                               'Para lixo comum.',                                               'Material de Limpeza',    'Higiene Pessoal',                  'Rolo',                    1),
            ('Saco de Lixo Branco Leitoso 50L (Infectante)',          'Para resíduos biológicos.',                                      'Material de Limpeza',    'Higiene Pessoal',                  'Rolo',                    1),
            ('Cobertor Hospitalar de Lã',                             'Para conforto térmico.',                                         'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Caneta Esferográfica Bic (Azul)',                       'Para uso diário, escrita de prontuários.',                       'Material de Escritório', 'Uso Geral',                        'Caixa 50 unidades',       1),
            ('Caneta Esferográfica Bic (Vermelha)',                   'Para marcação e destaque em documentos.',                        'Material de Escritório', 'Uso Geral',                        'Caixa 50 unidades',       1),
            ('Caneta Esferográfica Bic (Preta)',                      'Para uso diário.',                                               'Material de Escritório', 'Uso Geral',                        'Caixa 50 unidades',       1),
            ('Lápis Preto Nº 2',                                      'Para rascunhos.',                                                'Material de Escritório', 'Uso Geral',                        'Caixa 12 unidades',       1),
            ('Borracha Branca Plástica',                              'Para correção de escrita a lápis.',                              'Material de Escritório', 'Uso Geral',                        'Unidade',                 1),
            ('Grampeador de Mesa (para 20 folhas)',                   'Para unir documentos.',                                          'Material de Escritório', 'Uso Geral',                        'Unidade',                 1),
            ('Grampos 26/6 Galvanizados',                             'Para grampeador de mesa.',                                       'Material de Escritório', 'Uso Geral',                        'Caixa 5000 unidades',     1),
            ('Clipes para Papel Nº 3/0',                              'Para prender pequenas quantidades de papel.',                    'Material de Escritório', 'Uso Geral',                        'Caixa 100 unidades',      1),
            ('Envelope Pardo Ofício',                                 'Para envio de documentos.',                                      'Material de Escritório', 'Uso Geral',                        'Pacote 100 unidades',     1),
            ('Toner para Impressora Laser',                           'Suprimento de impressão.',                                       'Material de Escritório', 'Suprimento',                       'Unidade',                 0),
            ('Cartucho de Tinta Preto',                               'Suprimento de impressão.',                                       'Material de Escritório', 'Suprimento',                       'Unidade',                 0),
            ('Paracetamol 500mg',                                     'Analgésico e Antitérmico.',                                      'Medicamento',            'Analgésico/Antitérmico',           'Comprimido',              1),
            ('Ibuprofeno 400mg',                                      'Anti-inflamatório, Analgésico e Antitérmico.',                   'Medicamento',            'Anti-inflamatório Não Esteroidal', 'Cápsula',                 1),
            ('Amoxicilina 250mg/5mL',                                 'Antibiótico penicilínico.',                                            'Medicamento',            'Antibiótico',                      'Suspensão Oral',          1),
            ('Omeprazol 40mg',                                        'Inibidor de bomba de prótons.',                                  'Medicamento',            'Gastrointestinal',                 'Cápsula',                 1),
            ('Sinvastatina 20mg',                                     'Hipolipemiante, controle de colesterol.',                        'Medicamento',            'Cardiovascular',                   'Comprimido',              1),
            ('Losartana Potássica 25mg',                              'Anti-hipertensivo.',                                             'Medicamento',            'Cardiovascular',                   'Comprimido',              1),
            ('Cloridrato de Fluoxetina 10mg',                         'Antidepressivo, dose inicial.',                                  'Medicamento',            'Psicotrópico',                     'Cápsula',                 1),
            ('Diazepam 10mg/2mL',                                     'Uso emergencial para convulsões e sedação.',                           'Medicamento',            'Ansiolítico',                      'Ampola',                  1),
            ('Fita Demarcadora para Piso (Amarela)',                  'Para sinalização de segurança.',                                 'Material de Limpeza',    'Acessório',                        'Rolo',                    1),
            ('Hidrocortisona 500mg',                                  'Corticoide EV.',                                                       'Medicamento',            'Corticosteroide',                  'Ampola',                  1),
            ('Travesseiro Antialérgico Hospitalar',                   'Para conforto de pacientes.',                                    'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Gorro Cirúrgico de Tecido',                             'Para reuso, centro cirúrgico.',                                  'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Óculos de Proteção Transparente',                       'Para EPIs de proteção ocular.',                                  'Material Hospitalar',    'Descartável (EPIs)',               'Unidade',                 1),
            ('Cimetidina 300mg/2mL',                                  'Antagonista H2.',                                                      'Medicamento',            'Gastrointestinal',                 'Ampola',                  1),
            ('Azitromicina 250mg',                                    'Antibiótico Macrolídeo.',                                        'Medicamento',            'Antibiótico',                      'Comprimido',              1),
            ('Cloridrato de Lidocaína 2% com Vasoconstrictor',        'Anestésico local.',                                                    'Medicamento',            'Anestésico',                       'Ampola',                  1),
            ('Soro Fisiológico 100mL',                                'Solução isotônica.',                                                   'Medicamento',            'Hidratação',                       'Frasco',                  1),
            ('Soro Glicosado 5%',                                     'Solução para hidratação.',                                       'Medicamento',            'Solução Parenteral',               'Bolsa 100ml',             1),
            ('Cumarina + Troxirrutina',                               'Flebotônico para varizes.',                                            'Medicamento',            'Vasoprotetor',                     'Comprimido',              1),
            ('Captopril 50mg',                                        'Anti-hipertensivo, Inibidor da ECA.',                            'Medicamento',            'Cardiovascular',                   'Comprimido',              1),
            ('Furosemida 10mg/mL',                                    'Diurético de alça.',                                                   'Medicamento',            'Diurético',                        'Ampola 2mL',              1),
            ('Sertralina 100mg',                                      'Antidepressivo ISRS.',                                           'Medicamento',            'Psicotrópico',                     'Comprimido',              1),
            ('Lorazepam 1mg',                                         'Ansiolítico, Benzodiazepínico.',                                 'Medicamento',            'Psicotrópico',                     'Comprimido',              1),
            ('Propranolol 80mg',                                      'Betabloqueador.',                                                'Medicamento',            'Cardiovascular',                   'Comprimido',              1),
            ('Pilha Alcalina AA',                                     'Para equipamentos (mouse sem fio, termômetro).',                 'Material de Escritório', 'Suprimento',                       'Cartela 4 unidades',      0),
            ('Pilha Alcalina AAA',                                    'Para equipamentos (controle remoto, lanterna).',                 'Material de Escritório', 'Suprimento',                       'Cartela 4 unidades',      0),
            ('Dipirona Sódica 1g/2ml',                                'Analgésico e Antitérmico intravenoso/intramuscular.',            'Medicamento',            'Analgésico/Antitérmico',           'Ampola',                  1),
            ('Isossorbida 10mg',                                      'Vasodilatador para angina.',                                           'Medicamento',            'Cardiovascular',                   'Comprimido',              1),
            ('Complexo B Injetável',                                  'Reposição de vitaminas B.',                                            'Medicamento',            'Vitamina',                         'Ampola',                  1),
            ('Clonazepam Gotas',                                      'Anticonvulsivante e ansiolítico.',                               'Medicamento',            'Psicotrópico',                     'Frasco Gotas',            1),
            ('Metronidazol 40mg/mL',                                  'Antiprotozoário.',                                                     'Medicamento',            'Antibiótico',                      'Suspensão Oral',          1),
            ('Flumazenil Solução Injetável',                          'Antagonista Benzodiazepínico.',                                  'Medicamento',            'Emergência',                       'Ampola',                  1),
            ('Albendazol 400mg',                                      'Antiparasitário de amplo espectro.',                                   'Medicamento',            'Antiparasitário',                  'Comprimido',              1),
            ('Varfarina Sódica 2.5mg',                                'Anticoagulante oral.',                                           'Medicamento',            'Hematológico',                     'Comprimido',              1),
            ('Esfigmomanômetro Aneróide',                             'Medição manual de pressão arterial.',                            'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Água Sanitária Concentrada (2,5% Hipoclorito) 1L',      'Desinfecção de uso geral e sanitários.',                         'Material de Limpeza',    'Produto Químico',                  'Frasco',                  1),
            ('Detergente Neutro para Louças 5L',                      'Limpeza de utensílios de cozinha.',                              'Material de Limpeza',    'Produto Químico',                  'Galão',                   1),
            ('Luva de Borracha para Limpeza (Tamanho M)',             'Para proteção das mãos do pessoal da limpeza.',                  'Material de Limpeza',    'Descartável (EPIs)',               'Par',                     1),
            ('Saco de Lixo Cinza 40L (Comum)',                        'Para lixeiras menores de consultórios.',                         'Material de Limpeza',    'Higiene Pessoal',                  'Rolo',                    1),
            ('Fio de Sutura Poliglactina 910 (Vicryl) 3-0',           'Fio absorvível, para tecidos internos.',                         'Material Hospitalar',    'Descartável (Consumo)',            'Envelope',                1),
            ('Fio de Sutura Nylon (Monofilamentar) 4-0',              'Fio inabsorvível, para pele.',                                   'Material Hospitalar',    'Descartável (Consumo)',            'Envelope',                1),
            ('Cateter Central de Inserção Periférica (PICC) Nº 4 Fr', 'Acesso venoso central de longa permanência.',                    'Material Hospitalar',    'Descartável (Consumo)',            'Kit',                     1),
            ('Kit de Curativo Estéril (Bandeja, Pinças, Gaze)',       'Para procedimentos de curativo.',                                'Material Hospitalar',    'Descartável (Consumo)',            'Kit',                     1),
            ('Clorexidina Alcoólica 2% em Swabstick',                 'Para antissepsia de cateteres.',                                 'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Agulha para Punção Lombar Nº 22',                       'Para coleta de líquor.',                                         'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Kit de Aspiração Endotraqueal',                         'Para aspiração de secreções.',                                   'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Nebulizador Portátil',                                  'Para aerossolterapia à beira do leito.',                         'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Flanela Laranja',                                       'Para limpeza a seco de móveis.',                                 'Material de Limpeza',    'Acessório',                        'Unidade',                 1),
            ('Sabonete em Barra Neutro',                              'Para higiene de pacientes.',                                     'Material de Limpeza',    'Higiene Pessoal',                  'Unidade',                 1),
            ('Esfigmomanômetro Pediátrico',                           'Para medição de pressão arterial em crianças.',                  'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Oxímetro de Pulso Pediátrico',                          'Para medição de SatO2 em crianças.',                             'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Monitor de Glicemia (Glicosímetro)',                    'Para medição de glicose no sangue.',                             'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Oxigênio Medicinal Comprimido',                         'Gás terapêutico.',                                               'Material Hospitalar',    'Equipamento',                      'Cilindro',                1),
            ('Ar Comprimido Medicinal',                               'Gás para equipamentos.',                                         'Material Hospitalar',    'Equipamento',                      'Cilindro',                1),
            ('Manta Térmica Descartável',                             'Para manutenção da temperatura corporal.',                       'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Máscara de Oxigênio Simples (Adulto)',                  'Para oxigenoterapia.',                                           'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Nebulizador tipo Copinho',                              'Para aerossolterapia em rede de ar.',                            'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 0),
            ('Tubo para Coleta de Sangue a Vácuo (Tampa Vermelha)',   'Para sorologia e bioquímica.',                                   'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 100 unidades',      1),
            ('Tubo para Coleta de Sangue a Vácuo (Tampa Roxa)',       'Para hemograma.',                                                'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 100 unidades',      1),
            ('Avental para Exame (TNT Azul)',                         'Para pacientes em exames.',                                      'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Sapatilha Cirúrgica Estéril (Propé)',                   'Para centro cirúrgico.',                                         'Material Hospitalar',    'Descartável (EPIs)',               'Pacote 10 pares',         1),
            ('Luva de Látex para Coleta de Amostra',                  'Luva simples para coleta laboratorial.',                         'Material Hospitalar',    'Descartável (EPIs)',               'Caixa 100 unidades',      1),
            ('Laringoscópio Completo com Lâminas',                    'Para intubação orotraqueal.',                                    'Material Hospitalar',    'Instrumental (Reutilizável)',      'Conjunto',                1),
            ('Fio Guia (Stylet) para Intubação',                      'Para moldar o tubo endotraqueal.',                               'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Fita Crepe Hospitalar Larga',                           'Para fixação de tubos e sondas.',                                'Material Hospitalar',    'Descartável (Consumo)',            'Rolo',                    1),
            ('Pano de Chão Grosso (Alvejado)',                        'Para limpeza de áreas comuns.',                                  'Material de Limpeza',    'Acessório',                        'Unidade',                 1),
            ('Vassoura de Piaçava',                                   'Para varredura de pisos.',                                       'Material de Limpeza',    'Acessório',                        'Unidade',                 1),
            ('Pá de Lixo com Cabo',                                   'Para coleta de detritos.',                                       'Material de Limpeza',    'Acessório',                        'Unidade',                 1),
            ('Álcool em Gel 70% 5L (Refil Galão)',                    'Para reabastecimento de dispensers.',                            'Material de Limpeza',    'Produto Químico',                  'Galão',                   1),
            ('Sabonete Antisséptico Clorexidina 4%',                  'Para esfrega de mãos e preparo de pele.',                        'Material de Limpeza',    'Produto Químico',                  'Frasco 1L',               1),
            ('Formulário de Relatório de Enfermagem (Bloco)',         'Para passagem de plantão.',                                      'Material de Escritório', 'Registro/Documentação',            'Bloco 100 folhas',        1),
            ('Porta Canetas de Mesa (Acrílico)',                      'Para organização de materiais de escrita.',                      'Material de Escritório', 'Uso Geral',                        'Unidade',                 1),
            ('Tesoura de Escritório Grande',                          'Para corte de papel e embalagens.',                              'Material de Escritório', 'Uso Geral',                        'Unidade',                 1),
            ('Fita Dupla Face',                                       'Para fixação de avisos.',                                        'Material de Escritório', 'Uso Geral',                        'Rolo',                    1),
            ('Detergente para Lavadora de Roupas Hospitalar',         'Para lavanderia.',                                               'Material de Limpeza',    'Produto Químico',                  'Balde 20Kg',              1),
            ('Fio Guia Hidrofílico',                                  'Para procedimentos de cateterismo.',                             'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Bisturi Elétrico (Eletrocautério)',                     'Para hemostasia e corte.',                                       'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Caneta para Bisturi Elétrico',                          'Acessório do eletrocautério.',                                   'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Seringa para Irrigação 60ml',                           'Para lavagem de feridas ou cateteres.',                          'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Tesoura de Ponta Romba (Enfermagem)',                   'Para corte de gaze e fita, segura para o paciente.',             'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Solução Degermante PVPI 10%',                           'Antisséptico para assepsia.',                                    'Medicamento',            'Dermatológico',                    'Frasco 1L',               1),
            ('Bolsa de Colostomia com Base Adesiva',                  'Para pacientes ostomizados.',                                    'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 10 unidades',       1),
            ('Pasta Protetora para Ostomia',                          'Para proteção da pele periestoma.',                              'Material Hospitalar',    'Descartável (Consumo)',            'Bisnaga',                 1),
            ('Sonda Uretral Nº 10 (Fina)',                            'Para uso pediátrico.',                                           'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Sonda Gástrica de Levine Nº 16',                        'Para alimentação ou descompressão.',                             'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Saco para Lixo Hospitalar Vermelho 100L',               'Para descarte de resíduos perigosos específicos.',               'Material de Limpeza',    'Higiene Pessoal',                  'Rolo',                    1),
            ('Colar Cervical de Resgate (Tamanho M)',                 'Para imobilização de coluna cervical.',                          'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Prancha de Resgate (Longa)',                            'Para transporte e imobilização de vítima de trauma.',            'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Bolsa de Transporte para Medicamentos (Térmica)',       'Para transporte de termolábeis.',                                'Material Hospitalar',    'Equipamento',                      'Unidade',                 0),
            ('Lençol de Papel Picotado 50cm x 50m',                   'Para maca de consultório (largura menor).',                      'Material Hospitalar',    'Descartável (Consumo)',            'Rolo',                    1),
            ('Luva de Procedimento Vinílica (Sem Látex) M',           'Para pacientes/profissionais com alergia ao látex.',             'Material Hospitalar',    'Descartável (EPIs)',               'Caixa 100 unidades',      1),
            ('Toalha de Banho Branca',                                'Para higiene de pacientes.',                                     'Material de Limpeza',    'Higiene Pessoal',                  'Unidade',                 1),
            ('Jaleco de TNT Descartável',                             'Para visitantes em áreas restritas.',                            'Material Hospitalar',    'Descartável (EPIs)',               'Unidade',                 1),
            ('Porta Prontuário de Acrílico (Leito)',                  'Para identificação do paciente à cabeceira.',                    'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Bacia Metálica para Lavagem de Instrumentais',          'Para descarte de material biológico (sujo).',                    'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Sabão em Pó Industrial (Lavanderia)',                   'Para lavagem de enxoval.',                                       'Material de Limpeza',    'Produto Químico',                  'Saco 25Kg',               1),
            ('Amaciante Industrial (Lavanderia)',                     'Para maciez do enxoval.',                                        'Material de Limpeza',    'Produto Químico',                  'Galão 5L',                1),
            ('Pano de Prato Xadrez',                                  'Para limpeza na área de nutrição.',                              'Material de Limpeza',    'Acessório',                        'Unidade',                 1),
            ('Pasta Arquivo Morto (Papelão)',                         'Para arquivamento de prontuários antigos.',                      'Material de Escritório', 'Registro/Documentação',            'Caixa 10 unidades',       1),
            ('Dióxido de Carbono (CO2) Medicinal',                    'Para insuflação em laparoscopia e endoscopia.',                  'Material Hospitalar',    'Equipamento',                      'Cilindro',                1),
            ('Stent Coronariano Farmacológico',                       'Para angioplastia coronariana.',                                 'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Cateter Balão para Angioplastia',                       'Para dilatação de vasos sanguíneos.',                            'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Cateter Nasal para Oxigênio Pediátrico',                'Para baixo fluxo de O2 em crianças.',                            'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Bisturi Harmônico (Ultrassônico)',                      'Para dissecção e hemostasia em cirurgia avançada.',              'Material Hospitalar',    'Equipamento',                      'Unidade',                 1),
            ('Detergente Desincrustante Ácido 5L',                    'Para limpeza pesada de pisos e banheiros.',                      'Material de Limpeza',    'Produto Químico',                  'Galão',                   1),
            ('Limpa Vidros Concentrado 1L',                           'Para limpeza de janelas e superfícies de vidro.',                'Material de Limpeza',    'Produto Químico',                  'Frasco',                  1),
            ('Lâmina de Microscópio com Borda Fosca',                 'Para preparo de lâminas em laboratório.',                        'Material Hospitalar',    'Descartável (Consumo)',            'Caixa 72 unidades',       1),
            ('Kit de Teste Rápido para Dengue (NS1/IgM/IgG)',         'Para diagnóstico rápido de Dengue.',                             'Material Hospitalar',    'Descartável (Consumo)',            'Kit 25 testes',           1),
            ('Saco de Lixo Transparente 40L (Plástico)',              'Para descarte de materiais recicláveis plásticos.',              'Material de Limpeza',    'Higiene Pessoal',                  'Rolo',                    1),
            ('Avental Cirúrgico Reutilizável de Algodão',             'Para uso em centro cirúrgico (esterilizável).',                  'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Pinça Anatômica sem Dente 14cm',                        'Para manipulação delicada de tecidos.',                          'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Pinça Kocher 14cm',                                     'Para apreensão firme de tecidos.',                               'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Afastador Farabeuf (Par)',                              'Para cirurgias de pequeno e médio porte.',                       'Material Hospitalar',    'Instrumental (Reutilizável)',      'Unidade',                 1),
            ('Sonda Uretral (Nelaton) Nº 12',                         'Para esvaziamento vesical (calibre médio).',                     'Material Hospitalar',    'Descartável (Consumo)',            'Unidade',                 1),
            ('Kit de Teste Rápido para COVID-19 (Antígeno)',          'Para rastreamento de COVID-19.',                                 'Material Hospitalar',    'Descartável (Consumo)',            'Kit 25 testes',           1)
      ) AS T (Name, Description, MainCategory, SubCategory, PresentationForm, IsActive)
)

INSERT INTO [dbo].[Products]
            ([Name]
            ,[Description]
            ,[MainCategory]
            ,[SubCategory]
            ,[PresentationForm]
            ,[CreatedOn]
            ,[UpdatedOn]
            ,[IsActive])
SELECT
      Name,
      Description,
      MainCategory,
      SubCategory,
      PresentationForm,
      CreatedOn,
      UpdatedOn,
      IsActive
FROM  RandomDates;
GO

-- ==================================================================================================================================
USE [ararashealthhub]
GO

DECLARE @MaxMonthsAgo INT = 10
DECLARE @NOW DATETIME = GETDATE()
DECLARE @MinDate DATETIME = DATEADD(MONTH, -@MaxMonthsAgo, @NOW)
DECLARE @RangeSeconds INT = DATEDIFF(SECOND, @MinDate, @NOW)

;WITH RandomDates (
      FacilityId, Scope, IsActive, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount, CreatedOn, UpdatedOn
) AS (
      SELECT
            T.FacilityId,
            T.Scope,
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
            DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % @RangeSeconds, @MinDate) AS CreatedOn,

            -- 'UpdatedOn'
            CASE
            WHEN T.IsActive = 0
            THEN DATEADD(MINUTE, (ABS(CHECKSUM(NEWID())) % (60 * 24 * 30)) + 1, DATEADD(SECOND, ABS(CHECKSUM(NEWID())) % @RangeSeconds, @MinDate))
            ELSE NULL
            END AS UpdatedOn
      FROM (
            VALUES
               -- ('FacilityId', 'Scope', 'IsActive', 'UserName',        'NormalizedUserName',  'Email', 'NormalizedEmail', 'EmailConfirmed', 'PasswordHash',                                                                        'SecurityStamp', 'ConcurrencyStamp', 'PhoneNumber', 'PhoneNumberConfirmed', 'TwoFactorEnabled', 'LockoutEnd', 'LockoutEnabled', 'AccessFailedCount')
               -- (1,             1,       1,         'sms_master',      'SMS_MASTER',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEEqeBGF+Rvx70SKaJEf8a7fAWWMLi+icLvnqu5uiLw3uR23FB+X6dxnr0jBGFs2ZnA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (1,             1,       1,         'sms_admin',       'SMS_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELrbTaOsjU/nSbwwor8wr2irt9ZJhh26FRn0Fpwse8Yqwc/XQ7B3KR9AAYNPh65/7w==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (1,             1,       1,         'sms_user',        'SMS_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDR5p/FDbjAZWg8GmxSkqYBjbxoUS3Pnctb69y51r/JkRQYObcr+A67yTVm6TS9fYA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (2,             1,       1,         'cdm_master',      'CDM_MASTER',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDgZorTwRiBt+jaGuACqXQEaqsge9wX/yUrEAINreRN8HxEAmmgV5j8xtk8hX9P8vg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (2,             1,       1,         'cdm_admin',       'CDM_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEC3tHi0zyN8zMRirOzKEzXsqx/QRsuPNEazbbdZhvX6Pj+vUpH8MXcxUILtIBw0x2A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (2,             1,       1,         'cdm_user',        'CDM_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEG3wsZnFjqrLpEEr1riCXtf66MaQiJLlMwrCQw1rTseC4LmTqi6KxGJdnQacQoDs+A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (2,             1,       1,         'cdm_user2',       'CDM_USER2',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBjwkJTYyjHFP36i76CYr2wgEPioZOiOapk8vnBx2xFh4ez+paR4+7ZTEQo4I2EwMw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (3,             2,       1,         'ubs_ev_admin',    'UBS_EV_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEN35ulBBEEMdYsGe+Dr7rRhlVJbgreodBOY+cp3TbhMIO6+Wh9QeoW/4JAVZBC+zPg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (3,             2,       1,         'ubs_ev_user',     'UBS_EV_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELbjypAfD7G2SU6v0ZVh9LeedEMh4PTKuFayYudQL3O8qCaPpHuVib7/RBqjqjf8Fw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (4,             2,       1,         'upa_esf_admin',   'UPA_ESF_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEPH+BChfALUyi+RjRLk2vAb79jj6WM2Qtt3I4uoQwZiI02sRqWaBMq8KhFbWTt2txA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (4,             2,       1,         'upa_esf_user',    'UPA_ESF_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBzVzrKy6v5xX+GjxJG4j3niaI2MTSzkGybeJVeSy95y1vqsnffwrLhNzSFr5BbDLw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (5,             2,       1,         'fac_admin',       'FAC_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEGxoWPSzzmuqfXMBV2tJLoT4ZWmAbwfGuBspfSRZEaAUKi7hXKN4sa+LBrEjx4bk0A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (5,             2,       1,         'fac_user',        'FAC_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJp1Na9cUFhHrwz7GN+HugdN6761k5rYkS2Of4FgxPF0MywZtueJ7vNvDTg/L0I3ww==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (6,             2,       1,         'samu_admin',      'SAMU_ADMIN',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEGJdbUKsGVD/G7yYWPYb82YDdZ4/ZBxkODzQZp7WcPYtNV/SCHC71uNUxVsoOOp+pA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (6,             2,       1,         'samu_user',       'SAMU_USER',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAaMeanAynQIdnL/lhr1dcSbthu1mah7NhN4k+Ap1pMv5ug4Y1GurFUC7yaAfrmvxA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (7,             2,       1,         'psf_eu_admin',    'PSF_EU_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEMGW9L9w2cJs7rptSIqeSrs7BXLCuUqS6Dht2WDOUcwLMk8rLYHcaFJtgBCstZ/vIQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (7,             2,       1,         'psf_eu_user',     'PSF_EU_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJlhIrDYynGAjjhdBGXTQFcek1fdNV0UbHjI6N1MYEf5XTjNp+oDcDohNwPZx4QFMw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (8,             2,       1,         'psf_ndl_admin',   'PSF_NDL_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEEfenVMhf32yrobWPKimmegSZUvB7/LelT8oyOIQni/irgb053F/Qx7t6RWaX1lyFg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (8,             2,       1,         'psf_ndl_user',    'PSF_NDL_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEKhmianNIvwaus1nubY3RL9jBrlgJQPYW72b+9mkhpN3SgbZrg8ME0AMCV22xfRCjw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (9,             2,       1,         'psf_jm_admin',    'PSF_JM_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEA6Te8vIUWZnb2Nmx4197fIErzWuMKtxgMe3Mxg3aRHCY3OZDB2oCl+BXbU4UlhwCw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (9,             2,       1,         'psf_jm_user',     'PSF_JM_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOrV65A44ugH+d3+fLdNSZkwX0Od4p9J4Fi6Zf+eXEUAl/cc6M9WbTwp11H80G2fQQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (10,            2,       1,         'ubs_jf_admin',    'UBS_JF_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEFgYqO74PFN+hg3jCnqYThjMqe3q/t1d8vPDj6dHKE6jZ1rlkxS9bLNxbU68/KSzOA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (10,            2,       1,         'ubs_jf_user',     'UBS_JF_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENc9ihwYOGcD4geaiJ3bKjY4zTiUrqaB5hcGrev/A6RKGtzMqHOg8IJgfyd3ZLey8g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (11,            2,       1,         'caem_ns_admin',   'CAEM_NS_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEP42qRqIgquEENAXkhy83LXOxJwd5kIGg0oorANzyAb347P7QJwMh1xcTSFT1Pq7Tg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (11,            2,       1,         'caem_ns_user',    'CAEM_NS_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDzFiUC5fF3KrLFPFWQv7LQ0SCSrokUOKjHLFdLpc91E9FNXIu1JL75FRwzns4NvPA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (12,            2,       1,         'asm_ab_admin',    'ASM_AB_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEHmOJB0MuhFDB2Vo4StmKBn+H5ojOB+6w5uG1nCQdIODwkfmqtGufhK5PVFkLPCMyw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (12,            2,       1,         'asm_ab_user',     'ASM_AB_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAD/7uqisMnoBWf7noJT6wto/yd/S9sW7fFBvkdcI9yFdzTi/Qtrw1Rh7K2o/d8d6Q==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (13,            2,       1,         'caps_ad_admin',   'CAPS_AD_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELf9f+aBTfDYkPem7vkscjqEYgN7zUEHcYHWDRHrYPMdgAhzPI90CSFh3O56oL8eeg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (13,            2,       1,         'caps_ad_user',    'CAPS_AD_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEB6dXFwLmGfOXpXkBUXNO1mJVe7iyG29kJJXiMz9kgVYF+8PjdapFQ5/fupEMuCfSA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (14,            2,       1,         'ccz_admin',       'CCZ_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECWPaVYScJtNwx+WBYJJBBXdAwpFtGhZcX9CVBhzYhPot1HBDW+QqMLYQJuGE75kbA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (14,            2,       1,         'ccz_user',        'CCZ_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAf0HS/1Kaakil7wN1pI3Ab9Cp4qAMPyYH1LvETWdxqvoDLmcgZWPGxsMWm1LLMuzw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (15,            2,       0,         'apa_sfo_admin',   'APA_SFO_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEGqalT3NMD/gcz6fwwS4az3kowlAhzMItmGPx7tUy/DNz8HYrmgllmHCYmy6IFI4NA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (15,            2,       0,         'apa_sfo_user',    'APA_SFO_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENIGuS/kKaTVHh9i0b3AMhhcNNVCDgNR291eu/dAtn4Rjy9B1olJxazW4Y6ZARuxuQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (16,            2,       1,         'vs_admin',        'VS_ADMIN',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEIdW+Sito6knIRmzlirKRSpAdtmLdBzi9i2qyITeOytMlf3LsgxXXAQe1sCQWQ9pBg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (16,            2,       1,         'vs_user',         'VS_USER',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEIOx/Mt1etL7C2KGBvClIymx2TQ3jE6j44Kzmr2c3t8RqmJFLevY2q9mdnkoFLnUQQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (17,            2,       0,         'umo_admin',       'UMO_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEMz17gHOKJOZcll5gvbNde+I19vyRFuveNOIhf/Pe/dZtQcexjn9D0mwNSYqX+VgCg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (17,            2,       0,         'umo_user',        'UMO_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECxH7N5T+uef3Sy1UD04gon+576U6aTgIUIwte3Jg6HghWip+JcrTwNBYhvspUstgQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (18,            2,       1,         'uve_admin',       'UVE_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAED7pWOjnRGf09WbltfZvH37rtEj8F1q9m7tPD1Cc2gQonBgUN6L7wBUexLwtR8pm3Q==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (18,            2,       1,         'uve_user',        'UVE_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEK1Sp7mUn5wLWS0iJlAhlw5vrccaCH0SkfHKCskpltTxIrabnY0R/KyVF0rGTr5PYw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (19,            2,       1,         'ubs_osd_admin',   'UBS_OSD_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDMRy7IL8ZrYW4K5ppID9EXcYWF9N0OOL3QGn23PqXRPxEBAT5BPBKE94V8Azj3aSg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (19,            2,       1,         'ubs_osd_user',    'UBS_OSD_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECaKEkZdRsQexYC/YpSbqaEDonAZt3H9fZr6agiDO320d7mPPjdwN6ST2/U1OslB+A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (20,            2,       1,         'ubs_hrj_admin',   'UBS_HRJ_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEClI2cFIDFDYbKW51LNZ4s2W62vO+he6cglzxD12tKVsGhTxit4lPaINk3QfiNJvNA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (20,            2,       1,         'ubs_hrj_user',    'UBS_HRJ_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEN9Eea+2DZHj8mqLqJeh8ziy+rA538oi8EjVFnlWp8S+Nq+eMMAwcUnXVlC3uUk5tw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (21,            2,       1,         'ubs_em_admin',    'UBS_EM_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOfdXxkBREwxS4VMcnhxpeMyQ8uVXSedLnH9cP6ttmGJ1Qa2sRY2YETYbcUsbWy1xA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (21,            2,       1,         'ubs_em_user',     'UBS_EM_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEPNk6binzSWicXhphUs4PTTbrEd5M+Z2RPNTPkMwplUZ9nru4soC4TVBMNhxMLxUGQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (22,            2,       0,         'ubs_asp_admin',   'UBS_ASP_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEODC9pjkbtr12UzU80e6S6tcDu50H2rN8mJHzZ8hsRqJ7ocqrA2CMN/ifxQvlx8HZg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (22,            2,       0,         'ubs_asp_user',    'UBS_ASP_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEABNrdHXiBF67z+i+5ScB3d+77dafaLLwJVEVRdOe0yFklmhH4bQvdXLQ2eVgcjGDQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (23,            2,       1,         'ubs_acf_admin',   'UBS_ACF_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEIHpwKNvwRCf7r9WRhGcI393VP8LdCaT3C1u9XLRr0L0v+nUK1xlh/6bIMFczRMc4Q==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (23,            2,       1,         'ubs_acf_user',    'UBS_ACF_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOUdi5vKKcFNHtHpv+xuxccn6XbIlM0f4bXPXzc6M7dK6g4hkPN7GYcmxuKmaYuz5A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (24,            2,       1,         'ubs_af_admin',    'UBS_AF_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBSX80VMHrcffGF/lD/FIzapIygQA8VlscFsMhrMbwoW8vFTjtaG7oiQiD25Wd10aQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (24,            2,       1,         'ubs_af_user',     'UBS_AF_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEENCLOPCWQGozKQXxWwV/4jWm2w0TSoVeyedsHSRIvTeO8RHSqcmEIJwWSmN7CIUCQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (25,            2,       1,         'hps_admin',       'HPS_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEImFHsOVLe9HXjlKD8lpFNVUMQ84OAmTin8rriSIJUfqJK6zbUsCiXvpiz7GE239Gg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (25,            2,       1,         'hps_user',        'HPS_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOR0CDzLdqB1oipoVmmA/uGKaZx+cPwjyMhd0a84uH/RmpUjoTptdcvaVNXj4oZdLQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (26,            2,       0,         'ps_afo_admin',    'PS_AFO_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEMWTcZxQXqOF498KRCKWrptmx5G6wTxtTp8fJE781jcm1IaA3dL0bxF2fNUiCDY+nA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (26,            2,       0,         'ps_afo_user',     'PS_AFO_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENz3CzLPv0LrC/3ra2Yqt6TMcJFQOswSMTivRlz58kkZnjEqqU+UqZ2fguGXGRnvHw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (27,            2,       1,         'easg_admin',      'EASG_ADMIN',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEE88tNQrj3L3StrsdsYNkUtmnYjUX2e1o9lymnQcTz+Wx6cvbMAhfSsK/fbKLqaovA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (27,            2,       1,         'easg_user',       'EASG_USER',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECvkeJyFJEtbPOCHVRGocxsAYCzRX5PPI0cbQqcKNGijzdlHvKhFwF/VjADgBSUjog==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (28,            2,       0,         'pa_eacc_admin',   'PA_EACC_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEMLV1vh5IIne6aCnMPp2IEVI/snNvaZMzBVb6FFtsXQ7EwJKGUDwZUzl9P1SqOlwzA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (28,            2,       0,         'pa_eacc_user',    'PA_EACC_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJppkLl/GRLS5dl/LXXkucaQu06igZ0Z4ld8reYzGbsh5C37YFQIJOen5QIzjDC8qQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (29,            2,       1,         'mdcs_admin',      'MDCS_ADMIN',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDwJmsC1VqzrVIf1um8n4Vy6SxUo7b1tR8A1kc6AUEXzGE84N6kWWw0KYJSgn8sjig==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (29,            2,       1,         'mdcs_user',       'MDCS_USER',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEINSTaDrCnHzIQP9N58xdfWYgjQpLTF8c+Iz/JaCBEuvTmFsbV4pqFwkFsMX5bvVew==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (30,            2,       1,         'lv_admin',        'LV_ADMIN',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEKk9EilNuzNDgzGVmsp94PZPvoWyQ+aFCQHQicO+UM2hLJ10nS1x52QpYe4rrVuY5g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (30,            2,       1,         'lv_user',         'LV_USER',              NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEN2gpT/sY3zzBw5GQQFSqVfg52agPIzZuXZ5u9hPUskCPzW45fTB8z7WW/5YnhasaA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (31,            2,       1,         'esf_vph_admin',   'ESF_VPH_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECz+Pl22l4/rre1So56FAWpbfEjCgEYfGnBfn/mRCsRuBPnOp3hIsqOH/hDT5LCA+A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (31,            2,       1,         'esf_vph_user',    'ESF_VPH_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAErhhQdnKP5Xt7vmYDfax4aDWcOnCiUIHYuu8Bx/PGbGgR8/2y3TqnT3htovR7I4A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (32,            2,       0,         'hcc19_admin',     'HCC19_ADMIN',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEFDpcberLid53T0HfYhuHWbFveHVYji9btXDVDb2Hn1zek9w95leEbPtOJc0CY7d7g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (32,            2,       0,         'hcc19_user',      'HCC19_USER',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOUxAAQe8qz7IpTKDsEMzjmFmNHDa03/fIsr8ofPGX5XCXaVK5uhvHI7sfxyUALHFg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (33,            2,       1,         'hslm_admin',      'HSLM_ADMIN',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENYZK47bcJHa3F3ZrmFVA5qeT3aFignT5K5Q+Gjrw6CSRkN2mD5hO8pisg1F1qNnxA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (33,            2,       1,         'hslm_user',       'HSLM_USER',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEE1y3EoyayrWkljaTpONEAQ3DNcpoQFU1AOQsd2pzlfszIBUztYsdft1vLza5mTmaA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (34,            2,       1,         'hiscma_admin',    'HISCMA_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELR59iriPH2Y9u6ieExWGekd4/meyB4UFteACXssClmTm2PFSxkyNRuh/Quw/8sIqg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (34,            2,       1,         'hiscma_user',     'HISCMA_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECTUhYOj17/YWoBf64o5usn1Ns4/SbDzyzJO7IPXJz5RAM7ctLBrRXftoDvqlhs8og==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (35,            2,       1,         'esf_oz_admin',    'ESF_OZ_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJ9ZP5f07g/59PIoKfwfNks8AQiI9wCgsxApz8z959wmbapsjDUfZwWa+JGf2lXobw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (35,            2,       1,         'esf_oz_user',     'ESF_OZ_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEM2EfzhYjilXQHGJqvyp4LwKH/1CTwVyuj/C/X7OmVUxHkOy74FXoH5cczReqZyouA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (36,            2,       0,         'esf_sjm_admin',   'ESF_SJM_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEB4QlTnoETLczEyC3f6rJurnUGLMMe2zyzd65cdaEj4K6wp3whfPjjV+Z9K+npVyZQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (36,            2,       0,         'esf_sjm_user',    'ESF_SJM_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEFlAM/TvYVPL1wL9AzSjSZWQLWByuHwV25OEfCuxc3aRGOp17KE3UHWrGB5YXqeHtg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (37,            2,       1,         'esf_fnc_admin',   'ESF_FNC_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELE0Cp3ppu4TWByST0/MwjUiXsfkWwgWgh3dBa+23h5pcAwpL10JMErWZytjATIIAA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (37,            2,       1,         'esf_fnc_user',    'ESF_FNC_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELixgyLmUk8pcWeB35zJ6URdH40s4dUnE+z8pOBFkNT4a8Krkls8IzZbKnmD1UjhMQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (38,            2,       1,         'esf_jo_admin',    'ESF_JO_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAED/RzSL8j2BLAulbZohRGsAF42PS5Co79ptsBoQEicZSod8r79WOJ4vOGYQeicE1kw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (38,            2,       1,         'esf_jo_user',     'ESF_JO_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAAljIl8WD1wCJrPU9ggK9SJMir3rIs7ziWm+ib0nGeTTLHctDUxxsQhsJP8tTdlAg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (39,            2,       1,         'esf_lbm_admin',   'ESF_LBM_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAupG/M5XDxWL1ZQz9iTVXo2d1rdpYFc7qGSGs2Hj4oToURMWiTn24hZGCQq9dyemw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (39,            2,       1,         'esf_lbm_user',    'ESF_LBM_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBYgz9F2D5oSeziduOA7VxLPOPM36ODwTXV72tYdBx+XquGxnCXjySjQS9IJgHJ9Eg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (40,            2,       1,         'esf_mcr_admin',   'ESF_MCR_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEFG98BeYflT5UoFzApJnS023phmn0mwsjPO0jnHzdXwOUUccrdYYW6Bw+GfPhvoGRw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (40,            2,       1,         'esf_mcr_user',    'ESF_MCR_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENUUW4gdhEh7DJKw0fH6w7watwT1r+X1D/pZZ/9K6c5P2ck1UD0yH7S/zJPhO874OA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (41,            2,       1,         'esf_ng_admin',    'ESF_NG_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEO5rFlb9O36UeV47+o7FEMqEuUTPul4GjTvxX/C74ZE3W6App72LcByovi8ZOV+0hQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (41,            2,       1,         'esf_ng_user',     'ESF_NG_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEKO151w7ySdteP1tmaOhm4Jta0t0SeJMjl5co/nsIlXunQV96fbTVZp5L+JNGQLodw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (42,            2,       1,         'esf_ogp_admin',   'ESF_OGP_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAELLDPpeir15UlZ7KBj/6uZ+fNH7/3Z2wr1MQwov43LqVZupc3Rrzx6r7wngRlFSILA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (42,            2,       1,         'esf_ogp_user',    'ESF_OGP_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEEi+G8YlbQdC3/xi9mu7tH3WjhCEHxWcanVMUdQHE3S9cNdwkyavw4bxABqlbr24tw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (43,            2,       1,         'esf_ojb_admin',   'ESF_OJB_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEEyA0fjr2Lrnak2Nc47q/Aiw4LfUCInSswQeSGmfrnBOMj6+fG/7FCJbedUNpCWqhA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (43,            2,       1,         'esf_ojb_user',    'ESF_OJB_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAENAIaJfu5jYakIAn9uEnvZWSPg19LTQL1ias/5/qXJERqFmBN7MSrw2+GTn1X4sbaw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (44,            2,       1,         'esf_fbv_admin',   'ESF_FBV_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEIbkGLpMG3FRXXPfXKoAueuJFaBL3Wv1IIXghVw2RBVr+WR7CFxc/y0RDod2/IozqA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (44,            2,       1,         'esf_fbv_user',    'ESF_FBV_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEMWPpTQG49O+LAPXAO0K4x+mdY7Zd6CaBlhsdjRus0Yfvb3odB+7VQc8aUygKCWNtQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (45,            2,       1,         'esf_bf_admin',    'ESF_BF_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJJTLGbNwf1KwHn6xsN7VAUCxZpGfU7qj/tO+AG6ae2KCd08PfIV2fYpKxBizPcfvQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (45,            2,       1,         'esf_bf_user',     'ESF_BF_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEINH+fq2L/Q1ScuW8WzDnHfk/3qDeu6cEEwQhopFG58xPVOBUUpkSt3BOhoE9XBc7A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (46,            2,       1,         'esf_asp_admin',   'ESF_ASP_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEP2KLrwFKJqC5q2q3va/1RyuO0TFVGFu8JIr+E6EsEDj/4LPVigo0cBBu5LVLIKd2w==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (46,            2,       1,         'esf_asp_user',    'ESF_ASP_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECTaMb56SFZmN0I7QuMxLcc7BiYi3fy3wX3cfSykG0xDFHJmMGU6BvMzRFBnU3/6CQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (47,            2,       0,         'co_sof_admin',    'CO_SOF_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEF6e7kCt1IXrF6uppR2lJ0QC1m/CiNk153AiSE0auMN2FIzdaBsJWye8EhMLEsN+cw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (47,            2,       0,         'co_sof_user',     'CO_SOF_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEB7l0HdYOx0719/TzgHZSi/MSiXO50r+wsGPAOXv2LeY9KUtUaNvPmdRvumn3ZcHnA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (48,            2,       0,         'cm_imdp_admin',   'CM_IMDP_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEE9rhH8Qet7DtebCZuqY9dhV72ODgqKM9I4T+S7Oc7tRmna2Q565hxuwv+fgKeD9BA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (48,            2,       0,         'cm_imdp_user',    'CM_IMDP_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEIa1cvqZU9hUZdFleF5GM0jYBTecIRQTJtM35XPh8pbIVvWqpgabrlp/zBP7I5OO+g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (49,            2,       1,         'ci_hmca_admin',   'CI_HMCA_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAgUUTyxnUO+SeP1wqR9xFVGOjiBpZyzWNQk99iwDNme4ELRVMIyNltdahkZwZQWLQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (49,            2,       1,         'ci_hmca_user',    'CI_HMCA_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEChDjkqWQlh8pjzAcYFoDhIERqZJjl5iN/p5ynNnh8KRec6WwJ1yNpAvB9KjvK3qAg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (50,            2,       1,         'cs_rct_admin',    'CS_RCT_ADMIN',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEKaarSg41ZUXAgk4lgvBnvOblwbRV8tIfrBSsCeFUifXGXRuQpDz1DA5y0ofssFCFA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (50,            2,       1,         'cs_rct_user',     'CS_RCT_USER',          NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEE9wylBXK19SMMmqvtrwutChbxNBCP2Kn1hdBMKEfdPg3l9rpDw2MLr2023KlbXHVw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (51,            2,       1,         'csm_jad_admin',   'CSM_JAD_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDVxdAN9GLSPdsTnjRMtMacMVkb62SASVz6fHzGx+KYbMxoDKDk6ycA7lAOqLliEDg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (51,            2,       1,         'csm_jad_user',    'CSM_JAD_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEHpmkGXdAmfRtzzw5bgtnSxr4honedh/p6kurP94Ni09nu0Ow+PH9mZRNx/2icKt8w==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (52,            2,       0,         'cim_admin',       'CIM_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEJLNLl0px54ELyKVV0lloFJbnlaM45VGFhSkTc4d5dR+Fwg75PMHSs9XXsRWk7gbRQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (52,            2,       0,         'cim_user',        'CIM_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEOWBjhb1rdKgF5rU2l3DTa+hypIJgiU9mesofoD8lkTb617jve/G2aVlNJrH6cUDYQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (53,            2,       0,         'cdis_admin',      'CDIS_ADMIN',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEDHFso++6mDy0SVr7yQzeDmVdtl2V91sXS7VU+bjkEic+rmSvhZO8E6dxQajGXyX0g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (53,            2,       0,         'cdis_user',       'CDIS_USER',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEFgJ1Eguus+oX10oOOGdqmNPkicBEZCtmXXGXByXxA1FcMCj1ZyKjE1b94hcoog/LQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (54,            2,       1,         'caps_ij_admin',   'CAPS_IJ_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEBqOQ5x/GHXEAyUZGLw/iD6Mqpyk/ma9MOsl2ZY/R//x5hqjL+0598XGLcm6wqBEWw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (54,            2,       1,         'caps_ij_user',    'CAPS_IJ_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEAW5H1r+gd+rJ3zr308+2Fxo9IvgFa5ZguUGDJjDWK2ZX2f+tvVFJHpL/irOp6fycw==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (55,            2,       1,         'caps_icv_admin',  'CAPS_ICV_ADMIN',       NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEM5ayTOMDaxjjL9OTMgtXZMLRBx5NNZWbdjk0PabppFLI3rUp/QPGc034gGzlzoB2g==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (55,            2,       1,         'caps_icv_user',   'CAPS_ICV_USER',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECVdCsPDxq2+1K5LuhvwBCBP9CQ+12LYX745OqQg3eVnO5SvPmNi0F7MlHQPfjSYLQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (56,            2,       1,         'caps_as_admin',   'CAPS_AS_ADMIN',        NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEN+7nYYFrwTbzW/sY+5Qkb1k6P295CDFVvUm1mM/TU8APXIDdwIoxk+9RH3RMGMDjg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (56,            2,       1,         'caps_as_user',    'CAPS_AS_USER',         NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEGuImZNfNz/R9ejoxm3EEHe2XovJG7JL3rKMVwjoisLG2OCu3A4j7UNwrl75wLcIHQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (57,            2,       1,         'apae_admin',      'APAE_ADMIN',           NULL,    NULL,              0,               'AQAAAAIAAYagAAAAECRlgrUvKxr13AqAmpP1A/YLJ96hjR8R9CqQL94jNRXSxIjaaNdnzXCsWvnHlBJoMQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (57,            2,       1,         'apae_user',       'APAE_USER',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEPwpEEiCAj27UYkEHxBLnj6DR+NLVivFMXu0HpiCjAYiH8SFrJMPcQ66iPmiDd2fuQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (58,            2,       0,         'cdi_admin',       'CDI_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEGcdPGLtTPVBf7nEZkQNXLW8WPDvf9WZYILPfhy3BWc29ldeYnOFrzWRX7iJYaFPlg==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (58,            2,       0,         'cdi_user',        'CDI_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEB3uLK1LdeQ8ru1IAVxd/zDhXxzdlaX04YC3eAicwK3+eeMrP3wl1j7QSn2WvVeifQ==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (59,            2,       1,         'cdb_admin',       'CDB_ADMIN',            NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEMJt1byOsA2sNlRR4yV3faUB9az83fwKDZ2uxgMlDfw6Npq4KfsFEx+af33J8cYE/A==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0),
                  (59,            2,       1,         'cdb_user',        'CDB_USER',             NULL,    NULL,              0,               'AQAAAAIAAYagAAAAEIQO0SpBsvmevziwDg6COjjMopZCuqvF+hHJxd/qSxBB/0hihRRSo/up10NJTqneaA==', NEWID(),         NEWID(),            NULL,          0,                      0,                  NULL,         0,                0)
      ) AS T (FacilityId, Scope, IsActive, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
)

INSERT INTO [dbo].[AspNetUsers]
            ([FacilityId]
            ,[Scope]
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
            (121, 3);
GO

-- ==================================================================================================================================
-- /api/receiving/create
-- {
--   "invoiceNumber": "string",
--   "supplyAuthorization": "string",
--   "observation": "string",
--   "receivingDate": "2025-11-11T13:18:52.763Z",
--   "supplierId": 0,
--   "responsibleId": 0,
--   "accountId": 0,
--   "receivedItems": [
--     { "quantity": 0, "unitValue": 0, "batch": "string", "expiryDate": "2025-11-11", "productId": 0 },
--     { "quantity": 0, "unitValue": 0, "batch": "string", "expiryDate": "2025-11-11", "productId": 0 }
--   ];
-- }

-- 22, 23, 46, 85, 86, 87, 106, 116, 129, 135, 151, 155, 167, 172, 174, 182, 183, 189, 190, 191, 192, 193, 194, 196, 197, 198, 199,
-- 200, 201, 202, 203, 204, 205, 206, 207, 208, 209, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 230, 246, 247, 257, 258,
-- 259, 260, 269, 270, 278, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 307, 310, 313, 317, 318, 319, 320, 326, 327, 330,

-- ----------------------------------------------------------------------------------------------------------------------------------
-- /api/account/login
-- "accountId": 4,
{
  "userName": "cdm_master",
  "password": "A2H@master"
}

-- /api/receiving/create
{
  "invoiceNumber": "305112",
  "supplyAuthorization": "AF 2024/004870",
  "observation": "",
  "receivingDate": "2024-01-05T08:40:08.000Z",
  "supplierId": 14,
  "responsibleId": 1,
  "accountId": 4,
  "receivedItems": [
    { "quantity": 3000, "unitValue": 0.05, "batch": "LOTJ0K1S2M3", "expiryDate": "2029-03-24", "productId": 1 },
    { "quantity": 1000, "unitValue": 1.10, "batch": "LOTN4O5P6Q7", "expiryDate": "2028-07-09", "productId": 150 },
    { "quantity": 500, "unitValue": 2.50, "batch": "LOTR8S9T0U1", "expiryDate": "2027-04-02", "productId": 335 },
    { "quantity": 200, "unitValue": 4.80, "batch": "LOTV2W3X4Y5", "expiryDate": "2026-10-10", "productId": 65 },
    { "quantity": 40, "unitValue": 18.25, "batch": "LOTZ6A7B8C9", "expiryDate": "2030-08-08", "productId": 111 },
    { "quantity": 850, "unitValue": 0.70, "batch": "LOTD0E1F2G3", "expiryDate": "2028-09-03", "productId": 222 },
    { "quantity": 1600, "unitValue": 0.20, "batch": "LOTH4I5J6K7", "expiryDate": "2029-06-21", "productId": 298 },
    { "quantity": 10, "unitValue": 75.00, "batch": "LOTL8M9N0O1", "expiryDate": "2027-01-26", "productId": 10 }
  ]
}

{
  "invoiceNumber": "178234",
  "supplyAuthorization": "AF 2024/009900",
  "observation": "",
  "receivingDate": "2024-04-18T09:33:52.000Z",
  "supplierId": 79,
  "responsibleId": 2,
  "accountId": 4,
  "receivedItems": [
    { "quantity": 1750, "unitValue": 0.63, "batch": "LOT4D12F5A0", "expiryDate": "2027-10-14", "productId": 227 },
    { "quantity": 1640, "unitValue": 0.44, "batch": "LOTC3E75369", "expiryDate": "2028-08-10", "productId": 91 },
    { "quantity": 1350, "unitValue": 1.27, "batch": "LOT97F4DBD4", "expiryDate": "2027-11-06", "productId": 31 },
    { "quantity": 1800, "unitValue": 0.25, "batch": "LOT3ACEE600", "expiryDate": "2029-07-07", "productId": 255 },
    { "quantity": 1785, "unitValue": 0.82, "batch": "LOTE5DB7141", "expiryDate": "2028-02-11", "productId": 38 },
    { "quantity": 1490, "unitValue": 1.09, "batch": "LOT1AEDEE4C", "expiryDate": "2028-11-28", "productId": 4 },
    { "quantity": 1900, "unitValue": 2.10, "batch": "LOTAF29CD64", "expiryDate": "2027-05-25", "productId": 120 },
    { "quantity": 10, "unitValue": 20.14, "batch": "LOT994D4FE3", "expiryDate": "2029-11-15", "productId": 59 },
    { "quantity": 1855, "unitValue": 0.12, "batch": "LOT7A330134", "expiryDate": "2028-09-26", "productId": 97 },
    { "quantity": 1700, "unitValue": 2.05, "batch": "LOTA6652657", "expiryDate": "2027-11-30", "productId": 14 }
  ]
}

{
  "invoiceNumber": "333444",
  "supplyAuthorization": "AF 2024/009191",
  "observation": "",
  "receivingDate": "2024-08-02T11:30:02.000Z",
  "supplierId": 3,
  "responsibleId": 2,
  "accountId": 4,
  "receivedItems": [
    { "quantity": 1000, "unitValue": 0.50, "batch": "LOTF8G9H0I1", "expiryDate": "2028-02-29", "productId": 24 },
    { "quantity": 2000, "unitValue": 0.35, "batch": "LOTJ2K3L4M5", "expiryDate": "2027-11-09", "productId": 250 },
    { "quantity": 50, "unitValue": 10.00, "batch": "LOTN6O7P8Q9", "expiryDate": "2029-10-10", "productId": 331 },
    { "quantity": 300, "unitValue": 4.50, "batch": "LOTR0S1T2U3", "expiryDate": "2026-01-01", "productId": 6 },
    { "quantity": 800, "unitValue": 1.20, "batch": "LOTV4W5X6Y7", "expiryDate": "2030-04-24", "productId": 140 },
    { "quantity": 150, "unitValue": 6.80, "batch": "LOTZ8A9B0C1", "expiryDate": "2027-07-17", "productId": 30 },
    { "quantity": 500, "unitValue": 2.00, "batch": "LOTD2E3F4G5", "expiryDate": "2028-06-01", "productId": 15 },
    { "quantity": 10, "unitValue": 80.00, "batch": "LOTH6I7J8K9", "expiryDate": "2029-03-03", "productId": 44 },
    { "quantity": 900, "unitValue": 0.90, "batch": "LOTL0M1N2O3", "expiryDate": "2026-05-20", "productId": 177 },
    { "quantity": 1600, "unitValue": 0.25, "batch": "LOTP4Q5R6S7", "expiryDate": "2028-01-30", "productId": 280 }
  ]
}

{
  "invoiceNumber": "315622",
  "supplyAuthorization": "AF 2024/400987",
  "observation": "",
  "receivingDate": "2024-11-26T10:14:26.000Z",
  "supplierId": 14,
  "responsibleId": 2,
  "accountId": 4,
  "receivedItems": [
    { "quantity": 100, "unitValue": 15.00, "batch": "LOTL5M6N7O", "expiryDate": "2026-03-01", "productId": 33 },
    { "quantity": 400, "unitValue": 8.75, "batch": "LOTV8W9X0Y", "expiryDate": "2028-04-16", "productId": 178 },
    { "quantity": 2000, "unitValue": 0.55, "batch": "LOTB1C2D3E", "expiryDate": "2029-07-29", "productId": 222 },
    { "quantity": 150, "unitValue": 12.30, "batch": "LOTF4G5H6J", "expiryDate": "2027-01-05", "productId": 88 },
    { "quantity": 1200, "unitValue": 1.75, "batch": "LOTK7L8M9N", "expiryDate": "2030-01-21", "productId": 299 },
    { "quantity": 900, "unitValue": 2.45, "batch": "LOTP0Q1R2S", "expiryDate": "2028-11-14", "productId": 5 }
  ]
}

{
  "invoiceNumber": "884103",
  "supplyAuthorization": "AF 2025/009001",
  "observation": "",
  "receivingDate": "2025-01-30T09:46:37.000Z",
  "supplierId": 14,
  "responsibleId": 1,
  "accountId": 4,
  "receivedItems": [
    { "quantity": 100, "unitValue": 22.50, "batch": "LOTQ2A8Z5C6", "expiryDate": "2026-03-01", "productId": 27 },
    { "quantity": 400, "unitValue": 15.00, "batch": "LOTD7F1E0H3", "expiryDate": "2028-01-20", "productId": 165 },
    { "quantity": 600, "unitValue": 9.99, "batch": "LOT9W5R3P1M", "expiryDate": "2027-09-19", "productId": 240 },
    { "quantity": 150, "unitValue": 18.25, "batch": "LOTJ4B0T6N8", "expiryDate": "2029-04-11", "productId": 95 }
  ]
}

{
  "invoiceNumber": "748123",
  "supplyAuthorization": "AF 2025/998877",
  "observation": "",
  "receivingDate": "2025-06-17T08:49:12.000Z",
  "supplierId": 15,
  "responsibleId": 2,
  "accountId": 4,
  "receivedItems": [
    { "quantity": 300, "unitValue": 8.00, "batch": "LOTC2D3E4F", "expiryDate": "2029-06-14", "productId": 60 },
    { "quantity": 1000, "unitValue": 1.05, "batch": "LOTG5H6J7K", "expiryDate": "2027-09-01", "productId": 300 },
    { "quantity": 150, "unitValue": 18.50, "batch": "LOTL8M9N0P", "expiryDate": "2030-02-28", "productId": 99 },
    { "quantity": 2200, "unitValue": 0.28, "batch": "LOTQ1R2S3T", "expiryDate": "2028-04-03", "productId": 311 },
    { "quantity": 500, "unitValue": 5.10, "batch": "LOTU4V5W6X", "expiryDate": "2026-05-20", "productId": 185 },
    { "quantity": 1300, "unitValue": 0.79, "batch": "LOTY7Z8A9B", "expiryDate": "2029-12-10", "productId": 245 },
    { "quantity": 100, "unitValue": 14.30, "batch": "LOTC0D1E2F", "expiryDate": "2027-10-30", "productId": 25 },
    { "quantity": 1600, "unitValue": 0.49, "batch": "LOTG3H4J5K", "expiryDate": "2028-08-22", "productId": 333 },
    { "quantity": 800, "unitValue": 2.10, "batch": "LOTL6M7N8P", "expiryDate": "2030-09-05", "productId": 170 },
    { "quantity": 700, "unitValue": 3.40, "batch": "LOTQ9R0S1T", "expiryDate": "2026-11-18", "productId": 48 }
  ]
}

{
  "invoiceNumber": "550382",
  "supplyAuthorization": "AF 2025/002047",
  "observation": "Conferido e aceito.",
  "receivingDate": "2025-09-15T13:18:25.000Z",
  "supplierId": 21,
  "responsibleId": 1,
  "accountId": 4,
  "receivedItems": [
    { "quantity": 450, "unitValue": 4.50, "batch": "LOTH6I8J0K2", "expiryDate": "2026-07-11", "productId": 300 },
    { "quantity": 620, "unitValue": 3.80, "batch": "LOTM5N7O9P1", "expiryDate": "2028-06-19", "productId": 150 },
    { "quantity": 780, "unitValue": 3.20, "batch": "LOTD4E6F8G0", "expiryDate": "2029-10-04", "productId": 28 },
    { "quantity": 950, "unitValue": 2.60, "batch": "LOTC3B5A7Z9", "expiryDate": "2027-11-23", "productId": 118 },
    { "quantity": 1100, "unitValue": 2.10, "batch": "LOTX2Y4Z6A8", "expiryDate": "2030-02-17", "productId": 335 },
    { "quantity": 1250, "unitValue": 1.70, "batch": "LOTQ1R3S5T7", "expiryDate": "2028-05-28", "productId": 78 }
  ]
}

-- ----------------------------------------------------------------------------------------------------------------------------------
-- /api/account/login
-- "accountId": 5,
{
  "userName": "cdm_admin",
  "password": "A2H@admin"
}

-- /api/receiving/create
{
  "invoiceNumber": "109876",
  "supplyAuthorization": "AF 2024/000421",
  "observation": "Conferência realizada",
  "receivingDate": "2024-01-29T10:13:21.000Z",
  "supplierId": 50,
  "responsibleId": 4,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1500, "unitValue": 0.77, "batch": "LOTAA1BB2C3", "expiryDate": "2028-01-01", "productId": 255 },
    { "quantity": 200, "unitValue": 3.99, "batch": "LOTDD4EE5F6", "expiryDate": "2027-12-31", "productId": 300 },
    { "quantity": 750, "unitValue": 1.45, "batch": "LOTGG7HH8I9", "expiryDate": "2026-05-17", "productId": 88 }
  ]
}

{
  "invoiceNumber": "449012",
  "supplyAuthorization": "AF 2024/000889",
  "observation": "",
  "receivingDate": "2024-01-30T08:27:38.000Z",
  "supplierId": 67,
  "responsibleId": 4,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1300, "unitValue": 0.88, "batch": "LOT2D5F9A4B", "expiryDate": "2029-05-20", "productId": 123 },
    { "quantity": 1700, "unitValue": 1.05, "batch": "LOT4A0B7C3E", "expiryDate": "2028-06-07", "productId": 329 },
    { "quantity": 1400, "unitValue": 0.33, "batch": "LOT7E9C1D5F", "expiryDate": "2027-09-09", "productId": 65 },
    { "quantity": 1800, "unitValue": 1.80, "batch": "LOT3B6A8D2C", "expiryDate": "2030-01-01", "productId": 245 },
    { "quantity": 1100, "unitValue": 0.60, "batch": "LOT6C2E4F0A", "expiryDate": "2026-08-22", "productId": 77 },
    { "quantity": 1600, "unitValue": 0.45, "batch": "LOT8D4A6B2C", "expiryDate": "2028-03-16", "productId": 321 },
    { "quantity": 1250, "unitValue": 1.20, "batch": "LOT0F1E3D5B", "expiryDate": "2029-11-11", "productId": 11 }
  ]
}

{
  "invoiceNumber": "998877",
  "supplyAuthorization": "AF 2024/000088",
  "observation": "",
  "receivingDate": "2024-02-07T09:31:47.000Z",
  "supplierId": 22,
  "responsibleId": 6,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 700, "unitValue": 1.15, "batch": "LOTA5F4B3C2", "expiryDate": "2029-04-12", "productId": 133 },
    { "quantity": 1300, "unitValue": 0.55, "batch": "LOTD6E7F8G9", "expiryDate": "2027-08-29", "productId": 15 },
    { "quantity": 10, "unitValue": 65.00, "batch": "LOTH0I1J2K3", "expiryDate": "2030-11-20", "productId": 55 },
    { "quantity": 950, "unitValue": 1.80, "batch": "LOTL4M5N6O7", "expiryDate": "2026-07-28", "productId": 266 },
    { "quantity": 1700, "unitValue": 0.30, "batch": "LOTP8Q9R0S1", "expiryDate": "2028-12-05", "productId": 3 },
    { "quantity": 400, "unitValue": 2.25, "batch": "LOTT2U3V4W5", "expiryDate": "2027-02-14", "productId": 160 },
    { "quantity": 100, "unitValue": 9.99, "batch": "LOTX6Y7Z8A9", "expiryDate": "2029-09-09", "productId": 336 },
    { "quantity": 250, "unitValue": 5.00, "batch": "LOTB0C1D2E3", "expiryDate": "2026-06-30", "productId": 77 },
    { "quantity": 600, "unitValue": 1.70, "batch": "LOTF4G5H6I7", "expiryDate": "2028-05-01", "productId": 299 }
  ]
}

{
  "invoiceNumber": "777777",
  "supplyAuthorization": "AF 2024/001000",
  "observation": "Itens frágeis, conferidos com atenção.",
  "receivingDate": "2024-03-13T14:03:45.000Z",
  "supplierId": 57,
  "responsibleId": 4,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1200, "unitValue": 0.45, "batch": "LOTH4I5J6K7", "expiryDate": "2029-08-31", "productId": 17 },
    { "quantity": 800, "unitValue": 1.30, "batch": "LOTL8M9N0O1", "expiryDate": "2027-10-05", "productId": 300 },
    { "quantity": 250, "unitValue": 5.50, "batch": "LOTP2Q3R4S5", "expiryDate": "2028-11-14", "productId": 333 },
    { "quantity": 10, "unitValue": 45.00, "batch": "LOTT6U7V8W9", "expiryDate": "2030-02-28", "productId": 7 },
    { "quantity": 1500, "unitValue": 0.70, "batch": "LOTX0Y1Z2A3", "expiryDate": "2026-04-19", "productId": 19 },
    { "quantity": 100, "unitValue": 9.25, "batch": "LOTB4C5D6E7", "expiryDate": "2029-05-10", "productId": 110 }
  ]
}

{
  "invoiceNumber": "213894",
  "supplyAuthorization": "AF 2024/001478",
  "observation": "",
  "receivingDate": "2024-03-25T10:38:52.000Z",
  "supplierId": 46,
  "responsibleId": 9,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1200, "unitValue": 0.55, "batch": "LOTB38F7A1C", "expiryDate": "2027-04-10", "productId": 105 },
    { "quantity": 1850, "unitValue": 1.15, "batch": "LOTC1D89E4F", "expiryDate": "2028-12-01", "productId": 280 },
    { "quantity": 900, "unitValue": 2.30, "batch": "LOT07A5F44D", "expiryDate": "2026-06-19", "productId": 14 }
  ]
}

{
  "invoiceNumber": "504030",
  "supplyAuthorization": "AF 2024/003344",
  "observation": "",
  "receivingDate": "2024-04-22T16:12:20.000Z",
  "supplierId": 9,
  -- Limpeza
  "responsibleId": 5,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 15, "unitValue": 25.40, "batch": "LOTJ8K9L0M1", "expiryDate": "2029-12-12", "productId": 87 },
    { "quantity": 5, "unitValue": 15.40, "batch": "LOTN2O3P4Q5", "expiryDate": "2027-10-30", "productId": 199 },
    { "quantity": 250, "unitValue": 53.00, "batch": "LOTR6S7T8U9", "expiryDate": "2028-08-22", "productId": 316 },
    { "quantity": 10, "unitValue": 124.00, "batch": "LOTV0W1X2Y3", "expiryDate": "2026-09-16", "productId": 325 },
    { "quantity": 1200, "unitValue": 22.50, "batch": "LOTZ4A5B6C7", "expiryDate": "2030-03-01", "productId": 260 },
    { "quantity": 1200, "unitValue": 40.65, "batch": "LOTD8E9F0G1", "expiryDate": "2027-05-07", "productId": 208 },
    { "quantity": 15, "unitValue": 34.50, "batch": "LOTH2I3J4K5", "expiryDate": "2028-01-20", "productId": 85 },
    { "quantity": 300, "unitValue": 7.20, "batch": "LOTL6M7N8O9", "expiryDate": "2029-07-17", "productId": 259 },
    { "quantity": 100, "unitValue": 40.28, "batch": "LOTP0Q1R2S3", "expiryDate": "2026-11-04", "productId": 291 },
    { "quantity": 10, "unitValue": 92.00, "batch": "LOTT4U5V6W7", "expiryDate": "2030-05-18", "productId": 296 },
    { "quantity": 5, "unitValue": 121.10, "batch": "LOTX8Y9Z0A1", "expiryDate": "2027-04-14", "productId": 189 },
    { "quantity": 10, "unitValue": 83.55, "batch": "LOTB2C3D4E5", "expiryDate": "2028-03-06", "productId": 86 },
    { "quantity": 5, "unitValue": 110.75, "batch": "LOTF6G7H8I9", "expiryDate": "2029-01-05", "productId": 202 },
    { "quantity": 250, "unitValue": 7.45, "batch": "LOTJ0K1L2M3", "expiryDate": "2026-10-23", "productId": 197 }
  ]
}

{
  "invoiceNumber": "452791",
  "supplyAuthorization": "AF 2024/110543",
  "observation": "Entrega parcial concluída.",
  "receivingDate": "2024-05-03T14:38:53.000Z",
  "supplierId": 4,
  "responsibleId": 9,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1200, "unitValue": 0.85, "batch": "LOTJ3K7L8P", "expiryDate": "2027-04-20", "productId": 105 },
    { "quantity": 850, "unitValue": 2.15, "batch": "LOTS9A2B6R", "expiryDate": "2029-01-15", "productId": 280 },
    { "quantity": 2500, "unitValue": 0.33, "batch": "LOTD4F5G6H", "expiryDate": "2026-11-01", "productId": 19 }
  ]
}

{
  "invoiceNumber": "321987",
  "supplyAuthorization": "AF 2024/004004",
  "observation": "",
  "receivingDate": "2024-05-15T09:28:16.000Z",
  "supplierId": 67,
  "responsibleId": 6,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 80, "unitValue": 15.75, "batch": "LOTF1G2H3I4", "expiryDate": "2028-01-05", "productId": 54 },
    { "quantity": 1600, "unitValue": 0.40, "batch": "LOTJ5K6L7M8", "expiryDate": "2026-04-29", "productId": 234 },
    { "quantity": 900, "unitValue": 2.00, "batch": "LOTN9O0P1Q2", "expiryDate": "2027-09-11", "productId": 33 },
    { "quantity": 2200, "unitValue": 0.22, "batch": "LOTR3S4T5U6", "expiryDate": "2029-02-19", "productId": 280 },
    { "quantity": 1400, "unitValue": 1.35, "batch": "LOTV7W8X9Y0", "expiryDate": "2030-11-25", "productId": 110 },
    { "quantity": 1700, "unitValue": 0.60, "batch": "LOTZ1A2B3C4", "expiryDate": "2026-10-04", "productId": 88 },
    { "quantity": 1050, "unitValue": 0.95, "batch": "LOTD5E6F7G8", "expiryDate": "2028-06-13", "productId": 159 }
  ]
}

{
  "invoiceNumber": "459021",
  "supplyAuthorization": "AF 2024/005128",
  "observation": "",
  "receivingDate": "2024-07-22T10:35:10.000Z",
  "supplierId": 24,
  "responsibleId": 6,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 500, "unitValue": 1.55, "batch": "LOTX1D8P3J4", "expiryDate": "2027-03-20", "productId": 105 },
    { "quantity": 1200, "unitValue": 0.88, "batch": "LOT2B9L7A6E", "expiryDate": "2028-09-01", "productId": 299 },
    { "quantity": 850, "unitValue": 2.10, "batch": "LOTK9Z4T6R2", "expiryDate": "2026-05-15", "productId": 45 },
    { "quantity": 300, "unitValue": 5.05, "batch": "LOTH7E3S1W0", "expiryDate": "2029-12-10", "productId": 312 },
    { "quantity": 1500, "unitValue": 0.33, "batch": "LOTC5F0V8M7", "expiryDate": "2030-01-25", "productId": 188 }
  ]
}

{
  "invoiceNumber": "351987",
  "supplyAuthorization": "AF 2024/004002",
  "observation": "",
  "receivingDate": "2024-07-29T13:15:00.000Z",
  "supplierId": 33,
  "responsibleId": 7,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1300, "unitValue": 0.90, "batch": "LOTD2C4A6B8", "expiryDate": "2028-04-29", "productId": 10 },
    { "quantity": 1700, "unitValue": 1.30, "batch": "LOTE3D5B7C9", "expiryDate": "2026-10-10", "productId": 20 },
    { "quantity": 1200, "unitValue": 0.70, "batch": "LOTF4E6C8A0", "expiryDate": "2029-06-06", "productId": 30 },
    { "quantity": 1850, "unitValue": 0.50, "batch": "LOT8F0A2B4C", "expiryDate": "2030-02-14", "productId": 40 }
  ]
}

{
  "invoiceNumber": "654321",
  "supplyAuthorization": "AF 2024/002002",
  "observation": "",
  "receivingDate": "2024-08-23T14:45:35.000Z",
  "supplierId": 14,
  "responsibleId": 8,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 3000, "unitValue": 0.15, "batch": "LOT7D6E5F4A", "expiryDate": "2028-04-10", "productId": 65 },
    { "quantity": 1500, "unitValue": 0.90, "batch": "LOT3C2B1A09", "expiryDate": "2027-01-30", "productId": 178 },
    { "quantity": 400, "unitValue": 3.45, "batch": "LOT8F9E0D1C", "expiryDate": "2026-11-14", "productId": 300 }
  ]
}

{
  "invoiceNumber": "605483",
  "supplyAuthorization": "AF 2024/998123",
  "observation": "Conferência completa e sem divergências.",
  "receivingDate": "2024-09-17T11:03:50.000Z",
  "supplierId": 14,
  "responsibleId": 5,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 10, "unitValue": 50.00, "batch": "LOTI7J8K9L", "expiryDate": "2029-08-01", "productId": 3 },
    { "quantity": 5, "unitValue": 120.00, "batch": "LOTM0N1P2Q", "expiryDate": "2028-05-19", "productId": 333 },
    { "quantity": 50, "unitValue": 10.50, "batch": "LOTR3S4T5U", "expiryDate": "2026-12-07", "productId": 88 },
    { "quantity": 20, "unitValue": 45.99, "batch": "LOTV6W7X8Y", "expiryDate": "2030-06-25", "productId": 241 },
    { "quantity": 30, "unitValue": 22.10, "batch": "LOTZ9A0B1C", "expiryDate": "2027-02-14", "productId": 250 },
    { "quantity": 100, "unitValue": 8.75, "batch": "LOTD2E3F4G", "expiryDate": "2028-11-04", "productId": 110 },
    { "quantity": 150, "unitValue": 6.30, "batch": "LOTH5I6J7K", "expiryDate": "2029-04-16", "productId": 301 }
  ]
}

{
  "invoiceNumber": "587634",
  "supplyAuthorization": "AF 2024/001099",
  "observation": "",
  "receivingDate": "2024-10-09T15:30:02.000Z",
  "supplierId": 63,
  "responsibleId": 4,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 2000, "unitValue": 0.40, "batch": "LOTI2J3K4L", "expiryDate": "2027-05-08", "productId": 18 },
    { "quantity": 1800, "unitValue": 0.65, "batch": "LOTM5N6P7Q", "expiryDate": "2028-10-02", "productId": 140 },
    { "quantity": 1500, "unitValue": 0.90, "batch": "LOTR8S9T0U", "expiryDate": "2029-05-15", "productId": 300 },
    { "quantity": 1200, "unitValue": 1.50, "batch": "LOTV1W2X3Y", "expiryDate": "2026-11-29", "productId": 68 },
    { "quantity": 1000, "unitValue": 2.50, "batch": "LOTZ4A5B6C", "expiryDate": "2030-03-22", "productId": 225 },
    { "quantity": 800, "unitValue": 3.00, "batch": "LOTD7E8F9G", "expiryDate": "2027-01-15", "productId": 15 },
    { "quantity": 600, "unitValue": 4.50, "batch": "LOTH0I1J2K", "expiryDate": "2028-06-03", "productId": 300 },
    { "quantity": 400, "unitValue": 6.75, "batch": "LOTL3M4N5P", "expiryDate": "2029-02-18", "productId": 25 },
    { "quantity": 200, "unitValue": 9.00, "batch": "LOTQ6R7S8T", "expiryDate": "2027-11-01", "productId": 170 },
    { "quantity": 100, "unitValue": 15.00, "batch": "LOTU9V0W1X", "expiryDate": "2030-04-10", "productId": 95 },
    { "quantity": 50, "unitValue": 25.00, "batch": "LOTY2Z3A4B", "expiryDate": "2028-02-28", "productId": 321 },
    { "quantity": 20, "unitValue": 40.00, "batch": "LOTC5D6E7F", "expiryDate": "2029-10-07", "productId": 255 },
    { "quantity": 10, "unitValue": 60.00, "batch": "LOTG8H9I0J", "expiryDate": "2026-07-20", "productId": 20 }
  ]
}

{
  "invoiceNumber": "501927",
  "supplyAuthorization": "AF 2024/230987",
  "observation": "",
  "receivingDate": "2024-11-27T08:32:15.000Z",
  "supplierId": 4,
  "responsibleId": 7,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1000, "unitValue": 1.50, "batch": "LOTI7J8K9L", "expiryDate": "2028-09-05", "productId": 252 },
    { "quantity": 1500, "unitValue": 0.80, "batch": "LOTM0N1P2Q", "expiryDate": "2027-03-09", "productId": 30 },
    { "quantity": 2000, "unitValue": 0.30, "batch": "LOTR3S4T5U", "expiryDate": "2029-12-12", "productId": 102 }
  ]
}

{
  "invoiceNumber": "900418",
  "supplyAuthorization": "AF 2025/765012",
  "observation": "Prioridade de armazenamento.",
  "receivingDate": "2025-01-09T13:15:42.000Z",
  "supplierId": 3,
  "responsibleId": 6,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 50, "unitValue": 35.00, "batch": "LOTB0C1D2E", "expiryDate": "2027-03-03", "productId": 1 },
    { "quantity": 1000, "unitValue": 0.68, "batch": "LOTG3H4J5K", "expiryDate": "2029-09-09", "productId": 336 },
    { "quantity": 300, "unitValue": 7.90, "batch": "LOTL6M7N8P", "expiryDate": "2026-06-25", "productId": 150 },
    { "quantity": 1600, "unitValue": 0.42, "batch": "LOTQ9R0S1T", "expiryDate": "2028-10-19", "productId": 210 },
    { "quantity": 700, "unitValue": 3.15, "batch": "LOTU2V3W4X", "expiryDate": "2030-04-01", "productId": 72 },
    { "quantity": 2200, "unitValue": 0.18, "batch": "LOTY5Z6A7B", "expiryDate": "2027-11-22", "productId": 195 },
    { "quantity": 10, "unitValue": 45.99, "batch": "LOTC8D9E0F", "expiryDate": "2028-01-11", "productId": 13 }
  ]
}

{
  "invoiceNumber": "210987",
  "supplyAuthorization": "AF 2025/007320",
  "observation": "",
  "receivingDate": "2025-02-19T09:35:20.000Z",
  "supplierId": 28,
  "responsibleId": 8,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1500, "unitValue": 1.75, "batch": "LOTR4T6Y8U0", "expiryDate": "2028-10-10", "productId": 21 },
    { "quantity": 1300, "unitValue": 1.95, "batch": "LOTF3G5H7J9", "expiryDate": "2029-06-02", "productId": 89 },
    { "quantity": 1100, "unitValue": 2.15, "batch": "LOTL2M4N6P8", "expiryDate": "2027-07-28", "productId": 133 },
    { "quantity": 900, "unitValue": 2.35, "batch": "LOTV1W3X5Z7", "expiryDate": "2030-04-15", "productId": 277 },
    { "quantity": 700, "unitValue": 2.55, "batch": "LOTB0C2D4E6", "expiryDate": "2026-01-31", "productId": 315 },
    { "quantity": 500, "unitValue": 2.75, "batch": "LOTS9A1Q3B5", "expiryDate": "2028-12-07", "productId": 55 },
    { "quantity": 300, "unitValue": 2.95, "batch": "LOTJ8K0L2M4", "expiryDate": "2027-05-09", "productId": 188 },
    { "quantity": 100, "unitValue": 3.15, "batch": "LOT7P9R1S3T", "expiryDate": "2029-09-29", "productId": 244 }
  ]
}

{
  "invoiceNumber": "901234",
  "supplyAuthorization": "AF 2025/006006",
  "observation": "",
  "receivingDate": "2025-02-28T13:10:47.000Z",
  "supplierId": 24,
  "responsibleId": 7,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1500, "unitValue": 0.70, "batch": "LOTX5Y6Z7A8", "expiryDate": "2028-05-18", "productId": 2 },
    { "quantity": 2000, "unitValue": 0.35, "batch": "LOTB9C0D1E2", "expiryDate": "2026-06-06", "productId": 250 },
    { "quantity": 1300, "unitValue": 1.20, "batch": "LOTF3G4H5I6", "expiryDate": "2029-04-14", "productId": 30 },
    { "quantity": 1150, "unitValue": 0.48, "batch": "LOTJ7K8L9M0", "expiryDate": "2027-10-27", "productId": 101 },
    { "quantity": 1850, "unitValue": 0.88, "batch": "LOTN1O2P3Q4", "expiryDate": "2030-01-09", "productId": 235 },
    { "quantity": 600, "unitValue": 2.30, "batch": "LOTR5S6T7U8", "expiryDate": "2028-07-03", "productId": 125 },
    { "quantity": 30, "unitValue": 18.50, "batch": "LOTV9W0X1Y2", "expiryDate": "2029-12-05", "productId": 5 }
  ]
}

{
  "invoiceNumber": "802468",
  "supplyAuthorization": "AF 2025/010010",
  "observation": "",
  "receivingDate": "2025-03-05T12:38:14.000Z",
  "supplierId": 25,
  "responsibleId": 9,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 500, "unitValue": 3.80, "batch": "LOTR9S0T1U2", "expiryDate": "2026-11-03", "productId": 27 },
    { "quantity": 1200, "unitValue": 1.25, "batch": "LOTV3W4X5Y6", "expiryDate": "2027-12-12", "productId": 133 },
    { "quantity": 1900, "unitValue": 0.50, "batch": "LOTZ7A8B9C0", "expiryDate": "2028-06-21", "productId": 285 },
    { "quantity": 800, "unitValue": 2.10, "batch": "LOTD1E2F3G4", "expiryDate": "2029-01-17", "productId": 41 },
    { "quantity": 1400, "unitValue": 0.90, "batch": "LOTH5I6J7K8", "expiryDate": "2030-04-28", "productId": 225 },
    { "quantity": 2300, "unitValue": 0.15, "batch": "LOTL9M0N1O2", "expiryDate": "2027-03-24", "productId": 336 },
    { "quantity": 600, "unitValue": 4.50, "batch": "LOTP3Q4R5S6", "expiryDate": "2028-10-06", "productId": 6 },
    { "quantity": 1050, "unitValue": 0.60, "batch": "LOTT7U8V9W0", "expiryDate": "2026-08-05", "productId": 245 },
    { "quantity": 1700, "unitValue": 0.75, "batch": "LOTX1Y2Z3A4", "expiryDate": "2029-02-09", "productId": 115 },
    { "quantity": 1150, "unitValue": 1.05, "batch": "LOTB5C6D7E8", "expiryDate": "2030-11-19", "productId": 177 }
  ]
}

{
  "invoiceNumber": "550019",
  "supplyAuthorization": "AF 2025/678901",
  "observation": "Itens frágeis, manuseio cuidadoso.",
  "receivingDate": "2025-04-25T14:36:07.000Z",
  "supplierId": 24,
  "responsibleId": 1,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 10, "unitValue": 55.00, "batch": "LOTU2V3W4X", "expiryDate": "2029-04-10", "productId": 7 },
    { "quantity": 50, "unitValue": 28.75, "batch": "LOTY5Z6A7B", "expiryDate": "2027-03-27", "productId": 122 },
    { "quantity": 100, "unitValue": 17.10, "batch": "LOTC8D9E0F", "expiryDate": "2030-01-01", "productId": 30 },
    { "quantity": 500, "unitValue": 3.60, "batch": "LOTG1H2J3K", "expiryDate": "2028-05-13", "productId": 255 },
    { "quantity": 1800, "unitValue": 0.58, "batch": "LOTL4M5N6P", "expiryDate": "2026-07-29", "productId": 222 },
    { "quantity": 900, "unitValue": 2.01, "batch": "LOTQ7R8S9T", "expiryDate": "2029-08-08", "productId": 84 },
    { "quantity": 300, "unitValue": 9.99, "batch": "LOTU0V1W2X", "expiryDate": "2027-11-03", "productId": 130 },
    { "quantity": 2000, "unitValue": 0.35, "batch": "LOTY3Z4A5B", "expiryDate": "2028-02-01", "productId": 315 },
    { "quantity": 1100, "unitValue": 1.44, "batch": "LOTC6D7E8F", "expiryDate": "2030-11-25", "productId": 241 },
    { "quantity": 700, "unitValue": 4.25, "batch": "LOTG9H0J1K", "expiryDate": "2026-09-17", "productId": 44 },
    { "quantity": 1400, "unitValue": 0.90, "batch": "LOTL2M3N4P", "expiryDate": "2029-03-01", "productId": 265 },
    { "quantity": 400, "unitValue": 6.70, "batch": "LOTQ5R6S7T", "expiryDate": "2028-10-04", "productId": 66 },
    { "quantity": 1600, "unitValue": 0.20, "batch": "LOTU8V9W0X", "expiryDate": "2027-05-19", "productId": 335 }
  ]
}

{
  "invoiceNumber": "459012",
  "supplyAuthorization": "AF 2025/001345",
  "observation": "Entrega parcial",
  "receivingDate": "2025-05-14T11:24:32.000Z",
  "supplierId": 46,
  "responsibleId": 9,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 500, "unitValue": 1.55, "batch": "LOTC8A2F9B1", "expiryDate": "2027-01-20", "productId": 105 },
    { "quantity": 1200, "unitValue": 0.78, "batch": "LOT4E781C3D", "expiryDate": "2029-05-15", "productId": 331 },
    { "quantity": 350, "unitValue": 3.10, "batch": "LOTB5D90A6F", "expiryDate": "2026-03-01", "productId": 21 },
    { "quantity": 800, "unitValue": 0.50, "batch": "LOT9F4E3C1B", "expiryDate": "2028-11-20", "productId": 188 }
  ]
}

{
  "invoiceNumber": "543210",
  "supplyAuthorization": "AF 2025/008008",
  "observation": "",
  "receivingDate": "2025-06-17T15:30:41.000Z",
  "supplierId": 18,
  "responsibleId": 5,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1800, "unitValue": 0.99, "batch": "LOTB1C2D3E4", "expiryDate": "2029-11-06", "productId": 90 },
    { "quantity": 250, "unitValue": 6.80, "batch": "LOTF5G6H7I8", "expiryDate": "2026-02-14", "productId": 55 },
    { "quantity": 1300, "unitValue": 1.45, "batch": "LOTJ9K0L1M2", "expiryDate": "2028-01-26", "productId": 128 },
    { "quantity": 900, "unitValue": 2.75, "batch": "LOTN3O4P5Q6", "expiryDate": "2027-06-08", "productId": 150 },
    { "quantity": 1600, "unitValue": 0.38, "batch": "LOTR7S8T9U0", "expiryDate": "2030-09-30", "productId": 275 },
    { "quantity": 400, "unitValue": 4.10, "batch": "LOTV1W2X3Y4", "expiryDate": "2028-12-15", "productId": 45 },
    { "quantity": 2100, "unitValue": 0.18, "batch": "LOTZ5A6B7C8", "expiryDate": "2029-05-23", "productId": 325 },
    { "quantity": 100, "unitValue": 12.00, "batch": "LOTD9E0F1G2", "expiryDate": "2026-03-11", "productId": 78 }
  ]
}

{
  "invoiceNumber": "762001",
  "supplyAuthorization": "AF 2025/009187",
  "observation": "",
  "receivingDate": "2025-08-20T11:55:21.000Z",
  "supplierId": 14,
  "responsibleId": 4,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 10, "unitValue": 50.00, "batch": "LOT4A6B8C0D", "expiryDate": "2030-11-11", "productId": 1 },
    { "quantity": 5, "unitValue": 100.00, "batch": "LOT2F0E8D6C", "expiryDate": "2028-03-03", "productId": 335 },
    { "quantity": 250, "unitValue": 4.50, "batch": "LOT5C9B7A3D", "expiryDate": "2026-09-25", "productId": 111 },
    { "quantity": 1500, "unitValue": 0.35, "batch": "LOTB0D4F6A8", "expiryDate": "2027-06-08", "productId": 251 },
    { "quantity": 2000, "unitValue": 0.70, "batch": "LOT7E1C5B9D", "expiryDate": "2029-08-19", "productId": 30 },
    { "quantity": 1300, "unitValue": 1.30, "batch": "LOTD2A4F8C0", "expiryDate": "2028-01-28", "productId": 187 },
    { "quantity": 1600, "unitValue": 0.40, "batch": "LOT9B3D5F7A", "expiryDate": "2026-12-12", "productId": 222 }
  ]
}

{
  "invoiceNumber": "808080",
  "supplyAuthorization": "AF 2025/000888",
  "observation": "Entrega grande",
  "receivingDate": "2025-09-01T13:17:21.000Z",
  "supplierId": 26,
  "responsibleId": 6,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1500, "unitValue": 0.60, "batch": "LOT9A0B1C2D", "expiryDate": "2028-09-01", "productId": 25 },
    { "quantity": 2500, "unitValue": 0.45, "batch": "LOT3E4F5G6H", "expiryDate": "2027-03-17", "productId": 160 },
    { "quantity": 3500, "unitValue": 0.28, "batch": "LOT7I8J9K0L", "expiryDate": "2029-12-10", "productId": 305 },
    { "quantity": 500, "unitValue": 1.80, "batch": "LOT1M2N3O4P", "expiryDate": "2026-05-23", "productId": 7 },
    { "quantity": 800, "unitValue": 1.10, "batch": "LOT5Q6R7S8T", "expiryDate": "2030-01-05", "productId": 210 },
    { "quantity": 100, "unitValue": 7.00, "batch": "LOT9U0V1W2X", "expiryDate": "2028-07-14", "productId": 122 },
    { "quantity": 1000, "unitValue": 0.75, "batch": "LOT3Y4Z5A6B", "expiryDate": "2027-01-08", "productId": 15 },
    { "quantity": 200, "unitValue": 4.00, "batch": "LOT7C8D9E0F", "expiryDate": "2029-11-25", "productId": 321 },
    { "quantity": 60, "unitValue": 15.50, "batch": "LOT1G2H3I4J", "expiryDate": "2026-10-30", "productId": 55 },
    { "quantity": 400, "unitValue": 2.20, "batch": "LOT5K6L7M8N", "expiryDate": "2028-04-11", "productId": 240 },
    { "quantity": 90, "unitValue": 8.50, "batch": "LOT9O0P1Q2R", "expiryDate": "2027-09-03", "productId": 329 },
    { "quantity": 1200, "unitValue": 0.30, "batch": "LOT3S4T5U6V", "expiryDate": "2030-02-18", "productId": 80 },
    { "quantity": 180, "unitValue": 3.10, "batch": "LOT7W8X9Y0Z", "expiryDate": "2029-06-07", "productId": 195 }
  ]
}

{
  "invoiceNumber": "404040",
  "supplyAuthorization": "AF 2025/001122",
  "observation": "Revisar lote",
  "receivingDate": "2025-10-14T14:01:51.000Z",
  "supplierId": 33,
  "responsibleId": 10,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 1000, "unitValue": 0.88, "batch": "LOT8D7C6B5A", "expiryDate": "2026-08-16", "productId": 145 },
    { "quantity": 1700, "unitValue": 0.22, "batch": "LOT2F3E4D5C", "expiryDate": "2029-05-09", "productId": 332 },
    { "quantity": 600, "unitValue": 1.70, "batch": "LOT9A0B1C2D", "expiryDate": "2028-03-24", "productId": 45 },
    { "quantity": 250, "unitValue": 4.10, "batch": "LOT4E5F6G7H", "expiryDate": "2027-11-01", "productId": 262 },
    { "quantity": 50, "unitValue": 18.00, "batch": "LOT1I2J3K4L", "expiryDate": "2030-10-07", "productId": 9 }
  ]
}

{
  "invoiceNumber": "459012",
  "supplyAuthorization": "AF 2025/115793",
  "observation": "",
  "receivingDate": "2025-11-12T10:43:31.000Z",
  "supplierId": 46,
  "responsibleId": 9,
  "accountId": 5,
  "receivedItems": [
    { "quantity": 500, "unitValue": 5.99, "batch": "LOTX1D8F4A", "expiryDate": "2028-04-20", "productId": 105 },
    { "quantity": 1200, "unitValue": 1.45, "batch": "LOTC8E7536", "expiryDate": "2027-11-15", "productId": 280 },
    { "quantity": 300, "unitValue": 12.00, "batch": "LOT95F4D7B", "expiryDate": "2029-01-01", "productId": 329 },
    { "quantity": 850, "unitValue": 0.75, "batch": "LOT3ACEE2D", "expiryDate": "2026-06-06", "productId": 17 }
  ]
}

-- ----------------------------------------------------------------------------------------------------------------------------------
-- /api/account/login
-- "accountId": 6,
{
  "userName": "cdm_user",
  "password": "A2H@user"
}

-- /api/receiving/create
{
  "invoiceNumber": "100000",
  "supplyAuthorization": "AF 2024/000001",
  "observation": "",
  "receivingDate": "2024-01-08T09:18:52.763Z",
  "supplierId": 50,
  "responsibleId": 7,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1750, "unitValue": 0.63, "batch": "LOT4D12F5A0", "expiryDate": "2027-10-14", "productId": 227 },
    { "quantity": 1640, "unitValue": 0.44, "batch": "LOTC3E75369", "expiryDate": "2028-08-10", "productId": 91 },
    { "quantity": 1350, "unitValue": 1.27, "batch": "LOT97F4DBD4", "expiryDate": "2027-11-06", "productId": 31 },
    { "quantity": 1800, "unitValue": 0.25, "batch": "LOT3ACEE600", "expiryDate": "2029-07-07", "productId": 255 },
    { "quantity": 1785, "unitValue": 0.82, "batch": "LOTE5DB7141", "expiryDate": "2028-02-11", "productId": 38 },
    { "quantity": 1490, "unitValue": 1.09, "batch": "LOT1AEDEE4C", "expiryDate": "2028-11-28", "productId": 4 },
    { "quantity": 1900, "unitValue": 2.10, "batch": "LOTAF29CD64", "expiryDate": "2027-05-25", "productId": 120 },
    { "quantity": 10, "unitValue": 20.14, "batch": "LOT994D4FE3", "expiryDate": "2029-11-15", "productId": 59 },
    { "quantity": 1855, "unitValue": 0.12, "batch": "LOT7A330134", "expiryDate": "2028-09-26", "productId": 97 },
    { "quantity": 1700, "unitValue": 2.05, "batch": "LOTA6652657", "expiryDate": "2027-11-30", "productId": 14 },
  ]
}

{
  "invoiceNumber": "451890",
  "supplyAuthorization": "AF 2024/001357",
  "observation": "",
  "receivingDate": "2024-03-12T11:35:13.000Z",
  "supplierId": 4,
  "responsibleId": 9,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 500, "unitValue": 1.50, "batch": "LOTB5F1G2H3", "expiryDate": "2028-04-20", "productId": 105 },
    { "quantity": 1200, "unitValue": 0.85, "batch": "LOTC6D4E7F8", "expiryDate": "2027-09-01", "productId": 280 },
    { "quantity": 300, "unitValue": 5.25, "batch": "LOTG9H0I1J2", "expiryDate": "2029-01-15", "productId": 12 },
    { "quantity": 800, "unitValue": 0.33, "batch": "LOTK3L4M5N6", "expiryDate": "2026-11-23", "productId": 311 },
    { "quantity": 150, "unitValue": 12.99, "batch": "LOTP7Q8R9S0", "expiryDate": "2030-05-05", "productId": 301 }
  ]
}

{
  "invoiceNumber": "123456",
  "supplyAuthorization": "AF 2024/001001",
  "observation": "",
  "receivingDate": "2024-03-12T10:30:58.000Z",
  "supplierId": 46,
  "responsibleId": 5,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1200, "unitValue": 1.50, "batch": "LOTB4E7C1F2", "expiryDate": "2026-05-20", "productId": 10 },
    { "quantity": 950, "unitValue": 0.75, "batch": "LOT9A2D0F83", "expiryDate": "2027-12-18", "productId": 145 },
    { "quantity": 2100, "unitValue": 0.30, "batch": "LOTC8F1E5B4", "expiryDate": "2028-09-01", "productId": 331 },
    { "quantity": 150, "unitValue": 5.20, "batch": "LOT12D34E56", "expiryDate": "2029-01-25", "productId": 28 },
    { "quantity": 800, "unitValue": 2.15, "batch": "LOTF6A7B8C9", "expiryDate": "2030-03-05", "productId": 315 }
  ]
}

{
  "invoiceNumber": "789012",
  "supplyAuthorization": "AF 2024/007007",
  "observation": "",
  "receivingDate": "2024-04-01T11:12:13.000Z",
  "supplierId": 33,
  "responsibleId": 9,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 300, "unitValue": 5.00, "batch": "LOTZ3A4B5C6", "expiryDate": "2027-04-04", "productId": 16 },
    { "quantity": 2000, "unitValue": 0.20, "batch": "LOTD7E8F9G0", "expiryDate": "2028-03-29", "productId": 314 },
    { "quantity": 10, "unitValue": 45.00, "batch": "LOTH1I2J3K4", "expiryDate": "2030-05-02", "productId": 40 },
    { "quantity": 1700, "unitValue": 0.65, "batch": "LOTL5M6N7O8", "expiryDate": "2026-09-17", "productId": 240 },
    { "quantity": 1400, "unitValue": 1.05, "batch": "LOTP9Q0R1S2", "expiryDate": "2029-08-11", "productId": 170 },
    { "quantity": 1100, "unitValue": 0.50, "batch": "LOTT3U4V5W6", "expiryDate": "2028-11-20", "productId": 333 },
    { "quantity": 500, "unitValue": 3.10, "batch": "LOTX7Y8Z9A0", "expiryDate": "2027-02-08", "productId": 13 }
  ]
}

{
  "invoiceNumber": "889900",
  "supplyAuthorization": "AF 2024/007123",
  "observation": "",
  "receivingDate": "2024-04-16T15:42:24.000Z",
  "supplierId": 28,
  "responsibleId": 10,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 120, "unitValue": 8.00, "batch": "LOTP2Q3R4S5", "expiryDate": "2026-08-14", "productId": 5 },
    { "quantity": 600, "unitValue": 1.25, "batch": "LOTT6U7V8W9", "expiryDate": "2029-02-17", "productId": 144 },
    { "quantity": 25, "unitValue": 35.00, "batch": "LOTX0Y1Z2A3", "expiryDate": "2027-11-11", "productId": 321 },
    { "quantity": 1150, "unitValue": 0.49, "batch": "LOTB4C5D6E7", "expiryDate": "2028-03-30", "productId": 9 }
  ]
}

{
  "invoiceNumber": "190765",
  "supplyAuthorization": "AF 2024/334455",
  "observation": "",
  "receivingDate": "2024-07-03T09:38:12.000Z",
  "supplierId": 3,
  "responsibleId": 4,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 750, "unitValue": 3.10, "batch": "LOTH1J2K3L", "expiryDate": "2028-02-18", "productId": 145 },
    { "quantity": 1500, "unitValue": 0.99, "batch": "LOTP4Q5R6S", "expiryDate": "2026-08-01", "productId": 102 },
    { "quantity": 600, "unitValue": 4.50, "batch": "LOTU7V8W9X", "expiryDate": "2029-05-12", "productId": 263 },
    { "quantity": 1000, "unitValue": 1.10, "batch": "LOTY1Z2A3B", "expiryDate": "2027-12-24", "productId": 300 },
    { "quantity": 250, "unitValue": 6.80, "batch": "LOTG4H5J6K", "expiryDate": "2030-10-08", "productId": 77 }
  ]
}

{
  "invoiceNumber": "660022",
  "supplyAuthorization": "AF 2024/002468",
  "observation": "",
  "receivingDate": "2024-08-05T14:31:14.000Z",
  "supplierId": 7,
  "responsibleId": 5,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 2500, "unitValue": 0.15, "batch": "LOTB3A5C7E9", "expiryDate": "2030-09-09", "productId": 36 },
    { "quantity": 1800, "unitValue": 0.49, "batch": "LOT4E6D8F0A", "expiryDate": "2027-05-12", "productId": 115 },
    { "quantity": 900, "unitValue": 1.25, "batch": "LOT5C9A1B3D", "expiryDate": "2028-02-29", "productId": 231 },
    { "quantity": 1400, "unitValue": 0.72, "batch": "LOTD0B2F4E6", "expiryDate": "2029-01-27", "productId": 241 },
    { "quantity": 300, "unitValue": 3.15, "batch": "LOT7A3C5B9D", "expiryDate": "2026-06-01", "productId": 285 },
    { "quantity": 200, "unitValue": 5.05, "batch": "LOT9F1D3E7G", "expiryDate": "2028-11-18", "productId": 315 },
    { "quantity": 400, "unitValue": 2.50, "batch": "LOT6B8A0C2D", "expiryDate": "2027-04-04", "productId": 60 }
  ]
}

{
  "invoiceNumber": "213456",
  "supplyAuthorization": "AF 2024/006001",
  "observation": "",
  "receivingDate": "2024-09-17T10:45:10.000Z",
  "supplierId": 23,
  "responsibleId": 5,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 150, "unitValue": 7.20, "batch": "LOTN4O5P6Q7", "expiryDate": "2026-12-01", "productId": 103 },
    { "quantity": 300, "unitValue": 2.15, "batch": "LOTR8S9T0U1", "expiryDate": "2029-06-15", "productId": 248 },
    { "quantity": 500, "unitValue": 1.50, "batch": "LOTV2W3X4Y5", "expiryDate": "2028-04-18", "productId": 248 },
    { "quantity": 1000, "unitValue": 0.80, "batch": "LOTZ6A7B8C9", "expiryDate": "2027-03-27", "productId": 125 },
    { "quantity": 50, "unitValue": 15.00, "batch": "LOTD0E1F2G3", "expiryDate": "2030-07-04", "productId": 50 }
  ]
}

{
  "invoiceNumber": "834710",
  "supplyAuthorization": "AF 2024/304567",
  "observation": "",
  "receivingDate": "2024-10-14T11:12:13.000Z",
  "supplierId": 60,
  -- Escritório
  "responsibleId": 8,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 300, "unitValue": 25.50, "batch": "LOTV6W7X8Y", "expiryDate": "2026-06-19", "productId": 198 },
    { "quantity": 450, "unitValue": 2.75, "batch": "LOTZ9A0B1C", "expiryDate": "2027-09-28", "productId": 294 },
    { "quantity": 850, "unitValue": 0.85, "batch": "LOTD2E3F4G", "expiryDate": "2028-12-30", "productId": 212 },
    { "quantity": 750, "unitValue": 4.70, "batch": "LOTH5I6J7K", "expiryDate": "2029-04-03", "productId": 217 },
    { "quantity": 850, "unitValue": 0.83, "batch": "LOTL8M9N0P", "expiryDate": "2030-05-11", "productId": 213 },
    { "quantity": 5, "unitValue": 15.50, "batch": "LOTQ1R2S3T", "expiryDate": "2026-12-24", "productId": 135 },
    { "quantity": 1200, "unitValue": 4.20, "batch": "LOTU4V5W6X", "expiryDate": "2027-02-06", "productId": 23 },
    { "quantity": 850, "unitValue": 0.80, "batch": "LOTY7Z8A9B", "expiryDate": "2028-03-21", "productId": 211 },
    { "quantity": 650, "unitValue": 2.10, "batch": "LOTC0D1E2F", "expiryDate": "2029-10-01", "productId": 215 },
    { "quantity": 1000, "unitValue": 3.45, "batch": "LOTG3H4I5J", "expiryDate": "2030-04-29", "productId": 190 }
  ]
}

{
  "invoiceNumber": "246802",
  "supplyAuthorization": "AF 2024/009009",
  "observation": "",
  "receivingDate": "2024-10-21T08:42:12.000Z",
  "supplierId": 60,
  "responsibleId": 6,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1000, "unitValue": 2.20, "batch": "LOTH3I4J5K6", "expiryDate": "2027-08-01", "productId": 8 },
    { "quantity": 1500, "unitValue": 1.65, "batch": "LOTL7M8N9O0", "expiryDate": "2028-09-09", "productId": 15 },
    { "quantity": 2200, "unitValue": 0.42, "batch": "LOTP1Q2R3S4", "expiryDate": "2029-07-27", "productId": 233 },
    { "quantity": 700, "unitValue": 3.50, "batch": "LOTT5U6V7W8", "expiryDate": "2026-01-20", "productId": 305 },
    { "quantity": 1900, "unitValue": 0.78, "batch": "LOTX9Y0Z1A2", "expiryDate": "2030-02-16", "productId": 11 },
    { "quantity": 1350, "unitValue": 1.15, "batch": "LOTB3C4D5E6", "expiryDate": "2028-04-24", "productId": 175 },
    { "quantity": 50, "unitValue": 25.00, "batch": "LOTF7G8H9I0", "expiryDate": "2029-10-01", "productId": 61 },
    { "quantity": 1100, "unitValue": 0.30, "batch": "LOTJ1K2L3M4", "expiryDate": "2027-05-13", "productId": 256 },
    { "quantity": 1800, "unitValue": 0.80, "batch": "LOTN5O6P7Q8", "expiryDate": "2028-02-29", "productId": 277 }
  ]
}

{
  "invoiceNumber": "127856",
  "supplyAuthorization": "AF 2024/001099",
  "observation": "",
  "receivingDate": "2024-11-25T14:42:01.000Z",
  "supplierId": 4,
  "responsibleId": 1,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 2500, "unitValue": 0.15, "batch": "LOTP0G9Y5Q8", "expiryDate": "2028-04-18", "productId": 72 },
    { "quantity": 1000, "unitValue": 1.90, "batch": "LOT5S4H2D0F", "expiryDate": "2026-11-09", "productId": 210 },
    { "quantity": 750, "unitValue": 3.20, "batch": "LOTA3K6U9N1", "expiryDate": "2027-08-22", "productId": 140 },
    { "quantity": 200, "unitValue": 7.50, "batch": "LOTR8M7J0C5", "expiryDate": "2029-05-05", "productId": 63 },
    { "quantity": 1800, "unitValue": 0.40, "batch": "LOTB6V1W4Z9", "expiryDate": "2030-07-01", "productId": 331 },
    { "quantity": 900, "unitValue": 1.15, "batch": "LOT4E2T0L3X", "expiryDate": "2027-02-14", "productId": 19 }
  ]
}

{
  "invoiceNumber": "820356",
  "supplyAuthorization": "AF 2025/109876",
  "observation": "",
  "receivingDate": "2025-01-06T12:03:51.000Z",
  "supplierId": 57,
  "responsibleId": 2,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 50, "unitValue": 40.00, "batch": "LOTY1Z2A3B", "expiryDate": "2028-09-01", "productId": 8 },
    { "quantity": 300, "unitValue": 7.50, "batch": "LOTC4D5E6F", "expiryDate": "2026-02-14", "productId": 119 },
    { "quantity": 1000, "unitValue": 1.15, "batch": "LOTG7H8J9K", "expiryDate": "2029-05-05", "productId": 290 },
    { "quantity": 1500, "unitValue": 0.65, "batch": "LOTL0M1N2P", "expiryDate": "2030-12-31", "productId": 15 },
    { "quantity": 400, "unitValue": 5.80, "batch": "LOTQ3R4S5T", "expiryDate": "2027-04-04", "productId": 10 },
    { "quantity": 800, "unitValue": 2.50, "batch": "LOTU6V7W8X", "expiryDate": "2028-11-09", "productId": 165 },
    { "quantity": 250, "unitValue": 10.99, "batch": "LOTY9Z0A1B", "expiryDate": "2026-06-06", "productId": 55 },
    { "quantity": 1200, "unitValue": 0.92, "batch": "LOTC2D3E4F", "expiryDate": "2029-07-20", "productId": 280 },
    { "quantity": 100, "unitValue": 19.40, "batch": "LOTG5H6J7K", "expiryDate": "2027-10-10", "productId": 15 },
    { "quantity": 2000, "unitValue": 0.30, "batch": "LOTL8M9N0P", "expiryDate": "2030-03-15", "productId": 325 },
    { "quantity": 600, "unitValue": 4.75, "batch": "LOTQ1R2S3T", "expiryDate": "2028-01-25", "productId": 136 },
    { "quantity": 1800, "unitValue": 0.40, "batch": "LOTU4V5W6X", "expiryDate": "2029-10-01", "productId": 252 },
    { "quantity": 100, "unitValue": 16.00, "batch": "LOTY7Z8A9B", "expiryDate": "2027-01-20", "productId": 20 },
    { "quantity": 500, "unitValue": 5.50, "batch": "LOTC0D1E2F", "expiryDate": "2028-04-20", "productId": 95 },
    { "quantity": 700, "unitValue": 2.00, "batch": "LOTG3H4J5K", "expiryDate": "2026-12-05", "productId": 17 }
  ]
}

{
  "invoiceNumber": "555111",
  "supplyAuthorization": "AF 2025/008080",
  "observation": "",
  "receivingDate": "2025-01-15T10:53:26.000Z",
  "supplierId": 7,
  "responsibleId": 4,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1400, "unitValue": 0.99, "batch": "LOT6F82C4D7", "expiryDate": "2027-09-05", "productId": 331 },
    { "quantity": 1700, "unitValue": 0.55, "batch": "LOT7093D5E8", "expiryDate": "2028-02-29", "productId": 332 },
    { "quantity": 1200, "unitValue": 1.30, "batch": "LOT81A4E6F9", "expiryDate": "2029-01-01", "productId": 333 }
  ]
}

{
  "invoiceNumber": "720054",
  "supplyAuthorization": "AF 2025/006020",
  "observation": "",
  "receivingDate": "2025-02-10T15:46:38.000Z",
  "supplierId": 18,
  "responsibleId": 9,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1500, "unitValue": 1.10, "batch": "LOT1C3E5A7B", "expiryDate": "2027-02-02", "productId": 55 },
    { "quantity": 1900, "unitValue": 0.22, "batch": "LOT2D4F6B8A", "expiryDate": "2028-03-18", "productId": 66 },
    { "quantity": 1450, "unitValue": 1.55, "batch": "LOT3E5A7B9C", "expiryDate": "2029-04-20", "productId": 77 },
    { "quantity": 1650, "unitValue": 0.88, "batch": "LOT4F6B8C0D", "expiryDate": "2026-09-29", "productId": 88 },
    { "quantity": 1250, "unitValue": 0.35, "batch": "LOT5A7B9C1E", "expiryDate": "2030-11-25", "productId": 99 },
    { "quantity": 1800, "unitValue": 1.00, "batch": "LOT6B8C0D2F", "expiryDate": "2027-06-01", "productId": 110 }
  ]
}

{
  "invoiceNumber": "940516",
  "supplyAuthorization": "AF 2025/803472",
  "observation": "Itens frágeis, armazenar com cuidado.",
  "receivingDate": "2025-02-14T13:14:15.000Z",
  "supplierId": 60,
  "responsibleId": 10,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 100, "unitValue": 25.00, "batch": "LOTX5Y6Z7A", "expiryDate": "2028-01-28", "productId": 150 },
    { "quantity": 50, "unitValue": 35.50, "batch": "LOTB8C9D0E", "expiryDate": "2029-06-11", "productId": 280 },
    { "quantity": 250, "unitValue": 18.20, "batch": "LOTF1G2H3I", "expiryDate": "2027-08-03", "productId": 10 },
    { "quantity": 300, "unitValue": 11.99, "batch": "LOTJ4K5L6M", "expiryDate": "2030-05-20", "productId": 315 },
    { "quantity": 150, "unitValue": 40.00, "batch": "LOTN7P8Q9R", "expiryDate": "2026-10-15", "productId": 42 },
    { "quantity": 400, "unitValue": 7.50, "batch": "LOTS0T1U2V", "expiryDate": "2028-04-04", "productId": 222 },
    { "quantity": 500, "unitValue": 5.90, "batch": "LOTW3X4Y5Z", "expiryDate": "2029-03-27", "productId": 111 },
    { "quantity": 200, "unitValue": 9.99, "batch": "LOTA6B7C8D", "expiryDate": "2027-12-01", "productId": 55 },
    { "quantity": 1000, "unitValue": 1.25, "batch": "LOTE9F0G1H", "expiryDate": "2028-07-10", "productId": 240 }
  ]
}

{
  "invoiceNumber": "748120",
  "supplyAuthorization": "AF 2025/004455",
  "observation": "Entrega de emergência.",
  "receivingDate": "2025-02-18T15:12:35.000Z",
  "supplierId": 3,
  "responsibleId": 7,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 10, "unitValue": 50.00, "batch": "LOTZ0X9W8V7", "expiryDate": "2029-03-09", "productId": 336 },
    { "quantity": 25, "unitValue": 45.00, "batch": "LOTG5A6B7C8", "expiryDate": "2027-12-24", "productId": 1 },
    { "quantity": 40, "unitValue": 38.00, "batch": "LOTE2D3F4G5", "expiryDate": "2026-06-16", "productId": 300 }
  ]
}

{
  "invoiceNumber": "601579",
  "supplyAuthorization": "AF 2025/003152",
  "observation": "",
  "receivingDate": "2025-04-14T11:45:20.000Z",
  "supplierId": 25,
  "responsibleId": 5,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 800, "unitValue": 0.50, "batch": "LOTM7R9P1Q3", "expiryDate": "2027-03-05", "productId": 322 },
    { "quantity": 900, "unitValue": 0.55, "batch": "LOTK6J8H0G2", "expiryDate": "2028-02-17", "productId": 10 },
    { "quantity": 1000, "unitValue": 0.60, "batch": "LOTI5L7N9K1", "expiryDate": "2029-01-02", "productId": 44 },
    { "quantity": 1100, "unitValue": 0.65, "batch": "LOTG4F6E8D0", "expiryDate": "2026-12-19", "productId": 170 },
    { "quantity": 1200, "unitValue": 0.70, "batch": "LOTE3D5C7B9", "expiryDate": "2030-03-28", "productId": 222 },
    { "quantity": 1300, "unitValue": 0.75, "batch": "LOTC2B4A6Z8", "expiryDate": "2027-10-14", "productId": 290 },
    { "quantity": 1400, "unitValue": 0.80, "batch": "LOTY1Z3X5W7", "expiryDate": "2028-11-06", "productId": 60 },
    { "quantity": 1500, "unitValue": 0.85, "batch": "LOTW0V2U4T6", "expiryDate": "2029-12-01", "productId": 333 },
    { "quantity": 1600, "unitValue": 0.90, "batch": "LOTS9R1Q3P5", "expiryDate": "2026-05-18", "productId": 88 },
    { "quantity": 1700, "unitValue": 0.95, "batch": "LOTQ8P0N2M4", "expiryDate": "2028-07-25", "productId": 161 },
    { "quantity": 1800, "unitValue": 1.00, "batch": "LOTO7L9K1J3", "expiryDate": "2027-04-09", "productId": 249 },
    { "quantity": 1900, "unitValue": 1.05, "batch": "LOTM6N8P0Q2", "expiryDate": "2030-01-13", "productId": 305 },
    { "quantity": 2000, "unitValue": 1.10, "batch": "LOTL5K7J9H1", "expiryDate": "2028-10-30", "productId": 99 },
    { "quantity": 2100, "unitValue": 1.15, "batch": "LOTJ4I6G8F0", "expiryDate": "2029-06-22", "productId": 255 },
    { "quantity": 2200, "unitValue": 1.20, "batch": "LOTI3H5G7F9", "expiryDate": "2026-08-08", "productId": 280 }
  ]
}

{
  "invoiceNumber": "934567",
  "supplyAuthorization": "AF 2025/006811",
  "observation": "",
  "receivingDate": "2025-05-23T15:27:28.000Z",
  "supplierId": 57,
  "responsibleId": 9,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 300, "unitValue": 10.00, "batch": "LOTC8Z0Y2X4", "expiryDate": "2027-02-05", "productId": 11 },
    { "quantity": 250, "unitValue": 11.50, "batch": "LOTA7B9C1D3", "expiryDate": "2029-05-19", "productId": 122 },
    { "quantity": 200, "unitValue": 13.00, "batch": "LOTZ6Y8X0W2", "expiryDate": "2028-03-01", "productId": 210 },
    { "quantity": 150, "unitValue": 14.50, "batch": "LOTY5X7W9V1", "expiryDate": "2026-10-26", "productId": 304 },
    { "quantity": 100, "unitValue": 16.00, "batch": "LOTW4V6U8T0", "expiryDate": "2030-08-01", "productId": 48 }
  ]
}

{
  "invoiceNumber": "850117",
  "supplyAuthorization": "AF 2025/003301",
  "observation": "",
  "receivingDate": "2025-06-26T14:45:35.000Z",
  "supplierId": 43,
  -- Limpeza
  "responsibleId": 6,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 200, "unitValue": 40.70, "batch": "LOT9E52C9F8", "expiryDate": "2029-01-25", "productId": 183 },
    { "quantity": 150, "unitValue": 15.40, "batch": "LOTF6B0D5A3", "expiryDate": "2028-07-17", "productId": 192 },
    { "quantity": 150, "unitValue": 14.50, "batch": "LOT1A8C7F0E", "expiryDate": "2027-03-05", "productId": 106 },
    { "quantity": 10, "unitValue": 114.50, "batch": "LOT8D7E3B21", "expiryDate": "2030-10-02", "productId": 207 },
    { "quantity": 250, "unitValue": 12.90, "batch": "LOT5C4A9D66", "expiryDate": "2026-11-14", "productId": 196 }
  ]
}

{
  "invoiceNumber": "193847",
  "supplyAuthorization": "AF 2025/076041",
  "observation": "",
  "receivingDate": "2025-07-01T08:18:28.000Z",
  "supplierId": 33,
  "responsibleId": 8,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 2000, "unitValue": 0.35, "batch": "LOTJ9K0L1M", "expiryDate": "2027-06-12", "productId": 77 },
    { "quantity": 1800, "unitValue": 0.95, "batch": "LOTN2P3Q4R", "expiryDate": "2028-10-30", "productId": 142 },
    { "quantity": 1500, "unitValue": 0.40, "batch": "LOTS5T6U7V", "expiryDate": "2029-05-03", "productId": 299 },
    { "quantity": 1200, "unitValue": 1.15, "batch": "LOTW8X9Y0Z", "expiryDate": "2026-11-21", "productId": 65 },
    { "quantity": 1000, "unitValue": 2.20, "batch": "LOTA1B2C3D", "expiryDate": "2030-03-17", "productId": 222 },
    { "quantity": 800, "unitValue": 3.50, "batch": "LOTE4F5G6H", "expiryDate": "2027-01-08", "productId": 13 }
  ]
}

{
  "invoiceNumber": "987654",
  "supplyAuthorization": "AF 2025/003003",
  "observation": "",
  "receivingDate": "2025-08-02T11:05:11.000Z",
  "supplierId": 3,
  "responsibleId": 4,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1000, "unitValue": 2.50, "batch": "LOT5G4H3I2J", "expiryDate": "2029-06-03", "productId": 25 },
    { "quantity": 1800, "unitValue": 1.10, "batch": "LOTK1L0M9N8", "expiryDate": "2030-08-21", "productId": 77 },
    { "quantity": 500, "unitValue": 4.00, "batch": "LOTP7Q6R5S4", "expiryDate": "2027-03-09", "productId": 130 },
    { "quantity": 2500, "unitValue": 0.55, "batch": "LOTT3U2V1W0", "expiryDate": "2028-12-07", "productId": 298 },
    { "quantity": 750, "unitValue": 1.70, "batch": "LOTX9Y8Z7A6", "expiryDate": "2026-07-16", "productId": 328 },
    { "quantity": 1100, "unitValue": 0.85, "batch": "LOTB5C4D3E2", "expiryDate": "2029-10-10", "productId": 99 }
  ]
}

{
  "invoiceNumber": "456789",
  "supplyAuthorization": "AF 2025/002222",
  "observation": "",
  "receivingDate": "2025-08-20T14:57:18.000Z",
  "supplierId": 24,
  "responsibleId": 8,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1700, "unitValue": 0.80, "batch": "LOT709B3D5E", "expiryDate": "2028-05-17", "productId": 150 },
    { "quantity": 1300, "unitValue": 1.60, "batch": "LOT81A4E6F0", "expiryDate": "2029-02-09", "productId": 251 },
    { "quantity": 1900, "unitValue": 0.48, "batch": "LOT92B5F70A", "expiryDate": "2027-11-22", "productId": 152 },
    { "quantity": 1100, "unitValue": 1.35, "batch": "LOTA3C6081B", "expiryDate": "2030-08-08", "productId": 153 },
    { "quantity": 1550, "unitValue": 0.65, "batch": "LOTB4D7192C", "expiryDate": "2026-12-05", "productId": 154 },
    { "quantity": 1850, "unitValue": 2.00, "batch": "LOTC5E82A3D", "expiryDate": "2028-01-30", "productId": 255 },
    { "quantity": 1450, "unitValue": 0.90, "batch": "LOTD6F93B4E", "expiryDate": "2029-07-16", "productId": 156 },
    { "quantity": 1250, "unitValue": 0.52, "batch": "LOTE70A4C5F", "expiryDate": "2027-04-25", "productId": 157 },
    { "quantity": 1600, "unitValue": 1.11, "batch": "LOTF81B5D60", "expiryDate": "2030-05-10", "productId": 158 },
    { "quantity": 1750, "unitValue": 0.70, "batch": "LOT092C6E71", "expiryDate": "2028-03-28", "productId": 159 },
    { "quantity": 1350, "unitValue": 1.40, "batch": "LOT1A3D7F82", "expiryDate": "2029-11-03", "productId": 160 },
    { "quantity": 1950, "unitValue": 0.33, "batch": "LOT2B4E8093", "expiryDate": "2027-06-14", "productId": 161 },
    { "quantity": 1050, "unitValue": 1.80, "batch": "LOT3C5F91A4", "expiryDate": "2028-10-10", "productId": 162 },
    { "quantity": 1500, "unitValue": 0.77, "batch": "LOT4D60A2B5", "expiryDate": "2030-04-01", "productId": 163 },
    { "quantity": 1150, "unitValue": 2.15, "batch": "LOT5E71B3C6", "expiryDate": "2026-11-20", "productId": 164 }
  ]
}

{
  "invoiceNumber": "209531",
  "supplyAuthorization": "AF 2025/213456",
  "observation": "Reabastecimento urgente de estoque.",
  "receivingDate": "2025-09-04T09:54:56.000Z",
  "supplierId": 49,
  "responsibleId": 8,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 200, "unitValue": 9.50, "batch": "LOTQ5R6S7T", "expiryDate": "2026-12-12", "productId": 2 },
    { "quantity": 1100, "unitValue": 1.35, "batch": "LOTU8V9W0X", "expiryDate": "2028-03-29", "productId": 160 },
    { "quantity": 1900, "unitValue": 0.70, "batch": "LOTY1Z2A3B", "expiryDate": "2030-05-01", "productId": 233 },
    { "quantity": 600, "unitValue": 4.10, "batch": "LOTC4D5E6F", "expiryDate": "2027-08-15", "productId": 80 },
    { "quantity": 180, "unitValue": 11.20, "batch": "LOTG7H8J9K", "expiryDate": "2029-01-28", "productId": 40 },
    { "quantity": 1400, "unitValue": 0.50, "batch": "LOTL0M1N2P", "expiryDate": "2028-12-06", "productId": 321 },
    { "quantity": 750, "unitValue": 3.80, "batch": "LOTQ3R4S5T", "expiryDate": "2026-04-10", "productId": 115 },
    { "quantity": 2500, "unitValue": 0.15, "batch": "LOTU6V7W8X", "expiryDate": "2029-10-25", "productId": 250 },
    { "quantity": 50, "unitValue": 25.00, "batch": "LOTY9Z0A1B", "expiryDate": "2027-07-07", "productId": 28 }
  ]
}

{
  "invoiceNumber": "603810",
  "supplyAuthorization": "AF 2025/007123",
  "observation": "",
  "receivingDate": "2025-09-17T13:26:39.000Z",
  "supplierId": 25,
  "responsibleId": 8,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1100, "unitValue": 0.50, "batch": "LOT5F0A7B2D", "expiryDate": "2026-03-01", "productId": 101 },
    { "quantity": 1800, "unitValue": 1.55, "batch": "LOTC3E75369", "expiryDate": "2029-02-28", "productId": 102 },
    { "quantity": 1400, "unitValue": 0.77, "batch": "LOT97F4DBD4", "expiryDate": "2027-07-20", "productId": 303 },
    { "quantity": 1600, "unitValue": 1.10, "batch": "LOT3ACEE600", "expiryDate": "2028-01-15", "productId": 404 },
    { "quantity": 1250, "unitValue": 0.99, "batch": "LOTE5DB7141", "expiryDate": "2030-06-19", "productId": 505 },
    { "quantity": 1950, "unitValue": 0.45, "batch": "LOT1AEDEE4C", "expiryDate": "2027-04-12", "productId": 606 },
    { "quantity": 1500, "unitValue": 2.00, "batch": "LOTAF29CD64", "expiryDate": "2029-10-31", "productId": 707 },
    { "quantity": 1700, "unitValue": 0.30, "batch": "LOT994D4FE3", "expiryDate": "2028-05-05", "productId": 808 },
    { "quantity": 1350, "unitValue": 1.25, "batch": "LOT7A330134", "expiryDate": "2026-12-24", "productId": 909 },
    { "quantity": 1850, "unitValue": 0.85, "batch": "LOTA6652657", "expiryDate": "2030-03-03", "productId": 112 },
    { "quantity": 1050, "unitValue": 0.60, "batch": "LOTB1A3C5E7", "expiryDate": "2027-08-08", "productId": 224 },
    { "quantity": 1650, "unitValue": 1.45, "batch": "LOTD9F1B3E5", "expiryDate": "2029-09-09", "productId": 336 }
  ]
}

{
  "invoiceNumber": "881230",
  "supplyAuthorization": "AF 2025/001007",
  "observation": "",
  "receivingDate": "2025-10-25T10:48:57.000Z",
  "supplierId": 60,
  "responsibleId": 6,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1400, "unitValue": 0.68, "batch": "LOT7C9D1E3A", "expiryDate": "2028-09-01", "productId": 1 },
    { "quantity": 1750, "unitValue": 1.25, "batch": "LOT8D0E2F4B", "expiryDate": "2027-01-19", "productId": 2 },
    { "quantity": 1150, "unitValue": 0.98, "batch": "LOT9E1F3A5C", "expiryDate": "2029-05-13", "productId": 3 },
    { "quantity": 1950, "unitValue": 0.40, "batch": "LOT0F2A4B6D", "expiryDate": "2026-07-27", "productId": 4 },
    { "quantity": 1350, "unitValue": 1.15, "batch": "LOT1A3C5E7F", "expiryDate": "2030-01-20", "productId": 5 },
    { "quantity": 1600, "unitValue": 0.75, "batch": "LOT2B4D6F80", "expiryDate": "2028-12-15", "productId": 6 },
    { "quantity": 1050, "unitValue": 2.30, "batch": "LOT3C5E7F91", "expiryDate": "2027-03-09", "productId": 7 },
    { "quantity": 1800, "unitValue": 0.30, "batch": "LOT4D6F80A2", "expiryDate": "2029-10-05", "productId": 8 },
    { "quantity": 1500, "unitValue": 1.70, "batch": "LOT5E7F91B3", "expiryDate": "2028-06-21", "productId": 9 },
    { "quantity": 1200, "unitValue": 0.55, "batch": "LOT6F80A2C4", "expiryDate": "2026-04-03", "productId": 10 }
  ]
}

{
  "invoiceNumber": "301548",
  "supplyAuthorization": "AF 2025/000210",
  "observation": "Urgente",
  "receivingDate": "2025-11-04T08:26:17.000Z",
  "supplierId": 63,
  -- Escritório
  "responsibleId": 10,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 300, "unitValue": 27.80, "batch": "LOT1A7B3E9C", "expiryDate": "2027-02-19", "productId": 198 },
    { "quantity": 450, "unitValue": 2.95, "batch": "LOTZ9A0B1C", "expiryDate": "2027-09-28", "productId": 294 },
    { "quantity": 850, "unitValue": 0.75, "batch": "LOTF8D2C0A4", "expiryDate": "2029-11-30", "productId": 212 },
    { "quantity": 750, "unitValue": 4.50, "batch": "LOT3E5B7C9D", "expiryDate": "2028-08-03", "productId": 217 },
    { "quantity": 650, "unitValue": 2.00, "batch": "LOTC0D1E2F", "expiryDate": "2029-10-01", "productId": 215 },
    { "quantity": 850, "unitValue": 3.65, "batch": "LOTH3H8I5J", "expiryDate": "2030-04-29", "productId": 22 }
  ]
}

{
  "invoiceNumber": "900567",
  "supplyAuthorization": "AF 2025/005555",
  "observation": "",
  "receivingDate": "2025-11-05T11:22:33.000Z",
  "supplierId": 14,
  "responsibleId": 10,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1550, "unitValue": 0.95, "batch": "LOTD8A1B5F3", "expiryDate": "2027-01-08", "productId": 21 },
    { "quantity": 1700, "unitValue": 0.75, "batch": "LOTC7E3A9D1", "expiryDate": "2028-10-30", "productId": 333 },
    { "quantity": 1200, "unitValue": 2.50, "batch": "LOTB5F1D7C9", "expiryDate": "2029-03-24", "productId": 160 },
    { "quantity": 1850, "unitValue": 0.50, "batch": "LOT3A9D1C5E", "expiryDate": "2026-05-18", "productId": 44 },
    { "quantity": 1450, "unitValue": 1.10, "batch": "LOTF7C9B1D5", "expiryDate": "2030-04-04", "productId": 299 },
    { "quantity": 1650, "unitValue": 0.35, "batch": "LOT0E2A4F6B", "expiryDate": "2027-12-12", "productId": 111 },
    { "quantity": 1350, "unitValue": 1.40, "batch": "LOT9D1C5E7A", "expiryDate": "2028-02-06", "productId": 88 },
    { "quantity": 1900, "unitValue": 0.65, "batch": "LOT6A8C0E2D", "expiryDate": "2029-08-01", "productId": 133 }
  ]
}

{
  "invoiceNumber": "456789",
  "supplyAuthorization": "AF 2025/005005",
  "observation": "",
  "receivingDate": "2025-11-07T15:52:26.000Z",
  "supplierId": 79,
  "responsibleId": 10,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 50, "unitValue": 30.00, "batch": "LOTH9I0J1K2", "expiryDate": "2029-03-28", "productId": 12 },
    { "quantity": 2500, "unitValue": 0.10, "batch": "LOTL3M4N5O6", "expiryDate": "2027-07-22", "productId": 335 },
    { "quantity": 180, "unitValue": 8.50, "batch": "LOTP7Q8R9S0", "expiryDate": "2028-10-31", "productId": 100 },
    { "quantity": 1250, "unitValue": 1.90, "batch": "LOTT1U2V3W4", "expiryDate": "2026-12-01", "productId": 20 }
  ]
}

{
  "invoiceNumber": "713402",
  "supplyAuthorization": "AF 2025/554321",
  "observation": "",
  "receivingDate": "2025-11-18T10:42:32.000Z",
  "supplierId": 39,
  "responsibleId": 9,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 1750, "unitValue": 0.60, "batch": "LOTK1L2M3N", "expiryDate": "2028-04-14", "productId": 228 },
    { "quantity": 1640, "unitValue": 0.45, "batch": "LOTP4Q5R6S", "expiryDate": "2028-08-01", "productId": 92 },
    { "quantity": 1350, "unitValue": 1.25, "batch": "LOTT7U8V9W", "expiryDate": "2027-11-07", "productId": 32 }
  ]
}

{
  "invoiceNumber": "555111",
  "supplyAuthorization": "AF 2025/003456",
  "observation": "",
  "receivingDate": "2025-12-10T09:45:41.000Z",
  "supplierId": 24,
  "responsibleId": 7,
  "accountId": 6,
  "receivedItems": [
    { "quantity": 300, "unitValue": 2.15, "batch": "LOTC1B9A7D5", "expiryDate": "2026-02-09", "productId": 277 },
    { "quantity": 190, "unitValue": 6.80, "batch": "LOTF8D6C4B2", "expiryDate": "2029-07-28", "productId": 140 },
    { "quantity": 5000, "unitValue": 0.08, "batch": "LOT3A5C7E9B", "expiryDate": "2027-10-10", "productId": 88 },
    { "quantity": 110, "unitValue": 9.20, "batch": "LOTD0B2F4E6", "expiryDate": "2028-06-03", "productId": 311 },
    { "quantity": 700, "unitValue": 1.50, "batch": "LOT7C9A1D3F", "expiryDate": "2030-03-21", "productId": 29 },
    { "quantity": 1200, "unitValue": 0.55, "batch": "LOT8E6D4F2C", "expiryDate": "2029-04-16", "productId": 175 },
    { "quantity": 900, "unitValue": 1.05, "batch": "LOT1A3B5C7D", "expiryDate": "2027-07-19", "productId": 99 },
    { "quantity": 100, "unitValue": 3.70, "batch": "LOT5E7C9A1B", "expiryDate": "2028-11-29", "productId": 333 }
  ]
}

-- ----------------------------------------------------------------------------------------------------------------------------------
-- /api/account/login
-- "accountId": 7,
{
  "userName": "cdm_user2",
  "password": "A2H@user"
}

-- /api/receiving/create
{
  "invoiceNumber": "193847",
  "supplyAuthorization": "AF 2024/007000",
  "observation": "Conferido e OK",
  "receivingDate": "2024-02-16T15:05:53.000Z",
  "supplierId": 67,
  "responsibleId": 8,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 10000, "unitValue": 0.05, "batch": "LOT1234ABCD", "expiryDate": "2029-01-01", "productId": 3 },
    { "quantity": 50, "unitValue": 12.50, "batch": "LOT5678EFGH", "expiryDate": "2027-08-08", "productId": 312 },
    { "quantity": 750, "unitValue": 1.75, "batch": "LOT9012IJKL", "expiryDate": "2028-04-24", "productId": 50 },
    { "quantity": 180, "unitValue": 3.40, "batch": "LOT3456MNOP", "expiryDate": "2030-06-15", "productId": 290 },
    { "quantity": 1100, "unitValue": 0.90, "batch": "LOT7890QRST", "expiryDate": "2026-11-05", "productId": 19 },
    { "quantity": 15, "unitValue": 25.00, "batch": "LOTUVWXYZA", "expiryDate": "2028-12-31", "productId": 300 }
  ]
}

{
  "invoiceNumber": "214365",
  "supplyAuthorization": "AF 2024/000042",
  "observation": "Amostras",
  "receivingDate": "2024-07-26T10:23:31.000Z",
  "supplierId": 18,
  "responsibleId": 9,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 5, "unitValue": 25.00, "batch": "LOTF1A2B3C4", "expiryDate": "2029-03-01", "productId": 133 },
    { "quantity": 10, "unitValue": 15.00, "batch": "LOTD5E6F7G8", "expiryDate": "2028-10-20", "productId": 15 },
    { "quantity": 3, "unitValue": 75.00, "batch": "LOTC9H0I1J2", "expiryDate": "2026-04-14", "productId": 2 }
  ]
}

{
  "invoiceNumber": "782345",
  "supplyAuthorization": "AF 2024/002981",
  "observation": "",
  "receivingDate": "2024-07-30T14:41:32.000Z",
  "supplierId": 25,
  "responsibleId": 1,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 2500, "unitValue": 0.15, "batch": "LOT1A2B3C4D", "expiryDate": "2027-03-10", "productId": 76 },
    { "quantity": 100, "unitValue": 15.75, "batch": "LOT5E6F7G8H", "expiryDate": "2029-10-28", "productId": 329 },
    { "quantity": 900, "unitValue": 2.40, "batch": "LOT9I0J1K2L", "expiryDate": "2028-06-18", "productId": 45 },
    { "quantity": 1100, "unitValue": 0.90, "batch": "LOT3M4N5O6P", "expiryDate": "2026-02-05", "productId": 274 },
    { "quantity": 60, "unitValue": 50.00, "batch": "LOT7Q8R9S0T", "expiryDate": "2030-12-01", "productId": 21 },
    { "quantity": 1800, "unitValue": 0.60, "batch": "LOTU1V2W3X4", "expiryDate": "2027-07-04", "productId": 175 },
    { "quantity": 450, "unitValue": 3.10, "batch": "LOTY5Z6A7B8", "expiryDate": "2029-05-19", "productId": 98 }
  ]
}

{
  "invoiceNumber": "612345",
  "supplyAuthorization": "AF 2024/005500",
  "observation": "Entrega antecipada",
  "receivingDate": "2024-09-19T13:16:48.000Z",
  "supplierId": 49,
  "responsibleId": 8,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 4000, "unitValue": 0.08, "batch": "LOTF8G9H0I1", "expiryDate": "2030-01-25", "productId": 2 },
    { "quantity": 50, "unitValue": 10.50, "batch": "LOTJ2K3L4M5", "expiryDate": "2027-06-06", "productId": 180 },
    { "quantity": 1500, "unitValue": 0.95, "batch": "LOTN6O7P8Q9", "expiryDate": "2028-10-15", "productId": 240 },
    { "quantity": 200, "unitValue": 3.70, "batch": "LOTR0S1T2U3", "expiryDate": "2026-03-08", "productId": 32 }
  ]
}

{
  "invoiceNumber": "005391",
  "supplyAuthorization": "AF 2024/000214",
  "observation": "",
  "receivingDate": "2024-11-05T11:20:58.000Z",
  "supplierId": 49,
  "responsibleId": 4,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 3000, "unitValue": 0.05, "batch": "LOT8L3K7F5G", "expiryDate": "2030-05-01", "productId": 329 },
    { "quantity": 2800, "unitValue": 0.10, "batch": "LOTE9C2V4X1", "expiryDate": "2029-01-08", "productId": 285 },
    { "quantity": 2500, "unitValue": 0.12, "batch": "LOT7Y0Z6S3D", "expiryDate": "2028-07-29", "productId": 301 },
    { "quantity": 2200, "unitValue": 0.18, "batch": "LOTF1A5B8N6", "expiryDate": "2027-04-12", "productId": 111 },
    { "quantity": 2100, "unitValue": 0.23, "batch": "LOTV3M4R0C9", "expiryDate": "2026-10-03", "productId": 177 },
    { "quantity": 1900, "unitValue": 0.35, "batch": "LOT6H9J1P5T", "expiryDate": "2028-03-17", "productId": 250 },
    { "quantity": 1700, "unitValue": 0.45, "batch": "LOTI8O2K7L4", "expiryDate": "2029-08-21", "productId": 9 }
  ]
}

{
  "invoiceNumber": "391745",
  "supplyAuthorization": "AF 2025/008005",
  "observation": "Itens frágeis, armazenar com cuidado.",
  "receivingDate": "2025-01-27T10:41:14.000Z",
  "supplierId": 1,
  "responsibleId": 2,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 10, "unitValue": 100.00, "batch": "LOTU9V1W3X5", "expiryDate": "2029-02-01", "productId": 29 },
    { "quantity": 15, "unitValue": 95.00, "batch": "LOTS7R5Q3P1", "expiryDate": "2028-08-05", "productId": 125 },
    { "quantity": 20, "unitValue": 90.00, "batch": "LOTK6J8H0G2", "expiryDate": "2027-01-27", "productId": 305 },
    { "quantity": 25, "unitValue": 85.00, "batch": "LOTE4D2C0B9", "expiryDate": "2030-06-14", "productId": 311 },
    { "quantity": 30, "unitValue": 80.00, "batch": "LOTC2A0Z8Y6", "expiryDate": "2026-11-29", "productId": 50 },
    { "quantity": 35, "unitValue": 75.00, "batch": "LOTN1M9L7K5", "expiryDate": "2028-04-20", "productId": 142 },
    { "quantity": 40, "unitValue": 70.00, "batch": "LOTH0G8F6E4", "expiryDate": "2027-09-03", "productId": 263 },
    { "quantity": 45, "unitValue": 65.00, "batch": "LOTZ7Y5X3W1", "expiryDate": "2029-11-12", "productId": 35 },
    { "quantity": 50, "unitValue": 60.00, "batch": "LOTB6A4Z2Y0", "expiryDate": "2026-04-25", "productId": 180 },
    { "quantity": 55, "unitValue": 55.00, "batch": "LOTD5C3B1A9", "expiryDate": "2028-01-15", "productId": 231 }
  ]
}

{
  "invoiceNumber": "881304",
  "supplyAuthorization": "AF 2025/802917",
  "observation": "",
  "receivingDate": "2025-01-27T14:35:57.000Z",
  "supplierId": 21,
  "responsibleId": 10,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 500, "unitValue": 5.40, "batch": "LOTW1X2Y3Z", "expiryDate": "2028-06-05", "productId": 329 },
    { "quantity": 1800, "unitValue": 0.77, "batch": "LOTM4N5O6P", "expiryDate": "2030-03-25", "productId": 45 },
    { "quantity": 950, "unitValue": 1.50, "batch": "LOTQ7R8S9T", "expiryDate": "2027-09-10", "productId": 301 },
    { "quantity": 3000, "unitValue": 0.22, "batch": "LOTC1D2E3F", "expiryDate": "2029-12-30", "productId": 11 }
  ]
}

{
  "invoiceNumber": "637840",
  "supplyAuthorization": "AF 2025/556789",
  "observation": "",
  "receivingDate": "2025-02-14T15:37:26.000Z",
  "supplierId": 22,
  "responsibleId": 7,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 400, "unitValue": 6.10, "batch": "LOTG1H2J3K", "expiryDate": "2029-03-07", "productId": 111 },
    { "quantity": 1500, "unitValue": 0.95, "batch": "LOTL4M5N6P", "expiryDate": "2026-10-31", "productId": 240 },
    { "quantity": 1250, "unitValue": 1.80, "batch": "LOTQ7R8S9T", "expiryDate": "2028-05-05", "productId": 305 },
    { "quantity": 800, "unitValue": 3.25, "batch": "LOTU0V1W2X", "expiryDate": "2027-02-09", "productId": 65 },
    { "quantity": 1700, "unitValue": 0.38, "batch": "LOTY3Z4A5B", "expiryDate": "2030-08-17", "productId": 277 },
    { "quantity": 500, "unitValue": 4.90, "batch": "LOTC6D7E8F", "expiryDate": "2029-11-04", "productId": 90 },
    { "quantity": 300, "unitValue": 7.50, "batch": "LOTG9H0J1K", "expiryDate": "2027-06-19", "productId": 140 },
    { "quantity": 2100, "unitValue": 0.29, "batch": "LOTL2M3N4P", "expiryDate": "2028-07-28", "productId": 312 }
  ]
}

{
  "invoiceNumber": "987123",
  "supplyAuthorization": "AF 2025/005678",
  "observation": "",
  "receivingDate": "2025-05-09T11:41:36.000Z",
  "supplierId": 3,
  "responsibleId": 5,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 2500, "unitValue": 0.20, "batch": "LOT67F8A1B2", "expiryDate": "2030-04-05", "productId": 150 },
    { "quantity": 1000, "unitValue": 2.40, "batch": "LOTD3E5C7A9", "expiryDate": "2026-07-10", "productId": 48 },
    { "quantity": 1800, "unitValue": 0.85, "batch": "LOT2B9A0C8D", "expiryDate": "2028-09-22", "productId": 301 },
    { "quantity": 600, "unitValue": 1.15, "batch": "LOT8E6D4F2C", "expiryDate": "2027-12-01", "productId": 65 },
    { "quantity": 150, "unitValue": 15.00, "batch": "LOT5A1D9E7F", "expiryDate": "2029-02-14", "productId": 12 }
  ]
}

{
  "invoiceNumber": "872361",
  "supplyAuthorization": "AF 2025/402810",
  "observation": "Verificar embalagem danificada em 2 itens.",
  "receivingDate": "2025-05-23T14:42:21.000Z",
  "supplierId": 79,
  "responsibleId": 6,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 1500, "unitValue": 0.88, "batch": "LOTZ3E75369", "expiryDate": "2027-03-29", "productId": 45 },
    { "quantity": 250, "unitValue": 15.50, "batch": "LOTF8D9A2C", "expiryDate": "2029-12-10", "productId": 210 },
    { "quantity": 100, "unitValue": 3.20, "batch": "LOTB2C5E7A", "expiryDate": "2028-07-25", "productId": 180 },
    { "quantity": 400, "unitValue": 2.10, "batch": "LOTG6A1D4E", "expiryDate": "2030-01-05", "productId": 305 },
    { "quantity": 750, "unitValue": 0.55, "batch": "LOT2H4B3C5", "expiryDate": "2026-09-18", "productId": 52 }
  ]
}

{
  "invoiceNumber": "321098",
  "supplyAuthorization": "AF 2025/674509",
  "observation": "",
  "receivingDate": "2025-07-29T13:15:30.000Z",
  "supplierId": 25,
  "responsibleId": 7,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 1500, "unitValue": 0.70, "batch": "LOTL8M9N0P", "expiryDate": "2027-10-09", "productId": 91 },
    { "quantity": 1600, "unitValue": 0.52, "batch": "LOTQ1R2S3T", "expiryDate": "2028-09-22", "productId": 181 },
    { "quantity": 1300, "unitValue": 1.10, "batch": "LOTU4V5W6X", "expiryDate": "2026-08-05", "productId": 33 },
    { "quantity": 1800, "unitValue": 0.28, "batch": "LOTY7Z8A9B", "expiryDate": "2029-07-28", "productId": 255 },
    { "quantity": 1700, "unitValue": 0.85, "batch": "LOTC0D1E2F", "expiryDate": "2028-03-01", "productId": 40 },
    { "quantity": 1400, "unitValue": 1.05, "batch": "LOTG3H4I5J", "expiryDate": "2028-12-19", "productId": 5 },
    { "quantity": 1900, "unitValue": 2.00, "batch": "LOTK6L7M8N", "expiryDate": "2027-04-11", "productId": 122 },
    { "quantity": 10, "unitValue": 19.99, "batch": "LOTP9Q0R1S", "expiryDate": "2030-01-04", "productId": 60 },
    { "quantity": 1800, "unitValue": 0.15, "batch": "LOTT2U3V4W", "expiryDate": "2029-09-08", "productId": 100 }
  ]
}

{
  "invoiceNumber": "268904",
  "supplyAuthorization": "AF 2025/700100",
  "observation": "Prioridade de armazenamento. Produtos de alto valor.",
  "receivingDate": "2025-09-05T15:41:17.000Z",
  "supplierId": 21,
  "responsibleId": 6,
  "accountId": 7,
  "receivedItems": [
    { "quantity": 5, "unitValue": 250.00, "batch": "LOTX0Y1Z2A", "expiryDate": "2029-11-20", "productId": 1 },
    { "quantity": 15, "unitValue": 150.00, "batch": "LOTB3C4D5E", "expiryDate": "2030-02-08", "productId": 336 },
    { "quantity": 30, "unitValue": 90.00, "batch": "LOTF6G7H8I", "expiryDate": "2026-04-25", "productId": 75 },
    { "quantity": 60, "unitValue": 55.00, "batch": "LOTJ9K0L1M", "expiryDate": "2027-07-19", "productId": 130 },
    { "quantity": 100, "unitValue": 30.00, "batch": "LOTN2P3Q4R", "expiryDate": "2028-05-09", "productId": 271 },
    { "quantity": 150, "unitValue": 20.00, "batch": "LOTS5T6U7V", "expiryDate": "2029-01-30", "productId": 80 },
    { "quantity": 200, "unitValue": 12.00, "batch": "LOTW8X9Y0Z", "expiryDate": "2027-10-17", "productId": 160 },
    { "quantity": 300, "unitValue": 8.00, "batch": "LOTA1B2C3D", "expiryDate": "2028-11-14", "productId": 15 },
    { "quantity": 400, "unitValue": 4.50, "batch": "LOTE4F5G6H", "expiryDate": "2029-08-21", "productId": 50 }
  ]
}

-- ==================================================================================================================================
