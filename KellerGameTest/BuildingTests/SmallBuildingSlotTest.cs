using KellerGame.Buildings;
using Moq;
using NUnit.Framework;

namespace KellerGame.Test.BuildingTests
{
  /// <summary>
  /// Tests for the <see cref="SmallBuildingSlot"/>.
  /// </summary>
  [TestFixture]
  class SmallBuildingSlotTest
  {
    /// <summary>
    /// Tests the construction of a <see cref="SmallBuildingSlot"/>
    /// and if the default values are set correctly.
    /// </summary>
    [Test]
    public void ConstructionTest()
    {
      // given: SmallBuildingSlot
      // when: constructing
      SmallBuildingSlot slot = new SmallBuildingSlot();

      // then: default values
      Assert.That(slot.Building, Is.Null);
    }

    /// <summary>
    /// Tests the placing of an <see cref="IBuilding"/>
    /// in an <see cref="SmallBuildingSlot"/> without
    /// any previous places <see cref="IBuilding"/>s.
    /// </summary>
    [Test]
    public void PlaceBuildingTest()
    {
      // given: SmallBuildingSlot and Building
      Mock<IBuilding> buildingMock = new Mock<IBuilding>(MockBehavior.Strict);

      SmallBuildingSlot slot = new SmallBuildingSlot();

      // when: placing the slot
      slot.PlaceBuilding(buildingMock.Object);

      // then: Building is places
      Assert.That(slot.Building, Is.SameAs(buildingMock.Object));
    }

    /// <summary>
    /// Tests the placing of an <see cref="IBuilding"/>
    /// in an <see cref="SmallBuildingSlot"/> that is
    /// already occupied.
    /// </summary>
    [Test]
    public void PlaceBuildingOccupiedTest()
    {
      // given: SmallBuildingSlot and Buildings
      Mock<IBuilding> buildingMock = new Mock<IBuilding>(MockBehavior.Strict);
      Mock<IBuilding> buildingMock2 = new Mock<IBuilding>(MockBehavior.Strict);

      SmallBuildingSlot slot = new SmallBuildingSlot();
      slot.PlaceBuilding(buildingMock.Object);

      // when: placing the second slot
      // then: InvalidOperationException thrown
      Assert.That(() => slot.PlaceBuilding(buildingMock2.Object), Throws.InvalidOperationException);
    }

    /// <summary>
    /// Tests the placing of null.
    /// </summary>
    [Test]
    public void PlaceNullBuildingTest()
    {
      // given: SmallBuildingSlot
      SmallBuildingSlot slot = new SmallBuildingSlot();

      // when: placing a null Building
      // then: ArgumentNullException
      Assert.That(() => slot.PlaceBuilding(null), Throws.ArgumentNullException);
    }

    /// <summary>
    /// Tests the removal of an <see cref="IBuilding"/>.
    /// </summary>
    [Test]
    public void RemoveBuildingTest()
    {
      // given: SmallBuildingSlot with a Building
      Mock<IBuilding> buildingMock = new Mock<IBuilding>(MockBehavior.Strict);

      SmallBuildingSlot slot = new SmallBuildingSlot();
      slot.PlaceBuilding(buildingMock.Object);

      // when: removing the Building
      var removedBuilding = slot.RemoveBuilding();

      // then: slot Building is null and correct Building was returned
      Assert.That(slot.Building, Is.Null);
      Assert.That(removedBuilding, Is.SameAs(buildingMock.Object));
    }

    /// <summary>
    /// Tests the removal of null.
    /// </summary>
    [Test]
    public void RemoveNullBuildingTest()
    {
      // given: SmallBuildingSlot
      SmallBuildingSlot slot = new SmallBuildingSlot();

      // when: removing the Building
      // then: InvalidOperationException
      Assert.That(() => slot.RemoveBuilding(), Throws.InvalidOperationException);
    }

    /// <summary>
    /// Tests the simulation of a building in the building slot.
    /// </summary>
    [Test]
    public void SimulateTest()
    {
      // given: SmallBuildingSlot with building mock
      Mock<IBuilding> buildingMock = new Mock<IBuilding>(MockBehavior.Strict);
      buildingMock.Setup(b => b.Simulate());

      SmallBuildingSlot slot = new SmallBuildingSlot();
      slot.PlaceBuilding(buildingMock.Object);

      // when: simulating the slot
      slot.Simulate();

      // then: building was simulated
      Assert.That(() => buildingMock.Verify(b => b.Simulate(), Times.Once), Throws.Nothing);
    }
  }
}