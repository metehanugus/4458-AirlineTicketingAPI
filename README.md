# 4458-AirlineTicketingAPI
 21070006210 - SE4458 Midterm Project - AirlineTicketingAPI

### Project Overview
This project entails the development of a RESTful API for a fictitious airline company, designed to facilitate ticketing transactions through web services. Aimed at simulating real-world airline ticketing systems, the API allows clients to query available flights and purchase tickets, adhering to the principles of modern web service design and cloud-based deployment.

### Source Code Link
https://github.com/metehanugus/4458-AirlineTicketingAPI

### AZURE Web Page
https://metehanairline.azurewebsites.net/swagger/index.html (With SWAGGER UI) 

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

### TASK LIST
- [x] All REST services must be versionable. // In the project, the REST services have been implemented with versioning in mind, as evidenced by the use of the [ApiVersion("1.0")] annotation in the controller classes (FlightController.cs and UsersController.cs). This annotation is a clear indicator that the API endpoints in these controllers are designed to be versionable.
- [x] At least one service must support paging. // The GetFlights method in the FlightController class allows clients to specify a pageNumber and a pageSize.
The method applies these parameters to filter the results from the database, returning only a specific page of flights.
- [x] For authentication, JWT or Oauth can be implemented. Please check the examples from
class. // JWT is implemented in the project.
- [x] Must have Swagger UI or document
- [x] You can choose any development environment you like as long as they support REST
services. (Visual Studio 2022)
- [x] You can make assumptions as long as you document them
- [x] create a data model and use a database service from any cloud service you like
(preferably Azure + 10 points). Use local services if you cant. // SQL Database is created in Azure. We are using cloud service for saving our data.
- [x] For API hosting, use a cloud service (+10 points) or local application server service // Azure is used for API hosting. Check: https://metehanairline.azurewebsites.net/swagger/index.html
### DELIVERABLES
- [x] A readme document in your github code repo that has
- [x] code link to source code of the project i.e github, bitbucket
- [x] your design, assumptions, and issues you encountered.
- [x] Data model (i.e an ER)
- [x] Include a link to a short video presenting your project (+5 points if you store
video on a cloud storage service) (Uploaded on google drive: link will be here)
