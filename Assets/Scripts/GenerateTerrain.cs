using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateTerrain : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile[] tile;

    public GameObject spawn;
    public GameObject reference;

    public int RoomMin = 8;
    public int RoomMax = 12;
    private int widthMax = 12;
    private int heightMax = 12;
    private int wallRange;
    private bool RoomIsCreatable = true;

    private int width;
    private int height;
    public int NbRoom;

    public int xoffset;
    public int yoffset;

    public int getXMin;
    public int getXMax;
    public int getYMin;
    public int getYMax;

    private int rand;

    private bool first = true;

    public List<int> floor = new List<int>();

    void Start()
    {
        NbRoom = Random.Range(RoomMin, RoomMax);
        
        wallRange = GetComponent<GenerateWall>().range;

        for (int room = 0; room < NbRoom; room++)
        {
            if (first)
            {

                width = 6;
                height = 6;
            }
            else
            {

                width = Random.Range(6, widthMax);
                height = Random.Range(6, heightMax);
            }

            xoffset = Random.Range(-wallRange +5, wallRange - widthMax -5);
            yoffset = Random.Range(-wallRange + 5, wallRange - heightMax - 5);



            for (int i = 0; i < room; i++) //make room not superposable
            {
                getXMin = floor[0 + i*4];
                getXMax = floor[1 + i*4];
                getYMin = floor[2 + i*4];
                getYMax = floor[3 + i*4];

                if((xoffset > getXMin - 1 && xoffset < getXMax + 1) || (xoffset + width > getXMin - 1 && xoffset + width < getXMax + 1) ||(xoffset + width/2 > getXMin - 1 && xoffset + width/2 < getXMax + 1))
                {
                    if ((yoffset > getYMin - 1 && yoffset < getYMax + 1) || (yoffset + height > getYMin - 1 && yoffset + height < getYMax + 1) || (yoffset + height / 2 > getYMin - 1 && yoffset + height / 2 < getYMax + 1))
                    {
                        RoomIsCreatable = false;
                    }
                }
                

            }
            if (RoomIsCreatable)
            {
                Debug.Log("New Floor has been created");

                Instantiate(reference, new Vector3(Random.Range(xoffset + 1.5f, xoffset + width - 1.5f) , Random.Range(yoffset + 1.5f, yoffset + height - 1.5f) , 0), Quaternion.identity);

                floor.Add(xoffset);
                floor.Add(width + xoffset);

                floor.Add(yoffset);
                floor.Add(height + yoffset);



                for (int y = 0; y < height; y++)
                {
                    Vector3Int currentCell = tilemap.WorldToCell(transform.position);
                    currentCell.x += 5;
                    currentCell.y += 5;
                    for (int x = 0; x < width; x++)
                    {
                        currentCell.x = x + xoffset;
                        currentCell.y = y + yoffset;
                        rand = Random.Range(0, tile.Length);
                        tilemap.SetTile(currentCell, tile[rand]);
                    }
                }
            }
            else
            {
                room -= 1;
                RoomIsCreatable = true;
            }
            
            if (first)
            {
                first = false;
                Instantiate(spawn, new Vector3(xoffset + 1, yoffset + 1, 0), Quaternion.identity);
                GameObject.FindGameObjectWithTag("Player").transform.position = GameObject.FindGameObjectWithTag("Respawn").transform.position;
            }
            
        }  //create  a room
        Debug.Log(floor);
    }
}
