using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitsText : MonoBehaviour
{

    public TextMeshProUGUI hits;

    // Start is called before the first frame update
    void Update()
    {
        hits.text = PoopSpawn.poopHitCount.ToString();
    }
}
