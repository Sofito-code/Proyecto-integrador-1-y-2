using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PiecesController : MonoBehaviour
{
    public TMP_Text pieces;
    public TMP_Text notification;
    private bool setPiece = false;
    private int piecesPlayer = 0;
    private PiecesDAO piecesDAO;

    // Start is called before the first frame update
    void Start()
    {
        piecesDAO = this.GetComponent<PiecesDAO>();
        piecesDAO.ReadJugador();
        piecesPlayer = piecesDAO.jugador.available_pieces;
        if(piecesPlayer >= 15)
        {
            setPiece = true;
        }
        pieces.text = piecesPlayer + "";
    }

    // Update is called once per frame
    void Update()
    {
        if (setPiece)
        {
            int numberPieces = (piecesPlayer / 15) > 10 ? 10: (piecesPlayer / 15);
            int remainder = piecesPlayer % 15;
            ModelCuadros[] paints = piecesDAO.ReadCuadros();
            List<ModelCuadros> paintsList = new List<ModelCuadros>();
            for(int i = 0; i < paints.Length; i++){
                ModelCuadros paint = paints[i];
                if(paint.landed == 0){
                    paintsList.Add(paint);
                }
            }
            if(paintsList.Count > 0){
                for (int i = 0; i < numberPieces; i++)
                {
                    piecesDAO.BuyPaint(paintsList[i].painting_id);
                }
                piecesDAO.jugador.available_pieces = remainder;
                piecesDAO.SaveJugador();
                notification.gameObject.SetActive(true);
                pieces.text = remainder + "";
            }
            setPiece = false;
        }
    }
}
