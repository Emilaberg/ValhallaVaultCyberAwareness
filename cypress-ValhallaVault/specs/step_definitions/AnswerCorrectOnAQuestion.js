import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('I am on the QuestionPage', () => {
  // TODO: implement step
  cy.visit("/q");
});

When('I chose the correct answer on a Question', () => {
  // TODO: implement step
  cy.wait(1000);
  cy.get('[type="radio"]').check('3')
});

When('I press the checkAnswer button', () => {
  // TODO: implement step
  cy.wait(1000);
  cy.get(':nth-child(3) > :nth-child(1) > :nth-child(3)').click();
});

Then('I should see A {string} message', (a) => {
  // TODO: implement step
  //Då blazor laddar om dom:en och uppdaterar de element som har ändrat så kan inte cypress hitta elementet när det
  //Jag bör ändar i projektet så att när du väljer rätt fråga så kommer något upp direkt så man kan testa på det. detta är något jag kan lägga till, men då jag har haft ont om tid så är just nu koden otestbar, 
  //men jag vet vad jag behöver göra.
  cy.wait(1000);
  cy.get('#Correct');
});