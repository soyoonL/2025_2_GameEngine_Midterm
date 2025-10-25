using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemacineSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCam;
    public CinemachineFreeLook freeLook;
    public bool usingFreeLook = false;
    
    void Start()
    {
        VirtualCam.Priority = 10;
        freeLook.Priority = 0;
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            usingFreeLook = !usingFreeLook;
            if(usingFreeLook)
            {
                freeLook.Priority = 20;
                VirtualCam.Priority = 0;
            }
            else
            {
                VirtualCam.Priority = 20;
                freeLook.Priority = 0;
            }
        }
    }
}
