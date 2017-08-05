
''' <summary>
''' ���f�I�Ȋ֐S�������U�镑���i�����̂��Ɓj�ƁA���U�镑����K�p���邩���܂Ƃ߂����̂ł��B
''' �܂�AAdvice��Pointcut���܂Ƃ߂����̂�Aspect(�A�X�y�N�g)�Ƃ����܂��B
''' </summary>
''' <remarks></remarks>
Public Class Aspect

	Private _interceptor As IMethodInterceptor

	Private _pointcut As Pointcut

	''' <summary>
	''' �R���X�g���N�^
	''' </summary>
	''' <param name="interceptor">MethodInterceptor</param>
	''' <param name="pointcut">Pointcut</param>
	''' <remarks></remarks>
	Public Sub New(ByVal interceptor As IMethodInterceptor, ByVal pointcut As Pointcut)
		_interceptor = interceptor
		_pointcut = pointcut
	End Sub

	Public ReadOnly Property Interceptor() As IMethodInterceptor
		Get
			Return _interceptor
		End Get
	End Property

	Public ReadOnly Property Pointcut() As Pointcut
		Get
			Return _pointcut
		End Get
	End Property

End Class
