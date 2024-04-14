Feature: AnswerCorrectOnAQuestion

    Scenario: Answer Correct on Question
        Given I am on the QuestionPage
        When I chose the correct answer on a Question
        And I press the checkAnswer button
        Then I should see A "You answered correctly!" message