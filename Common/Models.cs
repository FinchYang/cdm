﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Common
{
    public enum VoiceType {Fee,Reject}
    public enum LedMsgType { Processing, Reject ,Done}
    public enum CountyCode { HaiYang, FuShan,QiXia }
   
    public enum ClientType { Voice, Led }
    public class CdmMessage
    {
        public CdmMessage()
        {
            CountyCode = string.Empty;
            ClientType= ClientType.Led;
        }
        public string CountyCode { get; set; }
        public ClientType ClientType { get; set; }
        public VoiceType VoiceType { get; set; }
        public LedMsgType LedMsgType { get; set; }
        public string Content { get; set; }

    }
    public class CdmClient
    {
        public CdmClient()
        {
            ConnectId = string.Empty;
        }
        public string ConnectId { get; set; }
        public string CountyCode { get; set; }
        public ClientType ClientType { get; set; }
    }

    public enum UserRole { Audit, Accept, Pay, Certificate }
    public enum UserTransactionType { Add, Update, GetUserList, Disable,ResetPass ,Login,ChangePass}
    public enum AuthorityLevel { Ordinary, CountyMagistrate, Administrator }
    public class UserTransaction
    {
        public UserTransaction()
        {
            UserInfo = new PoliceUser();
        }
        public UserTransactionType UserTransactionType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public PoliceUser UserInfo { get; set; }
        //public override string ToString()
        //{
        //    var perm = string.Empty;
        //    if (UserInfo.Permission == null)
        //        return
        //            string.Format(
        //                "type:{0},operator:{1},AuthorityLevel:{2},RealName:{3},UserName:{4},PoliceCode:{5},Disabled:{6},CountyCode:{7},UserRole:{8},Notation:{9},permission:{10}",
        //                UserTransactionType, UserName ?? "null", UserInfo.AuthorityLevel, UserInfo.RealName ?? "null",
        //                UserInfo.UserName ?? "null", UserInfo.PoliceCode ?? "null",
        //                UserInfo.Disabled, UserInfo.CountyCode ?? "null", UserInfo.UserRole,
        //                UserInfo.Notation ?? "null", perm);
        //    foreach (var v in UserInfo.Permission)
        //    {
        //        perm += v.Key + ":" + v.Value + ",";
        //    }
        //    return string.Format("type:{0},operator:{1},AuthorityLevel:{2},RealName:{3},UserName:{4},PoliceCode:{5},Disabled:{6},CountyCode:{7},UserRole:{8},Notation:{9},permission:{10}",
        //        UserTransactionType, UserName ?? "null", UserInfo.AuthorityLevel, UserInfo.RealName ?? "null", UserInfo.UserName ?? "null", UserInfo.PoliceCode ?? "null",
        //        UserInfo.Disabled, UserInfo.CountyCode ?? "null", UserInfo.UserRole,
        //       UserInfo.Notation ?? "null", perm);
        //   // return base.ToString();
        //}
    }
    public class PoliceUser
    {
        public AuthorityLevel AuthorityLevel { get; set; }
        public string RealName { get; set; }
        public string UserName { get; set; }
        public string PoliceCode { get; set; }
        public string Password { get; set; }
        public bool Disabled { get; set; }
        public string CountyCode { get; set; }
        public UserRole UserRole { get; set; }
        public string Notation { get; set; }
        public Dictionary<string,bool> Permission { get; set; }
    }
    public class SimpleResult
    {
        public SimpleResult()
        {
            Users = new List<PoliceUser>();
        }
        public string StatusCode { get; set; }
        public string Content { get; set; }
        public List<PoliceUser> Users { get; set; }
    }
    public class OrdinalInput
    {
        public string countyCode { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string counterNum { get; set; }
    }
    public class BusinessModel
    {
        public BusinessModel()
        {
            countyCode = string.Empty;
            userName = string.Empty;
            password = string.Empty;

            businessCategory = string.Empty;
            counterNum = string.Empty;

            Gender = string.Empty;
            Birthday = string.Empty;
            ZipCode = string.Empty;
            Nationality = string.Empty;

            startTime = string.Empty;
            endTime = string.Empty;
            queueNum = string.Empty;
            IDum = string.Empty;
            address = string.Empty;

            serialNum = string.Empty;
            rejectReason = string.Empty;
            name = string.Empty;
            phoneNum = string.Empty;
            processUser = string.Empty;

            fileRecvUser = string.Empty;
            transferStatus = string.Empty;
            uploader = string.Empty;
            completePayUser = string.Empty;
            attention = string.Empty;

            unloadTaskNum = string.Empty;
            carNum = string.Empty;
            texType = string.Empty;
            texNum = string.Empty;
            originType = string.Empty;

            originNum = string.Empty;
            ID = -1;
            type = -1;
            status = -1;
            checkFile = -1;

            zipFile = new byte[1];
        }
        public string countyCode { get; set; }//地区标识//input,out
        public string userName { get; set; }

        public string password { get; set; }
        public string BusinessUser { get; set; }
        public string businessCategory { get; set; }//业务种类//input,out
        public string counterNum { get; set; }
        public int ID { get; set; }//每笔业务编号，唯一//out
        public int type { get; set; }//业务种类//input,out

        public string Gender { get; set; }//性别//out
        public string Birthday { get; set; }//生日//out
        public string ZipCode { get; set; }//生日//out
        public string Nationality { get; set; }//民族//out
        public string startTime { get; set; }//开始时间//out
        public string endTime { get; set; }//业务办理完结时间out
        public int status { get; set; }//当前任务状态和进度in,out
        public string queueNum { get; set; }//排队号,in,out
        public string IDum { get; set; }//身份证号码或公司组织结构代码,in
        public string address { get; set; }//身份证地址或公司地址,in
        public string serialNum { get; set; }//公安网六合一平台流水号,in
        public string rejectReason { get; set; }//业务受理拒绝原因,in
        public string name { get; set; }//办理人姓名或公司名称,in
        public string phoneNum { get; set; }//办理人电话号码in
        public string processUser { get; set; }//办理民警in
        public string fileRecvUser { get; set; }//归档民警in
        public string transferStatus { get; set; }//档案移交状态
        public string uploader { get; set; }//业务审核民警in
        public string completePayUser { get; set; }//缴费民警in
        public string attention { get; set; }//资料审核处填写的重点关注in
        public string unloadTaskNum { get; set; }//自主信息采集机的表单序号in
        public int checkFile { get; set; }//核档是否成功in
        public string carNum { get; set; }//机动车牌号码in
        public string texType { get; set; }//完税种类in
        public string texNum { get; set; }//完税凭证号码in
        public string originType { get; set; }//来历证明种类in
        public string originNum { get; set; }//来历证明号码in
        public byte[] zipFile { get; set; }//图片in
    }
    public class ResultModel
    {

        public ResultModel()
        {
            BussinessModel = new BusinessModel();
        }
        public string StatusCode { get; set; }
        public string Result { get; set; }
        public BusinessModel BussinessModel { get; set; }
    }
    public class BusinessListResult
    {

        public BusinessListResult()
        {
            BussinessList = new List<BusinessModel>();
        }
        public string StatusCode { get; set; }
        public string Result { get; set; }
        public List<BusinessModel> BussinessList { get; set; }
    }
}
