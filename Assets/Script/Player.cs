using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerHp;
    [SerializeField] private float playerArmor;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float playerAttack;
    [SerializeField] private float playerAttackSpeed; //çalýþma prensibi saniyede kaç kez saldýracaðýný gösteriyor
    [SerializeField] private Rigidbody2D playerRb;
    private Transform playerTransform;
    private Vector2 moveDir;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();

        FunctionRepeat();
    }

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

        if (moveDir.x < 0)
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        else
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);

    }

    private void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

    }

    private void PlayerAttack()
    {
        Debug.Log("saldýrýyorum");
    }

    private void FunctionRepeat()
    {
        playerAttackSpeed = 60 / (playerAttackSpeed * 60);

        InvokeRepeating("PlayerAttack", 0, playerAttackSpeed);
    }
}