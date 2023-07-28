using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TextureLoader : MonoBehaviour
{
    public string webpageURL; // URL of the webpage 

    void Start()
    {
        LoadTextureFromWebpage();
    }
    
    public void LoadTextureFromWebpage()
    {
        StartCoroutine(LoadTexture());
    }

    private IEnumerator LoadTexture()
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(webpageURL))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error while loading texture: " + www.error);
            }
            else
            {
                
                Texture2D texture = DownloadHandlerTexture.GetContent(www);

                Renderer renderer = GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.mainTexture = texture;
                }
                else
                {
                    RawImage rawImage = GetComponent<RawImage>();
                    if (rawImage != null)
                    {
                        rawImage.texture = texture;
                    }
                }
            }
        }
    }
}
