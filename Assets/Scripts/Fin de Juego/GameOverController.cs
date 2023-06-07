using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isOver = false;
    void Start()
    {
        int countAvilable = this.GetComponent<DBManagement>().QueryGetCountPaintsAvilable("Cuadros_obtenidos");
        this.GetComponent<DBManagement>().CloseConn();
        int countPaints = this.GetComponent<DBManagement>().QueryGetCountPaintsAvilable("Cuadros");
        this.GetComponent<DBManagement>().CloseConn();
        countPaints -= 1;
        int final = this.GetComponent<DBManagement>().QueryGetFinal();
        this.GetComponent<DBManagement>().CloseConn();
        if(countAvilable == countPaints && final == 10){
            isOver = true;
            this.GetComponent<DBManagement>().QuerySetFinal();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isOver){
            StartCoroutine(Final());
        }
    }

    IEnumerator Final(){
        yield return new WaitForSeconds(2);
        this.GetComponent<MenuControl>().GoToFinalScene();
    }

}
