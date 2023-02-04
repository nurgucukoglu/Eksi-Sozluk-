using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Linq;

namespace IdentityProject.Helper
{
    public static class LayoutInfo
    {
        public static AppUser GetUserData(string userName)
        {
            var user = new AppUser();
           using (Context context = new Context())
           {
               user = context.Users.Where(x => x.UserName == userName).FirstOrDefault();
           }
            return user;
       }
    }

}
