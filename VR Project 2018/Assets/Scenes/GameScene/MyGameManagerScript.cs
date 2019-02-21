using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MyGameManagerScript : MonoBehaviour
{
    public static MyGameManagerScript Instance{ set; get; }
    public Vector3 lastCheckPointPos;
    public int checkPointNum;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(Instance);
            Debug.Log(this.GetInstanceID());
        } else {
            Destroy(gameObject);
        }
        
        if (checkPointNum == 0 || checkPointNum == 1) {
            Load("Player");
            Load("Level01");
            Load("Level02");
        } else if (checkPointNum == 2) {
            Load("Player");
            Load("Level02");
            Load("Level03");
        } else if (checkPointNum >= 3 && checkPointNum <= 5) {
            Load("Player");
            Load("Level03");
            Load("Level04");
            Load("Level05");
        } else if (checkPointNum == 6) {
            Load("Player");
            Load("Level05");
            Load("Level06");
        }
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
