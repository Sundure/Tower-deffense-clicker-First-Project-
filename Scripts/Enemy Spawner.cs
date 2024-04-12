using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Header("Refrences")]
    [SerializeField] private GameObject[] EnemyModel;

    [Header("Atributes")]
    [SerializeField] private int Base_Enemies;
    [SerializeField] private float Enemies_Per_Seconds = 0.5f;
    [SerializeField] public float Time_Betwwen_Waves = 5f;
    [SerializeField] private float Difficalty_Scaling_Factor = 0.75f;

    [Header("Events")]
    public static UnityEvent On_Enemy_Destroyd = new UnityEvent();

    public float Time_Sience_Last_Spawn;
    private int Current_Wave;
    public Text _Current_Wave;
    public int Enemies_Allive;
    private int Enemies_Left_To_Spawn;
    private bool Is_Spawning = false;

    private void Awake()
    {
        On_Enemy_Destroyd.AddListener(On_Enemy_Destroyed);
    }
    private void Start()
    {
        StartWave();
    }

    private void On_Enemy_Destroyed()
    {
        Enemies_Allive--;
    }
    private void StartWave()
    {
        Current_Wave++;
        _Current_Wave.text = Current_Wave.ToString();
        Is_Spawning = true;
        Enemies_Left_To_Spawn = Enemies_Per_Wave();
        if (Enemies_Allive <= -1)
        {
            Is_Spawning = false;
        }

    }
    private void Spawn_Enemy()
    {
        if (Time_Betwwen_Waves <= 0f)
        {
            Debug.Log("Spawn Enemy model");
            GameObject Prefab_To_Spawn = EnemyModel[0];
            Instantiate(Prefab_To_Spawn, Level_Manager.main.Start_Point.position, Quaternion.identity);
        }
    }

    private int Enemies_Per_Wave()
    {
        return Mathf.RoundToInt(Base_Enemies * Mathf.Pow(Current_Wave, Difficalty_Scaling_Factor));
    }
    private void Update()
    {
        Time_Betwwen_Waves -= Time.deltaTime;
        if (!Is_Spawning) return;

        Time_Sience_Last_Spawn += Time.deltaTime;

        if (Time_Betwwen_Waves <= 0f)
        {
            if (Time_Sience_Last_Spawn >= (1f / Enemies_Per_Seconds) && Enemies_Left_To_Spawn > 0)
            {
                Spawn_Enemy();
                Enemies_Left_To_Spawn--;
                Enemies_Allive++;
                Time_Sience_Last_Spawn = 0f;
            }
        }
    }
}
