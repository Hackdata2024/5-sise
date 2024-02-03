using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public Image uifill;
    [SerializeField] public Text uitext;

    public int duration;
    public int remainingduration;
    // Start is called before the first frame update
    void Start()
    {
        being(duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void being(int second)
    {
        remainingduration = second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingduration >= 0)
        {
            uitext.text = $"{remainingduration / 60:00} : { remainingduration % 60:00}";
            uifill.fillAmount = Mathf.InverseLerp(0, duration, remainingduration);
            remainingduration --;
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    private void OnEnd()
    {
        print("end");
    }
}
