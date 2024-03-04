namespace ValhallaVaultCyberAwareness.Data.Managers
{
    public class KeyManager
    {
        private readonly string filepath = "C:\\Users\\Skola\\Desktop\\safe.txt";
        public string? GetKey()
        {
            return File.Exists(filepath) ? File.ReadAllText(filepath) : null;
        }
    }
}
