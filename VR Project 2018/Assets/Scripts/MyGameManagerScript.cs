using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MyGameManagerScript : MonoBehaviour
{
    public const int STOMACH = 0;
    public const int LIVER = 1;
    public const int HEART = 2;

    public static MyGameManagerScript Instance{ set; get; }
    private bool unlock = false;
    private int level = STOMACH;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Timer>().beginTimer("Stomach");
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!unlock) return;

        if (level == STOMACH) {
            GameObject.FindGameObjectWithTag("StomachUnlockable").SetActive(false);
        } else if (level == LIVER) {
            GameObject.FindGameObjectWithTag("LiverUnlockable").SetActive(false);
        } else if (level == HEART) {
            GameObject.FindGameObjectWithTag("HeartUnlockable").SetActive(false);
        }
        level++;
        unlock = false;
    }
    
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

    public void Unlock()
    {
        unlock = true;
    }
}
