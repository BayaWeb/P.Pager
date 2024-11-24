namespace P.Pager.Tests
{
    public class PagerTest
    {
        [Fact]
        public void StartPageTest()
        {
            List<int> list = Enumerable.Range(1, 200).ToList();
            List<int> expectedList = Enumerable.Range(1, 20).ToList(); // get list from 1 to 20
            IPager<int> firstPage = list.ToPagerList(1, 20); // first page from 1 to 20, page size = 20
            Assert.Equal(expectedList, firstPage);//Test Passed
        }

        [Fact]
        public void MiddlePageTest()
        {
            List<int> list = Enumerable.Range(1, 200).ToList();
            List<int> expectedList = Enumerable.Range(21, 20).ToList(); // get list from 21 to 40
            IPager<int> secondPage = list.ToPagerList(2, 20); // second page from 21 to 40, page size = 20
            Assert.Equal(expectedList, secondPage);//Test Passed
        }

        [Fact]
        public void LastPageTest()
        {
            List<int> list = Enumerable.Range(1, 200).ToList();
            List<int> expectedList = Enumerable.Range(21, 20).ToList(); // get list from 21 to 40
            IPager<int> lastPage = list.ToPagerList(10, 20); // second page is last page
            Assert.NotSame(expectedList, lastPage);//Test Passed
        }

        [Fact]
        public void InvalidPageTest()
        {
            List<int> list = Enumerable.Range(1, 200).ToList();
            List<int> expectedList = Enumerable.Range(181, 200).ToList(); // get list from 21 to 40
            IPager<int> validPage = list.ToPagerList(12, 20); // Here totalPageCount is 10 but takes Index as 12
            Assert.NotSame(expectedList, validPage);//Test Passed
        }


        [Fact]
        public void NextPageCheck()
        {
            List<int> list = Enumerable.Range(1, 200).ToList();
            List<int> expectedList = Enumerable.Range(21, 20).ToList(); // get list from 21 to 40
            IPager<int> page = list.ToPagerList(1, 20); // second page from 21 to 40, page size = 20
            Assert.True(page.HasNextPage);//Test Passed
        }
    }
}
