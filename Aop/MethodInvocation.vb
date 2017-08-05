
Imports System.Reflection

Public Class MethodInvocation
	Implements IMethodInvocation

	Private _this As Object

	Private _method As MethodBase

	Private _args() As Object

	Private _interceptor As IMethodInterceptor

	Public Sub New(ByVal this As Object, ByVal method As MethodBase, ByVal args() As Object, ByVal interceptor As IMethodInterceptor)
		_this = this
		_method = method
		_args = args
		_interceptor = interceptor
	End Sub

	Public ReadOnly Property Args() As Object() Implements IMethodInvocation.Args
		Get
			Return _args
		End Get
	End Property

	Public ReadOnly Property Method() As MethodBase Implements IMethodInvocation.Method
		Get
			Return _method
		End Get
	End Property

	Public ReadOnly Property This() As Object Implements IMethodInvocation.This
		Get
			Return _this
		End Get
	End Property

	Public Function Proceed() As Object Implements IMethodInvocation.Proceed
		If _interceptor IsNot Nothing Then
			Return _interceptor.Invoke(Me)
		End If

		Return _method.Invoke(_this, _args)
	End Function

End Class
