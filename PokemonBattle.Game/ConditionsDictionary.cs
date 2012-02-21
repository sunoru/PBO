using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightStudio.PokemonBattle.Game
{
  public class ConditionsDictionary : Dictionary<int, object>
  {
    public new object this[int key]
    {
      get
      {
        object value;
        TryGetValue(key, out value);
        return value;
      }
      set
      {
        base[key] = value;
      }
    }
  }
}
