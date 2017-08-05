
Imports System.Runtime.Remoting.Proxies
Imports System.Runtime.Remoting.Messaging
Imports System.Reflection

''' <summary>
''' 透過的プロクシ
''' </summary>
''' <remarks></remarks>
Public Class AopProxy
	Inherits RealProxy

	''' <summary>透過的プロクシを作成する型</summary>
	Private _type As Type

	Private _aspects() As Aop.Aspect

	''' <summary>透過的プロクシを作成するインスタンス</summary>
	Private _target As Object

#Region " コンストラクタ "

	''' <summary>
	''' コンストラクタ
	''' </summary>
	''' <param name="type">透過的プロクシを作成する型</param>
	''' <remarks></remarks>
	Public Sub New(ByVal type As Type)
		MyBase.New(type)
		_type = type
	End Sub

	''' <summary>
	''' コンストラクタ
	''' </summary>
	''' <param name="type">透過的プロクシを作成する型</param>
	''' <param name="aspects"></param>
	''' <remarks></remarks>
	Public Sub New(ByVal type As Type, ByVal aspects() As Aop.Aspect)
		Me.New(type, aspects, Nothing)
	End Sub

	''' <summary>
	''' コンストラクタ
	''' </summary>
	''' <param name="type">透過的プロクシを作成する型</param>
	''' <param name="aspects"></param>
	''' <param name="target">透過的プロクシを作成するインスタンス</param>
	''' <remarks></remarks>
	Public Sub New(ByVal type As Type, ByVal aspects() As Aop.Aspect, ByVal target As Object)
		Me.New(type)
		_aspects = aspects
		_target = target
	End Sub

#End Region

	Public Overrides Function Invoke(ByVal msg As System.Runtime.Remoting.Messaging.IMessage) As System.Runtime.Remoting.Messaging.IMessage
		Dim mm As IMethodMessage
		Dim method As MethodInfo
		Dim args() As Object
		Dim ret As Object

		ret = Nothing
		mm = DirectCast(msg, IMethodMessage)
		method = DirectCast(mm.MethodBase, MethodInfo)
		args = mm.Args

		If Not _type.IsInterface Then
			_target = Activator.CreateInstance(_type)
		End If
		If _target Is Nothing Then
			_target = New Object()
		End If

		If _aspects Is Nothing Then
			ret = method.Invoke(_target, args)
		Else
			Dim invocation As Aop.IMethodInvocation
			For Each aspect As Aop.Aspect In _aspects
				If Not aspect.Pointcut.IsApplied(method.Name) Then
					Continue For
				End If
				invocation = New Aop.MethodInvocation(_target, method, args, aspect.Interceptor)
				ret = aspect.Interceptor.Invoke(invocation)
			Next
		End If

		Dim mrm As IMethodReturnMessage
		mrm = New ReturnMessage(ret, args, args.Length, mm.LogicalCallContext, DirectCast(msg, IMethodCallMessage))
		Return mrm
	End Function

End Class
