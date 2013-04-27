using System;
using System.Collections.Generic;
using System.Text;

namespace integral.Action
{
    public class User
    {
        //   private int _id;
        // private string _qq;
        private string _qq;
        private string _loginPassWord;
        private int _roleId;
        private bool _boolUse;
        private string _tuijianQQ;

        public int Jifen { get; set; }
        public DateTime CreatedAt { get; set; }

        public int Limit { get; set; }

        public bool CanLogin { get; set; }
        public int Shouyi { get; set; }
        //public int Id
        //{
        //    get
        //    {
        //        return _id;
        //    }
        //    set
        //    {
        //        _id = value;
        //    }
        //}
        //public string UserName
        //{
        //    get
        //    {
        //        return _userName;
        //    }
        //    set
        //    {
        //        _userName = value;
        //    }
        //}

        public string TuijianrenQQ
        {
            get
            {
                return _tuijianQQ;
            }
            set
            {
                _tuijianQQ = value;
            }
        }
        public string QQ
        {
            get
            {
                return _qq;
            }
            set
            {
                _qq = value;
            }
        }
        public string LoginPassWord
        {
            get
            {
                return _loginPassWord;
            }
            set
            {
                _loginPassWord = value;
            }
        }

        public string Mac { get; set; }
        //public int RoleId
        //{
        //    get
        //    {
        //        return _roleId;
        //    }
        //    set
        //    {
        //        _roleId = value;
        //    }
        //}
        //public bool BoolUse
        //{
        //    get
        //    {
        //        return _boolUse;
        //    }
        //    set
        //    {
        //        _boolUse = value;
        //    }
        //}
    }
}
