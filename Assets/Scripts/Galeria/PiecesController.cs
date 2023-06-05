using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PiecesController : MonoBehaviour
{
    public TMP_Text pieces;
    public TMP_Text notification;
    private bool setPiece = false;
    private int piecesDB = 0;

    // Start is called before the first frame update
    void Start()
    {
        piecesDB = this.GetComponent<DBManagement>().QueryGetPieces();
        this.GetComponent<DBManagement>().CloseConn();
        if (piecesDB >= 15)
        {
            setPiece = true;
        }
        pieces.text = piecesDB + "";
    }

    // Update is called once per frame
    void Update()
    {
        if (setPiece)
        {
            int numberPieces = piecesDB / 15;
            int remainder = piecesDB % 15;
            List<int> paints = this.GetComponent<DBManagement>().QueryGetPaints();
            this.GetComponent<DBManagement>().CloseConn();
            for (int i = 0; i < numberPieces; i++)
            {
                this.GetComponent<DBManagement>().QueryBuyPaint(paints[i]);
                this.GetComponent<DBManagement>().CloseConn();
            }
            this.GetComponent<DBManagement>().QuerySetPiecesToRemainder(remainder);
            this.GetComponent<DBManagement>().CloseConn();
            notification.gameObject.SetActive(true);
            pieces.text = remainder + "";
            setPiece = false;
        }
    }
}
