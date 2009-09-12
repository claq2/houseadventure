using HouseCore.Presenters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HouseCore;

namespace UnitTests2
{
    
    
    /// <summary>
    ///This is a test class for HousePresenterTest and is intended
    ///to contain all HousePresenterTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HousePresenterTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ProcessMovement
        ///</summary>
        [TestMethod()]
        [DeploymentItem("HouseCore.dll")]
        public void ProcessMovementTest()
        {
            PrivateObject param0 = new PrivateObject(new HousePresenter(new MockView()));
            HousePresenter_Accessor target = new HousePresenter_Accessor(param0);
            Direction direction = Direction.North;
            bool expected = false;
            bool actual;
            actual = target.ProcessMovement(direction);
            Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
