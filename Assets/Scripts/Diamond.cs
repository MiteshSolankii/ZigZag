using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private Animator anim;
    BallController ballController;
    void Start()
    {
        anim = GetComponent<Animator>();
        ballController = FindObjectOfType<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            GameObject part = Instantiate(ballController.particle, other.gameObject.transform.position, Quaternion.identity);



            anim.SetTrigger("hit");
            ScoreManager.instance.score += 5;
            Destroy(gameObject, 0.8f);
            Destroy(part, 1f);
        }
    }
}
