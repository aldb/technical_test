using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleText : MonoBehaviour
{
    public GameObject lvlTextAutoCollect;
    public GameObject lvlTextClickCollect;
    public GameObject effectTextAutoCollect;
    public GameObject effectTextClickCollect;

    void Start()
    {
        lvlTextAutoCollect.GetComponent<UnityEngine.UI.Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
