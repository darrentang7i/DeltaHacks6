using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishMovement : MonoBehaviour
{
    public float speed = 0.1f;
    float rotationSpeed = 4.0f;
    Vector3 averageHeading;
    Vector3 averagePosition;
    float neighbourDistance = 3.0f;

    bool turning = false; //turn in tank

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(4, 7);
        transform.Rotate(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    { 
        if(Vector3.Distance(transform.position, Vector3.zero) >= fishManager.tankSize)
        {
            turning = true;
        }
        else
        {
            turning = false;
        }

        if (turning)
        {
            Vector3 direction = Vector3.zero - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

            speed = Random.Range(0.5f, 1);
        }
        else
        {
            if(Random.Range(0,5) < 1)
            {
                ApplyRules();
            }
        }
        transform.Translate(0, 0, Time.deltaTime * speed);
 
        
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = fishManager.allFish;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero; //avoid hittin neighbours
        float gSpeed = 1;

        Vector3 goalPos = fishManager.goalPos; //general global one

        float dist;

        int groupSize = 0; //who is in the neighbour group
        foreach (GameObject go in gos)
        {
            if (go != this.gameObject)
            {
                dist = Vector3.Distance(go.transform.position, this.transform.position);
                if (dist <= neighbourDistance)
                {
                    vcenter += go.transform.position;
                    groupSize++;

                    if(dist < 1.0f) //if it is a small group
                    {
                        vavoid = vavoid+ (this.transform.position - go.transform.position);

                    }
                    FishMovement anotherFlock = go.GetComponent<FishMovement>();
                    gSpeed += anotherFlock.speed;
                }
            }
        }
        if(groupSize > 0)
        {
            vcenter = vcenter / groupSize + (goalPos - this.transform.position);
            speed = gSpeed / groupSize;

            Vector3 direction = (vcenter + vavoid) - transform.position;
            if (direction != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction),
                   rotationSpeed * Time.deltaTime);
        }
    }
}
