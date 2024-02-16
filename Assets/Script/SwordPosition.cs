using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPosition : MonoBehaviour
{
    GameObject player;
    public ParticleSystem slashEffect;
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
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
    }
}
