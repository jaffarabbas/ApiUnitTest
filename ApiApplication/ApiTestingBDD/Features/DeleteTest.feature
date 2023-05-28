Feature: Test Delete Api Response 
	Call api and Delete it response
@delete
Scenario: Delete User from Bdd
	Given i have api url and end points.
	When I call user from api and save it into the variable.
	Then i delete the data 
	And Then i check the data by fetching.