using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightStudio.PokemonBattle.Game
{
  class PokemonProxy
  {
    private readonly IController Controller;
    private readonly OnboardPokemon Pokemon;

    public PokemonProxy(IController controller, OnboardPokemon pokemon)
    {
      Controller = controller;
      Pokemon = pokemon;
    }

    public bool HasWorkingAbility(int abilityId)
    {
      return Pokemon.Ability.Id == abilityId && true;
    }

    #region 7D
    public int GetAtk()
    {
      throw new NotImplementedException();
    }
    #endregion
  }
}
