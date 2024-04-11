using ValhallaVaultCyberAwareness.Components.Admin.Pages;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVault_Testing
{
    public class OpenEditModalTest

    {
        private AdminView page;
        public OpenEditModalTest()
        {
            page = new AdminView();
        }

        //Tester för OpenEditModal med olika 

        [Fact]
        public void OpenEditModal_SetsSelectedCategory()
        {
            var category = new CategoryModel();

            page.OpenEditModal(category);

            // Assert
            Assert.Null(page.selectedSegment);
            Assert.Equal(category, page.selectedCategory);
        }

        [Fact]
        public void OpenEditModal_SetsSelectedSubCategory()
        {
            var subCategory = new SubCategoryModel();

            page.OpenEditModal(subCategory);

            // Assert
            Assert.Null(page.selectedSegment);
            Assert.Equal(subCategory, page.selectedSubCategory);
        }

        [Fact]
        public void OpenEditModal_SetsSelectedSegment()
        {
            var segment = new SegmentModel();

            page.OpenEditModal(segment);

            // Assert
            Assert.Null(page.selectedSubCategory);
            Assert.Equal(segment, page.selectedSegment);
        }

        [Fact]
        public void OpenEditModal_SetsSelectedQuestion()
        {

            var question = new QuestionModel();

            page.OpenEditModal(question);

            // Assert
            Assert.Null(page.selectedSubCategory);
            Assert.Equal(question, page.selectedQuestion);
        }
        [Fact]
        public void ClearSelected_SetsSelectedPropertiesToNull()
        {
            // Arrange
            page.selectedCategory = new CategoryModel();
            page.selectedSegment = new SegmentModel();
            page.selectedSubCategory = new SubCategoryModel();
            page.selectedQuestion = new QuestionModel();

            page.ClearSelected();

            // Assert
            Assert.Null(page.selectedCategory);
            Assert.Null(page.selectedSegment);
            Assert.Null(page.selectedSubCategory);
            Assert.Null(page.selectedQuestion);

        }
    }
}