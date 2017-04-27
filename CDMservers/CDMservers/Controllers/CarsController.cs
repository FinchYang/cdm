﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Remoting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;
using CDMservers.Models;
using Common;
using DataService;
using log4net;
using Newtonsoft.Json;

namespace CDMservers.Controllers
{
    public class CarsController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string FileRootPath = ConfigurationManager.AppSettings["FileRootPath"];

        [Route("GetBusinessInfoByOdc")]
        [HttpPost]
        public ResultModel GetBusinessInfoByOdc([FromBody] BusinessModel param)
        {
            try
            {
                if (!PermissionCheck.Check(param))
                {
                    return new ResultModel { statusCode = "000007", result = "没有权限" };
                }
                InputLog(param);
                using (var cd = new Business())
                {
                    switch (param.countyCode)
                    {
                        case "haiyang":
                            return HaiyangBusinessInfo(cd,param);
                        case "fushan":
                            return FushanBusinessInfo(cd, param);
                        default:
                            return AllBusinessInfo(cd, param);
                    }
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Log.InfoFormat("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Log.InfoFormat("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (EntityDataSourceValidationException ex)
            {
                Log.Error("EntityDataSourceValidationException", ex);
                return new ResultModel { statusCode = "000003", result = ex.Message };
            }
            catch (Exception ex)
            {
                Log.Error("GetBusinessInfoByOdc", ex);
                return new ResultModel { statusCode = "000003", result = ex.Message };
            }
        }
        private ResultModel AllBusinessInfo(Business cd, BusinessModel param)
        {
            var busi = cd.Bussiness.FirstOrDefault(c => c.UNLOAD_TASK_NUM == param.unloadTaskNum);

            if (busi == null)
                return new ResultModel
                {
                    statusCode = "000006",
                    result = "没有相关业务信息，请检查 上传任务代码：" + param.unloadTaskNum
                };
            var fpath = (@FileRootPath + param.countyCode + "\\" + busi.START_TIME + "\\" + busi.ID);
            Log.Info("fpath is:" + fpath);
            var fcontent = File.ReadAllBytes(@fpath);
            Log.Info("fcontent is:" + fcontent.Length);
            return new ResultModel
            {
                statusCode = "000000",
                bussinessModel = new BusinessModel
                {
                    type = int.Parse(busi.TYPE.ToString(CultureInfo.InvariantCulture)),
                    name = busi.NAME,
                    IDum = busi.ID_NUM,
                    queueNum = busi.QUEUE_NUM,
                    address = busi.ADDRESS,
                    phoneNum = busi.PHONE_NUM,
                    attention = busi.ATTENTION,
                    zipFile = fcontent
                }
            };
        }
        private ResultModel FushanBusinessInfo(Business cd, BusinessModel param)
        {
            var busi = cd.Fushanbusiness.FirstOrDefault(c => c.UNLOAD_TASK_NUM == param.unloadTaskNum);

            if (busi == null)
                return new ResultModel
                {
                    statusCode = "000006",
                    result = "没有相关业务信息，请检查 上传任务代码：" + param.unloadTaskNum
                };
            var fpath = (@FileRootPath + param.countyCode + "\\" + busi.START_TIME + "\\" + busi.ID);
            Log.Info("fpath is:" + fpath);
            var fcontent = File.ReadAllBytes(@fpath);
            Log.Info("fcontent is:" + fcontent.Length);
            return new ResultModel
            {
                statusCode = "000000",
                bussinessModel = new BusinessModel
                {
                    type = int.Parse(busi.TYPE.ToString(CultureInfo.InvariantCulture)),
                    name = busi.NAME,
                    IDum = busi.ID_NUM,
                    queueNum = busi.QUEUE_NUM,
                    address = busi.ADDRESS,
                    phoneNum = busi.PHONE_NUM,
                    attention = busi.ATTENTION,
                    zipFile = fcontent
                }
            };
        }
        private ResultModel HaiyangBusinessInfo(Business cd, BusinessModel param)
        {
            var busi = cd.Haiyangbusiness.FirstOrDefault(c => c.UNLOAD_TASK_NUM == param.unloadTaskNum);

            if (busi == null)
                return new ResultModel
                {
                    statusCode = "000006",
                    result = "没有相关业务信息，请检查 上传任务代码：" + param.unloadTaskNum
                };
            var fpath = (@FileRootPath + param.countyCode + "\\" + busi.START_TIME + "\\" + busi.ID);
            Log.Info("fpath is:" + fpath);
            var fcontent = File.ReadAllBytes(@fpath);
            Log.Info("fcontent is:" + fcontent.Length);
            return new ResultModel
            {
                statusCode = "000000",
                bussinessModel = new BusinessModel
                {
                    type = int.Parse(busi.TYPE.ToString(CultureInfo.InvariantCulture)),
                    name = busi.NAME,
                    IDum = busi.ID_NUM,
                    queueNum = busi.QUEUE_NUM,
                    address = busi.ADDRESS,
                    phoneNum = busi.PHONE_NUM,
                    attention = busi.ATTENTION,
                    zipFile = fcontent
                }
            };
        }

        [Route("PostBusinessFormInfo")]
        [HttpPost]
        public async Task<ResultModel> PostBusinessFormInfo([FromBody] BusinessModel param)
        {
            try
            {
                if (!PermissionCheck.Check(param))
                {
                    return new ResultModel { statusCode = "000007", result = "没有权限" };
                }
            //    Log.Info("PostBusinessFormInfo input is:" + JsonConvert.SerializeObject(param));

                var id = new OracleOperation().GetBusinessId();
                var currentdate = DateTime.Now.Date;
                var scurrentdate = string.Format("{0}-{1}-{2}", currentdate.Year, currentdate.Month, currentdate.Day);

                var filepath = string.Format("{2}{0}\\{1}", param.countyCode, scurrentdate, @FileRootPath);
            //    Log.Info("path 11 =" + filepath);
                if (!Directory.Exists(@filepath))
                {
                    Log.Info("path=" + filepath);
                    Directory.CreateDirectory(@filepath);
                }
                var filename = string.Format("{0}\\{1}", filepath, id);
             //   Log.Info("file name=" + filename);
                File.WriteAllBytes(filename, param.zipFile);

                switch (param.countyCode)
                {
                    case "haiyang":
                        using (var cd = new Business())
                        {
                            cd.Haiyangbusiness.Add(new haiyangbusiness { ID = id, COUNTYCODE = param.countyCode, UNLOAD_TASK_NUM = param.unloadTaskNum, START_TIME = scurrentdate, STATUS = param.status, TYPE = param.type, NAME = param.name, ID_NUM = param.IDum, QUEUE_NUM = param.queueNum, ADDRESS = param.address, PHONE_NUM = param.phoneNum, ATTENTION = param.attention });
                            cd.SaveChanges();
                        }
                        break;
                    case "fushan":
                        using (var cd = new Business())
                        {
                            cd.Fushanbusiness.Add(new fushanbusiness { ID = id, COUNTYCODE = param.countyCode, UNLOAD_TASK_NUM = param.unloadTaskNum, START_TIME = scurrentdate, STATUS = param.status, TYPE = param.type, NAME = param.name, ID_NUM = param.IDum, QUEUE_NUM = param.queueNum, ADDRESS = param.address, PHONE_NUM = param.phoneNum, ATTENTION = param.attention });
                            cd.SaveChanges();
                        }
                        break;
                    default:
                        using (var cd = new Business())
                        {
                            cd.Bussiness.Add(new BUSSINESS { ID = id, COUNTYCODE = param.countyCode, UNLOAD_TASK_NUM = param.unloadTaskNum, START_TIME = scurrentdate, STATUS = param.status, TYPE = param.type, NAME = param.name, ID_NUM = param.IDum, QUEUE_NUM = param.queueNum, ADDRESS = param.address, PHONE_NUM = param.phoneNum, ATTENTION = param.attention });
                            cd.SaveChanges();
                        }
                        break;
                }

                await MessagePush.PushVoiceMessage(new CdmMessage
                {
                    ClientType = ClientType.Voice,
                    Content = param.queueNum,
                    CountyCode = param.countyCode,
                    VoiceType = VoiceType.Fee
                });
                return new ResultModel { statusCode = "000000", bussinessModel = new BusinessModel() };
            }
            catch (DbEntityValidationException e)
            {
                var err = string.Empty;
                foreach (var eve in e.EntityValidationErrors)
                {
                    var err1 =
                        string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    err += err1;
                    Log.InfoFormat(err1);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        var err2 = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                        Log.InfoFormat(err2);
                        err += err2;
                    }
                }
                return new ResultModel { statusCode = "000003", result = "DbEntityValidationException:" + err };
            }
            catch (EntityDataSourceValidationException ex)
            {
                Log.Error("EntityDataSourceValidationException", ex);
                return new ResultModel { statusCode = "000003", result = ex.Message };
            }
            catch (Exception ex)
            {
                Log.Error("PostBusinessFormInfo", ex);
                return new ResultModel { statusCode = "000003", result = ex.Message };
            }
        }


        private void InputLog(BusinessModel input)
        {
            Log.Info("input json string:" + JsonConvert.SerializeObject(input));
        }
    }
}
