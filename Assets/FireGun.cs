using UnityEngine;

public class FireGun : MonoBehaviour
{
    public GameObject ammo = null; //ammunition 포탄

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fireGun();
        }
    }


    void fireGun()
    {
        GameObject newAmmo = Instantiate(ammo, transform.position, transform.rotation); //포탄 생성

        Transform parentTf = transform.parent;
        Renderer renderer = newAmmo.GetComponent<Renderer>();
        renderer.material.color = parentTf.GetComponent<Renderer>().material.color; //부모인 Gun의 색을 가져와서 적용


        Rigidbody rb = newAmmo.GetComponent<Rigidbody>();

        rb.AddForce(transform.up * GameManager.Instance.AmmoForce); //대문자 구분 up, forword, right 방향 벡터로 힘을 가함
    }
}
