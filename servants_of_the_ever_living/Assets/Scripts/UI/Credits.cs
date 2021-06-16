using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject CreditsUI;
    //Display Credits
    public void DisplayCredits()
    {
        CreditsUI.SetActive(true);
    }

    //Hide credits
    public void HideCredits()
    {
        CreditsUI.SetActive(false);
    }
   
}
