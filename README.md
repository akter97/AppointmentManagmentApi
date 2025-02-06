# Basic Appointment Management API with Authentication

## Objective

This project is a simple RESTful API built with **ASP.NET Core** for managing patient appointments in a healthcare clinic. The API includes **JWT authentication** to ensure only authorized users can access or modify the data.

## Features

- **User Authentication (Register & Login)**
- **JWT-based Authentication**
- **CRUD Operations for Appointments**
- **Entity Framework Core with MSSQL Database**
- **Input Validation & Error Handling**
- **API Testing using Postman/NUnit/XUnit**
- **Secure Password Hashing with ASP.NET Core Identity**

---

## Endpoints

### **User Authentication**
#### **Register a User**
- **POST** `/register`
- Registers a new user with a username and password.

#### **Login**
- **POST** `/login`
- Accepts a username and password and returns a JWT authentication token upon successful login.

---

### **Appointment Management (Requires Authentication Token)**

#### **Create an Appointment**
- **POST** `/appointments`
- Accepts the following details:
  - Patient Name
  - Patient Contact Information
  - Appointment Date & Time (must be in the future)
  - Doctor ID

#### **Get All Appointments**
- **GET** `/appointments`
- Returns a list of all appointments.

#### **Get Appointment by ID**
- **GET** `/appointments/{id}`
- Retrieves the details of a specific appointment.

#### **Update an Appointment**
- **PUT** `/appointments/{id}`
- Allows updating appointment details such as date, time, or doctor ID.

#### **Delete an Appointment**
- **DELETE** `/appointments/{id}`
- Deletes an appointment by ID.

---

## **Data Model**

### **User**
- `UserID`  
- `Username`
- `Password`  

### **Doctor**
- `DoctorID` 
- `DoctorName`

### **Appointment**
- `AppointmentID` 
- `PatientName`
- `PatientContactInfo`
- `AppointmentDateTime`
- `DoctorID`

---

## **Authentication**
- Uses **JWT (JSON Web Token)-based authentication**.
- Requires the **token to be included** in the Authorization header for all appointment-related endpoints.

---

## **Technology Stack**
- **ASP.NET Core**  
- **Entity Framework Core**  
- **MSSQL Database**
- **JWT Authentication**
- **ASP.NET Core Identity**

---

 
### **1. Clone the Repository**
###  Configure the Database
- ** Update the appsettings.json file with your MSSQL database connection string.**

### Run Migrations 
- dotnet ef migrations add InitialCreate
- dotnet ef database update
### Run the Application
 
**dotnet run**

*Gir Included DataBase*
 
