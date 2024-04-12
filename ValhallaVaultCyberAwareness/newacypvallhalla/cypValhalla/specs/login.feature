# "Feature" is a description of the functionality that the software should have.
Feature: Login
    # The user story follows the format: As a [role], I want [goal], so that [benefit].
    # As a user
    # I want to be able to log in to my account
    # So that I can access my personalized content

# "Scenario" is a concrete example that illustrates a business rule. It consists of a series of steps.
Scenario: Successful login
    # "Given" steps set up the initial context - the scene of the scenario.
    Given I am on the login page
    # "When" steps describe an event, or an action. This is something that happens that will cause an outcome.
    When I enter my email "test@example.com" and password "Password!1"
    # "And" steps are used for readability - they can be used as a "Given", "When", or "Then" step.
    And I click "The login button" with selector "body > div:nth-child(1) > main > article > div > section > div > div > form > div:nth-child(8) > button"
    # "Then" steps describe an expected outcome, or result.
    Then I should be redirected to the home page

Scenario: User forgets password
    Given I am on the login page
    When I click the "Forgot your password?" link
    And I enter my email "test@example.com"
    And I click the "Submit" button
    Then I should be redirected to the forgot password page

Scenario: User resends email confirmation
    Given I am on the login page
    When I click the "Resend email confirmation" link
    Then I should be redirected to the email confirmation page
    And I enter the email "test@example.com"
    And I click the "Resend" button
    Then I should see the message "Verification email sent. Please check your email."