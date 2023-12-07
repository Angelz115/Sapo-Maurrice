using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sa : MonoBehaviour
{
    public PlayerInput pla;
    public List<TextAsset> dias = new List<TextAsset>();
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("SocializandoPref") == 1)
        {
            DialogeManager.Instance.EnterDialogueMode(dias[GameManager.Instance.dias]);
            
        }
    }

    
}
