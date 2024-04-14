import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

//Gustavs Test

Given("I am on the Login page", () => {
  cy.visit("/Account/Login");
});

When("I type {string} in {string}", (a, selector) => {
  cy.wait(200);
  cy.get(selector).type(a);
});

When("I click the Login button", () => {
  cy.wait(200);
  cy.get(".w-100").click();
});

Then("I should see a logout button", () => {
  cy.wait(200);
  cy.get("form > .text-white");
});
