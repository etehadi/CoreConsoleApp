Feature: SampleService tests

@mytag
Scenario: Add two numbers
	Given the input value is <input>	
	When run an istance of ISampleService
	Then the result should be <result>
	Examples: 
	| input | result |
	| 1     | 1      |
	| 2     | 2      |