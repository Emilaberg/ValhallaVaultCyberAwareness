namespace ValhallaVaultCyberAwareness.Repositories
{
    public interface IValhallaUow
    {
        CategoryRepository CategoryRepo { get; }
        SegmentRepository SegmentRepo { get; }
        SubCategoryRepository SubCategoryRepo { get; }
        QuestionRepository QuestionRepo { get; }
        PromptRepository PromptRepo { get; }
        UserRepository UserRepo { get; }

        Task CompleteAsync();
    }
}
