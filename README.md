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

When a controller receives an HTTP POST request, the request data may have any shape. It needs to go from shapeless data to data with a schema (verified keys and types). Since DTO's should not contain business logic, it becomes more difficult to get to a valid and correct domain object that can, for example, be inserted into a database. The main focus of this repository lies in the process of validating the DTO data, so it can be converted to the correlating domain object. By enough feedback, a new project will be created containing the feedback, giving others the oppertunity to follow this trend.

## Repository content
This repository contains a solution with multiple ASP.NET Core Web API projects demonstrating the different approaches of validating a DTO. The list down below gives a summary of all the projects with a description. Each project has a `Product` class and `CreateProductDto` class. The properties `InternalCode`, `CreatedAt`, and `IsDiscontinued` are not used, but these fullfil the purpose of using a DTO.

1. Full validation
- The purpose of this project is to show that a DTO equipped with maximized validation properties is not beneficial. In the current situation the validation can create behavior and force the data to be in a certain shape. This is visible with for example `SupplierEmail` where it has to be a valid e-mail or with `Price` where the it should be within the given range. With this approach it could be more valid to remove the DTO class and use the `Product` class instead and adjust what can be posted and returned.
2. Lightweight validation
- This project gives an alternative to the full validation where only light validation rules are applied to the properties. This method recudes the chance of behavior in the DTO, and only shapes the data in such a way that certain data must be required or not. The problem remains that properties like `SupplierEmail` and `Price` should still be validated to prevent incorrect information to be processed. Since the controller's only purpose is to be a pass-through, the validation should not take place here. With a repository pattern a `create` function would exist to store the Product. Even this place is not suited for the job. This could mean that a new validation class could be created to handle the validation.
3. Fluent API Validation
- FluentValidation is a .NET library for building strongly-typed validation rules. With this package, validation can be put on the domain object and in-depth validation at the DTO is not needed anymore. In the controller the mapped domain object can directly be validated, resulting in a correct domain object to be passed to an eventual `create` function which is located in a service class.
4. TODO

## Feedback & contact
For contact or feedback purposes, feel free to leave an issue or reply to the thread on Discord.
