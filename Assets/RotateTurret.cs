using UnityEngine;

public class RotateTurret : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float ang = 0.0f;
        
        if(Input.GetKey(KeyCode.Q)) //�������� �ͷ� ȸ��
        {
            ang = -GameManager.Instance.RotSpeed*Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.E)) //���������� �ͷ� ȸ��
        {
            ang = GameManager.Instance.RotSpeed*Time.deltaTime;
        }
        ang += Input.mouseScrollDelta.y * 50.0f *GameManager.Instance.RotSpeed * Time.deltaTime;
        transform.Rotate(0.0f, ang, 0.0f);
    }
}
