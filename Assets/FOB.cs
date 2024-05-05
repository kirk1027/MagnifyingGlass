using UnityEngine;

public class MirrorCameraAdjuster : MonoBehaviour
{
    public Camera mirrorCamera; // ���p�̃J����
    public Transform mirror; // ���I�u�W�F�N�g
    public float initialMirrorHeight = 1.0f; // ���̏����̍���
    public float initialDistance = 1.0f; // �J�����̏�������

    void Start()
    {
        // �����̋��̍����ƃJ�����̋�����ۑ�
        initialMirrorHeight = mirror.localScale.y;
        initialDistance = Vector3.Distance(mirrorCamera.transform.position, mirror.position);
    }

    void Update()
    {
        // ���̃X�P�[�����ύX���ꂽ�Ƃ��̔䗦���v�Z
        float scaleRatio = mirror.localScale.y / initialMirrorHeight;

        // �J�����̎���p�𒲐�
        mirrorCamera.fieldOfView = 60 * scaleRatio; // ������60�͏�������p

        // �J�����̈ʒu��������̋�����ۂ��Ȃ��璲��
        mirrorCamera.transform.position = mirror.position - mirrorCamera.transform.forward * (initialDistance * scaleRatio);
    }
}
