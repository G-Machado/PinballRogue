using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimitArea : MonoBehaviour
{

    [SerializeField] private float maxSpeed = 6f;

    [SerializeField] private float minSpeed = 2f;

    private void OnTriggerEnter(Collider other)
    {

        GameObject ball = other.gameObject;

        if (ball.CompareTag("pinball"))
        {
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            if (ballRB.velocity.magnitude > maxSpeed)
                ballRB.velocity = ballRB.velocity.normalized * maxSpeed;
            
        }
    }

    private void OnTriggerStay(Collider other)
    {

        GameObject ball = other.gameObject;

        if (ball.CompareTag("pinball"))
        {
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            if (ballRB.velocity.magnitude > minSpeed)
                ballRB.velocity *= .98f;
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
