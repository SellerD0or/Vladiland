using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour, IEnemy
{
     [SerializeField] private ParticleSystem _particle;
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

    [SerializeField] private bool _isRightDirection = true;
   [SerializeField] private float _extraSpeed = -1;
    private  float _rotation;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private BulletEnemy _bullet;
      [SerializeField] private Artefacts _artefact;
    private bool _isCreated;
    [SerializeField] private GameObject[] _eyes;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GameObject _eye;

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
     transform.Rotate(Vector3.forward * 10 * Time.deltaTime);
          Move();
       IsTurned = transform.position.x < Character.transform.position.x;
         _rotation = IsTurned ? -Size.x : Size.x;
         Debug.LogError(_rotation);
      transform.localScale = new Vector3(_rotation, transform.localScale.y, transform.localScale.z);
      if(!IsCoolDown)
      {

          Attack();
          StartCoroutine(CoolDown());
      }
   }
   public IEnumerator CoolDown()
   {
       IsCoolDown =true;
       int _randomWaitTime = Random.Range(5,12);
       yield return new WaitForSeconds(_randomWaitTime);
       IsCoolDown = false;
   }
  public void Move()
  {
      transform.position = Vector2.MoveTowards(transform.position, Character.transform.position, _speed * Time.deltaTime);
      
  }
  public  void Attack()
   {
    BulletEnemy _bulletEnemy = Instantiate(_bullet, transform.position, Quaternion.identity);
    _bulletEnemy.Character = Character;
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
       if (_maxHealth / 2 >= _health && !_isCreated)
       {
         Create();
       }
       if (_health <= 0)
       {
           Dead();
       }
   }
   private void Create()
   {
       Instantiate(_eye, _spawnPosition.position, Quaternion.identity);
       foreach (var _bossEye in _eyes)
       {
           _bossEye.SetActive(false);
       }
       _isCreated = true;
   }

}
