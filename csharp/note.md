#### 美化.net publish 檔案
https://github.com/nulastudio/NetBeauty2
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

```csharp
// abstract class 裡面可包含abstract 或非abstract；僅提供繼承用，無法自己實例化
// abstract不提供實現方式
public abstract class Shape
{
    public abstract double CalculateArea();
    
    public void DisplayInfo()
    {
        Console.WriteLine($"Area: {CalculateArea()}");
    }
}
// private: 只在聲明的類內部可見
// public: 對所有類可見
// protected: 聲明的類內部可見、繼承的類可見
// internal: 在同一程序集內可見；開放給其他程序使用 [assembly: InternalsVisibleTo("OtherAssemblyName")]
// protected internal: 在同一程序集內或派生類中可見
// static: 無須實例化，即可調用
// Abc 不能被 new()
static class Abc {}
// Abc constructor 在該類第一次被實例化後執行唯一一次(可用作設定其他static 初始值)
public class Abc
{
    static public int Val;
    static Abc(){Val = 1;}
}
// virtual: 標記繼承後可被override
// delegate: 建立委託型別(函式宣告型式)，用該型別建立的變數，可以指派類似的函式或使用+=指派複數函式
```
```csharp
// funciton 的":"號之後，可以接base()或this()呼叫constructor
public MyClass(int x) : base(SomeOtherMethod(x))
{
    // 構造函數體
}
```
