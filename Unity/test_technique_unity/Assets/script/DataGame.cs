using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public string id;
    public int lvlClickCollect;
    public int lvlAutoCollect;
    public int ressources;
    public List<Tree> tiles;

    public GameData(string id, int lvlClickCollect, int lvlAutoCollect, int ressources, List<Tree> tiles)
    {
        this.id = id;
        this.lvlAutoCollect = lvlAutoCollect;
        this.lvlClickCollect = lvlClickCollect;
        this.ressources = ressources;
        this.tiles = tiles;
    }
}
