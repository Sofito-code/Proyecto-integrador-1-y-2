using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Loading : MonoBehaviour
{
    public GameObject PantallaDeCarga;
    public Slider Slider;
    public TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        int levelToLoad = LevelLoader.nextLevel;
        StartCoroutine(this.MakeTheLoad(levelToLoad));        
    }

    IEnumerator MakeTheLoad(int level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        PantallaDeCarga.SetActive(true);
        while (!operation.isDone)
        {
            float progreso = Mathf.Clamp01(operation.progress / .9f);            
            Slider.value = progreso; 
            tmp.text = (progreso * 100) + "%";           
            yield return null;
        }
    }
}
