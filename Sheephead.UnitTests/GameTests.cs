using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Sheephead.UnitTests
{
    [TestClass]
    public class GameTests
    {
        private Game _testGame;
        private Mock<Player> _mockPlayer1;
        private Mock<Player> _mockPlayer2;
        private Mock<Player> _mockPlayer3;

        [TestMethod]
        public void When_AGameIsStarted_Expect_ThePlayerIsTheDealer()
        {
            // Assert
            Assert.AreSame(_mockPlayer1.Object, _testGame.Dealer);
        }

        [TestMethod]
        public void When_DealIsCalled_Expect_EachPlayerHas10Cards()
        {
            // Arrange
            var mockHand1 = new Mock<Hand>();
            var mockHand2 = new Mock<Hand>();
            var mockHand3 = new Mock<Hand>();

            _mockPlayer1.SetupGet(p => p.Hand).Returns(mockHand1.Object);
            _mockPlayer2.SetupGet(p => p.Hand).Returns(mockHand2.Object);
            _mockPlayer3.SetupGet(p => p.Hand).Returns(mockHand3.Object);

            // Act
            _testGame.Deal();

            // Assert
            mockHand1.Verify(h => h.AddCard(It.IsAny<object>()), Times.Exactly(10));
            mockHand2.Verify(h => h.AddCard(It.IsAny<object>()), Times.Exactly(10));
            mockHand3.Verify(h => h.AddCard(It.IsAny<object>()), Times.Exactly(10));
        }

        [TestMethod]
        public void When_DealIsCalled_Expect_ThatTheBlindHas2Cards()
        {
            // Act
            _testGame.Deal();

            // Assert
            Assert.AreEqual(2, _testGame.Blind.Cards.Length);
        }

        [TestInitialize]
        public void Setup()
        {
            _mockPlayer1 = new Mock<Player>("Player1");
            _mockPlayer2 = new Mock<Player>("Player2");
            _mockPlayer3 = new Mock<Player>("Player3");
            _testGame = new Game(_mockPlayer1.Object, _mockPlayer2.Object, _mockPlayer3.Object);
        }
    }
}
