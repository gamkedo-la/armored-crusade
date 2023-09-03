using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public bool debug = false;

    public GameObject[] mechoidPrefab_1;
    public GameObject[] mechoidPrefab_2;
    public GameObject[] wheelstingerPrefab;
    public GameObject[] beetlebomberPrefab;
    public GameObject[] rockPrefab;
    public GameObject[] shieldPowerupPrefab;

    public float mechoidSpawnY = 92.5f;
    public float wheelstingerSpawnY = 18f;
    public float rockSpawnY = 18f;
    public float beetlebomberSpawnY = 70f;
    public float spawnZ = 1100f;

    private Vector3[] mechoidPositions;
    private Vector3[] wheelstingerPositions;
    private Vector3[] beetlebomberPositions;
    private Vector3[] rockPositions;
    private Vector3[] shieldPowerupPositions;

    public static bool wave2 = false;
    public static bool wave3 = false;
    public static bool wave4 = false;
    public static bool boss = false;

    public TextMeshProUGUI lbl_boss;
    public TextMeshProUGUI lbl_ready;
    public TextMeshProUGUI lbl_wave2;
    public TextMeshProUGUI lbl_wave3;
    public TextMeshProUGUI lbl_wave4;

    private AudioSource audioSource;
    public AudioClip wave;

    void Start()
    {
        if (debug != true)
        {
            lbl_ready.gameObject.SetActive(true);
            StartCoroutine(StopTimeForThreeSeconds());
        }

        audioSource = GetComponent<AudioSource>();

        InvokeRepeating("spawnMechoid_1", 0f, 2f);

        lbl_wave2.gameObject.SetActive(false);
        lbl_wave3.gameObject.SetActive(false);
        lbl_boss.gameObject.SetActive(false);

        mechoidPositions = new Vector3[] {
            new Vector3(-115f, mechoidSpawnY, spawnZ),
            new Vector3(-15f, mechoidSpawnY, spawnZ),
            new Vector3(85f, mechoidSpawnY, spawnZ)
        };
        wheelstingerPositions = new Vector3[] {
            new Vector3(-63f, wheelstingerSpawnY, spawnZ),
            new Vector3(-23f, wheelstingerSpawnY, spawnZ),
            new Vector3(12f, wheelstingerSpawnY, spawnZ)
        };
        beetlebomberPositions = new Vector3[] {
            new Vector3(-46.75f, beetlebomberSpawnY, spawnZ),
            new Vector3(-23f, beetlebomberSpawnY, spawnZ),
            new Vector3(12f, beetlebomberSpawnY, spawnZ)
        };
        rockPositions = new Vector3[] {
            new Vector3(-50f,rockSpawnY, spawnZ),
            new Vector3(-21f,rockSpawnY, spawnZ),
            new Vector3(18f, rockSpawnY, spawnZ)
        };
        shieldPowerupPositions = new Vector3[] {
            new Vector3(-300f, 75, 150),
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            Score.playerScore = Score.playerScore + 501;
        }

        if (Score.playerScore >= 300 && !wave2)
        {
            audioSource.PlayOneShot(wave);
            lbl_wave2.gameObject.SetActive(true);
            StartCoroutine(StopTimeForTwoSeconds());
            InvokeRepeating("spawnWheelstinger", 0f, 4f);
            wave2 = !wave2;

        }
        if (Score.playerScore >= 1000 && !wave3)
        {
            InvokeRepeating("spawnShieldPowerup", 0f, 30f);
            audioSource.PlayOneShot(wave);
            lbl_wave3.gameObject.SetActive(true);
            StartCoroutine(StopTimeForTwoSeconds());
            InvokeRepeating("spawnBeetlebomber", 0f, 4f);
            InvokeRepeating("spawnRock", 0f, 40f);
            wave3 = !wave3;
        }
        if (Score.playerScore >= 2000 && !wave4)
        {
            audioSource.PlayOneShot(wave);
            lbl_wave4.gameObject.SetActive(true);
            StartCoroutine(StopTimeForTwoSeconds());
            InvokeRepeating("spawnMechoid_2", 0f, 3f);
            CancelInvoke("spawnRock");
            InvokeRepeating("spawnRock", 0f, 20f);
            wave4 = !wave4;
        }
        //if (Score.playerScore >= 250 && !boss)
        //{
        //    audioSource.PlayOneShot(wave);
        //    lbl_boss.gameObject.SetActive(true);
        //    StartCoroutine(StopTimeForTwoSeconds());
        //    //TODO - Spawn Boss
        //    boss = !boss;
        //}
    }

    void spawnMechoid_1()
    {
        int mechoidIndex = Random.Range(0, mechoidPositions.Length);
        Vector3 randomPosition = mechoidPositions[mechoidIndex];
        Instantiate(mechoidPrefab_1[0], randomPosition, mechoidPrefab_1[0].transform.rotation);
    }

    void spawnMechoid_2()
    {
        int mechoidIndex = Random.Range(0, mechoidPositions.Length);
        Vector3 randomPosition = mechoidPositions[mechoidIndex];
        Instantiate(mechoidPrefab_2[0], randomPosition, mechoidPrefab_2[0].transform.rotation);
    }

    void spawnWheelstinger()
    {
        int wheelstingerIndex = Random.Range(0, wheelstingerPositions.Length);
        Vector3 randomPosition = wheelstingerPositions[wheelstingerIndex];
        Instantiate(wheelstingerPrefab[0], randomPosition, wheelstingerPrefab[0].transform.rotation);
    }

    void spawnBeetlebomber()
    {
        int beetlebomberIndex = Random.Range(0, beetlebomberPositions.Length);
        Vector3 randomPosition = beetlebomberPositions[beetlebomberIndex];
        Instantiate(beetlebomberPrefab[0], randomPosition, beetlebomberPrefab[0].transform.rotation);
    }
    void spawnRock()
    {
        int rockIndex = Random.Range(0, rockPositions.Length);
        Vector3 randomPosition = rockPositions[rockIndex];
        Instantiate(rockPrefab[0], randomPosition, rockPrefab[0].transform.rotation);
    }
    void spawnShieldPowerup()
    {
        int shieldPowerupIndex = Random.Range(0, shieldPowerupPositions.Length);
        Vector3 randomPosition = shieldPowerupPositions[shieldPowerupIndex];
        Instantiate(shieldPowerupPrefab[0], randomPosition, shieldPowerupPrefab[0].transform.rotation);
    }

    private IEnumerator StopTimeForTwoSeconds()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 1f;
        lbl_ready.gameObject.SetActive(false);
        lbl_wave2.gameObject.SetActive(false);
        lbl_wave3.gameObject.SetActive(false);
        lbl_wave4.gameObject.SetActive(false);
        lbl_boss.gameObject.SetActive(false);
    }
    private IEnumerator StopTimeForThreeSeconds()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(3f);
        Time.timeScale = 1f;
        lbl_ready.gameObject.SetActive(false);
    }
}
