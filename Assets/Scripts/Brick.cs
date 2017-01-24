using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioClip crack;

    public GameObject Smoke;

    public Sprite[] hitSprites;
     
    public static int breakableBrickCount = 0;

    private bool isBreakable;

    private int TimesHit;

    private LevelManager levelManager;

    void Start ()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        TimesHit = 0;
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableBrickCount++;
        }
    }

    void Update ()
    {
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        TimesHit++;
        int MaxHits = hitSprites.Length + 1;
        if (TimesHit >= MaxHits)
        {
            breakableBrickCount--;
            levelManager.BrickDestroyed();
            MakeSmoke();

            GameObject.Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void MakeSmoke()
    {
        GameObject puff = (GameObject)Instantiate(Smoke, this.transform.position, Quaternion.identity);
        ParticleSystem ps = puff.GetComponent<ParticleSystem>();
        var col = ps.colorOverLifetime;
        col.enabled = true;
        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(GetComponent<SpriteRenderer>().color, 0.0f), new GradientColorKey(GetComponent<SpriteRenderer>().color, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
        col.color = grad;
    }

    private void LoadSprites()
    {
        int spriteIndex = TimesHit - 1;
        if (hitSprites[spriteIndex])
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Sprite is missing for index " + spriteIndex);
        }
    }

    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
