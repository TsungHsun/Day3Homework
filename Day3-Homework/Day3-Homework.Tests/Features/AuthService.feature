Feature: AuthService
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline:  Validate
	Given id is <id>
	And password is <password>	
	And ProfileDao is stub
	And ProfileDao's GetPassword will return <passwordFromDao>
	And Hash is stub
	And Hash's GetHash will return <hashResult>
	When I invoke Validate
	Then the result should be <result>

	Examples: 
	| scenario | id      | password | result | passwordFromDao | hashResult |
	| valid    | rickyho | 1234     | true   | ooxx            | ooxx       |
	| invalid  | rickyho | abc      | false  | ooxx            | xxxx       |
