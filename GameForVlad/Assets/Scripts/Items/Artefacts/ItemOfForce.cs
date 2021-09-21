using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOfForce : Artefacts, IArtefact
{
       [SerializeField] private int _id;
    public Player Character {get;set;}
        public int ID { get => _id; set => _id = value; }

    private void Awake() {
        Character =  FindObjectOfType<Player>();
        Character.SaveItem(_id);
        Character.ChangeDamage();
        Destroy(gameObject, 5f);
    }
    private void Update() {
           transform.Translate(Vector3.up * 4 * Time.deltaTime);
    }
}
