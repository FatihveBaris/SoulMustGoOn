using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {

        if (player == null || player.tag == "Untagged")
        {
            player = GameObject.FindWithTag("Player");
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position,
            enemyData.MoveSpeed * Time.deltaTime); //Düşmanı sürekli olarak oyuncuya doğru hareket ettirir


    }
}
