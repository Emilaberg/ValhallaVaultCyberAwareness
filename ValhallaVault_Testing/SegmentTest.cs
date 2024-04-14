using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Repositories;

namespace ValhallaVault_Testing
{
    //Daniels Unittest
    public class SegmentTest
    {
        [Fact]
        // Testar GetAllSegments-metoden
        public async Task GetAllSegments_Returns_AllSegments()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb") // 
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                // Lägg till några testdata i databasen
                context.Segments.AddRange(
                    new SegmentModel { Id = 1, SegmentName = "Segment 1" },
                    new SegmentModel { Id = 2, SegmentName = "Segment 2" },
                    new SegmentModel { Id = 3, SegmentName = "Segment 3" }
                );
                await context.SaveChangesAsync();
            }

            // Skapa en ny ApplicationDbContext med samma options för att ha en separat context för testet
            using (var context = new ApplicationDbContext(options))
            {
                // Skapa en instans av SegmentRepository med vår test-ApplicationDbContext
                var repository = new SegmentRepository(context);

                // Act

                // Anropa GetAllSegments-metoden och få det returnerade resultatet
                var result = await repository.GetAllSegments();

                // Assert

                // Kontrollera att resultatet inte är null
                Assert.NotNull(result);

                // att det innehåller 3 segment, Om inte , kommer testet att misslyckas
                Assert.Equal(3, result.Count);

                // Dubbekolla att dessa segment faktiskt finns i resultatet
                Assert.Contains(result, s => s.SegmentName == "Segment 1");
                Assert.Contains(result, s => s.SegmentName == "Segment 2");
                Assert.Contains(result, s => s.SegmentName == "Segment 3");
            }
        }
        [Fact]
        // Testar GetSegmentById-metoden

        public async Task GetSegmentById_Returns_SingleSegment()
        {
            // Arrange
            // Skapa inställningar för in-memory-databasen
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb1")
                .Options;

            // Skapa och fyll in-memory-databasen med segmentdata
            using (var context = new ApplicationDbContext(options))
            {
                context.Segments.AddRange(
                 new SegmentModel { Id = 1, SegmentName = "Segment 1" },
                 new SegmentModel { Id = 2, SegmentName = "Segment 2" },
                 new SegmentModel { Id = 3, SegmentName = "Segment 3" }
                 );

                await context.SaveChangesAsync();
            }

            // Skapa en ny ApplicationDbContext med samma options för att ha en separat context för testet
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new SegmentRepository(context);

                // Act

                // Anropa GetSegmentById-metoden med id 2 och få det returnerade resultatet
                var result = await repository.GetSegmentById(2);

                // Assert

                // Kontrollera att resultatet inte är null
                Assert.NotNull(result);

                // Kontrollera att resultatet är det segmentet vi förväntade oss
                Assert.Equal("Segment 2", result.SegmentName);
            }
        }
        [Fact]
        // Testar AddSegment-metoden
        public async Task AddSegment_Returns_AddedSegment()
        {
            // Arrange
            // Skapa inställningar för in-memory-databasen
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb2")
                .Options;

            // Skapa en ny ApplicationDbContext med in-memory-databasen
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new SegmentRepository(context);

                // Act

                // Skapa ett nytt segmentobjekt
                var newSegment = new SegmentModel { Id = 4, SegmentName = "Segment 4" };

                // Anropa AddSegment-metoden med det nya segmentobjektet och få det returnerade resultatet
                var result = await repository.AddSegment(newSegment);

                // Assert

                // Kontrollera att resultatet inte är null
                Assert.NotNull(result);

                // Kontrollera att resultatet är det segmentet vi förväntade oss
                Assert.Equal("Segment 4", result.SegmentName);

                // Kontrollera att det nya segmentet faktiskt har lagts till i databasen
                var addedSegment = await context.Segments.FirstOrDefaultAsync(s => s.Id == 4);
                Assert.NotNull(addedSegment);
                Assert.Equal("Segment 4", addedSegment.SegmentName);
            }
        }

        [Fact]
        // Testar UpdateSegment-metoden
        public async Task UpdateSegment_Returns_UpdatedSegment()
        {
            // Arrange
            // Skapa inställningar för in-memory-databasen
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb3")
                .Options;

            // Skapa och fyll in-memory-databasen med segmentdata
            using (var context = new ApplicationDbContext(options))
            {
                context.Segments.AddRange(
                new SegmentModel { Id = 1, SegmentName = "Segment 1" },
                new SegmentModel { Id = 2, SegmentName = "Segment 2" },
                new SegmentModel { Id = 3, SegmentName = "Segment 3" }
                                                                                                                                                                                                                                                                                          );

                await context.SaveChangesAsync();
            }

            // Skapa en ny ApplicationDbContext med samma options för att ha en separat context för testet
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new SegmentRepository(context);

                // Act

                // Skapa ett uppdaterat segmentobjekt
                var updatedSegment = new SegmentModel { Id = 2, SegmentName = "Updated Segment 2" };

                // Anropa UpdateSegment-metoden med det uppdaterade segmentobjektet och få det returnerade resultatet
                var result = await repository.UpdateSegment(updatedSegment);

                // Assert

                // Kontrollera att resultatet inte är null
                Assert.NotNull(result);

                // Kontrollera att resultatet är det uppdaterade segmentet vi förväntade oss
                Assert.Equal("Updated Segment 2", result.SegmentName);

                // Kontrollera att det uppdaterade segmentet faktiskt har uppdaterats i databasen
                var updatedSegmentInDb = await context.Segments.FirstOrDefaultAsync(s => s.Id == 2);
                Assert.NotNull(updatedSegmentInDb);
                Assert.Equal("Updated Segment 2", updatedSegmentInDb.SegmentName);
            }
        }
        [Fact]
        // Testar DeleteSegment-metoden
        public async Task DeleteSegment_Returns_DeletedSegment()
        {
            // Arrange
            // Skapa inställningar för in-memory-databasen
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb4")
                .Options;

            // Skapa och fyll in-memory-databasen med segmentdata
            using (var context = new ApplicationDbContext(options))
            {
                context.Segments.AddRange(
                new SegmentModel { Id = 1, SegmentName = "Segment 1" },
                new SegmentModel { Id = 2, SegmentName = "Segment 2" },
                new SegmentModel { Id = 3, SegmentName = "Segment 3" }
                );

                await context.SaveChangesAsync();
            }

            // Skapa en ny ApplicationDbContext med samma options för att ha en separat context för testet
            using (var context = new ApplicationDbContext(options))
            {
                var repository = new SegmentRepository(context);

                // Act

                // Anropa DeleteSegment-metoden med id 2 och få det returnerade resultatet
                var result = await repository.DeleteSegment(2);

                // Assert

                // Kontrollera att resultatet inte är null
                Assert.NotNull(result);

                // Kontrollera att resultatet är det segmentet vi förväntade oss
                Assert.Equal("Segment 2", result.SegmentName);

                // Kontrollera att det borttagna segmentet inte längre finns i databasen
                var deletedSegment = await context.Segments.FirstOrDefaultAsync(s => s.Id == 2);
                Assert.Null(deletedSegment);
            }
        }
    }
}