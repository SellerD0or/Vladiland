using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void Start() {
        Destroy(gameObject, 5f);
    }
   private void Update() {
       transform.Translate(Vector2.down * 3 * Time.deltaTime);
   }
}
