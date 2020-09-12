using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaking : MonoBehaviour
{
    public GameObject shark;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {

        if(other.name == "point (4)") {
            this.GetComponent<CameraShake>().shakeOn = true;
            shark.SetActive(true);
        }
        
    }


    private void OnTriggerExit(Collider other) {
        this.GetComponent<CameraShake>().shakeOn = false;
    }
}
