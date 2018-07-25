using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using LeaveWord.Models;
using System.Web.Security;

namespace LeaveWord.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 确保每次启动应用程序时只初始化一次 ASP.NET Simple Membership
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);

            //确保创建了所需的角色
            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }
            //确保创建了所需的角色
            if (!Roles.RoleExists("Simple"))
            {
                Roles.CreateRole("Simple");
            }
            //创建管理员
            if (!WebSecurity.UserExists("Administrator"))
            {
                WebSecurity.CreateUserAndAccount("Administrator", "888888");
                Roles.AddUserToRole("Administrator", "Admin");
            }

        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<UsersContext>(null);

                try
                {
                    using (var context = new UsersContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // 创建不包含 Entity Framework 迁移架构的 SimpleMembership 数据库
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("无法初始化 ASP.NET Simple Membership 数据库。有关详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
