using System;
using Day3_Homework.Controllers.Models;

namespace Day3_Homework.Models
{
    public class AuthService : IAuth
    {
        private IProfileDao _profileDao;
        private IHash _auth;

        public IProfileDao ProfileDao
        {
            get
            {
                if (this._profileDao == null)
                {
                    this._profileDao = new ProfileDao();
                }

                return this._profileDao;
            }
            set
            {
                this._profileDao = value;
            }
        }

        public IHash Hash
        {
            get
            {
                if (this._auth == null)
                {
                    this._auth = new MyHash();
                }

                return this._auth;
            }
            set
            {
                this._auth = value;
            }
        }

        public bool Validate(string account, string password)
        {
            string passwordFromDao = this.ProfileDao.GetPassword(account);
            string hashResult = this.Hash.GetHash(password);

            return passwordFromDao == hashResult;
        }
    }
}