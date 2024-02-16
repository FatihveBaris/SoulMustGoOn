using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GhostMovemment : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Vector2 moveDir;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator anim;
    [SerializeField] public float ghostHp;

    // Update is called once per frame
    void FixedUpdate()
    {
        InputManagement();  
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        //AnimationUpdate();

        playerRb.velocity = new Vector2(moveDir.x * playerSpeed, moveDir.y * playerSpeed);

        if (moveDir.x < 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else if (moveDir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        }
    }


    private void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;


    }

    public void TakeDamage(float dmg)
    {
        ghostHp -= dmg;
    }
    
    void AnimationUpdate()
    {
        
    }
}
