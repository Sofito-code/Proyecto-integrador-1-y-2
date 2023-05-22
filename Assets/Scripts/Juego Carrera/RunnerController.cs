using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Transform[] rail1;
    public Transform[] rail2;
    private Transform[] auxRail;
    public float velocidad;
    public bool career = true;
    public float velRotacion;
    private Animator anim;
    private int point = 0;
    private bool isRunning = true;

    void Start()
    {
        anim = player.transform.GetChild(0).GetComponent<Animator>();
        auxRail = (Transform[])rail1.Clone();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("VelY", 1);

        if (isRunning)
        {
            StartCoroutine(Run());
            isRunning = false;
        }
    }

    IEnumerator Run()
    {
        bool arrive;
        for (int i = 0; i < auxRail.Length; i++)
        {
            point = i;
            arrive = false;
            while (!arrive)
            {
                if (player.transform.position != auxRail[i].position)
                {
                    yield return new WaitForSeconds(Time.deltaTime);
                    if (Input.GetKeyDown("right"))
                    {
                        if (auxRail[i].position != rail2[i].position)
                        {
                            Debug.Log($"Pasando");     
                            changeRail(rail2);
                            if(point == 0 || point == 5){
                                StartCoroutine(RunHorizontally());
                            }
                        }
                        else
                        {
                            Debug.Log($"No puedo pasar a la dere");
                        }
                    }
                    if (Input.GetKeyDown("left"))
                    {
                        
                        if (auxRail[i].position != rail1[i].position)
                        {
                            Debug.Log($"Pasando");
                            changeRail(rail1);
                            if(point == 0 || point == 5){
                                StartCoroutine(RunHorizontally());
                            }                            
                        }
                        else
                        {
                            Debug.Log($"No puedo pasar a la izquierde");
                        }
                    }
                    player.transform.position = Vector3.MoveTowards(
                        player.transform.position,
                        auxRail[i].position,
                        velocidad * Time.deltaTime
                    );
                    if ((auxRail[i].position - player.transform.position) != new Vector3(0, 0, 0))
                    {
                        Quaternion rotation = Quaternion.LookRotation(
                            auxRail[i].position - player.transform.position
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
            if (career && i == (auxRail.Length - 1))
            {
                i = -1;
            }
        }
    }

    IEnumerator RunHorizontally()
    {
        bool llegoAlCarril = false;
        while (!llegoAlCarril)
        {
            float distancia = auxRail[point].position.z - player.transform.position.z;            
            if (Abs(distancia) > 0.09f)
            {
                yield return new WaitForSeconds(Time.deltaTime);
                Vector3 final = player.transform.position + new Vector3(0, 0, distancia);
                player.transform.position = Vector3.MoveTowards(
                    player.transform.position,
                    final,
                    velocidad * Time.deltaTime
                );
            }
            else
            {
                llegoAlCarril = true;
            }
        }
    }

    void changeRail(Transform[] rail)
    {
        for (int i = 0; i < rail.Length; i++)
        {
            auxRail[i] = rail[i];
        }
        Debug.Log($"Carril listo");
    }

    float Abs(float a)
    {
        if (a < 0)
        {
            return a * -1;
        }
        else
        {
            return a;
        }
    }
}
