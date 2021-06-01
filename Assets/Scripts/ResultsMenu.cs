using UnityEngine;
using System.Collections.Generic;

public class ResultsMenu : MonoBehaviour
{
    void OnGUI()
    {
        // Pontuaçao Final
        GUI.Label(new Rect(Screen.width * 0.5f, Screen.height * 0.5f - 105.0f, 100.0f, 50.0f), StaticGameVars.score.ToString());


		//Botao reinicia aplicativo
        if (GUI.Button(new Rect( 83.20f,  380f, 200.0f, 30.0f), "Restart"))
        {
            StaticGameVars.levelIndex = 0;
			Application.LoadLevel(0);
        }

		//Botao encerra Aplicativo
        if (GUI.Button(new Rect( 413.50f,  380f, 200.0f, 30.0f), "Quit"))
        {

            Application.Quit();
        }
    }
}
