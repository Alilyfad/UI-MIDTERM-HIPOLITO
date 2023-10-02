using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonsManager : MonoBehaviour
{
    public Image imageToScale;

    public RectTransform leafToFlip, leafToFlyLeft, leafToSwingUp, leafToSlideLeft, leafToPulse, leafToShake;

    private bool isZoomOut = false;

    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = isZoomOut ? 1.0f : zoomVal;
        imageToScale.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void FlipHorizontal()
    {
        leafToFlip.DOScaleX(-1f, 0f);
        leafToFlip.DOScaleX(1f, 0.5f).SetEase(Ease.InOutQuad);
    }

    public void FlyLeft()
    {
        float targetX = -1000f;
        leafToFlyLeft.DOAnchorPosX(targetX, 1f).SetEase(Ease.InOutQuad).OnComplete(() => ResetPositionFly());
    }

    private void ResetPositionFly()
    {
        float originalX = 0f;
        leafToFlyLeft.anchoredPosition = new Vector2(originalX, leafToFlyLeft.anchoredPosition.y);
    }

    public void SwingUp()
    {
        float targetRotation = 15f;
        leafToSwingUp.DORotate(new Vector3(0f, 0f, targetRotation), 0.5f).SetEase(Ease.InOutQuad).OnComplete(() => ResetRotation());
    }

    private void ResetRotation()
    {
        leafToSwingUp.localRotation = Quaternion.identity;
    }

    public void SlideLeft()
    {
        float targetX = -1000f;
        leafToSlideLeft.DOAnchorPosX(targetX, 0.5f).SetEase(Ease.InOutQuad).OnComplete(() => ResetPositionSlide());
    }

    private void ResetPositionSlide()
    {
        float originalX = 0f;
        leafToSlideLeft.anchoredPosition = new Vector2(originalX, leafToSlideLeft.anchoredPosition.y);
    }

    public void Pulse()
    {
        float pulseScale = 1.2f;
        leafToPulse.DOScale(new Vector3(pulseScale, pulseScale, 1f), 0.5f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }

    public void Shake()
    {
        float shakeIntensity = 20f;
        float shakeDuration = 0.5f;
        leafToShake.DOShakePosition(shakeDuration, shakeIntensity, 10, 90).SetEase(Ease.InOutQuad);
    }
}
