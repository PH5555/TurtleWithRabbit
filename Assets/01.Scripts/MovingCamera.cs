using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{

    public Camera camera1;
    public Camera camera2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.name == "point (1)") {
            camera1.gameObject.SetActive(false);
            camera2.gameObject.SetActive(true);
        }
        
    }
}
