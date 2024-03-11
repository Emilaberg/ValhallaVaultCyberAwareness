using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Data.Models;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class SegmentRepository
    {
        private readonly ApplicationDbContext _context;
        public SegmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SegmentModel>> GetAllSegments()
        {
            var Segments = await _context.Segments.ToListAsync();

            return Segments;

        }
        public async Task<SegmentModel> GetSegmentById(int id)
        {
            var singleSegment = await _context.Segments.FirstOrDefaultAsync(c => c.Id == id);


            return singleSegment;

        }
        public async Task<SegmentModel> AddSegment(SegmentModel newSegment)
        {

            _context.Add(newSegment);
            await _context.SaveChangesAsync();

            return newSegment;

        }

        public async Task<SegmentModel> DeleteSegment(int id)
        {
            var SegmentToDelete = await _context.Segments.FirstOrDefaultAsync(c => c.Id == id);


            _context.Segments.Remove(SegmentToDelete);

            await _context.SaveChangesAsync();
            return SegmentToDelete;
            ;
        }
        public async Task<SegmentModel> UpdateSegment(SegmentModel updatedSegment)
        {
            var SegmentToUpdate = await _context.Segments.FirstOrDefaultAsync(c => c.Id == updatedSegment.Id);


            SegmentToUpdate.SegmentName = updatedSegment.SegmentName;

            await _context.SaveChangesAsync();
            return updatedSegment;

        }

        public async Task<List<SegmentModel>> GetSegmentByCategory(int categoryId)
        {
            return await _context.Segments
               .Where(s => s.CategoryId == categoryId)
               .ToListAsync();

        }


    }
}
