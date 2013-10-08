using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShaneBlog.Web.Models;

namespace ShaneBlog.Web.Controllers
{
    public class PostController : Controller
    {
        public PostController()
        {
            Posts = new List<Post>();
        }

        public List<Post> Posts { get; private set; }
        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(Post post)
        {
            try
            {
                Posts.Add(post);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Post/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(int postId, Post newPost)
        {
            try
            {
                var oldPost = Posts.FirstOrDefault(post => post.Id == postId);
                Posts.Remove(oldPost);
                Posts.Add(newPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Post/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Post/Delete/5

        [HttpPost]
        public ActionResult Delete(int postId, FormCollection collection)
        {
            try
            {
                var oldPost = Posts.FirstOrDefault(post => post.Id == postId);
                Posts.Remove(oldPost);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}  
