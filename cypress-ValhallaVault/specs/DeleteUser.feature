Feature: Delete User

    Scenario: Deleting my account
        Given I am logged in
        When I press mitt konto  
        And I press personal data
        And I press delete button
        And I type in my password
        And I click the delete data button 
        Then I get redirect to login page