## 1. Establish the Architecture Guide

- [x] 1.1 Create `docs/architecture.md` with the plugin-host startup sequence, `DefaultPipelinePlugin` discovery role, and AgentMesh Runtime boundary; verify each statement against `Program.cs`, `DefaultPipelinePlugin.cs`, and the public AgentMesh contracts.
- [x] 1.2 Document the typed parameter-store execution model, including snapshots, output mutations, version-checked commits, workflow notifications, and agent token statistics; verify it against `EWPipeline` and `IEWStep`/`IEWAgenticStep`.
- [x] 1.3 Add a configuration and prompt-ownership section covering `Agents`, LLM/provider mappings, system-prompt files, external-service settings, and `CodePipeline` flags without exposing credentials; verify all referenced section names exist in `appsettings.json` or `CodePipelineConfiguration`.

## 2. Document Components and Flow

- [x] 2.1 Add an agent and agentic-step catalog that maps every concrete agent to its corresponding `IEWAgenticStep`, responsibility, inputs, outputs, and pipeline usage; verify the catalog against `Services/Agents` and `Services/EWSteps`.
- [x] 2.2 Add a code-step catalog for memory, knowledge retrieval, query transformation, and JavaScript sandbox integration, including their parameter contracts and external-service boundaries; verify it against the relevant `Services/EWSteps` implementations.
- [x] 2.3 Add a Mermaid flow diagram and branch-condition table for `ChatRequestPipeline`, including small-talk, documentation, task-execution, rejection, memory, generated-code, execution-error, and domain-expert gates; verify each sequence and condition against `ChatRequestPipeline.cs`.
- [x] 2.4 Add the `SummarizationPipeline` sequence and its summarization/fact-evaluation relationship to agent memory; verify step ordering and rerun behavior against `SummarizationPipeline.cs`.

## 3. Integrate and Validate Documentation

- [x] 3.1 Link the README architecture section to `docs/architecture.md` and ensure the guide links to the AgentMesh framework repository where framework behavior is owned; verify both links resolve in repository Markdown rendering.
- [x] 3.2 Review the guide against the current source to confirm every documented concrete pipeline, agent, and step is covered and no undocumented runtime behavior is asserted; verify with a component-name comparison of the documented catalog against the implementation directories.
- [x] 3.3 Run `dotnet build AMCodePipeline/AMCodePipeline.csproj` and verify the documentation-only changes leave the project build successful.