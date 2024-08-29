using System;
using UnityEngine;

public class FPS : MonoBehaviour
{
    public float deltaTime;
    

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment =
            TextAnchor.UpperRight; //Posiciona el lugar donde se mostrara, lo puedes poner en el centro o derecha too.
        style.fontSize = h * 2 / 100;
        style.normal.textColor = Color.red; //Coloca el color en el que se mostrara
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
