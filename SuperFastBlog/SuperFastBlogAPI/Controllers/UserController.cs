using Newtonsoft.Json;
using SuperFastBlogAPI.Data;
using SuperFastBlogAPI.Extensions;
using SuperFastBlogAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

//using System.Web.Mvc;
using System.Web.Http;

namespace SuperFastBlogAPI.Controllers
{
    /// <summary>
    /// Our user controller
    /// </summary>
    public class UserController : ApiController
    {
        /// <summary>
        /// database entity context
        /// </summary>
        protected SuperFastEntities db = new SuperFastEntities();

        /// <summary>
        /// return class
        /// </summary>
        protected ApiStatus apiStatus { get; private set; }

        /// <summary>
        /// Retrieves all the users
        /// </summary>
        /// <returns></returns>
        [Route("api/user/GetAllUsers")]
        [HttpGet]
        public ApiStatus GetUsers()
        {
            var returnStatus = new ApiStatus();
            try
            {
                List<User> result = new List<User>();
                var allUsers = db.tbl_user.OrderByDescending(x => x.ID).ToArray();
                if (allUsers.Length > 0)
                {
                    foreach (var item in allUsers)
                    {
                        result.Add(new User
                        {
                            ID = item.ID,
                            Role = item.Role,
                            Username = item.Username

                        });
                    }

                    returnStatus.Code = (int)Status.Complete;
                    returnStatus.Message = JsonConvert.SerializeObject(result);
                }
                else
                {
                    returnStatus.Code = (int)Status.NoResult;
                    returnStatus.Message = "No result found";
                }
            }
            catch (Exception e)
            {
                returnStatus.Code = (int)Status.NoResult;
                returnStatus.Message = string.Format("{0}", e.Message);
            }
            return returnStatus;
        }

        /// <summary>
        /// gets one user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.Route("api/user/GetOneUser")]
        [System.Web.Http.HttpGet]
        public ApiStatus GetUser(int id)
        {
            var returnStatus = new ApiStatus();
            try
            {
                User result = null;
                var user = db.tbl_user.Where(x => x.ID == id).FirstOrDefault();
                if (user != null)
                {
                    result = new User()
                    {
                        ID = user.ID,
                        Username = user.Username,
                        Role = user.Role
                    };

                    returnStatus.Code = (int)Status.Complete;
                    returnStatus.Message = JsonConvert.SerializeObject(result);
                }
                else
                {
                    returnStatus.Code = (int)Status.NoResult;
                    returnStatus.Message = String.Format("Cannot find user id {0}.", id);
                }
            }
            catch (Exception e)
            {
                returnStatus.Code = (int)Status.Error;
                returnStatus.Message = String.Format("{0}", e.Message);
            }
            return returnStatus;
        }

        /// <summary>
        /// adds a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("api/user/AddUser")]
        [System.Web.Http.HttpPost]
        public ApiStatus AddUser([System.Web.Http.FromBody] User user)
        {
            var returnStatus = new ApiStatus();
            try
            {
                if (user != null)
                {
                    var flavorPw = Helper.GenerateSalt(70);
                    db.tbl_user.Add(new tbl_user
                    {
                        Password = Helper.HashPassword(user.Password, flavorPw, 10102, 70),
                        Username = user.Username,
                        Role = user.Role
                    });

                    if (db.SaveChanges() is 0)
                    {
                        returnStatus.Code = (int)Status.Complete;
                        returnStatus.Message = String.Format("{0} successfully added.", user.Username);
                    }
                }
                else
                {
                    returnStatus.Code = (int)Status.Unknown;
                    returnStatus.Message = "Please enter user details";
                }
            }
            catch (Exception e)
            {
                returnStatus.Code = (int)Status.Error;
                returnStatus.Message = String.Format("{0}", e.Message);
            }
            return returnStatus;
        }

        /// <summary>
        /// updates a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [Route("api/user/ModifyUser")]
        [HttpPut]
        public ApiStatus UpdateUser(int id, [System.Web.Http.FromBody] User user)
        {
            var returnStatus = new ApiStatus();
            try
            {
                if (user != null)
                {
                    var removeUser = db.tbl_user.Where(x => x.ID == id).FirstOrDefault();
                    if (removeUser != null)
                    {
                        db.Entry(removeUser).CurrentValues.SetValues(user);
                        if (db.SaveChanges() is 0)
                        {
                            returnStatus.Code = (int)Status.Complete;
                            returnStatus.Message = String.Format("Successfully removed {0}", removeUser.Username);
                        }
                    }
                    else
                    {
                        returnStatus.Code = (int)Status.NoResult;
                        returnStatus.Message = String.Format("Cannot find user {0}. ", id);
                    }
                }
            }
            catch (Exception e)
            {
                returnStatus.Code = (int)Status.Error;
                returnStatus.Message = String.Format("{0}", e.Message);
            }
            return returnStatus;
        }

        /// <summary>
        /// deletes a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/user/DeleteUse")]
        [HttpDelete]
        public ApiStatus RemoveUser(int id)
        {
            var returnStatus = new ApiStatus();
            try
            {
                var removeUser = db.tbl_user.Where(x => x.ID == id).FirstOrDefault();
                if (removeUser != null)
                {
                    db.tbl_user.Remove(removeUser);
                    if (db.SaveChanges() is 0)
                    {
                        returnStatus.Code = (int)Status.Complete;
                        returnStatus.Message = string.Format("Successfully removed {0}", removeUser.Username);
                    }
                }
                else
                {
                    returnStatus.Code = (int)Status.NoResult;
                    returnStatus.Message = String.Format("Cannot find user {0}. Please check spelling", removeUser.Username);
                }
            }
            catch (Exception e)
            {
                returnStatus.Code = (int)Status.Error;
                returnStatus.Message = String.Format("{0}", e.Message);
            }
            return returnStatus;
        }
    }
}