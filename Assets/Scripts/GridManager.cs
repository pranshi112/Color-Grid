using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject tilePrefab;
    [HideInInspector]
    public GameObject[,] spawnedTiles;
    

    private void Start()
    {
        spawnedTiles = new GameObject[3,3];
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                spawnedTiles[i,j] = (GameObject)Instantiate(tilePrefab, new Vector2((float)i +3.5f, j+3), Quaternion.identity);
                spawnedTiles[i,j].GetComponent<Tiles>().init();
            }
        }        
    }
}
