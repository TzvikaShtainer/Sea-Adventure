using DG.Tweening;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform menuPanel; 
    [SerializeField] private float animationDuration = 0.5f;
    [SerializeField] private Vector3 hiddenPosition = new Vector3(0, 0, 0); 
    [SerializeField] private Vector3 visiblePosition = new Vector3(0, 0, 0);
    [SerializeField] private float amplitude = 0.8f;
    [SerializeField] private float amplitudePeriod = 0.5f;
    
    private void Start()
    {
        menuPanel.anchoredPosition = hiddenPosition;
        
        ToggleMenu();
    }

    public void ToggleMenu()
    {
        menuPanel.DOAnchorPos(visiblePosition, animationDuration)
            .SetEase(Ease.OutElastic, amplitude, amplitudePeriod);  
    }   
}
