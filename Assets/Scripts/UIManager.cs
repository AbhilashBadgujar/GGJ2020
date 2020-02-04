using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class UIManager : MonoBehaviour
{



    [SerializeField]
    Slider HealthSlider;
    [SerializeField]
    Slider PromoSlider;

    public Text attack;
    public Text relax;

    public string[] attackText;


    public GameObject FakePause;


    public int health;
    public int MaxHealth;
    public int promotion;
    public int MaxPromotion;

    public static UIManager uIManager;
    
    public void ReduceHealth()
    {
        health -= 2;
    }

    public void AddHealth()
    {
        health += 2;
    }

    public void AddPromotion()
    {
        promotion += 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        uIManager = this;
        MaxHealth = 100;
        MaxPromotion = 500;
        health = 100;
        promotion = 0;
        HealthSlider.maxValue = MaxHealth;
        PromoSlider.maxValue = MaxPromotion;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        if (health <= 0)
        {
            GManager.gManager.isGameOver = true;
        }

        if (health >= 100)
        {
            health = 100;
        }
    }


    private void UpdateUI()
    {
        HealthSlider.value = health;
        PromoSlider.value = promotion;

        
    }

    public string SetText()
    {
        return attackText[ Random.Range(0, attackText.Length)];
    }


    IEnumerator FakePauseOn()
    {
        FakePause.SetActive(true);
        yield return new WaitForSeconds(2f);
        FakePause.SetActive(false);
    }

    public void FakePauseUI()
    {
        StartCoroutine(FakePauseOn());
    }

    public void ChangeRelaxText(string textb)
    {
        relax.text = textb;
    }
}
