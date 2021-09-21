using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOfFireRate : Artefacts, IArtefact
{
      [SerializeField] private int _id;
          public int ID { get => _id; set => _id = value; }
    public Player Character {get;set;}

    private void Awake() {
        Character =  FindObjectOfType<Player>();
        Character.SaveItem(_id);
        Character.ChangeFireRate();
        Destroy(gameObject, 5f);
    }
    private void Update() {
           transform.Translate(Vector3.up * 4 * Time.deltaTime);
    }
}
