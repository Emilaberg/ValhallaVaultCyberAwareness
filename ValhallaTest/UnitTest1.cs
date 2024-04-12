using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaTest
{
    public class CategoryRepositoryTests
    {
        // This is a unit test for the method GetAllCategories in the 
        [Fact]
        public async Task GetAlLCategoriesTest()
        {
            // Arrange
            // We're setting up an in-memory database for testing.
            // The "UseInMemoryDatabase" method creates a new database for testing.
            // This database does not create files on disk
            // and the data stored in it will be lost when the application restarts.
            // We're giving it a unique name "TestDatabase1" to isolate it from other tests.
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase1")
                .Options;

            // We're using a using statement to ensure that the database context
            // is disposed off correctly once we're done with it.
            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                // We're creating a new instance of the CategoryRepository, which is the class we're testing.
                var categoryRepo = new CategoryRepository(dbContext);

                // We're creating a list of categories that we'll add to the in-memory database.
                var categories = new List<CategoryModel>
                    {
                        new CategoryModel { Id = 1, CategoryName = "Category 1" },
                        new CategoryModel { Id = 2, CategoryName = "Category 2" },
                        new CategoryModel { Id = 3, CategoryName = "Category 3" }
                    };
                // We're adding the categories to the database and saving the changes.
                dbContext.Categories.AddRange(categories);
                await dbContext.SaveChangesAsync();

                // Act
                // We're calling the method we're testing and storing the result.
                var result = await categoryRepo.GetAllCategories();

                // Assert
                // We're checking that the number of categories returned
                // by the method matches the number of categories we added to the database.
                Assert.Equal(categories.Count, result.Count());

                // We're checking that the IDs of the categories returned by the method match the IDs
                // of the categories we added to the database.
                Assert.Equal(categories.Select(s => s.Id), result.Select(r => r.Id));

                // We're checking that the names of the categories returned by the method match the names
                // of the categories we added to the database.
                Assert.Equal(categories.Select(s => s.CategoryName), result.Select(r => r.CategoryName));
            }

            // The other tests follow a similar pattern: Arrange (set up the test),
            // Act (call the method being tested),
            // Assert (check the results).
            // The specific assertions depend on what the method being tested is supposed to do.
        }
        [Fact]
        public async Task GetCategoryByIdTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase2")
                .Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var categoryRepo = new CategoryRepository(dbContext);
                var category = new CategoryModel { Id = 1, CategoryName = "Test Category" };
                dbContext.Categories.Add(category);
                await dbContext.SaveChangesAsync();

                // Act
                var result = await categoryRepo.GetCategoryById(category.Id);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(category.Id, result.Id);
                Assert.Equal(category.CategoryName, result.CategoryName);
            }
        }

        [Fact]
        public async Task AddCategoryTest()
        {
            // Arrange
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase3")
                .Options;

            using (var dbContext = new ApplicationDbContext(dbContextOptions))
            {
                var categoryRepo = new CategoryRepository(dbContext);
                var category = new CategoryModel { Id = 1, CategoryName = "Category 1" };

                // Act
                await categoryRepo.AddCategory(category);

                // Assert
                var result = await dbContext.Categories.FindAsync(category.Id);
                Assert.NotNull(result);
                Assert.Equal(category.Id, result.Id);
                Assert.Equal(category.CategoryName, result.CategoryName);
            }
        }

        [Fact]
        public async Task DeleteCategoryTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase4")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new CategoryRepository(context);
                var category = new CategoryModel { Id = 1, CategoryName = "Test Category" };
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                // Act
                var deletedCategory = await repository.DeleteCategory(category.Id);

                // Assert
                Assert.Equal(category.Id, deletedCategory.Id);
                Assert.Equal(category.CategoryName, deletedCategory.CategoryName);
                Assert.DoesNotContain(context.Categories, c => c.Id == category.Id);
            }
        }

        [Fact]
        public async Task UpdateCategoryTest()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase5")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new CategoryRepository(context);
                var category = new CategoryModel { Id = 1, CategoryName = "Category 1" };
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                // Act
                var updatedCategory = new CategoryModel { Id = 1, CategoryName = "Updated Category 1" };
                var result = await repository.UpdateCategory(updatedCategory);

                // Assert
                Assert.Equal(updatedCategory.CategoryName, result.CategoryName);
            }
        }

        [Fact]
        public async Task GetAllCategoriesWithSegmentsAndSubCategoriesTest()
        {
            // Arrange

            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase6")
                .Options;

            using (var dbcontext = new ApplicationDbContext(dbContextOptions))
            {
                // Arrange
                var repository = new CategoryRepository(dbcontext);
                var category1 = new CategoryModel { Id = 1, CategoryName = "Category 1" };
                var category2 = new CategoryModel { Id = 2, CategoryName = "Category 2" };
                var segment1 = new SegmentModel { Id = 1, SegmentName = "Segment 1", CategoryId = 1 };
                var segment2 = new SegmentModel { Id = 2, SegmentName = "Segment 2", CategoryId = 2 };
                var subCategory1 = new SubCategoryModel { Id = 1, SubCategoryName = "SubCategory 1", SegmentId = 1 };
                var subCategory2 = new SubCategoryModel { Id = 2, SubCategoryName = "SubCategory 2", SegmentId = 2 };
                var question1 = new QuestionModel { Id = 1, Question = "Question 1", SubCategoryId = 1 };
                var question2 = new QuestionModel { Id = 2, Question = "Question 2", SubCategoryId = 2 };
                var prompt1 = new PromptModel { Id = 1, Prompt = "Prompt 1", IsCorrect = true, QuestionId = 1 };
                var prompt2 = new PromptModel { Id = 2, Prompt = "Prompt 2", IsCorrect = false, QuestionId = 2 };

                dbcontext.Categories.AddRange(category1, category2);
                dbcontext.Segments.AddRange(segment1, segment2);
                dbcontext.SubCategories.AddRange(subCategory1, subCategory2);
                dbcontext.Questions.AddRange(question1, question2);
                dbcontext.Prompts.AddRange(prompt1, prompt2);
                await dbcontext.SaveChangesAsync();

                // Act
                var result = await repository.GetAllCategoriesWithSegmentsAndSubCategories();

                // Assert
                Assert.NotNull(result);
                Assert.Equal(2, result.Count);
                Assert.Equal("Category 1", result[0].CategoryName);
                Assert.Equal("Category 2", result[1].CategoryName);
                Assert.Equal(1, result[0].Segments.Count);
                Assert.Equal(1, result[1].Segments.Count);
                Assert.Equal("Segment 1", result[0].Segments[0].SegmentName);
                Assert.Equal("Segment 2", result[1].Segments[0].SegmentName);
                Assert.Equal(1, result[0].Segments[0].SubCategory.Count);
                Assert.Equal(1, result[1].Segments[0].SubCategory.Count);
                Assert.Equal("SubCategory 1", result[0].Segments[0].SubCategory[0].SubCategoryName);
                Assert.Equal("SubCategory 2", result[1].Segments[0].SubCategory[0].SubCategoryName);
                Assert.Equal(1, result[0].Segments[0].SubCategory[0].Questions.Count);
                Assert.Equal(1, result[1].Segments[0].SubCategory[0].Questions.Count);
                Assert.Equal("Question 1", result[0].Segments[0].SubCategory[0].Questions[0].Question);
                Assert.Equal("Question 2", result[1].Segments[0].SubCategory[0].Questions[0].Question);
                Assert.Equal(1, result[0].Segments[0].SubCategory[0].Questions[0].Prompts.Count);
                Assert.Equal(1, result[1].Segments[0].SubCategory[0].Questions[0].Prompts.Count);
                Assert.Equal("Prompt 1", result[0].Segments[0].SubCategory[0].Questions[0].Prompts[0].Prompt);
                Assert.Equal("Prompt 2", result[1].Segments[0].SubCategory[0].Questions[0].Prompts[0].Prompt);
            }
        }


    }
}
