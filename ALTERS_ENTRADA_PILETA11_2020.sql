CREATE TABLE PILETA_HORARIOS 
(
  ID                 INTEGER         NOT NULL,
  DESDE              VARCHAR(    20)  COLLATE NONE,
  HASTA              VARCHAR(    20)  COLLATE NONE,
 CONSTRAINT PK_PILETA_HORARIOS PRIMARY KEY (ID)
);

alter table entrada_campo add SCARGO integer 
alter table entrada_campo add MONTO_SCARGO integer 

