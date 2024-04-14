import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

//Daniels Test


// Användaren inloggad och befinner sig på homepage
Given("I am logged in", () => {
  cy.visit("Account/Login");
  cy.get(":nth-child(5) > .form-control").type("pauline@mail.se");
  cy.get(":nth-child(6) > .form-control").type("123456Aa!");
  cy.get(".w-100").click();
});

// Användaren klickar på "Mitt konto"
When("I press mitt konto", () => {
  cy.get(":nth-child(3) > .row > :nth-child(1) > .d-flex").click();
});

// Sedan klickar användaren på "Personal data"
When("I press personal data", () => {
  cy.get(":nth-child(4) > .nav-link").click();
});

// Användaren klickar på "Delete"-knappen som gör att användaren tas bort från databasen
When("I press delete button", () => {
  cy.get("p.col-auto > .btn").click();
});

// Lösenordet skrivs in av användaren 
When("I type in my password", () => {
  cy.get(".form-control").type("12345Aa!");
});

// Användaren klickar på knappen där det står "Delete data and close my account"
When("I click the delete data button", () => {
  cy.get(".w-100").click();
});

// Användaren blir skickad automatiskt till login sidan när den tagit bort sitt konto
Then("I get redirect to login page", () => {
  cy.visit("Account/Login");
});
