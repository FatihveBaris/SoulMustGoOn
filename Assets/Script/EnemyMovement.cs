using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;
    Transform player;
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

   
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.moveSpeed * Time.deltaTime);  //Düşmanı sürekli olarak oyuncuya doğru hareket ettirir
    }
}
