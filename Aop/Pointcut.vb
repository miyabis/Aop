
''' <summary>
''' Joinpoint�̂����AAdvice��K�p������Joinpoint�𐳋K�\���Ȃǂ�p�����������g�p���či�荞�ނ��߂̃t�B���^�ł��B
''' �Ⴆ�΁AAdvice��K�p�������̂́uadd�v�ł͂��܂郁�\�b�h�����s���ꂽ���������Ƃ���ƁA
''' �������uadd*�v�Ƃ��či�荞�܂ꂽaddXxx���\�b�h�����s���ꂽ��������Advice�����s�����悤�ɂ��ł��܂��B
''' �����ł͎w�肳�ꂽ���\�b�h�����񂪈�v����Ƃ�����Advice�����s�����悤�ɂ��܂��B
''' </summary>
''' <remarks></remarks>
Public Class Pointcut

	''' <summary>
	''' ���\�b�h���̕����񃊃X�g
	''' </summary>
	Private _names As IList(Of String)

	''' <summary>
	''' �R���X�g���N�^
	''' </summary>
	''' <param name="names">���\�b�h���̕�����z��</param>
	''' <remarks></remarks>
	Public Sub New(ByVal names() As String)
		_names = New List(Of String)(names)
	End Sub

	''' <summary>
	''' ���\�b�h���̕����񃊃X�g
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property Names() As IList(Of String)
		Get
			Return _names
		End Get
	End Property

	''' <summary>
	''' �����œn���ꂽ���\�b�h����Advice��}�����邩�m�F���܂��B
	''' </summary>
	''' <param name="methodName">���\�b�h��</param>
	''' <returns>True�Ȃ�Advice��}������AFalse�Ȃ�Advice�͑}������Ȃ�</returns>
	''' <remarks></remarks>
	Public Function IsApplied(ByVal methodName As String) As Boolean
		Return _names.Contains(methodName)
	End Function

End Class
