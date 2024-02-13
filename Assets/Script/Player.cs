using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerHp;
    [SerializeField] private float playerArmor;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerAttack;
    [SerializeField] private Rigidbody2D playerRb;
    private Vector2 moveDir;

    private void FixedUpdate()
    {
        InputManagement();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        playerRb.velocity = new Vector2(moveDir.x * playerSpeed, moveDir.y * playerSpeed);
    }

    private void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

    }
}