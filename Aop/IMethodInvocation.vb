
Imports System.Reflection

''' <summary>
''' Interceptor����C���^�[�Z�v�g����Ă��郁�\�b�h�̏��ɃA�N�Z�X���邽�߂̃C���^�[�t�F�C�X
''' </summary>
''' <remarks></remarks>
Public Interface IMethodInvocation

	ReadOnly Property Method() As MethodBase

	ReadOnly Property This() As Object

	ReadOnly Property Args() As Object()

	Function Proceed() As Object

End Interface
