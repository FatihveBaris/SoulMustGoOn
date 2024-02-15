using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
            anim.SetBool("skeletonDie",true);

        }
    }

    

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            coll.gameObject.GetComponent<Player>().TakeDamagePlayer(currentDamage);
            Debug.Log(coll.gameObject.GetComponent<Player>().playerHp);
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {

            timer += Time.deltaTime;
            
            if (timer >= 1)
            {
                coll.gameObject.GetComponent<Player>().TakeDamagePlayer(currentDamage);
                Debug.Log(coll.gameObject.GetComponent<Player>().playerHp);
                timer = 0f; // Zamanlayýcýyý sýfýrla
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
