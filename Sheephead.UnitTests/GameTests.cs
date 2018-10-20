using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sheephead.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void When_AGameIsStarted_Expect_ThePlayerIsTheDealer()
        {
            // Arrange
            var p1 = new Player("Player1");
            var p2 = new Player("Player2");
            var p3 = new Player("Player3");
            var game = new Game(p1, p2,p3);

            // Assert
            Assert.AreSame(p1, game.Dealer);
        }

        
    }
}
