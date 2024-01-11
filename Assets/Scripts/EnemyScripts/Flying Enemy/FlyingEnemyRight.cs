using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyRight : MonoBehaviour
{
    public PlayerHealth player;

    [SerializeField] private float _speed = 10;
    [SerializeField] private GameObject _bomb;
    [SerializeField] private GameObject _spawnPoint;

    private bool _isAlive = true;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        if (player == null)
        {
            Debug.Log("Player is NULL");
        }

        if (gameObject != null)
        {
            Invoke("DestroyFlyingEnemy", 10f);
        }

        _isAlive = true;

        StartCoroutine(BombDropRoutine());
    }
    private void Update()
    {
        CalculateMovement();
    }
    private void CalculateMovement()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    IEnumerator BombDropRoutine()
    {
        while (_isAlive == true)
        {
            yield return new WaitForSeconds(0.75f);
            Instantiate(_bomb, _spawnPoint.transform.position, Quaternion.identity);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PLayer")
        {
            if (player != null)
            {
                player.Damage();
                Destroy(gameObject);
            }
        }
    }

    private void DestroyFlyingEnemy()
    {
        Destroy(gameObject);
    }
}
