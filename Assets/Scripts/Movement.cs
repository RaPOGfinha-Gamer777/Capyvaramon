using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject inventoy;

    public float tileSize = 1f;
    public float moveSpeed = 5f;

    public LayerMask obstacleLayer;

    private bool isMoving = false;
    private Vector3 targetPosition;

    private void Update()
    {
        if (!inventoy.activeSelf)
        {
            if (isMoving) return;

            Vector3 input = Vector3.zero;

            if (Input.GetKey(KeyCode.W)) input = Vector3.up;
            if (Input.GetKey(KeyCode.S)) input = Vector3.down;
            if (Input.GetKey(KeyCode.A)) input = Vector3.left;
            if (Input.GetKey(KeyCode.D)) input = Vector3.right;

            if (input != Vector3.zero && CanMove(input))
            {
                StartCoroutine(MoveToTile(input));
            }
        }    
    }

    private bool CanMove(Vector3 direction)
    {
        Vector3 nextPosition = transform.position + direction * tileSize;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, tileSize, obstacleLayer);

        if (hit.collider != null)
        {
            if (hit.collider.tag.Contains("Capybara"))
            {
                SaveCapybaraData(hit);
            }          
        }

        return hit.collider == null;
    }

    private IEnumerator MoveToTile(Vector3 direction)
    {
        isMoving = true;
        targetPosition = transform.position + direction * tileSize;

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }

    void SaveCapybaraData(RaycastHit2D capybaraCollider)
    {
        WildData wildData = FindAnyObjectByType<WildData>();
        wildData.GetCapybaraStats(capybaraCollider);

        LoadBattleScene();
    }

    void LoadBattleScene()
    {
        PlayerData playerData = FindAnyObjectByType<PlayerData>();
        playerData.positionInGameScene = transform.position;

        SceneManager.LoadScene("BattleScene");
    }
}
