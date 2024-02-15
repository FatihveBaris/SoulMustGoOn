using System.Collections;
using System.Collections.Generic;
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
