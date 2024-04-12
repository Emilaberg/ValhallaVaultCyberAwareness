using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data.Models;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Repositories;



public class GetSegmentByID
{
    [Fact]
    // Testar GetSegmentById-metoden

    public async Task GetSegmentById_Returns_SingleSegment()
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

            // Anropa GetSegmentById-metoden med id 2 och få det returnerade resultatet
            var result = await repository.GetSegmentById(2);

            // Assert

            // Kontrollera att resultatet inte är null
            Assert.NotNull(result);

            // Kontrollera att resultatet är det segmentet vi förväntade oss
            Assert.Equal("Segment 2", result.SegmentName);
        }



    }
}







