using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    public static int nextLevel;

    public static void LoadLevel(int levelName)
    {
        nextLevel = levelName;
        SceneManager.LoadScene(2);
    }
}
