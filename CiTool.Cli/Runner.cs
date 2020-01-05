using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Text;
using System.Threading.Tasks;
using CiTool.Cli.Verbs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CiTool.Cli
{
    public class Runner
    {
        private readonly ILogger<Runner> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Runner(ILogger<Runner> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<int> Run(string[] args)
        {
            var root = new RootCommand();
            root.Add(_serviceProvider.GetRequiredService<TestVerb>());
            return await root.InvokeAsync(args);
        }
    }
}
