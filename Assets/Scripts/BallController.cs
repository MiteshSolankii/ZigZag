using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject particle;
  


    [SerializeField] private float speed = 0;
    private bool started;
    private bool gameOver;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.StartGame();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {

            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();

        }


        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirections();
        }

    }

    void SwitchDirections()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }

        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }


    }

    void OnTriggerEnter(Collider col)
    { /*
        if (col.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity);

            

           GameObject.Find("Diamond").GetComponent<Animator>().SetTrigger("hit");
            ScoreManager.instance.score += 5;
            Destroy(col.gameObject, 0.8f);
            Destroy(part, 1f);

            
        }*/

        if (col.gameObject.tag == "end")
        {
            UIManager.instance.Gamewin();
            gameOver = true;
            print("game ended");
            
        }

    }

    
}