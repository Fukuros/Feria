using System.IO;
using UnityEngine;

public class Dump : MonoBehaviour
{
    private string Filename = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "\\Dump.txt";
    private StreamWriter writer;

    public void Start()
    {
        GameObject[] rootGameObjects = gameObject.scene.GetRootGameObjects();

        using (writer = new StreamWriter(Filename, false))
        {
            for (int gameObjectIndex = 0; gameObjectIndex < rootGameObjects.Length; gameObjectIndex++)
            {
                DumpGameObjects(rootGameObjects[gameObjectIndex], 0);
            }
        }

        Application.Quit();
    }

    private void DumpGameObjects(GameObject gameObject, int level)
    {
        for (int i = 0; i < level; ++i)
            writer.Write("-");

        writer.WriteLine(string.Format("[(GameObject) Name: {0}, Tag: {1}]\n", gameObject.name, gameObject.tag));
        DumpComponents(gameObject, level + 1);

        for (int childIndex = 0; childIndex < gameObject.transform.childCount; ++childIndex)
        {
            DumpGameObjects(gameObject.transform.GetChild(childIndex).gameObject, level + 1);
        }
    }

    private void DumpComponents(GameObject gameObject, int level)
    {
        for (int i = 0; i < level; ++i)
            writer.Write("-");

        foreach (Component component in gameObject.GetComponents(typeof(Component)))
        {
            writer.WriteLine(string.Format("[(Component) Type: {0}]\n", component.GetType()));
        }
    }
}