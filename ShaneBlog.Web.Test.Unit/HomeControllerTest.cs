using ShaneBlog.Web.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ShaneBlog.Web.Models;

namespace ShaneBlog.Web.Tests.Unit
{
    public class HomeControllerTests
    {

        [Test]
        public void IndexActionShouldDisplayPosts()
        {
            var controller = new HomeController();
            var actual = controller.Index() as ViewResult;
            Assert.That(actual.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void IndexActionShouldReturnsPosts() {
            var sut = new HomeController();
            var action = sut.Index() as ViewResult;
            Assert.That(action.ViewData.Model, Is.InstanceOf(typeof(IList<Post>)));
        }

        [Test]
        public void IndexActionModelShouldNotBeEmpty() {
            var sut = new HomeController();
            var action = sut.Index() as ViewResult;
            var posts = action.ViewData.Model as IList<Post>;
            Assert.That(posts, Is.Not.Empty);
        }

        [Test]
        public void PostShouldHaveABody() {
            var sut = new Post();
            // sut.Body = "";
        }

        [Test]
        public void PostShouldHaveABodyOfBoo() {
            var sut = new HomeController();
            var action = sut.Index() as ViewResult;
            var posts = action.ViewData.Model as IList<Post>;
            var actual = posts[0];
            Assert.That(actual.Body, Is.EqualTo("Boo"));
        }
    }
}
