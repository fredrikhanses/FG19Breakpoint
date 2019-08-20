using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]
public class Brick : MonoBehaviour
{
    [Tooltip("Should we cause the camera to shake if the ball hits this brick?")]
    public bool causeCameraShake = false;
    public bool isBreakable = true;

    [Tooltip("Number of sprites = number of hits the brick can take.")]
    public List<Sprite> sprites = new List<Sprite>();

    private SpriteRenderer spriteRenderer;

    public static int bricksDestroyed = 0;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer, "Failed to find SpriteRenderer component.");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (causeCameraShake)
        {
            GameCamera.instance.cameraShake.Shake();
        }

        if (!isBreakable)
        {
            return;
        }

        if (sprites.Count > 0)
        {
            sprites.RemoveAt(0);
            if(sprites.Count > 0)
            {
                spriteRenderer.sprite = sprites[0];
            }
            else
            {
                bricksDestroyed++;
                if (bricksDestroyed % GameMode.instance.spawnBallForEveryBrickDestroyed == 0)
                {
                    Instantiate(GameMode.instance.ballPrefab, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
}