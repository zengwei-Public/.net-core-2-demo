using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebApi.Models;
using Microsoft.Extensions.Options;

namespace NetCoreWebApi.Controllers
{
    public class BaseController : Controller
    {
        //public BaseController(IOptions<AppSettingsModel> appSettings, IOptions<ConnectionsModel> connSettings)
        //{

        //}

        //public string GetSectionVal(string sectionName,IOptions<AppSettingsModel> settings)
        //{
        //    string v = "settings.Value." + sectionName;
        //    return v;
        //}

        //public string GetConnextionStr(string sectionName,IOptions<ConnectionsModel> settings)
        //{
        //    string v = "settings.Value." + sectionName;
        //    return v;
        //}
    }
}