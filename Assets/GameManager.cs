using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public float speed = 10.0f; //�ʵ� : public �ϸ� ��ü������ ö�а� ��������
    public float Speed //������Ƽ
    { get;set; }

    public float SpeedStep
    { get; set;}

    public float RotSpeed
    { get; set; }

    public float AmmoForce
    { get; set; }

    public int PlayerScore
    { get; set; }

    public int EnemyScore
    { get; set; }

    //singleton pattern : Ŭ���� �ϳ��� �ν��Ͻ��� �ϳ��� �����Ǵ� ���α׷��� ����
    private static GameManager _instance = null; //��� ���� ����, ���� = �ʵ�(field) ���� �� private, protected ���� �ܺο��� ���� �Ұ���
    public static GameManager Instance //���� + �Լ� = �ʵ� + �޼ҵ� = ������Ƽ(property) �� �ܺ� ������ �����ϰ�(public ����), �ܺο����� ����ó�� ���  
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is null.");
            }
            return _instance;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initProgram();
        UIManager.Instance.showSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (_instance == null)
            _instance = this; //this : ���� �ν��Ͻ��� ����Ű�� ���۷���
        else if (_instance != this)
        {
            Debug.Log("GameManager has another instance.");
            // ���� �ν��Ͻ� �ı�
            Destroy(gameObject);
        }
        //���� �ٲ� ���� ���� ������Ʈ�� ����
        DontDestroyOnLoad(gameObject);
    }

    void initProgram()
    {
        Speed = 10.0f;
        SpeedStep = 1.0f;
        RotSpeed = 30.0f;
        AmmoForce = 2000.0f;

        PlayerScore = 0;
        EnemyScore = 0;
    }

    public void incSpeed()
    {
        Speed += SpeedStep;
        UIManager.Instance.showSpeed();
    }

    public void decSpeed()
    {
        Speed -= SpeedStep;
        if (Speed < 0.0f) { Speed = 0.0f; }
        UIManager.Instance.showSpeed();
    }

}
