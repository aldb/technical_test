using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class Load : MonoBehaviour
{
    [SerializeField]
    public const String URL = "http://localhost/load.php";
    
    public UnityEngine.UI.InputField loadCodeField;
    public GameObject messageText;
    public GameObject loadWindow;
    public Game game;

    public void OnClickPrimaryLoadButton()
    {
        loadWindow.SetActive(true);
    }
    public void OnClickLoadButton()
    {
        StartCoroutine(LoadData());
    }
    public void OnClickCloseButton()
    {
        loadWindow.SetActive(false);
    }
    IEnumerator LoadData()
    {
        string saveId = loadCodeField.text.ToString();
        WWWForm form = new WWWForm();
        form.AddField("id", saveId);

        using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text);
                messageText.GetComponent<TMPro.TextMeshProUGUI>().text = "ERROR: The game could not be load";
                yield return new WaitForSeconds(1);
                loadWindow.SetActive(false);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                
                GameData data = JsonUtility.FromJson<GameData>(www.downloadHandler.text);

                game = (Game)FindObjectOfType(typeof(Game));
                game.loadData(data.lvlClickCollect, data.lvlAutoCollect, data.ressources);

                game.grid.LoadData(data.tiles);

                messageText.GetComponent<TMPro.TextMeshProUGUI>().text = "Game Load";
                yield return new WaitForSeconds(1);
                loadWindow.SetActive(false);
            }

        }
    }
}