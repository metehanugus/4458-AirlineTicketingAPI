# 4458-AirlineTicketingAPI
 21070006210 - SE4458 Midterm Project - AirlineTicketingAPI

### Project Overview
This project entails the development of a RESTful API for a fictitious airline company, designed to facilitate ticketing transactions through web services. Aimed at simulating real-world airline ticketing systems, the API allows clients to query available flights and purchase tickets, adhering to the principles of modern web service design and cloud-based deployment.

### Source Code Link
https://github.com/metehanugus/4458-AirlineTicketingAPI

### Project Design
**Architecture:** 
The project is structured using the ASP.NET Core framework, harnessing MVC (Model-View-Controller) architecture. This approach ensures separation of concerns, with distinct layers handling data (Models), business logic (Services), and user interactions (Controllers).

**Assumptions:**
- The user base will include both regular customers and administrative users.
- Flight data is pre-populated and managed by administrative users.
- Scalability and security are critical, considering the sensitivity of user and transaction data.

### Challenges and Issues:
- Implementing authentication and authorization mechanisms was challenging, requiring a careful approach to secure user credentials and transaction details.
- The integration of paging in flight queries posed initial difficulties, especially in balancing performance with accurate data retrieval.
- Managing the relational data model, particularly the associations between flights, tickets, and users, demanded meticulous attention to ensure data integrity.

### Data Model
The data model revolves around three primary entities:

**Flight:** Represents flight details, including flight number, departure, arrival, and date.
**Ticket:** Links flights to users, symbolizing ticket purchases. Each ticket is associated with one flight and one user.
**Users:** Contains user information, distinguishing between regular customers and administrative roles. Users can have multiple tickets.

These entities are interconnected, forming the backbone of the airline ticketing system. The **Flight** and **Ticket** models establish a many-to-one relationship, as multiple tickets can be issued for a single flight. Similarly, the **Users** and **Ticket** models form a one-to-many relationship, allowing a user to purchase multiple tickets.

#### Video Presentation
> [!NOTE]
> This section will be uploaded.

### Conclusion
This project has been a comprehensive exercise in applying theoretical knowledge to a practical scenario. It challenged my understanding of API development, data modeling, and cloud-based deployment, providing invaluable insights into real-world application development. The experience has significantly bolstered my skills in software engineering and data management.
