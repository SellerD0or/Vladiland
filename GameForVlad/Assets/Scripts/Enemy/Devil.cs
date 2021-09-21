using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Devil : Enemy, IEnemy
{
          [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Artefacts _artefact;
     private EnemyHealthBar _healthBar;
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
    [SerializeField] private Rigidbody2D _ball;
    [SerializeField] private Transform _spawnPosition;
    private Panel _panel;

    private void Start() 
   {
       _panel = FindObjectOfType<Panel>();
       _healthBar = FindObjectOfType<EnemyHealthBar>();
       _particle.Pause();
       MaxHealth = Health;
       Size =transform.localScale;
       StartPosition= transform.position;
       Character = FindObjectOfType<Player>();
       ChangeHealthBar();
       Damage = 1;
       
   }
   private void ChangeHealthBar() =>  _healthBar.ChangeHealthBar(this);

   
   private void Update() 
   {
    
          Move();
       IsTurned = transform.position.x < Character.transform.position.x;
         _rotation = IsTurned ? Size.x : -Size.x;
         Debug.LogError(_rotation);
      transform.localScale = new Vector3(_rotation, transform.localScale.y, transform.localScale.z);
      if(Vector3.Distance(transform.position, Character.transform.position) < 3 && !IsCoolDown)
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
      
   }
  public void Dead()
   {
       
       _panel.EndPanel.SetActive(true);
       Instantiate(_artefact, transform.position, Quaternion.identity);
       Destroy(gameObject);
       SceneManager.LoadScene(4);
   }
   public void TakeDamage(float _damage)
   {
       _particle.Play();
       _health -= _damage;
       ChangeHealthBar();
       if (_health <= 0)
       {
           Dead();
       }
   }
}
