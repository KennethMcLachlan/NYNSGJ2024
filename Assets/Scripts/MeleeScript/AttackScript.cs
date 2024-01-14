using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField]
    private int attackSwing = 1;
    private Rigidbody2D _rigid;
    private PlayerAnimation _playerAnim;

    public PlayerMovement player;

    private bool canHit;

    private void OnEnable()
    {
        canHit = true;
    }


    void OnTriggerEnter(Collider other)
    {
        
        
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("The enemy has been hit!");
        }
    }

    // Update is called once per frame
    void Update()
    {
      

        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))  // 0 is for left mouse button
        {
            Attack();
        }
    }

    private void Attack()
    {
        _playerAnim.Attack();
    }

    public class PlayerAnimation : MonoBehaviour
    {
        private Animator _anim;

        void Start()
        {
            _anim = GetComponentInChildren<Animator>();
        }

        public void Move(float move)
        {
            _anim.SetFloat("Move", Mathf.Abs(move));
        }

        public void Jumping(bool isJumping)
        {
            _anim.SetBool("Jumping", isJumping);
        }

        public void Attack()
        {
            _anim.SetTrigger("Attack");
        }
    }
}
