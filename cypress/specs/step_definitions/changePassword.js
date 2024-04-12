import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('I have logged in', () => {
  cy.visit("Account/Login")
  cy.get(':nth-child(5) > .form-control').type("pauline@mail.se")
  cy.get(':nth-child(6) > .form-control').type("12345Aa!")
  cy.get('.w-100').click()
});

When('I press my account', () => {
  cy.get(':nth-child(3) > .row > :nth-child(1) > .d-flex').click()
});

When('I press password', () => {
  cy.get(':nth-child(3) > .nav-link').click()
});

When('I fill in the password form', () => {
  cy.get(':nth-child(3) > .form-control').type("12345Aa!")
  cy.get(':nth-child(4) > .form-control').type("123456Aa!")
  cy.get(':nth-child(5) > .form-control').type("123456Aa!")
});

When('I press update password', () => {
  cy.get('.btn').click()
});

Then('I should get a message that the password is updated', () => {
  cy.get('.alert').contains("Your password has been changed");
});
