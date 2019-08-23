using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MagIx { 

public class fo : MonoBehaviour
{

    JatekMenu ja;
        Alaptamadas alaptamad;

    // Start is called before the first frame update
    void Start()
    {
            ja = new JatekMenu();
            alaptamad = new Alaptamadas();
            //Debug.Log("fo valami");
           // Debug.Log(ja.getJatekszunet()+"tamadas fo");

    }

    // Update is called once per frame
    void Update()
    {
            //alaptamad.tamad(ja.getJatekszunet());
    }
}
}