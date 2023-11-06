using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{

    public GameObject player;
    public Transform[] rail1;
    public Transform[] rail2;
    private Transform[] auxRail;
    public float velocidad;
    public bool career = true;

    private bool rigth = true;
    public float velRotacion;
    private int point = 0;
    public Coroutine spawnCoroutine;

    void Start()
    {
        auxRail = (Transform[])rail2.Clone();
        for(int i=0; i<rail1.Length; i++){
            Vector3 distancia = rail1[i].transform.position - rail2[i].transform.position;
            Debug.Log($"{distancia}");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StopSpawn() => StopCoroutine(spawnCoroutine);
    public void StartRuninng()
    {
        spawnCoroutine = StartCoroutine(Run());
    }

    IEnumerator Run()
    {
        float tpDistance = 8f;
        bool arrive;
        for (point = 0; point < auxRail.Length; point++)
        {
            arrive = false;
            while (!arrive)
            {
                if (player.transform.position != auxRail[point].position)
                {
                    yield return new WaitForSeconds(Time.deltaTime);
                    if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
                    {
                        if (auxRail[point].position != rail2[point].position)
                        {
                            ChangeRail(rail2);
                            if(rigth == false){
                                
                                player.transform.position += (Vector3.right * tpDistance);
                                //player.transform.localPosition += new Vector3(0,0,8f);
                                rigth = true;
                            }              
                        }
                    }
                    if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
                    {
                        if (auxRail[point].position != rail1[point].position)
                        {
                            ChangeRail(rail1);
                            if(rigth == true){
                                player.transform.position += (Vector3.left * tpDistance);
                                //player.transform.localPosition += new Vector3(0,0,-8f);
                                rigth = false;
                            }
                        }
                    }

                    //aquí teletransportar el jugador
                    
                    player.transform.position = Vector3.MoveTowards(
                        player.transform.position,
                        auxRail[point].position,
                        velocidad * Time.deltaTime
                    );
                    if (
                        (auxRail[point].position - player.transform.position)
                        != new Vector3(0, 0, 0)
                    )
                    {
                        Quaternion rotation = Quaternion.LookRotation(
                            auxRail[point].position - player.transform.position
                        );
                        player.transform.rotation = Quaternion.Lerp(
                            player.transform.rotation,
                            rotation,
                            velRotacion * Time.deltaTime
                        );
                    }
                }
                else
                {
                    arrive = true;
                }
            }
            if (career && point == (auxRail.Length - 1))
            {
                point = -1;
            }
        }
    }

    void ChangeRail(Transform[] rail)
    {
        for (int i = 0; i < rail.Length; i++)
        {
            auxRail[i] = rail[i];
        }
    }
}
