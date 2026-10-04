# Travel Booking System (with Identity)

An ASP.NET Core travel booking app with sign up and login. Users book travel packages, and an admin approves or rejects each booking. It extends an earlier Travel Booking System by adding authentication and role-based dashboards.

## Features

- **Sign Up and Login** pages using ASP.NET Core Identity
- Two roles: **Admin** and **User**. The roles and a default Admin account are created automatically when the app starts, and new sign-ups get the User role
- **User Dashboard:** browse travel packages and make bookings (new bookings start as `Pending`)
- **Admin Dashboard:** see all bookings and approve or reject each one
- The booking status updates in the database and shows on the user's dashboard
- After login, users and admins are sent to their own dashboards

## Architecture

| Part | Role |
|---|---|
| Models | `TravelPackage` and `Booking` (with a `BookingStatus` column) |
| Data | `ApplicationDbContext` connects the app to SQL Server |
| Service layer | `TravelService` holds the booking logic, behind the `ITravelService` interface |
| Controller and Views | `TravelController` with Razor views for packages, details, booking and success pages |
| Identity pages | Razor Pages for Login and Register |

## Concepts Used

- **ASP.NET Core Identity:** `UserManager` and `SignInManager` handle users and login
- **Role-based authorization:** `[Authorize(Roles = "Admin")]` and `[Authorize(Roles = "User")]` protect the dashboards
- **Service layer with an interface:** keeps business logic separate from controllers
- **Entity Framework Core with SQL Server:** stores users, roles, packages and bookings
- **Role seeding:** roles and the default admin are created at startup

## Booking Status

| Status | Meaning |
|---|---|
| Pending | Default when a user makes a booking |
| Approved | The admin accepted the booking |
| Rejected | The admin declined the booking |

## Built With

- C#
- ASP.NET Core
- ASP.NET Core Identity
- Entity Framework Core
- SQL Server
- Razor Pages and Views

## About

Made for the Web Technologies course (SEF23), Homework 07, at the University of the Punjab.
