using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using ShaneBlog.Core;
using ShaneBlog.Web.Controllers;
using ShaneBlog.Web.Models;
using Moq;
using NUnit.Framework;
namespace ShaneBlog.Web.Test.Unit.Controllers
{
    public class PostControllerTests
    {

        private PostController _controller;
        Mock<IRepository<Post>> _mockRepository;


        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository<Post>>();
            _controller = new PostController(_mockRepository.Object);
        }

        [Test]
        public void CreateShouldSaveToRepository()
        {
            var post = new Post() { Id = 1 };
            _mockRepository.Setup(x => x.Add(post)).Verifiable();

            _controller.Create(post);

            _mockRepository.Verify();
        }



        [Test]
        public void Posts_IsEmptyBeforeAnyCreates()
        {
            Assert.That(_controller.Posts, Is.Empty);
        }



        [Test]
        public void Create_RedirectsToIndex()
        {
            var result = _controller.Create(new Post());
            Assert.That(result, Is.TypeOf(typeof(RedirectToRouteResult)));
        }

        [Test]
        public void Edit_SwapsPostBasedOnId()
        {
            var newPost = new Post() { Body = "New Body" };
            var postToRemove = new Post() { Id = 3, Body = "Old Post 3" };
            var postToKeep = new Post() { Id = 7, Body = "Old Post 7" };
            _controller.Posts.Add(postToRemove);
            _controller.Posts.Add(postToKeep);

            _controller.Edit(3, newPost);
            Assert.That(_controller.Posts, Is.SubsetOf(new List<Post>() { newPost, postToKeep }));
        }

        [Test]
        public void Edit_RedirectsToIndex()
        {
            _controller.Posts.Add(new Post() { Id = 1 });
            var result = _controller.Edit(1, new Post());
            Assert.That(result, Is.TypeOf(typeof(RedirectToRouteResult)));
        }

        [Test]
        public void Delete_RemovesPostWithGivenId()
        {
            var postToKeep = new Post() { Id = 3, Body = "Old Post 3" };
            var postToRemove = new Post() { Id = 7, Body = "Old Post 7" };
            _controller.Posts.Add(postToRemove);
            _controller.Posts.Add(postToKeep);

            _controller.Delete(7, null);
            Assert.That(_controller.Posts.Count, Is.EqualTo(1));
            Assert.That(_controller.Posts, Has.Member(postToKeep));
            Assert.That(_controller.Posts, Has.No.Member(postToRemove));
        }

        [Test]
        public void Delete_RemovesNothingIfPostNotFound()
        {
            var postToKeep = new Post() { Id = 3, Body = "Old Post 3" };
            _controller.Posts.Add(postToKeep);

            _controller.Delete(7, null);
            Assert.That(_controller.Posts.Count, Is.EqualTo(1));
            Assert.That(_controller.Posts, Is.SubsetOf(new List<Post>() { postToKeep }));
        }


        [Test]
        public void Delete_RedirectsToIndex()
        {
            var result = _controller.Delete(4, null);
            Assert.That(result, Is.TypeOf(typeof(RedirectToRouteResult)));
        }



    }
}