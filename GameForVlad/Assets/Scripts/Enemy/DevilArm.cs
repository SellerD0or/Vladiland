using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilArm : MonoBehaviour
{
    private Enemy _enemy;

    public Enemy Enemy { get => _enemy; set => _enemy = value; }
    private float _speed = 8;
    [SerializeField] private Devil _devil;
    private bool _isCreated;
        private Vector3 _startPosition;
private void Start() {
  _startPosition = transform.position;
}

    private void Update() {
      transform.position = Vector3.MoveTowards(transform.position, Enemy.transform.position,_speed *Time.deltaTime);
  }
  private void OnTriggerEnter2D(Collider2D other) {
      if (other.GetComponent<MineDevil>() && !_isCreated)
      {
          _isCreated = true;
          Instantiate(_devil, _startPosition, Quaternion.identity);
          
          Destroy(other.gameObject,1f);
          Destroy(gameObject,1.5f);
      }
  }
}
