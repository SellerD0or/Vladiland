using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
   
    [SerializeField] private Rigidbody2D _rigidbody2d;
    [SerializeField] private float _speed = 5;
    private float _damage = 1f;
    private Player _player;

    public float Damage { get => _damage; set => _damage = value; }

    private void Start() 
    {
        
        _player = FindObjectOfType<Player>();
        _rigidbody2d.AddForce(transform.right * _speed, ForceMode2D.Impulse);
        Destroy(gameObject, 4f);
  
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<IEnemy>(out IEnemy _enemy))
        {
           
            _enemy.TakeDamage(Damage);
            Destroy(gameObject);
        }
        if (other.GetComponent<Wall>())
        {
            Destroy(gameObject);
        }
    }
}
