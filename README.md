# HelloWorld.NetCoreApi

This app is very basic .NET Core Web API created purely for testing various hosting scenarios.

## Supported resources
## GET /api/user
### Parameters:
* name (string, optional) - when provided, method returns "Hello {name}", otherwise returns "Hello World"

### Sample requests
* _http://localhost:5000/api/user_ => Hello World
* _http://localhost:5000/api/user?name=Matt_ => Hello Matt