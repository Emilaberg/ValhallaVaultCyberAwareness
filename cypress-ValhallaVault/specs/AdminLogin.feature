Feature: Login

Scenario: Login with valid  credentials

Given I am on the Login page
When I type "admin@mail.com" in ":nth-child(5) > .form-control"
And I type "Password1234!" in ":nth-child(6) > .form-control"
And I click the Login button
Then I should see a logout button
