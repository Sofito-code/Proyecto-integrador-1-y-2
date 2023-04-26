using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string levelToLoad = LevelLoader.nextLevel;
        StartCoroutine(this.MakeTheLoad(levelToLoad));        
    }

    IEnumerator MakeTheLoad(string level)
    {
        //Esta linea se puede eliminar para que no retrase el juego
        yield return new WaitForSeconds(2.5f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(level);
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
