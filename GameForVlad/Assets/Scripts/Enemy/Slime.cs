using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy, IEnemy
{
      [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Artefacts _artefact;
    [SerializeField] private EnemyHealthBar _healthBar;
    private float _maxHealth;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _health;
   public float Speed {get => _speed;set => value = _speed;}
    public int Damage {get => _damage;set => value = _damage;}
   public float Health {get => _health;set => value = _health;}
   public  Player Character{get;set;}
   public Vector2 StartPosition{get;set;}
    public bool IsCoolDown{get;set;}
    public bool IsTurned { get ; set ; }
    public Vector2 Size { get; set ; }
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public Artefacts Artefact { get => _artefact; set => _artefact = value; }

    private  float _rotation;
    [SerializeField] private Rigidbody2D _rigidBody;

    private void Start() 
   {
       _particle.Pause();
       MaxHealth = Health;
       Size =transform.localScale;
       StartPosition= transform.position;
       Character = FindObjectOfType<Player>();
       Damage = 1;
       
   }

   
   private void Update() 
   {
    
          Move();
       IsTurned = transform.position.x < Character.transform.position.x;
         _rotation = IsTurned ? -2 : 2;
         Debug.LogError(_rotation);
      transform.localScale = new Vector3(_rotation, transform.localScale.y, transform.localScale.z);
      if(Vector3.Distance(transform.position, Character.transform.position) < 5 && !IsCoolDown)
      {

          Attack();
          StartCoroutine(CoolDown());
      }
   }
   public IEnumerator CoolDown()
   {
       IsCoolDown =true;
       yield return new WaitForSeconds(4);
       IsCoolDown = false;
   }
  public void Move()
  {
      transform.position = Vector3.MoveTowards(transform.position, new Vector3(Character.transform.position.x, transform.position.y, transform.position.z) , Speed * Time.deltaTime);
      
  }
  public  void Attack()
   {
       _rigidBody.velocity = Vector2.up * 10;
       _rigidBody.velocity -= new Vector2(_rotation * 7, 0);
   }
  public void Dead()
   {
       Instantiate(_artefact, transform.position, Quaternion.identity);
       Destroy(gameObject);
   }
   public void TakeDamage(float _damage)
   {
       _particle.Play();
       _health -= _damage;
       _healthBar.ChangeHealthBar(this);
       if (_health <= 0)
       {
           Dead();
       }
   }

}
