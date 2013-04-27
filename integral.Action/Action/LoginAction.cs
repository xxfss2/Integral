using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
namespace integral.Action
{
    public class LoginAction
    {
        public class CurrUser
        {
            public string  QQ
            {
                get { return HttpContext.Current.Session[QQ].ToString (); }
            }

            //public string PassWord
            //{
            //    get { return HttpContext.Current.Session[SPASWORD].ToString(); }
            //}
            //public string UserName
            //{
            //    get { return HttpContext.Current.Session[SUSERNAME].ToString(); }
            //}
            //public e_Role Role
            //{
            //    get { return (e_Role)HttpContext.Current.Session[SROLEID]; }
            //}
        }
        private UserAct userAct = new UserAct();
        private const string QQ = "qqnumber";
        private const string SPASWORD = "password";
        private const string SUSERID = "userid";
        private const string SUSERNAME = "username";
        private const string SROLEID = "roleid";

        public CurrUser User
        {
            get
            {
                CurrUser _curruser = new CurrUser();
                return _curruser;
            }
        }

        public bool IsLogin()
        {
            if (HttpContext.Current.Session[SUSERID] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool UserLogin(string qq, string passWord)
        {
            User user = new User();
            bool success = userAct.Login(qq, passWord, user);
            if (success)
            {
                HttpContext.Current.Session[QQ] = qq;
                HttpContext.Current.Session[SPASWORD] = passWord;
                //  HttpContext .Current .Session [SUSERID ]=user.Id ;
                // HttpContext.Current.Session[SUSERNAME] = user.UserName;
            //    HttpContext.Current.Session[SROLEID] = user.RoleId;

            }
            else
            {

            }
            return success;
        }
    }
}
