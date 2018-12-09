using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatScript : MonoBehaviour {

    private Transform tr;
    private Vector3 StartingPos;
    private Vector3 MinY = new Vector3 (0,-0.05f,0);
    private Vector3 MaxY = new Vector3 (0,0.05f,0);
    private bool movingDown = true;

	// Use this for initialization
	void Start ()
    {
        tr = this.gameObject.GetComponent<Transform>();
        StartingPos = tr.position;
        MinY += StartingPos;
        MaxY += StartingPos;
        StartCoroutine(floatAnimation());
	}

    IEnumerator floatAnimation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (movingDown)
            {
                tr.position = Vector3.MoveTowards(tr.position, MinY, 0.01f);
                if (tr.position.y <= MinY.y)
                    movingDown = false;
            }
            else
            {
                tr.position = Vector3.MoveTowards(tr.position, MaxY, 0.01f);
                if (tr.position.y >= MaxY.y)
                    movingDown = true;
            }
        }
    }
}
