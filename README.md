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

When a controller receives an HTTP POST request, the request data may have any shape. It needs to go from shapeless data to data with a schema (verified keys and types). Since DTO's should not contain business logic, it becomes more difficult to get to a valid and correct domain object that can, for example, be inserted into a database. The main focus of this repository lies in the process of validating the DTO data, so it can be converted to the correlating domain object. By enough feedback, a new project will be created containing the fresh obtained information, giving others the oppertunity to follow this trend.

## Repository content
This repository contains a solution with multiple ASP.NET Core Web API projects demonstrating the different approaches of validating a DTO. The list down below gives a summary of all the projects with a description. Each project has a `Product` class and `CreateProductDto` class. The properties `InternalCode`, `CreatedAt`, and `IsDiscontinued` are not used, but these fullfil the purpose of using a DTO.

1. Full validation
- The purpose of this project is to show that a DTO equipped with maximized validation properties is not beneficial. As stated in a previous chapter, DTO's should not have any behavior. Even though the data annations are simple attributes, they show how the data should behave. For example with `SupplierEmail` where it has to be a valid e-mail or with `Price` where the it should be within the given range. With this approach it could be more valid to remove the DTO class and use the `Product` class instead and adjust what can be posted and returned.
2. Lightweight validation
3. Validation using Fluent API
4. TODO

## Feedback & contact
For contact or feedback purposes, feel free to leave an issue or reply to the thread on Discord.
