using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;
    // Current Stats
    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    void Awake()
    {
        currentMoveSpeed = enemyData.moveSpeed;
        currentHealth = enemyData.maxHealth;
        currentDamage = enemyData.damage;
    }

    public void TakeDamage()
    {
        currentHealth -= dmg;
    }
}
