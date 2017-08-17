using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace D_Utilities
{
    public class ActiveDirectoryHelper
    {
        /// <summary>
        /// Validaites user credentials against Active Directory.
        /// </summary>
        public static bool ValidateUser(string username, string password)
        {
            bool validated = false;

            PrincipalContext context = new PrincipalContext(ContextType.Domain, APPSETTINGS.AD_Domain);

            if (context.ValidateCredentials(username, password))
            {
                validated = true;
            }

            return validated;
        }

        /// <summary>
        /// Verifies that user is a part of the specified group.
        /// </summary>
        public static bool IsUserInGroup(string username, string groupname)
        {
            PrincipalContext mPrincipalContext = new PrincipalContext(ContextType.Domain, APPSETTINGS.AD_Domain);

            var foundUserInGroup = false;

            GroupPrincipal mGroupPrincipal = null;

            try
            {
                mGroupPrincipal = GroupPrincipal.FindByIdentity(mPrincipalContext, groupname);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (mGroupPrincipal != null)
            {
                foreach (var member in mGroupPrincipal.GetMembers(true))
                {
                    try
                    {
                        if (member.SamAccountName.Equals(username))
                        {
                            foundUserInGroup = true;

                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            if (mGroupPrincipal != null)
            {
                mGroupPrincipal.Dispose();
            }

            if (mPrincipalContext != null)
            {
                mPrincipalContext.Dispose();
            }

            return foundUserInGroup;
        }

        /// <summary>
        /// Gets the User Principal for the specified user.
        /// </summary>
        public static UserPrincipal GetUserInformaiton(string UserName)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, APPSETTINGS.AD_Domain);

            UserPrincipal mUserPrincipal = new UserPrincipal(ctx);

            mUserPrincipal = UserPrincipal.FindByIdentity(ctx, UserName);

            return mUserPrincipal;
        }

        /// <summary>
        /// Gets the User Principal for the specified users.
        /// </summary>
        public static List<UserPrincipal> GetMultipleUsersInfomation(params string[] Users)
        {
            List<UserPrincipal> usersInfo = new List<UserPrincipal>();

            foreach (var user in Users)
            {
                try
                {
                    UserPrincipal mUserPrincipal = GetUserInformaiton(user);

                    usersInfo.Add(mUserPrincipal);
                }
                catch 
                {
                  
                }
            }

            return usersInfo;
        }

        /// <summary>
        /// Gets the entire Directory Entry for the specified user.
        /// </summary>
        public DirectoryEntry GetFullUserDirectoryEntry(string UserName)
        {
            UserPrincipal mUserPrincipal = GetUserInformaiton(UserName);

            try
            {
                if (mUserPrincipal.GetUnderlyingObjectType() == typeof(DirectoryEntry))
                {
                    return (DirectoryEntry)mUserPrincipal.GetUnderlyingObject();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
