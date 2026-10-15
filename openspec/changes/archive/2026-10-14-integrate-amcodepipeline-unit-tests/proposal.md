## Why

The AMCodePipeline solution currently contains only the application project, so deterministic logic has no automated unit-test home and cannot be exercised through the solution's normal test workflow. Adding a dedicated test project makes those checks discoverable and repeatable without requiring external services.

## What Changes

- Add an xUnit test project under the solution-root `AMCodePipelineTests/` directory, targeting .NET 8 and referencing the application project.
- Add the test project to `AMCodePipeline.sln` so solution-level test runs discover it.
- Add focused unit tests for deterministic public utilities, starting with source-code line formatting and parameter display formatting.
- Keep tests isolated from network services and host startup.

## Capabilities

### New Capabilities

None. This change adds test infrastructure and does not introduce runtime behavior.

### Modified Capabilities

None.

## Impact

The solution file and a new `AMCodePipelineTests/` test project are affected. The application project remains unchanged; no production API or runtime dependency changes are planned. The solution should support running the new tests with `dotnet test AMCodePipeline.sln`.
