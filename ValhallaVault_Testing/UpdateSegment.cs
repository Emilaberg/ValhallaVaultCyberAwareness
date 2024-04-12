using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Repositories;



public class UpdateSegment
{
    [Fact]
    // Testar UpdateSegment-metoden
    public async Task UpdateSegment_Returns_UpdatedSegment()
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
}

