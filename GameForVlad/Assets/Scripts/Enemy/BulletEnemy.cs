using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour, ITrap
{
    private Player _player;

    public Player Character { get => _player; set => _player = value; }
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _destroyTime =5f;
    private void Start() {
        Destroy(gameObject, _destroyTime);
    }
  
    private void Update() 
    {
       transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);
       transform.Rotate(Vector3.forward * 10 * Time.deltaTime);
   }
}
