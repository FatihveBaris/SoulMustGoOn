using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AxeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            coll.GetComponent<EnemyStats>().TakeDamage(10);
            float GiveExpRate = coll.GetComponent<EnemyStats>().giveExpRate;
            player.GetComponent<Player>().CurrentExp += GiveExpRate;
            Destroy(gameObject);

        }else if(coll.gameObject.CompareTag("Player")){}
        

    }
    
}
