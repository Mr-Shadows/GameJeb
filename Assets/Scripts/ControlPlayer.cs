using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayer : MonoBehaviour
{
    
    public Camera CamPlayer;
    public float MoveSpeed = 1;
    public float xMove, zMove;
    float xRot, yRot;
    public float MouseSense = 3f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Rigidbody rb;
    public  bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        



        xMove = Input.GetAxis("Horizontal")  * Time.deltaTime;
        zMove = Input.GetAxis("Vertical")  * Time.deltaTime;

        transform.Translate(Vector3.forward * zMove * MoveSpeed * Time.deltaTime);

        transform.Translate(Vector3.right * xMove * MoveSpeed * Time.deltaTime);

        xRot += Input.GetAxis("Mouse X")*MouseSense;
        
        if(CamPlayer.transform.localRotation.x <80 && Input.GetAxis("Mouse Y") * MouseSense>0)
            yRot += Input.GetAxis("Mouse Y") * MouseSense;
        if (CamPlayer.transform.localRotation.x > -80 && Input.GetAxis("Mouse Y") * MouseSense < 0)
            yRot += Input.GetAxis("Mouse Y") * MouseSense;

        transform.rotation = Quaternion.Euler(0f, xRot, 0f);
        CamPlayer.transform.rotation = Quaternion.Euler(-yRot, xRot, 0f);

        isGrounded = Physics.Raycast(groundCheck.position, -Vector3.up, groundDistance, groundMask);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        Debug.DrawRay(groundCheck.position, -Vector3.up * groundDistance, Color.red);

    }
}
