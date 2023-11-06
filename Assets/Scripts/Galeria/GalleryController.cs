using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class GalleryController : MonoBehaviour
{
    // Start is called before the first frame update
    List<int> posts;
    void Start()
    {
        posts = new List<int>();
        ModelCuadros[] paints = ReadCuadros();
            for(int i = 0; i < paints.Length; i++){
                ModelCuadros paint = paints[i];
                if(paint.landed == 1){
                    posts.Add(paint.painting_id);
                }
            }
        for (int i = 0; i < posts.Count; i++)
        {
            int id = posts[i];
            Sprite sp  = Resources.Load<Sprite>(id+"");
            this.transform.GetChild(id).GetChild(0).gameObject.GetComponent<Image>().sprite = sp;
        }
    }

    public ModelCuadros[] ReadCuadros()
    {
        string path = Path.Combine(Application.persistentDataPath, "cuadros.data");
        string text = File.ReadAllText(path);
        ModelCuadrosArray cuadrosArray = JsonUtility.FromJson<ModelCuadrosArray>(text);
        ModelCuadros[] cuadros = cuadrosArray.cuadros;
        return cuadros;
    }
}
