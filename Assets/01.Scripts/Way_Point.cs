using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way_Point : MonoBehaviour
{
    public Transform[] points;
    //public float speed = 1.0f;
    public float damping = 3.0f;
    private int nextIdx = 1;
    private Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        GameObject wayPointGroup = GameObject.Find("WayPoint");
        if (wayPointGroup != null)
            points = wayPointGroup.GetComponentsInChildren<Transform>();

        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWayPoint();
    }

    void MoveWayPoint()
    {
        Vector3 direction = points[nextIdx].position - tr.position;
        Quaternion rot = Quaternion.LookRotation(direction);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
        tr.Translate(Vector3.forward * Time.deltaTime * TurtleManage.instance.turtle_speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        nextIdx++;
    }

}
