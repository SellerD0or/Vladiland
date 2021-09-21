using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBullet : MonoBehaviour, ITrap
{
    [SerializeField] private Vector2 _vector;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private List< Transform> _points;
    private bool _isCoolDown;

 private void Update() 
 {
     transform.position = Vector3.MoveTowards(transform.position, _points[0].position, _speed * Time.deltaTime);
     if (!_isCoolDown)
     {
         StartCoroutine(CoolDown());
     }
 }
 IEnumerator CoolDown()
 {
     _points.Reverse();
     _isCoolDown = true;
     yield return new WaitForSeconds(1);
     _isCoolDown = false;
 }
}
