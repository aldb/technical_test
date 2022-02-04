using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UpgradeWindow : MonoBehaviour
{
    public GameObject Window;
    // Start is called before the first frame update
    public void OpenWindow() {
        if (Window != null) {
            Window.SetActive(true);
        }
    }
    public void ClosedWindow() {
        if (Window != null)
        {
            Window.SetActive(false);
        }
    }
 
}
