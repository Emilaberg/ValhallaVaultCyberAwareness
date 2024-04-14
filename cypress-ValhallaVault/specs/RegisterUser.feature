Feature: Register User

    Scenario: Register a new user
        Given I am on the register page
        When I fill in the form 
        And I press register button
        And I get send to the confirmation page
        And I press the link to confirm my account
        And I get send to the confirm email page
        And I press the Log in here button
        Then I get send to the login page
     
        