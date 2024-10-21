using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{

    [SerializeField] private KeyCode inputKeyRight = KeyCode.RightArrow;
    [SerializeField] private KeyCode inputKeyLeft = KeyCode.LeftArrow; 

    [SerializeField] private float flipStrength = 1000f; // Strength of the flipper
    [SerializeField] private float returnStrength = 500f; // Strength to return the flipper
    [SerializeField] private float targetVelocity = -800;

    [SerializeField] private HingeJoint[] hingeJoints;

    private List<Hinge> hinges = new();



    private class Hinge {
        [SerializeField] public HingeJoint hinge;
        public JointMotor motor;

        // Constructor
        public Hinge(HingeJoint hinge, JointMotor motor)
        {
            this.hinge = hinge;
            this.motor = motor;
        }


    } 




    private void TriggerFlipper(Hinge targetHinge)
    {




        targetHinge.motor.force = flipStrength; // Set the flipping strength
        targetHinge.motor.targetVelocity = targetVelocity; // Speed to move the flipper up
        targetHinge.motor.freeSpin = false; // Prevent free spin
        targetHinge.hinge.motor = targetHinge.motor;
        targetHinge.hinge.useMotor = true;
    }

    private void ReturnFlipper(Hinge targetHinge)
    {


        if (targetHinge.hinge.angle < targetHinge.hinge.limits.max) {
            targetHinge.motor.force = returnStrength;
            targetHinge.motor.targetVelocity = 800f; // Speed to return the flipper
            targetHinge.motor.freeSpin = false; // Prevent free spin
            targetHinge.hinge.motor = targetHinge.motor;
            targetHinge.hinge.useMotor = true;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        foreach (HingeJoint hjoints in hingeJoints)
        {
            Hinge newHinge = new Hinge(hjoints, hjoints.motor);
            hinges.Add(newHinge);
        }


    }

    // Update is called once per frame
    void Update()
    {
        // input right flipper
        if (Input.GetKey(inputKeyRight))
            TriggerFlipper(hinges[1]);
        else
            ReturnFlipper(hinges[1]);


        // input left flipper
        if (Input.GetKey(inputKeyLeft))
            TriggerFlipper(hinges[0]);
        else
            ReturnFlipper(hinges[0]);
    }
}
