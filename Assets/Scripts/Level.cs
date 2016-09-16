using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    private Color transparant;

    private float widthWorld, heightWorld;
    private int widthPixel, heightPixel;

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Texture2D texture = (Texture2D)Resources.Load("Platform");
        Texture2D textureClone = (Texture2D)Instantiate(texture);

        spriteRenderer.sprite = Sprite.Create(textureClone, new Rect(0f, 0f, textureClone.width, textureClone.height), new Vector2(0.5f, 0.5f), 100f);

        transparant = new Color(0f,0f,0f,0f);

        InitSpriteDimensions();

        gameObject.AddComponent<PolygonCollider2D>();
    }

    private void InitSpriteDimensions()
    {
        widthWorld = spriteRenderer.bounds.size.x;
        heightWorld = spriteRenderer.bounds.size.y;
        widthPixel = spriteRenderer.sprite.texture.width;
        heightPixel = spriteRenderer.sprite.texture.height;
    }

    public void DestroyGround(Collider2D cc)
    {
        V2int c = World2Pixel(cc.bounds.center.x, cc.bounds.center.y);
        int r = Mathf.RoundToInt(cc.bounds.size.x * widthPixel / widthWorld);

        int x, y, px, nx, py, ny, d;

        for (x = 0; x <= r; x++)
        {
            d = (int)Mathf.RoundToInt(Mathf.Sqrt(r * r - x * x));

            for (y = 0; y <= d; y++)
            {
                px = c.x + x;
                nx = c.x - x;
                py = c.y + y;
                ny = c.y - y;

                spriteRenderer.sprite.texture.SetPixel(px, py, transparant);
                spriteRenderer.sprite.texture.SetPixel(nx, py, transparant);
                spriteRenderer.sprite.texture.SetPixel(px, ny, transparant);
                spriteRenderer.sprite.texture.SetPixel(nx, ny, transparant);
            }
        }
        spriteRenderer.sprite.texture.Apply();
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private V2int World2Pixel(float x, float y)
    {
        V2int v = new V2int();

        float dx = x - transform.position.x;
        v.x = Mathf.RoundToInt(0.5f * widthPixel + dx * widthPixel / widthWorld);

        float dy = y - transform.position.y;
        v.y = Mathf.RoundToInt(0.5f * heightPixel + dy * heightPixel / heightWorld);

        return v;
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Collider2D circleCollider2d = GameObject.Find("CircleColliderTest").GetComponent<Collider2D>();
            //DestroyGround(circleCollider2d);
        }
	}
}
