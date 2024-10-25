using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillHealth : MonoBehaviour
{
    [SerializeField] private Image _healthCount;

    [SerializeField] private Text _countHealthText;    

    /// <summary>
    /// Отображение уровня жизни в UI
    /// </summary>
    /// <param name="health"></param>
    public void FillHealthCount(Health health) 
    {
        _healthCount.fillAmount = health.CurrentHealth / health.MaxHealth;

        _countHealthText.text = health.CurrentHealth.ToString();
    }   
}
