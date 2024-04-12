import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('that i am on the login page', () => {
  cy.visit("Account/Login")
});

When('I fill in the login form', () => {
  cy.get(':nth-child(5) > .form-control').type("Dan@mail.se")
  cy.get(':nth-child(6) > .form-control').type("12345Aa!")
});

When('press the login button', () => {
  cy.get('.w-100').click()
});

Then('I should see a welcome message', () => {
  cy.get('.content').contains("Welcome to Valhalla Vault Cyber Awareness")
});