using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private float fillValue;

    public void ChangeHealthBar(IEnemy _enemy)
    {
        fillValue = (float)_enemy.Health;
        fillValue = fillValue / _enemy.MaxHealth;
        _healthBar.fillAmount = fillValue;
    }
}
