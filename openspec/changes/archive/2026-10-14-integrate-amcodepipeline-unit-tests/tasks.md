## 1. Test Project Setup

- [x] 1.1 Create `AMCodePipelineTests/AMCodePipelineTests.csproj` targeting `net8.0`, enable nullable and implicit usings, add the xUnit test SDK/runner packages, and reference `../AMCodePipeline/AMCodePipeline.csproj`; verify project restore succeeds.
- [x] 1.2 Add the test project to `AMCodePipeline.sln`; verify `dotnet sln AMCodePipeline.sln list` lists both application and test projects.

## 2. Deterministic Unit Tests

- [x] 2.1 Add `SourceCodeUtils.GetSourceCodeWithLineNumbers` tests for null input, line-ending handling, and line-number padding; verify the focused tests pass.
- [x] 2.2 Add `EWParameterDisplayUtils` tests for null/empty placeholders and representative non-empty list and memory display formatting; verify the focused tests pass without host startup or external services.

## 3. Solution Verification

- [x] 3.1 Run `dotnet test AMCodePipeline.sln`; verify the test project is discovered and all tests pass.
