using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HandAnimationController : MonoBehaviour
{


    public InputDeviceCharacteristics ControllerType;

    public InputDevice thisController;
    private bool isControllerDetected;

    private Animator animatorController;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        animatorController = GetComponent<Animator>();
    }

    private void Initialize()
    {
        List<InputDevice> controllerDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ControllerType, controllerDevices);

        if (controllerDevices.Count != 0)
        {
            thisController = controllerDevices[0];
            isControllerDetected = true;
        }
        else
        {
            Debug.Log("List is empty");
        }

        //Debug.Log(thisController.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isControllerDetected)
        {
            Initialize();
        }
        else
        {
            if (thisController.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
            {
                Debug.Log("Trigger press");
                animatorController.SetFloat("Trigger", triggerValue);
                //Access the animator component - control a value - trigger animation
            }

            if (thisController.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.1f)
            {
                Debug.Log("Grip press");
                animatorController.SetFloat("Grip", gripValue);
                //Access the animator component - control a value - grip animation
            }
        }
    }
}
