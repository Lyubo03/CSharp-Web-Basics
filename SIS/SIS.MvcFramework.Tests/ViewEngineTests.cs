namespace SIS.MvcFramework.Tests
{
    using SIS.MVCFramework;
    using System.Collections.Generic;
    using System.IO;
    using Xunit;
    public class ViewEngineTests
    {
        [Theory]
        [InlineData("OnlyHtmlView")]
        [InlineData("ForForeachIfView")]
        [InlineData("ViewModelView")]

        public void GetHtmlTests(string testName)
        {
            var viewModel = new TestViewModel()
            {
                Name = "Stamat",
                Year = 2021,
                Numbers = new List<int>() { 1, 10, 100, 1000, 10000 }
            };

            var viewContent = File.ReadAllText($"ViewTests/{testName}.html");
            var expectedResults = File.ReadAllText($"ViewTests/{testName}.Expected.html");

            var viewEngine = new ViewEngine();
            var actualResut = viewEngine.GetHtml(viewContent, viewModel);

            Assert.Equal(expectedResults, actualResut);
        }
    }
}