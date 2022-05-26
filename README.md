# ClosestTransport

Running the application
The application can be run in Visual Studio or Visual Studio Code.
The application can also be run using the .net cli.

Testing can be done through Postman or Swagger which is already setup for the application.

The media type must be set to application/json

Request endpoint: https://localhost:5000/api/robots/closest

Request Body:
{
  "loadId": 222,
  "x": 21,
  "y": 33
}

Response:

{
  "robotId": "1212",
  "distanceToGoal": 12.8723872,
  "batteryLevel": 5
}

Next steps/features
If I were to continue, I would move the logic to calculate the closest robot into it's own class and also add unit tests around that logic.
More robust exception handling and handling of edge cases would also be a next consideration.
The addition of logging and perhaps a more robust http client implementation that can handle timeouts, retries and various failure states would be preferred.
