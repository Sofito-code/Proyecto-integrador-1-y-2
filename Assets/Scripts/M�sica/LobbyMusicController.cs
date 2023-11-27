using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyMusicController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager sm = FindObjectOfType<SoundManager>();
        if (sm != null)
        {
            string song = FindObjectOfType<SoundManager>().song;
            if(song != "Lobby1"){
                sm.Change("Lobby1");    
            }
        }
        
    }
}
