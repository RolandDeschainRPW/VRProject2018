using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MyGameManagerScript : MonoBehaviour
{
    public static MyGameManagerScript Instance{ set; get; }
    public Vector3 lastCheckPointPos;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(Instance);
        } else {
            Destroy(gameObject);
        }
        Load("Player");
        Load("Level01");
        Load("Level02");
    }

    public void Load(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void Unload(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.UnloadSceneAsync(sceneName);
    }
}
