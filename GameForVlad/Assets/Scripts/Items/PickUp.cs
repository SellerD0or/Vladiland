using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
   [SerializeField] private Item _currentItem;

    public Item CurrentItem { get => _currentItem; set => _currentItem = value; }
}
