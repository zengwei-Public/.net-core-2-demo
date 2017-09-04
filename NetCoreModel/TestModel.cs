using System;

namespace NetCoreModel
{
    public class TestModel
    {
        public string Name { get; set; }
    }

    public class ResultApiModel
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}
