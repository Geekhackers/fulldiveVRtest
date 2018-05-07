using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    private float Rotate = 0f;

	void Start ()
    {
        int k = Random.Range(2, 7);
        for (int i = 1; i <= k; i++)
        {
            Instantiate(Resources.Load("Point"), new Vector3(0,0,0), Quaternion.Euler(0, Rotate, 0));
            Rotate += 360 / 7;
        }
    }
	
}
