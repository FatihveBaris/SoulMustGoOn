using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private Transform cameraTransform;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        cameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null || player.tag == "Untagged")
        {
            player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        }

        cameraTransform.position = player.position;
        cameraTransform.position += new Vector3(0, 0, -10);
    }
}
