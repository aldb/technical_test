using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBoard : MonoBehaviour
{
    [SerializeField]
    private int rows = 5;
    [SerializeField]
    private int cols = 5;
    [SerializeField]
    private float tileSize = 3;
    [SerializeField]
    private String[] pineCat = new String[3] { "pine1", "pine2", "pine3" };

    private bool[,] notfree; //matrix that indicate if for a specific coordinate the tile is empty 
    private int nbFreeSpace; // number of avaible tile to place a decoration 
    public List<Tree> trees = new List<Tree>(); // The list contaning the tree place and catégorie on the GridBoard
    private List<GameObject> treesObj= new List<GameObject>(); // Sprite/Object place on the scene

    private System.Random rand;

    void Start()
    {
        rand = new System.Random();
        notfree = new bool[rows, cols];
        nbFreeSpace = rows * cols;
        GenerateGrid();
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
                float posY = row * tileSize - 2 * tileSize;
                tile.transform.position = new Vector2(posX, posY);

            }
        }
        Destroy(refTile);
    }


    //This fonction select random starting coordinate
    //From this coordinate it parcourt the matrix until a slot is avaible
    private (int, int) SelectFreePlace()
    {
        int x = rand.Next(0, cols - 1);
        int y = rand.Next(0, rows - 1);
        bool notfound = true;

        while (notfound)
        {
            if (notfree[x, y])
            {
                if (x < cols - 1){
                    x++;
                }
                else{
                    x = 0;
                    y = (y + 1) % rows;
                }
            }
            else{
                notfound = false;
            }
        }
        return (x, y);
    }

    //This Fonction place a tree on the map 
    private void PlaceTree(int cat, int x , int y)
    {
        notfree[x, y] = true;
        nbFreeSpace--;

        GameObject pine = (GameObject)Instantiate(Resources.Load(pineCat[cat]), transform);

        float posX = x * tileSize;
        float posY = y * tileSize - 2 * tileSize;

        pine.transform.position = new Vector3(posX, posY, -1);
        trees.Add(new Tree(cat, x, y));
        treesObj.Add(pine);
    }

    //This Fonction place a tree on the map at a random coordinate
    public bool RandomPlaceTree(int cat)
    {
        if (nbFreeSpace == 0)
        {
            return false;
        }
        else
        {
            (int, int) coord = SelectFreePlace();
            PlaceTree(cat, coord.Item1, coord.Item2);
            return true;
        }
    }

    public void LoadData(List<Tree> datas) {
        //Clear old data
        this.trees = new List<Tree>();
        notfree = new bool[rows, cols];
        nbFreeSpace = rows * cols;
        foreach (GameObject obj in treesObj) {
            Destroy(obj);
        }
        //Create new data
        foreach (Tree tree in datas) {
            PlaceTree(tree.cat, tree.coordX, tree.coordY); 
        }
    }
}
