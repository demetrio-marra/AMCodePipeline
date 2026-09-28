## Context

See [proposal.md](proposal.md) for motivation. AMCodePipeline is an ASP.NET Core plugin that references `AgentMesh.Runtime`. Its host loads plugin-owned configuration, binds `CodePipelineConfiguration`, and delegates component discovery and HTTP startup to `AgentMeshRuntime`. The implementation contains two `EWPipeline` descendants, agent implementations based on AgentMesh `AbstractAgent<T>`, agentic and code-driven `IEWStep` implementations, typed parameter configurations, prompts, and settings for external services.

The existing README gives an entry-level overview, but not the concrete component relationships, step input/output contracts, branch predicates, or pipeline lifecycle needed to safely extend the plugin.

## Goals / Non-Goals

**Goals:**

- Add `docs/architecture.md` as the maintained AMCodePipeline reference for the plugin runtime boundary, components, and execution paths.
- Make every concrete agent, agentic step, and code-driven step discoverable by name, responsibility, and relevant pipeline placement.
- Explain the typed parameter-store model, including how AgentMesh snapshots step inputs, commits output mutations, and records agent token usage.
- Trace the chat request and summarization flows with explicit conditions derived from the pipeline source.
- Cross-link to the AgentMesh repository for framework-owned interfaces and runtime behavior.

**Non-Goals:**

- Do not duplicate AgentMesh implementation documentation or modify AgentMesh source.
- Do not reproduce system prompts, configuration secrets, model pricing, or every DTO/property definition.
- Do not change code, public API behavior, pipeline routing, configuration defaults, or deployment assets.

## Decisions

### Publish one focused architecture guide under `docs/`

The implementation will add `docs/architecture.md` rather than expanding the README into a long operational reference. The README will link to the guide from its architecture section.

This keeps the landing documentation concise and gives the detailed reference a stable, discoverable location. An OpenSpec artifact alone was rejected because it is planning history rather than user-facing project documentation.

### Organize the guide around execution boundaries

The guide will progress from plugin startup and AgentMesh contracts to typed parameters, agents and steps, then the two concrete pipelines. Agent/step coverage will use tables grouping request interpretation, memory, knowledge retrieval/reranking, task execution, response composition, and summarization.

This matches the execution model: an agent is invoked by an agentic step, while a code step coordinates deterministic service access or state transformation. A flat alphabetical listing was rejected because it obscures pipeline relationships.

### Derive data-flow documentation from declared parameter contracts

For each documented step, the guide will summarize `InputParameterTypes` and `OutputParameterTypes`, using parameter names and categories rather than serializing implementation details. It will explain that `EWPipeline` reads snapshots, executes a batch, and commits returned mutations through `IParameterStore` with version checks.

This is more durable and actionable than documenting incidental local variables. Copying every parameter class was rejected because it would add bulk without explaining the contract.

### Use source-derived flow diagrams and branch tables

The chat flow will show request analysis; conditional memory expansion/query; shared knowledge retrieval, reranking, and canonicalization; then small-talk, documentation, or task-execution paths. It will identify feature flags and data-dependent gates, including rejection, generated-code, execution-error, and result-data checks. The summarization flow will separately show conversation summarization and fact evaluation.

Mermaid diagrams plus tables are preferred because they retain a readable high-level sequence while recording conditions accurately. Narrative-only documentation was rejected because it makes branching and retries difficult to scan.

### Describe configuration by ownership and purpose

The guide will document the relationship among `appsettings.json`, named LLMs/inference providers, `Agents` entries, system-prompt files, external-service sections, and the `CodePipeline` feature flags. It will state that real credentials belong in deployment configuration and will not include values from the checked-in template.

This provides operational context without exposing secrets or duplicating the full template.

## Risks / Trade-offs

- [The component catalog drifts as source changes] -> Link each catalog section to the owning directory and make documentation updates part of changes that add agents, steps, pipelines, parameters, or configuration keys.
- [Framework details change independently of this plugin] -> Describe only the framework behavior relied on by AMCodePipeline and link to AgentMesh for the full contract surface.
- [Diagrams imply unsupported execution guarantees] -> Label feature-flag and parameter gates explicitly; describe parallel execution only as supported by the `EWPipeline` batch model, not as a claim that every current flow uses it.
- [Configuration examples expose secrets or become stale] -> Refer to section names and environment-variable overrides, never embed active credential values.

## Migration Plan

1. Add `docs/architecture.md` and link it from the README.
2. Verify all catalog entries and flow conditions against the current source and AgentMesh contracts.
3. Build the project to ensure documentation-only changes did not affect compilation.
4. Roll back by removing the new guide and README link; no runtime or data migration is required.