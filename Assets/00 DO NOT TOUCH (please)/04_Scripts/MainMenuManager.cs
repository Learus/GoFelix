using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void Start()
    {
        Cursor.visible = true;
    }

    public void Go()
    {
        GoFelixManager.Instance.NextGameFree();
    }

    public void Quit()
    {
        GoFelixManager.Instance.Quit();
    }
}
