## Clean Architecture with NET 9

## Description

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

## About the project

The purpose of the sample project I am submitting is to demonstrate an online loan management system that supports repayment in monthly installments. It enables users to register borrowers, track loan details, view the total and remaining installments for each loan, and calculate the profit generated from each loan.

## Project Structure

```bash
└---src
    ├---Core
    |   ├---Loans.Application
    |   |   ├---Repositories
    |   |   ├---Services
    |   |   └---UseCases
    |   |       ├---CreateLoan
    |   |       └---GetInstallmentsByLoandId
    |   └---Loans.Domain
    |       ├---Entities
    |       └---ValueObjects
    ├---Infrastructure
    |   └---Loans.Infrastructure
    |       └---Persistance
    |           ├---Configurations
    |           ├---Context
    |           ├---Entities
    |           ├---Mappers
    |           ├---Repositories
    |           └---Services
    └---Presentation
        +---Loans.WebAPI
            +---Controllers
            └---Extensions
```

## About me

Hi, I am Jaime Zamora, a Software Engineer with over 13 years of experience. Throughout my career, I have designed and developed solutions across various domains, helping companies build scalable, maintainable, and high-quality software. I am passionate about applying clean architecture principles, sharing knowledge, and continuously improving my craft.

You can connect with me on:

- [LinkedIn](https://www.linkedin.com/in/jaimeyzv)
- [GitHub](https://github.com/jaimeyzv)
