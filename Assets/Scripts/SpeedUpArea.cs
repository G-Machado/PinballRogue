using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpArea : MonoBehaviour
{


    [SerializeField] private float maxSpeed = 24f;

    [SerializeField] private float minSpeed = 30f;

    private void OnTriggerEnter(Collider other)
    {

        GameObject ball = other.gameObject;

        if (ball.CompareTag("pinball"))
        {
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            if (ballRB.velocity.magnitude < minSpeed)
                ballRB.velocity = ballRB.velocity.normalized * minSpeed;
            
        }
    }


    private void OnTriggerStay(Collider other)
    {

        GameObject ball = other.gameObject;

        if (ball.CompareTag("pinball"))
        {
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            if (ballRB.velocity.magnitude < maxSpeed)
                ballRB.velocity *= 1.07f;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
