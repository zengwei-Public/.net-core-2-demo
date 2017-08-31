using NetCoreIBLL;
using System;
using System.Collections.Generic;
using TmsCommonDataService;

namespace NetCoreBLL
{
    public class TestBLL: ITestBLL
    {
        public string TestMethod()
        {
            return "hello";
        }

        public List<CustomsPortServiceModel> TestWcf()
        {
            //不能配置url到config
            CommonDataServiceClient client = new CommonDataServiceClient();
            CustomsPortServiceSearchModel searchModel = new CustomsPortServiceSearchModel();
            searchModel.Nos = new List<string>() { "GZ001" };
            List<CustomsPortServiceModel> list =client.GetCustomsPortsAsync(searchModel).Result;
            return list;
        }
    }
}
