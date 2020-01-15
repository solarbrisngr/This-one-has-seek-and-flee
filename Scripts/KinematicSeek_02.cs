using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek_02 : MonoBehaviour {

public class Static: MonoBehaviour
{
    public Vector3 position;
    public float orientation;
}

public class KinematicSteeringOutput : MonoBehaviour
{
    public Vector3 velocity;
    public float rotation;
}

    public Transform character;
    public Transform target;

        
    public float maxSpeed;

    public Rigidbody result;

    public float newRot;

    public float newOrientation(float current, Vector3 velocity)
    {
        Vector3 zeroVector = new Vector3(0f, 0f, 0f);
        if (velocity != zeroVector)
        {
            return Mathf.Atan2(-velocity.x, velocity.z);
        }
        else
        {
            return current;
        }
    }

    public Rigidbody getSteering()
    {

    result.velocity = target.position - character.position;
    result.velocity.Normalize();
    result.velocity *= maxSpeed;
    newRot = newOrientation(target.rotation.z, result.velocity);

    //character.orientation = newOrientation(character.orientation, result.velocity);
    target.rotation = Quaternion.Euler(0, newRot, 0);

    Quaternion zeroQuat = new Quaternion(0f, 0f, 0f,1f);
    result.rotation = zeroQuat;
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        getSteering();
    }
}

