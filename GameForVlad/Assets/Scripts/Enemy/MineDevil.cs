using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDevil :Enemy, IEnemy
{
    private bool _canMove;
    [SerializeField] private Color _color;
    [SerializeField] private Enter[] _enters;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Artefacts _artefact;
    [SerializeField] private EnemyHealthBar _healthBar;
    private float _maxHealth;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage = 1;
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
    [SerializeField]private int _randomEnter;
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private Enter _currentEnter;
    [SerializeField]private Sprite[] _spritesOfMouth;
    [SerializeField] private SpriteRenderer _mouth;
    [SerializeField] private BulletEnemy _bulletEnemy;
    [SerializeField] private Transform _eatenPosition;
    
    private bool _isCreated = false;
    [SerializeField] private DevilArm _arm;
    [SerializeField] private List<GameObject> _items;
    [SerializeField] private BulletEnemy _bullet;
    [SerializeField] private List<GameObject> _disactiveObjects;
    private void Start() 
   {
       _particle.Pause();
       MaxHealth = Health;
       Size =transform.localScale;
       StartPosition= transform.position;
       Character = FindObjectOfType<Player>();
       _bullet  = Instantiate(_bulletEnemy, transform.position, Quaternion.identity);
      _bullet.Character = Character;
   }

   
   private void Update() 
   {
    if(!_canMove)
    {
    if (!IsCoolDown)
    {
        StartCoroutine(ChangeMouth());
    }
          Move();
       IsTurned = transform.position.x < Character.transform.position.x;
         _rotation = IsTurned ? -Size.x : Size.x;
         Debug.LogError(_rotation);
      transform.localScale = new Vector3(_rotation, transform.localScale.y, transform.localScale.z);
   }
   }
   private IEnumerator ChangeMouth()
   {
       IsCoolDown = true;
       int _randomMouth = Random.Range(0, _spritesOfMouth.Length);
       _mouth.sprite = _spritesOfMouth[_randomMouth];
       yield return new WaitForSeconds(5);
        Attack();
       IsCoolDown = false;
   }
   public IEnumerator CoolDown()
   {
       IsCoolDown =true;
       yield return new WaitForSeconds(4);
       IsCoolDown = false;
   }
  public void Move()
  {
      transform.Translate( _currentEnter.Vector * _speed* Time.deltaTime);
  }
  public  void Attack()
   {
       
   }
  public void Dead()
   {
       Instantiate(_artefact, transform.position, Quaternion.identity);
       Destroy(gameObject);
   }
   public void TakeDamage(float _damage)
   {
       if(!_canMove)
       {
       _particle.Play();
       _health -= _damage;
       _healthBar.ChangeHealthBar(this);
          if (_maxHealth / 2 >= _health && !_isCreated)
       {
         SummonDevil();
         _isCreated  =true;
       }
       if (_health <= 0)
       {
           Dead();
       }
       }
   }
   private void OnTriggerEnter2D(Collider2D other) {
       if (other.TryGetComponent<Enter>(out Enter _enter))
       {
           _currentEnter = _enter;
           Teleport();
          transform.position = _enters[_randomEnter].AppearPosition.position;
          
       }
   }
   private void Teleport()
   {
     _randomEnter =  Random.Range(0, _enters.Length);
   }
   private void SummonDevil()
   {
      DevilArm _devilArm = Instantiate(_arm,_eatenPosition.position, Quaternion.identity);
      _devilArm.Enemy = this;
      _canMove = true;
      Destroy(_bullet.gameObject);
      StartCoroutine(Create());
      
   }
   private IEnumerator Create()
   {
       yield return new WaitForSeconds(0.5f);
       Camera.main.backgroundColor = _color;
       foreach (var item in _items)
       {
           item.SetActive(true);
       }
       foreach (var item in _disactiveObjects)
       {
           item.SetActive(false);
       }
   }


}
