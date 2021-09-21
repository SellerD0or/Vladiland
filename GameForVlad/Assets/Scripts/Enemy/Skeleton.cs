using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, ITrap
{
    [SerializeField] private float _speed = 5f;
    private Player _player;
    [SerializeField] private ParticleSystem _particle;
    private Vector3 _size;
    private void Start() 
    {
        _size = transform.localScale;
        _particle.Pause();
        _player = FindObjectOfType<Player>();
        StartCoroutine(Dead());
    }
    private IEnumerator Dead()
    {
        yield return new WaitForSeconds(2);
        _particle.Play();
        Destroy(gameObject, 0.5f);
    }
   private void Update() {
       bool _isTurned = transform.position.x < _player.transform.position.x;
         float _rotation = _isTurned ? -_size.x : _size.x;
      transform.localScale = new Vector3(_rotation, transform.localScale.y, transform.localScale.z);
       transform.position = Vector2.MoveTowards(transform.position,_player.transform.position, _speed * Time.deltaTime);
   }
}
