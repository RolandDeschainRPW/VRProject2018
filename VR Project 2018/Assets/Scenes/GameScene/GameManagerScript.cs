using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance{ set; get; }

    private void Awake()
    {
        Instance = this;
        Load("Player");
        Load("Level01");
        //Load("Level02");
    }

    public void Load(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void Unload(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.UnloadScene(sceneName);
    }
}
