namespace ValhallaVaultCyberAwareness.Data.Managers
{
    /// <summary>
    /// KEYMANAGER IS DEPRECATED?
    /// keymanagern används inte till nånting atm.
    /// omgjord så att den returnerar innehållet till en fil med den sökväg som man skickade med.
    /// </summary>
    public class KeyManager
    {
        //vägen till filen där ni har connectionstring
        private readonly string filepath;

        public KeyManager(string filepath)
        {
            this.filepath = filepath;
        }
        /// <summary>
        /// if there is a file on the specified filepath it will read and return its content
        /// </summary>
        /// <returns>
        /// return the content as a string if filepath exits, otherwise it returns null.
        /// </returns>
        public string? GetKey()
        {
            return File.Exists(filepath) ? File.ReadAllText(filepath) : null;
        }
    }
}
