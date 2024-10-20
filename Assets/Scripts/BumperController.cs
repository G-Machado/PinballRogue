using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{


    [SerializeField] private float bumpForceAmmount = 7;



    public float GetBumpForce() {
        return bumpForceAmmount;
    }

}
