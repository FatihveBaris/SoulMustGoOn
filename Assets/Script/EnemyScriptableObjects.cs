using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScripttableObjects/Enemy")]
public class EnemyScriptableObjects : ScriptableObject
{
    //Düsmanlar icin temel statlar
    [SerializeField] float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value;}
    [SerializeField] float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth= value;}

    [SerializeField] float damage;
    public float Damage { get => damage; private set => damage = value;}
}
