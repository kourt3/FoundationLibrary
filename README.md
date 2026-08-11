# FoundationLibrary

**FoundationLibrary** is a reusable VB.NET library that provides common building blocks for .NET applications.

The goal of this project is to keep frequently used abstractions, generic components, and core functionality in one place, so they can be reused across multiple projects without duplicating code.

## Features

FoundationLibrary currently includes reusable components such as:

- Generic repositories
- Generic services
- Generic interfaces
- Common validation components
- Shared abstractions
- Reusable base classes

The library is designed to grow over time as new reusable functionality is identified.

## Project Structure

```text
FoundationLibrary
│
├── Interfaces
│   ├── IRepository.vb
│   ├── IService.vb
│   └── ...
│
├── Repositories
│   ├── Repository.vb
│   ├── DatabaseRepository.vb
│   └── ...
│
├── Services
│   ├── Service.vb
│   └── ...
│
│
└── Validation
    └── ...