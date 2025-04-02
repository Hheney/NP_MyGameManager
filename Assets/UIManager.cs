using UnityEngine;
using TMPro;
using UnityEditor.Search;

public class UIManager : MonoBehaviour
{
    public TMP_Text textSpeed; //필드로 선언
    private Color[] colors = {Color.blue, Color.white, Color.red, Color.green, Color.gray, 
        Color.black, Color.cyan, new Color(0.5f, 0.25f, 0.7f)};

    private int tankColorIndex = 0;

    private static UIManager _instance = null;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("UIManager is null.");
            }
            return _instance;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //showSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Debug.Log("UIManager has another instance.");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    public void showSpeed()
    {
        string str = $"Speed = {GameManager.Instance.Speed}";
        textSpeed.text = str;
    }

    public Color indexToColor(int index)
    {
        return colors[index];
    }

    public Color getNextColor()
    {
        tankColorIndex++;

        if (tankColorIndex >= colors.Length) { tankColorIndex = 0; }

        return indexToColor(tankColorIndex);
    }
}
