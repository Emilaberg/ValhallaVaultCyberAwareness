using ValhallaVaultCyberAwareness.Components.Admin.Pages;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVault_Testing
{
    //Gustavs Unittest
    public class OpenEditModalTest

    {
        private AdminView page;
        public OpenEditModalTest()
        {
            page = new AdminView();
        }

        //Tester för OpenEditModal med olika modeller

        [Fact]
        public void OpenEditModal_SetsSelectedCategory()
        {
            //Create a new CategoryModel object.
            var category = new CategoryModel();

            //Call the OpenEditModal method of the AdminView page with the CategoryModel object.
            page.OpenEditModal(category);

            //Check that another property of the AdminView page is null.
            //Verify that the selectedCategory property of the AdminView page is set to the same instance as the created CategoryModel object.
            Assert.Null(page.selectedSegment);
            Assert.Equal(category, page.selectedCategory);
        }

        [Fact]
        public void OpenEditModal_SetsSelectedSubCategory()
        {
            //Create a new SubCategoryModel object.
            var subCategory = new SubCategoryModel();

            //Call the OpenEditModal method of the AdminView page with the SubCategoryModel object.
            page.OpenEditModal(subCategory);

            //Check that another property of the AdminView page is null.
            //Verify that the selectedSubCategory property of the AdminView page is set to the same instance as the created SubCategoryModel object.
            Assert.Null(page.selectedSegment);
            Assert.Equal(subCategory, page.selectedSubCategory);
        }

        [Fact]
        public void OpenEditModal_SetsSelectedSegment()
        {
            //Create a new SegmentModel object.
            var segment = new SegmentModel();

            //Call the OpenEditModal method of the AdminView page with the SegmentModel object.
            page.OpenEditModal(segment);

            //Check that another property of the AdminView page is null.
            //Verify that the selectedSegment  property of the AdminView page is set to the same instance as the created SegmentModel object.
            Assert.Null(page.selectedSubCategory);
            Assert.Equal(segment, page.selectedSegment);
        }

        [Fact]
        public void OpenEditModal_SetsSelectedQuestion()
        {
            //Create a new QuestionModel object.
            var question = new QuestionModel();

            //Call the OpenEditModal method of the AdminView page with the QuestionModel object.
            page.OpenEditModal(question);

            //Check that another property of the AdminView page is null.
            //Verify that the selectedQuestion property of the AdminView page is set to the same instance as the created QuestionModel object.
            Assert.Null(page.selectedSubCategory);
            Assert.Equal(question, page.selectedQuestion);
        }
        [Fact]
        public void ClearSelected_SetsSelectedPropertiesToNull()
        {
            //Set the selectedCategory, selectedSegment, selectedSubCategory, and selectedQuestion properties to new model instances.
            page.selectedCategory = new CategoryModel();
            page.selectedSegment = new SegmentModel();
            page.selectedSubCategory = new SubCategoryModel();
            page.selectedQuestion = new QuestionModel();

            //Call the ClearSelected method of the AdminView page.
            page.ClearSelected();

            //check that the selectedCategory, selectedSegment, selectedSubCategory, and selectedQuestion properties of the AdminView page are all null.
            Assert.Null(page.selectedCategory);
            Assert.Null(page.selectedSegment);
            Assert.Null(page.selectedSubCategory);
            Assert.Null(page.selectedQuestion);

        }
    }
}