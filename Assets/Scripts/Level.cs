using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private const float CAMERA_ORTHO_SIZE = 50f;
    private const float PIPE_WIDTH = 9f;
    private const float PIPE_HEAD_HEIGHT = 0.75f;

    private void Start() {
        CreatePipe(40f, 20f, true);
        CreatePipe(40f, 20f, false);
    }

    private void CreatePipe(float height, float xPosition, bool bottom) {
        Transform pipeHead = Instantiate(GameAssets.GetInstance().pfPipeHead);
        pipeHead.position = new Vector3(xPosition, -CAMERA_ORTHO_SIZE + height - (PIPE_HEAD_HEIGHT / 2f));
        
        pipeHead.position = new Vector3(
            xPosition,
            bottom ? -CAMERA_ORTHO_SIZE + height - (PIPE_HEAD_HEIGHT / 2f) : CAMERA_ORTHO_SIZE - height + (PIPE_HEAD_HEIGHT / 2f)
        );

        Transform pipeBody = Instantiate(GameAssets.GetInstance().pfPipeBody);
        float pipeBodyYPos;
        if(bottom){
            pipeBodyYPos = -CAMERA_ORTHO_SIZE;
        }else{
            pipeBodyYPos = CAMERA_ORTHO_SIZE;
            pipeBody.localScale = new Vector3(1, -1, 1);
        }
        pipeBody.position = new Vector3(xPosition, pipeBodyYPos);

        SpriteRenderer pipeBodySpriteRenderer = pipeBody.GetComponent<SpriteRenderer>();
        pipeBodySpriteRenderer.size = new Vector2(PIPE_WIDTH, height);

        BoxCollider2D pipeBodyBoxCollider = pipeBody.GetComponent<BoxCollider2D>();
        pipeBodyBoxCollider.size = new Vector2(PIPE_WIDTH, height);
        pipeBodyBoxCollider.offset = new Vector2(xPosition, height / 2f);
    }
}
