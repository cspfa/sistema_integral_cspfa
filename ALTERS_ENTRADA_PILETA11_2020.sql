CREATE TABLE PILETA_HORARIOS 
(
  ID                 INTEGER         NOT NULL,
  DESDE              VARCHAR(    20)  COLLATE NONE,
  HASTA              VARCHAR(    20)  COLLATE NONE,
 CONSTRAINT PK_PILETA_HORARIOS PRIMARY KEY (ID)
);

alter table entrada_campo add PROMO integer 
alter table entrada_campo add HORA_PILETA integer 
update entrada_Campo set promo=0
update entrada_campo set hora_pileta=0
insert into config values('CAMPO_PILETA_HORA',555,473,'','','CPOCABA')
insert into config values ('CAMPO_PILETA_TOPE',20,200,'','','CPOCABA')

