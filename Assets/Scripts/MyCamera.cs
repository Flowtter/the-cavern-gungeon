using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public float offset = 3f;
    [HideInInspector]
    public GameObject player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void FixedUpdate()
    {
        float Posx = (Input.mousePosition.x - 0.5f * Screen.width)/ (0.5f * Screen.width);
        float Posy = (Input.mousePosition.y - 0.5f * Screen.height)/ (0.5f * Screen.height) - offset;
        Vector3 mousePosition = new Vector3(Posx, Posy, -10);
        transform.position = player.transform.position  + mousePosition;
            
    }
}
