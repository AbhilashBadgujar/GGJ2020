using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{


    public bool isSpawn;
    public bool isGameOver;
    public static GManager gManager;




    public GameObject RelifText;
    public GameObject AttackText;
    // Start is called before the first frame update
    void Start()
    {

        
        gManager = this;
        StartCoroutine(DisableAttackPanel());
        StartCoroutine(ChangeMood());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene(2);
        }

        if (UIManager.uIManager.promotion >= UIManager.uIManager.MaxPromotion)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Problem")
        {
            Destroy(collision.gameObject);
            UIManager.uIManager.ReduceHealth();
            StartCoroutine(CamShake());
            GetComponent<AudioSource>().Play();
        }
    }

    IEnumerator CamShake()
    {
        CameraShake.cameraShake.shakeAmount = 0.2f;
        yield return new WaitForSeconds(0.08f);
        CameraShake.cameraShake.shakeAmount = 0.05f;

    }

   
    IEnumerator DisableAttackPanel()
    {
        UIManager.uIManager.attack.text = UIManager.uIManager.SetText();
        yield return new WaitForSeconds(3f);
        
        AttackText.SetActive(false);
    }


    public IEnumerator ChangeMood()
    {
        yield return new WaitForSeconds(35f);

        GameObject[] objs;
        isSpawn = false;
       
        RelifText.SetActive(true);
        CameraShake.cameraShake.shakeAmount = 0f;
        objs = GameObject.FindGameObjectsWithTag("Problem");
        foreach (GameObject pro in objs)
        {
            Destroy(pro);
        }
        UIManager.uIManager.ChangeRelaxText("Breath In...");
        yield return new WaitForSeconds(2f);
        UIManager.uIManager.ChangeRelaxText("Brealth Out...");
        yield return new WaitForSeconds(3f);

        RelifText.SetActive(false);
        CameraShake.cameraShake.shakeAmount = 0f;
        yield return new WaitForSeconds(7f);

        UIManager.uIManager.attack.text = UIManager.uIManager.SetText();
        AttackText.SetActive(true);
        objs = GameObject.FindGameObjectsWithTag("Health");
        foreach (GameObject pro in objs)
        {
            Destroy(pro);
        }
        isSpawn = true;
        yield return new WaitForSeconds(10f);
        CameraShake.cameraShake.shakeAmount = 0.05f;
        AttackText.SetActive(false);

        
        


        ProblemSpawnner.problemSpawnner.StartCoroutine(ProblemSpawnner.problemSpawnner.SpwanProblems());
        print("1");

    }


   
}
