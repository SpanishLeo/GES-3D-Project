using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateLookedAtObjects : MonoBehaviour
{
    //this script must be attached to the FPS camera

    [SerializeField]
    private float maxDistanceToCheckForObjects = 4.0f;

    [SerializeField]
    private Text lookedAtObjectText;

    private IActivatable lookedAtObject;

    private void Update()
    {
        UpdateLookedAtObject();
        UpdateLookedAtObkectText();
        HandleInput();
    }

    private void UpdateLookedAtObkectText()
    {
        if (lookedAtObject == null)
        {
            lookedAtObjectText.text = string.Empty;
        }
        else
        {
            lookedAtObjectText.text = lookedAtObject.NameText;
        }
    }

    private void UpdateLookedAtObject()
    {
        Debug.DrawRay(transform.position, transform.forward * maxDistanceToCheckForObjects, Color.red);

        RaycastHit raycastHit;

        if (Physics.Raycast(transform.position, transform.forward,
            out raycastHit, maxDistanceToCheckForObjects))
        {
            Debug.Log(raycastHit.transform.name + " is being looked at");

            lookedAtObject = raycastHit.transform.GetComponent<IActivatable>();
        }
        else
        {
            lookedAtObject = null;
        }
    }

    private void HandleInput()
    {
        if (lookedAtObject != null && Input.GetButtonDown("Activate"))
        {
            Debug.Log("This is an IActivatable");

            lookedAtObject.DoActivate();
        }
    }
}
