using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleManage : MonoBehaviour
{
    public static TurtleManage instance;

    public float turtle_speed;

    public void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("TurtleObstacle"))
        {
            SharkMoving.instance.isMeetTurtle = true;
            SharkMoving.instance.nextIdx = 0;
            turtle_speed += 1.5f;
        }
    }
}
