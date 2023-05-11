using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject PantallaDeCarga;
    public Slider Slider;

    // Start is called before the first frame update
    void Start()
    {
        int levelToLoad = LevelLoader.nextLevel;
        StartCoroutine(this.MakeTheLoad(levelToLoad));        
    }

    IEnumerator MakeTheLoad(int level)
    {
        //Esta linea se puede eliminar para que no retrase el juego
        //yield return new WaitForSeconds(2.5f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        PantallaDeCarga.SetActive(true);
        while (!operation.isDone)
        {
            float Progreso = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(Progreso);
            Slider.value = Progreso;            
            yield return null;
        }
    }
}
