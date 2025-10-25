using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject core1;
    public GameObject core2;
    public GameObject targetObj;
    public void Update()
    {

        if (core1 == null && core2 == null)
        {
            targetObj.SetActive(true);
        }
    }
}
