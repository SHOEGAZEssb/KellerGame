namespace KellerGame.Buildings
{
  /// <summary>
  /// Interface for an object that holds
  /// an <see cref="IBuilding"/>.
  /// </summary>
  public interface IBuildingSlot
  {
    /// <summary>
    /// Currently placed <see cref="IBuilding"/>.
    /// </summary>
    IBuilding Building { get; }

    /// <summary>
    /// The price of this slot.
    /// </summary>
    int Price { get; }

    /// <summary>
    /// Places the given <paramref name="building"/>
    /// in the <see cref="Building"/> slot.
    /// </summary>
    /// <param name="building"></param>
    void PlaceBuilding(IBuilding building);

    /// <summary>
    /// Removes the current <see cref="IBuilding"/>
    /// from the <see cref="Building"/> slot.
    /// </summary>
    void RemoveBuilding();
  }
}