using AMCodePipeline;
using AgentMesh.Runtime;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.Sources.Clear();
builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services
    .AddOptions<CodePipelineConfiguration>()
    .Bind(builder.Configuration.GetSection(CodePipelineConfiguration.SectionName))
    .Services
    .AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IOptions<CodePipelineConfiguration>>().Value);

AgentMeshRuntime.LoadAgentMesh<DefaultPipelinePlugin>(builder);

var app = builder.Build();
await AgentMeshRuntime.StartAgentMesh(app);