extern "C" void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_SharedInternals();
	RegisterModule_SharedInternals();

	void RegisterModule_Core();
	RegisterModule_Core();

	void RegisterModule_AI();
	RegisterModule_AI();

	void RegisterModule_Animation();
	RegisterModule_Animation();

	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_Director();
	RegisterModule_Director();

	void RegisterModule_Grid();
	RegisterModule_Grid();

	void RegisterModule_ImageConversion();
	RegisterModule_ImageConversion();

	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

	void RegisterModule_Input();
	RegisterModule_Input();

	void RegisterModule_InputLegacy();
	RegisterModule_InputLegacy();

	void RegisterModule_JSONSerialize();
	RegisterModule_JSONSerialize();

	void RegisterModule_ParticleSystem();
	RegisterModule_ParticleSystem();

	void RegisterModule_Physics();
	RegisterModule_Physics();

	void RegisterModule_Physics2D();
	RegisterModule_Physics2D();

	void RegisterModule_RuntimeInitializeOnLoadManagerInitializer();
	RegisterModule_RuntimeInitializeOnLoadManagerInitializer();

	void RegisterModule_ScreenCapture();
	RegisterModule_ScreenCapture();

	void RegisterModule_Subsystems();
	RegisterModule_Subsystems();

	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

	void RegisterModule_TextCoreFontEngine();
	RegisterModule_TextCoreFontEngine();

	void RegisterModule_TextCoreTextEngine();
	RegisterModule_TextCoreTextEngine();

	void RegisterModule_Tilemap();
	RegisterModule_Tilemap();

	void RegisterModule_TLS();
	RegisterModule_TLS();

	void RegisterModule_UI();
	RegisterModule_UI();

	void RegisterModule_UIElementsNative();
	RegisterModule_UIElementsNative();

	void RegisterModule_UIElements();
	RegisterModule_UIElements();

	void RegisterModule_UnityWebRequest();
	RegisterModule_UnityWebRequest();

	void RegisterModule_Vehicles();
	RegisterModule_Vehicles();

	void RegisterModule_Video();
	RegisterModule_Video();

	void RegisterModule_VR();
	RegisterModule_VR();

	void RegisterModule_WebGL();
	RegisterModule_WebGL();

	void RegisterModule_XR();
	RegisterModule_XR();

}

template <typename T> void RegisterUnityClass(const char*);
template <typename T> void RegisterStrippedType(int, const char*, const char*);

void InvokeRegisterStaticallyLinkedModuleClasses()
{
	// Do nothing (we're in stripping mode)
}

