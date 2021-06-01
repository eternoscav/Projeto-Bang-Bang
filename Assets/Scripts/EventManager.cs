using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
	// Chamar esse método quando a bola colidir em algo
    public static void BallCollision(GameObject arrow, Collision2D collision)
    {

		//Reativa as configurações de GUI
        StaticGameVars.guiSettingsEnabled = true;

		// Se a bola atingir o alvo e aumentado a pontuação do jogador com base nos disparos restantes,
		// Prosseguindo para o próximo nível e repondo os tiros. Caso contrário, diminuir tiros do jogador
        if (collision.gameObject.name.Equals("Target"))
        {
            StaticGameVars.score += StaticGameVars.shots;
            StaticGameVars.levelIndex += 2;
            Application.LoadLevel(StaticGameVars.levelIndex);
            StaticGameVars.shots += 2;
        }
        else
        {
            StaticGameVars.shots -= 1;
        }

		// Se o jogador ficar sem tiros, redefinir o jogo (voltar ao nível 1) e todo o jogo estático vars
        if (StaticGameVars.shots == 0)
        {
            Application.LoadLevel("Level_1");
            StaticGameVars.score = 0;
            StaticGameVars.shots = 3;
            StaticGameVars.levelIndex = 0;

        }
    }
}
