using Microsoft.Extensions.Options;
using NetCoreIBLL;
using NetCoreModel.Base;
using System;
using System.Collections.Generic;
using TmsCommonDataService;

namespace NetCoreBLL
{
    public class TestBLL: ITestBLL
    {
        private readonly IOptions<ConnectionsModel> _connSettings;
        public TestBLL(IOptions<ConnectionsModel> connSettings)
        {
            _connSettings = connSettings;
        }

        public string TestMethod()
        {
            

            return "ConnShangPinTms：" + _connSettings.Value.ConnShangPinTms+"，hello";
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
