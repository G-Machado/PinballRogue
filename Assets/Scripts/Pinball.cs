using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{

    private Rigidbody thisRB;
    [SerializeField] private float damageMultiplier = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObj = collision.gameObject;


        if (otherObj.CompareTag("Destructable"))
        {
            DestructableObject destructableObj = otherObj.GetComponent<DestructableObject>();

            destructableObj.TakeDamage(thisRB, damageMultiplier);

        }
        else if (otherObj.CompareTag("Bumper"))
        {

            BumpOffBumper(otherObj);
        }
    }


    private void BumpOffBumper(GameObject bumper)
    {
        BumperController bumperController = bumper.GetComponent<BumperController>();
        thisRB.velocity += thisRB.velocity.normalized * bumperController.GetBumpForce();
    }

    // Start is called before the first frame update
    void Start()
    {
        thisRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
