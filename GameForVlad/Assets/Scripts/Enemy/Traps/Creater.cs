using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creater : MonoBehaviour
{
    [SerializeField] private List<Transform> _summonPositions;
    [SerializeField] private GameObject _platform;
    [SerializeField] private float _waitTime =0.5f;
    private void Start() {
        StartCoroutine(Create());
    } 
    private IEnumerator Create()
    {
        int _random = Random.Range(0, _summonPositions.Count);
        yield return new WaitForSeconds(_waitTime);
        Instantiate(_platform, _summonPositions[_random].position, Quaternion.identity);
        StartCoroutine(Create());
    }
}
