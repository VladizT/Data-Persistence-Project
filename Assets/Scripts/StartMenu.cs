using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenu : MonoBehaviour
{

    TMP_InputField nameField;

    public TextMeshProUGUI BestScoreText;

    public UnityAction<string> inputEven;

    // Start is called before the first frame update
    void Start()
    {
        nameField = GameObject.Find("NameField").GetComponent<TMP_InputField>();

        inputEven = NameEnter;
        
        nameField.onValueChanged.AddListener(inputEven);

        Main.s.LoadGame();

        if (Main.s.playersData.currNamePlayer != "")
        {
            Main.s.CalcBestScore();
            BestScoreText.text = $"Best Score: {Main.s.bestPlayer} : {Main.s.bestScores}";
            nameField.text = Main.s.namePlayer;
        }
 

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NameEnter( string inputText )
    {
        Main.s.namePlayer = inputText;
    }

    public void StartGame()
    {
        Main.s.SaveGame();
        SceneManager.LoadScene(1);
    }

    public void OpenHighscores()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
