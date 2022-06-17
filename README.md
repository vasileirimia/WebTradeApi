## WebTradeApi
- Web Trade Application Exercise (trades & portofolios)
- Development time spent: ~2 days
  
### Solution components:  
- C# .NET 3.1 - KISS
- WebService - REST apis
- EF Core 3.1 - in memory DB - seed data is created before run
- unit tests
- Postman collection: a JSON file included under root folder
- Readme.md file

### Functionality for:  
- Inserting a new trade
- Delete of selected trade
- Ability to update the market price of a security - new endpoint
- Listing of all trades (optionally filtered by user)
- Listing of all portfolios

### Assumption:
- For AAPL security code, the current Market Price was set to 10 (not specified in requirements)

### Decisions:
- Used Builder pattern for computed values (called by repository) - ext ensibility, reusability. 
- 3 controllers / services / repositories: Trade, Portofolio & Market for low coupling & easier to extend future functionality
- For Update Market price - other good option is Observer pattern (first thought)
- Error midleware included
- Model Validation included

### Other future improvements (not included):
- solution can be improved but requires more time
- more unit tests could be added (integration tests for add, update actions)
- Performance - caching
