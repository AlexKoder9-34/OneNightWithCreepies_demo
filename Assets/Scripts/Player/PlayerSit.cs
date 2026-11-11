using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CharacterController))]
public class PlayerSit : MonoBehaviour
{
    private bool _isStanding = false;
    private CharacterController _characterController;

    [SerializeField] private Transform cameraPivot;

    [SerializeField] private float crouchHeight = 1f;
    [SerializeField] private float standHeight = 2f;

    [SerializeField] private float crouchCameraY = 0.8f;
    [SerializeField] private float animationDuration = 0.2f;

    private float _standCameraY;

    private Sequence _sitSequence;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

        _standCameraY = cameraPivot.localPosition.y;
    }

    public void ChangePlayerState()
    {
        _isStanding = !_isStanding;

        if (_isStanding)
        {
            Crouch();
        }
        else
        {
            Stand();
        }
    }

    private void Crouch()
    {
        _sitSequence?.Kill();

        _sitSequence = DOTween.Sequence();

        _sitSequence.Join(
            DOTween.To(
                () => _characterController.height,
                value => _characterController.height = value,
                crouchHeight,
                animationDuration
            )
        );

        _sitSequence.Join(
            DOTween.To(
                () => _characterController.center.y,
                value =>
                {
                    Vector3 center = _characterController.center;
                    center.y = value;
                    _characterController.center = center;
                },
                -0.5f,
                animationDuration
            )
        );

        _sitSequence.Join(
            cameraPivot.DOLocalMoveY(crouchCameraY, animationDuration)
        );
    }

    private void Stand()
    {
        _sitSequence?.Kill();

        _sitSequence = DOTween.Sequence();

        _sitSequence.Join(
            DOTween.To(
                () => _characterController.height,
                value => _characterController.height = value,
                standHeight,
                animationDuration
            )
        );

        _sitSequence.Join(
            DOTween.To(
                () => _characterController.center.y,
                value =>
                {
                    Vector3 center = _characterController.center;
                    center.y = value;
                    _characterController.center = center;
                },
                0f,
                animationDuration
            )
        );

        _sitSequence.Join(
            cameraPivot.DOLocalMoveY(_standCameraY, animationDuration)
        );
    }

    private void OnDestroy()
    {
        _sitSequence?.Kill();
    }
}