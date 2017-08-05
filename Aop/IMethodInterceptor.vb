
''' <summary>
''' メソッドに対するInterceptorのインターフェイス
''' </summary>
''' <remarks></remarks>
Public Interface IMethodInterceptor

	Function Invoke(ByVal invocation As IMethodInvocation) As Object

End Interface
