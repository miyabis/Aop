
Imports System.Reflection

''' <summary>
''' Interceptorからインターセプトされているメソッドの情報にアクセスするためのインターフェイス
''' </summary>
''' <remarks></remarks>
Public Interface IMethodInvocation

	ReadOnly Property Method() As MethodBase

	ReadOnly Property This() As Object

	ReadOnly Property Args() As Object()

	Function Proceed() As Object

End Interface
