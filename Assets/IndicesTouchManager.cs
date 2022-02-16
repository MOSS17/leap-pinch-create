using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicesTouchManager : MonoBehaviour
{
    [SerializeField]
    float PinchDistance;
    [SerializeField]
    float PalmDistance;

    [SerializeField]
    Transform lIndex;

    [SerializeField]
    Transform lThumb;
    
    [SerializeField]
    Transform rIndex;

    [SerializeField]
    Transform rThumb;
    [SerializeField]
    Transform rPalm;

    [SerializeField]
    Transform lPalm;

    bool PinchReady = false;

    bool creandoCubo = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float handsDistance = (Vector3.Distance(lIndex.position,lThumb.position));

        if(Vector3.Distance(lIndex.position,rIndex.position) <= PalmDistance)
        {
            PinchReady = true;
            Debug.Log(Vector3.Distance(lIndex.position,rIndex.position));
        }

        if(PinchReady)
        {
            if (Vector3.Distance(lIndex.position,lThumb.position) <= PinchDistance 
            && Vector3.Distance(rIndex.position,rThumb.position) <= PinchDistance 
            && creandoCubo == false)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = 
                    new Vector3(
                        (lIndex.position.x + rIndex.position.x) / 2, 
                        (lIndex.position.y + rIndex.position.y) / 2, 
                        (lIndex.position.z + rIndex.position.z) / 2);
                cube.transform.localScale = new Vector3(
                    Vector3.Distance(lIndex.position,rIndex.position), 
                    Vector3.Distance(lIndex.position,rIndex.position), 
                    Vector3.Distance(lIndex.position,rIndex.position));
                creandoCubo = true;
            }
        }

        if(Vector3.Distance(lIndex.position,lThumb.position) >= PinchDistance || Vector3.Distance(rIndex.position,rThumb.position) >= PinchDistance)
        {
            creandoCubo = false;

        }
    }
}