using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{




    public GameObject ufo;
    public float fireTime = 2;
    Transform fireTrans;
    public float fireSpeed = 200;
    Transform ground;
    public static Launcher Instance;
    

    private void Awake()
    {
        Instance = this;
        ground = GameObject.FindGameObjectWithTag("Ground").transform;
        fireTrans = transform.GetChild(0);

        
    }

    private void Start()
    {
        
        FireUFO();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray thisRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(thisRay,out hitInfo))
            {
                if (hitInfo.transform.tag=="UFO")
                {
                    hitInfo.transform.GetComponent<UFO>().Death();
                }

            }
        }

    }

    public void FireUFO()
    {

        StartCoroutine(FireUFOI());

    }

    IEnumerator FireUFOI()
    {

        yield return new WaitForSeconds(2);
        for (int i = 0; i < GameManager.Instance.curLevelTargetScore; i++)
        {
            int addFireSpeed = Random.Range(0,100);
            int fireIndex = Random.Range(0, fireTrans.childCount);
            GameObject g = Instantiate(ufo, fireTrans.GetChild(fireIndex).position,
                Quaternion.identity) as GameObject;
            //¼ÓÈëGround
            g.transform.SetParent(ground);
            if (ground.Find("Empty"))
            {
                Destroy(ground.Find("Empty").gameObject);
            }
            g.GetComponent<Rigidbody>().AddForce(
                fireTrans.GetChild(fireIndex).up
                *(fireSpeed+addFireSpeed));
            yield return new WaitForSeconds(0.3f);
        }
        ground.GetComponent<Ground>().isCanJudge = true;


    }



























}
