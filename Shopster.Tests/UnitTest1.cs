using System.Diagnostics;

namespace Shopster.Tests
{
    public class NonSharedFixture : IDisposable
    {
        public NonSharedFixture() 
        {
            Debug.WriteLine(message:"Nonshared fixture created.");
        }

        public void Dispose() 
        {
            Debug.WriteLine(message: "Nonshared fixture disposed.");
        }

    }


    public class UnitTest1 : IDisposable
    {
        private readonly NonSharedFixture nonSharedFixture;
        public UnitTest1() 
        {
             nonSharedFixture = new NonSharedFixture();
        }


        [Fact]
        public void Test1()
        {
            //arrange


            //test


            //assert
            Assert.True(true);   




        }

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(2, 2, 4, Skip = "This test is skipped")]
        [InlineData(2, 2, 5)]
        public void ParametrizedTest(int first, int second, int expectedResult)
        {
            //arrange


            //act
            var result = first + second;

            //assert
            Assert.Equal(expectedResult, result);
        }
        public void Dispose()
        {
            Debug.WriteLine(message: "Tests disposed.");
        }

    }
}