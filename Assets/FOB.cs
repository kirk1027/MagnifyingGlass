using UnityEngine;

public class MirrorCameraAdjuster : MonoBehaviour
{
    public Camera mirrorCamera; // 鏡用のカメラ
    public Transform mirror; // 鏡オブジェクト
    public float initialMirrorHeight = 1.0f; // 鏡の初期の高さ
    public float initialDistance = 1.0f; // カメラの初期距離

    void Start()
    {
        // 初期の鏡の高さとカメラの距離を保存
        initialMirrorHeight = mirror.localScale.y;
        initialDistance = Vector3.Distance(mirrorCamera.transform.position, mirror.position);
    }

    void Update()
    {
        // 鏡のスケールが変更されたときの比率を計算
        float scaleRatio = mirror.localScale.y / initialMirrorHeight;

        // カメラの視野角を調整
        mirrorCamera.fieldOfView = 60 * scaleRatio; // ここで60は初期視野角

        // カメラの位置を鏡からの距離を保ちながら調整
        mirrorCamera.transform.position = mirror.position - mirrorCamera.transform.forward * (initialDistance * scaleRatio);
    }
}
