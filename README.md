### Technical Test README

This repository contains a sample application developed as part of a technical test, demonstrating knowledge of ASP.NET Core MVC, MediatR, CQRS pattern, and layered architecture.

#### Overview

The application is a Candidate Management System, allowing users to perform CRUD (Create, Read, Update, Delete) operations on candidate records and their experiences. It follows a layered architecture with separate projects for Web, Business logic, Domain, and DataAccess.

#### Prerequisites

- .NET 8 SDK or later
- Visual Studio 2022 or Visual Studio Code
- SQL Server or another database management system

#### Getting Started

1. Clone the repository to your local machine.
2. Open the solution in Visual Studio or Visual Studio Code.
3. Select the `TechnicalTest.MVC.Web` project in initial project to run or https.
4. Build and run the application.

#### Features

- **Candidate**: Create, read, update, and delete candidate records.
- **Candidate Experience**: Create, read, update, and delete experiences associated with candidates.
- **Layered Architecture**: Separation of concerns with distinct projects for different layers of the application.
- **MediatR and CQRS**: Implementation of the Mediator pattern using MediatR library for decoupling requests from handlers.
- **InMemory Database**: Utilization of an InMemory database for easy setup and testing.

#### Project Structure

- **TechnicalTest.MVC.Web**: ASP.NET Core MVC project serving as the presentation layer.
- **TechnicalTest.Business**: Business logic layer containing application services and business logic.
- **TechnicalTest.Data**: Data layer containing domain models and DTOs.
- **TechnicalTest.Infrastructure**: Infrastructure layer containing implementations for data access and external services. Command and query handlers are managed here.
- **TechnicalTest.DataAccess**: Data access layer containing the database context and handlers for each command or query.

#### Usage

1. Candidate Management:

   - Navigate to the `/Candidate` route to view a list of candidates.
   - Click on a candidate to view details, edit, or delete.
   - Use the "Create" button to add a new candidate.
   
2. Experience Management:

   - To add an experience for a candidate, navigate to the candidate details page and click on "Create Experience".
   - Fill out the form with experience details and click "Save".
   - Experiences can be edited or deleted from the candidate details page.

#### Contributions

Contributions to the project are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request.

#### License

This project is licensed under the MIT License.

#### Contact

For any inquiries or questions, please contact [kevin.robles@me.com].