# AML Fuzzy vs Traditional Demo

Compares traditional rule-based AML detection with fuzzy logic scoring.

## Structure

- `src/TraditionalAmlEngine` — Binary yes/no detection using hard thresholds
- `src/FuzzyAmlEngine` — Weighted risk scoring with fuzzy logic
- `src/DemoApp` — Console app comparing both approaches
- `tests/` — xUnit tests for both detectors

## Run

```bash
dotnet run --project src/DemoApp
```

## Test

```bash
dotnet test tests
```
