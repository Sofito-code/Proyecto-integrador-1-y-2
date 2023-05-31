using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalMove;
    private float verticalMove;
    private CharacterController player;
    private Vector3 playerInput;
    private Vector3 camForward;
    private Vector3 movePlayer;
    public float speed;
    public float rotation;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");      
        CamDirection();
        playerInput = new Vector3(0, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);
        movePlayer = playerInput.z * camForward;
        player.transform.Rotate(0,horizontalMove * rotation * Time.deltaTime,0);
        player.Move(movePlayer * speed * Time.deltaTime);
    }

    void CamDirection()
    {
        camForward = player.transform.forward;        
        camForward.y = 0;
        camForward = camForward.normalized;
    }
}
