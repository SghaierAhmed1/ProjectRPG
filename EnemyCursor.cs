using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCursor : MonoBehaviour
{
    public Texture2D curs1;
    public Texture2D curs2;
    public bool k = false ;
    public GameObject click;
    void OnMouseOver()
    {
      k = true;
      Cursor.SetCursor(curs2,Vector2.zero, CursorMode.ForceSoftware);
      click.SetActive (false);
    }

    void OnMouseExit()
    {
      k = false;
      Cursor.SetCursor(curs1,Vector2.zero, CursorMode.ForceSoftware);
    }
}
