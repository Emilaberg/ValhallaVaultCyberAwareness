Feature: SwitchToNextQuestionAndBack

    Scenario: Switch to next question and back
        Given I am on the QuestionPage And want to check out the next question
        When I press the next question button
        Then I should see A the second question
        And I press the Prev question button
        Then I should see a first question
    
    
