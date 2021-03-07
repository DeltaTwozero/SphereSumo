using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCameraSpinFocus : MonoBehaviour
{
    [SerializeField] Slider rotationSlider;

    [SerializeField] GameObject playerSphere;

    bool isRotating;
    float rotationSpeed;
    void Start()
    {
        if(playerSphere != null)
            {
                isRotating = true;
            }

    }
    private void Update()
    {
        if(rotationSlider != null)
            {
                rotationSpeed = rotationSlider.value;
            }
        else rotationSpeed = 2;
        
    }
    private void FixedUpdate()
    {
        if (isRotating)
        {
            this.transform.LookAt(playerSphere.transform.position);
            this.transform.Translate(Vector3.left * Time.deltaTime * rotationSpeed);
        }
    }
}
