using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private const float PIPE_WIDTH = 1.56f;
    private const float PIPE_HEAD_HEIGHT = 0.75f;

    private void Start() {
        CreatePipe(50f, 0f);
        CreatePipe(50f, 20f);
    }

    private void CreatePipe(float height, float xPosition) {
        Transform pipeHead = Instantiate(GameAssets.GetInstance().pfPipeHead);
        pipeHead.position = new Vector3(xPosition, height - (PIPE_HEAD_HEIGHT / 2f));

        Transform pipeBody = Instantiate(GameAssets.GetInstance().pfPipeBody);
        pipeBody.position = new Vector3(xPosition, 0f);

        SpriteRenderer pipeBodySpriteRenderer = pipeBody.GetComponent<SpriteRenderer>();
        pipeBodySpriteRenderer.size = new Vector2(PIPE_WIDTH, height);
    }
}
