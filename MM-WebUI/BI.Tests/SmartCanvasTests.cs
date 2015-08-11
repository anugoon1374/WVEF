using System;
using System.Collections.Generic;
using System.Linq;
using BI.Core.Models;
using BI.Infrastructure;
using Xunit;
using BI.Service;

namespace BI.Tests
{
    public class SmartCanvasTests
    {
        public SmartCanvasService Sut { get; }

        public SmartCanvasTests()
        {
            Sut = new SmartCanvasService(
                AppSettings.Get("SmartCanvas-node", "127.0.0.1"),
                AppSettings.Get("SmartCanvas-id", ""),
                AppSettings.Get("SmartCanvas-token", ""));
        }

        [Theory, InlineData("6258364619161600")]
        public async void GetAsyncTest(string uid)
        {
            await Sut.GetAsync(uid);
        }

        [Fact]
        public async void CreateAsyncTest()
        {
            var newCanvas = new SmartCanvas()
            {
                Title = "Test Company",
                Summary = "This is a test company",
                AutoApprove = true,
                MetaTags = new List<string>() { "c2" },
                ContentProvider = new ContentProvider() { ContentId = "1438266605416", Id = "angular-web-app", UserId = "angular-web-app-user" },
                Categories = new List<string>() { "angular-client", "smes", "us-en" },
                //JsonExtendedData = "";
                Content = "This is content",
                Attachments = new List<string>()
            };

            await Sut.CreateAsync(newCanvas);
        }
    }
}
