using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour
{
    private Level level;
    private PolygonCollider2D hitCollider;
    [SerializeField] public Collider2D explosionCircle;

    void Start()
    {
        level = GameObject.Find("Level").GetComponent<Level>();
        hitCollider = GetComponent<PolygonCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        level.DestroyGround(explosionCircle);
        Destroy(gameObject);
    }
}
