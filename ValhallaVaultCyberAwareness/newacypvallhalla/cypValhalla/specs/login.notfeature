
Feature: Login
    As a user
    I want to be able to log in to my account
    So that I can access my personalized content

Scenario: Successful login
    Given I am on the login page
    When I enter my email "test@example.com" and password "password"
    And I click the "Log in" button
    Then I should be redirected to the home page

Scenario: Invalid login attempt
    Given I am on the login page
    When I enter my email "invalid@example.com" and password "wrongpassword"
    And I click the "Log in" button
    Then I should see an error message "Error: Invalid login attempt."

Scenario: Locked out account
    Given I am on the login page
    When I enter my email "locked@example.com" and password "password"
    And I click the "Log in" button
    Then I should see an error message "User account locked out."

Scenario: Forgot password
    Given I am on the login page
    When I click the "Forgot your password?" link
    Then I should be redirected to the forgot password page

Scenario: Register as a new user
    Given I am on the login page
    When I click the "Register as a new user" link
    Then I should be redirected to the registration page

Scenario: Resend email confirmation
    Given I am on the login page
    When I click the "Resend email confirmation" link
    Then I should be redirected to the email confirmation page
