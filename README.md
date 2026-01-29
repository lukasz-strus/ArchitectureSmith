# ArchitectureSmith

ArchitectureSmith is a .NET 10 solution that helps you bootstrap a **Clean Architecture** project structure quickly and consistently.

It generates a multi-project layout (Core / External / Presentation) and uses the **DomainSmith** library in the **Domain** layer to model and enforce domain concepts.

## Goals

- Provide a ready-to-use **Clean Architecture** solution layout
- Keep the **Domain** independent and focused on business rules
- Make infrastructure (persistence, auth, etc.) **replaceable** via DI boundaries
- Enable incremental development (start empty, grow by adding modules)

## Solution Structure (high level)

Typical layers/modules in this repository:

- `src/Core/*`
  - Application-level code (use cases, orchestration, abstractions)
  - No infrastructure dependencies
- `src/External/*`
  - Infrastructure implementations (e.g., persistence, authentication, authorization)
- `src/*` (host)
  - Web host / API composition root (wires everything together)

## Dependency Injection

The application is composed in `Program.cs` by registering each module:

- `AddApplication()`
- `AddAuthentication()`
- `AddAuthorization()`
- `AddPersistence()`
- `AddPresentation()`

Each module exposes its own `DependencyInjection` entry point to keep composition clean and maintainable.

## DomainSmith

The **Domain** layer is built on top of the **DomainSmith** library to define rich domain models and protect invariants.

> Note: DomainSmith is expected to be referenced/used by the Domain project; expand the Domain model according to your needs.

## Getting Started

### Prerequisites
- .NET SDK 10

### Install template

```bash
dotnet new install ArchitectureSmith
```

### Create a new solution

```bash
dotnet new archsmith -n MyApp
```

Or without tests:

```bash
dotnet new archsmith -n MyApp --includeTests false
```

### Run
From the repository root:

```bash
dotnet restore
dotnet build
dotnet run --project src/ArchitectureSmith.Host
```

In Development, the app exposes OpenAPI:

- OpenAPI endpoint is enabled when `ASPNETCORE_ENVIRONMENT=Development`.

## Development Notes

- Add new infrastructure integrations in `src/External/*` and register them via the module `Add*()` method.
- Keep application contracts (interfaces) in `Core` and implementations in `External`.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.