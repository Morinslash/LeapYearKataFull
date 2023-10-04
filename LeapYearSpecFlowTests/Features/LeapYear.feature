Feature: Leap Year Checker
As a user
I want to check whether a year is a leap year
So that I can know more about the year

    Scenario: Checking a non-leap year
        Given I am on the start page
        When I enter year '1997' into the input
        And I click the 'Check' button
        Then I should see a red banner
        And the banner should read 'This is not a Leap year!'