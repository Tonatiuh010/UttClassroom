## ASSETS
INSERT INTO ASSET 
	(ASSET_CODE, NAME, ATTR1, ATTR2, ATTR3, DESCRIPTION, CREATED_BY)  
VALUES 
	/*######################## Genero ##################################*/
	('MN-RST', 'Rosarito', 'MUNIC', NULL, NULL, 'Rosarito', 'ADMIN'),
    ('MN-TC', 'Tecate', 'MUNIC', NULL, NULL, 'Tecate', 'ADMIN'),
    ('MN-TJ', 'Tijuana', 'MUNIC', NULL, NULL, 'Tijuana', 'ADMIN'),
    ('MN-MZN', 'Mazatlán', 'MUNIC', NULL, NULL, 'Mazatlán', 'ADMIN'),
	/*######################## Genero ##################################*/
	('GN-F', 'Femenino', 'GENRE', NULL, NULL, 'Femenino', 'ADMIN'),
    ('GN-M', 'Masculino', 'GENRE', NULL, NULL, 'Masculino', 'ADMIN'),
    ('GN-OND', 'OTRO', 'GENRE', NULL, NULL, 'OTRO', 'ADMIN'),
    /*######################## ESTADO CIVIL #############################*/
    ('EC-CSD', 'Casado(a)', 'MARITAL', NULL, NULL, 'Casado(a)', 'ADMIN'),
    ('EC-DVR', 'Divorciado', 'MARITAL', NULL, NULL, 'Divorciado', 'ADMIN'),
    ('EC-SLT', 'Soltero(a)', 'MARITAL', NULL, NULL, 'Soltero(a)', 'ADMIN'),
    ('EC-UL', 'Unión Libre', 'MARITAL', NULL, NULL, 'Unión Libre', 'ADMIN'),
	/*######################## RAZON TRABAJA #############################*/
	('RT-AEF', 'Apoyar Económicamente a la Familia', 'WORK_REASON', NULL, NULL, 'Apoyar Económicamente a la Familia', 'ADMIN'),
    ('RT-ATF', 'Apoyar Totalmente a la Familia', 'WORK_REASON', NULL, NULL, 'Apoyar Totalmente a la Familia', 'ADMIN'),
    ('RT-SGI', 'Solventar Algunos Gastos Personales', 'WORK_REASON', NULL, NULL, 'Solventar Algunos Gastos Personales', 'ADMIN'),
    ('RT-ST', 'Sostenerme Totalmente', 'WORK_REASON', NULL, NULL, 'Sostenerme Totalmente', 'ADMIN'),
    /*######################## VIVE CON #############################*/
    ('VC-AP', 'Ambos Padres', 'LIVE_WITH', NULL, NULL, 'Sostenerme Totalmente', 'ADMIN'),
    ('VC-UP', 'Uno de los Padres', 'LIVE_WITH', NULL, NULL, 'Uno de los Padres', 'ADMIN'),
    ('VC-PRJ', 'Pareja', 'LIVE_WITH', NULL, NULL, 'PAREJA', 'ADMIN'),
    ('VC-SL', 'Solo(a)', 'LIVE_WITH', NULL, NULL, 'Solo(a)', 'ADMIN'),
    ('VC-OF', 'Otro Familiar', 'LIVE_WITH', NULL, NULL, 'Otro Familiar', 'ADMIN'),
    ('VC-AMG', 'Amigos', 'LIVE_WITH', NULL, NULL, 'Amigos', 'ADMIN'),
    /*######################## VIVIENDA #############################*/
    ('VD-PRP', 'Propia', 'DWELLING', NULL, NULL, 'Propia', 'ADMIN'),
    ('VD-RNT', 'Rentada', 'DWELLING', NULL, NULL, 'Rentada', 'ADMIN'),
    ('VD-PRS', 'Prestada', 'DWELLING', NULL, NULL, 'Prestada', 'ADMIN'),
    /*######################## TRANSPORTE #############################*/
    ('TR-PRP', 'Propio', 'TRANSPORT', NULL, NULL, 'Propio', 'ADMIN'),
    ('TR-PBL', 'Público', 'TRANSPORT', NULL, NULL, 'Público', 'ADMIN'),
    /*######################## Apoyo Economico #############################*/
    ('AE-PDR', 'Padre', 'ECONOMIC_SUPPORT', NULL, NULL, 'Padre', 'ADMIN'),
    ('AE-MDR', 'Madre', 'ECONOMIC_SUPPORT', NULL, NULL, 'Madre', 'ADMIN'),
    ('AE-HRM', 'Hermano(a)', 'ECONOMIC_SUPPORT', NULL, NULL, 'Hermano(a)', 'ADMIN'),
    ('AE-CYN', 'Cónyuge', 'ECONOMIC_SUPPORT', NULL, NULL, 'Cónyuge', 'ADMIN'),
    ('AE-OF', 'Otro Familiar', 'ECONOMIC_SUPPORT', NULL, NULL, 'Otro Familiar', 'ADMIN'),
    ('AE-YO', 'Yo', 'ECONOMIC_SUPPORT', NULL, NULL, 'Yo', 'ADMIN'),
    /*######################## SALARIO #############################*/
    ('IF-ME5', 'Menos de $5,000', 'SALARY', NULL, NULL, 'Menos de $5,000', 'ADMIN'),
    ('IF-510', '$5,000 A $10,000', 'SALARY', '5000', '10000', '$5,000 A $10,000', 'ADMIN'),
    ('IF-1015', '$10,000 A $15,000', 'SALARY', '10000', '15000', '$10,000 A $15,000', 'ADMIN'),
    ('IF-MA15', 'Más de $15,000', 'SALARY', '15000',  NULL, 'Más de $15,000', 'ADMIN'),
    /*############################ TIPO ESCUELA ###########################*/
    ('TB-PBL', 'Escuela Pública (Oficial de Gobierno)', 'SCHOOL_TYPE', NULL, NULL, 'Escuela Pública (Oficial de Gobierno)', 'ADMIN'),
    ('TB-PRV', 'Privada o Particular', 'SCHOOL_TYPE', NULL, NULL, 'Privada o Particular', 'ADMIN'),
    /*############################ CITY ###########################*/
    ('AGC', 'Aguascalientes', 'CITY', NULL, NULL, 'Aguascalientes', 'ADMIN'),
    ('BC', 'Baja California', 'CITY', NULL, NULL, 'Baja California', 'ADMIN'),
    ('SIN', 'Sinaloa', 'CITY', NULL, NULL, 'Sinaloa', 'ADMIN'),
	/*############################ Major Level ###########################*/
    ('ING', 'Ingenieria', 'MAJOR_LEVEL', NULL, NULL, 'Ingenieria', 'ADMIN'),
    ('TSU', 'Tecnico Superior Universitario', 'MAJOR_LEVEL', NULL, NULL, 'Tecnico Superior Universitario', 'ADMIN'),
    /*############################ Speciality ###########################*/
	('TIDGS', 'Desarrollo y Gestión de Software', 'MAJOR_SPECIALITY', NULL, NULL, 'Desarrollo y Gestión de Software', 'ADMIN'),
    /*############################ PERIOD ###########################*/
    ('202203', 'Period', 'PERIOD', '09/01/2022', '12/30/2022', 'Period', 'ADMIN')
