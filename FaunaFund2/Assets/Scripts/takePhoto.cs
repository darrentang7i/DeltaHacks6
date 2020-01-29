using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takePhoto : MonoBehaviour
{
    public Rect sourceRect;
    public RawImage background;
    public static Texture2D sourText;

    public RawImage cameraReturn;

    private Texture2D TextureToTexture2D(Texture texture)
    {
        Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA32, false);
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture renderTexture = RenderTexture.GetTemporary(texture.width, texture.height, 32);
        Graphics.Blit(texture, renderTexture);

        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture2D.Apply();

        RenderTexture.active = currentRT;
        RenderTexture.ReleaseTemporary(renderTexture);
        return texture2D;
    }

    public void takePic()
    {
        sourText = TextureToTexture2D(background.texture);

        /*pixContainer.Pix = sourText;
        Debug.Log(pixContainer.Pix);*/

        /*int x = Mathf.FloorToInt(sourceRect.x);
        int y = Mathf.FloorToInt(sourceRect.y);
        int width = Mathf.FloorToInt(sourceRect.width);
        int height = Mathf.FloorToInt(sourceRect.height);

        Color[] pix = sourText.GetPixels(x, y, width, height);

        pixContainer.pix = pix;*/

        cameraReturn.texture = sourText;

        GameObject cameraCanvas = GameObject.Find("CameraCanvas");
        cameraCanvas.SetActive(false);

        GameObject returnCanvas = GameObject.Find("ReturnCanvas");
        returnCanvas.SetActive(true);

        GameObject gameCam = GameObject.Find("Main Camera");
        gameCam.SetActive(true);
    }
}
