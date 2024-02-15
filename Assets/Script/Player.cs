using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float level;
    [SerializeField] private float playerHp;
    [SerializeField] private float playerArmor;
    [SerializeField] private float playerSpeed;
    private Vector2 moveDir;
    private Transform playerTransform;
    [SerializeField] private Rigidbody2D playerRb;
    

    [SerializeField] private float playerSwordDmg;
    [SerializeField] private float playerSwordAS; //�al��ma prensibi saniyede ka� kez sald�raca��n� g�steriyor
    [SerializeField] private float playerSwordDist;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();

        playerSwordAS = 60 / (playerSwordAS * 60);

        FunctionRepeat("PlayerSwordAttack",playerSwordAS);
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

    private void PlayerSwordAttack()
    {
        

        Vector2 direction = (transform.localScale.x > 0) ? -transform.right : transform.right;

        //YUKARIDAK� DIRECTIONA G�RE BURADA AN�MASYONU GER�EKLE�T�REB�L�RS�N
        //YUKARIDAK� DIRECTIONA G�RE BURADA AN�MASYONU GER�EKLE�T�REB�L�RS�N
        //YUKARIDAK� DIRECTIONA G�RE BURADA AN�MASYONU GER�EKLE�T�REB�L�RS�N
        //YUKARIDAK� DIRECTIONA G�RE BURADA AN�MASYONU GER�EKLE�T�REB�L�RS�N
        //YUKARIDAK� DIRECTIONA G�RE BURADA AN�MASYONU GER�EKLE�T�REB�L�RS�N

        Debug.DrawRay(transform.position + new Vector3(0f,1), direction * playerSwordDist, Color.red);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position+new Vector3(0f, 1), direction, playerSwordDist);

        

        foreach (RaycastHit2D hit in hits)
        {   
            
            Debug.Log(hit.collider);
            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {

                
                Debug.Log("d��mana vurdum");
            }
        }

    }

    private void FunctionRepeat(string functionName)
    {
        
        InvokeRepeating(functionName, 0, 0);
    }
    private void FunctionRepeat(string functionName,float repeatRate)
    {

        InvokeRepeating(functionName, 0, repeatRate);
    }
}