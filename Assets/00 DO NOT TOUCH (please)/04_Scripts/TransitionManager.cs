using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public void LoadNextGame()
    {
        // Load the scene
        SceneManager.LoadScene( GoFelixManager.Instance.GetNextGameIndex() );
    }
}