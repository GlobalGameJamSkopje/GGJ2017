using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoaderScript : MonoBehaviour
{
    private int _nextSceneToLoad = 0;


    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadSceneByBuildIndex(int buildIndex)
    {
        _nextSceneToLoad = buildIndex;
        Invoke("LoadSceneByIndexInvoke", 0.5f);
    }

    public void LoadSceneByIndexInvoke()
    {
        SceneManager.LoadScene(_nextSceneToLoad);

    } 
    
}
