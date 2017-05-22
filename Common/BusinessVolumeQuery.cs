using System.Collections.Generic;

namespace Common
{
    public class CommonRequest
    {
        public string CountyCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class BusinessVolumeQuery : CommonRequest
    {
      
        public string StartTime { get; set; }//��ʼʱ��//out
        public string EndTime { get; set; }//ҵ��������ʱ��out
    }
    public class OneUserVolume
    {
        public string UserName { get; set; }
        public int Volume { get; set; }//ҵ����
    }
    public class BusinessVolumeQueryResult:CommonResult
    {
        public BusinessVolumeQueryResult()
        {
            Volumes=new List<OneUserVolume>();
        }
        public List<OneUserVolume> Volumes { get; set; }//list
    }
}