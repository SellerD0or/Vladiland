using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
   [SerializeField] private Image _icon;

    public Image Icon { get => _icon; set => _icon = value; }
}