;

## Location 
INSERT INTO LOCATION (COUNTRY_ID, CITY, CITY_ID, CREATED_BY) VALUES 
	(GET_ASSET('BC'), 'Tijuana',  GET_ASSET('MN-TJ'), 'ADMIN'),
    (GET_ASSET('BC'), 'Tecate',  GET_ASSET('MN-TC'), 'ADMIN'),    
	(GET_ASSET('BC'), 'Rosarito',  GET_ASSET('MN-RST'), 'ADMIN'),
    (GET_ASSET('SIN'), 'Mazatlán',  GET_ASSET('MN-MZN'), 'ADMIN')
;

## Address 
INSERT INTO ADDRESS ( STREET, NUMBER, NEIGHBORHOOD, LOCATION_ID, CREATED_BY ) VALUES 
	/*############################ Viviendas - Alumnos - Familiares ###########################*/
	('Arroyo Chico', '416', 'El Mirador', 1, 'ADMIN'),
    ('Chula Vista', '413', 'El Mirador', 1, 'ADMIN'),    
    ('Blvd. Bellas Artes', '19842', 'Otay', 1, 'ADMIN'),
    ('Priv. Salvia', '17', 'Delicias', 1, 'ADMIN'),
    /*############################ Escuelas ###########################*/
    ('Av. Alejandro Von Humboldt Sn', 'NA', 'Nueva Tijuana', 1, 'ADMIN'),
    ('Blvd. Fuentes', 'NA', 'Florido', 1, 'ADMIN'),
	/*############################ Empresas ###########################*/
    ('Calle Laguna Maynar', '1022033', 'CETYS', 1, 'ADMIN'),
    ('Calle Chihuahua', '340', 'El Volado', 1, 'ADMIN')
;

## SCHOLARLY
INSERT INTO SCHOLARLY (SCHOOL_NAME, SCH_TYPE_ID, ADDRESS_ID, CREATED_BY) VALUES
	('CBTIs 116', GET_ASSET('TB-PBL'), 5, 'ADMIN'),
    ('CECyTE Florido', GET_ASSET('TB-PBL'), 6, 'ADMIN')
