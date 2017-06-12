using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WWBG.Startup))]
namespace WWBG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
            app.MapSignalR();
        }


        private void createRolesandUsers()
        {
            Models.ApplicationDbContext context = new Models.ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<Models.ApplicationUser>(new UserStore<Models.ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("SuperAdmin"))
            {

                // first we create Admin rool   
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "SuperAdmin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new Models.ApplicationUser();
                user.UserName = "gbengaoluyide@gmail.com";
                user.Email = "gbengaoluyide@gmail.com";

                string userPWD = "Pass@word1";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "SuperAdmin");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("ActiveUser"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "ActiveUser";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Spectator"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Spectator";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            //if (!roleManager.RoleExists("Employee"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Employee";
            //    roleManager.Create(role);

            //}
        }

    }
}
