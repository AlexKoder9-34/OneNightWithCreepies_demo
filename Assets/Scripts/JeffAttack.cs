using System;
using System.Collections;
using UnityEngine;

public class JeffAttack : MonoBehaviour
{
   [SerializeField] PlayJeffScreamerSound jeffScreamerSound;
   private Animator _attackAnimator;

   private void Awake()
   {
      _attackAnimator =  GetComponent<Animator>();
   }

   private void PlayJeffAttackAnimation()
   {
      StartCoroutine(JeffAttackCoroutine());
   }

   IEnumerator JeffAttackCoroutine()
   {
      _attackAnimator.enabled = true;
      jeffScreamerSound.PlayJeffScreamerClip();
      _attackAnimator.Play("JumpAttack");
      yield return new WaitForSeconds(1f);
      GameEvents.OnPlayerDead?.Invoke();
   }
   
   private void OnEnable()
   {
      JeffAttackController.OnJeffAttack += PlayJeffAttackAnimation;
   }

   private void OnDisable()
   {
      JeffAttackController.OnJeffAttack -= PlayJeffAttackAnimation;
   }
}