class NavMeshAgent; template <> void RegisterUnityClass<NavMeshAgent>(const char*);
class NavMeshProjectSettings; template <> void RegisterUnityClass<NavMeshProjectSettings>(const char*);
class NavMeshSettings; template <> void RegisterUnityClass<NavMeshSettings>(const char*);
class Animation; template <> void RegisterUnityClass<Animation>(const char*);
class AnimationClip; template <> void RegisterUnityClass<AnimationClip>(const char*);
class Animator; template <> void RegisterUnityClass<Animator>(const char*);
class AnimatorController; template <> void RegisterUnityClass<AnimatorController>(const char*);
class AnimatorOverrideController; template <> void RegisterUnityClass<AnimatorOverrideController>(const char*);
class Avatar; template <> void RegisterUnityClass<Avatar>(const char*);
class AvatarMask; template <> void RegisterUnityClass<AvatarMask>(const char*);
class Motion; template <> void RegisterUnityClass<Motion>(const char*);
class RuntimeAnimatorController; template <> void RegisterUnityClass<RuntimeAnimatorController>(const char*);
class AudioBehaviour; template <> void RegisterUnityClass<AudioBehaviour>(const char*);
class AudioClip; template <> void RegisterUnityClass<AudioClip>(const char*);
class AudioDistortionFilter; template <> void RegisterUnityClass<AudioDistortionFilter>(const char*);
class AudioEchoFilter; template <> void RegisterUnityClass<AudioEchoFilter>(const char*);
class AudioFilter; template <> void RegisterUnityClass<AudioFilter>(const char*);
class AudioHighPassFilter; template <> void RegisterUnityClass<AudioHighPassFilter>(const char*);
class AudioListener; template <> void RegisterUnityClass<AudioListener>(const char*);
class AudioLowPassFilter; template <> void RegisterUnityClass<AudioLowPassFilter>(const char*);
class AudioManager; template <> void RegisterUnityClass<AudioManager>(const char*);
class AudioMixer; template <> void RegisterUnityClass<AudioMixer>(const char*);
class AudioMixerGroup; template <> void RegisterUnityClass<AudioMixerGroup>(const char*);
class AudioMixerSnapshot; template <> void RegisterUnityClass<AudioMixerSnapshot>(const char*);
class AudioReverbFilter; template <> void RegisterUnityClass<AudioReverbFilter>(const char*);
class AudioSource; template <> void RegisterUnityClass<AudioSource>(const char*);
class SampleClip; template <> void RegisterUnityClass<SampleClip>(const char*);
class Behaviour; template <> void RegisterUnityClass<Behaviour>(const char*);
class BuildSettings; template <> void RegisterUnityClass<BuildSettings>(const char*);
class Camera; template <> void RegisterUnityClass<Camera>(const char*);
namespace Unity { class Component; } template <> void RegisterUnityClass<Unity::Component>(const char*);
class ComputeShader; template <> void RegisterUnityClass<ComputeShader>(const char*);
class Cubemap; template <> void RegisterUnityClass<Cubemap>(const char*);
class CubemapArray; template <> void RegisterUnityClass<CubemapArray>(const char*);
class DelayedCallManager; template <> void RegisterUnityClass<DelayedCallManager>(const char*);
class EditorExtension; template <> void RegisterUnityClass<EditorExtension>(const char*);
class FlareLayer; template <> void RegisterUnityClass<FlareLayer>(const char*);
class GameManager; template <> void RegisterUnityClass<GameManager>(const char*);
class GameObject; template <> void RegisterUnityClass<GameObject>(const char*);
class GlobalGameManager; template <> void RegisterUnityClass<GlobalGameManager>(const char*);
class GraphicsSettings; template <> void RegisterUnityClass<GraphicsSettings>(const char*);
class InputManager; template <> void RegisterUnityClass<InputManager>(const char*);
class LevelGameManager; template <> void RegisterUnityClass<LevelGameManager>(const char*);
class Light; template <> void RegisterUnityClass<Light>(const char*);
class LightingSettings; template <> void RegisterUnityClass<LightingSettings>(const char*);
class LightmapSettings; template <> void RegisterUnityClass<LightmapSettings>(const char*);
class LightProbes; template <> void RegisterUnityClass<LightProbes>(const char*);
class LineRenderer; template <> void RegisterUnityClass<LineRenderer>(const char*);
class LowerResBlitTexture; template <> void RegisterUnityClass<LowerResBlitTexture>(const char*);
class Material; template <> void RegisterUnityClass<Material>(const char*);
class Mesh; template <> void RegisterUnityClass<Mesh>(const char*);
class MeshFilter; template <> void RegisterUnityClass<MeshFilter>(const char*);
class MeshRenderer; template <> void RegisterUnityClass<MeshRenderer>(const char*);
class MonoBehaviour; template <> void RegisterUnityClass<MonoBehaviour>(const char*);
class MonoManager; template <> void RegisterUnityClass<MonoManager>(const char*);
class MonoScript; template <> void RegisterUnityClass<MonoScript>(const char*);
class NamedObject; template <> void RegisterUnityClass<NamedObject>(const char*);
class Object; template <> void RegisterUnityClass<Object>(const char*);
class PlayerSettings; template <> void RegisterUnityClass<PlayerSettings>(const char*);
class PreloadData; template <> void RegisterUnityClass<PreloadData>(const char*);
class QualitySettings; template <> void RegisterUnityClass<QualitySettings>(const char*);
namespace UI { class RectTransform; } template <> void RegisterUnityClass<UI::RectTransform>(const char*);
class ReflectionProbe; template <> void RegisterUnityClass<ReflectionProbe>(const char*);
class Renderer; template <> void RegisterUnityClass<Renderer>(const char*);
class RenderSettings; template <> void RegisterUnityClass<RenderSettings>(const char*);
class RenderTexture; template <> void RegisterUnityClass<RenderTexture>(const char*);
class ResourceManager; template <> void RegisterUnityClass<ResourceManager>(const char*);
class RuntimeInitializeOnLoadManager; template <> void RegisterUnityClass<RuntimeInitializeOnLoadManager>(const char*);
class Shader; template <> void RegisterUnityClass<Shader>(const char*);
class ShaderNameRegistry; template <> void RegisterUnityClass<ShaderNameRegistry>(const char*);
class Skybox; template <> void RegisterUnityClass<Skybox>(const char*);
class Sprite; template <> void RegisterUnityClass<Sprite>(const char*);
class SpriteAtlas; template <> void RegisterUnityClass<SpriteAtlas>(const char*);
class SpriteRenderer; template <> void RegisterUnityClass<SpriteRenderer>(const char*);
class TagManager; template <> void RegisterUnityClass<TagManager>(const char*);
class TextAsset; template <> void RegisterUnityClass<TextAsset>(const char*);
class Texture; template <> void RegisterUnityClass<Texture>(const char*);
class Texture2D; template <> void RegisterUnityClass<Texture2D>(const char*);
class Texture2DArray; template <> void RegisterUnityClass<Texture2DArray>(const char*);
class Texture3D; template <> void RegisterUnityClass<Texture3D>(const char*);
class TimeManager; template <> void RegisterUnityClass<TimeManager>(const char*);
class TrailRenderer; template <> void RegisterUnityClass<TrailRenderer>(const char*);
class Transform; template <> void RegisterUnityClass<Transform>(const char*);
class PlayableDirector; template <> void RegisterUnityClass<PlayableDirector>(const char*);
class Grid; template <> void RegisterUnityClass<Grid>(const char*);
class GridLayout; template <> void RegisterUnityClass<GridLayout>(const char*);
class ParticleSystem; template <> void RegisterUnityClass<ParticleSystem>(const char*);
class ParticleSystemRenderer; template <> void RegisterUnityClass<ParticleSystemRenderer>(const char*);
class BoxCollider; template <> void RegisterUnityClass<BoxCollider>(const char*);
class CapsuleCollider; template <> void RegisterUnityClass<CapsuleCollider>(const char*);
class CharacterController; template <> void RegisterUnityClass<CharacterController>(const char*);
class Collider; template <> void RegisterUnityClass<Collider>(const char*);
namespace Unity { class Joint; } template <> void RegisterUnityClass<Unity::Joint>(const char*);
class MeshCollider; template <> void RegisterUnityClass<MeshCollider>(const char*);
class PhysicsManager; template <> void RegisterUnityClass<PhysicsManager>(const char*);
class Rigidbody; template <> void RegisterUnityClass<Rigidbody>(const char*);
class SphereCollider; template <> void RegisterUnityClass<SphereCollider>(const char*);
namespace Unity { class SpringJoint; } template <> void RegisterUnityClass<Unity::SpringJoint>(const char*);
class BoxCollider2D; template <> void RegisterUnityClass<BoxCollider2D>(const char*);
class CircleCollider2D; template <> void RegisterUnityClass<CircleCollider2D>(const char*);
class Collider2D; template <> void RegisterUnityClass<Collider2D>(const char*);
class CompositeCollider2D; template <> void RegisterUnityClass<CompositeCollider2D>(const char*);
class Physics2DSettings; template <> void RegisterUnityClass<Physics2DSettings>(const char*);
class PolygonCollider2D; template <> void RegisterUnityClass<PolygonCollider2D>(const char*);
class Rigidbody2D; template <> void RegisterUnityClass<Rigidbody2D>(const char*);
namespace TextRendering { class Font; } template <> void RegisterUnityClass<TextRendering::Font>(const char*);
namespace TextRenderingPrivate { class TextMesh; } template <> void RegisterUnityClass<TextRenderingPrivate::TextMesh>(const char*);
class Tilemap; template <> void RegisterUnityClass<Tilemap>(const char*);
class TilemapRenderer; template <> void RegisterUnityClass<TilemapRenderer>(const char*);
namespace UI { class Canvas; } template <> void RegisterUnityClass<UI::Canvas>(const char*);
namespace UI { class CanvasGroup; } template <> void RegisterUnityClass<UI::CanvasGroup>(const char*);
namespace UI { class CanvasRenderer; } template <> void RegisterUnityClass<UI::CanvasRenderer>(const char*);
class WheelCollider; template <> void RegisterUnityClass<WheelCollider>(const char*);
class VideoPlayer; template <> void RegisterUnityClass<VideoPlayer>(const char*);

