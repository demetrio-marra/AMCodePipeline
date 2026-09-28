## Why

AMCodePipeline describes its broad request paths in the README, but contributors still need to reverse-engineer the concrete agents, steps, parameter flow, and orchestration rules from source. A focused architecture reference is needed to make the plugin maintainable and extensible while preserving its relationship to AgentMesh.

## What Changes

- Add a versioned architecture document for AMCodePipeline that explains the plugin host, AgentMesh runtime integration, and configuration/prompt ownership.
- Document the agent catalog, including each agent's responsibility and its corresponding agentic workflow step.
- Document code-driven steps, their external service roles, and the parameter-store contracts that connect stages.
- Document the `ChatRequestPipeline` execution order, branch conditions, optional memory and domain-expert stages, and final-response path.
- Document the `SummarizationPipeline` flow and its relationship to conversation summarization and agent memory.
- Keep this change documentation-only; it does not modify runtime behavior, public APIs, prompts, configuration defaults, or AgentMesh contracts.

## Capabilities

### New Capabilities

None. This is a documentation-only change, and `.openspec.yaml` declares `skip_specs: true`.

### Modified Capabilities

None.

## Impact

- Documentation additions in the AMCodePipeline repository.
- Source used as the reference: the plugin host, agent and step implementations, pipeline orchestration, configuration, prompts, and public AgentMesh framework contracts.
- No production code, API, dependency, deployment, or behavior change.