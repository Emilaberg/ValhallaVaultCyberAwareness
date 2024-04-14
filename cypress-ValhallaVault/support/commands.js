Cypress.Commands.add("adminlogin", (email, password) => {
  cy.visit("/Account/Login");
  cy.get(":nth-child(5) > .form-control").type(email);
  cy.get(":nth-child(6) > .form-control").type(password);
  cy.get(".w-100").click();
});
