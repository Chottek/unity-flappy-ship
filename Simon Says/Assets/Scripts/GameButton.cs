using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButton : MonoBehaviour {

    [SerializeField]
    public int index;

    //seconds
    public float activeDuration = 0.3f;
    public float cooldownDuration = 0.1f;

    private void Awake(){
        extractIndexFromName();
    }

    void Update(){
       
    }

    public IEnumerator PlayBlinkRoutine(){
        setActive();
        yield return new WaitForSeconds(activeDuration);
        setInactive();
        yield return new WaitForSeconds(cooldownDuration);
    }

    public int GetIndex(){
        return index;
    }

    private void extractIndexFromName(){
        index = int.Parse(gameObject.name.Split('_')[1]);
    }

    private void setActive(){
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(124, 252, 0, 255);
    }

    private void setInactive(){
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
    }

   
    
}
