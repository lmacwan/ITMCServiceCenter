using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.DLL
{
    public class UserUtility
    {
        #region Data Members
        private UserRepository userRepository = new UserRepository();
        #endregion

        public string GetUserFullName(int? userId)
        {
            var userFullName = "(None)";
            if (userId.HasValue)
            {
                var user = userRepository.GetUser(userId.Value);
                if (user != null)
                {
                    userFullName = user.UserFullName;
                }
            }
            return userFullName;
        }
    }
}
