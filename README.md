**Klipp & Style Salon**

_Usage_  
The API can get all the bookings, create new bookings and delete a booking. 

_Project Description_  
A booking backend system for a hair salon. Database can be created through Entity Framework using the project.

_Purpose_  
This is an exercise in creating Minimal REST-API, validation and async programming. 

_Endpoints_  
GET  
URL: /bookings  
Description: Returns all the bookings in the database. Booking data include: Date, Time, Hairdresser, CustomerName, PhoneNr.

POST  
URL: /bookings  
Description: Receives booking information (JSON) in body to save as booking in the database. Requested data is: Date, Time, Hairdresser, CustomerName, PhoneNr.

DELETE  
URL: /bookings/{id}  
Description: Removes a booking from database by booking id. Id is necessary to find the booking and delete it in the system. 
