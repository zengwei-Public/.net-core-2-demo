using System;
using System.Collections.Generic;
using TmsCommonDataService;

namespace NetCoreIBLL
{
    public interface ITestBLL
    {
        string TestMethod();

        List<CustomsPortServiceModel> TestWcf();
    }
}
