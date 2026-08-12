Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class ObjectOfValues

    <TestMethod()> Public Sub ObjectOfInteger()
        Dim int As New FoundationLibrary.ValueOfObject.ObjectOfInteger(1)

        Console.WriteLine(int.Value)
        Assert.AreEqual(int.Value, 1)
    End Sub

    <TestMethod> Public Sub ObjectOfString()
        Dim str As New FoundationLibrary.ValueOfObject.ObectOfString("Malakia")
        Console.WriteLine(str.Value)
        Assert.AreEqual(str.Value, "Malakia")
    End Sub

    <TestMethod()> Public Sub ObjectOfDate()
        Dim dat As New FoundationLibrary.ValueOfObject.OBjectOfDate("23/06/1995")
        Console.WriteLine(Format(dat.Value, "dd/MM/yyyy"))
        Assert.AreEqual(Format(dat.Value, "dd/MM/yyyy"), "23/06/1995")
    End Sub

    <TestMethod> Public Sub ObjectOfBoolean()
        Dim Bool As New FoundationLibrary.ValueOfObject.ObjectOfBoolean(0)
        Console.WriteLine(Bool.Value)
        Assert.IsFalse(Bool.Value)
    End Sub

    <TestMethod> Public Sub ObjectOfDouble()
        Dim Doub As New FoundationLibrary.ValueOfObject.ObjectOfDouble(0.25)
        Console.WriteLine(Doub.Value)
        Assert.AreEqual(Doub.Value, 0.25)
    End Sub

End Class