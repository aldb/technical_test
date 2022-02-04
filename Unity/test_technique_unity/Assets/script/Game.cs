using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    //Player
    const float delaySec = 5.0f;
    public int lvlClickCollect;
    public int quantityClickCollect;
    public int lvlAutoCollect;
    public int quantityAutoCollect;
    public int ressources;

    //TEXT
    public GameObject lvlTextAutoCollect;
    public GameObject lvlTextClickCollect;
    public GameObject effectTextAutoCollect;
    public GameObject effectTextClickCollect;

    protected float Timer;


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

    public void incrementRessourcesOnClick()
    {
        ressources += quantityClickCollect;
    }

    public void levelUpClickCollect()
    {
        if (ressources > 21)
        {
            ressources -= 20;
            lvlClickCollect += 1;
            quantityClickCollect = quantityClickCollect * 2;
            updateTextClickCollect();

        }
    }

    public void levelUpAutoCollect()
    {
        if (ressources > 21)
        {
            ressources -= 20;
            lvlClickCollect += 1;
            quantityAutoCollect = ((int)Math.Pow(2, Math.Max(0, (lvlAutoCollect - 1)))) / 2;
            updateTextAutoCollect();
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        quantityClickCollect = (int) Math.Pow(2,lvlClickCollect);
        Debug.Log(quantityClickCollect);
     
        quantityAutoCollect = ((int)Math.Pow(2, Math.Max(0, (lvlAutoCollect - 1))) ) / 2;
        updateTextAutoCollect();
        updateTextClickCollect();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        //We gain ressources every delaySec seconde
        if (Timer >= delaySec)
        {
            Timer = 0f;
            ressources += quantityAutoCollect;
        }

    }



}