;

## MAJOR 
INSERT INTO MAJOR (MAJOR_CODE, NAME, LEVEL_ID, CREATED_BY) VALUES 
	('INGTI', 'Ingeniería en Tecnologías de la Información', GET_ASSET('ING'), 'ADMIN'),
    ('TSUTI', 'Tecnico Superior Universitario en Tecnologías de la Información', GET_ASSET('TSU'), 'ADMIN')
;

## Group
INSERT INTO GROUP_CLASS (GROUP_CODE, GROUP_KEY, QUARTER, MAJOR_ID, FIELD_ID, PERIOD_ID, DESCRIPTION) VALUES
	('TI-IDGS-9A-202203', 'A', 9, 1, GET_ASSET('TIDGS'), GET_ASSET('202203'), '9-A Ingeniería en Tecnologías de la Información Área Desarrollo y Gestión de Software')
;
 
## Contact
INSERT INTO CONTACT (EMAIL1, EMAIL2, PHONE1, PHONE2, DESCRIPTION, CREATED_BY) VALUES 
	/*############################ Alumnos ###########################*/
	('l.tonatiuh010@gmail.com', NULL, '+526631226015', NULL, 'Contacto Tonatiuh Lopez - ALUMNO (0319125293)', 'ADMIN'),
	/*############################ Alumnos Familiares ###########################*/
    ('aleh.rod@hotmail.com', NULL, '+526641225889', NULL, 'Contacto Familiar - ALUMNO (0319125293)', 'ADMIN'),
    ('ana.ramirez@hotmail.com', NULL, '+526647889622', NULL, 'Contacto Familiar - ALUMNO (0319125293)', 'ADMIN'),
    /*############################ Empresas ###########################*/
    ('Exela.RH@exelaonline.com', NULL, '+018009055300', NULL, 'Contacto Empresa - Labor (1)', 'ADMIN'),
    ('foxconn.RH@foxconn.com', NULL, '+0170069963344', NULL, 'Contacto Empresa - Labor (2)', 'ADMIN')    
;
 
## Labor Student
INSERT INTO LABOR_STUDENT ( DEPARTMENT, BUSINESS, JOB, ADDRESS_ID, CONTACT_ID, IS_STUDY, CREATED_BY ) VALUES 
	('ISS', 'Foxconn BC S.A', 'SOFTWARE DEVELOPER', 7, 5, TRUE, 'ADMIN')
;

## Student
INSERT INTO STUDENT ( STUDENT_CODE, NAME, LAST_NAME, IMAGE, BIRTH, BIRTH_LOCATION, GENRE_ID, 
					  MARITAL_ID, CONTACT_ID, ADDRESS_ID, SCHOLARLY_ID, LABOR_ID, CREATED_BY ) VALUES
	(
		'0319125293', ## MATRICULA
		'KEVIN TONATIUH', ## NOMBRE 
		'LOPEZ RAMIREZ', ## APELLIDO
		NULL, ## IMAGEN (BYTES)
		STR_TO_DATE('12-01-2001', '%m-%d-%Y'), ## NACIMIENTO
		1, ## LUGAR DE NACIMIENTO
		GET_ASSET('GN-M'), ## GENERO
        GET_ASSET('EC-SLT'), ## ESTADO CIVIL
        1, ## CONTACTO
        1, ## DIRECCION
        2, ## ESTUDIOS
        1, ## TRABAJO
        'ADMIN' ## CREADO POR (DATOS DE AUDITORIA)
    )
;

## Contact Family
INSERT INTO CONTACT_FAMILY (NAME, KINSHIP, WORK, IS_EMERGENCY, CONTACT_ID, STUDENT_ID, CREATED_BY) VALUES
	('Alejandra Ramirez', 'Hermana', 'Sales Manager', TRUE, 2, 1, 'ADMIN'),
	('Ana Ramirez', 'Madre', 'Sastre', TRUE, 3, 1, 'ADMIN')
;

## Group Student
INSERT INTO GROUP_STUDENT ( GROUP_ID, STUDENT_ID, IS_CURSED, CREATED_BY ) VALUES 
	(1, 1, FALSE, 'ADMIN')
;

## Student History

