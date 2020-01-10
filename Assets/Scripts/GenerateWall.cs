using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateWall : MonoBehaviour
{
    public int range;

    public Tilemap tilemap;
    public Tilemap tilefloor;
    public Tile[] wall;
    private int rand;

    public float InitTime;
    [HideInInspector]
    public float ActualTime;

    void Start()
    {
        ActualTime = InitTime;
    }
    void Update()
    {
        if (ActualTime <= 0)
        {
            for (int y = -range; y < range; y++)
            {
                Vector3Int currentCell = tilemap.WorldToCell(transform.position);
                for (int x = -range; x < range; x++)
                {
                    currentCell.x = x;
                    currentCell.y = y;
                    rand = Random.Range(0, wall.Length);

                    if (tilefloor.GetTile(currentCell) == null)
                    {
                        tilemap.SetTile(currentCell, wall[rand]);
                    }
                }
            }
            Destroy(this);
        }
        else if (ActualTime > 0)
        {
            ActualTime -= Time.deltaTime;
        }
    }

}
