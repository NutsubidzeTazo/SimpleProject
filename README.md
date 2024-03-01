Project sample was written roughly in 3-4 hours.

Packages used in project: 
Pomelo.EfCore.MySql 7.0.0 , 
MySql.Data 7.0.0, 
Athentication.JwtBearer 7.0.16.

Project Version : .NET 7.0

Project consists simple endpoints where logic is written inside controller's actions. no patterns used, for example repository pattern. 

In near future I am planning to add UnitTests, Exception handlers using middleware, After this I am planning to write clean code and abstract away some "things", reconstruct architecture using Onion Architecture (Clean Architecture) for studying reasons. I have some basic experience but never created Onion architecture from scratch.

few steps to keep in mind to run application:

1.In order to start application you have to setup MySql server, then you have to fill Appsettings ConnectionStrings and run migrations. (Code first database)

2.Register account using api/v1/users/register endpoint, returns user entity. remember Id Property for later usage. ("v1" stands for versioning, "users" is controller, "register" actionName)

2.After registration  you have to use api/v1/users/authenticate endpoint, it returns token which we are going to use on actions which has authorize attributes.

3.After authentication you have to create Event (ex : football match event) using api/v1/events/event endpoint which returns event entity, remember event Id for upcoming method.(dont forget to write token in Authorize panel in swagger, you dont have to write Bearer prefix)

4.After creating event if you want to place a bet use api/v1/bets/place endpoint. you have to give this method your userId and EventId from previous response from an endpoint. (request model has other properties too such as money "Amount" and etc.)


I did not explain Request Models because it is shown in swagger.
