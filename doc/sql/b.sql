--------------------------------------------------------
--  文件已创建 - 星期五-四月-14-2017   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table BUSSINESS
--------------------------------------------------------

  CREATE TABLE "CITY"."BUSSINESS" 
   (	"ID" NUMBER, 
	"TYPE" NUMBER, 
	"START_TIME" DATE, 
	"END_TIME" DATE, 
	"STATUS" NUMBER, 
	"QUEUE_NUM" NVARCHAR2(10), 
	"ID_NUM" NVARCHAR2(25), 
	"ADDRESS" NVARCHAR2(100), 
	"SERIAL_NUM" VARCHAR2(20 BYTE), 
	"REJECT_REASON" VARCHAR2(100 BYTE), 
	"NAME" VARCHAR2(100 BYTE), 
	"PHONE_NUM" VARCHAR2(50 BYTE), 
	"PROCESS_USER" VARCHAR2(50 BYTE), 
	"FILE_RECV_USER" VARCHAR2(50 BYTE), 
	"TRANSFER_STATUS" NUMBER DEFAULT 0, 
	"UPLOADER" VARCHAR2(50 BYTE), 
	"COMPLETE_PAY_USER" VARCHAR2(50 BYTE), 
	"ATTENTION" VARCHAR2(100 BYTE), 
	"UNLOAD_TASK_NUM" NVARCHAR2(20)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1 BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;

   COMMENT ON COLUMN "CITY"."BUSSINESS"."ID" IS '业务的ID';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."TYPE" IS '业务类型：
1.初次申领
2.增加准驾车型申领
....';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."START_TIME" IS '业务上传的时间';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."END_TIME" IS '业务完成的时间';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."STATUS" IS '业务的状态
1.已扫描完成并上传
2.上传了一部分的任务
3.正在处理的任务
4.已拒绝受理的任务
5.已完成但未缴费
6.无法处理的任务
7.已缴费
8.已领取牌证 9.填单机提交';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."QUEUE_NUM" IS '排队号';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."ID_NUM" IS '身份证号';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."ADDRESS" IS '户籍地址';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."SERIAL_NUM" IS '六合一平台流水号';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."REJECT_REASON" IS '拒绝原因（只有任务被拒绝时有效）';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."PHONE_NUM" IS '电话号码';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."PROCESS_USER" IS '办理人';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."FILE_RECV_USER" IS '接收档案的用户，用于档案移交';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."TRANSFER_STATUS" IS '档案移交状态
0.未移交
1.已发送移交，但对方未接受
2.已接受';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."UPLOADER" IS '任务上传账号';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."COMPLETE_PAY_USER" IS '完成缴费用户';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."ATTENTION" IS '重点关注的业务，关注原因';
   COMMENT ON COLUMN "CITY"."BUSSINESS"."UNLOAD_TASK_NUM" IS '信息采集系统上传的业务编号';
REM INSERTING into CITY.BUSSINESS
SET DEFINE OFF;
--------------------------------------------------------
--  Constraints for Table BUSSINESS
--------------------------------------------------------

  ALTER TABLE "CITY"."BUSSINESS" MODIFY ("QUEUE_NUM" NOT NULL ENABLE);
  ALTER TABLE "CITY"."BUSSINESS" MODIFY ("STATUS" NOT NULL ENABLE);
  ALTER TABLE "CITY"."BUSSINESS" MODIFY ("START_TIME" NOT NULL ENABLE);
  ALTER TABLE "CITY"."BUSSINESS" MODIFY ("TYPE" NOT NULL ENABLE);
  ALTER TABLE "CITY"."BUSSINESS" MODIFY ("ID" NOT NULL ENABLE);
