using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{ 
     private bool _canAttack;
     [SerializeField] private Animator _animator;
    [SerializeField] private Vector2[] _vectrors;
    private bool _isTimeOver;
    private bool _isRight;
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rigidbody2d;
   private void Update() {
   
     
        int _rotation = _isRight ? 1 :0;
        transform.Translate(  _vectrors[_rotation] * _speed * Time.deltaTime);
        if(!_isTimeOver)
        {
        StartCoroutine(CoolDown());
        }
   }
   private IEnumerator CoolDown()
   {
        _isRight =! _isRight;
       _isTimeOver = true;
       Debug.LogError(_isRight);
       int _randomWaitTime = Random.Range(1,2);
       yield return new WaitForSeconds(_randomWaitTime);
       _isTimeOver = false;
   }
   private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<Player>())
        {
            ChangeAttack();
        }
   }
   private void OnTriggerExit2D(Collider2D other) {
        if (other.GetComponent<Player>())
        {
            ChangeAttack();
        }
   }
   private void ChangeAttack()
   {
        _canAttack =! _canAttack;
        _animator.SetBool("_isTriggered", _canAttack);
   }
}
