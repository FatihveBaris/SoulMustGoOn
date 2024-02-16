using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 moveDir;
    private Transform playerTransform;
    private bool isMoving;
    [SerializeField] private Animator anim;


    [SerializeField] private float level;
    [SerializeField] private float maxExp;
    [SerializeField] private float currentExp;

    public float CurrentExp { get => currentExp;  set => currentExp= value; }
    public float MaxExp { get => maxExp; private set => maxExp = value; }

    [SerializeField] public float playerHp;
    [SerializeField] private float playerArmor;
    [SerializeField] private float playerSpeed;
    [SerializeField] private Rigidbody2D playerRb;

    [SerializeField] private float playerSwordDmg;
    [SerializeField] private float playerSwordAS; //�al��ma prensibi saniyede ka� kez sald�raca��n� g�steriyor
    [SerializeField] private float playerSwordDist;

    [SerializeField] private GameObject throwAxePref;
    [SerializeField] private float playerTrowAxeCD;
    [SerializeField] private bool isAxeSkill;
    private bool axeLastDirection;


    private float timerSword;
    private float timerAxe;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();

        

    }

    private void FixedUpdate()
    {
        InputManagement();
    }

    private void Update()
    {
        playerSwordAS = 60 / (playerSwordAS * 60);
        playerTrowAxeCD = 60 / (playerTrowAxeCD * 60);

        LevelUp();
        Move();

        timerSword += Time.deltaTime;
        if (timerSword >= playerSwordAS)
        {
            PlayerSwordAttack();
            timerSword = 0f; // Zamanlayıcıyı sıfırla
        }

        timerAxe += Time.deltaTime;
        if (timerAxe >= playerTrowAxeCD)
        {
            if (isAxeSkill)  PlayerThrowAxe();
            timerAxe = 0f; // Zamanlayıcıyı sıfırla
        }

   
    }

    private void Move()
    {
        AnimationUpdate();

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


            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<EnemyStats>().TakeDamage(10);
                if (hit.collider.GetComponent<EnemyStats>().isKilled == true)
                {
                    currentExp += hit.collider.GetComponent<EnemyStats>().giveExpRate;
                    Debug.Log(currentExp);
                }

            }
        }
    }

    private void PlayerThrowAxe()
    {
        GameObject axeInstanceRef = Instantiate(throwAxePref, transform.position, Quaternion.identity);

        Rigidbody2D rb = axeInstanceRef.GetComponent<Rigidbody2D>();

        SpriteRenderer axeSprite = axeInstanceRef.GetComponent<SpriteRenderer>();

        
        Vector2 throwDirection = (transform.localScale.x > 0) ? -transform.right : transform.right;
        rb.velocity = throwDirection;

        if (moveDir.x < 0)
        {
            axeSprite.flipX = false;
            axeLastDirection = false;
        }
        else if (moveDir.x > 0)
        {
            axeSprite.flipX = true;
            axeLastDirection = true;
        }
        else
        {
            axeSprite.flipX = axeLastDirection;
        }
        

    }

    public void TakeDamagePlayer(float dmg)
    {
        playerHp -= dmg;
    }

    private void AnimationUpdate()
    {
        if (moveDir.x != 0)
        {
            anim.SetBool("knightWalk",true);
        }else if (moveDir.y != 0)
        {
            anim.SetBool("knightWalk", true);
        }
        else
        {
            anim.SetBool("knightWalk", false);
        }
    }

    private void LevelUp()
    {
        if (currentExp >= maxExp)
        {
            level += 1;
            maxExp += maxExp;
            currentExp = 0;
            playerHp += playerHp / (playerHp / level);
        }
    }
}