using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChanger : MonoBehaviour
{
    public SpeedWhenTouched swt;
    private PathCreation.Examples.PathFollower pf;

    private void Awake()
    {
        pf = GetComponent<PathCreation.Examples.PathFollower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("EPA");
        swt = other.GetComponent<SpeedWhenTouched>();
        pf.speed = swt.speed;
    }
}
