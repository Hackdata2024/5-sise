using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Michsky.UI.Heat;

public class Timer : MonoBehaviour , IPointerClickHandler 

   
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Pause = !Pause;
    }




    [SerializeField] public Image uifill;
    [SerializeField] public Text uitext;
    [SerializeField] public GameObject Inhale;
    [SerializeField] public GameObject Exhale;
    [SerializeField] public GameObject Hold;

    public int duration;
    public int remainingduration;
    private bool Pause;
    public int time = 1;
    // Start is called before the first frame update
    void Start()
    {
        being(duration);
    }

    // Update is called once per frame
    void Update()
    {
        //Display();
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
                if (time < 16 && time > 12)
                {
                    Exhale.SetActive(false);
                    Hold.SetActive(true);

                }
                else if (time >8  && time < 12)
                {
                    Exhale.SetActive(true) ;
                    Hold.SetActive(false);
                }

                else if (time > 4 && time < 8)
                {
                  Inhale.SetActive(false);
                  Hold.SetActive(true);
                }
                else if (time > 0  && time < 4)
                {
                    Inhale.SetActive(true) ;
                }

                time++;
                yield return new WaitForSeconds(1f);
        }
        yield return null;
        OnEnd();
    }

   /* private void Display()
    {
        while (time < 17)
        {
            if (time < 4)
            {
                Inhale.SetActive(true);

            }
            else if (time > 4 && time < 8 )
            {
                Inhale.SetActive(false);
                Hold.SetActive(true);
            }

            else if (time > 8 && time < 12)
            {
                
                
                Hold.SetActive(false);
                Exhale.SetActive(true);
            }
            else if (time > 12 && time < 16)
            {
                Exhale.SetActive(false);
                Hold.SetActive(true) ;
            }
            time++;
        }
        
    }*/

    private void OnEnd()
    {
        print("end");
    }
}
