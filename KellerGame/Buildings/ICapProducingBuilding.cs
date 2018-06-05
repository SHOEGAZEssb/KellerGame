namespace KellerGame.Buildings
{
  /// <summary>
  /// Interface for an <see cref="IBuilding"/>
  /// that can produce caps.
  /// </summary>
  public interface ICapProducingBuilding : IBuilding
  {
    /// <summary>
    /// Collects all caps currently stored.
    /// </summary>
    /// <returns>All collected caps.</returns>
    int CollectCaps();
  }
}