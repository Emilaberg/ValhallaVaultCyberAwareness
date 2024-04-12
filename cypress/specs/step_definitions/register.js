import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('I am on the register page', () => {
  cy.visit("Account/Register")
});

When('I fill in the form', () => {
  cy.get(':nth-child(5) > .form-control').type("Pauline@mail.se")
  cy.get(':nth-child(6) > .form-control').type("12345Aa!")
  cy.get(':nth-child(7) > .form-control').type("12345Aa!")
});

When('I press register button', () => {
  cy.get('.w-100').click()
});

When('I get send to the confirmation page', () => {
  cy.get('.container').contains("Register confirmation")
});

When('I press the link to confirm my account', () => {
  cy.get('p > a').click()
});

When('I get send to the confirm email page', () => {
  cy.get('.container').contains("Thank you for confirming your email.")
});

When('I press the Log in here button', () => {
  cy.get('.btn').click()
});

Then ('I get send to the login page', () => {
  cy.visit("Account/Login")
});
