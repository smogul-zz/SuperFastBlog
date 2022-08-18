using Newtonsoft.Json;
using SuperFastBlogAPI.Data;
using SuperFastBlogAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperFastBlogAPI.Controllers
{
    public class ArticleController : ApiController
    {
        protected SuperFastEntities db = new SuperFastEntities();
        protected ApiStatus apiStatus { get; private set; }

        /// <summary>
        /// call to GetAllArticles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/article/GetAllArticles")]
        public ApiStatus GetArticles()
        {
            var returnStatus = new ApiStatus();
            try
            {
                List<Article> result = new List<Article>();
                var allArticles = db.tbl_article.OrderByDescending(x => x.ID).ToArray();
                if (allArticles.Length > 0)
                {
                    foreach (var item in allArticles)
                    {
                        result.Add(new Article
                        {
                            ID = item.ID,
                            Content = item.Content,
                            DatePosted = item.DatePosted,
                            Heading = item.Heading,
                            Image = item.Image,
                            PostedUserID = item.PostedUserID,
                            Topic = item.Topic

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
        /// gets all articles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       [Route("api/article/GetArticle")]
        [HttpGet]
        public ApiStatus GetArticle(int id)
        {
            var returnStatus = new ApiStatus();
            try
            {
                Article result = null;
                var article = db.tbl_article.Where(x => x.ID == id).FirstOrDefault();
                if (article != null)
                {
                    result = new Article()
                    {
                        ID = article.ID,
                        Content = article.Content,
                        DatePosted = article.DatePosted,
                        Heading = article.Heading,
                        Image = article.Image,
                        PostedUserID = article.PostedUserID,
                        Topic = article.Topic

                    };

                    returnStatus.Code = (int)Status.Complete;
                    returnStatus.Message = JsonConvert.SerializeObject(result);
                }
                else
                {
                    returnStatus.Code = (int)Status.NoResult;
                    returnStatus.Message = String.Format("Cannot find article id {0}.", id);
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
        /// adds an article
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [Route("api/article/AddArticle")]
        [HttpPost]
        public ApiStatus AddArticle([FromBody] Article article)
        {
            var returnStatus = new ApiStatus();
            try
            {
                if (article != null)
                {
                    db.tbl_article.Add(new tbl_article
                    {
                        ID = article.ID,
                        Content = article.Content,
                        DatePosted = article.DatePosted,
                        Heading = article.Heading,
                        Image = article.Image,
                        PostedUserID = article.PostedUserID,
                        Topic = article.Topic
                    });

                    if (db.SaveChanges() is 0)
                    {
                        returnStatus.Code = (int)Status.Complete;
                        returnStatus.Message = String.Format("{0} successfully added.", article.Heading);
                    }
                }
                else
                {
                    returnStatus.Code = (int)Status.Unknown;
                    returnStatus.Message = "Please enter article details";
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
        /// call to update artivle
        /// </summary>
        /// <param name="id"></param>
        /// <param name="article"></param>
        /// <returns></returns>
        [Route("api/article/UpdateArticle")]
        [HttpPut]
        public ApiStatus UpdateArticle(int id, [FromBody] Article article)
        {
            var returnStatus = new ApiStatus();
            try
            {
                if (article != null)
                {
                    var removeArticle = db.tbl_article.Where(x => x.ID == id).FirstOrDefault();
                    if (removeArticle != null)
                    {
                        db.Entry(removeArticle).CurrentValues.SetValues(article);
                        if (db.SaveChanges() is 0)
                        {
                            returnStatus.Code = (int)Status.Complete;
                            returnStatus.Message = String.Format("Successfully removed {0}", removeArticle.Heading);
                        }
                    }
                    else
                    {
                        returnStatus.Code = (int)Status.NoResult;
                        returnStatus.Message = String.Format("Cannot find article id {0}. ", id);
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
        /// call to remove an article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/article/DeleteArticle")]
        [HttpDelete]
        public ApiStatus RemoveArticle(int id)
        {
            var returnStatus = new ApiStatus();
            try
            {
                var removeArticle = db.tbl_article.Where(x => x.ID == id).FirstOrDefault();
                if (removeArticle != null)
                {
                    db.tbl_article.Remove(removeArticle);
                    if (db.SaveChanges() is 0)
                    {
                        returnStatus.Code = (int)Status.Complete;
                        returnStatus.Message = string.Format("Successfully removed {0}", id);
                    }
                }
                else
                {
                    returnStatus.Code = (int)Status.NoResult;
                    returnStatus.Message = String.Format("Cannot find article {0}. ", id);
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
