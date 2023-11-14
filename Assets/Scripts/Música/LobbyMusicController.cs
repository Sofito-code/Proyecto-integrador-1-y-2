using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMusicController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string song = FindObjectOfType<SoundManager>().song;
        if(song != "Lobby1")
            FindObjectOfType<SoundManager>().Change("Lobby1");
    }
}
