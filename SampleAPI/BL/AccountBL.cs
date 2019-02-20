using SampleAPI.Models;
using SampleAPI.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleAPI.BL
{
    public class AccountBL
    {
        private SampleAssignmentEntities db = new SampleAssignmentEntities();
        public bool SignUpUser(SignUpRequest signuprequestModel)
        {
            try
            {
                var userdetail = new RegisterUser()
                {
                    UserID = signuprequestModel.UserID,
                    FirstName = signuprequestModel.FirstName,
                    LastName = signuprequestModel.LastName,
                    Email = signuprequestModel.Email,
                    Location = signuprequestModel.Location

                };

                var loginCredit = new Login()//assign parameter values to table elements
                {

                    UserID = signuprequestModel.UserID,
                    UserName = signuprequestModel.Username,
                    Password = signuprequestModel.Password
                };


                db.RegisterUsers.Add(userdetail);
                db.Logins.Add(loginCredit);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        public bool Login(LoginModel loginModel)
        {
            var data = (from u in db.Logins
                        select u).ToList();

            var checkuser = data.Where(x => x.UserName == loginModel.Username && x.Password == loginModel.Password);
            if (checkuser.SingleOrDefault()!=null)
            {
                return true;
            }
            return false;
        }
    }
}