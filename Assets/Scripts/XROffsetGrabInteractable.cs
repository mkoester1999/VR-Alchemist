﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{

    private Vector3 initialAttachLocalPos;
    private Quaternion initialAttachLocalRot;

    // Start is called before the first frame update
    void Start()
    {
        //create offset attach point
        if(!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }

        initialAttachLocalPos = attachTransform.localPosition;
        initialAttachLocalRot = attachTransform.transform.localRotation;

    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if(interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initialAttachLocalPos;
            attachTransform.localRotation = initialAttachLocalRot;
        }

        base.OnSelectEnter(interactor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

