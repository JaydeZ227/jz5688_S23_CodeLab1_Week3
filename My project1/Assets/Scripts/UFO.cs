using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{


    GameObject par;
    public float fireParSpeedMin = 800;
    public float fireParSpeedMax = 1200;
    public int parCount = 30;

    private void Awake()
    {
        par = Resources.Load<GameObject>("Prefabs/Par");
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag=="Ground")
        {
            Destroy(gameObject);
        }


    }


    public void Death()
    {
        for (int i = 0; i < parCount; i++)
        {
            GameObject g = Instantiate(par,
                transform.position,
                Quaternion.Euler(Random.Range(-360,360),
                Random.Range(-360, 360),
                Random.Range(-360, 360)
                ))as GameObject;
            float fireSpeed = Random.Range(fireParSpeedMin,fireParSpeedMax);
            g.GetComponent<Rigidbody>().AddForce(g.transform.up*fireSpeed);
        }
        //增加分数
        GameManager.Instance.AddScore();

        Destroy(gameObject);
    }




















}
