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

            if (singleSegment != null)
            {
                return singleSegment;
            }
            throw new NullReferenceException();
        }
        public async Task<SegmentModel> AddSegment(SegmentModel newSegment)
        {
            if (newSegment != null)
            {
                _context.Add(newSegment);
                await _context.SaveChangesAsync();

                return newSegment;
            }
            throw new NullReferenceException();
        }

        public async Task<SegmentModel> DeleteSegment(int id)
        {
            var SegmentToDelete = await _context.Segments.FirstOrDefaultAsync(c => c.Id == id);

            if (SegmentToDelete != null)
            {
                _context.Segments.Remove(SegmentToDelete);

                await _context.SaveChangesAsync();
                return SegmentToDelete;
            }
            throw new NullReferenceException();
        }
        public async Task<SegmentModel> UpdateSegment(SegmentModel updatedSegment)
        {
            var SegmentToUpdate = await _context.Segments.FirstOrDefaultAsync(c => c.Id == updatedSegment.Id);

            if (SegmentToUpdate != null)
            {
                SegmentToUpdate.SegmentName = updatedSegment.SegmentName;

                await _context.SaveChangesAsync();
                return updatedSegment;
            }
            throw new NullReferenceException();
        }

        public async Task<SegmentModel> Get


    }
}
