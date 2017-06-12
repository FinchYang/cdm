--------------------------------------------------------
--  文件已创建 - 星期一-六月-12-2017   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table SYNCUSER
--------------------------------------------------------

  CREATE TABLE "CITY"."SYNCUSER" 
   (	"IDENTITY" VARCHAR2(20 BYTE), 
	"NOTICESTATUS" VARCHAR2(20 BYTE), 
	"STUDYSTATUS" VARCHAR2(20 BYTE)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SYNCUSER_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "CITY"."SYNCUSER_PK" ON "CITY"."SYNCUSER" ("IDENTITY") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table SYNCUSER
--------------------------------------------------------

  ALTER TABLE "CITY"."SYNCUSER" ADD CONSTRAINT "SYNCUSER_PK" PRIMARY KEY ("IDENTITY")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
  ALTER TABLE "CITY"."SYNCUSER" MODIFY ("STUDYSTATUS" NOT NULL ENABLE);
  ALTER TABLE "CITY"."SYNCUSER" MODIFY ("NOTICESTATUS" NOT NULL ENABLE);
  ALTER TABLE "CITY"."SYNCUSER" MODIFY ("IDENTITY" NOT NULL ENABLE);
