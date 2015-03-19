Feature: Number of hits 
		In order to be able to see how many hits I got 
		As a search freak
		I want to see the number of hits

Scenario: viewing number of hits
		Given I go to the startpage
		When I search for 'Half life 3' 
		Then I should be presented with the number of hits

Scenario: viewing number of hits for doom
		Given I go to the startpage
		When I search for 'Doom 3' 
		Then I should be presented with the number of hits

