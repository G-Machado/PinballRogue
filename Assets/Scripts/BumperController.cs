using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{


    [SerializeField] private float bumpForceAmmount = 7;



    public float GetBumpForce() {
        return bumpForceAmmount;
    }

    void OnCollisionEnter(Collision collision)
    {
        
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

    }
}
