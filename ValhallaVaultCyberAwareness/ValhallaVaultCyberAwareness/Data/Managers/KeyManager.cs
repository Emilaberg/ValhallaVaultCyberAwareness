namespace ValhallaVaultCyberAwareness.Data.Managers
{
    public class KeyManager
    {
        public string? GetKey(string filepath)
        {
            return File.Exists(filepath) ? File.ReadAllText(filepath) : null;
        }
    }
}
