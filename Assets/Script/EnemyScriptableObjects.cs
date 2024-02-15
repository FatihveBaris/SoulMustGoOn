using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScripttableObjects/Enemy")]
public class EnemyScriptableObjects : ScriptableObject
{
    //Düsmanlar icin temel statlar
    public float moveSpeed;
    public float MaxHealth;
    public float damage;
}
