namespace Sagittarius.Platform.Config;

#pragma warning disable CS8618 

internal class WindowSettings{

    public int SizeX { get; set; }
    public int SizeY { get; set; }

    public WindowBorder windowBorder { get; set; }
    public WindowState windowState { get; set; }
    public string Title { get; set; }

    public ContextFlags contextFlags { get; set; }

    public int APIVersionMajor { get; set; }
    public int APIVersionMinor { get; set; }
    public ContextProfile Profile { get; set; }
    public ContextAPI API { get; set; }

    public int NumberOfSamples { get; set; }

    public bool IsFullScrean { get; set; }

}
