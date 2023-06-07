using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFinal : MonoBehaviour
{
    // Start is called before the first frame update
    
    private float temp = 0f;
    private float limit = 35f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        temp += Time.deltaTime;
        if (temp >= limit)
        {
            this.GetComponent<MenuControl>().buttonGalery();
        }
     }
}
