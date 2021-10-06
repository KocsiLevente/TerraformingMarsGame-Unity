using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHexagonMap : MonoBehaviour
{
    public GameObject Hexagon;
    public int HexagonQuantity = 0;
    public int RingQuantity = 0;
    public float Xpos, Ypos, Zpos, XDeltaAngle, YDeltaAngle;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateMap());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateMap()
    {
        for (int i = 0; i < 5; i++)
        {
            RingQuantity++;

            //Set angle for rotation and starting position to the surface of the planet.
            switch (i+1)
            {
                case 1:
                    Xpos = 0.0f;
                    Ypos = 0.0f;
                    Zpos = 499.9f;
                    XDeltaAngle = 0.0f;
                    YDeltaAngle = 0.0f;
                    break;
                case 2:
                    Xpos = -44.7f;
                    Ypos = 69.6f;
                    Zpos = 498.2f;
                    XDeltaAngle = 7.0f;
                    YDeltaAngle = 5.0f;
                    break;
                case 3:
                    Xpos = -44.7f;
                    Ypos = -70.4f;
                    Zpos = 498.2f;
                    XDeltaAngle = -7.0f;
                    YDeltaAngle = 5.0f;
                    break;
                case 4:
                    Xpos = 0.0f;
                    Ypos = 137.5f;
                    Zpos = 509.3f;
                    XDeltaAngle = 14.0f;
                    YDeltaAngle = 0.0f;
                    break;
                case 5:
                    Xpos = 0.0f;
                    Ypos = -139.5f;
                    Zpos = 509.3f;
                    XDeltaAngle = -14.0f;
                    YDeltaAngle = 0.0f;
                    break;
                default:
                    Xpos = 0.0f;
                    Ypos = 0.0f;
                    Zpos = 499.9f;
                    XDeltaAngle = 0.0f;
                    YDeltaAngle = 0.0f;
                    break;
            }

            //Start to generate a Ring.
            StartCoroutine(GenerateRing());
        }
        yield return new WaitForSeconds(0.01f);
    }

    IEnumerator GenerateRing()
    {
        for (int i = 0; i < 36; i++)
        {
            HexagonQuantity++;

            //Generate a Hexagon.
            GameObject Hex1 = Instantiate(Hexagon, new Vector3(Xpos, Ypos, Zpos), Quaternion.identity);
            Hex1.transform.localScale = new Vector3(90.0f, 0.9f, 90.0f);
            Hex1.transform.Rotate(90.0f + XDeltaAngle, 0.0f + YDeltaAngle, 0.0f, Space.World);

            //Changing angle and position for the next object.
            /*Extra information for calculations.
             *Radius of planet, r = 500.0f. Planet is at (0.0f, 0.0f, 1000.0f) position.
             *K(u,v) = K(0,1000). (x-u)^2 + (y-v)^2 = r^2 -> x^2 + (y-1000)^2 = 250000 -> x^2 + y^2 - 2000y + 1000000 = 250000 ->
             *x^2 + y^2 - 2000y = -750000
             */
            YDeltaAngle -= 10.0f;
        }
        yield return new WaitForSeconds(0.01f);
    }
}
