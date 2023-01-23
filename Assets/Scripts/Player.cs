using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public static float speed=5f;
    public float move;
    private Rigidbody2D rb;
    public static float jump = 300;
    public static Vector3 position;
    public bool inground;
    public static bool trapped;
    public GameObject startpoint;
    public static Vector3 startposition;
    public IPlayerInput PlayerInput;
    // Start is called before the first frame update
    void Start()
    {
        //startposition = new Vector3(startpoint.transform.position.x, startpoint.transform.position.y, startpoint.transform.position.z);
        startposition = new Vector3(0,0,-1);
        rb = GetComponent<Rigidbody2D>();
        if (PlayerInput == null)
        {

        PlayerInput = new PlayerInput();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isdead() || trapped)
        {
            transform.position = startposition;
            trapped = false;
        }
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        move = PlayerInput.getHorizontal();
        //Debug.Log(move);
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        inground = PlayerInput.checkground();
        if ((PlayerInput.jumpclick() && inground))
        {
            Debug.Log(PlayerInput.jumpclick());
            Vector2 force = new Vector2(rb.velocity.x, jump);
            rb.AddForce(force);
        }
        Debug.DrawRay(position, Vector3.down * .4f, Color.black);

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            trapped = true;
        }

    }
    /*public bool checkground(Vector2 position)
    {

        return Physics2D.Raycast(position, Vector2.down, .4f, LayerMask.GetMask("Ground")); 
    }*/
    /*public void Jump(float jump)
    {
        Vector2 force = new Vector2(rb.velocity.x, jump);
        rb.AddForce(force);
    }*/
    public static bool isdead()
    {
        if (position.y < -2)
        {
            return true;
        }
        else return false;
    }
}
