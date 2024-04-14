import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

//Daniels Test

Given("I am logged in", () => {
  cy.visit("Account/Login");
  cy.get(":nth-child(5) > .form-control").type("pauline@mail.se");
  cy.get(":nth-child(6) > .form-control").type("123456Aa!");
  cy.get(".w-100").click();
});

When("I press mitt konto", () => {
  cy.get(":nth-child(3) > .row > :nth-child(1) > .d-flex").click();
});

When("I press personal data", () => {
  cy.get(":nth-child(4) > .nav-link").click();
});

When("I press delete button", () => {
  cy.get("p.col-auto > .btn").click();
});

When("I type in my password", () => {
  cy.get(".form-control").type("12345Aa!");
});

When("I click the delete data button", () => {
  cy.get(".w-100").click();
});

Then("I get redirect to login page", () => {
  cy.visit("Account/Login");
});
