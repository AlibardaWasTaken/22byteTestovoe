using UnityEngine;

public class GridGroundResizer : MonoBehaviour
{
    [SerializeField]
    private int _rows;

    [SerializeField]
    private int _colums;





    public static GridGroundResizer Instance;

    public int Rows { get => _rows; }
    public int Colums { get => _colums; }

    void Awake()
    {
        if (Instance != null) Destroy(this);

        Instance = this;
    }

    private void Start()
    {
        this.transform.localScale = new Vector3(_rows, 10f, _colums);

        Renderer renderer = GetComponent<Renderer>();

        MaterialPropertyBlock mpb = new MaterialPropertyBlock();

        mpb.SetVector("_MainTex_ST", new Vector4(_rows, _colums, (_rows / 10f) / 2f, (_colums / 10f) / 2f));

        renderer.SetPropertyBlock(mpb);

        CreateWalls();
    }

    private void CreateWalls()
    {
        Vector3 cubeSize = this.transform.localScale;


        CreateWall(new Vector3(0.5f, 0.5f, 0), new Vector3(1, cubeSize.y, cubeSize.z)); // Right
        CreateWall(new Vector3(-0.5f, 0.5f, 0), new Vector3(1, cubeSize.y, cubeSize.z)); // Left
        CreateWall(new Vector3(0, 0.5f, 0.5f), new Vector3(cubeSize.x, cubeSize.y, 1)); // Front
        CreateWall(new Vector3(0, 0.5f, -0.5f), new Vector3(cubeSize.x, cubeSize.y, 1)); // Back
    }

    private void CreateWall(Vector3 position, Vector3 size)
    {
        GameObject wall = new GameObject("InvisibleWall");
        wall.transform.parent = this.transform;
        wall.transform.localPosition = position;
        wall.AddComponent<BoxCollider>().size = size;
    }
}