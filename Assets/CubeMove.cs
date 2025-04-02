using UnityEngine;

public class CubeMove : MonoBehaviour
{
    //public float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //필드인 경우 접근
        //float xoff = Input.GetAxis("Horizontal") * GameManager.Instance.speed * Time.deltaTime; //speed*시간 = 거리
        //float zoff = Input.GetAxis("Vertical") * GameManager.Instance.speed * Time.deltaTime;

        //프로퍼티 경우 접근
        float xoff = Input.GetAxis("Horizontal") * GameManager.Instance.Speed * Time.deltaTime; //speed*시간 = 거리
        float zoff = Input.GetAxis("Vertical") * GameManager.Instance.Speed * Time.deltaTime;

        //CubeMove 클래스를 실행한 인스턴스는 gameObejct(인스턴스)에 저장되어 있음
        //gameObejct의 클래스는 GameObject
        //원칙 : gameObejct.transform으로 접근
        //간략화 : 그냥 transform 인스턴스로 접근: transform의 클래스는 Transform
        //작성한 것은 설계도(Class), 씬에서 실행되는 것은 인스턴스
        transform.Translate(xoff, 0.0f, zoff);

        if (Input.GetKeyDown(KeyCode.R)) changeColor();
    }

    private void changeColor()
    {
        Color color =  UIManager.Instance.getNextColor();
        Renderer renderer = gameObject.GetComponent<Renderer>();

        renderer.material.color = color;

        Transform parentTf = transform;

        while(parentTf.childCount > 0) //부모(Tank) 내 자식 존재여부 / transform 으로 찾을 수 있다.
        {
            Transform childTf = parentTf.GetChild(0);
            renderer = childTf.GetComponent<Renderer>();

            renderer.material.color = color;
            parentTf = childTf;
        }
    }
}
