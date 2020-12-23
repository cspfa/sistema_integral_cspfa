CREATE TABLE ENTRADA_CAMPO_PH 
(
  ID                        INTEGER         NOT NULL,
  ID_EC                     INTEGER,
  ID_HORA                   INTEGER,
  SOCIO_PILETA              INTEGER,
  INTER_PILETA              INTEGER,
  INVI_PILETA               INTEGER,
  MENOR                     INTEGER,
  DISCA                     INTEGER,
  DISCA_ACOM                INTEGER,
  PROMO                     INTEGER,
  FECHA                        DATE,
  ROL                       VARCHAR(    50),
 CONSTRAINT PK_ENTRADA_CAMPO_PH PRIMARY KEY (ID)
);

SET TERM ^^ ;
CREATE PROCEDURE P_ENTRADA_CAMPO_PH_I (
  PIN_ID_EC Integer, 
  PIN_ID_HORA Integer, 
  PIN_SOCIO_PILETA Integer, 
  PIN_INTER_PILETA Integer, 
  PIN_INVI_PILETA Integer, 
  PIN_MENOR Integer, 
  PIN_DISCA Integer, 
  PIN_DISCA_ACOM Integer, 
  PIN_PROMO Integer, 
  PIN_FECHA Date, 
  PIN_ROL VarChar(50))
 returns (
  POUT_ID Integer) AS
BEGIN
  SUSPEND;
END ^^
SET TERM ; ^^
SET TERM ^^ ;
CREATE OR ALTER PROCEDURE P_ENTRADA_CAMPO_PH_I (
  PIN_ID_EC Integer, 
  PIN_ID_HORA Integer, 
  PIN_SOCIO_PILETA Integer, 
  PIN_INTER_PILETA Integer, 
  PIN_INVI_PILETA Integer, 
  PIN_MENOR Integer, 
  PIN_DISCA Integer, 
  PIN_DISCA_ACOM Integer, 
  PIN_PROMO Integer, 
  PIN_FECHA Date, 
  PIN_ROL VarChar(50))
 returns (
  POUT_ID Integer) AS ^^
SET TERM ; ^^



