using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    void Update()
    {
        // Projetil codigo
        Vector3 moveDirection = rigidbody2D.velocity;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
		Application.LoadLevel(0);
		// Destroi o script. 
        Destroy(this);

		// Controle de eventos sobre a colisão
        EventManager.BallCollision(this.gameObject, collision);
    }
}
