import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

//Gustavs Test

When("I am on the admin page", () => {
  // Navigate to the "Admin" page
  cy.visit("admin/admin");
});

When("i click on the Go to Add button", () => {
  cy.wait(200);
  // Assert that the button  is visible and Click the "Go to Add" button
  cy.get("article > :nth-child(2)").should("be.visible").click();
});

Then("I should see {string} on the add page", (a) => {
  cy.wait(200);
  // Assert that the specified text is visible on the add page
  cy.get(".text-light.text-center").should("contain", a);
});

When("I am on the add page", () => {
  cy.visit("admin/add");
});

When("I type {string} in the category name field", (text) => {
  cy.wait(200);
  // Type the specified text in the category name field
  cy.get(".col-md-12 > .card > .card-body > form > .row > .col-md-6").type(
    text
  );
});

When("I Click on the add new category button", () => {
  cy.wait(200);
  // Click the "Add New Category" button
  cy.get(".col-md-12 > .card > .card-body > form > .btn").click();
});

Then("I should see {string} on the admin page", (a) => {
  cy.wait(200);
  // Navigate back to the "Admin" page
  cy.visit("admin/admin");
  // Assert that the added category name is visible on the admin page
  cy.get(
    ":nth-child(n) > .card > .card-body > .btn-transparent > .card-title"
  ).should("contain", a);
});
