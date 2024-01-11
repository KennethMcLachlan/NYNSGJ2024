using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemyBehavior : MonoBehaviour
{
    public PlayerHealth player;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpHeight = 3f;

    private Rigidbody _rigidbody;

    private bool _enemyIsAlive = true;
    private bool _isJumping;
    private bool _moveLeft;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerHealth>();
        if (player != null)
        {
            Debug.Log("Player is NULL");
        }

        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _isJumping = true;
        }

        CalculateMovement();
    }

    private void FixedUpdate()
    {

        StartCoroutine(JumpRoutine());

    }

    private void CalculateMovement()
    {
        if (_moveLeft == true)
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * _speed * Time.deltaTime);

        }
    }
    public void MoveLeft()
    {
        _moveLeft = true;

    }

    public void MoveRight()
    {
        _moveLeft = false;
    }
    IEnumerator JumpRoutine()
    {
        while (_enemyIsAlive == true)
        {
            yield return new WaitForSeconds(6f);
            EnemyJump();


        }
    }

    private void EnemyJump()
    {
        if (_isJumping == true)
        {
            _rigidbody.AddForce(new Vector3(0, _jumpHeight), ForceMode.Impulse);
            _isJumping = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (player != null)
            {
                player.Damage();
                Destroy(gameObject);
            }
        }
    }


}
