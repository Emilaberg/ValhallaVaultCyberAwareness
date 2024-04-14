import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

//Gustavs Test

When("I Click on the {string} category", (a) => {
  cy.wait(200);
  // Assert that the specified category name is not visible on the admin page
  cy.get(":nth-child(4) > .card > .card-body > .btn > .card-title")
    .should("contain", a)
    .click();
});

When("The modal with category information is visible", () => {
  cy.wait(200);
  // Assert that the modal containing category information is visible
  cy.get(".show > .modal-dialog > .modal-content").should("be.visible");
});

Then("I type {string} in the input field", (a) => {
  cy.wait(200);
  // Clear the input field and type the specified string
  cy.get("#categoryName").type("{selectAll}{backspace}").type(a);
});

When("I click on the save changes button", () => {
  cy.wait(200);
  // // Assert that the button  is visible and Click the "Save Changes" button
  cy.get(".text-end > .btn").should("be.visible").click();
});
