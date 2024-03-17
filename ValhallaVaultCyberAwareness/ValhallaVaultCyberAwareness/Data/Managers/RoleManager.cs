using Microsoft.AspNetCore.Identity;

namespace ValhallaVaultCyberAwareness.Data.Managers
{
    public class RoleManager
    {
        private SignInManager<ApplicationUser> signInManager;
        private RoleManager<IdentityRole> roleManager;
        public RoleManager(SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        /// <summary>
        /// Här kan man öka på med flera metoder för att skapa användare, t.ex så kan vi lägga in en metod här som skapar x antal användare med olika roller.
        //  detta hade varit nice att implementera för då behöver vi inte lägga massa kod i program.cs för att skapa användare utan det ligger här istället. 
        //  hade vi haft mer tid kunde vi lagt en sådan metod här.//Emil
        /// </summary>
        public void InitialAdminAccount()
        {
            //skapa en admin användare
            ApplicationUser admin = new()
            {
                UserName = "admin@mail.com",
                Email = "admin@mail.com",
                EmailConfirmed = true
            };

            var user = signInManager.UserManager.FindByEmailAsync(admin.Email).GetAwaiter().GetResult();
            //sen vill jag kolla om användaren finns i databasen 
            if (user == null) //finns det inte så vill jag lägga till användaren i databasen 
            {

                signInManager.UserManager.CreateAsync(admin, "Password1!").GetAwaiter().GetResult();


                bool roleExits = roleManager.RoleExistsAsync("Admin").GetAwaiter().GetResult();

                //sen vill kolla om admin rollen finns 
                if (!roleExits) //finns den inte så vill jag skapa en ny
                {
                    IdentityRole adminRole = new()
                    {
                        Name = "Admin",
                    };

                    roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
                }
                //sen vill jag lägga till rollen till databasen och tilldela rollen till användaren 
                signInManager.UserManager.AddToRoleAsync(admin, "Admin").GetAwaiter().GetResult();
            }
        }

        
    }
}
