using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCartas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LevelLoader.LoadLevel("Juego_memoria");
    }
}
