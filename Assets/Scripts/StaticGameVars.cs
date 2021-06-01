using UnityEngine;
using System.Collections;

public class StaticGameVars : MonoBehaviour
{
    // Pontuacao do jogo
    public static int score = 0;

    // Numero de tiros do canhao remanescentes
    public static int shots = 3;

	// Armazena o índice para o nível atual
    public static int levelIndex = 0;

	// Bloqueia ou desbloqueia as configurações do canhão GUI
    public static bool guiSettingsEnabled = true;
}
