using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVault_Testing
{
    public class SubCategoryRepositoryTests
    {
        //Gustavs Test

        [Fact]
        public async Task GetAllSubCategories_ReturnsListOfSubCategories()
        {
            //Create an in-memory database context (ApplicationDbContext) using Entity Framework Core with a unique name.
            //Initialize the repository(SubCategoryRepository) with the database context.
            //Define a list of SubCategoryModel objects.
            //Add the list of SubCategoryModel objects to the database context and save changes.
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase1")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new SubCategoryRepository(context);
                var subCategories = new List<SubCategoryModel>
                {
                    new SubCategoryModel { Id = 1, SubCategoryName = "SubCategory 1" },
                    new SubCategoryModel { Id = 2, SubCategoryName = "SubCategory 2" },
                    new SubCategoryModel { Id = 3, SubCategoryName = "SubCategory 3" }
                };
                context.SubCategories.AddRange(subCategories);
                await context.SaveChangesAsync();

                //Call the GetAllSubCategories method of the repository to retrieve all subcategories from the database.
                var result = await repository.GetAllSubCategories();

                //Check that the result is not null.
                //Verify that the number of subcategories returned matches the count of subcategories added.
                //Ensure that the IDs and subcategory names of the returned subcategories match the IDs and names of the added subcategories.
                Assert.NotNull(result);
                Assert.Equal(subCategories.Count, result.Count);
                Assert.Equal(subCategories.Select(s => s.Id), result.Select(r => r.Id));
                Assert.Equal(subCategories.Select(s => s.SubCategoryName), result.Select(r => r.SubCategoryName));
            }
        }

        [Fact]
        public async Task GetSubCategoryById_ReturnsSingleSubCategory()
        {
            //set up in-memory database context, initialize the repository, and add a single SubCategoryModel object to the context
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase2")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new SubCategoryRepository(context);
                var subCategory = new SubCategoryModel { Id = 1, SubCategoryName = "Test SubCategory" };
                context.SubCategories.Add(subCategory);
                await context.SaveChangesAsync();

                //Call the GetSubCategoryById method of the repository with the ID of the added subcategory.
                var result = await repository.GetSubCategoryById(subCategory.Id);

                //Check that the result is not null.
                //Verify that the ID and subcategory name of the returned subcategory match the ID and name of the added subcategory.
                Assert.NotNull(result);
                Assert.Equal(subCategory.Id, result.Id);
                Assert.Equal(subCategory.SubCategoryName, result.SubCategoryName);
            }
        }

        [Fact]
        public async Task AddSubCategory_ReturnsNewSubCategory()
        {
            // Set up the database context and repository.
            // Create a new SubCategoryModel object.
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase3")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new SubCategoryRepository(context);
                var newSubCategory = new SubCategoryModel { Id = 1, SubCategoryName = "New SubCategory" };

                // Call the AddSubCategory method of the repository with the new subcategory object.
                var result = await repository.AddSubCategory(newSubCategory);

                //Check that the result is not null.
                //Verify that the ID and subcategory name of the returned subcategory match the ID and name of the added subcategory.
                Assert.NotNull(result);
                Assert.Equal(newSubCategory.Id, result.Id);
                Assert.Equal(newSubCategory.SubCategoryName, result.SubCategoryName);
            }
        }

        [Fact]
        public async Task DeleteSubCategory_RemovesSubCategory()
        {
            // Set up the database context, repository, and add a single SubCategoryModel object to the context.
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase4")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new SubCategoryRepository(context);
                var subCategory = new SubCategoryModel { Id = 1, SubCategoryName = "Test SubCategory" };
                context.SubCategories.Add(subCategory);
                await context.SaveChangesAsync();

                // Call the DeleteSubCategory method of the repository with the ID of the added subcategory.
                var deletedSubCategory = await repository.DeleteSubCategory(subCategory.Id);

                //Check that the result is not null.
                //Verify that the ID and subcategory name of the deleted subcategory match the ID and name of the added subcategory.
                //Ensure that the deleted subcategory is no longer present in the database context.
                Assert.NotNull(deletedSubCategory);
                Assert.Equal(subCategory.Id, deletedSubCategory.Id);
                Assert.Equal(subCategory.SubCategoryName, deletedSubCategory.SubCategoryName);
                Assert.DoesNotContain(context.SubCategories, c => c.Id == subCategory.Id);
            }
        }

        [Fact]
        public async Task UpdateSubCategory_UpdatesSubCategory()
        {
            // Set up the database context, repository, and add a single SubCategoryModel object to the context.
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase5")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new SubCategoryRepository(context);
                var subCategory = new SubCategoryModel { Id = 1, SubCategoryName = "Test SubCategory" };
                context.SubCategories.Add(subCategory);
                await context.SaveChangesAsync();

                // Create a new SubCategoryModel object with updated information.
                var updatedSubCategory = new SubCategoryModel { Id = 1, SubCategoryName = "Updated SubCategory" };
                //Call the UpdateSubCategory method of the repository with the updated subcategory object.
                var result = await repository.UpdateSubCategory(updatedSubCategory);

                //Check that the result is not null.
                //Verify that the subcategory name of the updated subcategory matches the updated name.
                Assert.NotNull(result);
                Assert.Equal(updatedSubCategory.SubCategoryName, result.SubCategoryName);
            }
        }
    }
}
