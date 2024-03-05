namespace ValhallaVaultCyberAwareness.Data.Managers
{
    public class KeyManager
    {
        //vägen till filen där ni har connectionstring
        private readonly string filepath = "C:\\Users\\frisi\\OneDrive\\Skrivbord\\fil.txt";
        public string? GetKey()
        {
            return File.Exists(filepath) ? File.ReadAllText(filepath) : null;
        }
    }
}
