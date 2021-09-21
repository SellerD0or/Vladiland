using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
   private void OnTriggerEnter2D(Collider2D other) {
       if (other.GetComponent<Player>())
       {
           _animator.SetBool("_isTriggered", true);
       }
   }
   private void OnTriggerExit2D(Collider2D other) {
              if (other.GetComponent<Player>())
       {
           _animator.SetBool("_isTriggered", false);
       }
   }
}
