using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GalleryController : MonoBehaviour
{
    // Start is called before the first frame update
    List<int> posts;
    void Start()
    {
        posts = this.GetComponent<DBManagement>().QueryGetPaintsAvilable();
        this.GetComponent<DBManagement>().CloseConn();
        for (int i = 0; i < posts.Count; i++)
        {
            int id = posts[i];
            Sprite sp  = Resources.Load<Sprite>(id+"");
            this.transform.GetChild(id).GetChild(0).gameObject.GetComponent<Image>().sprite = sp;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
