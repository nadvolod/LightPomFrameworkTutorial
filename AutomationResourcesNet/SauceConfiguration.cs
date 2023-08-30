namespace AutomationResourcesNet;

public class SauceConfiguration
{
    public string OS;
    public string Browser { get; set; }
    public string Version { get; set; }
    public string DeviceName { get; set; }
    public string DeviceOrientation { get; set; }
    public string TestCaseName { get; set; }
}
