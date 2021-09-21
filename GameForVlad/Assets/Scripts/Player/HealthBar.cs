using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform _heartsPosition;
    [SerializeField] private HeartContainer _heartContainer;
      private List< HeartContainer> _heartContainers = new List<HeartContainer>();
    [SerializeField]private Player _player;

    public void CreateContainers() 
    {
        for (int i = 0; i < _player.MaxHealth; i++)
        {
          HeartContainer _heart =  Instantiate(_heartContainer, transform.position, Quaternion.identity);
          _heart.transform.SetParent(_heartsPosition, false);
          _heartContainers.Add(_heart);
        }
    }
    public void ChangeContainers()
    {
       _heartContainers[_player.Health - 1].TakeDamage();
    }
}
