using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToRunner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LevelLoader.LoadLevel(5);
    }
}
