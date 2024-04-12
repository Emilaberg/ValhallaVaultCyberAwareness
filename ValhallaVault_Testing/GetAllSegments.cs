using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Repositories;


public class GetAllSegments
{
    [Fact]
    // Testar GetAllSegments-metoden
    public async Task GetAllSegments_Returns_AllSegments()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb2") // 
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

}