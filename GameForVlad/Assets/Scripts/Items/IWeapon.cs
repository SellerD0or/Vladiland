using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon 
{
   void Attack();
   float Damage{get;set;}
   float FireRate{get;set;}
   bool CanAttack{get;set;}
   float WaitTime{get;set;}
   IEnumerator CoolDown();
}
