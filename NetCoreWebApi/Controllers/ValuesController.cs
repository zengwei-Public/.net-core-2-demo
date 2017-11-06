using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreIBLL;
using NetCoreModel;
using Microsoft.AspNetCore.Cors;
using AutoMapper;
using NetCoreWebApi.Models;

namespace NetCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSameDomain")]
    public class ValuesController : Controller
    {
        private readonly ITestBLL _testBLL;

        private readonly IMapper _mapper;
        public ValuesController(IMapper mapper,ITestBLL testBLL)
        {
            _mapper = mapper;
            _testBLL = testBLL;
        }

        [HttpGet("GetApiTest")]
        public string GetApiTest()
        {
            return _testBLL.TestMethod();
        }

        [HttpPost("PostApiTest")]
        public IActionResult PostApiTest([FromBody] TestViewModel model)
        {
            var model1 = _mapper.Map<TestViewModel,TestModel>(model);

            if (model1 == null || string.IsNullOrWhiteSpace(model1.Name))
                return Json(new ResultApiModel (){ IsSuccess = false, Message = "失败 model is null or model.Name is empty" });
            return Json(new ResultApiModel() { IsSuccess = true, Message = "成功" + model1.Name });
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
