## CREATING DATABASE
DROP DATABASE IF EXISTS CLASSROOM;
CREATE DATABASE CLASSROOM;
USE CLASSROOM;

## ASSETS
DROP TABLE IF EXISTS ASSET;
CREATE TABLE ASSET (
	ASSET_ID INT NOT NULL,
    ASSET_CODE VARCHAR(8) NOT NULL,
    NAME VARCHAR(40) NOT NULL,
    ATTR1 VARCHAR(450),
    ATTR2 VARCHAR(450),
    ATTR3 VARCHAR(450),
    DESCRIPTION VARCHAR(40)
);

ALTER TABLE ASSET ADD CONSTRAINT PRIMARY KEY PK_ASSET (ASSET_ID),
				  MODIFY COLUMN ASSET_ID INT NOT NULL AUTO_INCREMENT,
                  ADD CONSTRAINT UNIQUE UQ_ASSET_CODE (ASSET_CODE);

## LOCATION
DROP TABLE IF EXISTS LOCATION;
CREATE TABLE LOCATION (
	LOCATION_ID INT PRIMARY KEY AUTO_INCREMENT,
    COUNTRY_ID INT NOT NULL,
    CITY_ID INT NOT NULL,
    CITY VARCHAR(50)
);

ALTER TABLE LOCATION ADD CONSTRAINT FOREIGN KEY FK_LOCATION_COUNTRY (COUNTRY_ID) REFERENCES ASSET (ASSET_ID),
					 ADD CONSTRAINT FOREIGN KEY FK_LOCATION_CITY (CITY_ID) REFERENCES ASSET (ASSET_ID),
                     ADD CONSTRAINT UNIQUE KEY UQ_LOCATION_CC (COUNTRY_ID, CITY_ID);

## ADDRESS
DROP TABLE IF EXISTS ADDRESS;
CREATE TABLE ADDRESS (
	ADDRESS_ID INT PRIMARY KEY AUTO_INCREMENT,
    STREET VARCHAR(300) NOT NULL,
    NUMBER VARCHAR(20) NOT NULL,
    NEIGHBORHOOD VARCHAR(20) NOT NULL,
    LOCATION_ID INT NOT NULL
);

ALTER TABLE ADDRESS ADD CONSTRAINT FOREIGN KEY FK_ADDRESS_LOCATION (LOCATION_ID) REFERENCES LOCATION (LOCATION_ID);

## CONTACT 
DROP TABLE IF EXISTS CONTACT;
CREATE TABLE CONTACT (
	CONTACT_ID INT PRIMARY KEY AUTO_INCREMENT,
    EMAIL1 VARCHAR(100) NOT NULL,
    EMAIL2 VARCHAR(100),
    PHONE1 VARCHAR(40) NOT NULL,
    PHONE2 VARCHAR(40),
    DESCRIPTION VARCHAR(150)
);

## LABOR_STUDENT
DROP TABLE IF EXISTS LABOR_STUDENT;
CREATE TABLE LABOR_STUDENT(
	LABOR_ID INT PRIMARY KEY AUTO_INCREMENT,
    DEPARTMENT VARCHAR(50) NOT NULL,
    BUSINESS VARCHAR(150) NOT NULL,
    JOB VARCHAR(50) NOT NULL,
    ADDRESS_ID INT,
    CONTACT_ID INT,
    IS_STUDY BOOL    
);

ALTER TABLE LABOR_STUDENT ADD CONSTRAINT FOREIGN KEY FK_LS_ADDRESS (ADDRESS_ID) REFERENCES ADDRESS(ADDRESS_ID),
						  ADD CONSTRAINT FOREIGN KEY FK_LS_CONTACT (CONTACT_ID) REFERENCES CONTACT(CONTACT_ID);

## SCHOLARLY_STUDENT
DROP TABLE IF EXISTS SCHOLARLY;
CREATE TABLE SCHOLARLY (
	SCHOLARLY_ID INT PRIMARY KEY AUTO_INCREMENT,
    SCHOOL_NAME VARCHAR(80),
    SCH_TYPE_ID INT NOT NULL,
    ADDRESS_ID INT NOT NULL
);

