using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMoving : MonoBehaviour
{
    public static SharkMoving instance;
    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public Transform[] points;
    public float speed = 1.0f;
    public float damping = 3.0f;
    public int nextIdx = 1;
    private Transform tr;

    public bool isMeetTurtle = false;
    bool isMeetObstacle = false;

    [SerializeField]
    Transform[] after_meet_turtle_transform = new Transform[4];

    // Start is called before the first frame update
    void Start()
    {
        GameObject wayPointGroup = GameObject.Find("WayShark");
        if (wayPointGroup != null)
        {
            points = wayPointGroup.GetComponentsInChildren<Transform>();
        }

        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMeetTurtle)
            MoveWayPoint();
        else if (isMeetObstacle)
        {

        }
        else if (isMeetTurtle)
            MoveWayToTurtle();
    }

    void MoveWayPoint()
    {
        Vector3 direction = points[nextIdx].position - tr.position;
        Quaternion rot = Quaternion.LookRotation(direction);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
        tr.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void MoveWayToTurtle()
    {
        Vector3 direction = after_meet_turtle_transform[nextIdx].position - tr.position;
        Quaternion rot = Quaternion.LookRotation(direction);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
        tr.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;

        if (other.tag.Equals("SharkObstacle"))
        {

        }
    }
}
