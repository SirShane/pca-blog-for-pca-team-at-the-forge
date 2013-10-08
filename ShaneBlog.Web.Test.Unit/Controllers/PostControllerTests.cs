using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using ShaneBlog.Web.Controllers;
using ShaneBlog.Web.Models;
using NUnit.Framework;
namespace ShaneBlog.Web.Test.Unit.Controllers
{
    public class PostControllerTests
    {

        private PostController controller;

        [SetUp]
        public void Setup()
        {
            controller = new PostController();
        }

        [Test]
        public void Posts_IsEmptyBeforeAnyCreates()
        {
            Assert.That(controller.Posts, Is.Empty);
        }

        [Test]
        public void Create_SavesPostToList()
        {
            var post = new Post() { Body = "First Post" };
            controller.Create(post);
            Assert.That(controller.Posts.Count, Is.EqualTo(1));
            Assert.That(controller.Posts[0], Is.EqualTo(post));
        }

        [Test]
        public void Create_RedirectsToIndex()
        {
            var result = controller.Create(new Post());
            Assert.That(result, Is.TypeOf(typeof(RedirectToRouteResult)));
        }

        [Test]
        public void Edit_SwapsPostBasedOnId()
        {
            var newPost = new Post() { Body = "New Body" };
            var postToRemove = new Post() { Id = 3, Body = "Old Post 3" };
            var postToKeep = new Post() { Id = 7, Body = "Old Post 7" };
            controller.Posts.Add(postToRemove);
            controller.Posts.Add(postToKeep);

            controller.Edit(3, newPost);
            Assert.That(controller.Posts, Is.SubsetOf(new List<Post>() { newPost, postToKeep }));
        }

        [Test]
        public void Edit_RedirectsToIndex()
        {
            controller.Posts.Add(new Post() { Id = 1 });
            var result = controller.Edit(1, new Post());
            Assert.That(result, Is.TypeOf(typeof(RedirectToRouteResult)));
        }

        [Test]
        public void Delete_RemovesPostWithGivenId()
        {
            var postToKeep = new Post() { Id = 3, Body = "Old Post 3" };
            var postToRemove = new Post() { Id = 7, Body = "Old Post 7" };
            controller.Posts.Add(postToRemove);
            controller.Posts.Add(postToKeep);

            controller.Delete(7, null);
            Assert.That(controller.Posts.Count, Is.EqualTo(1));
            Assert.That(controller.Posts, Has.Member(postToKeep));
            Assert.That(controller.Posts, Has.No.Member(postToRemove));
        }

        [Test]
        public void Delete_RemovesNothingIfPostNotFound()
        {
            var postToKeep = new Post() { Id = 3, Body = "Old Post 3" };
            controller.Posts.Add(postToKeep);

            controller.Delete(7, null);
            Assert.That(controller.Posts.Count, Is.EqualTo(1));
            Assert.That(controller.Posts, Is.SubsetOf(new List<Post>() { postToKeep }));
        }


        [Test]
        public void Delete_RedirectsToIndex()
        {
            var result = controller.Delete(4, null);
            Assert.That(result, Is.TypeOf(typeof(RedirectToRouteResult)));
        }

    }
}