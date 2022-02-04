using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    [SerializeField]
    private int rows = 3;
    [SerializeField]
    private int cols = 3;
    [SerializeField]
    private float tileSize = 2;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void GenerateGrid()
    {
        GameObject refTile = (GameObject)Instantiate(Resources.Load("greenTilePrefab"));
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(refTile, transform);
                float posX = col * tileSize;
                float posY = row * -tileSize;
                tile.transform.position = new Vector2(posX, posY);

            }
        }
        Destroy(refTile);

        float gridW = cols * tileSize;
        float gridH = cols * tileSize;
        transform.position = new Vector2(gridW/2+ tileSize/2, gridH / 2 );
    }
}
