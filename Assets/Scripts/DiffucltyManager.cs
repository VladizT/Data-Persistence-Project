using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiffucltyManager : MonoBehaviour
{



    public void SelectDiffulcty( string type )
    {

        switch (type)
        {
            case "easy":
                
                setDiffuclty(0.01f, 3.0f, 2.0f, 1);
            
            break;

            case "medium":
                
                setDiffuclty(0.01f, 5.0f, 2.5f, 2);
            
            break;

            case "hard":
                
                setDiffuclty(0.01f, 6.0f, 3.0f, 3);

            break;

        }




    }

    void setDiffuclty( float acc, float maxV, float startImp, int scoreM )
    {
        Main.s.accelerationFactor = acc;
        Main.s.maxVelocity = maxV;
        Main.s.scoresMulty = scoreM;
        Main.s.startImpulse = startImp;

       SceneManager.LoadScene(1);
    }


}
