# TicketApprentice

TicketApprentice is an app that allows users to purchase tickets to concerts/events at various venues. A user (preferrably an admin) has the ability to add their own venue, or create their own event!

A typical user can search for venues and purchase tickets for specific events. They have a lot of options when it comes to finding venues and events! They can search for venues by state, or search events by their date, and so on.

## Installation

To install TicketApprentice, simply clone the main branch from github into a local folder of your choice!
When the app is up and running, use a service like Postman to access these endpoints. 

## Usage

Use these endpoints to create/view/edit/delete venues, events, or tickets. See our [documentation](https://www.youtube.com/watch?v=iik25wqIuFo&ab_channel=Rickroll%2Cbutwithadifferentlink) for a more in-depth description of each endpoint and its requirements.

### Venues:
- GET api/Venue/state/{state} => returns all venues located in the specified state
- GET api/Venue/{id} => returns a single venue, specified by its id
- GET api/Venue => returns all venues
- POST api/Venue => creates a new venue
- PUT api/Venue => edits an existing venue
- DELETE api/Venue/{id} => deletes a venue, specified by its id

### Events:
- GET api/Event => returns all events
- GET api/Event/upcoming => returns all future events
- GET api/Event/{type}/{id} => the {type} can either be "e" or "v". If {type} is "e", then this will return a specific event by the specified id. If {type} is "v", then this will return all events located at the specified venue
- GET api/Event/date/{date} => returns all events that are scheduled for the specified date
- POST api/Event => creates a new event
- PUT api/Event => updates the specified event
- DELETE api/Event/{id} => deletes the specified event

### Tickets: 
- GET api/Ticket => returns all tickets
- GET api/Ticket/User/{id} => returns all tickets purchased by the specified user
- GET api/Ticket/Event/{id} => returns all tickets for a specific event
- GET api/Ticket/{id} => returns a specific ticket
- POST api/Ticket => creates a new ticket, this endpoint will be fired when a user purchases a ticket
- PUT api/Ticket => updates a ticket
- DELETE api/Ticket/{id} => deletes a ticket

## Contributing
Please do not submit any pull requests to this project. We intend to sell this as our own, completely original idea, and we expect to make a billion dollars off of it. 

## License
[RR](https://www.youtube.com/watch?v=iik25wqIuFo&ab_channel=Rickroll%2Cbutwithadifferentlink) License
