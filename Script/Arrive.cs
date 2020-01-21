using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{
    public GameObject character;
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
        if (Vector3.Distance(target.position, character.transform.position) >= 25f)
        {
            result.velocity = target.position - character.transform.position;
            result.velocity.Normalize();
            result.velocity *= maxSpeed;
            newRot = newOrientation(target.rotation.z, result.velocity);
        }
        else
        {
            result.velocity = Vector3.zero;
        }
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

