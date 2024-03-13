using ValhallaVaultCyberAwareness.Data;

namespace ValhallaVaultCyberAwareness.Repositories
{
    public class ValhallaUow : IValhallaUow
    {
        public CategoryRepository CategoryRepo { get; }

        public SegmentRepository SegmentRepo { get; }

        public SubCategoryRepository SubCategoryRepo { get; }
        public QuestionRepository QuestionRepo { get; }

        public PromptRepository PromptRepo { get; }

        private readonly ApplicationDbContext _context;

        public ValhallaUow(ApplicationDbContext context)
        {
            _context = context;

            CategoryRepo = new(context);
            SegmentRepo = new(context);
            SubCategoryRepo = new(context);
            QuestionRepo = new(context);
            PromptRepo = new(context);



        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
