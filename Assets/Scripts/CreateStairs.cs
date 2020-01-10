using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStairs : MonoBehaviour
{
    public List<int> everyfloor = new List<int>();
    public List<int> lastfloor = new List<int>();
    public int howManyFloor;
    public float ActualTime;
    public bool first = true;

    public GameObject stairs;
    void Update()
    {
        if(ActualTime < 0 && first)
        {
            first = false;
            howManyFloor = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateTerrain>().NbRoom;

            everyfloor = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateTerrain>().floor;

            for (int i = 0; i < 4 ; i++)
            {
                lastfloor.Add(everyfloor[howManyFloor*4 - 4 + i]);
            }

            Instantiate(stairs, new Vector3( Random.Range(lastfloor[0] + 0.5f, lastfloor[1] - 0.5f), Random.Range(lastfloor[2] + 0.5f, lastfloor[3] - 0.5f), 0), transform.rotation);

        }

        else
        {
            ActualTime -= Time.deltaTime;
        }
    }
}
