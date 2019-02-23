using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MyGameManagerScript : MonoBehaviour
{
    public static MyGameManagerScript Instance{ set; get; }
    /*
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    */
    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(Instance);
            Debug.Log(this.GetInstanceID());
        } else {
            Destroy(gameObject);
        }
        
        Load("Player");
        Load("NewLevel01");
        Load("NewLevel02");
        Load("NewLevel03");
        Load("NewLevel04");
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
