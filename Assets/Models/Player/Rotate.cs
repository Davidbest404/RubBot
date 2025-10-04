using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour
{
    [SerializeField] public Camera camera;
    [SerializeField] public int Value;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate_cam();
    }

    void Rotate_cam()
    {

        float angle = camera.transform.rotation[1];
        Debug.Log(angle);
        if (angle < -0.4083161 && angle > -0.9183323)
        {
            Value = 1;
        }
        else if (angle <= 0.4083161 && angle >= -0.4083161)
        {
            Value = 2;
        }
        else if (angle < 0.9183323 && angle > 0.4083161)
        {
            Value = 3;
        }
        else if (angle >= 0.9183323 || angle <= -0.9183323)
        {
            Value = 4;
        }
    }
}
