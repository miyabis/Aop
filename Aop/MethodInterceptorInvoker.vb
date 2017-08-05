
Friend Class MethodInterceptorInvoker
	Implements IMethodInterceptor

	''' <summary>���̃}�b�`���O����</summary>
	Private _interceptor As IMethodInterceptor

	Private _next As MethodInterceptorInvoker

	''' <summary>
	''' ���炢�񂵂̐��ݒ肵�܂��B
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
