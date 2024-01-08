using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour
{
    private Slider _healthBar;

    [SerializeField] private TMP_Text _score;

    private void Start()
    {
        _score.text = "Score: ";
    }
    public void DamageHealth(int health)
    {
        _healthBar.value = health;

        if (health <= 0)
        {
            //GameOver
        }
    }

    public void RecoverHealth(int recover)
    {
        _healthBar.value = recover;
    }

    public void UpdateScore(int score)
    {
        _score.text = "Score: " + score.ToString();
    }
}
