using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer; // where to show
    public GameObject textprefab; // what to show

    // list of all the text shown before
    private List<FloatingText> floatingtexts = new List<FloatingText>(); 
    private void Update()
    {
        foreach (FloatingText txt in floatingtexts)
        {
            txt.updatefloatingText();
        }
    }
    public void Show(string msg,int fontSize,Color color,Vector3 position, Vector3 motion,float duration)
    {
        FloatingText floatingtxt = GetFloatingText();

        floatingtxt.text.text = msg;
        floatingtxt.text.fontSize = fontSize;
        floatingtxt.text.color = color;
        //transfre world space to screen space to use in ui
        floatingtxt.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingtxt.motion = motion;
        floatingtxt.duration = duration;

        floatingtxt.Show();
    }

    private FloatingText GetFloatingText()
    {  
        /* for (int i = 0; i < floatingtexts.Count; i++)
        {
            if (!floatingtexts[i].isactive)
            {
                return floatingtexts[i];
            }
        } 
        OR
        */
        FloatingText txt = floatingtexts.Find(t => !t.isactive);
      
        if(txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textprefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.text = txt.go.GetComponent<Text>();

            floatingtexts.Add(txt);
        }

        return txt;

    }

 

}
