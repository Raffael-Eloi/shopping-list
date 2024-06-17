# Shopping List API 🚀

## Overview 💡
Welcome to the Shopping List API! This .NET-based API provides a comprehensive solution for managing a shopping list with various features for both customers and store managers. It allows customers to browse products, add items to their cart, and make purchases, while store managers can manage promotions, monitor inventory levels, and receive email notifications.

## Features 🔑
### Customer Features 
- **Browse Products**: View a wide range of products available in the store.
- **Product Details**: Access detailed information about each product.
- **Add to Cart**: Easily add items to your shopping cart.
- **Purchase Items**: Complete purchases efficiently.
- **Rate and Review Products**: After purchasing, provide feedback through ratings and reviews. This helps other shoppers and gives insights to the store manager.

### Store Manager Features
- **Manage Promotions**: Create and update promotions to attract customers.
- **Inventory Management**: Receive email alerts when stock levels are low, enabling timely restocking.
- **Order Confirmation**: Customers receive prompt email notifications confirming their order details.

## Requirements 🛠️
- **FluentValidation**: For validating inputs and ensuring data integrity.
- **Quartz.NET**: For scheduling and managing background jobs.
- **Serilog**: For structured logging to keep track of application events.
- **FakeItEasy**: For creating mocks in unit tests.
- **FluentAssertions**: For writing readable and maintainable test assertions.
- **MailKit**: For handling email functionalities (IMAP, POP3, SMTP).
- **Autofac**: For managing dependency injection with Inversion of Control (IoC).
  
## Event Storming
You can access <a href="https://miro.com/app/board/uXjVNdfSw8k=/?share_link_id=981039779858" target="_blank">here</a>.

## Domain Storytelling - Diagrams

## Ubitiquous language - Dictionary

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
