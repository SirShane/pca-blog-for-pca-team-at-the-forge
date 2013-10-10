using System.Collections.Generic;
using System.Web.Mvc;
using ShaneBlog.Web.Controllers;
using ShaneBlog.Web.Models;
using NUnit.Framework;

namespace ShaneBlog.Web.Tests.Unit.Controllers
{
    public class HomeControllerTests
    {

        [Test]
        public void IndexActionShouldDisplayPosts()
        {
            var sut = new HomeController();
            var actual = sut.Index() as ViewResult;
            Assert.That(actual.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void IndexActionReturnsPosts()
        {
            var sut = new HomeController();
            var action = sut.Index() as ViewResult;
            Assert.That(action.ViewData.Model, Is.InstanceOf(typeof(IList<Post>)));
        }

        [Test]
        public void IndexActionModelShouldNotBeEmpty()
        {
            var sut = new HomeController();
            var action = sut.Index() as ViewResult;
            var posts = action.ViewData.Model as IList<Post>;
            Assert.That(posts, Is.Not.Empty);
        }

        [Test]
        public void PostShouldHaveABody()
        {
            var sut = new Post();
            // sut.Body = "";
        }

        [Test]
        public void PostShouldHaveABodyOfBoo()
        {
            var sut = new HomeController();
            var action = sut.Index() as ViewResult;
            var posts = action.ViewData.Model as IList<Post>;
            var actual = posts[0];
            Assert.That(actual.Body, Is.EqualTo("Boo"));
        }
    }
}