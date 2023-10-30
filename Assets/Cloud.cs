using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        transform.localPosition += Vector3.right * Speed * Time.deltaTime;
    }
}
