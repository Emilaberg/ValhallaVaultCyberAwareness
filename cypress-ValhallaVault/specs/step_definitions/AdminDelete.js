import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

//Gustavs Test

When("I click on the delete button", () => {
  cy.wait(200);
  // Assert that the button is visible and Click the delete button
  cy.get(".mb-3 > .btn").should("be.visible").click();
});

When("the confirmation modal is visible", () => {
  cy.wait(200);
  // Assert that the confirmation modal is visible
  cy.get("#confirmationModal > .modal-dialog > .modal-content").should(
    "be.visible"
  );
});

When("I click on the yes button", () => {
  cy.wait(200);
  // Click the "Yes" button in the confirmation modal
  cy.get(
    "#confirmationModal > .modal-dialog > .modal-content > .modal-footer > :nth-child(1)"
  )
    .should("be.visible")
    .click();
});

Then("I should not see {string} on the admin page", (a) => {
  cy.wait(200);
  // Assert that the deleted category name is not visible on the admin page
  cy.get(
    ":nth-child(n) > .card > .card-body > .btn-transparent > .card-title"
  ).should("not.contain", a);
});
