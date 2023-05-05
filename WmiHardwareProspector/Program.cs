using WmiHardwareProspector;
using static WmiHardwareProspector.WmiUtilities;

//GetEmptyDataForTestPrintingMethods().PrintList("Short Caption");
//GetEmptyDataForTestPrintingMethods().PrintList("L..o..n..g C..a..p..t..i..o..n");

//GetEmptyDataForTestPrintingMethods().PrintTable("Short Caption");
//GetEmptyDataForTestPrintingMethods().PrintTable("L..o..n..g C..a..p..t..i..o..n");

try
{
    HardwareType hardwareType = HardwareType.BIOS;
    PrintStyle printStyle = PrintStyle.List;
    string caption = null;

    if (args?.Any() ?? false)
    {
        if (args.Length >= 1 && args[0] != null)
            Enum.TryParse(args[0], ignoreCase: true, out hardwareType);

        if (args.Length >= 2 && args[1] != null)
            Enum.TryParse(args[1], ignoreCase: true, out printStyle);

        if (args.Length >= 3 && args[2] != null)
            caption = args[2];
    }

    if (string.IsNullOrWhiteSpace(caption))
        caption = hardwareType.ToString();

    Func<IEnumerable<(string, string)>> getInfoMethod = hardwareType switch
    {
        HardwareType.BIOS => GetBiosInformation,
        HardwareType.System => GetComputerSystemInformation,
        HardwareType.Board => GetBaseBoardInformation,
        HardwareType.CPU => GetProcessorInformation,
        HardwareType.Storage => GetDiskDriveInformation,
        HardwareType.Network => GetNetworkAdapterInformation,
        _ => GetBiosInformation
    };

    if (printStyle == PrintStyle.Table)
        getInfoMethod().PrintTable(caption);
    else
        getInfoMethod().PrintList(caption);
}
catch (Exception x)
{
    Console.WriteLine(x.Message);
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();