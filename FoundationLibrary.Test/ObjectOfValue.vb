Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class ObjectOfValues

    <TestMethod()> Public Sub ObjectOfInteger()
        Dim Obj As New FoundationLibrary.ValueOfObject.ObjectOfInteger(1)
        Console.WriteLine(Obj.Value)
        Assert.AreEqual(Obj.Value, 1)
    End Sub

    <TestMethod> Public Sub ObjectOfString()
        Dim Obj As New FoundationLibrary.ValueOfObject.ObectOfString("Paok")
        Console.WriteLine(Obj.Value)
        Assert.AreEqual(Obj.Value, "Paok")
    End Sub

    <TestMethod> Public Sub ObjectOfDate()
        Dim Obj As New FoundationLibrary.ValueOfObject.OBjectOfDate("23/06/1995")
        Console.WriteLine(Obj.Value)
        Assert.AreEqual(Format(Obj.Value, "dd/MM/yyyy"), "23/06/1995")
    End Sub

    <TestMethod> Public Sub ObjectOfBoolean()
        Dim obj As New FoundationLibrary.ValueOfObject.ObjectOfBoolean
        Console.WriteLine(Obj.Value)
        Assert.AreEqual(obj.Value, False)
    End Sub

    <TestMethod> Public Sub TestError()
        Dim Err As New FoundationLibrary.Validation.Exceptions.ErrFields("Kourt", "Den egine kala", "malakia")
        Console.WriteLine(Err)
    End Sub

End Class