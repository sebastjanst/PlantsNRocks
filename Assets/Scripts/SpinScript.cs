using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour {

    //this script just adds a little spin animation to objects. used on the intro screen

    public float Speed = 30;

    void Update()
    {
        transform.Rotate(new Vector3(0, Speed, 0) * Time.deltaTime);
    }
}
