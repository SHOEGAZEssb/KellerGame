using KellerGame.Buildings;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace KellerGame.Test
{
  /// <summary>
  /// Tests for the <see cref="Game"/>.
  /// </summary>
  [TestFixture]
  class GameTest
  {
    /// <summary>
    /// Tests the construction of a <see cref="Game"/>
    /// and if default values are ok.
    /// </summary>
    [Test]
    public void ConstructionTest()
    {
      // given: Game
      // when: constructing a Game
      Game game = new Game();

      // then: default values
      Assert.That(game.Caps, Is.EqualTo(Game.STARTCAPS));
    }

    /// <summary>
    /// Tests the collection of caps from
    /// all <see cref="IBuilding"/>s.
    /// </summary>
    [Test]
    public void CollectAllTest()
    {
      // given: Game with mocks

      int building1Caps = 100;
      Mock<ICapProducingBuilding> buildingMock = new Mock<ICapProducingBuilding>(MockBehavior.Strict);
      buildingMock.Setup(b => b.CollectCaps()).Returns(building1Caps);

      Mock<IBuildingSlot> buildingSlotMock = new Mock<IBuildingSlot>();
      buildingSlotMock.Setup(b => b.Building).Returns(buildingMock.Object);
      buildingSlotMock.Setup(b => b.Price).Returns(Game.STARTCAPS / 2);

      int building2Caps = 150;
      Mock<ICapProducingBuilding> buildingMock2 = new Mock<ICapProducingBuilding>(MockBehavior.Strict);
      buildingMock2.Setup(b => b.CollectCaps()).Returns(building2Caps);

      Mock<IBuildingSlot> buildingSlotMock2 = new Mock<IBuildingSlot>();
      buildingSlotMock2.Setup(b => b.Building).Returns(buildingMock2.Object);
      buildingSlotMock2.Setup(b => b.Price).Returns(Game.STARTCAPS / 2);

      Game game = new Game();
      game.BuyBuildingSlot(buildingSlotMock.Object);
      game.BuyBuildingSlot(buildingSlotMock2.Object);

      // when: collecting the caps
      game.CollectAllCaps();

      // then: caps have been added to the game
      int caps = (Game.STARTCAPS - game.BuildingSlots.Sum(b => b.Price)) + (building1Caps + building2Caps);
      Assert.That(game.Caps, Is.EqualTo(caps));
    }
  }
}