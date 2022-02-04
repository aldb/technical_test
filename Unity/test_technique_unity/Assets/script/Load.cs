using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
public class Load : MonoBehaviour
{
    public UnityEngine.UI.InputField loadCodeField;
    public GameObject messageText;
    public GameObject loadWindow;
    public Game game;
    public void OnClickLoadButton()
    {
        StartCoroutine(LoadData());
    }
    public class GameData
    {
        public int lvlClickCollect;
        public int lvlAutoCollect;
        public int ressources;
    }

    IEnumerator LoadData()
    {
        string saveId = loadCodeField.text.ToString();
        WWWForm form = new WWWForm();
        form.AddField("id", saveId);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/load.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log(www.downloadHandler.text);
                messageText.GetComponent<TMPro.TextMeshProUGUI>().text = "Error in loading";
                yield return new WaitForSeconds(1);
                loadWindow.SetActive(false);
            }
            else
            {
                GameData data = JsonUtility.FromJson<GameData>(www.downloadHandler.text);
                game= (Game)FindObjectOfType(typeof(Game));
                game.loadData(data.lvlClickCollect, data.lvlAutoCollect, data.ressources);

                messageText.GetComponent<TMPro.TextMeshProUGUI>().text = "Game Load";
                yield return new WaitForSeconds(1);
                loadWindow.SetActive(false);
            }

        }
    }
}