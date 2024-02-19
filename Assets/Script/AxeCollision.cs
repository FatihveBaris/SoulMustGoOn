using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AxeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;

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
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(player.GetComponent<GhostMovemment>() != null && player.GetComponent<GhostMovemment>().enabled)
        {
            
            DestroyAllAxes();
        }
        else if (coll.gameObject.CompareTag("Enemy"))
        {
            coll.GetComponent<EnemyStats>().TakeDamage(10);
            float GiveExpRate = coll.GetComponent<EnemyStats>().giveExpRate;
            player.GetComponent<Player>().CurrentExp += GiveExpRate;
            Destroy(gameObject);

        }else if(coll.gameObject.CompareTag("Player")){}


    }

    void DestroyAllAxes()
{
    GameObject[] axes = GameObject.FindGameObjectsWithTag("Axe");
    foreach(GameObject axe in axes)
    {
        Destroy(axe);
    }
}
}
