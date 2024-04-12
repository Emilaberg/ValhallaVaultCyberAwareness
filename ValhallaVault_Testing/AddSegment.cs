using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Repositories;


public class AddSegment 
{
    [Fact]
    // Testar AddSegment-metoden
    public async Task AddSegment_Returns_AddedSegment()
    {
        // Arrange
        // Skapa inställningar för in-memory-databasen
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
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
}

