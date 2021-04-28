Feature: Single User

@smoke
Scenario: Register a new player and check if it exist
	Given the user with email as "test@gmail.com" and password as "password123"
	When I register the user with given details
	Then I see the user is registered with email as "test@gmail.com"
	And password as "password123"