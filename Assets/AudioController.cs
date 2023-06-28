using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource; // �I�[�f�B�I�\�[�X�R���|�[�l���g�擾
    AudioClip audioclip;    // �I�[�f�B�I�N���b�v�ۑ�
    AudioClip[] bgmClip = new AudioClip[3]; // �I�[�f�B�I�N���b�v�ۑ�(3�ȕ�)

    AudioClip seClip;   // ���ʉ���ۑ�����ϐ�
    Vector3 sePos;      // ���ʉ����Đ�����ʒu��ۑ�����ϐ�

    // Start is called before the first frame update
    void Start()
    {
        seClip = Resources.Load<AudioClip>("Audio/SE/bomb");
        sePos = GameObject.Find("Main Camera").transform.position;

        //bgmClip[0] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit08");
        //bgmClip[1] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit10");
        //bgmClip[2] = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit11");
        string[] bgmName =
        {
            "Audio/BGM/bgm_maoudamashii_8bit08",    // bgmName[0]
            "Audio/BGM/bgm_maoudamashii_8bit10",    // bgmName[1]
            "Audio/BGM/bgm_maoudamashii_8bit11"     // bgmName[2]
        };
        for (int i = 0; i < 3; i++)
        {
            bgmClip[i] = Resources.Load<AudioClip>(bgmName[i]);
        }

        // Resources�t�H���_���ɕۑ�����Ă���Audio�t�H���_���ɕۑ�����Ă���
        // BGM�t�H���_���ɕۑ�����Ă���I�[�f�B�I�t�@�C����ǂݍ���
        audioclip = Resources.Load<AudioClip>("Audio/BGM/bgm_maoudamashii_8bit20");

        // �I�[�f�B�I�\�[�X�R���|�[�l���g���擾����
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = audioclip;

        // �I�[�f�B�I�\�[�X�ɓo�^����Ă���I�[�f�B�I�N���b�v���Đ�����
        //audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            audioSource.clip = bgmClip[0];

            audioSource.Play();
        }

        if (Input.GetKey(KeyCode.Z))
        {
            AudioSource.PlayClipAtPoint(seClip, sePos);
        }

    }
}