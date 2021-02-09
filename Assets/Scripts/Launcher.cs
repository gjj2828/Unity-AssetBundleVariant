using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum EVariant
{
    en,
    cn
}

public class Launcher : MonoBehaviour
{
    public Transform m_UIParent;
    public EVariant m_Variant;

    private static string m_ABNameUI = "ui";
    private static string m_ABNameBG = "bg";

    // Start is called before the first frame update
    void Start()
    {
        var bundleBG = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, m_ABNameBG + "." + m_Variant.ToString()));
        bundleBG.LoadAsset<Sprite>("bg");
        var bundleUI = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, m_ABNameUI));
        var assetBG = bundleUI.LoadAsset<GameObject>("BG");
        var bg = Instantiate(assetBG);
        bg.transform.parent = m_UIParent;
        bg.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
