# FlowCode

FlowCode is a .NET 9 library that provides a standardized way to handle operation results, encapsulating both success and failure states, along with any associated data or exceptions.

## Features

- **Generic Operation Result**: Handle results with or without data.
- **Exception Handling**: Encapsulate exceptions within operation results.
- **Implicit Conversions**: Easily convert exceptions and data to operation results.

## Benefits

### 1. Standardized Error Handling
FlowCode provides a consistent way to handle both successful and failed operations. By encapsulating exceptions and data within `OperationResult` objects, you can streamline error handling across your application.

### 2. Type Safety
The generic `OperationResult<T>` class allows you to return strongly-typed data from your operations. This ensures that the data type is known at compile time, reducing the risk of runtime errors.

### 3. Implicit Conversions
FlowCode supports implicit conversions from exceptions and data to `OperationResult` objects. This makes your code cleaner and more readable, as you can directly return data or exceptions without additional boilerplate code.

### 4. Improved Code Readability
By using `OperationResult` and `OperationResult<T>`, you make the intent of your methods clear. It becomes immediately obvious whether a method can fail and what type of data it returns upon success.

### 5. Centralized Exception Management
With exceptions encapsulated within `OperationResult` objects, you can centralize your exception handling logic. This makes it easier to log, analyze, and respond to errors in a consistent manner.

### 6. Enhanced Maintainability
The clear structure provided by FlowCode makes your codebase easier to maintain. New developers can quickly understand the error handling and data return patterns used throughout the project.

### 7. Compatibility with .NET 9 and C# 13.0
FlowCode is designed to leverage the latest features of .NET 9 and C# 13.0, ensuring that you can take advantage of modern language and framework capabilities.

### 8. Extensibility
The base `OperationResult` class can be extended to include additional metadata or functionality as needed, providing flexibility to adapt to specific project requirements.

## Installation

To install FlowCode, add the following package reference to your project file:


## Usage

### OperationResult\<T\>

The `OperationResult<T>` class is used to represent the result of an operation that returns data of type `T`.

#### Example
TODO

### OperationResult

The `OperationResult` class is used to represent the result of an operation that does not return data.

#### Example
TODO

## Properties

### OperationResult\<T\>

- `T Data`: The data returned by the operation.
- `bool IsSuccess`: Indicates whether the operation was successful.
- `Exception? Exception`: The exception thrown during the operation, if any.

### OperationResult

- `bool IsSuccess`: Indicates whether the operation was successful.
- `Exception? Exception`: The exception thrown during the operation, if any.