void RegisterAllClasses()
{
void RegisterBuiltinTypes();
RegisterBuiltinTypes();
	//Total: 114 non stripped classes
	//0. NavMeshAgent
	RegisterUnityClass<NavMeshAgent>("AI");
	//1. NavMeshProjectSettings
	RegisterUnityClass<NavMeshProjectSettings>("AI");
	//2. NavMeshSettings
	RegisterUnityClass<NavMeshSettings>("AI");
	//3. Animation
	RegisterUnityClass<Animation>("Animation");
	//4. AnimationClip
	RegisterUnityClass<AnimationClip>("Animation");
	//5. Animator
	RegisterUnityClass<Animator>("Animation");
	//6. AnimatorController
	RegisterUnityClass<AnimatorController>("Animation");
	//7. AnimatorOverrideController
	RegisterUnityClass<AnimatorOverrideController>("Animation");
	//8. Avatar
	RegisterUnityClass<Avatar>("Animation");
	//9. AvatarMask
	RegisterUnityClass<AvatarMask>("Animation");
	//10. Motion
	RegisterUnityClass<Motion>("Animation");
	//11. RuntimeAnimatorController
	RegisterUnityClass<RuntimeAnimatorController>("Animation");
	//12. AudioBehaviour
	RegisterUnityClass<AudioBehaviour>("Audio");
	//13. AudioClip
	RegisterUnityClass<AudioClip>("Audio");
	//14. AudioDistortionFilter
	RegisterUnityClass<AudioDistortionFilter>("Audio");
	//15. AudioEchoFilter
	RegisterUnityClass<AudioEchoFilter>("Audio");
	//16. AudioFilter
	RegisterUnityClass<AudioFilter>("Audio");
	//17. AudioHighPassFilter
	RegisterUnityClass<AudioHighPassFilter>("Audio");
	//18. AudioListener
	RegisterUnityClass<AudioListener>("Audio");
	//19. AudioLowPassFilter
	RegisterUnityClass<AudioLowPassFilter>("Audio");
	//20. AudioManager
	RegisterUnityClass<AudioManager>("Audio");
	//21. AudioMixer
	RegisterUnityClass<AudioMixer>("Audio");
	//22. AudioMixerGroup
	RegisterUnityClass<AudioMixerGroup>("Audio");
	//23. AudioMixerSnapshot
	RegisterUnityClass<AudioMixerSnapshot>("Audio");
	//24. AudioReverbFilter
	RegisterUnityClass<AudioReverbFilter>("Audio");
	//25. AudioSource
	RegisterUnityClass<AudioSource>("Audio");
	//26. SampleClip
	RegisterUnityClass<SampleClip>("Audio");
	//27. Behaviour
	RegisterUnityClass<Behaviour>("Core");
	//28. BuildSettings
	RegisterUnityClass<BuildSettings>("Core");
	//29. Camera
	RegisterUnityClass<Camera>("Core");
	//30. Component
	RegisterUnityClass<Unity::Component>("Core");
	//31. ComputeShader
	RegisterUnityClass<ComputeShader>("Core");
	//32. Cubemap
	RegisterUnityClass<Cubemap>("Core");
	//33. CubemapArray
	RegisterUnityClass<CubemapArray>("Core");
	//34. DelayedCallManager
	RegisterUnityClass<DelayedCallManager>("Core");
	//35. EditorExtension
	RegisterUnityClass<EditorExtension>("Core");
	//36. FlareLayer
	RegisterUnityClass<FlareLayer>("Core");
	//37. GameManager
	RegisterUnityClass<GameManager>("Core");
	//38. GameObject
	RegisterUnityClass<GameObject>("Core");
	//39. GlobalGameManager
	RegisterUnityClass<GlobalGameManager>("Core");
	//40. GraphicsSettings
	RegisterUnityClass<GraphicsSettings>("Core");
	//41. InputManager
	RegisterUnityClass<InputManager>("Core");
	//42. LevelGameManager
	RegisterUnityClass<LevelGameManager>("Core");
	//43. Light
	RegisterUnityClass<Light>("Core");
	//44. LightingSettings
	RegisterUnityClass<LightingSettings>("Core");
	//45. LightmapSettings
	RegisterUnityClass<LightmapSettings>("Core");
	//46. LightProbes
	RegisterUnityClass<LightProbes>("Core");
	//47. LineRenderer
	RegisterUnityClass<LineRenderer>("Core");
	//48. LowerResBlitTexture
	RegisterUnityClass<LowerResBlitTexture>("Core");
	//49. Material
	RegisterUnityClass<Material>("Core");
	//50. Mesh
	RegisterUnityClass<Mesh>("Core");
	//51. MeshFilter
	RegisterUnityClass<MeshFilter>("Core");
	//52. MeshRenderer
	RegisterUnityClass<MeshRenderer>("Core");
	//53. MonoBehaviour
	RegisterUnityClass<MonoBehaviour>("Core");
	//54. MonoManager
	RegisterUnityClass<MonoManager>("Core");
	//55. MonoScript
	RegisterUnityClass<MonoScript>("Core");
	//56. NamedObject
	RegisterUnityClass<NamedObject>("Core");
	//57. Object
	//Skipping Object
	//58. PlayerSettings
	RegisterUnityClass<PlayerSettings>("Core");
	//59. PreloadData
	RegisterUnityClass<PreloadData>("Core");
	//60. QualitySettings
	RegisterUnityClass<QualitySettings>("Core");
	//61. RectTransform
	RegisterUnityClass<UI::RectTransform>("Core");
	//62. ReflectionProbe
	RegisterUnityClass<ReflectionProbe>("Core");
	//63. Renderer
	RegisterUnityClass<Renderer>("Core");
	//64. RenderSettings
	RegisterUnityClass<RenderSettings>("Core");
	//65. RenderTexture
	RegisterUnityClass<RenderTexture>("Core");
	//66. ResourceManager
	RegisterUnityClass<ResourceManager>("Core");
	//67. RuntimeInitializeOnLoadManager
	RegisterUnityClass<RuntimeInitializeOnLoadManager>("Core");
	//68. Shader
	RegisterUnityClass<Shader>("Core");
	//69. ShaderNameRegistry
	RegisterUnityClass<ShaderNameRegistry>("Core");
	//70. Skybox
	RegisterUnityClass<Skybox>("Core");
	//71. Sprite
	RegisterUnityClass<Sprite>("Core");
	//72. SpriteAtlas
	RegisterUnityClass<SpriteAtlas>("Core");
	//73. SpriteRenderer
	RegisterUnityClass<SpriteRenderer>("Core");
	//74. TagManager
	RegisterUnityClass<TagManager>("Core");
	//75. TextAsset
	RegisterUnityClass<TextAsset>("Core");
	//76. Texture
	RegisterUnityClass<Texture>("Core");
	//77. Texture2D
	RegisterUnityClass<Texture2D>("Core");
	//78. Texture2DArray
	RegisterUnityClass<Texture2DArray>("Core");
	//79. Texture3D
	RegisterUnityClass<Texture3D>("Core");
	//80. TimeManager
	RegisterUnityClass<TimeManager>("Core");
	//81. TrailRenderer
	RegisterUnityClass<TrailRenderer>("Core");
	//82. Transform
	RegisterUnityClass<Transform>("Core");
	//83. PlayableDirector
	RegisterUnityClass<PlayableDirector>("Director");
	//84. Grid
	RegisterUnityClass<Grid>("Grid");
	//85. GridLayout
	RegisterUnityClass<GridLayout>("Grid");
	//86. ParticleSystem
	RegisterUnityClass<ParticleSystem>("ParticleSystem");
	//87. ParticleSystemRenderer
	RegisterUnityClass<ParticleSystemRenderer>("ParticleSystem");
	//88. BoxCollider
	RegisterUnityClass<BoxCollider>("Physics");
	//89. CapsuleCollider
	RegisterUnityClass<CapsuleCollider>("Physics");
	//90. CharacterController
	RegisterUnityClass<CharacterController>("Physics");
	//91. Collider
	RegisterUnityClass<Collider>("Physics");
	//92. Joint
	RegisterUnityClass<Unity::Joint>("Physics");
	//93. MeshCollider
	RegisterUnityClass<MeshCollider>("Physics");
	//94. PhysicsManager
	RegisterUnityClass<PhysicsManager>("Physics");
	//95. Rigidbody
	RegisterUnityClass<Rigidbody>("Physics");
	//96. SphereCollider
	RegisterUnityClass<SphereCollider>("Physics");
	//97. SpringJoint
	RegisterUnityClass<Unity::SpringJoint>("Physics");
	//98. BoxCollider2D
	RegisterUnityClass<BoxCollider2D>("Physics2D");
	//99. CircleCollider2D
	RegisterUnityClass<CircleCollider2D>("Physics2D");
	//100. Collider2D
	RegisterUnityClass<Collider2D>("Physics2D");
	//101. CompositeCollider2D
	RegisterUnityClass<CompositeCollider2D>("Physics2D");
	//102. Physics2DSettings
	RegisterUnityClass<Physics2DSettings>("Physics2D");
	//103. PolygonCollider2D
	RegisterUnityClass<PolygonCollider2D>("Physics2D");
	//104. Rigidbody2D
	RegisterUnityClass<Rigidbody2D>("Physics2D");
	//105. Font
	RegisterUnityClass<TextRendering::Font>("TextRendering");
	//106. TextMesh
	RegisterUnityClass<TextRenderingPrivate::TextMesh>("TextRendering");
	//107. Tilemap
	RegisterUnityClass<Tilemap>("Tilemap");
	//108. TilemapRenderer
	RegisterUnityClass<TilemapRenderer>("Tilemap");
	//109. Canvas
	RegisterUnityClass<UI::Canvas>("UI");
	//110. CanvasGroup
	RegisterUnityClass<UI::CanvasGroup>("UI");
	//111. CanvasRenderer
	RegisterUnityClass<UI::CanvasRenderer>("UI");
	//112. WheelCollider
	RegisterUnityClass<WheelCollider>("Vehicles");
	//113. VideoPlayer
	RegisterUnityClass<VideoPlayer>("Video");

}
