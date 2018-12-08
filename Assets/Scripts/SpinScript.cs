using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour {

    public float Speed = 30;

    void Update()
    {
        transform.Rotate(new Vector3(0, Speed, 0) * Time.deltaTime);
    }
}
