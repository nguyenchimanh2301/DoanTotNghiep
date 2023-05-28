using APIDoanV.Entities;
using System.Collections.Generic;
using System.Linq;
namespace APIDoanV.helper
{
    public static class ExtentionMethods
    {
       
            public static IEnumerable<Users> WithoutPasswords(this IEnumerable<Users> users)
            {
                if (users == null) return null;

                return users.Select(x => x.WithoutPassword());
            }

            public static Users WithoutPassword(this Users user)
            {
                if (user == null) return null;

                user.MatKhau = null;
                return user;
            }
        /*Scaffold-DbContext "Server=LAPTOP-LLHPT87U\SQLEXPRESS;Database=API;Trusted_Connection=True;Encrypt=False;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force*/
    }
}
