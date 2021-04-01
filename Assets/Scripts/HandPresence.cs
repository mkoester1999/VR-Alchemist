using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    public bool showHands = true;
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;

    // Start is called before the first frame update

    private GameObject spawnedHandModel;
    private Animator handAnimator;
    void Start()
    {
        tryInitialize();

    }

    void tryInitialize()
    {
        //gets all input devices for headset.
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        if (devices.Count > 0)
            targetDevice = devices[0];


        spawnedHandModel = Instantiate(handModelPrefab, transform);
        spawnedHandModel.SetActive(true);
        handAnimator = spawnedHandModel.GetComponent<Animator>();
    }

    void UpdateHandAnimation()
    {   

        //code to handle animations. Grabs value from trigger and grip.
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
            handAnimator.SetFloat("Trigger", triggerValue);
        
        else
            handAnimator.SetFloat("Trigger", 0);

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            handAnimator.SetFloat("Grip", gripValue);

        else
            handAnimator.SetFloat("Grip", 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (!targetDevice.isValid)
            tryInitialize();
        else
        {
            if (showHands)
            {
                spawnedHandModel.SetActive(true);
                UpdateHandAnimation();
            }
            else
                spawnedHandModel.SetActive(false);
        }
       
    }
}
