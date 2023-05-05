# Hardware Laboratory (Solution)
A place to explore hardware information in Microsoft&trade; Windows&copy;

## WMI Hardware Prospector (Project)
A console application to retrieve information about some hardware in Windows using WMI.

### Usage:
```Batchfile
D:\>prospect
D:\>prospect @hardware-id
D:\>prospect @hardware-id @printing-style
D:\>prospect @hardware-id @printing-style "@caption"
```
### Parameters:
| Name | Acceptable values |
| :---: | --- |
| hardware-id | `bios`<br>`system`<br>`board`<br>`cpu`<br>`storage`<br>`network`<br><br>[**blank**]: will be interpreted as `bios`. |
| printing-style | `list`<br>`table`<br><br>[**blank**]: will be interpreted as `list`. |
| caption | ny description as you wish, wrapped by double quots(")<br><br>[**blank**]: **hardware-id** value will be used instead. |

### Examples:
| Command | Description |
| --- | --- |
| `prospect` | Show information about BIOS in form of a list with caption set as "BIOS". |
| `prospect cpu` | Show information about CPU in form of a list with caption set as "CPU". |
| `prospect cpu list` | Show information about CPU in form of a list with caption set as "CPU". |
| `prospect cpu table` | Show information about CPU in form of a table with caption set as "CPU". |
| `prospect cpu table "My Processor"` | Show information about CPU in form of a table with header caption set as "**My Processor**". |

### Execution result as list
```Batchfile
D:\>prospect

== BIOS
 - BiosCharacteristics: 7, 11, 12, 15, 16, 19, 20, 21, 22, 23, 24, 25, 27, 30, 32, 33, 40, 42, 43
 - BIOSVersion: ACRSYS - 2, V1.21, INSYDE Corp. - 59193121
 - BuildNumber:
 - Caption: V1.21
 - CodeSet:
 - CurrentLanguage:
 - Description: V1.21
 - EmbeddedControllerMajorVersion: 1
 - EmbeddedControllerMinorVersion: 8
 - IdentificationCode:
 - InstallableLanguages:
 - InstallDate:
 - LanguageEdition:
 - ListOfLanguages:
 - Manufacturer: Insyde Corp.
 - Name: V1.21
 - OtherTargetOS:
 - PrimaryBIOS: True
 - ReleaseDate: 20200703000000.000000+000
 - SerialNumber: N....................0
 - SMBIOSBIOSVersion: V1.21
 - SMBIOSMajorVersion: 3
 - SMBIOSMinorVersion: 2
 - SMBIOSPresent: True
 - SoftwareElementID: V1.21
 - SoftwareElementState: 3
 - Status: OK
 - SystemBiosMajorVersion: 1
 - SystemBiosMinorVersion: 21
 - TargetOperatingSystem: 0
 - Version: ACRSYS - 2

Press any key to exit...
```
### Execution result as table
```Batchfile
D:\>prospect bios table "My BIOS"

--------------------------------------------------------------------------------------------------------------
|                                                  My BIOS                                                   |
--------------------------------------------------------------------------------------------------------------
| BiosCharacteristics            | 7, 11, 12, 15, 16, 19, 20, 21, 22, 23, 24, 25, 27, 30, 32, 33, 40, 42, 43 |
--------------------------------------------------------------------------------------------------------------
| BIOSVersion                    | ACRSYS - 2, V1.21, INSYDE Corp. - 59193121                                |
--------------------------------------------------------------------------------------------------------------
| BuildNumber                    |                                                                           |
--------------------------------------------------------------------------------------------------------------
| Caption                        | V1.21                                                                     |
--------------------------------------------------------------------------------------------------------------
| CodeSet                        |                                                                           |
--------------------------------------------------------------------------------------------------------------
| CurrentLanguage                |                                                                           |
--------------------------------------------------------------------------------------------------------------
| Description                    | V1.21                                                                     |
--------------------------------------------------------------------------------------------------------------
| EmbeddedControllerMajorVersion | 1                                                                         |
--------------------------------------------------------------------------------------------------------------
| EmbeddedControllerMinorVersion | 8                                                                         |
--------------------------------------------------------------------------------------------------------------
| IdentificationCode             |                                                                           |
--------------------------------------------------------------------------------------------------------------
| InstallableLanguages           |                                                                           |
--------------------------------------------------------------------------------------------------------------
| InstallDate                    |                                                                           |
--------------------------------------------------------------------------------------------------------------
| LanguageEdition                |                                                                           |
--------------------------------------------------------------------------------------------------------------
| ListOfLanguages                |                                                                           |
--------------------------------------------------------------------------------------------------------------
| Manufacturer                   | Insyde Corp.                                                              |
--------------------------------------------------------------------------------------------------------------
| Name                           | V1.21                                                                     |
--------------------------------------------------------------------------------------------------------------
| OtherTargetOS                  |                                                                           |
--------------------------------------------------------------------------------------------------------------
| PrimaryBIOS                    | True                                                                      |
--------------------------------------------------------------------------------------------------------------
| ReleaseDate                    | 20200703000000.000000+000                                                 |
--------------------------------------------------------------------------------------------------------------
| SerialNumber                   | N....................0                                                    |
--------------------------------------------------------------------------------------------------------------
| SMBIOSBIOSVersion              | V1.21                                                                     |
--------------------------------------------------------------------------------------------------------------
| SMBIOSMajorVersion             | 3                                                                         |
--------------------------------------------------------------------------------------------------------------
| SMBIOSMinorVersion             | 2                                                                         |
--------------------------------------------------------------------------------------------------------------
| SMBIOSPresent                  | True                                                                      |
--------------------------------------------------------------------------------------------------------------
| SoftwareElementID              | V1.21                                                                     |
--------------------------------------------------------------------------------------------------------------
| SoftwareElementState           | 3                                                                         |
--------------------------------------------------------------------------------------------------------------
| Status                         | OK                                                                        |
--------------------------------------------------------------------------------------------------------------
| SystemBiosMajorVersion         | 1                                                                         |
--------------------------------------------------------------------------------------------------------------
| SystemBiosMinorVersion         | 21                                                                        |
--------------------------------------------------------------------------------------------------------------
| TargetOperatingSystem          | 0                                                                         |
--------------------------------------------------------------------------------------------------------------
| Version                        | ACRSYS - 2                                                                |
--------------------------------------------------------------------------------------------------------------

Press any key to exit...
```

## Limitations
  - Just works on Microsoft Windows 10+
  - Needs Microsoft .NET 7.0 for building and execution

## Creator

**Arash Laylazi**

- GitHub: <https://github.com/PerseusTheGreat>
- Linked-In: <https://www.linkedin.com/in/laylazithegreat>
- Telegram: <https://t.me/laylazi>

## Copyright and license

Code copyright 2023 the [Arash Laylazi](https://github.com/PerseusTheGreat).
Code released under the [MIT License](https://github.com/PerseusTheGreat/HardwareLab/blob/main/LICENSE). 
