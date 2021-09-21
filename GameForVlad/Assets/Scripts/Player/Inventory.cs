using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
     [SerializeField] private List< Item> _artefacts = new List<Item>();

    public List<Item> Artefacts { get => _artefacts; set => _artefacts = value; }
    private List<Slot> _slots = new List<Slot>();
    [SerializeField] private Slot _slot;
    [SerializeField] private Transform _slotPosition;
    public void AddItem(Item _item)
    {
     //  Slot slot = Instantiate(_slot, _slotPosition.position, Quaternion.identity);
//       slot.Icon.sprite = _item.Icon;
  //     slot.transform.SetParent(_slotPosition, false);
        _artefacts.Add(_item);
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _artefacts.Count > 0)
        {
            RemoveItem();
        }
    }
    private void RemoveItem()
    {
        // Item _removedItem = Artefacts.Peek();
      

    }
}
