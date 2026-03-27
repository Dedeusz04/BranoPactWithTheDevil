using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruszańsko : MonoBehaviour
{

    public float speed = 12f;
    public float skok = 3f;
    public float air;
    Rigidbody rb;
    public Transform orientation;
    public float playerheight;
    public LayerMask groundMask;
    public int m = 0;
    public float grounddrag;
    float x, z;
    Vector3 ruszac;
    float exitpos;
    bool isGrounded;
    bool ReadytoJump;
    public float jumpCoolDown;
    public float falldamage;
    GameObject target;

    // Update is called once per frame
    void Start()
    {
        target = GameObject.Find("Gracz");
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        Resetjump();
    }
    private void Update()
    {

        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerheight * 0.5f+ 0.1f, groundMask);
        MyInput();
        Speed();
        if (isGrounded)
        {
            rb.drag = grounddrag;
            m = 0;
            if ((exitpos - transform.position.y) > 15)
            {
                Debug.Log("dostales modr");
               
                falldamage = (exitpos - transform.position.y)*0.75f;
                falldamage = Mathf.Round(falldamage * 1f) * 1f;
                Debug.Log(falldamage);
                target.GetComponent<graczhp>().Obrazenie(falldamage);
                exitpos = transform.position.y;
            }
        }
        else
        {
            rb.drag = 0;
        }

        if (!isGrounded && m == 0)
        {
            m = 1;
            exitpos = transform.position.y;
        }
        


    }
    private void MovePlayer()
    {
       ruszac = orientation.forward * z + orientation.right * x;
        rb.AddForce(ruszac * speed * 10f, ForceMode.Force);
        if (isGrounded)
        {
            rb.AddForce(ruszac.normalized * speed * 10f, ForceMode.Force);

        }
        else if (!isGrounded)
        {
            rb.AddForce(ruszac.normalized * speed * 10f * air, ForceMode.Force);
        }

    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed = 15f;
        }
        else if (!Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            speed =7f;

        }
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.Space) && isGrounded && ReadytoJump)
        {
            ReadytoJump = false;
            Jump();
            Invoke(nameof(Resetjump), jumpCoolDown);
        }
    }
    private void Speed()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * skok, ForceMode.Impulse);

    }
    private void Resetjump()
    {
        ReadytoJump = true;
    }
}
