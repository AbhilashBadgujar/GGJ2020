using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemSpawnner : MonoBehaviour
{

    [SerializeField] GameObject problem;
    [SerializeField] GameObject HealthProb;
    [SerializeField] float maxWidth;

    public Color[] colors;

    public static ProblemSpawnner problemSpawnner;

    // Start is called before the first frame update
    void Start()
    {
        problemSpawnner = this;
        StartCoroutine(SpwanProblems());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(Mathf.Sin(Time.time), 0.0f, 0.0f);
    }


    public IEnumerator SpwanProblems()
    {
        GManager.gManager.StartCoroutine(GManager.gManager.ChangeMood());
        while (GManager.gManager.isSpawn)
        {
            Vector3 spawnPosition = new Vector3(
                transform.position.x + Random.Range(-maxWidth, maxWidth),
                transform.position.y,
                0.0f
            );
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
            GameObject problm = Instantiate(problem, spawnPosition, Quaternion.identity);
            ProblemClass probClass = problm.GetComponent<ProblemClass>();
            probClass.ProblemLevel = Random.Range(1, probClass.MaxProblemLevel);
            probClass.CurveSpeed = Random.Range(1, 5);
            probClass.MoveSpeed = Random.Range(1, 3);
            problm.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
        }
        while (GManager.gManager.isSpawn == false)
        {
            Vector3 spawnPosition = new Vector3(
               transform.position.x + Random.Range(-maxWidth, maxWidth),
               transform.position.y + 14f,
               0.0f
           );
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            Instantiate(HealthProb, spawnPosition, Quaternion.identity);

        }
    }
}
