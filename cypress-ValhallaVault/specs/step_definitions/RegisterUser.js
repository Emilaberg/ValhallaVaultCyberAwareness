import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

//Daniels Test

// Användaren är på register-sidan
Given("I am on the register page", () => {
  cy.visit("Account/Register");
});

//Användaren fyller i fälten som måste vara ifyllda(Email, lösenord och lösenordet igen)
When("I fill in the form", () => {
  cy.get(":nth-child(5) > .form-control").type("Pauline@mail.se");
  cy.get(":nth-child(6) > .form-control").type("12345Aa!");
  cy.get(":nth-child(7) > .form-control").type("12345Aa!");
});

// Användaren klickar på Register-knappen
When("I press register button", () => {
  cy.get(".w-100").click();
});

//Därefter blir användaren skickad till confirmation page 
  cy.get(".container").contains("Register confirmation");
});

// Användaren klickar på knappen för att bekräfta registrationen
When("I get send to the confirmation page", () => {
When("I press the link to confirm my account", () => {
  cy.get("p > a").click();
});

//Ett meddelande dyker upp om att användaren nu är registrerad
When("I get send to the confirm email page", () => {
  cy.get(".container").contains("Thank you for confirming your email.");
});

// Användaren klickar på "Log in here"-knappen 
When("I press the Log in here button", () => {
  cy.get(".btn").click();
});

// Och blir skickad till Login page där den nu kan logga in med sitt konto
Then("I get send to the login page", () => {
  cy.visit("Account/Login");
});
