# Summary 
 2 projects, with Clean Architecture as the leading pattern of structure.  Best to use Visual Studio as it will automatically nest the files correctly. 

 1. Keesing.Technologies.Web - Uses a package Ardalis.ApiEndpoints, which is most useful to create clearer and feature based endpoints, which are clean ( Singular Respnsible, Low Coupled ), an alternative pattern that I have used previously and found very good at creating easily maintainable code is mediator and the MediatR package provides all the necessary parts to do this.
 2. Keesting.Technologies.Core - Defines the package with only the business related entity and ports/interfaces this library does not have any dependencies and is intended to be the center of the application with all other dependencies pointing inward toward it. 

 ## Shortcomings and Assumptions
 - No persistent store, there is only an in memory implementation that uses a static readonly List<>  
 - No tests, no unit tests or integration tests, but I would approach it with TestServer 
 - The swagger UI doesn't seem to be supporting Guid, but a couple of fetch commands via the Chrome Console shows all endpoints work.


# Assignment
- [x] Adding a new event - POST request should be created to add a new event. The API endpoint would be /calendar. The request body contains the details of the event. HTTP response should be 201. 
- [x] Deleting any event by id -  DELETE request to endpoint /calendar/{id} should delete the event. If the item does not exist return not found. 
- [x] Editing the event - PUT request to endpoint /calendar/{id}. If the item does not exist return not found. 
- [x] Getting all events - GET request to endpoint /calendar should return all the events in the system. The HTTP response code should be 200. If no event exists, return the empty array. 
- [x] Getting all events of the organizer - GET request to endpoint /calendar/query?eventOrganizer={eventOrganizer} should return the entire list of events organized by this organizer. The HTTP response code should be 200. For empty response return empty array. 
- [x] Getting event by id - GET request to endpoint /calendar/{id} should return the details of the event with this unique id. The HTTP response code should be 200. 
- [x] Sort the event as per the time - GET request to endpoint /calendar/sort should return the events sorted in descending order of time. 
- [x] Adding a new event - POST request should be created to add a new event. The API endpoint would be /calendar. The request body contains the details of the event. HTTP response should be 201. 
- [x] Deleting any event by id -  DELETE request to endpoint /calendar/{id} should delete the event. If the item does not exist return not found. 
- [x] Editing the event - PUT request to endpoint /calendar/{id}. If the item does not exist return not found. 
- [x] Getting all events - GET request to endpoint /calendar should return all the events in the system. The HTTP response code should be 200. If no event exists, return the empty array. 
- [x] Getting all events of the organizer - GET request to endpoint /calendar/query?eventOrganizer={eventOrganizer} should return the entire list of events organized by this organizer. The HTTP response code should be 200. For empty response return empty array. 
- [x] Getting event by id - GET request to endpoint /calendar/{id} should return the details of the event with this unique id. The HTTP response code should be 200. 
- [x] Sort the event as per the time - GET request to endpoint /calendar/sort should return the events sorted in descending order of time. 
