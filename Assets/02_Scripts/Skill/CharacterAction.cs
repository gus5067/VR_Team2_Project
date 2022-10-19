using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// VR
public class CharacterAction
{
    public bool isEnd = false;

    public virtual void OnStart(Vehicle owner)
    {

    }

    public virtual void OnUpdate(Vehicle owner)
    {

    }

    public virtual void OnExit(Vehicle owner)
    {

    }

    public CharacterAction Copy()
    {
        return (CharacterAction)this.MemberwiseClone();
    }

}