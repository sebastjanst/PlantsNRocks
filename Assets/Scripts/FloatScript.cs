using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour {

    //this script just makes gameobjects float up and down a bit

    private Transform tr;
    private Vector3 StartingPos;//need to know the starting position to set where the max and min are in relation to the gameobject
    private Vector3 MinY = new Vector3 (0,-0.05f,0);//lowest vertical position to float to
    private Vector3 MaxY = new Vector3 (0,0.05f,0);//highest vertical position to float to
    private bool movingDown = true;//to keep track of the direction the object is floating in

	// Use this for initialization
	void Start ()
    {
        tr = this.gameObject.GetComponent<Transform>();
        StartingPos = tr.position;

        //adjusts min and max points based on the starting position
        MinY += StartingPos;
        MaxY += StartingPos;
        StartCoroutine(floatAnimation());
	}

    IEnumerator floatAnimation()//the animation
    {
        while (true)//the animation loops infinitely
        {
            yield return new WaitForSeconds(0.07f);//how long it takes between movements

            if (movingDown)//check the direction of movement
            {
                tr.position = Vector3.MoveTowards(tr.position, MinY, 0.02f);
                if (tr.position.y <= MinY.y)//once the min position is reached we use the movingDown bool to start moving in the other direction
                    movingDown = false;
            }
            else
            {
                tr.position = Vector3.MoveTowards(tr.position, MaxY, 0.02f);
                if (tr.position.y >= MaxY.y)
                    movingDown = true;
            }
        }
    }
}
