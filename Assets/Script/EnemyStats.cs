using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sr;
    // Current Stats
    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;
    public float giveExpRate;
    public bool isKilled = false;
    private float timer;
    public LayerMask targetLayer;
    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = enemyData.MaxHealth;
        currentDamage = enemyData.Damage;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if(currentHealth <= 0)
        {
            anim.SetBool("Die",true);

        }
    }

    

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && coll.gameObject.name == "PlayableChracter")
        {
            coll.gameObject.GetComponent<Player>().TakeDamagePlayer(currentDamage);
            Debug.Log(coll.gameObject.GetComponent<Player>().playerHp);
        }
        else if (coll.gameObject.CompareTag("Player") && coll.gameObject.name == "Ghost")
        {

            coll.gameObject.GetComponent<GhostMovemment>().TakeDamage(currentDamage);
            Debug.Log(coll.gameObject.GetComponent<GhostMovemment>().ghostHp);
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && coll.gameObject.name == "PlayableChracter")
        {

            timer += Time.deltaTime;
            
            if (timer >= 1)
            {
                coll.gameObject.GetComponent<Player>().TakeDamagePlayer(currentDamage);
                Debug.Log(coll.gameObject.GetComponent<Player>().playerHp);
                timer = 0f; // Zamanlay�c�y� s�f�rla
            }
            else if (coll.gameObject.CompareTag("Player") && coll.gameObject.name == "Ghost")
            {

                coll.gameObject.GetComponent<GhostMovemment>().TakeDamage(currentDamage);
                Debug.Log(coll.gameObject.GetComponent<GhostMovemment>().ghostHp);
            }
        }

    }


    public void Kill()
    {
        isKilled = true;
        Destroy(gameObject); 
    }

    public void Update()
    {
        if (sr.enabled == false)
        {
            Kill();
        }
    }
}
