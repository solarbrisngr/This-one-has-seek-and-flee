using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicSeek_02 : MonoBehaviour {
    public GameObject character;
    public Transform target;

    public float maxSpeed;

    public Rigidbody result;

    public float tempRot;
    public float newRot;

    public bool flee = false;

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
        if (flee)
        {
            result.velocity = character.transform.position - target.position;

        }
        else
        {
            result.velocity = target.position - character.transform.position;

        }
        result.velocity.Normalize();
        result.velocity *= maxSpeed;
        tempRot = newOrientation(target.rotation.z, result.velocity);
        newRot = Mathf.Rad2Deg * tempRot;

        //character.orientation = newOrientation(character.orientation, result.velocity);
        target.rotation = Quaternion.Euler(0, newRot, 0);

        Quaternion zeroQuat = new Quaternion(0f, 0f, 0f, 1f);
        result.rotation = zeroQuat;
        return result;
    }
    private void Start()
    {
        character = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        getSteering();
    }
}

