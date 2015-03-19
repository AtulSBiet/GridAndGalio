Feature: Outline
	In order to avoid silly 
	As a search freak
	I want to be told the sum of two numbers
@test
Scenario Outline: Searching for more stuff
	Given I go to the startpage
	When I search for '<searchTerm>'
	Then I should be presented with the number of hits
	And I search for '<enNyKolumn>'
	Examples: 
	| searchTerm | enNyKolumn |
	| Bam        | Test12     |
	| Greger     | test2      |