
Friend Class MethodInterceptorInvoker
	Implements IMethodInterceptor

	''' <summary>次のマッチング処理</summary>
	Private _interceptor As IMethodInterceptor

	Private _next As MethodInterceptorInvoker

	''' <summary>
	''' たらい回しの先を設定します。
	''' </summary>
	''' <param name="interceptor"></param>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function SetInterceptor(ByVal interceptor As IMethodInterceptor) As MethodInterceptorInvoker
		_interceptor = interceptor

		_next = New MethodInterceptorInvoker
		Return _next
	End Function

	Public Function Invoke(ByVal invocation As IMethodInvocation) As Object Implements IMethodInterceptor.Invoke
		Return _interceptor.Invoke(invocation)
	End Function

End Class
