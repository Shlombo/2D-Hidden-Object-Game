using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SpriteLoader : MonoBehaviour
{
    public string spriteURL; // URL of the image file 

    private void Start()
    {
        StartCoroutine(LoadSprite());
    }

    private IEnumerator LoadSprite()
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(spriteURL))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error while loading sprite: " + www.error);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(www);
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
                ApplySprite(sprite);
            }
        }
    }

    private void ApplySprite(Sprite sprite)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        Vector2 S = sprite.bounds.size;
        GetComponent<BoxCollider2D>().size = S;
    }

}