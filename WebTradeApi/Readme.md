### Web Trade Application Assignment - Vasile Irimia
##### _Development time spent = 2 workdays (~16h)_
  
### Solution includes:  
- C# .NET 3.1
- WebService - REST apis
- EF Core 3.1
- Postman collection: a JSON file included under root folder
- in memory DB - seed data is created before run
- unit tests
- Readme.md file

### Functionality for:  
- Inserting a new trade.
- delete of selected trade.
- Ability to update the market price of a security. - new endpoint
- Listing of all trades (optionally filtered by user).
- Listing of all portfolios.

### Assumption:
- For AAPL security code, the current Market Price = 10 (not specified)

### Decisions:
- Used Builder pattern for computed values (called by repository). 
- 3 controllers / services/ repositories: Trade, Portofolio & Market for low coupling & easier to extend future functionality
- For Update Market price - other good option is Observer pattern (first thought)