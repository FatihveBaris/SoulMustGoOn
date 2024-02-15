using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScripttableObjects/Enemy")]
public class EnemyScriptableObjects : ScriptableObject
{
    //Düsmanlar icin temel statlar
    [SerializeField] float moveSpeed;
    public float moveSpeed { get => moveSpeed; private set => moveSpeed = value;}
    [SerializeField] float maxHealth;
    public float maxHealth { get => maxHealth; private set => maxHealth= value;}

    [SerializeField] float damage;
    public float damage { get => damage; private set => damage = value;}
}
