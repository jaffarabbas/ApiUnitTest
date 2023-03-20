Feature: TestApiSingleResponce

Call api and compare it single response

@tag1
Scenario: Test single user name from api with Spesific Id
	Given I have api url and end points
	When I call all user from api and save it into the variable
	Then i compare user name with user object name
