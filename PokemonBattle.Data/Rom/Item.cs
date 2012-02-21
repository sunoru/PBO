using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using LightStudio.Tactic.DataModels;

namespace LightStudio.PokemonBattle.Data
{
  [DataContract(Namespace=Namespaces.DEFAULT)]
  public class Item : ExecutableGameElement<IController>
  {
    [DataMember(EmitDefaultValue = false)]
    public bool IsOneTime { get; set; }

    [DataMember(EmitDefaultValue = false)]
    public int FlingPower { get; set; }

    public IExecutableElement<IController> FlingEffect { get; internal set; }
    
    public Item(int id)
      : base(id)
    {
    }
  }
}
