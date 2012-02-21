using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LightStudio.PokemonBattle.Data;
using LightStudio.PokemonBattle.Game;

namespace LightStudio.PokemonBattle.PBO.Battle
{
  /// <summary>
  /// Interaction logic for Pokemon2D.xaml
  /// </summary>
  public partial class OPokemon2D : Canvas, IPokemonEvent
  {
    PokemonOutward pokemon;

    public OPokemon2D()
    {
      InitializeComponent();
    }

    public void Sendout(PokemonOutward pm)
    {
      pokemon = pm;
      if (pokemon != null)
      {
        pokemon.AddListener(this);
        if (pokemon.Gender == PokemonGender.Female)
          main.Source = DataService.Image.GetPokemonFemaleBack(pokemon.ImageId);
        else main.Source = DataService.Image.GetPokemonMaleBack(pokemon.ImageId);
      }
    }
    void IPokemonEvent.Faint()
    {
    }
    void IPokemonEvent.Hurt()
    {
    }
    void IPokemonEvent.PositionChanged()
    {
    }
    void IPokemonEvent.UseItem() //褐色光圈
    {
    }
    void IPokemonEvent.UseMove(int moveType)
    {
    }
    void IPokemonEvent.HpRecovered() //绿色光上升
    {
    }
    void IPokemonEvent.Lv5DUp() //绿色上升
    {
    }
    void IPokemonEvent.Lv5DDown() //下降
    {
    }
    void IPokemonEvent.SubstituteAppear()
    {
    }
    void IPokemonEvent.SubstituteDisappear()
    {
    }
    void IPokemonEvent.ImageIdChanged()
    {
    }
    void IPokemonEvent.Withdrawn()
    {
      pokemon.RemoveListener(this);
      pokemon = null;
    }
  }
}
