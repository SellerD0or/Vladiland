using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
 [SerializeField] private float _speed =5f;
 [SerializeField] private Rigidbody2D _rigidbody2d;
 [SerializeField] private float _jumpForce = 8f;
[SerializeField] private PowerfulBow _bow;
private bool _isTurned;
[SerializeField] private Transform _jumpPosition;
[SerializeField] private LayerMask _layerMask;
[SerializeField] private float _range = 0.5f; 
[SerializeField] private  Animator _animator;
[SerializeField] private Transform _weaponPosition;
 private Vector3 _playerSize;
[SerializeField] private Inventory _inventory;
[SerializeField] private int _health = 10;
private int _maxHealth;
[SerializeField] private HealthBar _healthBar;
public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public int Health { get => _health; set => _health = value; }
    public float ExtraFireRate { get => _extraFireRate; set => _extraFireRate = value; }

    private bool _canGetDamage;
[SerializeField] private List<Artefacts> _artefacts;
private List<Artefacts> _currentArtefacts = new List<Artefacts>();
[SerializeField] private bool[] _HaveItem;
private int _orderOfItem;
private float _extraSpeed =1;
private int _extraHealth = 1;
private float _extraDamage = 1;
private float _extraFireRate = 1;
[SerializeField] private UnityEvent OnSave;
[SerializeField] private string[] _names;
private bool _isFallen;

    private void Awake() 
    {
       
    
     _playerSize = transform.localScale;
     
}
private void Start() 
{
     _orderOfItem = PlayerPrefs.GetInt("OrderOfItem");
      if(PlayerPrefs.HasKey("Speed"))
      {
     _extraSpeed = PlayerPrefs.GetFloat("Speed");
      }
    _extraHealth = PlayerPrefs.GetInt("ExtraHealth");
     ExtraFireRate = PlayerPrefs.GetFloat("FireRate");
     _bow.ExtraDamage = _extraDamage = PlayerPrefs.GetFloat("Damage");
     _bow.FireRate = ExtraFireRate;
     Debug.LogError(_extraHealth);
     Health = Health + _extraHealth;
    _maxHealth = Health;
    _healthBar.CreateContainers();
     Debug.LogError(_extraSpeed);
        for (int i = 0; i < _orderOfItem; i++)
        {
            _currentArtefacts.Add(_artefacts[i]);
            _HaveItem[i] = true;
            SetName(_names[i]);
            SaveItem(i);
        }
}
public void SetName(string _savedName)
{

} //_nameOfItem = _savedName;
public void SaveInformation(float _information)
{
    //_information = PlayerPrefs.GetFloat(_nameOfItem);
}
 private void Update() {
     _isFallen = Input.GetKey(KeyCode.S);
     float movement = Input.GetAxis("Horizontal");
     _rigidbody2d.velocity = new Vector2(movement * _speed * _extraSpeed, _rigidbody2d.velocity.y);
    bool _isOnGround =Physics2D.OverlapCircle(_jumpPosition.position,_range, _layerMask);
     
     if (Input.GetKeyDown(KeyCode.Space) && _isOnGround)
     {
         Jump();
     }
     bool _isIdle= movement ==0;
     _animator.SetBool("_IsRun", _isIdle);
     if(!_isIdle)
     {
         Debug.Log(movement);
     _isTurned = movement > 0;
     Turn();
     }

 }
 public void ChangeFireRate() => PlayerPrefs.SetFloat("FireRate", ExtraFireRate = 5f);
 public void ChangeDamage() => PlayerPrefs.SetFloat("Damage", _extraDamage =1.5f);
  public void ChangeSpeed(int _id) => PlayerPrefs.SetFloat("Speed", _extraSpeed = 1.25f);
  
  public void ChangeHealth(int _id) => PlayerPrefs.SetFloat("ExtraHealth", _extraHealth = 1);
 public void SaveItem(int _id) => PlayerPrefs.GetInt("OrderOfItem", _id);
 
 private void Turn()
 {
    TurnTransform(transform, _playerSize);
    TurnTransform(_bow.transform, _bow.Size);
 }
 private void TurnTransform( Transform _transform, Vector3 _size)
 {
     
     float _rotation = _isTurned ? -_size.x : _size.x;
      _transform.localScale = new Vector3(_rotation, _transform.localScale.y, _transform.localScale.z);
 }
 private void Jump()
 {
     _rigidbody2d.velocity = Vector2.up * _jumpForce * _extraSpeed;
 }
 public void TakeDamage(int _damage)
 {
     _healthBar.ChangeContainers();
     Health -= _damage;
     if (Health <= 0)
     {
         
         Destroy(gameObject);
         SceneManager.LoadScene(0);
     }

 }
 private void OnTriggerEnter2D(Collider2D other) {
     if ((other.TryGetComponent<IEnemy>(out IEnemy _enemy) || other.TryGetComponent<ITrap>(out ITrap _trap)) && !_canGetDamage)
     {
         TakeDamage(1);
         StartCoroutine(Cooldown());
     }
    
 }
 private void OnTriggerStay2D(Collider2D other) {
      if (other.TryGetComponent<Railroad>(out Railroad _railroad) && _isFallen)
     {
         _railroad.Platform.rotationalOffset = 180;
     }
 }
 private void OnTriggerExit2D(Collider2D other) {
 if (other.TryGetComponent<Railroad>(out Railroad _railroad))
     {
         _railroad.Platform.rotationalOffset = 0;
     }
 }
 private IEnumerator Cooldown()
 {
     _canGetDamage = true;
     yield return new WaitForSeconds(1);
     _canGetDamage = false;
 }
}
