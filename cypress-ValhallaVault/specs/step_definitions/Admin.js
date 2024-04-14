import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

//Gustavs Test

Given("that I am logged in", () => {
  //Wait for 200 milliseconds
  cy.wait(200);
  // Custom command to log in
  cy.adminlogin("admin@mail.com", "Password1234!");
});

When("I am on the Admin page", () => {
  // Navigate to the "Admin" page
  cy.visit("admin/admin");
});

Then("The categories should be Visible", () => {
  cy.wait(200);
  // Assert that category names are visible
  cy.get(
    ":nth-child(n) > .card > .card-body > .btn-transparent > .card-title"
  ).should("be.visible");
});

When("I click on the category name", () => {
  cy.wait(200);
  // Click on the first category name
  cy.get(":nth-child(1) > .card > .card-body > .btn-transparent > .card-title")
    .should("be.visible")
    .click();
});

Then("The modal with category information should be visible", () => {
  cy.wait(200);
  // Assert that the modal is visible
  cy.get(".show > .modal-dialog > .modal-content").should("be.visible");
});
