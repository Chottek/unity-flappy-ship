using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private const float CAMERA_ORTHO_SIZE = 50f;
    private const float PIPE_WIDTH = 9f;
    private const float PIPE_HEAD_HEIGHT = 0.75f;
    private const float PIPE_MOVE_SPEED = 30f;
    private const float PIPE_DESTROY_X_POS = -100f;
    private const float PIPE_SPAWN_X_POS = 100f;

    private List<Pipe> pipeList;
    private float pipeSpawnTimer;
    private float pipeSpawnDelay;
    private float gapSize;

    private void Awake() {
        pipeList = new List<Pipe>();
        pipeSpawnDelay = 1.5f;
        gapSize = 50f;
    }

    private void Start() {

    }

    private void Update() {
       HandlePipeMovement();
       HandlePipeSpawning();
    }

    private void HandlePipeSpawning() {
        pipeSpawnTimer -= Time.deltaTime;
        if(pipeSpawnTimer < 0) {
            pipeSpawnTimer = pipeSpawnDelay;

            float heightEdgeLimit = 10f;
            float minHeight = gapSize / 2f + heightEdgeLimit;
            float totalHeight = CAMERA_ORTHO_SIZE * 2f;
            float maxHeight = totalHeight - gapSize / 2f - heightEdgeLimit;

            float height = UnityEngine.Random.Range(minHeight, maxHeight);
            CreateGapPipes(height, gapSize, PIPE_SPAWN_X_POS);
        }
    }

    private void HandlePipeMovement() {
        for(int i = 0; i < pipeList.Count; i++) {
            Pipe p = pipeList[i];
            p.Move();
            if (p.GetXPos() < PIPE_DESTROY_X_POS) {
                p.DestroyThis();
                pipeList.Remove(p);
                i--;
            }
        }
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

        pipeList.Add(new Pipe(pipeHead, pipeBody));
    }

    private void CreateGapPipes(float gapY, float gapSize, float xPosition) {
        CreatePipe(gapY - gapSize / 2f, xPosition, true);
        CreatePipe(CAMERA_ORTHO_SIZE * 2f - gapY - gapSize / 2f, xPosition, false);
    }

    /**
    * Represents a single Pipe position
    */
    private class Pipe {
        
        private Transform pipeHeadTransform;
        private Transform pipeBodyTransform;

        public Pipe(Transform pipeHeadTransform, Transform pipeBodyTransform){
            this.pipeHeadTransform = pipeHeadTransform;
            this.pipeBodyTransform = pipeBodyTransform;
        }

        public void Move() {
             pipeHeadTransform.position += new Vector3(-1, 0, 0) * PIPE_MOVE_SPEED * Time.deltaTime;
             pipeBodyTransform.position += new Vector3(-1, 0, 0) * PIPE_MOVE_SPEED * Time.deltaTime;
        }

        public float GetXPos() {
            return pipeHeadTransform.position.x;
        }

        public void DestroyThis() {
            Destroy(pipeHeadTransform.gameObject);
            Destroy(pipeBodyTransform.gameObject);
        }
    }

}
