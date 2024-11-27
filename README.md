# InnoHackathon-ZhulegoFans-MeetUpNow

This project consists of two microservices: **EventService** and **ServiceOrganisation**. These services are built using **Onion Architecture** on the **.NET** platform, utilizing **Entity Framework** and **ASP.NET**. The project is designed to manage events and organizational data efficiently.

## Microservices

### 1. EventService

The **EventService** is responsible for managing the following entities:

- **Event**: Represents an individual event.
- **EventsTable**: A collection of events, providing a structured overview.
- **Place**: Details about the location of the events.
- **Purpose**: The objective or goal associated with the event.

#### Key Features

- Repository pattern for data access.
- Service layer for business logic.
- Controllers for handling HTTP requests.
- Swagger integration for API documentation.

### 2. ServiceOrganisation

The **ServiceOrganisation** manages organizational data and includes the following entities:

- **Employees**: Represents the staff within the organization.
- **Documentation**: Manages documents related to the organization.
- **Organization**: Represents the organization itself.

#### Key Features

- Repository pattern for data access.
- Service layer for business logic.
- Controllers for handling HTTP requests.
- Swagger integration for API documentation.

## Architecture

This project follows the **Onion Architecture** pattern, promoting separation of concerns and maintainability. The structure includes:

- **Repositories**: Interfaces for data access.
- **Services**: Business logic implementation.
- **Controllers**: API endpoints for client interaction.
- **Configurations**: Dependency injection and application settings.
- **DTOs**: Data Transfer Objects for communication between layers.
- **Mappers**: Object mapping between entities and DTOs.
