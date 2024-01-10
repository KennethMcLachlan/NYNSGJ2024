using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public PlayerMovement player;
    private Transform _target;
    [SerializeField] private float _speed = 3f;

    //Projectile Spawn Points
    [SerializeField] private GameObject _spawnUP;
    [SerializeField] private GameObject _spawnLEFT;
    [SerializeField] private GameObject _spawnRIGHT;

    //Projectiles to Instantiate
    [SerializeField] private GameObject _projectileUP;
    [SerializeField] private GameObject _projectileLEFT;
    [SerializeField] private GameObject _projectileRIGHT;

    //Enemy Movement
    [Range(0, 1)] private int _movement;

    private bool _enemyIsAlive = true;
    private bool _playerInProximity;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        if (player == null)
        {
            Debug.Log("Player is NULL");
        }

        _target = player.transform;
        _movement = 0;

        StartCoroutine(ProjectileRoutine());
    }
    void Update()
    {
        CalculateMovement();
    }

    IEnumerator ProjectileRoutine()
    {
        while (_enemyIsAlive == true)
        {
            yield return new WaitForSeconds(3f);
            Instantiate(_projectileUP, _spawnUP.transform.position, Quaternion.identity);
            Instantiate(_projectileLEFT, _spawnLEFT.transform.position, Quaternion.identity);
            Instantiate(_projectileRIGHT, _spawnRIGHT.transform.position, Quaternion.identity);
        }
    }

    private void CalculateMovement()
    {
        if (transform.position.x <= -15f)
        {
            _movement = 1;
            
        }

        if (transform.position.x >= 15)
        {
            _movement = 0;
        }

        switch (_movement)
        {
            case 0:
                MoveLeft();
                break;

            case 1:
                MoveRight();
                break;

            case 2:
                FollowPlayer();
                break;

            default:
                break;
        }
    }

    private void MoveLeft()
    {
        transform.Translate(Vector3.left * _speed * Time.deltaTime);
        
    }

    private void MoveRight()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    private void FollowPlayer()
    {
        if (gameObject != null && player != null)
        {
            Vector3 temp = transform.position;
            temp.y = 1;
            transform.position = temp;

            Vector3 displacement = _target.position - transform.position;
            displacement = displacement.normalized;

            if (Vector2.Distance (_target.position, transform.position) > 1f)
            {
                transform.position += (displacement * _speed * Time.deltaTime);
            }
        }
    }

    public void PlayerInProximity()
    {
        _playerInProximity = true;
        _speed += 1f;
        _movement = 2;
        Debug.Log("Player In Proximity");
    }

    public void PlayerOutOfProximity()
    {
        _playerInProximity = false;
        _speed -= 1f;
        _movement = Random.Range(0, 1);
        Debug.Log("Player Left Proximity");
    }
    
}
