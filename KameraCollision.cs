using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraCollision : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 karakter;
    public Vector3 karaktertavols;
    public float tavolsag;

    // Use this for initialization
    void Awake()
    {
        karakter = transform.localPosition.normalized;
        tavolsag = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 desiredCameraPos = transform.parent.TransformPoint(karakter * maxDistance);
        RaycastHit ut;

        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out ut))
        {
            tavolsag = Mathf.Clamp((ut.distance * 0.87f), minDistance, maxDistance);

        }
        else
        {
            tavolsag = maxDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, karakter * tavolsag, Time.deltaTime * smooth);
    }
}
