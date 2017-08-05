
''' <summary>
''' 横断的な関心事が持つ振る舞い（処理のこと）と、いつ振る舞いを適用するかをまとめたものです。
''' つまり、AdviceとPointcutをまとめたものをAspect(アスペクト)といいます。
''' </summary>
''' <remarks></remarks>
Public Class Aspect

	Private _interceptor As IMethodInterceptor

	Private _pointcut As Pointcut

	''' <summary>
	''' コンストラクタ
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