ALTER TABLE SCHOLARLY ADD CONSTRAINT FOREIGN KEY FK_SCHOLARLY_ADDRESS (ADDRESS_ID) REFERENCES ADDRESS (ADDRESS_ID),
					  ADD CONSTRAINT FOREIGN KEY FK_SCHOLARLY_TYPE (SCH_TYPE_ID) REFERENCES ASSET (ASSET_ID);


## STUDENT
DROP TABLE IF EXISTS STUDENT;
CREATE TABLE STUDENT (
	STUDENT_ID INT PRIMARY KEY AUTO_INCREMENT,
    STUDENT_CODE VARCHAR(15) NOT NULL,
    NAME VARCHAR(80) NOT NULL,
    LAST_NAME VARCHAR(80) NOT NULL,
    IMAGE LONGBLOB,
    BIRTH DATE NOT NULL,
    BIRTH_LOCATION INT NOT NULL,
    GENRE_ID INT NOT NULL,
    MARITAL_ID INT NOT NULL,
    CONTACT_ID INT,
    ADDRESS_ID INT,
    SCHOLARLY_ID INT,
    LABOR_ID INT
);

ALTER TABLE STUDENT ADD CONSTRAINT FOREIGN KEY FK_BIRTH_LOCATION (BIRTH_LOCATION) REFERENCES LOCATION (LOCATION_ID),
				    ADD CONSTRAINT FOREIGN KEY FK_STUDENT_GENRE (GENRE_ID) REFERENCES ASSET (ASSET_ID),
                    ADD CONSTRAINT FOREIGN KEY FK_STUDENT_MARITAL (MARITAL_ID) REFERENCES ASSET (ASSET_ID),
                    ADD CONSTRAINT FOREIGN KEY FK_STUDENT_CONTACT (CONTACT_ID) REFERENCES CONTACT (CONTACT_ID),
                    ADD CONSTRAINT FOREIGN KEY FK_STUDENT_ADDRESS (ADDRESS_ID) REFERENCES ADDRESS (ADDRESS_ID),
                    ADD CONSTRAINT FOREIGN KEY FK_STUDENT_LABOR (LABOR_ID) REFERENCES LABOR_STUDENT (LABOR_ID),
                    ADD CONSTRAINT FOREIGN KEY FK_STUDENT_SCHO (SCHOLARLY_ID) REFERENCES SCHOLARLY (SCHOLARLY_ID),
                    ADD CONSTRAINT UNIQUE KEY UQ_STUDENT_CODE (STUDENT_CODE);

## CONTACT - FAMILY
DROP TABLE IF EXISTS CONTACT_FAMILY;
CREATE TABLE CONTACT_FAMILY (
	CON_FAMILY_ID INT PRIMARY KEY AUTO_INCREMENT,
    NAME VARCHAR(400) NOT NULL,
    KINSHIP VARCHAR(40),
    WORK VARCHAR(30),
    IS_EMERGENCY BOOL,
    CONTACT_ID INT NOT NULL,
    STUDENT_ID INT NOT NULL
);

ALTER TABLE CONTACT_FAMILY ADD CONSTRAINT FOREIGN KEY FK_CF_CONTACT (CONTACT_ID) REFERENCES CONTACT (CONTACT_ID),
						   ADD CONSTRAINT FOREIGN KEY FK_CF_STUDENT (STUDENT_ID) REFERENCES STUDENT (STUDENT_ID);

## STUDENT_HISTORY
DROP TABLE IF EXISTS STUDENT_HISTORY;
CREATE TABLE STUDENT_HISTORY (
	HISTORY_ID INT NOT NULL,
    SCORE VARCHAR(100) NULL,
    SCORE_DATE DATE,
    ATTR1 VARCHAR(450) NOT NULL,
    ATTR2 VARCHAR(450) NOT NULL,
    ATTR3 VARCHAR(450),
    ATTR4 VARCHAR(450),
    STUDENT_ID INT NOT NULL
);

ALTER TABLE STUDENT_HISTORY ADD CONSTRAINT PRIMARY KEY PK_STUDENT_HISTORY (HISTORY_ID, STUDENT_ID),
							-- ADD CONSTRAINT FOREIGN KEY FK_SH_STUDENT (STUDENT_ID) REFERENCES STUDENT (STUDENT_ID),
                            MODIFY COLUMN HISTORY_ID INT NOT NULL AUTO_INCREMENT;

