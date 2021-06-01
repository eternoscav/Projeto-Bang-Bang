using UnityEngine;

// Anexa este script para o objeto que você quer deixar o rastro
public class ProjectileTrail : MonoBehaviour
{
    public GameObject ticks;
    public float interval;

    private Vector2 lastPos;
    private Vector2 currPos;

    void Update()
    {
        currPos = this.transform.position;
        if (Vector2.Distance(currPos, lastPos) > interval)
        {
            GameObject.Instantiate(ticks , this.transform.position, this.transform.rotation);
            lastPos = currPos;
        }
    }
}
