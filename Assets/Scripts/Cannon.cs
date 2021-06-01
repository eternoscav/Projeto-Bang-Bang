using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject ballPrefab;

	// Mantenha o controle de velocidade e tambem speed quando disparar o projétil
	public float speed;
	public float velocity;

	/// Metodo Ajusta a rotacao do o canhao baseado no Angulo
    public void SetAngle(float angle)
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
    }


    // Metodo que dispara o bola do canhao
    public void Fire()
    {
		// As condições de partida (a posição eo ângulo do objeto)
        Vector3 startPos = transform.position;
        Quaternion shotAngle = transform.rotation;

		// Cria a bola
		GameObject ball= (GameObject)GameObject.Instantiate(ballPrefab, startPos + transform.right * 0f, shotAngle);

		// Adiciona força a bola
		ball.rigidbody2D.velocity = ball.transform.right * velocity;


    }

	
}