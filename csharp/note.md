```csharp
SpeechSynthesizer synth = new ();
//等同於
SpeechSynthesizer synth = new SpeechSynthesizer();
```

```csharp
// 自動推斷a型別
var a = "123";
```

```csharp
public string Name
{
    get { return name; }
    set { name = value; } // value是這括號裡面就有的變數，不能更名
}
// 等同於
public string Name
{
   get;
set;
}
```
