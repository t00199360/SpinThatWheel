using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpinTheWheel : MonoBehaviour
{
    public List<string> prize;
    public List<string> passed_prizes;
    public List<AnimationCurve> animationCurves;

    private bool spinning;
    private float anglePerItem;
    private int randomTime;
    private int itemNumber;
    public int numberOfSpins;
    GameObject obj;
    

    void Start()
    {
        numberOfSpins = 0;
        passed_prizes = UserDefinedGames.GameList;
        Debug.Log(UserDefinedGames.GameList.Count + " :is the size of the list passed");
        
        int i = 0;
        while(i<12)
        {
            prize[i] = passed_prizes[i];
            i++;
        }
        

        spinning = false;
        anglePerItem = 360 / prize.Count;
    }


    void Update()
    {
        if (Input.touchCount > 0 && !spinning)
        {
            randomTime = Random.Range(1, 4);
            itemNumber = Random.Range(0, prize.Count);
            float maxAngle = 360 * randomTime + (itemNumber * anglePerItem);

            StartCoroutine(SpinWheelClockwise(5 * randomTime, maxAngle));
            
        }
    }


    IEnumerator SpinWheelClockwise(float time, float maxAngle)
    {
        numberOfSpins++;
        Social.ReportScore(numberOfSpins, "CgkIiMHV2twCEAIQAA", success => { });
        spinning = true;
        Social.ReportProgress("CgkIiMHV2twCEAIQAQ", 100, success => { });
        float timer = 0.0f;
        float startAngle = transform.eulerAngles.x;
        maxAngle = maxAngle - startAngle;

        int animationCurveNumber = Random.Range(0, animationCurves.Count);
        Debug.Log("Animation Curve No. : " + animationCurveNumber);

        while (timer < time)
        {
            //to calculate rotation
            float angle = maxAngle * animationCurves[animationCurveNumber].Evaluate(timer / time);
            transform.eulerAngles = new Vector3(angle + startAngle ,270.0f , 270.0f);
            timer += Time.deltaTime;
            yield return 0;
        }

        transform.eulerAngles = new Vector3( maxAngle + startAngle,270.0f, 270.0f );
        spinning = false;
        numberOfSpins++;
        Debug.Log("Prize: " + prize[itemNumber]);//use prize[itemNumber] as per requirement
    }
}
