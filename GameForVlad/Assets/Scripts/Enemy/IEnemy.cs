using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public interface IEnemy 
{
    bool IsCoolDown{get;set;}
    Vector2 StartPosition{get;set;}
    float Speed {get;set;}
    Player Character{get;set;}
   int Damage {get;set;}
   float Health {get;set;}
   float MaxHealth {get;set;}
   void Move();
   void Attack();
   void Dead();
   void TakeDamage(float _damage);
   IEnumerator CoolDown();
   bool IsTurned{get;set;}
   Vector2 Size{get;set;}
   Artefacts Artefact{get;set;}
}