## MAJOR
DROP TABLE IF EXISTS MAJOR;
CREATE TABLE MAJOR (
	MAJOR_ID INT PRIMARY KEY AUTO_INCREMENT,
    MAJOR_CODE VARCHAR(30),
    NAME VARCHAR(200),
    LEVEL_ID INT NOT NULL
);

ALTER TABLE MAJOR ADD CONSTRAINT FOREIGN KEY FK_MAJOR_LEVEL (LEVEL_ID) REFERENCES ASSET (ASSET_ID);

## GROUP
DROP TABLE IF EXISTS GROUP_CLASS;
CREATE TABLE GROUP_CLASS (
	GROUP_ID INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    GROUP_CODE VARCHAR(20) NOT NULL,
	GROUP_KEY VARCHAR(10) NOT NULL,
    QUARTER INT NOT NULL,
    MAJOR_ID INT NOT NULL,
    FIELD_ID INT NOT NULL,
    PERIOD_ID INT NOT NULL,
    DESCRIPTION VARCHAR(450)
);

ALTER TABLE GROUP_CLASS ADD CONSTRAINT FOREIGN KEY FK_GC_MAJOR (MAJOR_ID) REFERENCES MAJOR (MAJOR_ID),
						ADD CONSTRAINT FOREIGN KEY FK_GC_FIELD (FIELD_ID) REFERENCES ASSET (ASSET_ID),
                        ADD CONSTRAINT FOREIGN KEY FK_GC_PERIOD (PERIOD_ID) REFERENCES ASSET (ASSET_ID);											

## GROUP - STUDENT

DROP TABLE IF EXISTS GROUP_STUDENT;
CREATE TABLE GROUP_STUDENT (
	GROUP_ID INT NOT NULL,
    STUDENT_ID INT NOT NULL,
    IS_CURSED BOOL NOT NULL DEFAULT 1
);

ALTER TABLE GROUP_STUDENT ADD CONSTRAINT PK_GS_GROUP PRIMARY KEY (GROUP_ID, STUDENT_ID),
						  ADD CONSTRAINT FK_GS_GROUP FOREIGN KEY (GROUP_ID) REFERENCES GROUP_CLASS (GROUP_ID),
						  ADD CONSTRAINT FK_GS_STUDENT FOREIGN KEY (STUDENT_ID) REFERENCES STUDENT (STUDENT_ID);

/*######################### ADD AUDIT COLUMNS TO ALL TABLES! ##############################*/
DROP PROCEDURE IF EXISTS ADD_AUDIT_COLUMNS;
DELIMITER // 
CREATE PROCEDURE ADD_AUDIT_COLUMNS(
	OUT OUT_MSG VARCHAR(500)
)
BEGIN	
    DECLARE TABLE_N VARCHAR(300) DEFAULT '';
	DECLARE TABLES_C CURSOR FOR SELECT TABLE_NAME FROM information_schema.tables WHERE TABLE_SCHEMA = 'CLASSROOM';
	DECLARE EXIT HANDLER FOR SQLEXCEPTION 
    BEGIN
		GET DIAGNOSTICS CONDITION 1 @errno = MYSQL_ERRNO, @errmsg = MESSAGE_TEXT;
		SET OUT_MSG = CONCAT( 'ERROR EXECUTING PROCESS [DYNAMIC_SQL_STMT] - (', @errno ,'): ', @errmsg);
	END;
    
	SET OUT_MSG = 'OK';
    
    OPEN TABLES_C;    
    TABLE_LOOP: LOOP
    
		FETCH TABLES_C INTO TABLE_N;        
        
        SET @s = CONCAT(
			'ALTER TABLE ', 
				TABLE_N ,
			' ADD STATUS VARCHAR(40) NOT NULL DEFAULT \'ENABLED\' CHECK (STATUS IN (\'ENABLED\', \'DISABLED\')),
              ADD CREATED_ON DATETIME NOT NULL DEFAULT NOW(),
              ADD CREATED_BY VARCHAR(50),
              ADD UPDATED_ON DATETIME,
              ADD UPDATED_BY VARCHAR(50)'
		);			
        
		PREPARE stmt FROM @s;
		EXECUTE stmt;
		DEALLOCATE PREPARE stmt;
        
	END LOOP;    
    CLOSE TABLES_C;
	
END
//
DELIMITER ;

set @msg = null;
call ADD_AUDIT_COLUMNS(@msg);
SELECT @msg;