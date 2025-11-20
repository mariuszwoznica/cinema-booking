# Cinema Booking System

The Cinema Booking System is designed to manage the process of booking movie tickets. It is a back-end implementation built as a **modular monolith** with **CQRS** and an **event-driven** approach. It is organized into independent modules, each encapsulating its domain logic:

* `Cinema` - managing cinemas.
* `Movies` - managing movies.
* `Pricing` - managing prices.
* `Booking` - representation of a lifecycle of a single customer's booking.
* `ShowTime` - managing seats avaibility for a particular showtime.
* `Payments` - integration with payment gateway.
* `Notifications` - customer notification of purchased tickets via email. 
* `Users` - managing users' identity.

The `ShowTime` module is built using **event sourcing**.

## Technologies

![Static Badge](https://img.shields.io/badge/.NET%2010-%238DEE59?style=for-the-badge)
![Static Badge](https://img.shields.io/badge/C%23-%238DEE59?style=for-the-badge)
![Static Badge](https://img.shields.io/badge/ASP%20.NET%20Core-%238DEE59?style=for-the-badge)
![Static Badge](https://img.shields.io/badge/EF%20CORE-%23D7EE59?style=for-the-badge)
![Static Badge](https://img.shields.io/badge/Dapper-%23D7EE59?style=for-the-badge)
![Static Badge](https://img.shields.io/badge/PostgreSQL-%23D7EE59?style=for-the-badge)
![Static Badge](https://img.shields.io/badge/Redis-%23FFB247?style=for-the-badge)
![Static Badge](https://img.shields.io/badge/Docker-%23FFB247?style=for-the-badge)
