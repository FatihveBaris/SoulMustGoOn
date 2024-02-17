using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GhostMovemment : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    private Vector2 moveDir;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator anim;
    [SerializeField] public float ghostHp;
    [SerializeField] private GameObject gameManager;
    private GameManager gmScript;

    // Update is called once per frame
    void Start()
    {
        gmScript = gameManager.GetComponent<GameManager>();
    }

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
        if(ghostHp <= 0)
        {
            DieGhost();
        }
    }

    public void DieGhost()
    {
        anim.SetBool("Die",true);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

    }
    
    void AnimationUpdate()
    {
        
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (Input.GetKey(KeyCode.F) && coll.CompareTag("DeadBody"))
        {
            coll.GetComponent<Player>().enabled = true;
            coll.GetComponent<Player>().PlayerReborn(gmScript.preLevel);
            coll.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            coll.tag = "Player";
            coll.name = "PlayableChracter";
            
            playerRb.velocity = new Vector2(0, 0);
            gameObject.transform.position = new Vector3(1000, 0);
            gameObject.tag = "Untagged";
            gameObject.GetComponent<GhostMovemment>().enabled = false;


        }
    }


    void GameOver()
    {
       SceneManager.LoadScene("GameOver");
    }
}
