using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] private Texture2D mouseTexture;

    void Awake()
    {
        Cursor.visible = false;
    }

    void OnGUI()
    {
        Vector2 mousePos = Event.current.mousePosition;

        GUI.Label(new Rect(mousePos.x - 19, mousePos.y - 19, mouseTexture.width - 20, mouseTexture.height - 20), mouseTexture);
    }
}
