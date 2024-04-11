using ValhallaVaultCyberAwareness.Components.Pages;
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
    }
}
