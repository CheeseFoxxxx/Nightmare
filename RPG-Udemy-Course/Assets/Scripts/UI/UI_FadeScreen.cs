using UnityEngine;

public class UI_FadeScreen : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeOut() 
    {
        if (anim != null)
        {
            
            anim.SetTrigger("FadeOut");
        }
    }
    public void FadeIn() 
    {
        if (anim != null)
        {
            
            anim.SetTrigger("FadeIn");            
        }
    }
}
