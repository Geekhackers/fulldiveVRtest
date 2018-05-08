using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    private float Rotate = 0f;
    public GameObject PanelVR;
    public static int k;

    void Start()
    {
        for (int i = 1; i <= k; i++)
        {
            Instantiate(PanelVR, new Vector3(0, 0, 0), Quaternion.Euler(0, Rotate, 0));
            Rotate += 360 / 7;
        }
    }
}