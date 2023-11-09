using System;
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
                                float angle = player.transform.eulerAngles.y * Mathf.Deg2Rad;
                                Vector3 movementDirection = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                                Vector3 movement = player.transform.TransformDirection(movementDirection) * tpDistance;
                                player.transform.Translate(movement);
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
                                float angle = player.transform.eulerAngles.y * Mathf.Deg2Rad;
                                Vector3 movementDirection = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                                Vector3 movement = player.transform.TransformDirection(movementDirection) * tpDistance * -1f;
                                player.transform.Translate(movement);
                                rigth = false;
                            }
                        }
                    }
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
