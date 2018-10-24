using System;

namespace KellerGame.Buildings
{
  public class SmallBuildingSlot : IBuildingSlot
  {
    #region Properties

    /// <summary>
    /// The building places on this building slot.
    /// </summary>
    public IBuilding Building { get; private set; }

    /// <summary>
    /// Default price for this building slot.
    /// </summary>
    public int Price => 500;

    #endregion Properties

    /// <summary>
    /// Places the given <paramref name="building"/>
    /// in the <see cref="Building"/> slot.
    /// </summary>
    /// <param name="building">Building to place.</param>
    public void PlaceBuilding(IBuilding building)
    {
      if (Building != null)
        throw new InvalidOperationException("Slot already occupied by a building");

      Building = building ?? throw new ArgumentNullException(nameof(building));
    }

    /// <summary>
    /// Removes the current <see cref="Building"/>.
    /// </summary>
    /// <returns>The removed building.</returns>
    public IBuilding RemoveBuilding()
    {
      if (Building == null)
        throw new InvalidOperationException("Slot is empty");

      var removedBuilding = Building;
      Building = null;
      return removedBuilding;
    }

    /// <summary>
    /// Simulates the <see cref="Building"/>.
    /// </summary>
    public void Simulate()
    {
      Building?.Simulate();
    }
  }
}