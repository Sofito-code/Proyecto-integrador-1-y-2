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
                        }
                    }
                    if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
                    {                        
                        if (auxRail[point].position != rail1[point].position)
                        {
                            ChangeRail(rail1);                           
                        }
                    }
                    player.transform.position = Vector3.MoveTowards(
                        player.transform.position,
                        auxRail[point].position,
                        velocidad * Time.deltaTime
                    );
                    if ((auxRail[point].position - player.transform.position) != new Vector3(0, 0, 0))
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
