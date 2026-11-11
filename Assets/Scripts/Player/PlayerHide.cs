using UnityEngine;
using DG.Tweening;

public class PlayerHide : MonoBehaviour
{
    [SerializeField]private PlayerController playerController;
    
    private Sequence _hideSequence;
    private bool _isHidden;
    private bool _isAnimating;

    public bool IsHidden() => _isHidden;

    private void Awake()
    {
        // _playerController =  GetComponent<PlayerController>();
        
    }
    
    private void RuleSequence()
    {
        _hideSequence = DOTween.Sequence();
        _hideSequence.Join(transform.DOMoveY(7.2f, 0.5f));
        _hideSequence.Join(transform.DOScaleY(1.03f, 0.5f));
        _hideSequence.Append(transform.DOMove(new Vector3(-128f, 7.2f, 200f), 0.5f));
        
        _hideSequence.SetAutoKill(false);
        _hideSequence.Pause();
        
        _hideSequence.OnComplete(() =>
        {
            _isAnimating = false;
        });

        _hideSequence.OnRewind(() =>
        {
            _isAnimating = false;
            playerController.UnlockMoveInput();
            playerController.UnlockPlayerMovement();
            _hideSequence.Kill();
        });
    }
    public void Hide()
    {
        RuleSequence();
        playerController.LockMoveInput(); 
        playerController.LockPlayerMovement();
        
        if (_hideSequence != null && _isAnimating)
            return;
        
        _isHidden = true;
        _isAnimating = true;
        
        _hideSequence.PlayForward();
    }
    public void Show()
    {
        if ( _isAnimating && _hideSequence != null)
            return;
        
        _isHidden = false;
        _isAnimating = true;
        
        _hideSequence.PlayBackwards();
    }

    public void HidePlayer()
    {
        _isHidden = true;
    }

    public void ShowPlayer()
    {
        _isHidden = false;
    }
}
