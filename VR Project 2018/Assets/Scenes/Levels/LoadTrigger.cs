using System.Collections;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    public string loadName;
    public string unloadName;

    private void OnTriggerEnter(Collider col)
    {
        if (loadName != "")
            GameManagerScript.Instance.Load(loadName);

        if (unloadName != "")
            StartCoroutine("UnloadScene");
    }

    IEnumerator UnloadScene()
    {
        yield return new WaitForSeconds(.10f);
        GameManagerScript.Instance.Unload(unloadName);
    }
}
