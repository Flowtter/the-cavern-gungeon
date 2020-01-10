using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneratePath : MonoBehaviour
{
    public int path;
    public int pathMin;
    public int pathMax;

    public Tilemap tilemap;
    public Tilemap tilefloor;
    public Tile[] wall;

    public float InitTime;

    public GameObject[] rooms;

    public int i = 0;
    
    public float ActualTime;
    public float ActualTime2;
    [HideInInspector]

    void Start()
    {
        ActualTime = 0.5f;
        ActualTime2 = InitTime;
    }
    void Update()
    {
        if (ActualTime <= 0)
        {

            rooms = GameObject.FindGameObjectsWithTag("Room");

            if(ActualTime2 <= 0)
            {
                if(i < rooms.Length)
                {

                    ActualTime2 = 0.1f;
                    rooms[i].GetComponent<LocalPath>().yourTurn = true;
                    rooms[i].GetComponent<LocalPath>().nbPath = Random.Range(pathMin, pathMax+1);
                    i += 1;
                }
            }


            



        }
        else if (ActualTime > 0)
        {
            ActualTime -= Time.deltaTime;
        }
        if(ActualTime <0 && ActualTime2 > 0)
        {
            ActualTime2 -= Time.deltaTime;
        }
    }
}
