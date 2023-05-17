
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Transform[] rail1;
    public float velocidad;
    public bool carrera = true;
    public float velRotacion;

    private bool correr = true;
    void Start()
    {
                
    }
    

    // Update is called once per frame
    void Update()
    {       
        Animator anim = player.transform.GetChild(0).GetComponent<Animator>();
        anim.SetFloat("VelY", 1); 
        if(correr){
            
            StartCoroutine(Runner());            
            correr = false;
        }
    }

    IEnumerator Runner(){
        bool llegoAlPunto;
        
        for (int i= 0; i < rail1.Length; i++)
        {
            llegoAlPunto = false;
            while (!llegoAlPunto){                

                if(player.transform.position != rail1[i].position){
                    
                    yield return new WaitForSeconds(Time.deltaTime);
                    player.transform.position = Vector3.MoveTowards(player.transform.position, rail1[i].position,velocidad * Time.deltaTime);
                    if((rail1[i].position - player.transform.position) != new Vector3(0,0,0)){
                        Quaternion rotation = Quaternion.LookRotation(rail1[i].position - player.transform.position);
                        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, rotation, velRotacion * Time.deltaTime);
                    }
                }
                else{
                    llegoAlPunto = true;
                }
            }
            if(carrera && i == (rail1.Length-1)){
                i = -1;
            } 
        }
    }
}

