import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

//Daniels Test

//Användaren är inloggad och är på homepage
Given("I have logged in", () => {
  cy.visit("Account/Login");
  cy.get(":nth-child(5) > .form-control").type("pauline@mail.se");
  cy.get(":nth-child(6) > .form-control").type("12345Aa!");
  cy.get(".w-100").click();
});

//Användaren klickar på "Mitt konto" uppe till höger
When("I press my account", () => {
  cy.get(":nth-child(3) > .row > :nth-child(1) > .d-flex").click();
});

// Därefter klickar andvändaren på "Password"-alternativet för att ändra lösenord
When("I press password", () => {
  cy.get(":nth-child(3) > .nav-link").click();
});

// Fälten fylls i, det vill säga, lösenordet som användaren har just nu, sedan det nya lösenordet som den vill ändra till(två gånger)
When("I fill in the password form", () => {
  cy.get(":nth-child(3) > .form-control").type("12345Aa!");
  cy.get(":nth-child(4) > .form-control").type("123456Aa!");
  cy.get(":nth-child(5) > .form-control").type("123456Aa!");
});

// Användaren klickar på knappen "Update password" som gör att lösenordet ändras
When("I press update password", () => {
  cy.get(".btn").click();
});

// Då får användaren en message box som en bekräftelse på att lösenordet har ändrats
Then("I should get a message that the password is updated", () => {
  cy.get(".alert").contains("Your password has been changed");
});
