using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public float alphaColor = 125f;
    public Color hitHealthColor;

    public float delayDamage = 0.5f;
    private float getDamageTime;
    Animator anim;

    bool shield = false;
    private GameObject shieldObj;

    PlayerMoovement pm;

    void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMoovement>();
        if (maxHealth > 3 || maxHealth < 0)
        {
            maxHealth = 3;
        }
        currentHealth = maxHealth;
        for (int i = 0; i < currentHealth; i++)
        {
            CanvasObject.CO.healthImage[i].color = new Color(255f, 255f, 255f, 255f);
        }
    }

    public void TakeDamage(int damage)
    {
        if (getDamageTime + delayDamage < Time.time && !shield)
        {
            getDamageTime = Time.time;
            if (damage > currentHealth) damage = currentHealth;
            for(int i = damage; i > 0; i--)
            {
                print(i);
                currentHealth--;
                CanvasObject.CO.healthImage[currentHealth].color = hitHealthColor;
                pm.PlaySound(pm.damageGetSound);
            }
            if (currentHealth <= 0)
            {
                Deth();
            }
            anim.SetBool("hit", true);
            Invoke("OffDamageAnimation", delayDamage-0.5f);
        }
    }

    public void DethZone()
    {
        currentHealth = 0;
        for (int i = 0; i < maxHealth; i++)
        {
            CanvasObject.CO.healthImage[i].color = hitHealthColor;
        }
        Deth();
    }

    private void Deth()
    {
        OffDamageAnimation();
        GetComponent<PlayerMoovement>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        anim.SetBool("deth", true);
        pm.PlaySound(pm.dethSound);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Invoke("RestartLevel", 2f);
    }

    public void AddHealth(int health)
    {
        pm.PlaySound(pm.bonusSound);
        if (currentHealth >= 3) return;
        else
        {
            if (currentHealth + health > 3)
            {
                health = 0;
            }
            else { currentHealth += health; }
            for(int i = 0; i < currentHealth; i++)
            {
                print(i);
                CanvasObject.CO.healthImage[currentHealth-1].color = new Color(255f, 255f, 255f, 255f);
            }
        }
    }

    public void ActivateShield(float shieldDelay, GameObject shieldObject)
    {
        pm.PlaySound(pm.bonusSound);
        shieldObj = Instantiate(shieldObject);
        shieldObj.transform.position = transform.position;
        shieldObj.transform.SetParent(this.gameObject.transform);
        shield = true;
        Invoke("DisactivateShield", shieldDelay);
    }

    private void DisactivateShield()
    {
        shield = false;
        Destroy(shieldObj);
    }

    void OffDamageAnimation()
    {
        anim.SetBool("hit", false);
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
