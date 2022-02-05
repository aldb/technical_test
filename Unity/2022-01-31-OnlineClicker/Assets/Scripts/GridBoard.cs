using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBoard : MonoBehaviour
{
    [SerializeField]
    private int rows = 7;
    [SerializeField]
    private int cols = 8;
    [SerializeField]
    private float tileSize = 1.0f;
    private String[] pineCat = new String[3] { "pineA", "pineB", "pineC" };

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
        
    }

    //This fonction select random starting coordinate
    //From this coordinate it parcourt the matrix until a slot is avaible
    private (int, int) SelectFreePlace()
    {
        int y = rand.Next(0, cols - 1);
        int x = rand.Next(0, rows - 1);
        bool notfound = true;
       
        while (notfound)
        {
            if (notfree[x, y])
            {
                if (y < cols - 1){
                    y++;
                }
                else{
                    y = 0;
                    x = (x + 1) % rows;
                }
            }
            else{
                notfound = false;
            }
        }
        //if (notfound) Debug.LogError("NOT FOUND ");
        return (x, y);
    }

    //This Fonction place a tree on the map 
    private void PlaceTree(int cat, int x , int y)
    {
        notfree[x, y] = true;
        nbFreeSpace--;
        GameObject pine = (GameObject)Instantiate(Resources.Load(pineCat[cat]), transform);

        float posX = x * tileSize - (rows-1.5f)* tileSize;
        float posY = y * tileSize - cols * tileSize;

        pine.transform.position = new Vector3(posX, 0.5f, posY);
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
