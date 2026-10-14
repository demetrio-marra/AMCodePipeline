## Context

See proposal.md for motivation. `AMCodePipeline.sln` currently contains only `AMCodePipeline/AMCodePipeline.csproj`, a `net8.0` Web SDK project. It has no local shared test props or test project. The neighboring AgentMesh solution uses xUnit and .NET 8, but its package references are supplied by shared test props that are not present here.

## Goals / Non-Goals

**Goals:**
- Make the test project independently restorable and discoverable through the solution.
- Exercise stable, deterministic behavior without starting the web host or contacting configured services.

**Non-Goals:**
- Add integration, endpoint, provider-connectivity, or external-service tests.
- Introduce a shared test-support project, coverage gate, or changes to production visibility.

## Decisions

### Keep the test project beside the application project

Create `AMCodePipelineTests/AMCodePipelineTests.csproj` at the solution root, as requested, and reference `../AMCodePipeline/AMCodePipeline.csproj`. Add it to `AMCodePipeline.sln`. This keeps all test project files together while retaining the existing application folder layout; placing tests under the application folder was rejected because it would not satisfy the requested subdirectory placement.

### Use a self-contained .NET 8 xUnit project

Target `net8.0`, enable nullable reference types and implicit usings, and declare `Microsoft.NET.Test.Sdk`, `xunit`, and `xunit.runner.visualstudio` in the test project. This follows the available neighboring convention without depending on build props from another repository. Do not add a mocking framework or coverage collector until a concrete test requires one; deterministic utility tests need neither.

### Start at deterministic public boundaries

Add focused tests for `SourceCodeUtils.GetSourceCodeWithLineNumbers` and `EWParameterDisplayUtils` formatting methods, including null/empty input and representative non-empty formatting. These methods are public and can be exercised directly. Workflow and agent tests can be added later when an isolated behavior and its fake dependencies are identified; invoking the host or real service clients is outside this unit-test foundation.

## Risks / Trade-offs

- [The application project brings transitive runtime dependencies into test restore] → Reference only the application project and avoid contacting its external services from tests.
- [The initial test set does not cover orchestration behavior] → Keep the first scope deliberately deterministic; expand tests in later changes around explicit seams and fake boundaries.
- [Package availability may depend on configured NuGet sources] → Use the solution's existing NuGet configuration and verify restore and `dotnet test AMCodePipeline.sln` during implementation.

## Migration Plan

No runtime migration is required. The test setup can be rolled back by removing the test project and its solution entry; production code and deployment behavior remain unchanged.
