using UnityEngine;
using System.Collections;

public class GUIOverlay : MonoBehaviour
{
    //Script referente ao canhao
    public Cannon cannon;

	//Armazena o valor de entrada dos eixos x e y
	private float ballAxis = 0.1f;  

	//Armazena o valor de entrada do Drag do RigidBody
	private float ballDrag = 0f;

	//Armazena o valor de entrada da velocidade 
	private float initialVelocity = 20f;

	//Armazena o valor de entrada do angulo 
	private float angle = 20f;

	//Texturas botoes + e - de entrada
	public Texture2D buttonPositive = null;
	public Texture2D buttonNegative = null;

    public GUIStyle style;

	void Update(){
			cannon.ballPrefab.rigidbody2D.drag = ballDrag;
			cannon.ballPrefab.transform.localScale = new Vector2(ballAxis, ballAxis);

	}

	void OnGUI()
    {

		// ------------------ GUI Canhão Configurações --------------------------- -----------------------
        if (StaticGameVars.guiSettingsEnabled)
        {
			if(GUI.Button(new Rect(475,10,18,18), buttonPositive))
			{
				if(angle <90f ){
					angle++;
				}
			}
			
			if(GUI.Button(new Rect(705,10,18,18), buttonNegative))
			{
				if(angle >0f){
					angle--;
				}
			}
			
			if(GUI.Button(new Rect(475,27,18,18), buttonPositive))
			{

				initialVelocity++;
			}
			
			if(GUI.Button(new Rect(705,27,18,18), buttonNegative))
			{
				if(initialVelocity >0f ){
				initialVelocity--;
				}
			}

			if(GUI.Button(new Rect(475,45,18,18), buttonPositive))
			{
				
				ballDrag++;
			}
			
			if(GUI.Button(new Rect(705,45,18,18), buttonNegative))
			{
				if(ballDrag >0f ){
					ballDrag--;
				}
			}

			if(GUI.Button(new Rect(475,63,18,18), buttonPositive))
			{
				if(ballAxis <0.4f ){
				ballAxis+=0.1f;
				}
			}
			
			if(GUI.Button(new Rect(705,63,18,18), buttonNegative))
			{
				if(ballAxis >0.1f ){
					ballAxis-=0.1f;
				}
			}


			// Cria uma Area GUILayout no canto inferior esquerdo da tela
			GUILayout.BeginArea(new Rect(520.0f, 10.0f, 175.0f, 100.0f));
        
			//vertical cria dois dois campos de texto
            GUILayout.BeginVertical("box");

            //Cria um campo angulo
            GUILayout.BeginHorizontal();
            GUILayout.Label("Angle", style);
			GUILayout.Label("    " + angle.ToString(), style);

			cannon.SetAngle(angle);

            //Fim do campo Angulo
            GUILayout.EndHorizontal();

			//Mostra a velocidade
			GUILayout.BeginHorizontal();
            GUILayout.Label("Velocity", style);
			GUILayout.Label("" + initialVelocity.ToString(), style);


            cannon.velocity = initialVelocity;

			//Fim do campo velocidade
            GUILayout.EndHorizontal();
			//--------------------------------------------------


			//Mostra a velocidade
			GUILayout.BeginHorizontal();
			GUILayout.Label("Weight", style);
			GUILayout.Label(" " + ballDrag.ToString(), style);
			GUILayout.EndHorizontal();
			//---------------------------------------------------
					
			//Mostra a velocidade
			GUILayout.BeginHorizontal();
			GUILayout.Label("Size", style);
			GUILayout.Label("     " + ballAxis.ToString(), style);
			GUILayout.EndHorizontal();
			//---------------------------------------------------

            //Fim da vertical
            GUILayout.EndVertical();

            //Botao de iniciar simulaçao
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Fire!"))
            {
                StaticGameVars.guiSettingsEnabled = false;
                cannon.Fire();
            }

            GUILayout.EndHorizontal();

            //Fim do campo area
            GUILayout.EndArea();

        }
		// ---------------- Fim GUI canhão Configurações --------------------------- ------------------


        //-------------------- Informacoes GUI ---------------------------------------------------
		// Cria uma nova área de GUI no canto superior esquerdo
        GUILayout.BeginArea(new Rect(10.0f, 10.0f, 175.0f, 100.0f));
		GUILayout.BeginVertical("box");

		// Inclui a pontuação (ou seja, quantas vezes projétil atingiu o alvo)
        GUILayout.BeginHorizontal();
        GUILayout.Label("Score", style);
        GUILayout.Label(StaticGameVars.score.ToString(), style);
        GUILayout.EndHorizontal();

		// Quantos disparos restantes antes de reiniciar
        GUILayout.BeginHorizontal();
        GUILayout.Label("Shots", style);
        GUILayout.Label(StaticGameVars.shots.ToString(), style);
        GUILayout.EndHorizontal();
		GUILayout.EndVertical();

		// Fim da area de informacoes
        GUILayout.EndArea();
        //------------------ Fim da Informacoes GUI -----------------------------------------------------


	 }
}
