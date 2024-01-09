using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIManager : MonoBehaviour
{
    public BossBehavior _bossBehavior;

    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _bossHealth;

    [SerializeField] private TMP_Text _score;

    private void Start()
    {
        _bossBehavior = GameObject.Find("BossPrototype").GetComponent<BossBehavior>();
        if (_bossBehavior == null)
        {
            Debug.Log("Boss Behavior Script is NULL");
        }

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

    public void UpdateBossHealth(int bossHealth)
    {
        _bossHealth.value = bossHealth;

        if (bossHealth <= 0)
        {
            //Boss Dies
            _bossBehavior.BossHasDied();
        }
    }
}
