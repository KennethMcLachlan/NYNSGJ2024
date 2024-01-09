using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private UIManager _uiManager;
    private ScreenShake _screenShake;

    [SerializeField] private int _currentHealth;
    [SerializeField] private int _maxHealth = 50;

    //Temporary value for damage
    private int _damage = 5;

    //Add health when the Player picks up a healing potion
    private int _heal = 15;

    //Add score when the player defeats an enemy
    private int _score;

    void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.Log("UIManager is NULL!");
        }

        //_screenShake = GameObject.Find("2D Camera").GetComponent<ScreenShake>();
        //if (_screenShake == null)
        //{
        //    Debug.Log("ScreenShake is NULL");
        //}

        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        AddScore();
    }

    public void Damage()
    {
        // Tells the Healthbar that the player has been damaged
        //_screenShake.StartShake(); Couldn't get it to work with Cinemachine
        _currentHealth -= _damage;
        _uiManager.DamageHealth(_currentHealth);
    }

    public void Heal()
    {
        //Heals the Player when they pick up health
        _currentHealth += _heal;

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        _uiManager.RecoverHealth(_currentHealth);

    }

    public void AddScore()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _score += 100;
            _uiManager.UpdateScore(_score);

        }
    }

}
