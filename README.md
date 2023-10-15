Task list:

1. Upload the file "Input.csv" and "TypeInfos.json"
2. Perform a connection with TypeInfos for each line from Input.csv.json by type.

**Example:**

For the string:  root.SSN1.ZRP1.IL2.ZD1 type is specified.
it should work out:

| tag | offset |
| ------ | ------ |
| root.SSN1.ZRP1.IL2.ZD1.Cmd | offset |
| root.SSN1.ZRP1.IL2.ZD1.Time01 | offset |
| root.SSN1.ZRP1.IL2.ZD1.Time02 | offset |
| root.SSN1.ZRP1.IL2.ZD1.Time03 | offset |
| ..... |  |
| root.SSN1.ZRP1.IL2.ZD1.Time11_in | offset |
| root.SSN1.ZRP1.IL2.ZD1.Time12_in | offset |
| root.SSN1.ZRP1.IL2.ZD1.Time13_in | offset |

where *offset* is the offset from the previous one by the size of the data type

| tag | offset |
| ------ | ------ |
| root.SSN1.ZRP1.IL2.ZD1.Cmd | 0 |
| root.SSN1.ZRP1.IL2.ZD1.Time01 | 4 |
| root.SSN1.ZRP1.IL2.ZD1.Time02 | 12 |
| root.SSN1.ZRP1.IL2.ZD1.Time03 | 20 |

3.  Save the received value in XML format according to the template.
```xml
<item Binding="Introduced">
    <node-path>{{ tag }}</node-path>
    <address>{{ offset }}</address>
</item>
```
4. Implement a graphical interface for uploading *.csv files and selecting lines.csv required for conversion.
