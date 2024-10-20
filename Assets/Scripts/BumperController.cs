using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    [SerializeField] private float bumpForceAmmount = 7;
    [SerializeField] private Animator animator;

    public float GetBumpForce() {

        if(animator)
            animator.Play("Barrel_Collision");
        return bumpForceAmmount;
    }

}
