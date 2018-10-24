using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KellerGame
{
  /// <summary>
  /// Describes an object able to simulate a tick.
  /// </summary>
  public interface ISimulatable
  {
    /// <summary>
    /// Simulates a single tick.
    /// </summary>
    void Simulate();
  }
}