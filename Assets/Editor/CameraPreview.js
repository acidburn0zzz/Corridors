#pragma strict
     
    class CameraPreview extends EditorWindow {
    var camera : Camera = Camera.main;
    var renderTexture : RenderTexture;
     
    @MenuItem("Window/Preview Selected Camera #c")
     
    static function Init () {
    var editorWindow : EditorWindow = GetWindow(typeof(CameraPreview));
    editorWindow.autoRepaintOnSceneChange = true;
    editorWindow.Show();
    editorWindow.title = "Camera Preview";
    }
     
    function Awake () {
    CreateRenderTexture();
    }
     
    function Update () {
    if(camera != null) {
    camera.targetTexture = renderTexture;
    camera.Render();
    camera.targetTexture = null;
    }
    if(renderTexture.width != position.width || renderTexture.height != position.height)
    renderTexture = new RenderTexture(position.width, position.height, RenderTextureFormat.ARGB32);
    }
     
    function OnSelectionChange () {
    var obj : GameObject = Selection.activeGameObject;
    if (obj!=null && obj.camera) camera = obj.camera;
    CreateRenderTexture();
    }
     
    function CreateRenderTexture () {
    renderTexture = new RenderTexture(position.width, position.height, RenderTextureFormat.ARGB32);
    }
     
    function OnGUI () {
    GUI.DrawTexture(new Rect(.0, .0, position.width, position.height), renderTexture);
    }
    }