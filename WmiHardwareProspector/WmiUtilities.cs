using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WmiHardwareProspector
{
    internal static class WmiUtilities
    {
        static IEnumerable<(string, string)> PrepareResult(this ManagementObjectCollection instanceCollection)
        {
            if (instanceCollection == null || instanceCollection.Count == 0)
                return null;

            if (instanceCollection.Count == 1)
            {
                return instanceCollection.OfType<ManagementObject>()
                                         .First()
                                         .Properties
                                         .OfType<PropertyData>()
                                         .Select(p => (p.Name, Flattened(p.Value)));
            }
            else
            {
                var propertyList = new List<(string, string)>();

                var instanceList = instanceCollection.OfType<ManagementObject>()
                                                     .Select((managementObject, index) => (Index: index, Data: managementObject));

                foreach (var instance in instanceList)
                {
                    propertyList.Add(("#", instance.Index.ToString()));
                    propertyList.AddRange(instance.Data
                                                  .Properties
                                                  .OfType<PropertyData>()
                                                  .Select(p => (p.Name, Flattened(p.Value)))
                                         );
                }

                return propertyList;
            }
            // End of method

            // Local Function
            static string Flattened(object value)
                => (value?.GetType().IsArray ?? false)
                 ? string.Join(", ", (value as Array).OfType<object>())
                 : Convert.ToString(value);
        }

        static IEnumerable<(string, string)> GetHardwareInformation(string className)
        {
            try
            {
                using var managementClass = new ManagementClass(className);
                using var instanceCollection = managementClass.GetInstances();

                return instanceCollection.PrepareResult();
            }
            catch (Exception ex)
            {
                return new (string, string)[] { ("Error", ex.ToString()) };
            }
        }

        static IEnumerable<(string, string)> SearchHardwareInformation(string query)
        {
            try
            {
                using var managementObjectSearcher = new ManagementObjectSearcher(query);
                using var instanceCollection = managementObjectSearcher.Get();

                return instanceCollection.PrepareResult();
            }
            catch (Exception ex)
            {
                return new (string, string)[] { ("Error", ex.ToString()) };
            }
        }

        internal static IEnumerable<(string, string)> GetBiosInformation()
            => GetHardwareInformation("Win32_BIOS");

        internal static IEnumerable<(string, string)> GetComputerSystemInformation()
            => GetHardwareInformation("Win32_ComputerSystem");

        internal static IEnumerable<(string, string)> GetBaseBoardInformation()
            => GetHardwareInformation("Win32_BaseBoard");

        internal static IEnumerable<(string, string)> GetProcessorInformation()
            => GetHardwareInformation("Win32_Processor");

        internal static IEnumerable<(string, string)> GetDiskDriveInformation()
            => GetHardwareInformation("Win32_DiskDrive");

        internal static IEnumerable<(string, string)> GetNetworkAdapterInformation()
            => SearchHardwareInformation("SELECT * FROM Win32_NetworkAdapter WHERE PhysicalAdapter = True AND NetEnabled = True");
    }
}
