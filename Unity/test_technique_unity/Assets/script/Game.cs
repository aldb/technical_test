using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    const float DELAY = 5.0f;
    [SerializeField]
    const int COST = 20;
    [SerializeField]
    const int LVLLIMIT = 10; 
    protected float Timer;

    //Player Var
    public int lvlClickCollect;
    private int quantityClickCollect;
    public int lvlAutoCollect;
    private int quantityAutoCollect;
    public int ressources;

    //TEXT Var
    [SerializeField]
    private GameObject lvlTextAutoCollect;
    [SerializeField]
    private GameObject lvlTextClickCollect;
    [SerializeField]
    private GameObject effectTextAutoCollect;
    [SerializeField]
    private GameObject effectTextClickCollect;
    [SerializeField]
    private GameObject scoreText;

    //Tree
    public GridBoard grid;


    //Update the data during loading
    public void loadData(int lvlC, int lvlAut, int r)
    {
        lvlAutoCollect=lvlAut;
        lvlClickCollect=lvlC;
        ressources = r;
        quantityClickCollect = (int)Math.Pow(2, lvlClickCollect);
        quantityAutoCollect = (int)Math.Floor(Math.Pow(2, lvlAutoCollect - 1));

        updateTextAutoCollect();
        updateTextClickCollect();
        updateScoreText();
    }

    private void updateTextAutoCollect()
    {
        lvlTextAutoCollect.GetComponent<TMPro.TextMeshProUGUI>().text = "lvl." + lvlAutoCollect;
        effectTextAutoCollect.GetComponent<TMPro.TextMeshProUGUI>().text = quantityAutoCollect + " per click";
    }
    private void updateTextClickCollect()
    {
        lvlTextClickCollect.GetComponent<TMPro.TextMeshProUGUI>().text = "lvl." + lvlClickCollect;
        effectTextClickCollect.GetComponent<TMPro.TextMeshProUGUI>().text = quantityClickCollect + " per click";
    }
    private void updateScoreText()
    {
        scoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + ressources;
    } 
    public void incrementRessourcesOnClick()
    {
        ressources += quantityClickCollect;
        updateScoreText();
    }
    public void levelUpClickCollect()
    {
        if (lvlClickCollect < LVLLIMIT && ressources >= COST)
        {
            ressources -= COST;
            lvlClickCollect += 1;
            quantityClickCollect = quantityClickCollect * 2;
            updateTextClickCollect();
            updateScoreText();

        }
    }
    public void levelUpAutoCollect()
    {
        if (lvlAutoCollect < LVLLIMIT&& ressources >= COST)
        {
            ressources -= COST;
            lvlAutoCollect += 1;
            quantityAutoCollect = (int)Math.Floor(Math.Pow(2, lvlAutoCollect - 1));
            updateTextAutoCollect();
            updateScoreText();
        }
    }
    public void OnClicBuyPine(int cat)
    {
        if (ressources >= COST)
        {
            if (grid.RandomPlaceTree(cat)) {
                ressources -= COST;
                updateScoreText();
            } 

        }
    }

    void Start()
    {
        grid= (GridBoard)FindObjectOfType(typeof(GridBoard));
        quantityClickCollect = (int) Math.Pow(2,lvlClickCollect);
        quantityAutoCollect = (int)Math.Floor( Math.Pow(2, lvlAutoCollect - 1) );
        updateTextAutoCollect();
        updateTextClickCollect();
        updateScoreText();
    }
    void Update()
    {
        Timer += Time.deltaTime;

        //We gain ressources every delaySec seconde
        if (Timer >= DELAY)
        {
            Timer = 0f;
            ressources += quantityAutoCollect;
            updateScoreText();
        }

    }

}
