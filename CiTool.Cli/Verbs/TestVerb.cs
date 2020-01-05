using System.CommandLine;
using System.CommandLine.Invocation;
using Microsoft.Extensions.Logging;

namespace CiTool.Cli.Verbs
{
    public class TestVerb : Command
    {
        private readonly ILogger<TestVerb> _logger;

        public TestVerb(ILogger<TestVerb> logger)
            : base("test")
        {
            _logger = logger;
            AddOption(new Option("--project", "The project to be tested")
            {
                Argument = new Argument<string>()
            });

            Handler = CommandHandler.Create((string project) =>
            {
                Handle(project);
            });
        }

        private void Handle(string project)
        {
            _logger.LogInformation($"project: {project}");
        }
    }
}
