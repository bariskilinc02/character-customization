using System.Collections;
using TMPro;
using UnityEngine;

public class LoadingPanel : MonoBehaviour
{
    private IEnumerator _routine;

    public TextMeshProUGUI loadingText;

    public GameObject panel;
    
    public void ShowPanel()
    {
        _routine = Animation();
        StartCoroutine(_routine);
    }
    
    public void HidePanel()
    {
        StopCoroutine(_routine);
        _routine = null;
        panel.SetActive(false);
    }

    private IEnumerator Animation()
    {
        panel.SetActive(true);
        while (true)
        {
            UpdateText();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void UpdateText()
    {
        int dotCount = loadingText.text.Length;
        if (dotCount >= 3)
        {
            dotCount = 0;
        }
        loadingText.text = "";
        for (int i = 0; i < dotCount+1; i++)
        {
            loadingText.text += ".";
        }
        
    }
}
