using System.Drawing;

namespace Sagittarius.Graphics;

#pragma warning disable CA1416

public class ColorsBuffer{
    Bitmap bitmap;
    public Color this[int j,int i] { get { try { return bitmap.GetPixel(j, i); } catch (Exception e) { return Color.White; } } }

    public int Width { get { return bitmap.Width; } }
    public int Height { get { return bitmap.Height; } }

    public ColorsBuffer(string path) {
        bitmap = new Bitmap(1,1);
        if (!File.Exists(path))
            return;
        bitmap = new Bitmap(path);
    }

    public Color[] GetSlice(int index) {

        Color[] result = new Color[Height];
        for (int i = 0; i < Height;i++) {
            result[i] = bitmap.GetPixel(index, i);
        }
        return result;
    }

}
