using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursTrol : MonoBehaviour
{
    public Texture2D curs;
    void Start()
    {
    Cursor.SetCursor(curs,Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
