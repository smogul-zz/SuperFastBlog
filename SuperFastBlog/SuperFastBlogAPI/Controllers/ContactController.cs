using Newtonsoft.Json;
using SuperFastBlogAPI.Data;
using SuperFastBlogAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace SuperFastBlogAPI.Controllers
{
    /// <summary>
    /// The contacts controller
    /// </summary>
    public class ContactController : ApiController
    {
        /// <summary>
        /// database context
        /// </summary>
        protected SuperFastEntities db = new SuperFastEntities();

        /// <summary>
        /// return status
        /// </summary>
        protected ApiStatus apiStatus { get; private set; }
        
        /// <summary>
        /// gets all contacts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/contact/GetMultipleContacts")]
        public ApiStatus GetAllContacts()
        {
            var returnStatus = new ApiStatus();
            try
            {
                List<Contact> result = new List<Contact>();
                var allContacts = db.tbl_contact.OrderByDescending(x => x.ID).ToArray();
                if (allContacts.Length > 0)
                {
                    foreach (var item in allContacts)
                    {
                        result.Add(new Contact
                        {
                            ID = item.ID,
                            Message = item.Message,
                            Date = item.Date,
                            Email = item.Email,
                            Name = item.Name,
                            Phone = item.Phone,
                            PostID = item.PostID,
                            Surname = item.Surname
                       
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
       /// gets a single contact
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        [HttpGet]
        [Route("api/contact/GetAllContact/{id}")]
        public ApiStatus GetContact(int id)
        {
            var returnStatus = new ApiStatus();
            try
            {
                Contact result = null;
                var contact = db.tbl_contact.Where(x => x.ID == id).FirstOrDefault();
                if (contact != null)
                {
                    result = new Contact()
                    {
                        ID = contact.ID,
                        Date = contact.Date,
                        Email = contact.Email,
                        Message = contact.Message,
                        Name = contact.Name,
                        Phone = contact.Phone,
                        PostID = contact.PostID,
                        Surname = contact.Surname

                    };

                    returnStatus.Code = (int)Status.Complete;
                    returnStatus.Message = JsonConvert.SerializeObject(result);
                }
                else
                {
                    returnStatus.Code = (int)Status.NoResult;
                    returnStatus.Message = String.Format("Cannot find contact id {0}.", id);
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
        /// Adds contact
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/contact/AddContact")]
        public ApiStatus AddContact([FromBody] Contact contact)
        {
            var returnStatus = new ApiStatus();
            try
            {
                if (contact != null)
                {
                    db.tbl_contact.Add(new tbl_contact
                    {
                        ID = contact.ID,
                        Date = contact.Date,
                        Email = contact.Email,
                        Message = contact.Message,
                        Name = contact.Name,
                        Phone = contact.Phone,
                        PostID = contact.PostID,
                        Surname = contact.Surname
                    });

                    if (db.SaveChanges() is 0)
                    {
                        returnStatus.Code = (int)Status.Complete;
                        returnStatus.Message = String.Format("{0} successfully added.", contact.Name);
                    }
                }
                else
                {
                    returnStatus.Code = (int)Status.Unknown;
                    returnStatus.Message = "Please enter contact details";
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
        /// removes a contact by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/contact/RemoveContact/{id}")]
        public ApiStatus RemoveContact(int id)
        {
            var returnStatus = new ApiStatus();
            try
            {
                var removeContact = db.tbl_contact.Where(x => x.ID == id).FirstOrDefault();
                if (removeContact != null)
                {
                    db.tbl_contact.Remove(removeContact);
                    if (db.SaveChanges() is 0)
                    {
                        returnStatus.Code = (int)Status.Complete;
                        returnStatus.Message = string.Format("Successfully removed {0}", id);
                    }
                }
                else
                {
                    returnStatus.Code = (int)Status.NoResult;
                    returnStatus.Message = String.Format("Cannot find contact {0}. ", id);
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
        /// removes all contacts
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/contact/RemoveAllContacts")]
        public ApiStatus RemoveAllContacts()
        {
            var returnStatus = new ApiStatus();
            try
            {
                var removeContact = db.tbl_contact.FirstOrDefault();
                if (removeContact != null)
                {
                    db.tbl_contact.Remove(removeContact);
                    if (db.SaveChanges() is 0)
                    {
                        returnStatus.Code = (int)Status.Complete;
                        returnStatus.Message = "Successfully removed all contacts";
                    }
                }
                else
                {
                    returnStatus.Code = (int)Status.NoResult;
                    returnStatus.Message = "Cannot find contacts. ";
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
