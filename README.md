# Coding Challenge: Implement a RESTful JSON API

## Introduction

In this technical test, you will be tasked with building a RESTful JSON API that supports the basic CRUD (Create, Read, Update, Delete) operations. We ask that you make use of the Mediator Pattern and store results using SQL and Entity Framework.

## Requirements

The API should be able to:

1. Add new records to the database
2. Edit existing records in the database
3. Delete records from the database
4. Read and return records from the database

You should ensure that your solution:

- Makes use of the Mediator Pattern
- Utilises SQL for data storage
- Utilises Entity Framework as an ORM (Object-Relational Mapping)
- Includes both unit and integration tests

## Setup

1. Please fork this repository to your own GitHub account.
2. Complete the project within your forked repository.
3. Once you're done, please submit a pull request.

## Project Structure

You are free to structure your project as you see fit, but we recommend the following:

- A separate project for the API
- A separate project for the tests
  - Inside the test project, separate folders for unit and integration tests
- A separate project for the data access layer
- Use MediatR or a similar library for implementing the Mediator pattern

## Submission

Please include the following in your submission:

1. Source Code: All source code written for this project.
2. Readme: A README.md file explaining how to run your project, your thought process, the architecture you used, etc.
3. Tests: Unit and integration tests for the API.
4. If possible, please include a Postman collection (or similar) with example requests for each endpoint.

## Evaluation

Your submission will be evaluated on:

- Code cleanliness and organisation
- Functionality of the API
- Coverage and quality of the tests
- Documentation and explanation of your process and design decisions

## Tips

- Try to write clean, modular, and self-documenting code.
- Include comments where necessary, but try to make the code explain itself.
- Make sure your tests cover a reasonable range of cases and edge cases.

Good luck! We're excited to see what you come up with.
