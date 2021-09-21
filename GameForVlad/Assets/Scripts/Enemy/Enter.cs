using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
 [SerializeField] private Vector2 _vector;

    public Vector2 Vector { get => _vector; set => _vector = value; }
    public Transform AppearPosition { get => _appearPosition; set => _appearPosition = value; }

    [SerializeField] private Transform _appearPosition;
}
