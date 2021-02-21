using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File;
using Serilog.Sinks.SystemConsole.Themes;
using Utility;
using Utility.AspNetCore;

namespace Shop.Product.Api
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;
        public static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
        public static void Main(string[] args)
        {
            DbConfig.Flag = DbFlag.MySql;
            //StartHelper.Start<Startup>("Shop.Product.Api", args);
            Console.Title = "Shop.Product.Api";
            IConfiguration configuration = LogHelper.Initial();
           // StartHelper.IsNew = true;
           StartHelper.CreateHostBuilder<Startup>(configuration, args).Run();
        }
    }
}
