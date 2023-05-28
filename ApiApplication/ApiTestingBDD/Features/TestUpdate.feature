Feature: Test Update Api Response 
	Call api and Update it response
@update
Scenario: Update User from Bdd
	Given I have api url and end points.
	When i call user from api and save it into the variable.
	Then i override the data i want to update.
	And i compare the data.