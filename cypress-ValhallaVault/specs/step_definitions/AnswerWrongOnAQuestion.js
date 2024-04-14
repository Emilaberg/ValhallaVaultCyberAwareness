import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

/* No duplicate steps, this one already in AnswerCorrectOnAQuestion.js
Given('I am on the QuestionPage', () => {});*/

When('I chose an wrong answer on a Question', () => {
  // TODO: implement step
  cy.wait(1000);
  cy.get('[type="radio"]').check('1')
});

/* No duplicate steps, this one already in AnswerCorrectOnAQuestion.js
When('I press the checkAnswer button', () => {});*/

Then('I should see A inCorrect button', () => {
  // TODO: implement step
  cy.get('#inCorrect');
});