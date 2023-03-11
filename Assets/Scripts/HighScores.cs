using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class HighScores : MonoBehaviour
{

    public GameObject linePrefab;

    GameObject[] rows = new GameObject[10];

    List<Main.PlayerData> highscoresSorted;

    GameObject testObject;
    TextMeshProUGUI testText;

   

    void Start()
    {

        highscoresSorted = Main.s.playersData.arrPlayers;

        highscoresSorted.Sort(( Main.PlayerData x, Main.PlayerData y) => y.scores.CompareTo(x.scores));

        CreateList();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CreateList()
    {

        TextMeshProUGUI tempTMP;
        RectTransform   tempRT;

        Color tempColor = new Vector4(0.9f, 0.9f, 0.9f, 1.0f); ;
        string tempName = "Row ";

        float offsetX = -110;

        for (int j = 0; j < 3; j++)
        {

            float offsetY = GameObject.Find("HighscoresLabel").transform.localPosition.y;
            

            if (j == 1)
            {
                offsetX = -70;
                tempName = "Name ";
                ColorUtility.TryParseHtmlString("#FBC538", out tempColor);
            }

            if (j == 2)
            {
                offsetX = 110;
                tempName = "Scores ";
                ColorUtility.TryParseHtmlString("#FF45FF", out tempColor);
            }


            

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = new GameObject();
                rows[i].name = tempName + (i + 1);

                rows[i].transform.SetParent(transform, false);

                tempTMP = rows[i].AddComponent<TextMeshProUGUI>();
                tempRT = rows[i].GetComponent<RectTransform>();

                tempRT.sizeDelta = new Vector2(50, 20);

                tempRT.anchorMin = new Vector2(0.5f, 1);
                tempRT.anchorMax = new Vector2(0.5f, 1);
                tempRT.pivot     = new Vector2(0.5f, 0.1f);

                offsetY -= 25;
                tempRT.localPosition = new Vector3(offsetX, offsetY, 0);

           
                
                tempTMP.color = tempColor;
                
                tempTMP.fontSize = 18;
                tempTMP.fontStyle = FontStyles.Bold;

                tempTMP.enableWordWrapping = false;


                if( j == 0 )
                {
                    tempTMP.text = $"#{i + 1}";

                    
                    if( i < rows.Length-1)
                    {
                        GameObject tempLine = Instantiate(linePrefab, transform);
                        tempLine.transform.localPosition = tempRT.localPosition;
                        tempLine.transform.Translate(new Vector3(102f, -5f, 0));
                    }
                    
                }

                if (j == 1)
                {
                    if (i < highscoresSorted.Count)
                    {

                        if( Main.s.namePlayer == highscoresSorted[i].namePlayer )
                        {
                            tempTMP.fontStyle = FontStyles.Underline;
                        }

                        tempTMP.text = highscoresSorted[i].namePlayer;
                    } 
                    else
                    {
                        tempTMP.text = "-----";
                    }
                }

                if (j == 2)
                {
                    if (i < highscoresSorted.Count)
                    {
                        tempTMP.text = highscoresSorted[i].scores.ToString();
                    }
                    else
                    {
                        tempTMP.text = "--";
                    }
                }

            }

        }

    }


    public void Back()
    {
        SceneManager.LoadScene(0);
    }

}
