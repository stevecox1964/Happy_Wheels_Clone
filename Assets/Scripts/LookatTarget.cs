using System;
using UnityEngine;



public class LookatTarget : MonoBehaviour
{

    public GameObject target;
    public float angleOffset = 90;
    public float triggerDistance = 5;
    private float lastAngle = 0;
    public float speed = 3;

    // Use this for initialization
    void Start()
    {
        //float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
        //transform.eulerAngles = new Vector3(0, angle, 0);
    }

    void Update()
    {
        float newAngle = 0;
        float currentDistance = Vector2.Distance(target.transform.position, transform.position);

        if (currentDistance <= triggerDistance)
        {
            Vector3 dir = target.transform.position - transform.position;

            newAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + angleOffset;

            float angle = Mathf.LerpAngle(lastAngle, newAngle, Time.time * speed);

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //transform.rotation = Quaternion.Lerp(from.rotation, to.rotation, Time.time * speed);
        }
        //else
        //{
        //    float angle = Mathf.LerpAngle(lastAngle, 0, Time.time * speed);
        //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //}

        lastAngle = newAngle;

    }


    
}

