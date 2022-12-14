/*################ GET_LABOR_STUDENT ###################*/
DROP PROCEDURE IF EXISTS GET_LABOR_STUDENTS;
DELIMITER //
CREATE PROCEDURE GET_LABOR_STUDENTS(
	IN IN_LABOR_STUDENTS INT,
    OUT OUT_MSG VARCHAR(450)
) BEGIN 
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		GET DIAGNOSTICS CONDITION 1 @errno = MYSQL_ERRNO, @errmsg = MESSAGE_TEXT;
		SET OUT_MSG = CONCAT( 'ERROR EXECUTING PROCESS [GET_LABOR_STUDENTS] - (', @errno ,'): ', @errmsg);
	END;
    
    SET OUT_MSG = 'OK';
    
    SELECT
		LS.LABOR_ID,
		LS.DEPARTMENT,
		LS.BUSINESS,
		LS.JOB,
        LS.ADDRESS_ID ADDRESS_ID,
        AD.STREET ADDRESS_STREET,
        AD.NEIGHBORHOOD ADDRESS_NEIGHBORHOOD,
		LS.CONTACT_ID CONTACT_ID,
        C.EMAIL1 CONTACT_EMAIL,
        C.PHONE1 CONTACT_PHONE,
        LS.IS_STUDY
    
    FROM
		LABOR_STUDENT LS JOIN ADDRESS AD ON LS.ADDRESS_ID = AD.ADDRESS_ID
        JOIN CONTACT C ON LS.CONTACT_ID = C.CONTACT_ID
    
    WHERE
		LS.LABOR_ID = IFNULL(IN_LABOR_STUDENTS, LS.LABOR_ID);
    
END //
DELIMITER ;

SET @msg = null;
CALL GET_LABOR_STUDENTS(1, @msg);
SELECT @msg;

/*################ GET_LOCATION ###################*/
DROP PROCEDURE IF EXISTS GET_LOCATION;
DELIMITER //
CREATE PROCEDURE GET_LOCATION(
	IN IN_LOCATION INT,
    OUT OUT_MSG VARCHAR(450)
) BEGIN 
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		GET DIAGNOSTICS CONDITION 1 @errno = MYSQL_ERRNO, @errmsg = MESSAGE_TEXT;
		SET OUT_MSG = CONCAT( 'ERROR EXECUTING PROCESS [GET_LOCATION] - (', @errno ,'): ', @errmsg);
	END;
    
    SET OUT_MSG = 'OK';
    
    SELECT
		L.LOCATION_ID,
        L.CITY CITY,
        COUNTRY.ASSET_ID COUNTRY_ID,
        COUNTRY.ASSET_CODE COUNTRY_CODE,
        COUNTRY.NAME COUNTRY_NAME,
        CITY.ASSET_ID CITY_ID,
		CITY.ASSET_CODE CITY_CODE,
		CITY.NAME CITY_NAME
    
    FROM
		LOCATION L,
        ASSET COUNTRY,
        ASSET CITY
        
    WHERE
		COUNTRY.ASSET_ID = COUNTRY_ID
		AND CITY.ASSET_ID = CITY_ID
		AND L.LOCATION_ID = IFNULL(IN_LOCATION, L.LOCATION_ID);

END //
DELIMITER ;

SET @msg = null;
CALL GET_LOCATION(4, @msg);
SELECT @msg;

/*################ GET_MAJOR ###################*/
DROP PROCEDURE IF EXISTS GET_MAJOR;
DELIMITER //
CREATE PROCEDURE GET_MAJOR(
	IN IN_MAJOR INT,
    OUT OUT_MSG VARCHAR(450)
) BEGIN 
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		GET DIAGNOSTICS CONDITION 1 @errno = MYSQL_ERRNO, @errmsg = MESSAGE_TEXT;
		SET OUT_MSG = CONCAT( 'ERROR EXECUTING PROCESS [GET_MAJOR] - (', @errno ,'): ', @errmsg);
	END;
    
    SET OUT_MSG = 'OK';
    
    SELECT
		M.MAJOR_ID,
        M.MAJOR_CODE,
        M.NAME,
       LEVEL.ASSET_ID LEVEL_ID,
       LEVEL.ASSET_CODE LEVEL_CODE,
       LEVEL.NAME LEVEL_NAME
    FROM
		MAJOR M,
        ASSET LEVEL
    WHERE
		LEVEL.ASSET_ID = LEVEL_ID
		AND M.MAJOR_ID = IFNULL(IN_MAJOR, M.MAJOR_ID);
    
