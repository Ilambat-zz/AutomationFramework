Feature: JobProfileSearch

@mytag
Scenario Outline: [DFC-167 - A2 - 1] The "Next" pagination control is NOT shown if the last result is shown on the page
	Given I am on the homepage
	When I search for <term>
	Then there should be <CountOfProfiles> results
	And the Next pagination control is 'not shown'

	Examples: 
	| term  | CountOfProfiles |
	| nurse | 5               |  

Scenario Outline:[DFC-106 - A1] Display of total number of results found
	Given I am on the homepage
	When I search for <term>
	Then the correct text '<ResultText>' is displayed

	Examples: 
	| term         | ResultText                                              |
	| Nurse        | 7 results found                                         |
	| Dental Nurse | 1 result found                                          |
	| <>           | 0 results found - try again using a different job title |
