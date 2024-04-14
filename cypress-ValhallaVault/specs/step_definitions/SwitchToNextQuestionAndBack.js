import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('I am on the QuestionPage And want to check out the next question', () => {
  // TODO: implement step
  cy.visit('/q')
});

When('I press the next question button', () => {
  // TODO: implement step
  cy.wait(1000);
  cy.get(':nth-child(3) > :nth-child(1) > :nth-child(4)').click();
});

Then('I should see A the second question', () => {
  // TODO: implement step
  cy.get('p').contains('Question 2 / 14')
});

Then('I press the Prev question button', () => {
  // TODO: implement step
  cy.wait(1000);
  cy.get(':nth-child(3) > :nth-child(1) > :nth-child(4)').click();
});

Then('I should see a first question', () => {
  // TODO: implement step
  cy.wait(1000);
  cy.get('p').contains('Question 1 / 14')
});