using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MagIx {
    public class eloreszint : MonoBehaviour
    {
        public GameObject fal;
        public GameObject fal2;
        //        public GameObject falajto;
        // public GameObject ures;
        public GameObject padlo;

        private GameObject[] falaktomb;

        public float falhossz = 10f;
        public float falmag = 2.5F;

        public int xPalya = 50;
        public int zPalya = 50;




        private Vector3 hely;
        //private Vector3[,] szobatomb;
        // private Szobak[] faltomb;
        private int hossz;
        private float random;
        private Szobak szobale;

        //berend
        int randomellen;
        int randomtultolt;
        int randomcelhely;
        int randomcelhelymax;
        public GameObject[] ellen;
        public GameObject[] tultolt;
        public GameObject cel;

        bool celgeneralt = false;
        // Start is called before the first frame update
        void Start()



        {
            randomcelhelymax = xPalya;
            //falak = GameObject.FindGameObjectsWithTag("Fal");

            falaktomb = listarendezo("Falak");
            ellen = listarendezo("ellenseg");
            tultolt = listarendezo("tultolt");


            for (int i = 0; i < falaktomb.Length; i++)
            {
                //Debug.Log(falaktomb[i] + falaktomb[i].name + "ez egy fal");
            }

            szobale = new Szobak();


            xPalya--;
            zPalya--;
            int mer = ((xPalya + 1) / 10);

            //szobatomb = new Vector3[mer, mer];
            // faltomb= new Szobak[mer];
            hossz = Mathf.RoundToInt(falhossz);



            Alapgen();



            SzobaGen();

            tartalomgen();
        }




        void Alapgen()
        {








            // 2 ciklus palya generalas szele


            //alap x-re párhuzamos

            for (int i = 0; i <= xPalya; i = i + hossz)
            {
                // Instantiate(fal, new Vector3((falhossz / 2) + i, falmag, (-hossz / 2) + 0), Quaternion.identity);
                for (int j = 0; j <= zPalya + 1; j = j + zPalya + 1)
                {

                    Instantiate(fal, new Vector3((falhossz / 2) + i, falmag, (-hossz / 2) + j), Quaternion.identity);
                }
            }
            //alap z - ra párhuzamos

            for (int i = 0; i <= zPalya; i = i + hossz)
            {
                //Instantiate(fal2, new Vector3( xPalya+(falhossz / 2) , falmag, 0 + i), Quaternion.Euler(0f, 90f, 0f));

                for (int j = 0; j <= xPalya + 1; j = j + xPalya + 1)
                {
                    Instantiate(fal2, new Vector3(0 + j, falmag, 0 + i), Quaternion.Euler(0f, 90f, 0f));
                }
            }


            //padlo gener


            for (int i = 0; i <= xPalya; i = i + hossz)
            {

                for (int j = 0; j <= zPalya; j = j + hossz)
                {
                    Instantiate(padlo, new Vector3((falhossz / 2) + i, 0, 0 + j), Quaternion.identity);
                }

            }




        }
        //szoba és bele general
        void SzobaGen()
        {
            //int[] balfelsofal = new int[(zPalya + 1) / 10];
            //for (int i = 0; i < balfelsofal.Length; i++)
            //{
            //    balfelsofal[i] = Random.Range(0, falaktomb.Length);
            //}
            //int[] zfal = new int[(zPalya + 1) / 10];
            //for (int i = 0; i < zfal.Length; i++)
            //{
            //    zfal[i] = Random.Range(0, falaktomb.Length);
            //}

            int[,] xfal = new int[(xPalya + 1) / 10+1, (zPalya + 1) / 10+1];
            int[,] zfal = new int[(xPalya + 1) / 10+1, (zPalya + 1) / 10+1];
            //for (int i = 0; i < (xPalya + 1) / 10 ; i++)
            //{
            //    xfal[0, i] = 0;
            //    zfal[0, i] = 0;
            //}

            //int tombindx = 0;
            //int tombindz = 0;


            int randomSzam = 0;
            int randomSzam2 =0;
            int ix = 0;

            for (int i = 0; i <= xPalya; i = i + hossz)
            {
             
               
                int jx = 0;
                int vanfal = 0;
                for (int j = 0; j < zPalya - hossz; j = j + hossz)
                {//vizsgálja hogy az előtte lévő falak ajtók -e ha nem akkor ajtó lesz
                   if(vanfal<(xPalya + 1) / 10 - 1)
                    {
                        randomSzam = Random.Range(falaktomb.Length/2, falaktomb.Length);
                    }
                    randomSzam = Random.Range(0, falaktomb.Length );
                    Instantiate(falaktomb[randomSzam], new Vector3(falhossz + j, falmag, 0 + i), Quaternion.Euler(0f, 90f, 0f));
              
                    xfal[ix, jx] = randomSzam;

                    if(randomSzam< falaktomb.Length / 2)
                    {
                        vanfal++;
                    }
                   // Debug.Log(xfal[ix, jx]+"random");
                    jx++;
                }
                ix++;
            }

           // Debug.Log("zkezd");
            int iz = 0;
            for (int i = 0; i <= xPalya; i = i + hossz)
            {
                //Debug.Log("zkezdels");
                int jz = 0;
                // ha a z uj alatta bx  felette bx vagy alatta bx mellette bz vagy felette bx mellette bz falv akkor ez ajtó vagy ures
                for (int j = 0; j < zPalya - hossz; j = j + hossz)
                {
                    //  Debug.Log("zkezdelsj");
                    //if (0<jz&& 0<iz) {
                        int ajto = 0;
                    //vizsgálja hogy a szobához tartozó falak ajtók-e ha nem a 4. biztos
                    if (xfal[iz, jz] >= (falaktomb.Length / 2))
            {
                            ajto++;
                        }
                        if (0<jz && xfal[iz, jz-1] >= (falaktomb.Length / 2))
                        {
                            ajto++;
                        }
                        if (0 < iz && zfal[iz-1, jz] >= (falaktomb.Length / 2))
                        {
                            ajto++;
                        }
                    if (ajto < 3)
                    {
                        randomSzam2 = Random.Range(falaktomb.Length / 2, falaktomb.Length);
                    }
                    else { randomSzam2 = Random.Range(0, falaktomb.Length); }
                   // falaktomb.Length / 2



                            //(xfal[iz, jz]
                            //if ((xfal[iz, jz] <= (falaktomb.Length / 2) && zfal[iz, jz - 1] <= (falaktomb.Length / 2)) || (xfal[iz + 1, jz] <= (falaktomb.Length / 2) && zfal[iz, jz - 1] <= (falaktomb.Length / 2)) || xfal[iz, jz] <= (falaktomb.Length / 2) && xfal[iz + 1, jz] <= (falaktomb.Length / 2))
                            //{
                            //    //Debug.Log(randomSzam2 + "zkezdelsaj");
                            //    randomSzam2 = Random.Range(falaktomb.Length / 2, falaktomb.Length);
                            //    //különben ha az alattaz és az egyel ballra alatta ajtó vagy az alatta xés az egyel ballra ajtó akkor lehet fal
                            //}
                            //else
                            //{
                            //    //Debug.Log(randomSzam2+"zkezdelsbarmi");
                            //    randomSzam2 = Random.Range(0, falaktomb.Length);
                            //    //Random.Range(0, falaktomb.Length);
                            //}
                            // }
                            //  Debug.Log("gener");


                    Instantiate(falaktomb[randomSzam2], new Vector3((falhossz / 2) + i, falmag, (hossz / 2) + j), Quaternion.identity);
                    zfal[iz, jz] = randomSzam2;
                }
            }
          

            //    //ha az xalso fal és az also is ne legyen nyílás
            //    if (balfelsofal[tombind] <= (falaktomb.Length / 2) && randomSzam2 <= (falaktomb.Length / 2))
            //    {
            //        while (!(randomSzam > (falaktomb.Length / 2)) || !(randomSzam2 > (falaktomb.Length / 2)))
            //        {
            //            randomSzam = Random.Range(0, falaktomb.Length-1);
            //            randomSzam2 = Random.Range(0, falaktomb.Length-1);
            //        }
            //        //ha a xfenti ajtó ne legyen a mellette üres
            //    }
            //    else if (balfelsofal[tombind] - 1 == 2)
            //    {
            //        randomSzam = Random.Range(0, falaktomb.Length - 1);
            //    }
            //    else { 
            //    randomSzam = Random.Range(0, falaktomb.Length);
            //    randomSzam2 = Random.Range(0, falaktomb.Length);
            //       // Debug.Log(randomSzam + "elsoszam" + randomSzam2 + "masdikszam");
            //}



            //    Instantiate(falaktomb[randomSzam], new Vector3((falhossz / 2) + i, falmag, (hossz / 2) + j), Quaternion.identity);



            //    Instantiate(falaktomb[randomSzam2], new Vector3(falhossz  + j, falmag, 0 + i), Quaternion.Euler(0f, 90f, 0f));

            //    balfelsofal[tombindx] = randomSzam;
            //    tombindx++;
        

    



           



        }
        void Update()
        {

        }

        void tartalomgen()
        {
           
            for (int i = hossz; i <= xPalya; i = i + hossz)
            {
                for (int j = 0; j <= zPalya; j = j + hossz)
                {

                    //max akkora amekkora a pálya mindig csökken így növeli az esélyét a generálásra
                    randomcelhely = Random.Range(0, randomcelhelymax/10);
                    if (randomcelhely == 1 && !celgeneralt)
                    {
                        Vector3 celhely = new Vector3(Random.Range((falhossz / 2) + i - 3, (falhossz / 2) + i - 1), 2f, Random.Range((hossz / 2) + j - 3, (hossz / 2) + j - 1));
                        Instantiate(cel, celhely, Quaternion.identity);
                        celgeneralt = true;
                    }
                    else
                    {
                        randomcelhelymax -= 10;
                    }

                    // int randoellen = Random.Range(0, ellen.Length-1);
                    // int randomtultolt = Random.Range(0, tultolt.Length-1);

                    int randomellenszam = Random.Range(0, 3);

                    for (int a = 0; a < randomellenszam; a++)
                    {
                        randomellen = Random.Range(0, ellen.Length );
                        Vector3 positionellen = new Vector3(Random.Range((falhossz / 2) + i - 6, (falhossz / 2) + i -2), 0f, Random.Range((hossz / 2) + j - 6, (hossz / 2) + j -2));
                        Instantiate(ellen[randomellen], positionellen, Quaternion.identity);
                    }


                    for (int a = 0; a < randomellenszam; a++)
                    {
                        randomtultolt = Random.Range(0, ellen.Length - 1);
                        Vector3 positionboost = new Vector3(Random.Range((falhossz / 2) + i - 6, (falhossz / 2) + i-2 ), (falhossz / 5), Random.Range((hossz / 2) + j - 6, (hossz / 2) + j -2));
                        Instantiate(tultolt[randomtultolt], positionboost, Quaternion.identity);

                    }
                }
            }
        }

       
       

            GameObject[] listarendezo(string tag)
        {
            GameObject[] tomb = GameObject.FindGameObjectsWithTag(tag);
            System.Array.Sort(tomb, nameosszehasonlit);
            return tomb;
        }


        int nameosszehasonlit(GameObject x, GameObject y)
        {
            return x.name.CompareTo(y.name);
        }
    }


}