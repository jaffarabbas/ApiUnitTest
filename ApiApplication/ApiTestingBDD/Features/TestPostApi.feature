Feature: TestApiPostResponse
	Call api and post data then compare it response
@mytag
Scenario: [Test Post Responce After Posting Data In Api]
	Given i have api url and end point 
	When I Post User in the api
	Then I call that user by id
	And compare it responce 