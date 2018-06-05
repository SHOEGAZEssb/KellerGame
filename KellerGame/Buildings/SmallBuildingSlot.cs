using System;

namespace KellerGame.Buildings
{
  public class SmallBuildingSlot : IBuildingSlot
  {
    #region Properties

    public IBuilding Building { get; private set; }

    public int Price => 500;

    #endregion Properties

    public void PlaceBuilding(IBuilding building)
    {
      if (Building != null)
        throw new InvalidOperationException("Slot already occupied by a building");

      Building = building ?? throw new ArgumentNullException(nameof(building));
    }

    public IBuilding RemoveBuilding()
    {
      if (Building == null)
        throw new InvalidOperationException("Slot is empty");

      var removedBuilding = Building;
      Building = null;
      return removedBuilding;
    }
  }
}