INSERT INTO STUDENT_HISTORY (
	SCORE, 
    SCORE_DATE, 
    ATTR1, 
    ATTR2, 
    ATTR3, 
    ATTR4, 
    STUDENT_ID, 
    CREATED_BY
) VALUES 
/*########### LOPEZ RAMIREZ KEVIN TONATIUH ####################### */
(
	/* NIVEL INGLES */
	'A1', -- SCORE
    STR_TO_DATE('06-15-2020', '%m-%d-%Y'), -- SCORE DATE
    'TSU', -- ATTR1
    'ENGLISH', -- ATTR2
    NULL, -- ATTR3
    NULL, -- ATTR4
    1, -- STUDENT_ID,
    'ADMIN' -- CREATED BY        
),
(
	/* PROMEDIO DE BACHILLERATO */
	'8.6', -- SCORE
    STR_TO_DATE('08-08-2019', '%m-%d-%Y'), -- SCORE DATE
    'TSU', -- ATTR1
    'SCHOLARLY', -- ATTR2
    NULL, -- ATTR3
    NULL, -- ATTR4
    1, -- STUDENT_ID,
    'ADMIN' -- CREATED BY        
),
(
	/* PUNTOS EXAMEN DE INGRESO */
	'872', -- SCORE
    STR_TO_DATE('05-15-2020', '%m-%d-%Y'), -- SCORE DATE
    'TSU', -- ATTR1
    'EXAM_ENTRY', -- ATTR2
    NULL, -- ATTR3
    NULL, -- ATTR4
    1, -- STUDENT_ID,
    'ADMIN' -- CREATED BY        
),
(
	/* QUATRIMESTRE 1 */
	'9.2', -- SCORE
    STR_TO_DATE('05-15-2020', '%m-%d-%Y'), -- SCORE DATE
    'TSU', -- ATTR1
    'QUARTER', -- ATTR2
    '1', -- ATTR3 
    NULL, -- ATTR4 (INICIO DE PERIODO)
    1, -- STUDENT_ID,
    'ADMIN' -- CREATED BY        
),
(
	/* QUATRIMESTRE 2 */
	'9.4', -- SCORE
    STR_TO_DATE('05-15-2020', '%m-%d-%Y'), -- SCORE DATE
    'TSU', -- ATTR1
    'QUARTER', -- ATTR2
    '2', -- ATTR3 
    NULL, -- ATTR4 (INICIO DE PERIODO)
    1, -- STUDENT_ID,
    'ADMIN' -- CREATED BY        
),
(
	/* QUATRIMESTRE 3 */
	'9.0', -- SCORE
    STR_TO_DATE('05-15-2020', '%m-%d-%Y'), -- SCORE DATE
    'TSU', -- ATTR1
    'QUARTER', -- ATTR2
    '3', -- ATTR3
    NULL, -- ATTR4 (INICIO DE PERIODO)
    1, -- STUDENT_ID
    'ADMIN' -- CREATED BY        
),
(
	/* QUATRIMESTRE 4 */
	'8.5', -- SCORE
    STR_TO_DATE('05-15-2020', '%m-%d-%Y'), -- SCORE DATE
    'TSU', -- ATTR1
    'QUARTER', -- ATTR2
    '4', -- ATTR3 
    NULL, -- ATTR4 (INICIO DE PERIODO)
    1, -- STUDENT_ID,
    'ADMIN' -- CREATED BY        
),
(
	/* QUATRIMESTRE 5 */
	'8.9', -- SCORE
    STR_TO_DATE('05-15-2020', '%m-%d-%Y'), -- SCORE DATE
    'TSU', -- ATTR1
    'QUARTER', -- ATTR2
    '5', -- ATTR3
    NULL, -- ATTR4 (INICIO DE PERIODO)
    1, -- STUDENT_ID,
    'ADMIN' -- CREATED BY        
),
(
	/* QUATRIMESTRE 6 */
	'9.0', -- SCORE
    STR_TO_DATE('05-15-2020', '%m-%d-%Y'), -- SCORE DATE
    'TSU', -- ATTR1
    'QUARTER', -- ATTR2
    '6', -- ATTR3
    NULL, -- ATTR4 (INICIO DE PERIODO)
    1, -- STUDENT_ID,
    'ADMIN' -- CREATED BY        
),
(
	/* QUATRIMESTRE 7 */
	'8.1', -- SCORE
    STR_TO_DATE('05-15-2020', '%m-%d-%Y'), -- SCORE DATE
    'ING', -- ATTR1
    'QUARTER', -- ATTR2
    '7', -- ATTR3
    NULL, -- ATTR4 (INICIO DE PERIODO)
    1, -- STUDENT_ID,
    'ADMIN' -- CREATED BY        
),
(
	/* QUATRIMESTRE 8 */
	'8.5', -- SCORE
    STR_TO_DATE('05-15-2020', '%m-%d-%Y'), -- SCORE DATE
    'ING', -- ATTR1
    'QUARTER', -- ATTR2
    '8', -- ATTR3
    NULL, -- ATTR4 (INICIO DE PERIODO)
    1, -- STUDENT_ID,
    'ADMIN' -- CREATED BY        
);