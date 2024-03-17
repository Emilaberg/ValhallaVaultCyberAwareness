using Microsoft.EntityFrameworkCore;
using ValhallaVaultCyberAwareness.Data;
using ValhallaVaultCyberAwareness.Data.Models;

namespace valhaValhallaVaultCyberAwarenessllaTest.Repositories
{
    public class SegmentRepository
    {
        private readonly ApplicationDbContext _context;
        public SegmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<SegmentModel>?> GetAllSegments()
        {
            var Segments = await _context.Segments.ToListAsync();
            if (Segments != null)
            {
                return Segments;

            }
            return null;

        }
        public async Task<SegmentModel?> GetSegmentById(int id)
        {
            var singleSegment = await _context.Segments.FirstOrDefaultAsync(c => c.Id == id);
            if (singleSegment != null)
            {
                return singleSegment;

            }
            return null;

        }
        public async Task<SegmentModel?> AddSegment(SegmentModel newSegment)
        {
            if (newSegment != null)
            {
                _context.Add(newSegment);
                await _context.SaveChangesAsync();

                return newSegment;

            }
            return null;
        }

        public async Task<SegmentModel?> DeleteSegment(int id)
        {
            var segmentToDelete = await _context.Segments.FirstOrDefaultAsync(c => c.Id == id);

            if (segmentToDelete != null)
            {
                _context.Segments.Remove(segmentToDelete);

                await _context.SaveChangesAsync();
                return segmentToDelete;

            }
            return null;
        }
        public async Task<SegmentModel?> UpdateSegment(SegmentModel updatedSegment)
        {
            var segmentToUpdate = await _context.Segments.FirstOrDefaultAsync(c => c.Id == updatedSegment.Id);

            if (segmentToUpdate != null)
            {
                segmentToUpdate.SegmentName = updatedSegment.SegmentName;

                await _context.SaveChangesAsync();
                return updatedSegment;

            }
            return null;

        }
        //Get all segments By category
        public async Task<List<SegmentModel>?> GetSegmentByCategory(int categoryId)
        {
            var categorySegment = await _context.Segments
               .Where(sc => sc.CategoryId == categoryId)
               .ToListAsync();
            if (categorySegment != null)
            {
                return categorySegment;

            }
            return null;
        }
    }
}
