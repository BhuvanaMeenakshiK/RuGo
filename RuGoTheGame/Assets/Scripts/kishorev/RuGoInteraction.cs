﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuGoInteraction : MonoBehaviour {
    /*
     * TASKS
     * ** RAY       - Input space to world space ray
     * ** CONFIRM   - An action button triggered on all input
     * ** BACK      - A button mapped for Back action / Reset action
     * ** SCROLL    - 
    */

    public static RuGoInteraction Instance = null;
    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private SteamVR_ControllerManager ControllerManager;
    private SteamVR_TrackedObject LeftTrackedObject;
    private SteamVR_TrackedObject RightTrackedObject;

    private SteamVR_Controller.Device LeftController
    {
        get
        {
            return SteamVR_Controller.Input((int)LeftTrackedObject.index);
        }
    }

    private SteamVR_Controller.Device RightController
    {
        get
        {
            return SteamVR_Controller.Input((int)RightTrackedObject.index);
        }
    }

    private void CacheControllers()
    {
        ControllerManager = GetComponent<SteamVR_ControllerManager>();
        LeftTrackedObject = ControllerManager.left.GetComponent<SteamVR_TrackedObject>();
        RightTrackedObject = ControllerManager.right.GetComponent<SteamVR_TrackedObject>();
    }

    void Awake()
    {
        MakeSingleton();
    }

    void Start ()
    {
        // We do it here because we want all the VR initializations to be done first
        CacheControllers();
	}

    private void EnableDebugging()
    {
        if (!DebugCapsule.gameObject.activeSelf)
        {
            DebugCapsule.gameObject.SetActive(true);
        }

        if (!DebugCylinder.gameObject.activeSelf)
        {
            DebugCylinder.gameObject.SetActive(true);
        }
    }

    private void DisableDebugging()
    {
        if (DebugCapsule.gameObject.activeSelf)
        {
            DebugCapsule.gameObject.SetActive(false);
        }

        if (DebugCylinder.gameObject.activeSelf)
        {
            DebugCylinder.gameObject.SetActive(false);
        }
    }
	
	void Update ()
    {
        if(DebugInputs)
        {
            EnableDebugging();

            Ray selectorRay = GetSelectorRay();
            Debug.DrawRay(selectorRay.origin, selectorRay.direction, Color.red, 0.0f, false);
            DebugCapsule.position = selectorRay.origin;
            DebugCapsule.rotation = Quaternion.LookRotation(selectorRay.direction, Vector3.up);

            if (GetIsConfirmPressed())
            {
                RaycastHit hit;
                if (Physics.Raycast(selectorRay, out hit))
                {
                    DebugCylinder.position = hit.point;
                }
            }
        }
        else
        {
            DisableDebugging();
        }
	}


    // ACTIONS
    public bool IsUserRightHanded = true;
    public bool DebugInputs = false;
    public Transform DebugCapsule;
    public Transform DebugCylinder;

    private bool IsSelectorControllerActive()
    {
        return (IsUserRightHanded && ControllerManager.right.activeSelf) || (!IsUserRightHanded && ControllerManager.left.activeSelf);
    }

    private Transform GetSelectorController()
    {
        if(IsUserRightHanded && ControllerManager.right.activeSelf)
        {
            return ControllerManager.right.transform;
        }
        else if(!IsUserRightHanded && ControllerManager.left.activeSelf)
        {
            return ControllerManager.left.transform;
        }

        return null;
    }

    public Ray GetSelectorRay()
    {
        Ray selectorRay = new Ray();

        if (IsSelectorControllerActive())
        {
            Transform selectorController = GetSelectorController();
            selectorRay.origin           = selectorController.localPosition;
            selectorRay.direction        = selectorController.forward;
        }
        else
        {
            selectorRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        return selectorRay;
    }

    public bool GetIsConfirmPressed()
    {
        if(IsSelectorControllerActive())
        {
            return ((IsUserRightHanded && RightController.GetHairTriggerDown()) || (!IsUserRightHanded && LeftController.GetHairTriggerDown()));
        }
        else
        {
            return Input.GetMouseButtonDown(0);
        }
    }
}
