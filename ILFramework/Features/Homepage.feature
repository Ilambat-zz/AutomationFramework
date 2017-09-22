Feature: Homepage

@mytag
Scenario Outline: Check NCS HomePage
	Given I am on the homepage
	When I search for <term>
	Then the user is redirected to the search page
	And the search box is displayed

	Examples: 
	| term  |
	| nurse |
