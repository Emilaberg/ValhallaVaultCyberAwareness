using ValhallaVaultCyberAwareness.Components.Pages;
using ValhallaVaultCyberAwareness.Data.Models;
namespace ValhallaVault_Testing.Emil_testklasser
{
    public class TestQuestionLogic
    {


        [Fact]
        public void TestLoadNextQuestion()
        {
            Questions questionpage = new Questions();
            int beforeNextQuestionInt = questionpage.currentQuestion;

            questionpage.NextQuestion();

            Assert.Equal(beforeNextQuestionInt + 1, questionpage.currentQuestion);
        }

        [Fact]
        public void TestCurrentQuestionShouldBeTheSameWhenPressingPrevQuestion()
        {
            Questions questionpage = new Questions();
            int beforeNextQuestionInt = questionpage.currentQuestion;

            questionpage.PrevQuestion();

            Assert.Equal(beforeNextQuestionInt, questionpage.currentQuestion);
        }

        [Fact]
        public void TestCantCheckAnswerWhenNotSelectedAnAnswer()
        {
            Questions questionpage = new Questions();

            Assert.Null(questionpage.answeredPrompt);

            questionpage.CheckAnswer();

            Assert.Null(questionpage.answeredPrompt);
            Assert.False(questionpage.answeredCorrect);
        }


        [Fact]
        public void TestAnsweredPromptSetsWhenCallingSetAnswer()
        {
            Questions questionpage = new Questions();
            //checko so no answered prompt is set as default
            Assert.Null(questionpage.answeredPrompt);

            //Create a fake prompt
            PromptModel fakePrompt = new()
            {
                Id = 1,
                Prompt = "this is a fake question",
                IsCorrect = false,
                QuestionId = 1,
                Question = { },
            };

            questionpage.setAnswer(fakePrompt);

            //Check so the answered prompt is set
            Assert.NotNull(questionpage.answeredPrompt);

            //check so the answered prompt is actually the prompt we made, or in the application the prompt we chose.
            Assert.Equal(fakePrompt.Prompt, questionpage.answeredPrompt.Prompt);

        }
    }
}
