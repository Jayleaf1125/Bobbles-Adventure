using UnityEngine;

public class SizeTransitioner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public RuntimeAnimatorController controller1;
    public RuntimeAnimatorController controller2;
    public ShrinkingAndExpanding size;
    public Animator anim;
    public PlayerMovement player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void Blow()
    {
        player.Reset();
        anim.runtimeAnimatorController = controller2;
        anim.Rebind();
        anim.Update(0f);
        Debug.Log("blow");
        



    }

    public void Shrink()
    {
        player.Reset();

        anim.runtimeAnimatorController = controller1;
        anim.Rebind();
        anim.Update(0f);
        Debug.Log("shrink");

    }


}
