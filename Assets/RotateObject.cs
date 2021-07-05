using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    private Transform transformComponent;

    // Start is called before the first frame update
    void Start()
    {
        transformComponent = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transformComponent.Rotate(0.0f, 0.1f, 0.0f);
    }
}
