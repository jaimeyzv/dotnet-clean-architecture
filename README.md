## 🏗️ Clean Architecture with NET 9

## 📝 Description

Although I haven’t published a previous article on this topic, I’ve had the opportunity to work on several real-world projects — many of them based in the United States — where we implemented microservices using [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) principles.

<p align="center">
  <a 
    href="https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html" 
    target="blank"
  >
    <img 
      src="https://blog.cleancoder.com/uncle-bob/images/2012-08-13-the-clean-architecture/CleanArchitecture.jpg"
      width="75%" 
      alt="Nest Logo" 
    />
  </a>
</p>

I have over 10 years of experience working with .NET, from its .NET Framework versions to the first release of .NET Core, which I continue to use today under its current name, .NET 9.

I have found .NET to be the ideal platform for building structured, scalable, and maintainable applications. Its strong type system, mature ecosystem, and powerful tooling provide a solid foundation for delivering enterprise-grade solutions.

Coming from a background that values SOLID principles and object-oriented design, it has been natural to apply those principles when designing services, use cases, and domain models in .NET.

Like any architectural approach, Clean Architecture involves trade-offs. It’s important to strike the right balance, avoiding unnecessary complexity or over-abstraction, while maintaining flexibility and a clear separation of concerns.

In my projects, I have applied the concepts proposed by Robert C. Martin (Uncle Bob) and combined them with ideas from Hexagonal Architecture, Onion Architecture, and Screaming Architecture. The goal has always been to make the application resilient to change, especially given how often client requirements evolve (which, as we all know, is a certainty in software development).

## 🚀 About the project

This sample application represents a simplified **Online Loan Management System** backend, implemented as a **.NET 9 Web API**, that exposes services for managing loan operations and business rules.  

From the backend perspective, this system provides the following capabilities:

- Manage borrower registration and persist loan assignments through secure endpoints.  
- Handle loan installment scheduling with support for multiple repayment modalities (**Monthly**, **Weekly**, **Every 15 Days**).  
- Expose endpoints to query outstanding and completed installments per loan.  
- Implement business logic to calculate the total profit generated from issued loans.  
- Detect overdue installments and classify loans as delinquent for risk monitoring.  

Beyond loan domain functionality, this project also demonstrates the application of **Clean Architecture principles** in a backend environment — enforcing separation of concerns across **Domain**, **Application**, **Infrastructure**, and **Presentation** layers. It highlights patterns such as **CQRS with MediatR**, **dependency injection**, and **repository abstractions** to achieve modularity, scalability, and testability in the service layer.


## 📁 Project Structure

```bash
└───src
    ├───Core
    │   ├───Loans.Application
    │   │   ├───Repositories
    │   │   ├───Services
    │   │   └───UseCases
    │   │       ├───CreateLoan
	│   │       ├───GetAllLoans
	│   │       ├───GetInstallmentsByLoandId
    │   │       └───PayInstallment
    │   └───Loans.Domain
    │       ├───Entities
    │       └───ValueObjects
    ├───Infrastructure
    │   └───Loans.Infrastructure
    │       └───Persistance
    │           ├───Configurations
    │           ├───Context
    │           ├───Entities
    │           ├───Mappers
    │           ├───Repositories
    │           └───Services
    └───Presentation
        └───Loans.WebAPI
            ├───Controllers
            └───Extensions
```

## ⚙️ How to Run the Project

1. **Run the SQL script**  
   Execute the provided `.sql` file in **database scripts** folder to create and seed the database schema.

2. **Configure the connection string**  
   Open the `appsettings.json` file and locate the **ConnectionStrings** section.  
   Update the value of `Database` with your local connection string:

   ```json
   "ConnectionStrings": {
     "Database": "Server=localhost;Database=YourDbName;User Id=yourUser;Password=yourPassword;"
   }
	```
3. **Run the application**  
	You’re all set! Build and run the app.
	
## 🔗 Related Frontend Project
This backend pairs with the companion Angular 20 frontend. Together they form a complete full-stack system.	
Right below, you can see the **Angular 20 frontend** presentation layer that **consumes this Web API**.  

- [Online Loan Frontend (Angular)](https://github.com/jaimeyzv/angular-feture-based-architecture)
<p align="center">
	<img 
		src="https://github.com/jaimeyzv/dotnet-clean-architecture/blob/main/.project-ui-video/Online%20Loan%20Management%20System.gif"
		width="100%" 
		alt="Online Loan Management System - Demo" 
	/>
</p>


## 👤 About me

Hi, I am Jaime Zamora, a Software Engineer with over 13 years of experience. Throughout my career, I have designed and developed solutions across various domains, helping companies build scalable, maintainable, and high-quality software. I am passionate about applying clean architecture principles, sharing knowledge, and continuously improving my craft.

You can connect with me on:

- [LinkedIn](https://www.linkedin.com/in/jaimeyzv)
- [GitHub](https://github.com/jaimeyzv)
