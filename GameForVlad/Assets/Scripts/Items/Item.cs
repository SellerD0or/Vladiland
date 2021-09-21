using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
   // public abstract bool IsFlip{get;set;}
    public abstract  Vector3 Size{get;set;}
    public  Sprite Icon {get;set;}
    public  bool IsActive{get;set;}
    //public abstract void Flip(bool _isTurned);
    
}
