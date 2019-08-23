using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialenz : MonoBehaviour
{
    public float helyY = 2;
    public Transform hely;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PozicioElet();
    }
    private void PozicioElet()
    {
        Vector3 jelenlegiPoz = transform.position;

        hely.position = new Vector3(jelenlegiPoz.x, jelenlegiPoz.y + helyY, jelenlegiPoz.z);

        hely.LookAt(Camera.main.transform);
    }
}
