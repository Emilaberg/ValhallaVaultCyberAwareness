import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

// This step navigates to the login page by visiting the URL "/Account/Login"
Given("I am on the login page", () => {
    cy.visit("/Account/Login");
});

// This step enters the email and password into the respective form fields
// It uses CSS selectors to find the input fields and then types the email and password
When("I enter my email {string} and password {string}", (email, password) => {
    cy.get(':nth-child(5) > .form-control').type(email);
    cy.get(':nth-child(6) > .form-control').type(password);
});

// This step clicks a button or link identified by the provided selector
// It uses the CSS selector to find the button or link and then performs a click action
When( "I click {string} with selector {string}", (a, selector) => {
    cy.get(selector).click();
});

// This step checks that the current URL is the home page URL
// It waits for 4000 milliseconds (to allow for any redirects) and then checks the URL
Then(/^I should be redirected to the home page$/, () => {
    cy.wait(4000);
    cy.url().should('eq', 'https://localhost:7257/');
});

// This step clicks the "Forgot your password?" link
// It uses a CSS selector to find the link and then performs a click action
When(/^I click the "Forgot your password\?" link$/, () => {
    cy.get(':nth-child(9) > :nth-child(1) > a').click();
});

// This step checks that the current URL is the forgot password page URL
// It checks that the URL includes the string '/Account/ForgotPassword'
Then(/^I should be redirected to the forgot password page$/, () => {
    cy.url().should('include', '/Account/ForgotPassword');

    // .should() is a command that is used for assertions. 
    // It's used to assert that things are what you expect.
});

// This step enters the email into the form field
// It uses a CSS selector to find the email input field and then types the email
When(/^I enter my email "([^"]*)"$/, (email) => {
    cy.get('input[type="email"].form-control').type(email);
});

// This step clicks the "Submit" button
// It uses a CSS selector to find the button and then performs a click action
When(/^I click the "Submit" button$/, () => {
    cy.get('.btn').click();
});

// This step clicks the "Resend email confirmation" link
// It uses a CSS selector to find the link and then performs a click action
When(/^I click the "Resend email confirmation" link$/, () => {
    cy.get(':nth-child(3) > a').click();
});

// This step checks that the current URL is the email confirmation page URL
// It checks that the URL includes the string '/Account/ResendEmailConfirmation'
Then(/^I should be redirected to the email confirmation page$/, () => {
    cy.url().should('include', '/Account/ResendEmailConfirmation');
});

// This step enters the email into the form field
// It uses a CSS selector to find the email input field and then types the email
When(/^I enter the email "([^"]*)"$/, (email) => {
    cy.get('.form-control').type(email);
});

// This step clicks the "Resend" button
// It uses a CSS selector to find the button and then performs a click action
When(/^I click the "Resend" button$/, () => {
    cy.get('button[type="submit"]').click(); 
});

// This step checks that the alert message contains the expected text
// It uses a CSS selector to find the alert message and then checks its text
Then(/^I should see the message "([^"]*)"$/, (message) => {
    cy.get('.alert').should('contain', message);
});