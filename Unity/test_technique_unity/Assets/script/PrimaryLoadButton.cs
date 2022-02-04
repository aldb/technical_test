using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryLoadButton : MonoBehaviour
{
    public GameObject loadWindow;
   

    public void OnClickPrimaryLoadButton()
    {
        loadWindow.SetActive(true);
    }
}
