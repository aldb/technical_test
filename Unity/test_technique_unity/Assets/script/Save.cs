using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.Networking;


public class Save : MonoBehaviour
{
    [SerializeField]
    public const int codeLength= 6;

    public GameObject messageText;

    public System.Random rand = new System.Random();
    public GameObject saveWindow;
    public Game game;
    WWWForm form;

    public void OnClickSaveButton() {
        saveWindow.SetActive(true);
        StartCoroutine(SaveGame());
    }
    private string GenerateSaveCode(int length) {
        
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[rand.Next(s.Length)]).ToArray());
    }
    IEnumerator SaveGame() {
        form = new WWWForm();
        String id = GenerateSaveCode(codeLength); 
        form.AddField("id",id);
        form.AddField("lvlClickCollect", game.lvlClickCollect);
        form.AddField("lvlAutoCollect", game.lvlAutoCollect);
        form.AddField("ressources", game.ressources);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/save.php", form))
        {
            yield return www.SendWebRequest();
           
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text);
                messageText.GetComponent<TMPro.TextMeshProUGUI>().text = "An error occur";
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                messageText.GetComponent<TMPro.TextMeshProUGUI>().text = "Game Save";
                yield return new WaitForSeconds(1);
                saveWindow.SetActive(false);
            }

        }
    }
}
