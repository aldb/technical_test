using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class Tree 
{
    public int cat;
    public int coordX;
    public int coordY;

    public Tree(int cat, int x, int y )
    {
        this.cat = cat;
        this.coordX = x;
        this.coordY = y; 
        
    }
 
}
