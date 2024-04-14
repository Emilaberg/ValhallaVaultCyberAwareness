Feature: AnswerWrongOnAQuestion

    Scenario: Answer Wrong on Question
        Given I am on the QuestionPage
        When I chose an wrong answer on a Question
        And I press the checkAnswer button
        Then I should see A inCorrect button