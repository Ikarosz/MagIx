using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MagIx { 
public class Szobak : MonoBehaviour
{

        GameObject a;
        private GameObject[] faltomb;
        public Szobak()
        {
            faltomb = new GameObject[4];

            for (int i = 0; i < faltomb.Length; i++)
            {
                faltomb[i] = a;
            }
        }


     
         public GameObject GetFal()
 {
            for (int i = 0; i < faltomb.Length-1; i++)
            {
                return faltomb[i];
            }
                
            
            return faltomb[faltomb.Length];
 }
}
}