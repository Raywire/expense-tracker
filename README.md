# Expense Tracker API Documentation

The Expense Tracker API is a RESTful web service that allows users to manage their personal expenses. It provides endpoints to add, retrieve, update, and calculate expenses. This documentation will guide you through the available API endpoints and their usage.

## Base URL

The base URL for all API endpoints is: `(https://localhost:****/swagger/v1/swagger.json)/api/v1`

## Authentication

Authentication is not required for accessing the Expense Tracker API endpoints.

## Available Endpoints

### 1. Add Expense

**URL:** `/expenses`

**Method:** `POST`

**Request Body:**

```json
{
  "description": "Expense description",
  "amount": 100.0,
  "date": "2023-05-24",
  "category": "Food"
}
```
**Response:**

- 201 Created: Expense successfully created.
- 400 Bad Request: Invalid expense data.

### 2. Get All Expenses
**URL:** `/expenses`

**Method:** GET

**Response:**

- 200 OK: Returns an array of expenses.

### 3. Get Expense by ID
**URL:** `/expenses/{id}`

**Method:** GET

**Response:**

200 OK: Returns the expense with the specified ID.
404 Not Found: Expense not found.
4. Update Expense
**URL:** `/expenses/{id}`

**Method:** `POST`

**Request Body:**
```json
{
  "description": "Updated description",
  "amount": 150.0,
  "date": "2023-05-25",
  "category": "Travel"
}
```
**Response:**

- 200 OK: Expense successfully updated.
- 400 Bad Request: Invalid expense data.
- 404 Not Found: Expense not found.

### 3. Get Total Expenses

**URL:** `/expenses/total-spent`

**Method:** `GET`

**Response:**
- 200 OK: Returns the total amount spent.
- Example Response Body:
```json
{
  "totalExpenses": 128,000,000,000.0
}
```
### 4. Get Monthly Spending
**URL:** `/expenses/monthly`

**Method:** `GET`

Query Parameters:

| param | type  | description                       |required   |   
|-------|-------|-----------------------------------|---|
| month | number   | It represents months of the year. | yes  |   

Response:

- 200 OK: Returns the total spending for the specified month.
- Example Response Body:
```json
{
  "month": 5,
  "totalSpending": 128,000.0
}
```
### 5. Get Expenses by Category
**URL:** `/expenses/category`

**Method:** `GET`

Query Parameters:

| param | type  | description                       |required   |   
|-------|-------|-----------------------------------|---|
| category | string  | Field of spending such as food, clothes etc. | yes  |   

Response:
- 200 OK: Returns an array of expenses matching the specified category.
- Example Response Body:
```json
  {
    "id": "72d1d59c-4092-47a7-9eaf-6b3367e6a4db",
    "description": "Test",
    "amount": 100.0,
    "date": "2023-05-24",
    "category": "Food"
  },
  {
    "id": "c7fd44dd-5cde-485f-8c81-55a710c2dc68",
    "description": "Description",
    "amount": 50.0,
    "date": "2023-05-25",
    "category": "Electronics"
  }
```

### 6. Update Expense

**URL:** `/expenses/{id}`

**Method:** `PUT`

**URL Parameters:**
- `id` (required): The unique identifier of the expense to update.

**Request Body:**
- The request body should contain the updated expense information in the following format:
```json
{
  "description": "Updated description",
  "amount": 50.0,
  "date": "2023-05-26",
  "category": "Drinks"
}
```
**Response:**

- 200 OK: Returns the updated expense object.
- Example Response Body:
```json
{
  "id": "72d1d59c-4092-47a7-9eaf-6b3367e6a4db",
  "description": "Updated description",
  "amount": 1000.0,
  "date": "2023-05-26",
  "category": "Clothes"
}
```
Error Responses:

- 404 Not Found: If the expense with the specified id is not found.
- 400 Bad Request: If the request body contains invalid expense data.


### 7. Get Monthly Expense Summary
**URL:** `/expenses/summary`

**Method:** `POST`

**Response:**
- 200 OK: Returns the summary of expenses for the specified month.
- 404 Not Found: No expenses found for the specified month.

## Error Handling
- 400 Bad Request: Indicates invalid request data or parameters.
- 404 Not Found: Indicates a resource (expense) was not found.
- 500 Internal Server Error: Indicates an unexpected server error occurred.

## Conclusion
The Expense Tracker API provides convenient endpoints to manage personal expenses. Use the provided API documentation to integrate the API into your applications and start tracking your expenses effortlessly.
