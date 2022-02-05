using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class Save : MonoBehaviour
{
    [SerializeField]
    public const int codeLength = 6;
    [SerializeField]
    public const String URL = "http://localhost/save.php";
   
    public System.Random rand = new System.Random();
    public GameObject saveWindow;
    public GameObject messageText;
    public GameObject displayCode;
    public UnityEngine.UI.InputField inputFieldCode;
    public Game game;

    public void OnClickSaveButton()
    {
        saveWindow.SetActive(true);
        messageText.SetActive(true);
        displayCode.SetActive(false);
        StartCoroutine(SaveGame());
    }
    public void OnClickCloseButton()
    {
        saveWindow.SetActive(false);
    }
    private string GenerateSaveCode(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[rand.Next(s.Length)]).ToArray());
    }

    IEnumerator SaveGame()
    {
        String id = GenerateSaveCode(codeLength);
        GameData gameData = new GameData(id, game.lvlClickCollect, game.lvlAutoCollect, game.ressources, game.grid.trees);
        string myjson = JsonUtility.ToJson(gameData);

        byte[] postData = System.Text.Encoding.UTF8.GetBytes(myjson);
        var request = new UnityWebRequest(URL, "POST");

        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.Send();

        if (request.isNetworkError || request.isHttpError){
            messageText.GetComponent<TMPro.TextMeshProUGUI>().text = "ERROR: The game could not be save";
            yield return new WaitForSeconds(1);
            saveWindow.SetActive(false);
        }
        else{
            messageText.SetActive(false);
            inputFieldCode.text = id;
            displayCode.SetActive(true);
        }
    }
}
