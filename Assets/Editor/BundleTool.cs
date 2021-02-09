using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BundleTool : MonoBehaviour
{
    [MenuItem("Tool/Bundle")]
    public static void Bundle()
    {
        var names = AssetDatabase.GetAllAssetBundleNames();
        var builds = new List<AssetBundleBuild>();
        foreach(string name in names)
        {
            var assetPaths = AssetDatabase.GetAssetPathsFromAssetBundle(name);
            if(assetPaths == null || assetPaths.Length <= 0) continue;
            string[] nv = name.Split('.');
            var build = new AssetBundleBuild() { assetBundleName = nv[0], assetNames = assetPaths };
            if(nv.Length > 1)
            {
                build.assetBundleVariant = nv[1];
            }
            builds.Add(build);
        }
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, builds.ToArray()
            , BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.DeterministicAssetBundle
            , BuildTarget.Android);
        //BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath
        //    , BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.DeterministicAssetBundle
        //    , BuildTarget.Android);
    }
}
