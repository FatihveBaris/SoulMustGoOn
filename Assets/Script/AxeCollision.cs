using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AxeCollision : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            coll.GetComponent<EnemyStats>().TakeDamage(10);
            Destroy(gameObject);
        }else if(coll.gameObject.CompareTag("Player")){}
        

    }
    
}
