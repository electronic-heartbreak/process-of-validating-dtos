# The process of validating data transfer objects at incoming requests

## Introduction

Data Transfer Objects, also known as DTO's, are often used to carry encapsulated data between processes. The main benefit is that it reduces the amount of data that needs to be sent across the wire in distributed applications.

A DTO may be used to (from [Microsoft](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio#prevent-over-posting)):

* Prevent over-posting.
* Hide properties that clients are not supposed to view.
* Omit some properties in order to reduce payload size.
* Flatten object graphs that contain nested objects. Flattened object graphs can be more convenient for clients.

The difference between data transfer objects and business objects or data access objects is that a DTO does not have any behavior except for storage, retrieval, serialization and deserialization of its own data.

## The problem

When a controller receives an HTTP POST request, the request data may have any shape. It needs to go from shapeless data to data with a schema (verified keys and types). Since DTO's should not contain business logic, it becomes more difficult to get to a valid and correct domain object that can, for example, be inserted into a database. Additionally, it is questionable as well on how the data should be validated. There is quite some discussion about this topic ([1](https://stackoverflow.com/questions/42280355/spring-rest-api-validation-should-be-in-dto-or-in-entity)), ([2](https://softwareengineering.stackexchange.com/questions/387763/should-i-validate-dtos-or-entities)), ([3](https://www.reddit.com/r/dotnet/comments/12tumni/confusion_about_whether_dtos_having_validation/)), but none of them give a clear solution, hence the reason of creating this repository. Having no validation in general is bad practice and is therefore not discussed in this repository. The following table gives an overview of possible validation scenarios:

| Data Transfer Object | Domain object |
|----------------------|---------------|
|           ✅          |       ❌       |
|           ✅          |       ✅       |
|           ❌          |       ✅       |
|           ❌          |       ❌       |

## Repository content
This repository contains a solution with multiple ASP.NET Core Web API projects demonstrating the different approaches of the validation process. The list down below gives a summary of all the projects in the solution with each a description. Every project has a `Product` and `CreateProductDto` class. The properties `InternalCode`, `CreatedAt`, and `IsDiscontinued` are not used, but these fullfil the purpose of using a DTO.

1. Full validation
- The project shows a DTO equipped with maximum data annotations. In the current situation the validation can create behavior and force the data to be in a certain shape. This is visible with for example.`SupplierEmail` where it has to be a valid e-mail, or with `Price` where it should be within the given range. Eventually the e-mail address can be validated if it comes from a certain domain. When the mapped domain object is not modified anymore, this approach *could* be enough. However, adding the same validation logic to the domain object can result in duplicate code and the urge to validate both the DTO and the domain object.
2. Lightweight validation
- This project gives an alternative to the full validation where only light validation rules are applied to the properties. This method recudes the chance of behavior in the DTO, and only shapes the data in such a way that certain data must be required or not. The problem remains that properties like `SupplierEmail` and `Price` should still be validated to prevent incorrect information to be processed. Since the controller's only purpose is to be a pass-through, the validation should not take place here. With a repository pattern a `create` function would exist to store the Product. Even this place is not suited for the job. This could mean that a new validation class could be created to handle the validation.
3. Fluent API validation
- FluentValidation is a .NET library for building strongly-typed validation rules. With this package, validation can be put on the domain object and in-depth validation at the DTO is not needed anymore. A possible service layer can receive the DTO, map it to the domain object, and finally be validated.
4. Extension method validation
- The extension method approach gives the `CreateProductDto` class an extra method which can *validate* the state of the DTO. The extension method approach gives the `CreateProductDto` class an extra method that can validate the state of the DTO. This approach adds functionality to the `CreateProductDto` without altering its original structure, making it easier to maintain and test the validation logic separately. By using extension methods, code can be kept clean and organized by encapsulating validation logic in a separate static class, ensuring that validation rules are applied consistently across the application.
## Feedback & contact
For contact or feedback purposes, feel free to leave an issue or reply to the thread on Discord.
