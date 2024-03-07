using ValhallaVaultCyberAwareness.Data;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class ValhallaUow : IValhallaUow
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository CategoryRepo { get; }
        public SegmentRepository SegmentRepo { get; }
        public SubCategoryRepository SubCategoryRepo { get; }
        public QuestionRepository QuestionRepo { get; }
        public PromptRepository PromptRepo { get; }

        public ValhallaUow(ApplicationDbContext context)
        {

            _context = context;

            CategoryRepo = new(_context);
            SegmentRepo = new(_context);
            SubCategoryRepo = new(_context);
            QuestionRepo = new(_context);
            PromptRepo = new(_context);

        }
        public async Task Complete()
        {
            await _context.SaveChangesAsync();

        }
    }
}
