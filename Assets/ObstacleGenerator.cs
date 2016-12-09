using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour
{
    public float startDistance = 10;
    public float yDistance = 100;
    public float minSpread = 5;
    public float maxSpread = 10;

    public Transform playerTransform;
    public Transform obstaclePrefab;

    float ySpread;
    float lastYPos;

    void Start()
    {
        ySpread = Random.Range(minSpread, maxSpread);
        lastYPos = playerTransform.forward.z + (startDistance - ySpread - yDistance);
    }

    void Update()
    {
        SOGen();   
    }

    void SOGen()
    {
        if (playerTransform.position.z - lastYPos >= ySpread)
        {
            double[] tab = new double[] { -2.5, 0.5, 3.5 };
            float lanePos = Random.Range(0, 3);
            lanePos = (float)tab[(int)lanePos];
            Vector3 position = new Vector3(lanePos, 1, lastYPos + ySpread + yDistance);
            if(PosCheck(position, 1f)) { Instantiate(obstaclePrefab, position, Quaternion.identity); }
            

            lastYPos += ySpread;
            ySpread = Random.Range(minSpread, maxSpread);
        }

    }


    bool PosCheck(Vector3 position, float radius)
    {
        if (Physics.CheckSphere(position, 1f))
        {
            return false;
        }
        else
        {
            
            return true;
        }
    }
}