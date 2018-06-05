using KellerGame.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KellerGame
{
  /// <summary>
  /// Game class managing all game
  /// infos and actions.
  /// </summary>
  public class Game
  {
    #region Constants

    /// <summary>
    /// The default amount of caps to
    /// start a new game with.
    /// </summary>
    public const int STARTCAPS = 100;

    #endregion Constants

    #region Properties

    /// <summary>
    /// The current amount of caps.
    /// </summary>
    public int Caps { get; private set; }

    /// <summary>
    /// Currently available building slots.
    /// </summary>
    public IReadOnlyList<IBuildingSlot> BuildingSlots => _buildingSlots.AsReadOnly();
    private List<IBuildingSlot> _buildingSlots;

    #endregion Properties

    #region Construction

    /// <summary>
    /// Constructor.
    /// </summary>
    public Game()
    {
      Caps = STARTCAPS;
      _buildingSlots = new List<IBuildingSlot>();
    }

    #endregion Construction

    /// <summary>
    /// Collects caps from all <see cref="ICapProducingBuilding"/>s
    /// in the <see cref="BuildingSlots"/>.
    /// </summary>
    public void CollectAllCaps()
    {
      foreach(var capProducingBuilding in BuildingSlots.Select(b => b.Building).OfType<ICapProducingBuilding>())
      {
        Caps += capProducingBuilding.CollectCaps();
      }
    }

    /// <summary>
    /// Buys the given <paramref name="slot"/> and
    /// adds it to the <see cref="BuildingSlots"/>.
    /// </summary>
    /// <param name="slot"><see cref="IBuildingSlot"/> to buy.</param>
    public void BuyBuildingSlot(IBuildingSlot slot)
    {
      if (slot.Price > Caps)
        throw new Exception("Building slot is not affordable");

      Caps -= slot.Price;
      _buildingSlots.Add(slot);
    }
  }
}