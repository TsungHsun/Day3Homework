Feature: LoginController
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Login Success
	Given login account is "rickyho"
	And user's password is "1234"	
	And AuthService is stub
	And AuthService.Validate return isValid is true
	When I invoke Index with HttpPost
	Then result's Controller name should be "Welcome"
	And result's Action name should be "Index"

Scenario: Login Failed
	Given login account is "rickyho"
	And user's password is "abc"	
	And AuthService is stub
	And AuthService.Validate return isValid is false
	When I invoke Index with HttpPost
	Then result's ViewBag Message should be "wrong account or password"