using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour, IActivatable
{
    public void DoActivate()
    {
        Debug.Log(transform.name + " was activated");
    }

    private void Start()
    {
        DoActivate();
    }

}
