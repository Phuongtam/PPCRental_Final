Feature: UC2_ViewListProject
	In order to search all project
	As a agency of the website
	I want to search all project

@mytag
Scenario: I want to see the list of project on the screen
	Given I have enter the homepage
	And I have click login
	When I entered username and password
	And click submit
	Then the result should show the list of project on the screen 'PIS Top Apartment,ICON 56 – Modern Style Apartment,PIS Serviced Apartment – Boho Style'

