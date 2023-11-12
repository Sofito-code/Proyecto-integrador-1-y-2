using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isOver = false;
    [SerializeField]
    public ModelCuadrosArray cuadrosArray;

    void Start()
    {
        int countAvilable = 0;
        int final = 0;
        ModelCuadros[] paints = ReadCuadros();
        for (int i = 0; i < paints.Length; i++)
        {
            ModelCuadros paint = paints[i];
            if (paint.landed == 1)
            {
                countAvilable++;
            }
            if (paint.painting_id == 11)
            {
                final = paint.pieces_amount;
            }
        }
        SaveCuadros();
        int countPaints = paints.Length;
        countPaints -= 1;
        if (countAvilable == countPaints && final == 10)
        {
            isOver = true;
            for (int i = 0; i < paints.Length; i++)
            {
                ModelCuadros paint = paints[i];
                if (paint.painting_id == 11)
                {
                    paint.pieces_amount = 0;
                }
            }
            SaveCuadros();
        }
    }

    public ModelCuadros[] ReadCuadros()
    {
        string path = Path.Combine(Application.persistentDataPath, "cuadros.data");
        FileStream fs = new FileStream(path, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        ModelCuadros[] cuadros = (ModelCuadros[]) bf.Deserialize(fs);
        fs.Close();
        this.cuadrosArray.cuadros = cuadros;
        return cuadros;
    }

    public void SaveCuadros()
    {
        ModelCuadros[] cuadros = cuadrosArray.cuadros;
        string path = Path.Combine(Application.persistentDataPath, "cuadros.data");
        FileStream fs = new FileStream(path, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, cuadros);
        fs.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOver)
        {
            StartCoroutine(Final());
        }
    }

    IEnumerator Final()
    {
        yield return new WaitForSeconds(2);
        this.GetComponent<MenuControl>().GoToFinalScene();
    }
}
