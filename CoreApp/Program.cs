using Autofac;
using NetCoreBLL;
using NetCoreIBLL;
using System;
using System.Reflection;

namespace CoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetType().GetTypeInfo().Assembly
            var builder = new ContainerBuilder();
            //var an = new AssemblyName("NetCoreBLL, Version=1.0.0.0, Culture=neutral, " +
            //            "PublicKeyToken=b03f5f7f11d50a3a, processor architecture=MSIL");
            builder.RegisterAssemblyTypes(Assembly.Load("NetCoreBLL")).Where(t => t.Name.EndsWith("BLL")).AsImplementedInterfaces();

            var container = builder.Build();

            //ITestBLL bll = new TestBLL();
            //Console.WriteLine(bll.TestMethod());
            Console.WriteLine("Hello World!");
        }
    }
}
