Feature: TestApi
	Call api and capre it response
@mytag
Scenario: Test a all user name from api
	Given I have api url and end point
	When I call all user from api and save it into the list
	Then i compare first user name with list first user object