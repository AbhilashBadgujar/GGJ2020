using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemClass : MonoBehaviour
{

    public int ProblemLevel;
    public int MaxProblemLevel;
    public bool isProblem;
    public bool isNoLevel;
    Vector3 _startPosition;



    [SerializeField]
    ParticleSystem effect;
    [SerializeField]
    AudioClip hit, ends;

    public float CurveSpeed = 5;
    public float MoveSpeed = 1;

    float fTime = 0;
    Vector3 vLastPos = Vector3.zero;

    SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    // Use this for initialization
    void Start()
    {

        
        vLastPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {

        vLastPos = transform.position;

        fTime += Time.deltaTime * CurveSpeed;

        Vector3 vSin = new Vector3(Mathf.Sin(fTime), -Mathf.Sin(fTime), 0);
        Vector3 vLin = new Vector3(0, MoveSpeed, 0);

        transform.position += (vSin + vLin) * Time.deltaTime;
        
    }


    void DestroyProblems()
    {
        PlayEffect();
        spriteRenderer.color = new Color(0f,0f,0f,0f);
        
        gameObject.tag = "Player";
        


        GetComponent<AudioSource>().clip = ends;
        
        UIManager.uIManager.AddPromotion();
        
        GetComponent<AudioSource>().Play();
        
        
        
        

        Destroy(gameObject, 2f);
    }

    void PlayEffect()
    {
        var main = effect.main;
        main.startColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);


        effect.Play();
    }

    private void OnMouseDown()
    {
        
        if (isProblem)
        {
            ProblemLevel--;

            if (ProblemLevel <= 0)
            {
                
                PlayEffect();

                DestroyProblems();
            }


            
            GetComponent<AudioSource>().Play();
            if (ProblemLevel > 0)
            {
                transform.localScale *= ((float)((float)ProblemLevel / MaxProblemLevel) * 2);
            }
           

        } else
        {
            spriteRenderer.enabled = false;
            PlayEffect();
            UIManager.uIManager.AddHealth();
            GetComponent<AudioSource>().Play();
            Destroy(gameObject,1f);
        }
        
    }
}
