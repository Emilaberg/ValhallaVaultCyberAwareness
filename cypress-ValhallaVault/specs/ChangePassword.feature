Feature: Change Password

    Scenario: Change the user accounts password
        Given I have logged in
        When I press my account  
        And I press password
        And I fill in the password form
        And I press update password
        Then I should get a message that the password is updated