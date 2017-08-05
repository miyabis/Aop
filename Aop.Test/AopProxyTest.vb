Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class AopProxyTest

	<TestMethod()>
	Public Sub TestNames()
		Dim pointcut As Aop.Pointcut

		pointcut = New Aop.Pointcut(New String() {"HogeHoge"})
		Assert.AreEqual(1, pointcut.Names.Count)
	End Sub

	<TestMethod()>
	Public Sub TestIsApplied()
		Dim pointcut As Aop.Pointcut

		pointcut = New Aop.Pointcut(New String() {"HogeHoge"})
		Assert.IsTrue(pointcut.IsApplied("HogeHoge"))
		Assert.IsFalse(pointcut.IsApplied("Hoge"))
	End Sub

	<TestMethod()>
	Public Sub TestCase1()
		Dim pointcut As Aop.Pointcut
		Dim aspect As Aop.Aspect
		Dim proxy As Aop.AopProxy
		Dim bark As IBark

		pointcut = New Aop.Pointcut(New String() {"Bark"})
		aspect = New Aop.Aspect(New CatInterceptor, pointcut)
		proxy = New Aop.AopProxy(GetType(IBark), New Aop.Aspect() {aspect})
		bark = DirectCast(proxy.GetTransparentProxy(), IBark)
		Assert.AreEqual("「にゃー！」だよ。", bark.Bark)
	End Sub

	<TestMethod()>
	Public Sub TestCase2()
		Dim proxy As Aop.AopProxy
		Dim bark As IBarkEx

		proxy = New Aop.AopProxy(GetType(BarkEx))
		bark = DirectCast(proxy.GetTransparentProxy(), IBarkEx)
		Assert.AreEqual("「hoge hoge！」だよ。", bark.Bark("hoge hoge"))
	End Sub

End Class


Public Interface IBark

	Function Bark() As String

End Interface

Public Class CatInterceptor
	Implements Aop.IMethodInterceptor

	Public Function Invoke(ByVal invocation As Aop.IMethodInvocation) As Object Implements Aop.IMethodInterceptor.Invoke
		Return "「にゃー！」だよ。"
	End Function

End Class

Public Interface IBarkEx

	Function Bark(ByVal message As String) As String

End Interface

Public Class BarkEx
	Inherits MarshalByRefObject
	Implements IBarkEx

	Public Function Bark(ByVal message As String) As String Implements IBarkEx.Bark
		Return "「" & message & "！」だよ。"
	End Function

End Class
