
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoFelixManager : PersistentSingleton<GoFelixManager>
{
    public int Lives = 3;
    public bool win = true;
    
    private List<int> remainingScenes;
    private int totalScenes;
    
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        totalScenes = SceneManager.sceneCountInBuildSettings;
        ResetScenes();
    }

    private void ResetScenes()
    {
        // Initialize or clear the list
        if (remainingScenes == null)
            remainingScenes = new List<int>();
        else
            remainingScenes.Clear();

        // Add all scenes to the list, excluding the first two
        for (int i = 2; i < totalScenes; i++)
        {
            remainingScenes.Add(i);
        }
    }

    public int GetNextGameIndex(){

        Debug.Log(remainingScenes);
        Debug.Log(remainingScenes.Count);
        
        // If all scenes have been loaded, reset the list
        if (remainingScenes.Count == 0)
        {
            ResetScenes();
        }

        // Pick a random index from the remaining scenes
        int randomIndex = Random.Range(0, remainingScenes.Count);
        int sceneIndex = remainingScenes[randomIndex];

        // Remove the loaded scene from the list of remaining scenes
        remainingScenes.RemoveAt(randomIndex);

        return sceneIndex;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        win = true;

        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            Debug.Log("queued next game");
            Invoke("NextGame", 7.25f);
        }
    }

    public void NextGame()
    {
        if (win == false) Lives--;
        
        if(Lives == 0)
            SceneManager.LoadScene(0);
        
        else            
            SceneManager.LoadScene(1);
    }

    public void NextGameFree()
    {
        SceneManager.LoadScene(1);
    }
}
