using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LocalPath : MonoBehaviour
{

    public List<float> lastclosest = new List<float>();
    public float thelast;
    public bool yourTurn;

    public Tilemap tilefloor;
    public Tile[] tile;

    public int nbPath;
    public bool first = true;
    public GameObject path;
    public float ActualTime;
    public GameObject[] rooms;
    public Vector3 pos;

    public float magnitude;

    public float minus;
    public Vector3 minusV;

    private int rand;
    public int saven;

    public int r = 0;

    void Start()
    {
        minus = Mathf.Infinity;
        tile = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateTerrain>().tile;
        tilefloor = GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateWall>().tilefloor;
        lastclosest.Add(-500f);
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("GameController").GetComponent<GenerateWall>().ActualTime <=0)
        {
            Destroy(gameObject);
        }

        if (ActualTime <= 0)
        {
            if (first)
            {
                //Debug.Log(nbPath);
                for (int n = 0; n < nbPath; n++)
                {
                    thelast = lastclosest[r];
                    //Debug.Log("time run, supposed to be 5*5, n = " + n);
                    //Debug.Log(thelast);
                    first = false;

                    rooms = GameObject.FindGameObjectsWithTag("Room");
                    Vector3 currentPos = transform.position;
                    

                    foreach (GameObject room in rooms)
                    {
                        pos = room.transform.position - this.transform.position;

                        magnitude = Vector3.SqrMagnitude(pos);

                        if (magnitude > 1)
                        {

                            float dist = Vector3.Distance(room.transform.position, currentPos);
                            if (dist < minus && lastclosest.Contains(minus))
                            {

                                minus = dist;
                                minusV = room.transform.position;



                            }
                        }
                    }
                    r += 1;
                    lastclosest.Add(minus);
                    if (true)
                    {

                        Vector3Int currentCell = tilefloor.WorldToCell(transform.position);
                        float distx = (minusV.x - this.transform.position.x);
                        float disty = (minusV.y - this.transform.position.y);

                        int random = Random.Range(1, 3);
                        Debug.Log(random);
                        if(random == 1)
                        {
                            if (distx > 0)
                            {
                                for (int i = 0; i < distx; i++)
                                {
                                    rand = Random.Range(0, tile.Length);
                                    currentCell.x += 1;
                                    tilefloor.SetTile(currentCell, tile[rand]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < -distx; i++)
                                {
                                    rand = Random.Range(0, tile.Length);
                                    currentCell.x -= 1;
                                    tilefloor.SetTile(currentCell, tile[rand]);
                                }
                            }
                            if (disty > 0)
                            {
                                for (int i = 0; i < disty; i++)
                                {
                                    rand = Random.Range(0, tile.Length);
                                    currentCell.y += 1;
                                    tilefloor.SetTile(currentCell, tile[rand]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < -disty; i++)
                                {
                                    rand = Random.Range(0, tile.Length);
                                    currentCell.y -= 1;
                                    tilefloor.SetTile(currentCell, tile[rand]);
                                }
                            }
                        }
                        else
                        {
  
                            if (disty > 0)
                            {
                                for (int i = 0; i < disty; i++)
                                {
                                    rand = Random.Range(0, tile.Length);
                                    currentCell.y += 1;
                                    tilefloor.SetTile(currentCell, tile[rand]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < -disty; i++)
                                {
                                    rand = Random.Range(0, tile.Length);
                                    currentCell.y -= 1;
                                    tilefloor.SetTile(currentCell, tile[rand]);
                                }
                            }
                            if (distx > 0)
                            {
                                for (int i = 0; i < distx; i++)
                                {
                                    rand = Random.Range(0, tile.Length);
                                    currentCell.x += 1;
                                    tilefloor.SetTile(currentCell, tile[rand]);
                                }
                            }
                            else
                            {
                                for (int i = 0; i < -distx; i++)
                                {
                                    rand = Random.Range(0, tile.Length);
                                    currentCell.x -= 1;
                                    tilefloor.SetTile(currentCell, tile[rand]);
                                }
                            }
                        }


                    }
                }
                
            }

        }
        else if (ActualTime > 0 && yourTurn)
        {
            ActualTime -= Time.deltaTime;
        }

    }
}
