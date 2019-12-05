using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePlayer : MonoBehaviour
{
    private int call = 0;

    private float posY;
    private float posYREAL;
    private float posX;
    private float posXREAL;

    [SerializeField]
    private float speed = 0.5f;

    private Vector3 Target;

    void Update()
    {

        // Put in string.
        string s = "1,1,10,-3017,2081,3.13;1,2,8,-835,-561,2.38;1,3,11,-2448,-528,1.73;0,4,15,-2334,2729,0.69;1,5,4,-347,1133,1.14;1,6,5,-346,1983,1.62;3,7,1,11,-3440,0.40;1,8,25,-3084,108,1.61;0,9,6,-2776,1828,0.57;4,10,-1,5550,4400,0.00;0,11,9,-561,1867,1.69;3,12,2,-3490,3685,0.44;1,13,7,-2546,2408,3.58;0,14,7,-2707,2070,3.37;4,15,-1,5550,4400,0.00;3,16,0,-1825,891,1.49;1,17,22,-3185,2834,1.72;0,18,11,-993,-1008,1.47;0,19,1,-4864,238,0.15;0,20,5,-3477,561,0.45;0,21,23,-1766,1393,2.50;1,22,3,-1284,2702,2.00;0,23,3,-3340,2120,0.30;1,24,20,-1723,1617,2.99;-1,25,-1,-2693,2013,0.00;1,26,24,3321,549,0.44;0,27,4,-3129,-496,0.84;4,28,-1,5550,4400,0.00;0,29,18,-2737,2313,1.04";


        // Split the string (s) when ever you see a ; and put it into an array
        string[] substrings = s.Split(';');
     
        
        //make an 2d array with 6 spots to fill per array length (the + 1 is for not getting the array out of bounds when looping)
        string[,] my2d = new string[substrings.Length +1, 6];


        for (int i = 0; i < substrings.Length; i++)
        {
            //splits the string at " , "
            string[] values = substrings[i].Split(',');

            for (int j = 0; j < values.Length; j++)
            {
                //sets the little strings into the 6 containers from the array per array length
                my2d[i, j] = values[j];
            }
        }


        //makes the string into a float and gives its stats to the var at the end
        float.TryParse(my2d[call, 3], out float posYREAL);
        float.TryParse(my2d[call, 4], out float posXREAL);


        //makes the float smaller so its more equal too the ingame playing field
        if (posYREAL != 0)
        {
            posY = posYREAL / 105;
        }
        if (posXREAL != 0)
        {
            posX = posXREAL / 68;
        }
        

        //sets the target to move to
        Target = new Vector3(posX, posY, 0);


        //evrey time when the player(where this script is on is at the target it adds to call and changes the target to next target
        if (transform.position == Target)
        {
            call++;
            //makes it start from the beginning when he is at the last target
            if(call > substrings.Length)
            {
                call = 0;
            }
        }


        //moves the player to the target
        transform.position = Vector3.Lerp(transform.position, Target, speed);
    }
}