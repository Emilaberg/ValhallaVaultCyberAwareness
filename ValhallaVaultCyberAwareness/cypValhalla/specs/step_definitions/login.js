import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given("I am on the login page", () => {
    cy.visit("/Account/Login");
});

When(/^I enter my email "([^"]*)" and password "([^"]*)"$/, (email, password) => {
    cy.get('input[name="email"]').type(email);
    cy.get('input[name="password"]').type(password);
});

And(/^I click the "([^"]*)" button$/, (buttonText) => {
    cy.contains('button', buttonText).click();
});

Then(/^I should be redirected to the home page$/, () => {
    cy.url().should('eq', 'https://localhost:7257/');
});

When(/^I click the "Forgot your password?" link$/, () => {
    cy.get('a[href="/Account/ForgotPassword"]').click();
    // Add any additional actions or validations here
});

Then(/^I should be redirected to the forgot password page$/, () => {
    cy.url().should('include', '/Account/ForgotPassword');
});

When(/^I click the "Register as a new user" link$/, () => {
    cy.get('a[href="/Account/Register"]').click();
});

Then(/^I should be redirected to the registration page$/, () => {
    cy.url().should('include', '/Account/Register');
});

When(/^I click the "Resend email confirmation" link$/, () => {
    cy.get('a[href="/Account/ResendEmailConfirmation"]').click();
});

Then(/^I should be redirected to the email confirmation page$/, () => {
    cy.url().should('include', '/Account/EmailConfirmation');
});

describe('Login', () => {
    it('should log in successfully', () => {
        cy.visit('https://localhost:7257/Account/Login');
        cy.get('input[name="email"]').type('test@example.com');
        cy.get('input[name="password"]').type('password');
        cy.contains('button', 'Log in').click();
        cy.url().should('eq', 'https://localhost:7257/');
    });

    it('should show an error message for invalid login attempt', () => {
        cy.visit('https://localhost:7257/Account/Login');
        cy.get('input[name="email"]').type('invalid@example.com');
        cy.get('input[name="password"]').type('wrongpassword');
        cy.contains('button', 'Log in').click();
        cy.contains('Error: Invalid login attempt.');
    });

    it('should show an error message for locked out account', () => {
        cy.visit('https://localhost:7257/Account/Login');
        cy.get('input[name="email"]').type('locked@example.com');
        cy.get('input[name="password"]').type('password');
        cy.contains('button', 'Log in').click();
        cy.contains('User account locked out.');
    });

    it('should redirect to the forgot password page', () => {
        cy.visit('https://localhost:7257/Account/Login');
        cy.contains('Forgot your password?').click();
        cy.url().should('include', '/Account/ForgotPassword');
    });

    it('should redirect to the registration page', () => {
        cy.visit('https://localhost:7257/Account/Login');
        cy.contains('Register as a new user').click();
        cy.url().should('include', '/Account/Register');
    });

    it('should redirect to the email confirmation page', () => {
        cy.visit('https://localhost:7257/Account/Login');
        cy.contains('Resend email confirmation').click();
        cy.url().should('include', '/Account/EmailConfirmation');
    });
});