Imports System.ComponentModel
Imports System.Runtime.InteropServices
Public Class InfoDialog

    Private Const SWP_NOSIZE As Integer = &H1
    Private Const SWP_NOMOVE As Integer = &H2
    Private Const SWP_SHOWWINDOW As Integer = &H40

    Private Const HWND_TOPMOST As Integer = -1
    Private Const HWND_NOTOPMOST As Integer = -2

    Dim TimeCount As Integer
    Dim CloseThread As New Threading.Thread(New Threading.ThreadStart(AddressOf Close_Timer))

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetWindowPos(hWnd As IntPtr,
    hWndInsertAfter As Integer,
    x As Integer, y As Integer, cx As Integer, cy As Integer,
    uFlags As Integer) _
    As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function
    'このメソッドでフォームを表示します
    Public Sub ShowWithoutActive()
        Const HWND_TOPMOST As Integer = -1
        Const SWP_NOSIZE As Integer = &H1
        Const SWP_NOMOVE As Integer = &H2
        Const SWP_NOACTIVATE As Integer = &H10
        Const SWP_SHOWWINDOW As Integer = &H40

        SetWindowPos(Me.Handle, HWND_TOPMOST, 0, 0, 0, 0,
        SWP_NOACTIVATE Or SWP_NOMOVE Or SWP_NOSIZE Or SWP_SHOWWINDOW)

    End Sub

    ' ShowWithoutActivationプロパティのオーバーライド
    Protected Overrides ReadOnly Property ShowWithoutActivation() As Boolean
        Get
            Return True
        End Get
    End Property
    Private Sub CloseTimer_Tick(sender As System.Object, e As System.EventArgs) Handles CloseTimer.Tick
        If TimeCount >= 5000 Then
            Me.Close()
        Else
            TimeCount += CloseTimer.Interval
        End If
    End Sub

    Private Sub PopDialog_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
    Private Sub Close_Timer()
        Dim SW As New Stopwatch
        SW.Start()
        Do While (SW.ElapsedMilliseconds < 5000)
            Threading.Thread.Sleep(500)
        Loop
        SW.Stop()
        Me.Invoke(
            Sub()
                    Me.Close()
                End Sub
          )
    End Sub

    Private Sub InfoDialog_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            TimeCount = 0

            CloseThread = New Threading.Thread(New Threading.ThreadStart(AddressOf Close_Timer))
            CloseThread.IsBackground = True
            CloseThread.Start()
        End If
    End Sub

End Class