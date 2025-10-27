using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    public GameObject core1;
    public GameObject core2;
    public GameObject Spawner1;
    public GameObject Spawner2;
    public GameObject Spawner3;
    public GameObject Spawner4;
    public GameObject Spawner5;
    public GameObject targetObj;
    public void Update()
    {

        if (core1 == null && core2 == null)
        {
            targetObj.SetActive(true);
            Spawner1.SetActive(false);
            Spawner2.SetActive(false);
            Spawner3.SetActive(false);
            Spawner4.SetActive(false);
            Spawner5.SetActive(false);
        }
    }
}