END //
DELIMITER ;

SET @msg = null;
CALL GET_MAJOR(1, @msg);
SELECT @msg;

/*################ GET_SCHOLARLY ###################*/
DROP PROCEDURE IF EXISTS GET_SCHOLARLY;
DELIMITER //
CREATE PROCEDURE GET_SCHOLARLY(
	IN IN_SCHOLARLY INT,
    OUT OUT_MSG VARCHAR(450)
) BEGIN 
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		GET DIAGNOSTICS CONDITION 1 @errno = MYSQL_ERRNO, @errmsg = MESSAGE_TEXT;
		SET OUT_MSG = CONCAT( 'ERROR EXECUTING PROCESS [GET_SCHOLARLY] - (', @errno ,'): ', @errmsg);
	END;
    
    SET OUT_MSG = 'OK';
    
    SELECT
		S.SCHOLARLY_ID,
		S.SCHOOL_NAME,
        SCH_TYPE.ASSET_ID SCH_TYPE_ID,
        SCH_TYPE.ASSET_CODE SCH_TYPE_CODE,
        SCH_TYPE.NAME SCH_TYPE_NAME,
        AD.ADDRESS_ID ADDRESS_ID,
        AD.STREET ADDRESS_STREET,
        AD.NEIGHBORHOOD ADDRESS_NEIGHBORHOOD

    FROM
		SCHOLARLY S JOIN ADDRESS AD ON S.ADDRESS_ID = AD.ADDRESS_ID,
        ASSET SCH_TYPE        
    WHERE
		SCH_TYPE.ASSET_ID = S.SCH_TYPE_ID
		AND S.SCHOLARLY_ID = IFNULL(IN_SCHOLARLY, S.SCHOLARLY_ID);
    
END //
DELIMITER ;

SET @msg = null;
CALL GET_SCHOLARLY(1, @msg);
SELECT @msg;

/*################ GET_STUDENT_HISTORIAL ###################*/
DROP PROCEDURE IF EXISTS GET_STUDENT_HISTORIAL;
DELIMITER //
CREATE PROCEDURE GET_STUDENT_HISTORIAL (
	IN IN_STUDENT INT,
    IN IN_ATTR1 VARCHAR(450),
    IN IN_ATTR2 VARCHAR(450),
    OUT OUT_MSG VARCHAR(450)
) BEGIN 
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		GET DIAGNOSTICS CONDITION 1 @errno = MYSQL_ERRNO, @errmsg = MESSAGE_TEXT;
		SET OUT_MSG = CONCAT( 'ERROR EXECUTING PROCESS [GET_STUDENT_HISTORIAL] - (', @errno ,'): ', @errmsg);
	END;
    
    SET OUT_MSG = 'OK';
    
    SELECT 
		SH.HISTORY_ID, SH.SCORE_DATE,
		SH.ATTR1, SH.ATTR2, SH.ATTR3, 
		SH.ATTR4, SH.SCORE, SH.STUDENT_ID,
		S.NAME STUDENT_NAME, S.LAST_NAME STUDENT_LAST_NAME
	FROM 
		STUDENT_HISTORY SH JOIN STUDENT S ON SH.STUDENT_ID = S.STUDENT_ID 
	WHERE
		S.STUDENT_ID = IFNULL(IN_STUDENT, S.STUDENT_ID)
	AND SH.ATTR1 = IFNULL(IN_ATTR1, SH.ATTR1)
	AND	SH.ATTR2 = IFNULL(IN_ATTR2, SH.ATTR2);
    
END //
DELIMITER ;

SET @msg = null;
CALL GET_STUDENT_HISTORIAL(1, null, null, @msg);
SELECT @msg;