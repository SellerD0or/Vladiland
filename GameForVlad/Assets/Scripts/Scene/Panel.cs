using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
  [SerializeField] private GameObject _panel;

    public GameObject EndPanel { get => _panel; set => _panel = value; }
}
