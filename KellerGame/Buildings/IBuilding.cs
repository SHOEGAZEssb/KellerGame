namespace KellerGame.Buildings
{
  /// <summary>
  /// Interface for a building.
  /// </summary>
  public interface IBuilding : ISimulatable
  {
    /// <summary>
    /// Price of this building.
    /// </summary>
    int Price { get; }
  }
}