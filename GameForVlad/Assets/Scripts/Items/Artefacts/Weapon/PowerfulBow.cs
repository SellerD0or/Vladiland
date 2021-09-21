using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerfulBow : Item
{
     public float Damage { get => _damage; set => _damage = value; }
    public float FireRate { get => _fireRate; set => _fireRate = value; }
   public float WaitTime { get => _waitTime; set => _waitTime = value; }
    [SerializeField] private float _waitTime;
    [SerializeField] private float _damage;
     private float _fireRate = 1f;
    [SerializeField] private Arrow _arrow;
    [SerializeField] private Transform _arrowPoint;
      public bool CanAttack{get;set;}
    public override Vector3 Size { get => _size; set => value = _size; }
    private Vector3 _size;
    public  bool IsFlip {get;set;}
    public float ExtraDamage { get => _extraDamage; set => _extraDamage = value; }

    private Vector3 _pos;
    private float _extraDamage = 1f;
    private void Start() {
        transform.localScale = new Vector3(transform.localScale.y, transform.localScale.y, transform.localScale.z);
        _size =transform.localScale;
    }

    private void Update() {
      //transform.position = _pos;
      Vector3 _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position ;
      transform.eulerAngles = new Vector3(0, 0,Mathf.Rad2Deg  *  Mathf.Atan2(_mousePosition.y, _mousePosition.x));
      if(!CanAttack && Input.GetMouseButton(0))
     {
         Attack();
         CanAttack = true;
         StartCoroutine(CoolDown());
     }

     }
     public void Attack()
    {
       Arrow arrow = Instantiate(_arrow, _arrowPoint.position, transform.rotation);
       arrow.Damage =Damage + ExtraDamage;
    }

 

    public IEnumerator CoolDown()
    {
        
        yield return new WaitForSeconds(WaitTime - FireRate);
        CanAttack = false;
    }
}
