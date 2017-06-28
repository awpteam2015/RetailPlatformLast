using System;
using System.Security.Principal;

namespace CommonFrameWork.Bus.Distributed.Model
{
    [Serializable]
    public class CQRSIdentity : IIdentity
    {
        
        #region -  Constructor(s)  -

        public string AuthenticationType { get; private set; }
        public string Name { get; private set; }
        public string UserID { get; private set; }

        public ulong? Roles { get; private set; }

        public bool IsAuthenticated { get; private set; }

        #endregion
        
        #region -  Constructor(s)  -

        public CQRSIdentity()
        {
            this.Name = string.Empty;
            this.UserID = string.Empty;
        }

        public CQRSIdentity(string authType, string name, string userid, ulong? roles, bool isAuth)
        {
            this.AuthenticationType = authType;
            this.Name = name;
            this.UserID = userid;
            this.Roles = roles;
            this.IsAuthenticated = isAuth;
        }

        #endregion
    }
}
