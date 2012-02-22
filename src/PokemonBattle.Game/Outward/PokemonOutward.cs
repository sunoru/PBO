using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;
using LightStudio.PokemonBattle.Data;

namespace LightStudio.PokemonBattle.Game
{
  public interface IPokemonEvent
  {
    void Faint();
    void Hurt();
    void PositionChanged();
    void UseItem(); //褐色光圈
    void UseMove(int moveType);
    void HpRecovered(); //绿色光上升
    void Lv5DUp(); //绿色上升
    void Lv5DDown(); //下降
    void SubstituteAppear();
    void SubstituteDisappear();
    void ImageIdChanged(); //幻影 变身
    void Withdrawn();
  }

  [DataContract(Namespace = Namespaces.DEFAULT)]
  public class PokemonOutward : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;
    
    [DataMember]
    internal readonly int Id;
    [DataMember]
    public int OwnerId { get; private set; }
    [DataMember]
    public readonly Position Position;
    [DataMember]
    public PokemonState State { get; set; }
    [DataMember]
    public int ImageId { get; set; }
    //[DataMember]
    //public double Weight; //扬起尘土

    private List<IPokemonEvent> _listeners;
    private List<IPokemonEvent> listeners
    { 
      get
      {
        if (_listeners == null) _listeners = new List<IPokemonEvent>();
        return _listeners;
      }
    }

    internal PokemonOutward(OnboardPokemon pm, PairValue hp)
    {
      _listeners = new List<IPokemonEvent>();
      OwnerId = pm.Owner.Id;
      Id = pm.Id;
      Hp = hp;
      Lv = pm.Lv;
      Position = pm.Position;
    }

    [DataMember]
    public string Name { get; internal set; }
    [DataMember]
    public PokemonGender Gender { get; internal set; }
    [DataMember]
    public PairValue Hp { get; private set; }
    [DataMember]
    public int Lv { get; private set; }

    #region Events
    public void Faint()
    {
      foreach (IPokemonEvent l in listeners)
        l.Faint();
    }
    public void Hurt()
    {
      foreach (IPokemonEvent l in listeners)
        l.Hurt();
    }
    public void PositionChanged()
    {
      foreach (IPokemonEvent l in listeners)
        l.PositionChanged();
    }
    public void UseItem()
    {
      foreach (IPokemonEvent l in listeners)
        l.UseItem();
    }
    public void UseMove(int moveType)
    {
      foreach (IPokemonEvent l in listeners)
        l.UseMove(moveType);
    }
    public void HpRecovered(int currentHp)
    {
      Hp.Value = currentHp;
      foreach (IPokemonEvent l in listeners)
        l.HpRecovered();
    }
    public void Lv5DUp()
    {
      foreach (IPokemonEvent l in listeners)
        l.Lv5DUp();
    }
    public void Lv5DDown()
    {
      foreach (IPokemonEvent l in listeners)
        l.Lv5DDown();
    }
    public void SubstituteAppear()
    {
      foreach (IPokemonEvent l in listeners)
        l.SubstituteAppear();
    }
    public void SubstituteDisappear()
    {
      foreach (IPokemonEvent l in listeners)
        l.SubstituteDisappear();
    }
    public void ImageIdChanged()
    {
      foreach (IPokemonEvent l in listeners)
        l.ImageIdChanged();
      OnPropertyChanged(); //顺序没错
    }
    public void Withdrawn()
    {
      foreach (IPokemonEvent l in listeners)
        l.Withdrawn();
    }
    #endregion

    private void OnPropertyChanged()
    {
      if (PropertyChanged != null)
        PropertyChanged(this, new PropertyChangedEventArgs("Name"));//据说性别虽然改变但不会显示出来
    }
    public void AddListener(IPokemonEvent listener)
    {
      listeners.Add(listener);
    }
    public void RemoveListener(IPokemonEvent listener)
    {
      listeners.Remove(listener);
    }
  }
}
