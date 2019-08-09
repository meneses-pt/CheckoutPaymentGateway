# CheckoutPaymentGateway

This is the repository for the Challenge for the .NET Developer position at Checkout.com and below are the considerations about the given solution.

## Deliverables

- The API has two endpoints that can be reached at `https://localhost:44388/api/PaymentGateway`
- A `POST` request will make a Payment Request
- A `GET` request will get information about a previously made Payment Request

You can go to `https://localhost:44388/index.html` to see automatically generated documentation about the methods

## Extra Miles Bonus Points

### Application Logging

I used the NLog component to write application logs.
The application is configured to log to a file, but it can easily be changed using the `nlog.config` file

There are some specific logs that were made, for example when the methods in the Controllers raise an exception.

### Authentication

I integrated the application with the Auth0 platform for authentication purposes.
There is a sample application created there, so that you can get an Access Token to make the requests to the API.

Here is an example request for an Access Token:

```bash
curl --request POST \
  --url https://authwebapi.eu.auth0.com/oauth/token \
  --header 'content-type: application/json' \
  --data '{"client_id":"jsJn0PVv7cPg9dVV94NjQW3Fc1L2NDbD","client_secret":"49Jp4JTXFw09HP-zr9Xgff5p2Q3C_sFmEKcGw4NYrWhhnpiW5GGbZojvvDir4z_M","audience":"http://checkoutpaymentgateway.meneses.pt","grant_type":"client_credentials"}'
```

You can then use the obtained Access Token and pass it as a `Bearer` to access the API.
I set two roles: one for making payment requests and another for getting its information. This Access Token will grant you permission for both of them.

### API Client
I have made a very simple API Client to make requests to the API.
Using the Auth0 created client, it gets an Access Token for each Request to the API.

There are two endpoints you can use:

- `https://localhost:44390/Info`
- `https://localhost:44390/Request`

### Build Script/CI

In the folder Scripts you will find three scripts:

- `build_solution.ps1`: Build the solution
- `test_solution.ps1`: Runs the Unit Tests of the solution
- `run_update_db.ps1`: Receives an SQL Server Database Connection String and runs all the DB Scripts (creating or updating the database structure)

### Encryption

The API is configured to use HTTPS which will encrypt the communication between the client and the API

### Data Storage

An initial solution was made saving the Payments Information in a memory object.
The API easily permits that another storage type (implementing the same Interface) can be used.
Having this in consideration, a simple database structure was created and the data is saved and retrieved using EntityFramework.

### Another considerations

There is not a lot of data validation, either on the API and in the client because I thought that was not the main purpose. I focused more in trying to build a flexible and scalable solution where changes and improvements can be easily made.
Please feel free to contact me if you have any questions.